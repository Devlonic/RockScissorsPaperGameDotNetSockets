using System.Collections;
using System.Collections.Specialized;
using System.Net.Sockets;

namespace rsp.server.game;

class PlayersList : IEnumerable<Player>, INotifyCollectionChanged {
    public PlayersList(Game game, int playersLimit) {
        this.game = game;
        this.playersLimit = playersLimit;
    }

    private List<Player> players = new List<Player>();
    private Game game;
    private int playersLimit;
    public int CountPlayers => players.Count;

    public bool AutoPlayersNotify { get; set; } = true;

    public event NotifyCollectionChangedEventHandler? CollectionChanged;
    public event EventHandler<PlayersList>? GameCanBeStarted;
    public event EventHandler<PlayersList>? RecievedFiguresFromEachPlayer;
    public event EventHandler GameErrorOccured;


    public void ResetPlayersState() {
        foreach ( var p in players ) {
            p.Figure = null;
        }
    }
    public void DisconnectEach() {
        foreach ( var p in players ) {
            p.Tcp.Dispose();
        }
        players.Clear();
        this.game.Log.State(this, $"Active Players: {players.Count}");
    }
    private List<Player> NotifyPlayersAboutThemLose(List<PlayerResult> toDisconnect) {
        ServerNotification n = new ServerNotification(ServerNotificationType.PlayerLose);
        List<Player> notifyedPlayers = new();
        foreach ( var p in players ) {
            if(toDisconnect.Find((pr)=>pr.Nick== p.Name) is PlayerResult playerToDisconnect) {
                p.Notify(n);
                notifyedPlayers.Add(p);
            }
        }
        return notifyedPlayers;
    }
    public void DisconnectRange(List<PlayerResult> toDisconnect) {
        var nplayers = NotifyPlayersAboutThemLose(toDisconnect);
        foreach ( var p in nplayers ) {
            p.Tcp.Dispose();
            players.Remove(p);
        }
        playersLimit = nplayers.Count;
        this.game.Log.State(this, $"Active Players: {players.Count}");
    }

    // auth part
    private Player AuthPlayer(TcpClient tcp) {
        if ( players.Count == playersLimit )
            throw new PlayersListOverflowException(game, this);

        var player = Player.AuthPlayer(tcp, game);
        players.Add(player);
        player.Disconected += Player_Disconected;
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, player));

        if ( AutoPlayersNotify )
            NotifyAllPlayersAboutPlayersList();

        if ( players.Count == playersLimit )
            GameCanBeStarted?.Invoke(this, this);

        return player;
    }
    public bool AlreadyAuth(string nick) {
        return !players.Exists((p)=>p.Name==nick);
    }

    // disconnect part
    private void Player_Disconected(object sender, Player player) {
        players.Remove(player);
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, player));
        game.Log.Info(this, $"{player}: disconnect");
        player.Tcp.Close();
        switch ( game.State ) {
            case GameState.Unstarted:
            break;
            case GameState.WaitForPlayers:
            if ( AutoPlayersNotify )
                NotifyAllPlayersAboutPlayersList();
            break;
            case GameState.Running:
                NotifyAllPlayersAboutGameError(GameError.PlayerDisconnectWhileGameRunning);
                GameErrorOccured?.Invoke(this, null);
            break;
            case GameState.End:
            break;
            default:
            break;
        }
    }

    // broadcast notification
    private void NotifyAllPlayersAboutGameError(GameError error) {
        var l = ( from p in players
                  select p.Name ).ToList();

        ServerNotification sn = new ServerNotification(ServerNotificationType.GameError, error);
        NotifyAllPlayers(sn, nameof(NotifyAllPlayersAboutGameError));
        
    }
    public void NotifyAllPlayersAboutPlayersList() {
        var l = ( from p in players
                  select p.Name ).ToList();

        ServerNotification sn = new ServerNotification(ServerNotificationType.PlayersListChanged, l);
        NotifyAllPlayers(sn, nameof(NotifyAllPlayersAboutPlayersList));
        this.game.Log.State(this, $"Active Players: {players.Count}");
    }
    public void NotifyAllPlayersAboutGameStart() {
        ServerNotification sn = new ServerNotification(ServerNotificationType.GameState, GameState.Running);
        NotifyAllPlayers(sn, nameof(NotifyAllPlayersAboutGameStart));
    }
    public GameResults NotifyAllPlayersAboutGameEnd() {
        GameResults r = GameResultsCalculator.Calculate(this);
        ServerNotification sn = new ServerNotification(ServerNotificationType.Results, r);
        NotifyAllPlayers(sn, nameof(NotifyAllPlayersAboutGameEnd));
        return r;
    }
    public void NotifyAllPlayersAboutGameFinish() {
        ServerNotification sn = new ServerNotification(ServerNotificationType.GameState, GameState.Finish);
        NotifyAllPlayers(sn, nameof(NotifyAllPlayersAboutGameFinish));
    }



    private void NotifyAllPlayers(ServerNotification n, string about) {
        int count = 0;
        foreach ( var p in players ) {
            p.Notify(n);
            count++;
        }
        game.Log.Info(this, $"notifyed {count} players about {about}");
    } 

    // listen players
    public void RecieveFiguresFromAllPlayers() {
        CancellationTokenSource timeoutSource = new CancellationTokenSource();
        timeoutSource.CancelAfter(GameSettings.FigureRecieveTimeout);
        int countRecieved = 0;
        foreach ( var p in players ) {
            Task.Run(async () => {
                try {
                    await p.GetFigureAsync(timeoutSource.Token);
                    Interlocked.Increment(ref countRecieved);
                    game.Log.Info(this, $"{p} recieved figure: {p.Figure}. count recieved: {countRecieved}");

                    if( countRecieved == players.Count) {
                        RecievedFiguresFromEachPlayer?.Invoke(this, this);
                        game.Log.Debug(this, $"RecievedFiguresFromEachPlayer event invoked");
                    }

                }
                catch ( OperationCanceledException e ) {
                    //game.Log.Warn(this, "Figure recieve timeout(canceled)");
                }
            });
        }
    }

    // handling raw TCP connections
    public void StartSession(TcpClient tcp) {
        try {
            var player = AuthPlayer(tcp);
            player.StartCheckingConnection();
        }
        catch ( AuthException au ) {
            game.Log.Warn(this, au.Message);
            
        }
        catch ( PlayersListOverflowException loe ) {
            game.Log.Warn(this, loe.Message);
        }

    }

    public IEnumerator<Player> GetEnumerator() {
        return ( (IEnumerable<Player>)this.players ).GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator() {
        return ( (IEnumerable)this.players ).GetEnumerator();
    }
}


using System.Net.Sockets;
using System.Numerics;

namespace rsp.server.game;

class Game {
    public GameState State { get; private set; } = GameState.Unstarted;

    public PlayersList PlayersList { get; private set; }
    public IServerLogger Log { get; private set; }
    Guid ID;
    int maxPlayers;

    public CancellationToken CancelAllConnectionChecking { get; private set; }
    private CancellationTokenSource cancelConnectionChecking;
    public Game(IServerLogger logger, int maxPlayers) {
        Log = logger;
        this.maxPlayers = maxPlayers;
        Reset(maxPlayers);
        ID = Guid.NewGuid();
    }

    private void Reset(GameResults res) {
        List<PlayerResult> losers = res.Results.Except(res.WinPlayers).ToList();
        
        PlayersList.DisconnectRange(losers);
        PlayersList.ResetPlayersState();
    }
    private void Reset(int maxPlayers) {
        this.maxPlayers = maxPlayers;

        PlayersList?.DisconnectEach();

        PlayersList = new PlayersList(this, maxPlayers);
        PlayersList.GameCanBeStarted += StartGame;
        PlayersList.RecievedFiguresFromEachPlayer += this.PlayersList_RecievedFiguresFromEachPlayer;
        PlayersList.GameErrorOccured += this.PlayersList_GameErrorOccured;

        State = GameState.WaitForPlayers;
        cancelConnectionChecking = new CancellationTokenSource();
        CancelAllConnectionChecking = cancelConnectionChecking.Token;
    }

    private void PlayersList_GameErrorOccured(object? sender, EventArgs e) {
        Reset(this.maxPlayers);
    }

    private void PlayersList_RecievedFiguresFromEachPlayer(object? sender, PlayersList e) {
        Log.Info(this, "All players send them figures. Calculating results");
        State = GameState.End;
        var res = e.NotifyAllPlayersAboutGameEnd();

        HandleGameResult(res);
    }

    

    private void HandleGameResult(GameResults res) {
        // few seconds delay

        Log.Info(this, $"Wait 10 seconds for handle current game state: {res.ResultType}");
        Thread.Sleep(10000);

        switch ( res.ResultType ) {
            case GameResultsType.Kashamalasha:
                HandleKashamalasha();
            break;
            case GameResultsType.OneWinner:
                HandleOneWinner(res);
            break;
            case GameResultsType.ManyWinners:
                HandleManyWinners(res);
            break;
            case GameResultsType.NoWinners:
                HandleNoWinners();
            break;
        }
    }

    private void HandleKashamalasha() {
        PlayersList.ResetPlayersState();
        StartGame(this, PlayersList);
    }
    private void HandleOneWinner(GameResults results) {
        // already one winner. Do not do anything,
        // just disconnect each player and send to losers notification
        this.State = GameState.Finish;

        Reset(results);

        PlayersList.NotifyAllPlayersAboutGameFinish();
        
        this.Reset(this.maxPlayers);
    }
    private void HandleManyWinners(GameResults results) {
        Reset(results);
        StartGame(this, PlayersList);
    }
    private void HandleNoWinners() {
        PlayersList.ResetPlayersState();
        StartGame(this, PlayersList);
    }

    private void StartGame(object? sender, PlayersList? e) {
        Log.Info(this, $"Game has been started with {e?.CountPlayers}!\n\n");
        State = GameState.Running;

        try {
            cancelConnectionChecking.Cancel(true);
        }
        catch ( Exception ex ) {
            Log.Error(this, ex.Message);
        }
        //todo 8
        e.NotifyAllPlayersAboutPlayersList();
        e.NotifyAllPlayersAboutGameStart();
        e.RecieveFiguresFromAllPlayers();
    }



    public void HandleTcp(TcpClient tcp) {
        if ( State != GameState.WaitForPlayers )
            throw new GameException(this, "Game state is not GameState.WaitForPlayers");

        Task.Run(() => {
            PlayersList.StartSession(tcp);
        });
    }
    public override string ToString() {
        return $"GAME";
    }
}


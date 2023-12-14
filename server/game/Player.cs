using System.Net.Sockets;
using System.Numerics;
using System.Xml.Serialization;
using System.Linq;
using System.IO;
using System.Text;

namespace rsp.server.game;

delegate void PlayerDisconectedEventHandler(object sender, Player player);

class Player {
    public Player(Game game, TcpClient tcp, string name, CancellationToken connectionCheckCancel) {
        Tcp = tcp;
        Name = name;
        Game = game;
        this.connectionCheckCancel = connectionCheckCancel;
        br = new(tcp.GetStream());
        bw = new(tcp.GetStream());
        sr = new(tcp.GetStream());

    }

    public event PlayerDisconectedEventHandler? Disconected;

    private BinaryReader br;
    private BinaryWriter bw;
    private StreamReader sr;
    private CancellationToken connectionCheckCancel;

    public TcpClient Tcp { get; set; }
    public NetworkStream? Stream => Tcp?.GetStream();
    public string Name { get; set; }
    public Figure? Figure { get; set; } = null;
    public Game Game { get; private set; }


    // auth part
    public static Player AuthPlayer(TcpClient tcp, Game game) {
        string remoteHost = tcp.Client.RemoteEndPoint.ToString();

        BinaryReader br = new BinaryReader(tcp.GetStream());
        StreamReader sr = new StreamReader(tcp.GetStream());
        game.Log.Debug(game, "waiting for client nickname");
        var nick = sr.ReadLine();
        if ( !IsCorrectNick(nick, game) ) {
            tcp.Close();
            throw new AuthException(remoteHost);
        }
        else {
            var p = new Player(game, tcp, nick, game.CancelAllConnectionChecking);
            game.Log.Info(p, "logged in");
            return p;
        }
    }
    private static bool IsCorrectNick(string? nick, Game game) {
        return 
            nick is not null && 
            game.PlayersList.AlreadyAuth(nick) && 
            nick != string.Empty && 
            nick.Length > 2;
    }

    
    public void Notify(ServerNotification sn) {
        sn.SendTo(Tcp);
    }
    public async Task GetFigureAsync(CancellationToken token) {
        try {
            var readTask = sr.ReadLineAsync();
            var f = await readTask.WithCancellation(token);

            if ( f is null || f == string.Empty ) {
                Disconected?.Invoke(this, this);
                throw new DisconnectedException(Game, this);
            }

            this.Figure = (Figure)Enum.Parse(typeof(Figure), f);
        }
        catch ( IOException e ) {
            Disconected?.Invoke(this, this);
            throw new DisconnectedException(Game, this);
        }
        catch (SocketException e) {
            Disconected?.Invoke(this, this);
            throw new DisconnectedException(Game, this);
        }
        catch(OperationCanceledException e) {
            Game.Log.Warn(this, "Figure recieve timeout(canceled)");
            Disconected?.Invoke(this, this);
            throw;
        }

    }

    public override string ToString() {
        return $"{Name}({Tcp.Client?.RemoteEndPoint})";
    }

    public void StartCheckingConnection() {
        Task.Run(async () => {
            Random random = new();
            Game.Log.Debug(this, $"begin checking connection");
            
            try {
                byte[] buf = new byte[16];

                // if client send any unexpected
                // data until game start - disconnect him

                // if client disconnect manual or
                // any other problem - handle it

                // if connectionCheckCancel will occur -
                // game started, then this will
                // throw OperationCanceledException, so StartCheckingConnection
                // must be terminated


                await Task.Run(async() => {
                    bool isErrorOccur = true;
                    do {
                        isErrorOccur = Tcp.Client.Poll(1000, SelectMode.SelectRead);
                        await Task.Delay(100);
                    } while ( !isErrorOccur && !connectionCheckCancel.IsCancellationRequested);

                    if( isErrorOccur ) {
                        Game.Log.Warn(this, "unexpected behavior. Disconnecting him...");
                        Disconected?.Invoke(this, this);
                    } else {
                        Game.Log.Info(this, "cancel checking");
                    }
                });
            }
            catch ( OperationCanceledException e ) {
                // it`s ok, so just ignore it
                
            }
        });
    }
}

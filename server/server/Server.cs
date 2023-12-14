using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using rsp.server.game;

namespace rsp.server.server;
class Server {
    Game game;
    TcpListener listener = new TcpListener(IPEndPoint.Parse("127.0.0.1:4225"));
    IServerLogger log;
    public Server(IServerLogger logger) {
        log = logger;
    }

    public override string ToString() {
        return "SERVER";
    }

    public void Start() {
        try {
            int max = 4;
            log.Info(this, "Server startup");
            listener.Start(max);
            game = new Game(log, max);

            while ( true ) {
                try {
                    log.Info(this, "Wait for TCP connection");
                    var c = listener.AcceptTcpClient();
                    log.Info(this, $"New bound TCP connection from {c.Client.RemoteEndPoint}");


                    try {
                        game.HandleTcp(c);
                    }
                    catch ( GameException ge ) {
                        log.Warn(game, ge.Message);
                        c.Close();
                    }
                }
                catch ( GameException ge ) {
                    log.Warn(game, ge.Message);

                }
                catch ( SocketException se ) {
                    log.Error(this, se.Message);
                }
            }
        }
        catch ( Exception e ) {
            log.Fatal(this, e.Message);
        }

    }
}
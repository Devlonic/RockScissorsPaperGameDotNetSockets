using rsp.server.game;
using rsp.server.server;

namespace rsp.server;
class Program {
    public static void Main(String[] args) {
        Server server = new Server(new ConsoleServerLogger());
        server.Start();
    }
}

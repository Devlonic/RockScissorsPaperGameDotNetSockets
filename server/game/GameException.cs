namespace rsp.server.game;
class GameException : ApplicationException {
    public GameException(Game game, string message) : base(message) { }
}


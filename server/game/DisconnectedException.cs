namespace rsp.server.game;

class DisconnectedException : GameException {
    public DisconnectedException(Game game, Player player) : base(game, $"{player} quit") {

    }
}

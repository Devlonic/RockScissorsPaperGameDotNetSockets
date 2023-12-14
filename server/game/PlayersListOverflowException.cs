namespace rsp.server.game;

class PlayersListOverflowException : GameException {
    public Game Game { get; private set; }
    public PlayersList PlayersList { get; private set; }
    public PlayersListOverflowException(Game game, PlayersList players) : base(game, "players list overflow") {
        this.PlayersList = players;
        this.Game = game;
    }
}


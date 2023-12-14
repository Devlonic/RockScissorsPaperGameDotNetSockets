namespace rsp {

    [Serializable]
    public class GameResults {
        public GameResultsType? ResultType { get; set; }
        public List<PlayerResult>? Results { get; set; }
        public List<PlayerResult>? WinPlayers { get; set; }
        public PlayerResult? Winner { get; set; }
    }
}

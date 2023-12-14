namespace rsp.client {
    public class GameStateChangedEventArgs : EventArgs {
        public GameStateChangedEventArgs(GameState? state, GameResults? results = null) {
            this.State = state;
            this.Results = results;
        }

        public GameState? State { get; set; }
        public GameResults? Results { get; set; } 
    }
}
namespace rsp {
    [Serializable]
    public class PlayerResult {
        public string Nick { get; set; }
        public Figure Figure { get; set; }

        public PlayerResult() {}
        public PlayerResult(string nick, Figure figure) {
            this.Nick = nick;
            this.Figure = figure;
        }

        public override string ToString() {
            return $"{Nick} {Figure}";
        }
    }
}

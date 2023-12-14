namespace rsp {
    [Serializable]
    public enum ServerNotificationType {
        PlayersListChanged, GameState, CheckConnection, GameError, Results, PlayerLose, AuthError
    }
}

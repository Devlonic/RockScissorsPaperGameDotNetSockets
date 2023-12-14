using System.Drawing;

namespace rsp.client {
    public delegate void UserAuthenticateEventHandler(object sender, string nick);
    public delegate void PlayersListChangedEventHandler(object sender, List<string> list);
    public delegate void PlayerSelectFigureEventHandler(object sender, Figure figure);
    public delegate void GameStateChangedEventHandler(object sender, GameStateChangedEventArgs args);
    public delegate void GameErrorOccuredEventHandler(object sender, GameError? error);
    public delegate void NetworkErrorOccuredEventHandler(object sender, NetworkError? error);
    
    public interface IPlayerUi {
        void PlayersListChanged(object sender, List<string> list);
        
        void BlockSelectionPossibility();
        void UnblockSelectionPossibility();

        void SetStatus(string state, Color color);
        void SetApplicationPart(ApplicationParts part);
        void HandleCriticalError(GameError? error);
        void HandleNetworkError(NetworkError? error);
        void HandleGameEnd(GameResults? results);

        void HandleGameLose();

        void HandleGameFinish();

        void StartDisplayTimer(TimeSpan time);
        void StopDisplayTimer();


        event PlayerSelectFigureEventHandler? FigureSelected;
        event UserAuthenticateEventHandler? UserAuthenticate;
    }
}
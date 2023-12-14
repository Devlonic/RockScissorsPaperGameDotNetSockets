using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace rsp.client {
    delegate void StatusDelegate(string message);

    public class Controller : IDisposable {
        private IPlayerUi ui;
        private PlayerAgent agent;
        private IPEndPoint serverHost = IPEndPoint.Parse("127.0.0.1:4225");

        // dummy name generation
        Random random = new Random();
        private List<string> dbg() {
            List<string> all = new List<string> {
                "max",
                "ivan",
                "george",
                "hermentos",
                "kamila",
                "vlad",
                "youra",
                "kalika",
            };
            return all.Where((s) => random.Next(10) < 5).ToList();
        }

        public Controller(IPlayerUi ui) {
            this.ui = ui;
            ui.FigureSelected += this.Ui_FigureSelected;
            ui.UserAuthenticate += this.Ui_UserAuthenticate;
        }

        private void Reset() {
            this.agent = new PlayerAgent(serverHost, Info, Success, Error);
            agent.PlayersListRecieved += this.Agent_PlayersListRecieved;
            agent.GameStateChanged += this.Agent_GameStateChanged;
            agent.GameErrorOccured += this.Agent_GameErrorOccured;
            agent.NetworkErrorOccured += this.Agent_NetworkErrorOccured;
            agent.UserLose += this.Agent_UserLose;
        }

        private void Agent_UserLose(object? sender, EventArgs e) {
            ui.HandleGameLose();
        }

        private void Agent_NetworkErrorOccured(object sender, NetworkError? error) {
            ui.HandleNetworkError(error);
        }

        private void Agent_GameErrorOccured(object sender, GameError? error) {
            ui.HandleCriticalError(error);
        }

        private void Agent_GameStateChanged(object sender, GameStateChangedEventArgs? args) {
            if ( args is null )
                return;
            GameState gameState = (GameState)args.State;

            switch ( gameState ) {
                case GameState.Unstarted:
                break;
                case GameState.WaitForPlayers:
                ui.SetApplicationPart(ApplicationParts.Lobby);
                break;
                case GameState.Running:
                ui.UnblockSelectionPossibility();
                ui.SetApplicationPart(ApplicationParts.Game);
                ui.StartDisplayTimer(TimeSpan.FromMilliseconds(GameSettings.FigureRecieveTimeout));
                break;
                case GameState.End:
                ui.SetApplicationPart(ApplicationParts.Results);

                ui.HandleGameEnd(args.Results);
                break;
                case GameState.Finish:
                agent.Dispose();
                ui.HandleGameFinish();
                break;
                default:
                break;
            }
        }

        private void Ui_UserAuthenticate(object sender, string nick) {
            Task.Run(async () => {
                Reset();
                agent.Nick = nick;
                var status = await agent.NewSessionAsync(nick);
                if ( status == ConnectionStatus.OK )
                    ui.SetApplicationPart(ApplicationParts.Lobby);
            });
        }

        private void Agent_PlayersListRecieved(object sender, List<string> list) {
            this.ui.PlayersListChanged(this, list);
        }

        private void Ui_FigureSelected(object sender, Figure figure) {
            this.ui.BlockSelectionPossibility();
            this.ui.StopDisplayTimer();
            Task.Run(async () => {
                await this.agent.SendFigure(figure);
            });
        }

        private void Success(string msg) {
            this.ui.SetStatus(msg, Color.Green);
        }
        private void Info(string msg) {
            this.ui.SetStatus(msg, Color.Black);
        }
        private void Error(string msg) {
            this.ui.SetStatus(msg, Color.Red);
        }

        public void Dispose() {
            this.agent.Dispose();
        }
    }
}

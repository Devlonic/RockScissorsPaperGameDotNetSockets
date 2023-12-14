using System.Net;
using System.Net.Sockets;
using System.Text;

namespace rsp.client {

    class PlayerAgent : IDisposable {
        TcpClient tcp;
        IPEndPoint host;
        StatusDelegate info, success, error;
        StreamWriter? sw;
        public string? Nick { get; set; }
        private bool isDisposed = false;
        public PlayerAgent(IPEndPoint serverHost,StatusDelegate info, StatusDelegate success, StatusDelegate error) {
            this.info = info;
            this.success = success;
            this.error = error;

            tcp = new TcpClient();
            host = serverHost;
        }

        public event PlayersListChangedEventHandler? PlayersListRecieved;
        public event GameStateChangedEventHandler? GameStateChanged;
        public event GameErrorOccuredEventHandler? GameErrorOccured;
        public event NetworkErrorOccuredEventHandler? NetworkErrorOccured;
        public event EventHandler? UserLose;


        public async Task<ConnectionStatus> NewSessionAsync(string nickname) {
            try {
                info?.Invoke($"Connecting to {host}...");
                await tcp.ConnectAsync(host);
                sw = new(tcp.GetStream());
                sw.AutoFlush = true;
                success?.Invoke($"Connected!");
                await AuthenticatePlayerAsync(nickname);
                StartTaskServerNotificationReading();
                return ConnectionStatus.OK;
            }
            catch ( SocketException se ) {
                error?.Invoke($"{se.Message}");
                return ConnectionStatus.Refused;
            }
            catch ( Exception ex ) {
                error?.Invoke($"{ex.Message}");
                return ConnectionStatus.Refused;
            }
        }

        private async Task AuthenticatePlayerAsync(string nick) {
            info?.Invoke($"Try to authenticate {nick}...");
            await sw.WriteLineAsync(nick);
            await sw.FlushAsync();
            success?.Invoke($"{nick} authenticated!");
        }
        public async Task SendFigure(Figure figure) {
            string res = figure.ToString();

            info?.Invoke($"Try to send figure {figure}...");

            await sw.WriteLineAsync(figure.ToString());
            success?.Invoke($"{figure} send!");
        }
        private void StartTaskServerNotificationReading() {
            Task.Run(async () => {
                while ( true ) {
                    var notification = await ServerNotification.ParseAsync(tcp.GetStream());
                    File.AppendAllLines($"{Nick}.txt", new[] { notification.Type.ToString() });
                    if ( notification != null ) {
                        switch ( notification.Type ) {
                            case ServerNotificationType.PlayersListChanged:
                            PlayersListRecieved?.Invoke(
                                this, 
                                notification.PlayersList??new());
                            break;
                            case ServerNotificationType.GameState:
                                HandleGameStateChange(notification);
                            break;
                            case ServerNotificationType.GameError:
                                GameErrorOccured?.Invoke(this, notification.Error);
                            break;
                            case ServerNotificationType.Results:
                                HandleGameStateChange(notification);
                            break;
                            case ServerNotificationType.PlayerLose:
                                UserLose?.Invoke(this, null);
                            break;
                            default:
                            break;
                        }
                    }
                }
            });
        }

        private void HandleCheckConnection(ServerNotification n) {
            int? token = n.CheckConnectionToken;
            if ( token.HasValue ) {
                success?.Invoke($"start token retransmit {token.Value}");
                var bw = new BinaryWriter(tcp.GetStream());
                bw.Write(token.Value);
                success?.Invoke($"token retransmit: {token.Value}");
            }
        }

        private void HandleGameStateChange(ServerNotification n) {
            GameStateChanged?.Invoke(this, new GameStateChangedEventArgs(n.GameState, n.Results));
        }

        public void Dispose() {
            tcp.Close();
            Console.Beep();
            isDisposed = true;
        }
    }
}

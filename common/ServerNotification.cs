using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace rsp {

    [Serializable]
    public class ServerNotification {
        public ServerNotification(ServerNotificationType type) {
            Type = type;
        }
        public ServerNotification(ServerNotificationType type, List<string> data) {
            this.Type = type;
            this.PlayersList = data;
        }
        public ServerNotification(ServerNotificationType type, GameState state) {
            this.Type = type;
            this.GameState = state;
        }
        public ServerNotification(ServerNotificationType type, GameError error) {
            this.Type = type;
            this.Error = error;
        }
        public ServerNotification() {

        }

        public ServerNotification(ServerNotificationType type, GameResults? results) {
            this.Type = type;
            this.GameState = rsp.GameState.End;
            this.Results = results;
        }

        public ServerNotification(ServerNotificationType type, int? token) {
            this.Type = type;
            this.CheckConnectionToken = token;
        }

        public ServerNotificationType Type { get; set; }
        public List<string>? PlayersList { get; set; }
        public GameState? GameState { get; set; }
        public GameResults? Results { get; set; }
        public GameError? Error { get; set; }
        public int? CheckConnectionToken { get; set; }

        public void SendTo(TcpClient tcp) {
            var ms = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(typeof(ServerNotification));
            xml.Serialize(ms, this);
            var bw = new BinaryWriter(tcp.GetStream());
            var arr = ms.ToArray();
            bw.Write(arr.Length);
            bw.Write(arr);
            bw.Flush();
        }

        public static async Task<ServerNotification?> ParseAsync(Stream stream) {
            int count = new BinaryReader(stream).ReadInt32();
            byte[] data = new byte[count];
            await stream.ReadAsync(data, 0, count);
            return new XmlSerializer(typeof(ServerNotification)).
                Deserialize(new MemoryStream(data)) as ServerNotification;
        }
    }
}

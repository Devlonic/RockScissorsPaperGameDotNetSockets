using System.Net.Sockets;

namespace rsp.server.game;
class AuthException : ApplicationException
{
    public TcpClient Tcp { get; set; }
    public AuthException(string remoteHost, TcpClient? tcp = null) : base($"{remoteHost} auth error")
    {
        Tcp = tcp;
    }
}


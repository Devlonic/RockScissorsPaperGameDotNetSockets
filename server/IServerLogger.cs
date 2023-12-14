namespace rsp.server;
interface IServerLogger
{
    void Info(object sender, string msg);
    void Warn(object sender, string msg);
    void Error(object sender, string msg);
    void Fatal(object sender, string msg);
    void Debug(object sender, string msg);

    void State(object sender, string msg);
}

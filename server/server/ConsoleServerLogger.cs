namespace rsp.server.server;
class ConsoleServerLogger : IServerLogger
{
    public void Debug(object sender, string msg)
    {
        Log(sender, msg, ConsoleColor.Gray);
    }

    public void Error(object sender, string msg)
    {
        Log(sender, msg, ConsoleColor.Red);
    }

    public void Fatal(object sender, string msg)
    {
        Log(sender, $"\n==========================================\n{msg}\n==========================================\n", ConsoleColor.DarkRed);
    }

    public void Info(object sender, string msg)
    {
        Log(sender, msg, ConsoleColor.White);
    }

    public void State(object sender, string msg) {
        Console.Title = msg;
    }

    public void Warn(object sender, string msg)
    {
        Log(sender, msg, ConsoleColor.Yellow);
    }

    private void Log(object sender, string msg, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"{DateTime.Now}\t{sender}:\t{msg}");
        Console.ResetColor();
    }

}
namespace Ganzenbord.Business.Logger;

public interface ILogger
{
    string Input(string message);
    void Log(string message);
}
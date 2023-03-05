namespace DesignPatterns._02_Structural._01_Adapter;

public interface ILogger
{
    void Log(string message);

    void LogError(Exception exception);
}
namespace DesignPatterns._02_Structural._01_Adapter;

public interface ILogNetMaster
{
    void LogInfo(string message);

    void LogException(Exception exception);
}
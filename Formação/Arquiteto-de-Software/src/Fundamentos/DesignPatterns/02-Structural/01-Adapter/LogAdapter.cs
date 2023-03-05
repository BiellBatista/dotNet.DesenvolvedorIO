﻿namespace DesignPatterns._02_Structural._01_Adapter;

// Adapter class
public class LogAdapter : ILogger
{
    private readonly ILogNetMaster _logNetMaster;

    public LogAdapter(ILogNetMaster logNetMaster)
    {
        _logNetMaster = logNetMaster;
    }

    public void Log(string message)
    {
        _logNetMaster.LogInfo(message);
    }

    public void LogError(Exception exception)
    {
        _logNetMaster.LogException(exception);
    }
}
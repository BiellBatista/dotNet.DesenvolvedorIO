﻿namespace DesignPatterns._02_Structural._01_Adapter;

// Target class
public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine("Log padrão - " + message);
    }

    public void LogError(Exception exception)
    {
        Console.WriteLine("Log padrão - " + exception.Message);
    }
}
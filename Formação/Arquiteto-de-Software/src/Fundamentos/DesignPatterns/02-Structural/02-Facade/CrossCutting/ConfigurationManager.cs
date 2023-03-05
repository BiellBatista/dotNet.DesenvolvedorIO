namespace DesignPatterns._02_Structural._02_Facade.CrossCutting;

public class ConfigurationManager : IConfigurationManager
{
    public string GetValue(string node)
    {
        return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
    }
}
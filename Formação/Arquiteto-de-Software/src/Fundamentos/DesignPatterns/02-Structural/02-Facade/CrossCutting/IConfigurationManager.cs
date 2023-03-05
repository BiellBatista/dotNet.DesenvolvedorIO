namespace DesignPatterns._02_Structural._02_Facade.CrossCutting;

public interface IConfigurationManager
{
    string GetValue(string node);
}
namespace DesignPatterns._03_Behavioral._02_Strategy;

public class PagamentoBoletoFacade : IPagamentoBoletoFacade
{
    public string GerarBoleto()
    {
        // GerarBoleto
        return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
    }
}
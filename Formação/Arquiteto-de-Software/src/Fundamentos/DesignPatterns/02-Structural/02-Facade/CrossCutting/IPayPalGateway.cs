namespace DesignPatterns._02_Structural._02_Facade.CrossCutting;

public interface IPayPalGateway
{
    string GetPayPalServiceKey(string apiKey, string encriptionKey);

    string GetCardHashKey(string serviceKey, string cartaoCredito);

    bool CommitTransaction(string cardHashKey, string orderId, decimal amount);
}
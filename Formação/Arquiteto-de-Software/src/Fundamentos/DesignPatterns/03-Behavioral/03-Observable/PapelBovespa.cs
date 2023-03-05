namespace DesignPatterns._03_Behavioral._03_Observable;

// Concrete Subject
public class PapelBovespa : Investimento
{
    public PapelBovespa(string simbolo, decimal preco)
        : base(simbolo, preco)
    {
    }
}
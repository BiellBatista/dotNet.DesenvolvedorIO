namespace DesignPatterns._02_Structural._03_Composite;

public class DomainMessage : IMessage
{
    public string Nome { get; set; }

    public DomainMessage(string name)
    {
        Nome = name;
    }

    public void ExibirMensagens(int sub)
    {
        Console.WriteLine(new string('-', sub) + Nome);
    }
}
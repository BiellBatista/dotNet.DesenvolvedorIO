namespace DesignPatterns._02_Structural._03_Composite;

public interface IMessage
{
    string Nome { get; set; }

    void ExibirMensagens(int sub);
}
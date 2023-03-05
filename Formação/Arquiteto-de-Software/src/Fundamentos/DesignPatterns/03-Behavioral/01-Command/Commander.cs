namespace DesignPatterns._03_Behavioral._01_Command;

internal abstract class Commander
{
    public abstract void Executar();

    public abstract void Desfazer();
}
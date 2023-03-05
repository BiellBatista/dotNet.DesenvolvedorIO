namespace DesignPatterns._03_Behavioral._03_Observable;

// Observer
public interface IObservador
{
    string Nome { get; }

    void Notificar(Investimento investimento);
}
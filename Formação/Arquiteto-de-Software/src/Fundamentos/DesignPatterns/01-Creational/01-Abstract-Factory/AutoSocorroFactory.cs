namespace DesignPatterns._01_Creational._01_Abstract_Factory;

// Abstract Factory
public abstract class AutoSocorroFactory
{
    public abstract Guincho CriarGuincho();
    public abstract Veiculo CriarVeiculo(string modelo, Porte porte);
}
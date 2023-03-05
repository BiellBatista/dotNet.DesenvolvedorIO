namespace DesignPatterns._01_Creational._01_Abstract_Factory;

// Concrete Factory
public class SocorroVeiculoMedioFactory : AutoSocorroFactory
{
    public override Guincho CriarGuincho()
    {
        return GuinchoCreator.Criar(Porte.Medio);
    }

    public override Veiculo CriarVeiculo(string modelo, Porte porte)
    {
        return VeiculoCreator.Criar(modelo, porte);
    }
}
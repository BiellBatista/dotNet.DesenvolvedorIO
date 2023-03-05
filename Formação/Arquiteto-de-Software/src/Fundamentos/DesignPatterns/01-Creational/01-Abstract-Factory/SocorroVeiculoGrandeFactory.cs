namespace DesignPatterns._01_Creational._01_Abstract_Factory;

// Concrete Factory
public class SocorroVeiculoGrandeFactory : AutoSocorroFactory
{
    public override Guincho CriarGuincho()
    {
        return GuinchoCreator.Criar(Porte.Grande);
    }

    public override Veiculo CriarVeiculo(string modelo, Porte porte)
    {
        return VeiculoCreator.Criar(modelo, porte);
    }
}
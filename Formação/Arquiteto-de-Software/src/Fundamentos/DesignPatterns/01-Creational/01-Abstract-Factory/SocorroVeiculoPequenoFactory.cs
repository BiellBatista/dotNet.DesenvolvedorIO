namespace DesignPatterns._01_Creational._01_Abstract_Factory;

// Concrete Factory
public class SocorroVeiculoPequenoFactory : AutoSocorroFactory
{
    public override Guincho CriarGuincho()
    {
        return GuinchoCreator.Criar(Porte.Pequeno);
    }

    public override Veiculo CriarVeiculo(string modelo, Porte porte)
    {
        return VeiculoCreator.Criar(modelo, porte);
    }
}
namespace SOLID._3_LSP._02_Solucao;

internal abstract class Paralelogramo
{
    protected Paralelogramo(int altura, int largura)
    {
        Altura = altura;
        Largura = largura;
    }

    public double Altura { get; private set; }
    public double Largura { get; private set; }
    public double Area
    { get { return Altura * Largura; } }
}
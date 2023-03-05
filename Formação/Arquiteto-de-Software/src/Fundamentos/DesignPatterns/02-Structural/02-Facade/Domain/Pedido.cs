namespace DesignPatterns._02_Structural._02_Facade.Domain;

public class Pedido
{
    public Guid Id { get; set; }
    public decimal Valor { get; set; }
    public List<Produto> Produtos { get; set; }
}
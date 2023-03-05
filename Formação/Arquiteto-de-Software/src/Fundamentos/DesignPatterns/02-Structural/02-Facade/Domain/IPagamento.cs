namespace DesignPatterns._02_Structural._02_Facade.Domain;

public interface IPagamento
{
    Pagamento RealizarPagamento(Pedido pedido, Pagamento pagamento);
}
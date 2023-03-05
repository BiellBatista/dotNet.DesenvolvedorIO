namespace DesignPatterns._02_Structural._02_Facade.Domain;

public interface IPagamentoCartaoCreditoFacade
{
    bool RealizarPagamento(Pedido pedido, Pagamento pagamento);
}
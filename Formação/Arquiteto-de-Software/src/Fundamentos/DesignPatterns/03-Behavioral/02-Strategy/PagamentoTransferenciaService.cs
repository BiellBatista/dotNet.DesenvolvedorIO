using DesignPatterns._02_Structural._02_Facade.Domain;

namespace DesignPatterns._03_Behavioral._02_Strategy;

public class PagamentoTransferenciaService : IPagamento
{
    private readonly IPagamentoTransferenciaFacade _pagamentoTransferenciaFacade;

    public PagamentoTransferenciaService(IPagamentoTransferenciaFacade pagamentoTransferenciaFacade)
    {
        _pagamentoTransferenciaFacade = pagamentoTransferenciaFacade;
    }

    public Pagamento RealizarPagamento(Pedido pedido, Pagamento pagamento)
    {
        pagamento.Valor = pedido.Produtos.Sum(p => p.Valor);
        Console.WriteLine("Iniciando Pagamento via Transferência - Valor R$ " + pagamento.Valor);

        pagamento.ConfirmacaoTransferencia = _pagamentoTransferenciaFacade.RealizarTransferencia();
        pagamento.Status = "Pago via Transferência";
        return pagamento;
    }
}
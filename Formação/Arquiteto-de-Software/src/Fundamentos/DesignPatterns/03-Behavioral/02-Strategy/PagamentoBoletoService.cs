using DesignPatterns._02_Structural._02_Facade.Domain;

namespace DesignPatterns._03_Behavioral._02_Strategy;

public class PagamentoBoletoService : IPagamento
{
    private readonly IPagamentoBoletoFacade _pagamentoBoletoFacade;

    public PagamentoBoletoService(IPagamentoBoletoFacade pagamentoBoletoFacade)
    {
        _pagamentoBoletoFacade = pagamentoBoletoFacade;
    }

    public Pagamento RealizarPagamento(Pedido pedido, Pagamento pagamento)
    {
        pagamento.Valor = pedido.Produtos.Sum(p => p.Valor);
        Console.WriteLine("Iniciando Pagamento via Boleto - Valor R$ " + pagamento.Valor);

        pagamento.LinhaDigitavelBoleto = _pagamentoBoletoFacade.GerarBoleto();
        pagamento.Status = "Aguardando Pagamento";
        return pagamento;
    }
}
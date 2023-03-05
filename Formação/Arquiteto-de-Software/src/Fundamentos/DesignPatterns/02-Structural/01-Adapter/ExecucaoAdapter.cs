namespace DesignPatterns._02_Structural._01_Adapter;

public class ExecucaoAdapter
{
    public static void Executar()
    {
        var pagamentoLogPadrao = new TransacaoService(new Logger());
        pagamentoLogPadrao.RealizarTransacao();

        var pagamentoLogCustom = new TransacaoService(new LogAdapter(new LogNetMasterService()));
        pagamentoLogCustom.RealizarTransacao();
    }
}
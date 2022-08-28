namespace SOLID._2_OCP._02_SolucaoExtensionMethods;

internal static class DebitoContaInvestimento
{
    public static string DebitarContaInvestimento(this DebitoConta debitoConta)
    {
        // Logica de negócio para debito em conta investimento.
        return debitoConta.FormatarTransacao();
    }
}
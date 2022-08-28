namespace SOLID._2_OCP._02_SolucaoExtensionMethods;

internal static class DebitoContaCorrente
{
    public static string DebitarContaCorrente(this DebitoConta debitoConta)
    {
        // Logica de negócio para debito em conta corrente.
        return debitoConta.FormatarTransacao();
    }
}
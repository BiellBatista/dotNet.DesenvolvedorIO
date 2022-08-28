namespace SOLID._2_OCP._02_Solucao;

internal class DebitoContaInvestimento : DebitoConta
{
    public override string Debitar(decimal valor, string conta)
    {
        // Debita Conta Investimento
        // Isentar Taxas
        return FormatarTransacao();
    }
}
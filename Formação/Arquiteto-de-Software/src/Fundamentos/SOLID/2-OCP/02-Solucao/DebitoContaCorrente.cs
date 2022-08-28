namespace SOLID._2_OCP._02_Solucao;

internal class DebitoContaCorrente : DebitoConta
{
    public override string Debitar(decimal valor, string conta)
    {
        // Debita Conta Corrente
        return FormatarTransacao();
    }
}
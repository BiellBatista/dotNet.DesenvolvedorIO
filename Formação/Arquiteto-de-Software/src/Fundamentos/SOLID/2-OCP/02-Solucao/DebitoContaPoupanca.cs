namespace SOLID._2_OCP._02_Solucao;

internal class DebitoContaPoupanca : DebitoConta
{
    public override string Debitar(decimal valor, string conta)
    {
        // Valida Aniversário da Conta
        // Debita Conta Corrente
        return FormatarTransacao();
    }
}
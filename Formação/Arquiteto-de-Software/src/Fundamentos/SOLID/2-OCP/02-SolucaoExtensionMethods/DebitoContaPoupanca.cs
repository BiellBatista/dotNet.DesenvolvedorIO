﻿namespace SOLID._2_OCP._02_SolucaoExtensionMethods;

internal static class DebitoContaPoupanca
{
    public static string DebitarContaPoupanca(this DebitoConta debitoConta)
    {
        // Logica de negócio para debito em conta poupanca.
        return debitoConta.FormatarTransacao();
    }
}
﻿namespace SOLID._2_OCP._01_Violacao;

internal class DebitoConta
{
    public void Debitar(decimal valor, string conta, TipoConta tipoConta)
    {
        if (tipoConta == TipoConta.Corrente)
        {
            // Debita Conta Corrente
        }

        if (tipoConta == TipoConta.Poupanca)
        {
            // Valida Aniversário da Conta
            // Debita Conta Poupança
        }
    }
}
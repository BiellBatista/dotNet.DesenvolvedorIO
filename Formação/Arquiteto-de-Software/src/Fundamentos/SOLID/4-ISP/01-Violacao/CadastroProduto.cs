﻿namespace SOLID._4_ISP._01_Violacao;

internal class CadastroProduto : ICadastro
{
    public void ValidarDados()
    {
        // Validar valor
    }

    public void SalvarBanco()
    {
        // Insert tabela Produto
    }

    public void EnviarEmail()
    {
        // Produto não tem e-mail, o que eu faço agora???
        throw new NotImplementedException("Esse metodo não serve pra nada");
    }
}
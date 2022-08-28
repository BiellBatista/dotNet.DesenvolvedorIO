using SOLID._4_ISP._02_Solucao.Interfaces;

namespace SOLID._4_ISP._02_Solucao;

internal class CadastroCliente : ICadastroCliente
{
    public void ValidarDados()
    {
        // Validar CPF, Email
    }

    public void SalvarBanco()
    {
        // Insert na tabela Cliente
    }

    public void EnviarEmail()
    {
        // Enviar e-mail para o cliente
    }
}
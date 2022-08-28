namespace SOLID._4_ISP._01_Violacao;

internal class CadastroCliente : ICadastro
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
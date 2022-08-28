namespace SOLID._4_ISP._02_Solucao.Interfaces;

internal interface ICadastroCliente
{
    void ValidarDados();

    void SalvarBanco();

    void EnviarEmail();
}
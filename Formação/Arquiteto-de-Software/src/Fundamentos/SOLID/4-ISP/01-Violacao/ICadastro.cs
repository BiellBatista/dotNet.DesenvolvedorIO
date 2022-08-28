namespace SOLID._4_ISP._01_Violacao;

internal interface ICadastro
{
    void ValidarDados();

    void SalvarBanco();

    void EnviarEmail();
}
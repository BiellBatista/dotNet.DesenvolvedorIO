namespace SOLID._1_SRP._02_Solucao;

internal class CPFServices
{
    public static bool IsValid(string cpf)
    {
        return cpf.Length == 11;
    }
}
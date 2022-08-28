namespace SOLID._5_DIP._01_Violacao;

internal static class CPFServices
{
    public static bool IsValid(string cpf)
    {
        return cpf.Length == 11;
    }
}
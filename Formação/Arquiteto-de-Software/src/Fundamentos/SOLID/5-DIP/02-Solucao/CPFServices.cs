using SOLID._5_DIP._02_Solucao.Interfaces;

namespace SOLID._5_DIP._02_Solucao;

internal class CPFServices : ICPFServices
{
    public bool IsValid(string cpf)
    {
        return cpf.Length == 11;
    }
}
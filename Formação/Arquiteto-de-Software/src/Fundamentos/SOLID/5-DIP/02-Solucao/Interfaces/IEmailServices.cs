namespace SOLID._5_DIP._02_Solucao.Interfaces;

internal interface IEmailServices
{
    bool IsValid(string email);

    void Enviar(string de, string para, string assunto, string mensagem);
}
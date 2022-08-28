using SOLID._5_DIP._02_Solucao.Interfaces;
using System.Net.Mail;

namespace SOLID._5_DIP._02_Solucao;

internal class EmailServices : IEmailServices
{
    public bool IsValid(string email)
    {
        return email.Contains("@");
    }

    public void Enviar(string de, string para, string assunto, string mensagem)
    {
        var mail = new MailMessage(de, para);
        var client = new SmtpClient
        {
            Port = 25,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Host = "smtp.google.com"
        };

        mail.Subject = assunto;
        mail.Body = mensagem;
        client.Send(mail);
    }
}
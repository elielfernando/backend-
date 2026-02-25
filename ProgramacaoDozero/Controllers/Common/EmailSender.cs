using System.Net;
using System.Net.Mail;

namespace ProgramacaoDozero.Common
{
    public class EmailSender
    {
        public void Enviar(string assunto, string corpo, string emailDestino)
        {
            var fromEmail = "elielfernando851@gmail.com";
            var fromPassword = "dggmqbucvvkezhno";
            var fromHost = "smtp.gmail.com";
            var fromPort = 587;


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(new MailAddress(emailDestino));
            mail.Subject = assunto;
            mail.Body = corpo;
            mail.IsBodyHtml = true;
            using (SmtpClient smtp = new SmtpClient(fromHost, fromPort))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mail);
            }

        }

    }
}

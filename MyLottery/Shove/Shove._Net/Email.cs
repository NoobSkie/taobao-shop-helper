namespace Shove._Net
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Text;

    public class Email
    {
        public static int SendEmail(string MailFrom, string MailTo, string Subject, string Body, string MailServer, string MailUserName, string MailUserPassword)
        {
            MailMessage message = new MailMessage(MailFrom, MailTo);
            message.Subject = Subject;
            message.Body = Body;
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            message.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient(MailServer);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(MailUserName, MailUserPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(message);
                return 0;
            }
            catch
            {
                return -1;
            }
        }
    }
}


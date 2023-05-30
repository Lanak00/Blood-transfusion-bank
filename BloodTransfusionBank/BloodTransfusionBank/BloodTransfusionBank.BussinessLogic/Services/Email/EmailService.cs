using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;


namespace BloodTransfusionBank.BussinessLogic.Services.Email
{
    public class EmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(SmtpSettings smtpSettings)
        {
            _smtpSettings = smtpSettings;
        }

        public string SendEmail(string email, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Plain) { Text = body};

            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate(_smtpSettings.Username, _smtpSettings.Password);
            string response = smtp.Send(message);
            smtp.Disconnect(true);
            return response;
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = body };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.CheckCertificateRevocation = false;

                await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, SecureSocketOptions.StartTlsWhenAvailable);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
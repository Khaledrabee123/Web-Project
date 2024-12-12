using System.Net.Mail;
using System.Net;

namespace LaptopShop.Models.servive
{
    public interface ISenderEmail
    {
        Task SendEmailAsync(string ToEmail, string Subject, string Body, bool IsBodyHtml = false);
    }

    public class EmailSender : ISenderEmail
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string ToEmail, string Subject, string Body, bool IsBodyHtml = false)
        {
            try
            {
                string MailServer = _configuration["EmailSettings:MailServer"];
                string FromEmail = _configuration["EmailSettings:FromEmail"];
                string Password = _configuration["EmailSettings:Password"];
                int Port = int.Parse(_configuration["EmailSettings:MailPort"]);

                var client = new SmtpClient(MailServer, Port)
                {
                    Credentials = new NetworkCredential(FromEmail, Password),
                    EnableSsl = true,
                };

                MailMessage mailMessage = new MailMessage(FromEmail, ToEmail, Subject, Body)
                {
                    IsBodyHtml = IsBodyHtml
                };

                await client.SendMailAsync(mailMessage);
            }
            catch (SmtpException smtpEx)
            {
                // Handle or log SMTP-specific exceptions here
                throw new Exception("There was an issue sending the email: " + smtpEx.Message, smtpEx);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw new Exception("An error occurred: " + ex.Message, ex);
            }
        }

    }
}
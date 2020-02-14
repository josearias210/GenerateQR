using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Workana.QR.WebSite.Services
{
    public  class EmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public  async Task<bool> SendQR(string toEmailAddress, string subject, string htmlMessage)
        {
            string strEmail = this.configuration["Email"].ToString();
            string strUser = this.configuration["User"].ToString();
            string strPassword = this.configuration["Password"].ToString();
            string strPort = this.configuration["Port"].ToString();
            string strServer = this.configuration["Server"].ToString();

            var SmtpServer = new SmtpClient(strServer);
            var mail = new MailMessage();
            mail.From = new MailAddress(strEmail);
            mail.To.Add(toEmailAddress);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = htmlMessage;
            SmtpServer.Port = int.Parse(strPort);
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new NetworkCredential(strUser, strPassword);
            SmtpServer.EnableSsl = true;

            try
            {
                await Task.Run(() => SmtpServer.Send(mail));
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}

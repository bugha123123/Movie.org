using CinemaClix.Interfaces;
using System.Net.Mail;
using System.Net;

namespace CinemaClix.Services
{
    public class GmailService : IGmailService
    {
        public void SendPasswordResetEmail(string resetToken)
        {
            using (SmtpClient smtpClient = new SmtpClient("smtp.ethereal.email", 587))
            {
                smtpClient.Credentials = new NetworkCredential("wanda73@ethereal.email", "yjc5RcSRXQKPzSKG7j");
                smtpClient.EnableSsl = true;

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("wanda73@ethereal.email", "CinemaClixNoReply"),
                    Subject = "Password Reset",
                    Body = $"Click the following link to reset your password: https://yourwebsite.com/reset-password?token={resetToken}",
                    IsBodyHtml = false
                };

                // Specify the recipient email address
                mailMessage.To.Add("wanda73@ethereal.email");

                smtpClient.Send(mailMessage);
            }
        }




    }
}

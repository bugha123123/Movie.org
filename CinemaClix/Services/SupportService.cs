using CinemaClix.Interfaces;
using CinemaClix.Models;
using System.Net.Mail;
using System.Net;

public class SupportService : ISupportService
{
    private readonly string EtherealEmail = "wanda73@ethereal.email";
    private readonly string Password = "yjc5RcSRXQKPzSKG7j";
    private readonly string UserName = "Wanda Mueller";

    public async Task SendSupportEmailAsync(Support support)
    {
        var smtpClient = new System.Net.Mail.SmtpClient("smtp.ethereal.email")
        {
            Port = 587,
            Credentials = new NetworkCredential(EtherealEmail, Password),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(EtherealEmail, UserName),
            Subject = "Support Request",
            Body = $"Name: {support.FirstName} {support.LastName}\nEmail: {support.EmailAddress}\nPhone: {support.PhoneNumber}\nComment: {support.Comment}",
        };

        mailMessage.To.Add("wanda73@ethereal.email");

        await smtpClient.SendMailAsync(mailMessage);
    }
}

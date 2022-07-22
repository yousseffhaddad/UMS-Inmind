using MailKit.Net.Smtp;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using MimeKit;
using UMS.Infrastructure.Abstraction.EmailServiceAbstraction;
using UMS.Infrastructure.EmailConfiguration;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace UMS.Infrastructure.EmailService;

public class EmailService: IEmailService
{
    private EmailSettings _emailSettings = new EmailSettings("testzyntest@gmail.com", "Support - Pro Code Guide",
        "swjfefptehltxerz", "smtp.gmail.com", 465, true);
    public bool SendEmail(string EmailToId ,string EmailToName,string EmailSubject,string EmailBody)
    {
        try
        {
            MimeMessage emailMessage = new MimeMessage();
            Console.WriteLine(_emailSettings.Name);
            MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
            emailMessage.From.Add(emailFrom);
            MailboxAddress emailTo = new MailboxAddress(EmailToName, EmailToId);
            emailMessage.To.Add(emailTo);
            emailMessage.Subject = EmailSubject;
            BodyBuilder emailBodyBuilder = new BodyBuilder();
            emailBodyBuilder.TextBody = EmailBody;
            emailMessage.Body = emailBodyBuilder.ToMessageBody();
            SmtpClient emailClient = new SmtpClient();
            emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
            emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
            emailClient.Send(emailMessage);
            emailClient.Disconnect(true);
            emailClient.Dispose();
            return true;
        }
        catch(Exception ex)
        {
            //Log Exception Details
            return false;
        }
    }
    
}
namespace UMS.Infrastructure.Abstraction.EmailServiceAbstraction;

public interface IEmailService
{
    bool SendEmail(string EmailToId ,string EmailToName,string EmailSubject,string EmailBody);
}
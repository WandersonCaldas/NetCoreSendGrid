using WebApplication1.Model;

namespace WebApplication1.Service.Interface;

public interface IMailService
{
    Task SendEmailAsync(MailRequest mailRequest);
}

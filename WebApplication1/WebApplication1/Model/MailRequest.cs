namespace WebApplication1.Model;

public class MailRequest
{
    public string? ToName { get; set; }
    public string? ToEmail { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
    public string? Format { get; set; }
    public List<IFormFile>? Attachments { get; set; }
}

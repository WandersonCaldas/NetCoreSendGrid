using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Service.Interface;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public EmailController(IMailService mailService)
        {
            _mailService = mailService;
        }
        
        [HttpPost]
        public async Task<ActionResult<Email>> Post(Email model)
        {
            string strBody = @"<html>
                                <body>
                                    <b>Teste e-mail.</b><br />
                                    <font color=black>
                                        Teste para envio de e-mails.<br />
                                        Data: <b>@@data@@</b><br />
						                Hora: <b>@@hora@@</b><br />	 					                       
                                    </font>
                                </body>
                            </html>";

            strBody = strBody.Replace("@@data@@", DateTime.Now.ToShortDateString());
            strBody = strBody.Replace("@@hora@@", DateTime.Now.ToShortTimeString());

            var emailData = new MailRequest { ToName = model.Remetente, ToEmail = model.Destinatario, Subject = model.Titulo, Body = strBody };
            await _mailService.SendEmailAsync(emailData);

            return Ok();
        }
    }
}

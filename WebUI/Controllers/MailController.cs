using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WebUI.Dtos.MailDto;

namespace WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("Sezen&Co Restaurant", "mailadresiniz");
            message.From.Add(mailboxAddress);

            MailboxAddress to = new MailboxAddress("Sezen&Co Restaurant", createMailDto.ReceiverMail);
            message.To.Add(to);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body;
            bodyBuilder.HtmlBody = $"<p>{createMailDto.Body}</p>";

            message.Subject = createMailDto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("mailadresi", "mailkey");
            message.Body = bodyBuilder.ToMessageBody();
            client.Send(message);
            client.Disconnect(true);
            return RedirectToAction("Index", "Statistic");
        }
    }
}

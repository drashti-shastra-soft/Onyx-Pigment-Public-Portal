using Microsoft.AspNetCore.Mvc;
using OnyxPigment.Models;
using System.Net;
using System.Net.Mail;

namespace OnyxPigment.Controllers
{
    public class ContactFormModel : Controller
    {

        [HttpPost]
        public ActionResult TestMail()
        {
            try
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("test@gmail.com", "test@ooo"),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                var mail = new MailMessage("test@gmail.com", "test@gmail.com")
                {
                    Subject = "Test Email",
                    Body = "This is a test email sent from MVC project."
                };

                smtp.Send(mail);
                return Content("Email sent successfully!");
            }
            catch (Exception ex)
            {
                return Content("Error: " + ex.Message);
            }
        }
    }
}

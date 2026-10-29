using Microsoft.AspNetCore.Mvc;
using OnyxPigment.Models;
using System.Diagnostics;
using System.Dynamic;
using System.Net;
using System.Net.Mail;

namespace OnyxPigment.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contactus()
    {
        return View();
    }

    public IActionResult CopperPhthalocyanineGreenPigment()
    {
        return View();
    }

    public IActionResult CopperPhthalocyanineBluePigment()
    {
        return View();
    }

    public IActionResult CopperPhthalocyanineRedPigment()
    {
        return View();
    }

    public IActionResult CopperPhthalocyanineYellowPigment()
    {
        return View();
    }

    public IActionResult Faqs()
    {
        return View();
    }

    public IActionResult Termsandcondition()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public ActionResult SentMail([FromBody] ContactUs mContactUs)
    {
        dynamic result = new ExpandoObject();

        try
        {
            string templatePath = @"EmailTemplate\ToAdminWhenCustomerContactUs.html"; // use relative path if needed

            var placeholders = new Dictionary<string, string>
            {
                { "Name", mContactUs.Name },
                { "CompanyName", mContactUs.CompanyName },
                { "EmailAddress", mContactUs.EmailAddress },
                { "MobileNumber", mContactUs.MobileNumber },
                { "Message", mContactUs.Message }
            };

            string emailBody = Helper.TemplateEngineHelper.Render(templatePath, placeholders);


            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("vinod@onyxchemtrade.com");
                mailMessage.Subject = "New Inquiry from " + mContactUs.Name + " – ONYX Pigment";
                mailMessage.Body = emailBody;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress("vinod@onyxchemtrade.com"));

                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "vinod@onyxchemtrade.com";
                NetworkCred.Password = "OnyxChem@2024";

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.onyxchemtrade.com";
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }

            result = new { success = true, message = "Your details has been submitted to belonging person. Please wait while we will reach you." };
        }
        catch (Exception ex)
        {
            result = new { success = false, message = "Error: " + ex.Message };
        }

        return Json(result);
    }

}
using Microsoft.AspNetCore.Mvc;
using TechMeetsMagic.Core.Dto;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Models.Emails;

namespace TechMeetsMagic.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailServices _emailServices;
        public EmailsController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailViewModel viewModel, string token)
        {
            var dto = new EmailTokenDto()
            {
                To = viewModel.To,
                Subject = viewModel.Subject,
                Body = viewModel.Body,
                token = token
            };
            _emailServices.SendEmailToken(dto, token);
            return RedirectToAction(nameof(Index));
        }
    }
}

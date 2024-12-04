using Microsoft.AspNetCore.Mvc;
using TechMeetsMagic.Core.Dto;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Models.Emails;

namespace TechMeetsMagic.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailsServices _emailServices;
        public EmailsController(IEmailsServices emailServices)
        {
            _emailServices = emailServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailViewModel viewModel)
        {
            var dto = new EmailDto()
            {
                To = viewModel.To,
                Subject = viewModel.Subject,
                Body = viewModel.Body,
            };
            _emailServices.SendEmail(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}

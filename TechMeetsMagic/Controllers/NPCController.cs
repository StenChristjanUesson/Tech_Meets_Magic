using Microsoft.AspNetCore.Mvc;

namespace TechMeetsMagic.Controllers
{
    public class NPCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

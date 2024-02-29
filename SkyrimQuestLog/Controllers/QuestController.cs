using Microsoft.AspNetCore.Mvc;

namespace SkyrimQuestLog.Controllers
{
    public class QuestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

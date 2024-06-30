using Microsoft.AspNetCore.Mvc;

namespace TradersDiary.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

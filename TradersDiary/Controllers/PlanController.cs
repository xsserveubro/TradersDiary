using Microsoft.AspNetCore.Mvc;
using TradersDiary.EditAreaContent;

namespace TradersDiary.Controllers
{
    public class PlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void UpdateEditableArea()
        {
            this.View().ViewData["contenteditable"] = "Hello Kitty's";
        }

        [HttpPost]
        public JsonResult SaveData(AreaObject areaObject)
        {
            Console.WriteLine("dsfa");
            return Json("God! job.");
        }

        public void TestUpdateEditableArea()
        {
        }
    }
}

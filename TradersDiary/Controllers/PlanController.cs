using Microsoft.AspNetCore.Mvc;

namespace TradersDiary.Controllers
{
    public class PlanController : Controller
    {
        public IActionResult Index()
        {
            UpdateEditableArea();
            return View();
        }

        public void UpdateEditableArea()
        {
            this.View().ViewData["contenteditable"] = "Hello Kitty's";
        }

        public void TestUpdateEditableArea()
        {
            // выгружаются данные из БД
            // добавляются в View.ContentEditable
        }
    }
}

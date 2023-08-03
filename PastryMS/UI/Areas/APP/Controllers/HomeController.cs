using Microsoft.AspNetCore.Mvc;
using Models;
using UI.Filters;

namespace UI.Areas.APP.Controllers
{
    [Area("Admin")]
    [MyFilters]
    public class HomeController : Controller
    {
        private PastryMSDB db = new PastryMSDB();

        public IActionResult Index()
        {
            Redirect("/Admin/Home/Index");
            return View(); 

        }
    }
}

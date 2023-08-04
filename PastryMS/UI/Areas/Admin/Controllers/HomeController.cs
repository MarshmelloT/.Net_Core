using Microsoft.AspNetCore.Mvc;
using Models;
using UI.Filters;

namespace UI.Areas.Admin.Controllers
{
    //里面
    [Area("Admin")]
    public class HomeController : Controller
    {
        private PastryMSDB db = new PastryMSDB();

        public IActionResult Index()
        {
            return View();

        }
    }
}

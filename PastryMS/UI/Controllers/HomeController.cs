using Microsoft.AspNetCore.Mvc;
using Models;
using UI.Filters;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        //外面
        private PastryMSDB db = new PastryMSDB();

        public IActionResult Index()
        {
           return View("/Admin/Home/Index");
        }
    }
}

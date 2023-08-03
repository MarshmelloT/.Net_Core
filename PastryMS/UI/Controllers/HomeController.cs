using Microsoft.AspNetCore.Mvc;
using Models;
using UI.Filters;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private PastryMSDB db = new PastryMSDB();

        public IActionResult Index()
        {
           return  Redirect("/Admin");

        }
    }
}

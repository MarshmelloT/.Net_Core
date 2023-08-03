using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Areas.APP.Controllers
{
    [Area("APP")]

    public class Customer_Refund_InstanceStepController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

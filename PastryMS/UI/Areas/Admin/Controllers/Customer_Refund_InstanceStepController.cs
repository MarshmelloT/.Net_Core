using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Areas.Admin.Controllers
{
    public class Customer_Refund_InstanceStepController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

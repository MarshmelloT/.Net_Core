using common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BLL;
using IBLL;
using Models;
using UI.Filters;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [MyFilters]

    public class CustomerInfoController : Controller
    {
        private PastryMSDB _dbContext;
        private ICustomerInfoBLL _customerInfoBLL;

        public CustomerInfoController(
            PastryMSDB dbContext,
            ICustomerInfoBLL customerInfoBLL
            )
        {

            _dbContext = dbContext;
            _customerInfoBLL= customerInfoBLL;
        }

        public IActionResult ListView()
        {
            return View();
        }

        [HttpGet] public IActionResult getCustomerInfo(int page, int limit, string account, string customerName)
        {
            ReturnResult result = new ReturnResult();
            int count;
            List<GetCustomerInfoDTO> data = _customerInfoBLL.getCustomerInfo(page,limit, account , customerName ,out count);
            result.IsSuccess = true;
            result.Data = data;
            result.Code = 0;
            result.Msg = "获取成功";
            result.Count = count;

            return Json(result);

        }
    }
}

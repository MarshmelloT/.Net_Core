using common;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using System.Collections.Generic;

namespace UI.Areas.Admin.Controllers
{
    public class Customer_Refund_InstanceController : Controller
    {
        private PastryMSDB _dbContext;
        private ICustomer_Refund_InstanceBLL _customer_Refund_InstanceBLL;
        public Customer_Refund_InstanceController(ICustomer_Refund_InstanceBLL customer_Refund_InstanceBLL,PastryMSDB dbContext)
        {
            _dbContext = dbContext;
            _customer_Refund_InstanceBLL= customer_Refund_InstanceBLL;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region 显示信息

        public IActionResult ListCustomer_Refund_instance(int page, int limit, string modelId, int status)
        {

            int count;
            List<GetRefund_InstanceDTO> getRefund_Instances=_customer_Refund_InstanceBLL.GetRefund_Instances(page,limit,modelId,status,out count);
            ReturnResult result = new ReturnResult()
            {
                Code = 0,
                Msg = "成功！",
                Data = getRefund_Instances,
                IsSuccess = true,
                Count = count
            };
            return Json(result);
        }

        #endregion

        #region 添加

        public IActionResult CreateCustomer([FromForm] Customer_Refund_Instance customer_Refund_Instance)
        {
            string msg;
            bool isSuccess = _customer_Refund_InstanceBLL.CreateRefund_Instance(customer_Refund_Instance,out msg);
            ReturnResult result = new ReturnResult();
            result.Msg = msg;
            result.IsSuccess = isSuccess;
            if(isSuccess)
            {
                result.Code = 200;
            }
            return Json(result);
        }

        #endregion
    }
}

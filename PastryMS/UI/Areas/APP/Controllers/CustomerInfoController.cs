using common;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using System.Collections.Generic;
using BLL;
using IBLL;
using Models;

namespace UI.Areas.APP.Controllers
{
    [Area("Admin")]
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
        public IActionResult CreateCustomerInfoView()
        {
            return View();
        }
        public IActionResult UpdateCustomerInfoView()
        {
            return View();
        }
        public IActionResult UserSettingView()
        {
            return View();
        }
        public IActionResult UserPwdUpdateView()
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

        [HttpPost]
        public IActionResult CreateCustomerInfo([FromForm] CustomerInfo customerInfo)
        {
            string msg;

            bool IsSuccess = _customerInfoBLL.CreateCustomerInfo(customerInfo, out msg);

            ReturnResult result = new ReturnResult();
            result.Msg = msg;
            result.IsSuccess = IsSuccess;

            if (IsSuccess)
            {
                result.Code = 200;

            }
            return Json(result);
        }
        #region 用户软删除接口
        [HttpPost]
        public IActionResult DeleteCustomerInfo(string id)
        {
            //实例化返回对象
            ReturnResult result = new ReturnResult();

            //判断非空
            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "ID不能为空";
                return Json(result);
            }

            //调用删除方法
            bool isOK = _customerInfoBLL.DeleteCustomerInfo(id);

            //判断是否删除并返回
            if (isOK)
            {
                result.Msg = "删除用户成功";
                result.Code = 200;
            }

            return Json(result);
        }
        #endregion

        #region 批量用户软删除

        [HttpPost]

        public IActionResult DeleteCustomerInfos(List<string> ids)
        {
            ReturnResult resultresult = new ReturnResult();

            if (ids == null || ids.Count == 0)
            {
                resultresult.Msg = "你还没有选择要删除的用户";
                return Json(resultresult);
            }

            bool isOK = _customerInfoBLL.DeleteCustomerInfos(ids);

            if (isOK)
            {
                resultresult.Msg = "删除成功";
                resultresult.Code = 200;
            }
            return Json(resultresult);
        }
        #endregion

        #region 修改用户的接口

        [HttpPost]
        public IActionResult UpdateCustomerInfo([FromForm] CustomerInfo userInfo)
        {
            ReturnResult result = new ReturnResult();

            string msg;
            bool isOK = _customerInfoBLL.UpdateCustomerInfo(userInfo, out msg);
            result.Msg = msg;
            if (isOK)
            {
                result.Code = 200;
                result.IsSuccess = isOK;
            }

            //返回结果
            return Json(result);
        }

        //[HttpPost]
        //public IActionResult UpdatePwd(string id, string oldpwd, string newpwd, string agapwd)
        //{
        //    ReturnResult result = new ReturnResult();

        //    string msg;
        //    bool isOK = _customerInfoBLL.UpdatePwd(id, oldpwd, newpwd, agapwd, out msg);
        //    result.Msg = msg;
        //    if (isOK)
        //    {
        //        result.Code = 200;
        //        result.IsSuccess = isOK;
        //    }

        //    //返回结果
        //    return Json(result);
        //}
        #endregion
    }
}

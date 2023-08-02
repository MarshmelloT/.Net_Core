using common;
using IBLL;
using IDAL;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Enums;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UI.Filters;

namespace UI.Controllers
{
    [Area("Admin")]
    [MyFilters]

    public class WorkFlow_InstanceStepController : Controller
    {
        private PastryMSDB _dbContext;
        private IWorkFlow_InstanceStepBLL _IWorkFlow_InstanceStepBLL;

        public WorkFlow_InstanceStepController(PastryMSDB dbContext
            , IWorkFlow_InstanceStepBLL IWorkFlow_InstanceStepBLL

            )
        {
            _dbContext = dbContext;
            _IWorkFlow_InstanceStepBLL = IWorkFlow_InstanceStepBLL;
        }
        // GET: WorkFlow_InstanceStep
        public IActionResult ListView()
        {
            return View();
        }

        public IActionResult UpdateWorkFlow_InstanceStepView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetWorkFlow_InstanceSteps(int page, int limit, int status = 0)
        {
            int count;
            ReturnResult result = new ReturnResult();
            var userId = HttpContext.Request.Cookies["UserId"];
            var data = _IWorkFlow_InstanceStepBLL.GetWorkFlow_InstanceSteps(page, limit,userId, status, out count);
            result.IsSuccess = true;
            result.Code = 0;
            result.Data = data;
            result.Count = count;
            result.Msg = "获取成功";

            return Json(result);

        }

        [HttpPost]
        public IActionResult UpdateWorkFlow_InstanceStep(string id, string reviewReason, WorkFlow_InstanceStepStatusEnum reviewStatus,  int outNum)
        {
            string msg;
            ReturnResult result = new ReturnResult();
            var userId = HttpContext.Request.Cookies["UserId"];
            if(userId == null)
            {
                result.Msg = "登录状态过去";
                return Json(result);
            }
            if(string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "工作流步骤不能为空";
                return Json(result);
            }
            //if (string.IsNullOrWhiteSpace(reviewReason))
            //{
            //    result.Msg = "审核意见不能为空";
            //    return Json(result);
            //}
            if (outNum<=0)
            {
                result.Msg = "申请耗材的数量不能小于或等于0";
                return Json(result);
            }
            if(reviewStatus!= WorkFlow_InstanceStepStatusEnum.同意&& reviewStatus != WorkFlow_InstanceStepStatusEnum.驳回)
            {
                result.Msg = "输入的审核状态错误";
                return Json(result);
            }
            bool isok=_IWorkFlow_InstanceStepBLL.UpdateWorkFlow_InstanceStep(id, reviewReason, reviewStatus, userId, outNum, out msg);
            result.IsSuccess = isok;
            result.Msg = msg;
            if(isok )
            {
                result.Code = 200;
            }
            return Json(result);
        }
    }
}
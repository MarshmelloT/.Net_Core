using BLL;
using common;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTO;
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

    public class WorkFlow_InstanceController : Controller
    {
        private PastryMSDB _dbContext;
        private IConsumableInfoBLL _consumableInfoBLL;
        private IWorkFlow_InstanceBLL _WorkFlow_InstanceBLL;

        public WorkFlow_InstanceController(PastryMSDB dbContext
            , IConsumableInfoBLL consumableInfoBLL
            , IWorkFlow_InstanceBLL WorkFlow_InstanceBLL
            )
        {
            _dbContext = dbContext;
            _consumableInfoBLL = consumableInfoBLL;
            _WorkFlow_InstanceBLL = WorkFlow_InstanceBLL;
        }
        // GET: WorkFlow_Instance
        public IActionResult ListView()
        {
            return View();
        }

        public IActionResult CreateWorkFlow_InstanceView()
        {
            return View();
        }

        public IActionResult UpdateWorkFlow_InstanceView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetWorkFlow_InstanceById(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "ID不能为空";
                return Json(result);
            }

            WorkFlow_Model workFlow_Model = _WorkFlow_InstanceBLL.GetWorkFlow_InstanceById(id);
            if (workFlow_Model == null)
            {
                result.Msg = "未能获取到部门信息";
            }
            else
            {
                var selectOption = _WorkFlow_InstanceBLL.GetSelectOptions();

                result.Code = 200;
                result.Msg = "查询成功";

                result.Data = new
                {
                    workFlow_Model,
                    selectOption
                };
            }
            return Json(result);
        }

        [HttpGet]
        public IActionResult GetSelectOptions()
        {
            ReturnResult result = new ReturnResult();
            var data = _WorkFlow_InstanceBLL.GetSelectOptions();
            result.Code = 200;
            result.IsSuccess = true;
            result.Msg = "成功";
            result.Data = data;
            return Json(result);
        }
        [HttpGet]
        public IActionResult getWorkFlow_InstanceDTOs(int page, int limit, int status = 0)
        {
            int count;
            var userId = HttpContext.Request.Cookies["UserId"];
            List<GetWorkFlow_InstanceDTO> data = _WorkFlow_InstanceBLL.getWorkFlow_InstanceDTOs(page, limit, userId, status, out count);
            ReturnResult result = new ReturnResult();
            result.Data = data;
            result.Code = 0;
            result.IsSuccess = true;
            result.Msg = "获取成功";
            result.Count = count;
            return Json(result);


        }
        [HttpPost]
        public IActionResult CreateWorkFlow_Instance([FromForm] WorkFlow_Instance entity)
        {
            ReturnResult result = new ReturnResult();

            var userId = HttpContext.Request.Cookies["UserId"];
            if (userId == null)
            {
                result.Msg = "用户的Id不能为空";
                return Json(result);
            }
            if (string.IsNullOrWhiteSpace(entity.ModelId))
            {
                result.Msg = "工作流模板不能为空";
                return Json(result);
            }
            if (string.IsNullOrWhiteSpace(entity.Reason))
            {
                result.Msg = "请填写申请理由";
                return Json(result);
            }
            if (string.IsNullOrWhiteSpace(entity.OutGoodsId))
            {
                result.Msg = "请选择申请的物品";
                return Json(result);
            }
            if (entity.OutNum <= 0)
            {
                result.Msg = "请你填写正确的数量";
                return Json(result);
            }
            string msg;
            result.IsSuccess = _WorkFlow_InstanceBLL.CreateWorkFlow_Instance(entity, userId, out msg);
            result.Msg = msg;
            if (result.IsSuccess)
            {
                result.Code = 200;
            }
            return Json(result);

        }

        [HttpPost]
        public IActionResult UpdateWorkFlow_Instance(string id)
        {
            string msg;
            ReturnResult result = new ReturnResult();
            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "实例id不能为空";
                return Json(result);
            }
            result.IsSuccess = _WorkFlow_InstanceBLL.UpdateWorkFlow_Instance(id, out msg);
            result.Msg = msg;
            result.Code = result.IsSuccess ? 200 : result.Code;
            return Json(result);
        }
    }
}
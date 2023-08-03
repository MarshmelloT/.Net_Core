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

    public class WorkFlow_ModelController : Controller
    {
        private PastryMSDB _dbContext;
        private IConsumableInfoBLL _consumableInfoBLL;
        private IWorkFlow_ModelBLL _workFlow_ModelBLL;

        public WorkFlow_ModelController(PastryMSDB dbContext
            , IConsumableInfoBLL consumableInfoBLL
            , IWorkFlow_ModelBLL workFlow_ModelBLL
            )
        {
            _dbContext = dbContext;
            _consumableInfoBLL = consumableInfoBLL;
            _workFlow_ModelBLL = workFlow_ModelBLL;
        }


        // GET: workFlow_Model
        public IActionResult ListView()
        {
            return View();
        }

        public IActionResult CreateWorkFlow_ModelView()
        {
            return View();
        }
        public IActionResult UpdateWorkFlow_ModelView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult getWorkFlow_ModelDTOs(int page, int limit, string title)
        {
            int count;
            var data = _workFlow_ModelBLL.getWorkFlow_ModelDTOs(page, limit, title, out count);
            ReturnResult result = new ReturnResult();
            result.Data = data;
            result.Code = 0;
            result.IsSuccess = true;
            result.Count = count;
            result.Msg = "获取成功";

            return Json(result);
        }

        [HttpPost]
        public IActionResult CreateWorkFlow_Model([FromForm] WorkFlow_Model entity)
        {
            string msg;
            bool isok = _workFlow_ModelBLL.CreateWorkFlow_Model(entity, out msg);
            ReturnResult result = new ReturnResult();
            result.Msg = msg;

            if (isok)
            {
                result.IsSuccess = isok;
                result.Code = 200;
            }

            return Json(result);

        }

        [HttpPost]
        public IActionResult DeleteWorkFlow_Model(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }

            bool isok = _consumableInfoBLL.DeleteConsumableInfo(id);

            if (isok)
            {
                result.Code = 200;
                result.Msg = "删除成功";
            }

            return Json(result);
        }

        [HttpPost]
        public IActionResult DeleteWorkFlow_Models(List<string> ids)
        {
            ReturnResult result = new ReturnResult();

            if (ids == null || ids.Count == 0)
            {
                result.Msg = "你还没有选择要删除的id";
                return Json(result);
            }

            bool isok = _consumableInfoBLL.DeleteConsumableInfos(ids);

            if (isok)
            {
                result.Code = 200;
                result.Msg = "删除成功";
            }

            return Json(result);
        }
    }
}
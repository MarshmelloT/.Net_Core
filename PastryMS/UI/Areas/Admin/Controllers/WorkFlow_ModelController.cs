using BLL;
using common;
using IBLL;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CreateWorkFlow_Model([FromBody] WorkFlow_Model entity)
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


    }
}
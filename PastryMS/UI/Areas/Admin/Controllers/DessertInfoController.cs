using BLL;
using common;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.DTO;
using NPOI.POIFS.Crypt.Dsig;
using System.Collections.Generic;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DessertInfoController : Controller
    {
        private PastryMSDB _dbContext;
        private IDessertInfoBLL _dessertInfoBLL;

        public DessertInfoController (PastryMSDB dbContext
            , IDessertInfoBLL dessertInfoBLL
            )
        {
            _dbContext = dbContext;
            _dessertInfoBLL = dessertInfoBLL;
        }

        public IActionResult ListView()
        {
            return View();
        }
        public IActionResult CreateDessertInfoView()
        {
            return View();
        }
        public IActionResult UpdateDessertInfoView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDessertInfo(int page, int limit, string dessertName, string dessertTypeId)
        {
            ReturnResult result =new ReturnResult();
            int count;
            List<GetDessertInfoDTO> data = _dessertInfoBLL.getDessertInfos(page, limit, dessertName, dessertTypeId, out count);
            result.IsSuccess = true;
            result.Data = data;
            result.Code = 0;
            result.Msg = "获取成功";
            result.Count = count;

            return Json(result);
        }

        [HttpPost]
        public IActionResult UpLoadDessertInfo([FromForm] DessertInfo dessertInfo)
        {
            string msg;

            bool IsSuccess = _dessertInfoBLL.UpLoadDessertInfo(dessertInfo, out msg);

            ReturnResult result = new ReturnResult();
            result.Msg = msg;
            result.IsSuccess = IsSuccess;

            if (IsSuccess)
            {
                result.Code = 200;

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult DownDessertInfo(string id)
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
            bool isOK = _dessertInfoBLL.DownDessertInfo(id);

            //判断是否删除并返回
            if (isOK)
            {
                result.Msg = "删除用户成功";
                result.Code = 200;
            }

            return Json(result);
        }

        [HttpPost]
        public IActionResult DownDessertInfos(List<string> ids)
        {
            ReturnResult result = new ReturnResult();

            if (ids == null || ids.Count == 0)
            {
                result.Msg = "你还没有选择要删除的用户";
                return Json(result);
            }

            bool isOK = _dessertInfoBLL.DownDessertInfos(ids);

            if (isOK)
            {
                result.Msg = "删除成功";
                result.Code = 200;
            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult ReUpLoadDessertInfo([FromForm] DessertInfo dessertInfo)
        {
            ReturnResult result = new ReturnResult();

            string msg;
            bool isOK = _dessertInfoBLL.ReUpLoadDessertInfo(dessertInfo, out msg);
            result.Msg = msg;
            if (isOK)
            {
                result.Code = 200;
                result.IsSuccess = isOK;
            }

            //返回结果
            return Json(result);
        }

        [HttpGet]
        public ActionResult GetSelectOptions()
        {
            ReturnResult result = new ReturnResult();

            var data = _dessertInfoBLL.GetSelectOptions();

            result.Code = 200;
            result.Msg = "成功获取";
            result.IsSuccess = true;
            result.Data = data;

            return Json(result);

        }

        [HttpGet]
        public ActionResult GetDessertInfoById(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }

            DessertInfo dessertInfo = _dessertInfoBLL.GetDessertInfoById(id);
            if (dessertInfo == null)
            {
                result.Msg = "未能获取到用户信息";
            }
            else
            {
                var dessertType = _dessertInfoBLL.GetSelectOptions();

                result.Code = 200;
                result.Msg = "查询成功";

                result.Data = new
                {
                    dessertInfo,
                    dessertType
                };
            }
            return Json(result);
        }
    }
}

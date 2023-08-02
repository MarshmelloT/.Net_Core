using BLL;
using common;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using Models;
using UI.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace UI.Controllers
{
    [Area("Admin")]
    [MyFilters]

    public class ConsumableInfoController : Controller
    {
        private PastryMSDB _dbContext;
        private IConsumableInfoBLL _consumableInfoBLL;

        public ConsumableInfoController(
            PastryMSDB dbContext
            , IConsumableInfoBLL consumableInfoBLL
            )
        {
            _dbContext = dbContext;
            _consumableInfoBLL = consumableInfoBLL;
        }
        // GET: ConsumableInfo
        public IActionResult ListView()
        {
            return View();
        }
        public IActionResult CreateConsumableInfoView()
        {
            return View();

        }
        public IActionResult UpdateConsumableInfoView()
        {
            return View();

        }
        [HttpGet]
        public IActionResult GetConsumableInfo(int page, int limit, string ConsumableName)
        {
            int count;

            List<GetConsumableInfosDTO> list = _consumableInfoBLL.GetConsumableInfos(page, limit, ConsumableName, out count);
            ReturnResult result = new ReturnResult();
            result.Msg = "获取成功";
            result.Code = 0;
            result.IsSuccess = true;
            result.Data = list;
            result.Count = count;

            return Json(result);
        }
        [HttpPost]
        public IActionResult CreateConsumableInfo([FromForm] ConsumableInfo consumableInfo)
        {
            string msg;
            bool isok = _consumableInfoBLL.CreateConsumableInfo(consumableInfo, out msg);
            ReturnResult result = new ReturnResult();
            result.Msg = msg;
            result.IsSuccess = isok;
            if (isok)
            {
                result.Code = 200;

            }
            return Json(result);

        }
        [HttpPost]
        public IActionResult DeleteConsumableInfo(string id)
        {
            ReturnResult result = new ReturnResult();
            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "ID不能为空";
                return Json(result);
            }

            bool isok = _consumableInfoBLL.DeleteConsumableInfo(id);
            if (isok)
            {
                result.Code = 200;
                result.Msg = "删除用户成功";

            }
            return Json(result);
        }
        [HttpPost]
        public IActionResult DeleteConsumableInfos(List<string> ids)
        {
            ReturnResult result = new ReturnResult();
            if (ids == null || ids.Count <= 0)
            {
                result.Msg = "你还没有选择要删除的用户";
                return Json(result);
            }

            bool isok = _consumableInfoBLL.DeleteConsumableInfos(ids);
            if (isok)
            {
                result.Code = 200;
                result.Msg = "删除用户成功";

            }
            return Json(result);
        }
        [HttpPost]
        public IActionResult UpdateConsumableInfo([FromBody] ConsumableInfo userInfo)
        {
            ReturnResult result = new ReturnResult();

            string msg;
            bool isok = _consumableInfoBLL.UpdateConsumableInfo(userInfo, out msg);
            result.Msg = msg;
            if (isok)
            {
                result.Code = 200;
                result.IsSuccess = true;
            }
            return Json(result);
        }
        [HttpGet]
        public IActionResult GetSelectOptions()
        {
            ReturnResult result = new ReturnResult();

            var data = _consumableInfoBLL.GetSelectOptions();

            result.Code = 200;
            result.Msg = "成功获取";
            result.IsSuccess = true;
            result.Data = data;

            return Json(result);
        }
        [HttpGet]
        public IActionResult GetConsumableById(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }

            ConsumableInfo consumableInfo = _consumableInfoBLL.GetConsumableInfoById(id);
            if (consumableInfo == null)
            {
                result.Msg = "未能获取到用户信息";
            }
            else
            {
                var selectOption = _consumableInfoBLL.GetSelectOptions();

                result.Code = 200;
                result.Msg = "查询成功";

                result.Data = new
                {
                    consumableInfo,
                    selectOption
                };
            }
            return Json(result);
        }
        public IActionResult UpLoad(IFormFile file)
        {
            //实例化返回对象
            ReturnResult result = new ReturnResult();

            var userId = HttpContext.Request.Cookies["UserId"];
            if (userId == null || string.IsNullOrWhiteSpace(userId))
            {
                result.Msg = "上传用户的id不存在";
                return Json(result);
            }

            //非空判断
            if (file == null)
            {
                result.Msg = "文件为空";
                return Json(result);
            }

            //获取文件名
            string fileName = file.FileName;
            string extension = Path.GetExtension(fileName);//获取后缀

            //判断文件后缀是否为Excel文件
            if (extension == ".xls" || extension == ".xlsx")
            {
                Stream stream = file.OpenReadStream();//获取传递进来的文件流
                string msg;
                bool isok = _consumableInfoBLL.Upload(stream, fileName, userId, out msg);

                result.IsSuccess = isok;
                result.Msg = msg;
                if (isok)
                {
                    result.Code = 200;
                }
                return Json(result);
            }
            else
            {
                result.Msg = "文件类型只能为Excel";
                return Json(result);
            }


        }
        //导出
        public IActionResult GetDownload()
        {
            string downloadFileName;

            Stream stream = _consumableInfoBLL.GetDownload(out downloadFileName);

            return File(stream, "application/octet-stream", downloadFileName);
        }

       
    }
}
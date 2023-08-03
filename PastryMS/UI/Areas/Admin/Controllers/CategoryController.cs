using common;
using IBLL;
using IDAL;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UI.Filters;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [MyFilters]

    public class CategoryController : Controller
    {
        private PastryMSDB _dbContext;
        private ICategoryBLL _categoryBLL;
        public CategoryController(
            PastryMSDB dbContext
            , ICategoryBLL categoryBLL
            )
        {
            _dbContext = dbContext;
            _categoryBLL = categoryBLL;
        }
        // GET: Category
        public IActionResult ListView()
        {
            return View();
        }
        public IActionResult CreateCategoryView()
        {
            return View();
        }
        public IActionResult UpdateCategoryView()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetCategories(int page, int limit, string CategoryName)
        {
            int count;
            List<GetCategoryDTO> list = _categoryBLL.GetCategories(page, limit, CategoryName, out count);
            ReturnResult result = new ReturnResult();
            result.Count = count;
            result.IsSuccess = true;
            result.Msg = "获取成功";
            result.Data = list;
            result.Code = 0;

            return Json(result);

        }
        [HttpPost]
        public IActionResult DeleteCategories(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }
            bool isok = _categoryBLL.DeleteCategories(id);
            if (isok)
            {
                result.Msg = "删除成功";
                result.Code = 200;
            }
            return Json(result);

        }
        [HttpPost]
        public IActionResult DeleteCategoriess(List<string> ids)
        {
            ReturnResult result = new ReturnResult();
            if (ids == null || ids.Count <= 0)
            {
                result.Msg = "还没有选择要删除的耗材类型";
                return Json(result);
            }
            bool isok = _categoryBLL.DeleteCategoriess(ids);
            if (isok)
            {
                result.Msg = "删除成功";
                result.Code = 200;
            }
            return Json(result);
        }
        [HttpPost]
        public IActionResult CreateCategories([FromForm] Category entity)
        {
            string msg;
            bool isok = _categoryBLL.CreateCategories(entity, out msg);
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
        public IActionResult UpdateCategories([FromForm] Category category)
        {
            string msg;
            bool isok = _categoryBLL.UpdateCategories(category, out msg);
            ReturnResult result = new ReturnResult();
            result.Msg = msg;

            if (isok)
            {
                result.Code = 200;
                result.IsSuccess = isok;
            }
            return Json(result);
        }
    }
}
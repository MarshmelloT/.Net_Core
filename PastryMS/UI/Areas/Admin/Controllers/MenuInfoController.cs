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

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [MyFilters]

    public class MenuInfoController : Controller
    {
        private IMenuInfoBLL _menuInfoBLL;

        public MenuInfoController(IMenuInfoBLL menuInfoBLL)
        {
            _menuInfoBLL = menuInfoBLL;
        }
        // GET: MenuInfo
        public IActionResult ListView()
        {
            return View();
        }
        public IActionResult CreateMenuInfoView()
        {
            return View();
        }
        public IActionResult UpdateMenuInfoView()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetMenuInfoById(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "ID不能为空";
                return Json(result);
            }

            MenuInfo menuInfo = _menuInfoBLL.GetMenuInfoById(id);
            if (menuInfo == null)
            {
                result.Msg = "未能获取到部门信息";


            }
            else
            {
                var selectOption = _menuInfoBLL.GetSelectOptions();

                result.Code = 200;
                result.Msg = "查询成功";

                result.Data = new
                {
                    menuInfo,
                    selectOption
                };
            }
            return Json(result);
        }

        [HttpGet]

        public IActionResult GetSelectOptions()
        {
            ReturnResult result = new ReturnResult();

            var data = _menuInfoBLL.GetSelectOptions();

            result.Code = 200;
            result.Msg = "成功获取";
            result.IsSuccess = true;
            result.Data = data;

            return Json(result);

        }

        [HttpGet]
        public IActionResult getMenuInfoDTOs(int page, int limit, string title)
        {
            ReturnResult result = new ReturnResult();
            int count;
            var data = _menuInfoBLL.getMenuInfoDTOs(page, limit, title, out count);

            result.Code = 0;
            result.Msg = "获取成功";
            result.Data = data;
            result.IsSuccess = true;
            result.Count = count;

            return Json(result);
        }

        [HttpPost]
        public IActionResult CreateMenuInfo([FromForm] MenuInfo menuInfo)
        {
            string msg;

            bool isok = _menuInfoBLL.CreateMenuInfo(menuInfo, out msg);
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
        public IActionResult DeleteMenuInfo(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }

            bool isok = _menuInfoBLL.DeleteMenuInfo(id);

            if (isok)
            {
                result.Code = 200;
                result.Msg = "删除成功";
            }

            return Json(result);
        }

        [HttpPost]
        public IActionResult DeleteMenuInfos(List<string> ids)
        {
            ReturnResult result = new ReturnResult();

            if (ids == null || ids.Count == 0)
            {
                result.Msg = "你还没有选择要删除的id";
                return Json(result);
            }

            bool isok = _menuInfoBLL.DeleteMenuInfos(ids);

            if (isok)
            {
                result.Code = 200;
                result.Msg = "删除成功";
            }

            return Json(result);
        }

        [HttpPost]
        public IActionResult UpdateMenuInfo([FromBody] MenuInfo menuInfo)
        {
            ReturnResult result = new ReturnResult();

            string msg;
            bool isok = _menuInfoBLL.UpdateMenuInfo(menuInfo, out msg);

            result.Msg = msg;
            result.IsSuccess = isok;

            if (isok)
            {
                result.Code = 200;
            }

            return Json(result);

        }

        [HttpGet]
        public IActionResult GetMenus()
        {
            GetMenusDTO res = new GetMenusDTO();

            #region 旧的
            //List<HomeMenuInfoDTO> menulist = new List<HomeMenuInfoDTO>()
            //{
            //	new HomeMenuInfoDTO()
            //	{
            //		Title="用户管理",
            //		Href="/UserInfo/ListView",
            //		Icon="fa fa-user",
            //		Target="_self",

            //	},
            //	 new HomeMenuInfoDTO()
            //	 {
            //		Title="系统管理",
            //		Href="",
            //		Icon="fa fa-cog",
            //		Target="_self",
            //		Child= new List<HomeMenuInfoDTO>()
            //		{
            //			new HomeMenuInfoDTO(){
            //				Title="角色管理",
            //				Href="/RoleInfo/ListView",
            //				Icon="fa fa-street-view",
            //				Target="_self"
            //			}
            //		}

            //	}


            //};
            #endregion
            var userid = HttpContext.Request.Cookies["UserId"];
            if (userid == null)
            {
                res = new GetMenusDTO(new List<HomeMenuInfoDTO>());
                return Json(res);
            }
            else
            {
                List<HomeMenuInfoDTO> menulist = _menuInfoBLL.GetMenus(userid);
                res = new GetMenusDTO(menulist);
            }

            return Json(res);
        }



    }
}
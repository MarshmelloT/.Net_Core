using common;
using IBLL;
using IDAL;
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
    

    public class RoleInfoController : Controller
    {
        private IRoleInfoBLL _RoleInfoBLL;
        //private IMenuInfoBLL _menuInfoBLL;
        private ICustomerInfoBLL _customerInfoBLL;

        public RoleInfoController(
            IRoleInfoBLL RoleInfoBLL
            //,IMenuInfoBLL menuInfoBLL
            ,ICustomerInfoBLL customerInfoBLL
            )
        {
            _RoleInfoBLL = RoleInfoBLL;
            //_menuInfoBLL = menuInfoBLL;
            _customerInfoBLL = customerInfoBLL;
        }
        // GET: RoleInfo

        public IActionResult ListView()
        {
            return View();
        }
        public IActionResult CreateRoleInfosView()
        {
            return View();
        }

        public IActionResult UpdateRoleInfosView()
        {
            return View();
        }

        public IActionResult RoleInfoTransferView()
        {
            return View();
        }
        public IActionResult MenuInfoTransferView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetRoleInfos(int page, int limit, string roleName)
        {

            int count;

            List<GetRoleInfoDTO> list = _RoleInfoBLL.GetRoleInfos(page, limit, roleName, out count);

            ReturnResult result = new ReturnResult();
            result.Msg = "获取成功";
            result.IsSuccess = true;
            result.Code = 0;
            result.Data = list;
            result.Count = count;

            return Json(result);
        }

        [HttpPost]
        public IActionResult CreateRoleInfos([FromBody] RoleInfo roleInfo)
        {
            string msg;
            ReturnResult result = new ReturnResult();

            bool isSuccess = _RoleInfoBLL.CreateRoleInfos(roleInfo, out msg);
            result.Msg = msg;
            result.IsSuccess = isSuccess;

            if (isSuccess)
            {
                result.Code = 200;

            }

            return Json(result);


        }

        [HttpPost]
        public IActionResult DeleteRoleInfo(string id)
        {
            ReturnResult result = new ReturnResult();


            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }
            bool isOK = _RoleInfoBLL.DeleteRoleInfo(id);

            if (isOK)
            {
                result.Code = 200;
                result.Msg = "删除成功";
            }
            return Json(result);

        }
        [HttpPost]
        public IActionResult DeleteRoleInfos(List<string> ids)
        {
            ReturnResult result = new ReturnResult();


            if (ids == null || ids.Count == 0)
            {
                result.Msg = "你还没有选择要删除的用户";
                return Json(result);
            }
            bool isOK = _RoleInfoBLL.DeleteRoleInfos(ids);

            if (isOK)
            {
                result.Code = 200;
                result.Msg = "删除成功";
            }
            return Json(result);

        }

        [HttpPost]
        public IActionResult UpdateRoleInfos([FromBody] RoleInfo roleInfo)
        {
            ReturnResult result = new ReturnResult();
            string msg;
            bool IsSuccess = _RoleInfoBLL.UpdateRoleInfos(roleInfo, out msg);
            result.Msg = msg;

            if (IsSuccess)
            {
                result.Code = 200;
                result.IsSuccess = IsSuccess;
            }

            return Json(result);
        }


        [HttpGet]
        public IActionResult GetBindUserIdOptions(string roleId)
        {
            ReturnResult result = new ReturnResult();
            if (string.IsNullOrWhiteSpace(roleId))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }

            List<GetCustomerInfoDTO> options = _customerInfoBLL.getCustomerInfoDTOs();

            List<string> userIds = _RoleInfoBLL.GetBindUserIds(roleId);

            result.Data = new
            {
                options,
                userIds
            };
            result.Code = 200;
            result.Msg = "获取成功";
            result.IsSuccess = true;
            return Json(result);
        }

        [HttpPost]
        public IActionResult BindUserInfo(List<string> userIds, string roleId)
        {
            ReturnResult result = new ReturnResult();

            if(string.IsNullOrWhiteSpace(roleId))
            {
                result.Msg = "角色id不能为空";
                return Json(result);
            }

            result.IsSuccess = _RoleInfoBLL.BindUserInfo(userIds,roleId);
            result.Code=200;
            result.Msg = "绑定成功";

            return Json(result);


        }

        [HttpGet]
        public IActionResult GetBindMenuIdOptions(string roleId)
        {
            ReturnResult result = new ReturnResult();
            //if (string.IsNullOrWhiteSpace(roleId))
            //{
            //    result.Msg = "id不能为空";
            //    return Json(result);
            //}

            //List<GetMenuInfoDTO> options=_menuInfoBLL.GetMenuInfos();

            //List<string> mid=_RoleInfoBLL.GetBindMenuids(roleId);

            //result.Data = new
            //{
            //    options,
            //    mid
            //};

            //result.Code = 200;
            //result.Msg = "获取成功";
            //result.IsSuccess = true;

            return Json(result);
         }

        [HttpPost]
        public IActionResult BindMenuInfo(List<string> mids, string roleId)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(roleId))
            {
                result.Msg = "角色id不能为空";
                return Json(result);
            }

            result.IsSuccess = _RoleInfoBLL.BindMenuInfo(mids, roleId);
            result.Code = 200;
            result.Msg = "绑定成功";

            return Json(result);


        }
    }
}
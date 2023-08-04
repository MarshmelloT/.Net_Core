using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using common;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using UI.Filters;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [MyFilters]
    public class StaffInfoController : Controller
    {
        #region 构造函数
        private PastryMSDB _dbContext;
        private IStaffInfoBLL _staffInfoBLL;
        public StaffInfoController(PastryMSDB dbContext
            ,IStaffInfoBLL staffInfoBLL)
        {
            _dbContext = dbContext;
            _staffInfoBLL = staffInfoBLL;
        }
        #endregion


        #region 视图显示
        public IActionResult Index()
        {
            return View();
        }
        #endregion


        #region 查询
        [HttpGet]
        public IActionResult GetStaffInfos(int page, int limit, string account, string staffName)
        {
            //数据总条数
            int count;
            //调用BLL的获取用户方法
            List<GetStaffInfoDTO> list = _staffInfoBLL.GetStaffInfos(page, limit, account, staffName, out count);

            //返回结果
            ReturnResult result = new ReturnResult()
            {
                Code = 0,//layui要求状态码为0
                Msg = "获取成功!",
                Data = list,
                IsSuccess = true,
                Count = count
            };

            //返回结果
            return Json(result);
        }
        #endregion

        #region 添加 (CreateStaffInfo)
        [HttpPost]
        public IActionResult CreateStaffInfo([FromForm] StaffInfo staff)
        {
            string msg;
            //调用添加方法
            bool isSuccess = _staffInfoBLL.CreateStaffInfo(staff, out msg);
            //返回结果封装
            ReturnResult result = new ReturnResult();
            result.Msg = msg;
            result.IsSuccess = isSuccess;
            //判断是否成功
            if (isSuccess)
            {
                result.Code = 200;
            }
            return Json(result);

        }
        #endregion

        #region 软删除 (DeleteStaffInfo)
        [HttpPost]
        public IActionResult DeleteStaffInfo(string id)
        {
            //实例化返回对象
            ReturnResult result = new ReturnResult();
            //非空判断
            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "Id不能为空!";
                return Json(result);
            }
            //调用删除方法
            bool isOk = _staffInfoBLL.DeleteStaffInfo(id);
            //判断删除情况
            if (isOk)
            {
                result.Msg = "删除用户成功！";
                result.Code = 200;
            }
            //返回结果
            return Json(result);
        }
        #endregion

        #region 批量删除(DeleteStaffInfos)
        [HttpPost]
        public IActionResult DeleteStaffInfos(List<string> ids)
        {
            //实例化返回对象
            ReturnResult result = new ReturnResult();
            //非空判断

            if (ids == null || ids.Count == 0)
            {
                result.Msg = "你还没有选择要删除的用户!";
                return Json(result);
            }
            //调用批量删除的方法
            bool isOk = _staffInfoBLL.DeleteStaffInfos(ids);
            if (isOk)
            {
                result.Msg = "删除成功！";
                result.Code = 200;
            }
            else
            {
                result.Msg = "删除失败!";
            }
            return Json(result);//返回结果
        }
        #endregion

        #region 更新(UpdateStaffInfo)
        [HttpPost]
        public IActionResult UpdateStaffInfo([FromForm] StaffInfo staffInfo)
        {
            //实例化返回对象
            ReturnResult result = new ReturnResult();
            //条用方法
            string msg;
            bool isOk = _staffInfoBLL.UpdateStaffInfo(staffInfo, out msg);
            result.Msg = msg;
            //判断的是否成功
            if (isOk)
            {
                result.Code = 200;
                result.IsSuccess = isOk;
            }
            return Json(result);//返回结果
        }
        #endregion
    }
}

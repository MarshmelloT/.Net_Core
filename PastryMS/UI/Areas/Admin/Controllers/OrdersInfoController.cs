 using BLL;
using common;
using IBLL;
using IDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.DTO;
using System.Collections.Generic;

namespace UI.Areas.Admin.Controllers
{
    /// <summary>
    /// 客户订单信息表
    /// </summary>
    public class OrdersInfoController : Controller
    {
        private IOrdersInfoBLL _ordersInfoBLL;

        public OrdersInfoController(
            IOrdersInfoBLL ordersInfoBLL
            )
        {
            _ordersInfoBLL = ordersInfoBLL;
        }

        #region 显示视图
        public IActionResult ListView()
        {
            return View();
        }
        #endregion

        #region 查询客户订单信息表全部数据(GetOrdersInfos)
        public ActionResult GetOrdersInfos(int page, int limit, string Id, string CustomerId)
        {
            //数据总条数
            int count;

            //调用ConsumableInfoBLL中获取用户的方法
            List<GetOrdersInfosDTO> list = _ordersInfoBLL.GetOrdersInfos(page,limit,Id,CustomerId,out count);

            //返回结果
            ReturnResult result = new ReturnResult()
            {
                Code = 0,
                Msg = "获取成功!",
                Data = list,
                IsSuccess = true,
                Count = count
            };

            //返回结果
            return Json(result);
        }

        #endregion

        #region 添加客户订单信息的方法(CreateOrdersInfo)
        //[HttpPost]
        //public ActionResult CreateOrdersInfo(OrdersInfo entity, out string msg)
        //{
        //    //调用添加角色的方法
        //    bool IsSuccess = _ordersInfoBLL.CreateOrdersInfo(entity, out msg);
        //    //返回结果封装
        //    ReturnResult result = new ReturnResult();
        //    result.Msg = msg;
        //    result.IsSuccess = IsSuccess;

        //    //判断是否成功
        //    if (IsSuccess)
        //    {
        //        result.Code = 200;
        //    }
        //    return Json(result);
        //}

        #endregion

        #region 软删除的方法(DeleteOrdersInfo)
        [HttpPost]
        public ActionResult DeleteOrdersInfo(string id)
        {
            //实例化返回对象
            ReturnResult result = new ReturnResult();
            //非空判断
            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "Id不能为空";
                return Json(result);
            }
            //调用删除的方法
            bool isOk = _ordersInfoBLL.DeleteOrdersInfo(id);
            //判断删除情况
            if (isOk)
            {
                result.Msg = "删除成功";
                result.Code = 200;
            }
            //返回结果
            return Json(result);
        }
        #endregion

        #region 批量删除的方法(DeleteOrdersInfos)
        [HttpPost]
        public ActionResult DeleteOrdersInfos(List<string> ids)
        {
            //实例化返回对象
            ReturnResult result = new ReturnResult();
            //非空判断
            if (ids == null || ids.Count == 0)
            {
                result.Msg = "你还没有选择要删除的客户订单信息";
                return Json(result);
            }
            //调用批量删除方法
            bool isOk = _ordersInfoBLL.DeleteOrdersInfos(ids);
            //判断是否成功
            if (isOk)
            {
                result.Msg = "删除成功";
                result.Code = 200;
            }
            //else
            //{
            //    result.Msg = "删除失败";
            //}
            return Json(result);
        }
        #endregion

        #region 更新的方法
<<<<<<< HEAD
        //[HttpPost]
        //public ActionResult UpdateOrdersInfo(OrdersInfo ordersInfo, out string msg)
        //{
        //    //实例化返回对象
        //    ReturnResult result = new ReturnResult();
        //    //调用方法
        //    bool isOk = _ordersInfoBLL.UpdateOrdersInfo(ordersInfo, out msg);
        //    result.Msg = msg;
        //    //判断是否成功
        //    if (isOk)
        //    {
        //        result.Code = 200;
        //        result.IsSuccess = isOk;
        //    }
        //    return Json(result);//返回结果
        //}
        #endregion

        #region 更新的方法
=======
>>>>>>> 92f83aa7dee419533f57bed8fdff102105df119b
        //[HttpPost]
        //public ActionResult UpdateOrdersInfo(OrdersInfo ordersInfo, out string msg)
        //{
        //    //实例化返回对象
        //    ReturnResult result = new ReturnResult();
        //    //调用方法
        //    bool isOk = _ordersInfoBLL.UpdateOrdersInfo(ordersInfo, out msg);
        //    result.Msg = msg;
        //    //判断是否成功
        //    if (isOk)
        //    {
        //        result.Code = 200;
        //        result.IsSuccess = isOk;
        //    }
        //    return Json(result);//返回结果
        //}
        #endregion

    }
}

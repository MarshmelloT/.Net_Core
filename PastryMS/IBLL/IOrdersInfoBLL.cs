using Model.DTO;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL
{
    /// <summary>
    /// 客户订单信息表接口
    /// </summary>
    public interface IOrdersInfoBLL
    {
        /// <summary>
        /// 查询客户订单信息的方法
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="Id"></param>
        /// <param name="CustomerName"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<GetOrdersInfosDTO> GetOrdersInfos(int page, int limit, string Id, string CustomerId, out int count);

        /// <summary>
        /// 添加客户订单信息的方法
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool CreateOrdersInfo(OrdersInfo entity, out string msg);

        /// <summary>
        /// 软删除客户订单信息的方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteOrdersInfo(string id);

        /// <summary>
        /// 批量软删除客户订单信息的方法
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteOrdersInfos(List<string> ids);

        /// <summary>
        /// 更新客户订单信息表的方法
        /// </summary>
        /// <param name="ordersInfo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool UpdateOrdersInfo(OrdersInfo ordersInfo, out string msg);
    }
}

//using Castle.Core.Resource;
using IBLL;
using IDAL;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /// <summary>
    /// 客户订单信息表BLL
    /// </summary>
    public class OrdersInfoBLL : IOrdersInfoBLL
    {
        private IOrdersInfoDAL _ordersInfoDAL;
        private PastryMSDB _dbContext;

        public OrdersInfoBLL(
            IOrdersInfoDAL ordersInfoDAL
            , PastryMSDB dbContext
            )
        {
            _dbContext = dbContext;
            _ordersInfoDAL = ordersInfoDAL;
        }

        #region 查询客户订单信息表全部数据(GetOrdersInfos)
        /// <summary>
        /// 查询客户订单信息的方法
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="Id"></param>
        /// <param name="CustomerName"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<GetOrdersInfosDTO> GetOrdersInfos(int page, int limit, string Id, string CustomerId, out int count)
        {
            var data = from o in _dbContext.OrdersInfo.Where(x => x.IsDeleted == false)
                       join c in _dbContext.CustomerInfo.Where(c => c.IsDeleted == false)
                       on o.CustomerId equals c.Id
                       into temp
                       from oc in temp.DefaultIfEmpty()
                       select new GetOrdersInfosDTO
                       {
                           Id = Id,//编号
                           OrdersDetailId = o.OrdersDetailId,//订单详情
                           CustomerId = oc.Id,//客户编号
                           Price = o.Price,//消费金额
                           Description = o.Description,//备注
                           CreateTime = DateTime.Now,//创建时间
                       };
            count = data.Count();

            if (!string.IsNullOrWhiteSpace(CustomerId))
            {
                data = data.Where(o => o.CustomerId.Contains(CustomerId));
            }

            //分页
            var list = data.OrderByDescending(r => r.CreateTime).Skip(limit * (page - 1)).Take(limit).ToList();

            return list;
        }
        #endregion

        #region 添加客户订单信息的方法(CreateOrdersInfo)
        /// <summary>
        /// 添加客户订单信息的方法
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        //public bool CreateOrdersInfo(OrdersInfo entity, out string msg)
        //{
        //    //判断非空
        //    if (string.IsNullOrWhiteSpace(entity.CustomerId))
        //    {
        //        msg = "客户编号不能为空";
        //        return false;
        //    }

        //    //赋值id和时间
        //    entity.Id = Guid.NewGuid().ToString();
        //    entity.CreateTime = DateTime.Now;

        //    //更新到数据库
        //    bool isSuccess = _ordersInfoDAL.CreateEntity(entity);

        //    //判断是否成功
        //    if (isSuccess)
        //    {
        //        msg = "添加成功!";
        //        return true;
        //    }
        //    else
        //    {
        //        msg = "添加失败!";
        //    }
        //    return isSuccess;
        //}
        #endregion

        #region 软删除的方法(DeleteOrdersInfo)
        /// <summary>
        /// 软删除客户订单信息的方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteOrdersInfo(string id)
        {
            //根据Id查询用户是否存在
            OrdersInfo ordersInfo = _ordersInfoDAL.GetEntityById(id);

            if (ordersInfo == null)
            {
                return false;
            }
            //修改用户的状态
            ordersInfo.IsDeleted = true;
            ordersInfo.DelTime = DateTime.Now;
            return true;
        }
        #endregion

        #region 批量删除的方法(DeleteOrdersInfos)
        /// <summary>
        /// 批量软删除客户订单信息的方法
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteOrdersInfos(List<string> ids)
        {
            foreach (var item in ids)
            {
                OrdersInfo ordersInfo = _ordersInfoDAL.GetEntityById(item);
                if (ordersInfo == null)
                {
                    continue;//跳出本次循环
                }
                ordersInfo.IsDeleted = true;
                ordersInfo.DelTime = DateTime.Now;
                //执行修改
                _ordersInfoDAL.UpdateEntity(ordersInfo);
            }
            return true;
        }
        #endregion

        #region 更新客户订单信息表的方法(UpdateOrdersInfo)
        /// <summary>
        /// 更新客户订单信息表的方法
        /// </summary>
        /// <param name="ordersInfo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        //public bool UpdateOrdersInfo(OrdersInfo ordersInfo, out string msg)
        //{
        //    //非空判断
        //    //判断这个id是否存在用户
        //    OrdersInfo entity = _ordersInfoDAL.GetEntityById(ordersInfo.Id);
        //    if (entity == null)
        //    {
        //        msg = "客户id无效";
        //        return false;
        //    }

        //    if (entity.CustomerId != ordersInfo.CustomerId)
        //    {
        //        //通过账号查询数据库是否存在相同的账号
        //        OrdersInfo oldUser = _ordersInfoDAL.GetEntities().FirstOrDefault(u => u.CustomerId == ordersInfo.CustomerId);
        //        if (oldUser != null)
        //        {
        //            msg = "客户已存在";
        //            return false;
        //        }
        //    }

        //    if (string.IsNullOrWhiteSpace(ordersInfo.CustomerId))
        //    {
        //        msg = "客户姓名不能为空";
        //        return false;
        //    }

        //    entity.OrdersDetailld = ordersInfo.OrdersDetailld;
        //    entity.CustomerId = ordersInfo.CustomerId;
        //    entity.Price = ordersInfo.Price;
        //    entity.Description = ordersInfo.Description;
        //    entity.CreateTime = DateTime.Now;

        //    bool isOk = _ordersInfoDAL.UpdateEntity(entity);
        //    msg = isOk ? "修改成功" : "修改失败";
        //    //返回结果
        //    return isOk;
        //}
        #endregion
    }
}

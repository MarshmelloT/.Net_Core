using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDAL
{
    /// <summary>
    /// 客户订单信息表接口
    /// </summary>
    public interface IOrdersInfoDAL: IBaseDeleteDAL<OrdersInfo>
    {
        DbSet<OrdersInfo> GetOrdersInfos();
    }
}

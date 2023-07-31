using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class OrdersInfoDAL : BaseDeleteDAL<OrdersInfo>, IOrdersInfoDAL
    {
        private PastryMSDB _dbContext;
        public OrdersInfoDAL(PastryMSDB dbContext):base(dbContext) 
        { 
            _dbContext = dbContext;
        }

        public DbSet<OrdersInfo> GetOrdersInfos()
        {
            return _dbContext.OrdersInfo;
        }
    }
}

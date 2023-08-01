using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Refund_InstanceDAL : BaseDAL<Customer_Refund_Instance>, ICustomer_Refund_InstanceDAL
    {
        private PastryMSDB _dbContext;

        public Refund_InstanceDAL(PastryMSDB dbContext) : base(dbContext)
        {
            _dbContext= dbContext;
        }

        public DbSet<Customer_Refund_Instance> GetRefund_Instance()
        {
            return _dbContext.Customer_Refund_Instance;
        }
    }
}

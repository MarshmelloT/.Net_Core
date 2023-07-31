using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Refund_InstanceDAL : BaseDAL<Refund_Instance>, IRefund_InstanceDAL
    {
        private PastryMSDB _dbContext;

        public Refund_InstanceDAL(PastryMSDB dbContext) : base(dbContext)
        {
            _dbContext= dbContext;
        }

        public DbSet<Refund_Instance> GetRefund_Instance()
        {
            return _dbContext.Refund_Instance;
        }
    }
}

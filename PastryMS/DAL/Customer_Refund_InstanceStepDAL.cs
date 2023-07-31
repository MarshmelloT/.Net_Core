using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Customer_Refund_InstanceStepDAL : BaseDAL<Customer_Refund_InstanceStep>, ICustomer_Refund_InstanceStepDAL
    {
        private PastryMSDB _dbContext;
        public Customer_Refund_InstanceStepDAL(PastryMSDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<Customer_Refund_InstanceStep> customer_Refund_InstanceSteps()
        {
            return _dbContext.Customer_Refund_InstanceStep;
        }
    }
}

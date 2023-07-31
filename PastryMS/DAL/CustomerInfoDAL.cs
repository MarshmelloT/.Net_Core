using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CustomerInfoDAL:BaseDeleteDAL<CustomerInfo>, ICustomerInfoDAL
    {
        private PastryMSDB _dbContext;
        public CustomerInfoDAL(PastryMSDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<CustomerInfo> GetCustomerInfoAll()
        {
            return _dbContext.CustomerInfo;
        }
    }
}

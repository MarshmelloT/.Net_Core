using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WorkFlow_InstanceDAL : BaseDAL<WorkFlow_Instance>, IWorkFlow_InstanceDAL
    {
        private PastryMSDB _dbContext;
        public WorkFlow_InstanceDAL(PastryMSDB dbContext) : base(dbContext)
        {
        }

        public DbSet<WorkFlow_Instance> GetWorkFlow_Instances()
        {
            return _dbContext.WorkFlow_Instance;
        }
    }
}

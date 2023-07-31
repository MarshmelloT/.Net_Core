using IDAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WorkFlow_InstanceStepDAL : BaseDAL<WorkFlow_InstanceStep>, IWorkFlow_InstanceStepDAL
    {
        private PastryMSDB _dbContext;
        public WorkFlow_InstanceStepDAL(PastryMSDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<WorkFlow_InstanceStep> GetWorkFlow_InstanceSteps()
        {
            return _dbContext.WorkFlow_InstanceStep;
        }
    }
}

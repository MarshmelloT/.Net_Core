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
    public class WorkFlow_ModelDAL : BaseDeleteDAL<WorkFlow_Model>, IWorkFlow_ModelDAL
    {
        private PastryMSDB _dbContext;
        public WorkFlow_ModelDAL(PastryMSDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<WorkFlow_Model> GetWorkFlow_Models()
        {
            return _dbContext.WorkFlow_Model;
        }
    }
}

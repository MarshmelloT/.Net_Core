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
    public class ConsumableInfoDAL : BaseDeleteDAL<ConsumableInfo>, IConsumableInfoDAL
    {
        private PastryMSDB _dbContext;
        public ConsumableInfoDAL(PastryMSDB dbContext) : base(dbContext)
        {

        }

        public DbSet<ConsumableInfo> GetConsumableInfos()
        {
            return _dbContext.ConsumableInfo;
        }
    }
}

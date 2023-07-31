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
    public class ConsumableRecordDAL : BaseDAL<ConsumableRecord>, IConsumableRecordDAL
    {
        private PastryMSDB _dbContext;
        public ConsumableRecordDAL(PastryMSDB dbContext) : base(dbContext)
        {
            _dbContext=dbContext;
        }

        public DbSet<ConsumableRecord> GetConsumableRecords()
        {
            return _dbContext.ConsumableRecord;
        }
    }
}

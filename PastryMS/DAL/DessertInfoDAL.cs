using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DessertInfoDAL : BaseDeleteDAL<DessertInfo>, IDessertInfoDAL
    {
        private PastryMSDB _dbContext;
        public DessertInfoDAL(PastryMSDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<DessertInfo> GetDessertInfos()
        {
            return _dbContext.DessertInfo;
        }
    }
}

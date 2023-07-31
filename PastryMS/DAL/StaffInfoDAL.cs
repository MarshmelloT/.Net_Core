using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 员工信息表
    /// </summary>
    public class StaffInfoDAL:BaseDeleteDAL<StaffInfo>, IStaffInfoDAL
    {
        private PastryMSDB _dbContext;
        public StaffInfoDAL(PastryMSDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


          
        public DbSet<StaffInfo> GetStaffInfos()
        {
            return _dbContext.StaffInfo;
        }
    }
}

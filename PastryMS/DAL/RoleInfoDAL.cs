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
    public class RoleInfoDAL : BaseDeleteDAL<RoleInfo>, IRoleInfoDAL
    {
        private PastryMSDB _dbContext;
        public RoleInfoDAL(PastryMSDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<RoleInfo> GetRoleInfos()
        {
            return _dbContext.RoleInfo;
        }
    }
}

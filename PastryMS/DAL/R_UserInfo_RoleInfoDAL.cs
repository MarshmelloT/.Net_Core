using IDAL;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class R_UserInfo_RoleInfoDAL : BaseDAL<R_UserInfo_RoleInfo>, IR_UserInfo_RoleInfoDAL
    {
        private RepositorySysDB _dbContext;
        public R_UserInfo_RoleInfoDAL(RepositorySysDB dbContext) : base(dbContext)
        {
            _dbContext=dbContext;
        }

        public DbSet<R_UserInfo_RoleInfo> Get_UserInfo_RoleInfos()
        {
            return _dbContext.R_UserInfo_RoleInfo;
        }
    }
}

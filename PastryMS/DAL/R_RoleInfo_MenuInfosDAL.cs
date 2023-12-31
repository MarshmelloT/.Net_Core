﻿using IDAL;
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
    public class R_RoleInfo_MenuInfosDAL : BaseDAL<R_RoleInfo_MenuInfo>, IR_RoleInfo_MenuInfoDAL
    {
        private PastryMSDB _dbContext;

        public R_RoleInfo_MenuInfosDAL(PastryMSDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<R_RoleInfo_MenuInfo> GetR_RoleInfo_MenuInfos()
        {
            return _dbContext.R_RoleInfo_MenuInfo;
        }
    }
}

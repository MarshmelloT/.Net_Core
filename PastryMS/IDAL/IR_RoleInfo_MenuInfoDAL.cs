﻿using Microsoft.EntityFrameworkCore;
using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IR_RoleInfo_MenuInfoDAL:IBaseDAL<R_RoleInfo_MenuInfo>
    {
        DbSet<R_RoleInfo_MenuInfo> GetR_RoleInfo_MenuInfos();
    }
}

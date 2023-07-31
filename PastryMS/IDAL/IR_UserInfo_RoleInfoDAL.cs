using Microsoft.EntityFrameworkCore;
using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
     public interface  IR_UserInfo_RoleInfoDAL:IBaseDAL<R_UserInfo_RoleInfo>
    {
        DbSet<R_UserInfo_RoleInfo> Get_UserInfo_RoleInfos();
    }
}

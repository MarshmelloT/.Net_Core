using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IRoleInfoDAL : IBaseDeleteDAL<RoleInfo>
    {
        DbSet<RoleInfo> GetRoleInfos();
    }
}

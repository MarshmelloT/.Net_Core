using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IMenuInfoDAL:IBaseDeleteDAL<MenuInfo>
    {
        DbSet<MenuInfo> MenuInfos();
    }
}

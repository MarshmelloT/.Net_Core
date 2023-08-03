using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDAL
{
    public interface IDessertInfoDAL:IBaseDeleteDAL<DessertInfo>
    {
        DbSet<DessertInfo> GetDessertInfos();
    }
}

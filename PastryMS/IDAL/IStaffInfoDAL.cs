using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDAL
{
    /// <summary>
    /// 员工信息表
    /// </summary>
    public interface IStaffInfoDAL : IBaseDeleteDAL<StaffInfo>
    {

           
        DbSet<StaffInfo> GetStaffInfos();
    }
}

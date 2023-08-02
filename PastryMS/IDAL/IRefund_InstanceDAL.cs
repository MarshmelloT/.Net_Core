
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDAL
{
    public interface IRefund_InstanceDAL:IBaseDAL<Refund_Instance>
    {
        DbSet<Refund_Instance> GetRefund_Instance();
    }
}

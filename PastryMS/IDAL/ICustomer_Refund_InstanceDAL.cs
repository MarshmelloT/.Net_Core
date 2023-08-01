using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDAL
{
    public interface ICustomer_Refund_InstanceDAL:IBaseDAL<Customer_Refund_Instance>
    {
        DbSet<Customer_Refund_Instance> GetRefund_Instance();
    }
}

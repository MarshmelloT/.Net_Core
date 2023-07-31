using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDAL
{
    public interface ICustomerInfoDAL:IBaseDeleteDAL<CustomerInfo>
    {
        DbSet<CustomerInfo> GetCustomerInfoAll();
    }
}

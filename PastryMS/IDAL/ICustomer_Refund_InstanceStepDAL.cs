using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDAL
{
    public interface  ICustomer_Refund_InstanceStepDAL:IBaseDAL<Customer_Refund_InstanceStep>
    {
        DbSet<Customer_Refund_InstanceStep> customer_Refund_InstanceSteps();
    }
}

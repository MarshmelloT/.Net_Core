using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IWorkFlow_InstanceStepDAL:IBaseDAL<WorkFlow_InstanceStep>
    {
        DbSet<WorkFlow_InstanceStep> GetWorkFlow_InstanceSteps();
    }
}

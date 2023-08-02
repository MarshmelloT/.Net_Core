using Models;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public  interface  IWorkFlow_InstanceStepBLL
    {
        List<GetWorkFlow_InstanceStepDTO> GetWorkFlow_InstanceSteps(int page, int limit, string userId, int status, out int count);

        bool UpdateWorkFlow_InstanceStep(string id, string reviewReason, WorkFlow_InstanceStepStatusEnum reviewStatus, string userId, int outNum, out string msg);
    }
}

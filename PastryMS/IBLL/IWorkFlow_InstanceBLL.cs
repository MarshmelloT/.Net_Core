using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using Model.DTO;
using Models;

namespace IBLL
{
    public  interface IWorkFlow_InstanceBLL
    {
        List<GetWorkFlow_InstanceDTO> getWorkFlow_InstanceDTOs(int page, int limit, string title,int status, out int count);
        bool CreateWorkFlow_Instance(WorkFlow_Instance entity,string userId, out string msg);
        bool UpdateWorkFlow_Instance(string id, out string msg);
        List<GetWorkFlow_InstanceDTO> getWorkFlow_InstanceDTOs();
        object GetSelectOptions();
        WorkFlow_Model GetWorkFlow_InstanceById(string id);
      

    }
}

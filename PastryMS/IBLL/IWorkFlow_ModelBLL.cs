using Model;
using Model.DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IWorkFlow_ModelBLL
    {
        List<GetWorkFlow_ModelDTO> getWorkFlow_ModelDTOs(int page, int limit, string title, out int count);

        bool CreateWorkFlow_Model(WorkFlow_Model entity, out string msg);

        bool UpdateWorkFlow_Model(WorkFlow_Model workFlow_Model, out string msg);

        bool DeleteWorkFlow_Model(string id);
        bool DeleteWorkFlow_Models(List<string> ids);

        List<GetWorkFlow_ModelDTO> getWorkFlow_ModelDTOs();

        object GetModelSelect();

    }
}

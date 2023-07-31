using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IWorkFlow_ModelDAL:IBaseDeleteDAL<WorkFlow_Model>
    {
        DbSet<WorkFlow_Model> GetWorkFlow_Models();
    }
}

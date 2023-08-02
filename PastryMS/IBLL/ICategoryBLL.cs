using Model.DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface ICategoryBLL
    {
        List<GetCategoryDTO> GetCategories(int page,int limit,string CategoryName ,out int count);

        bool CreateCategories(Category entity, out string msg);

        bool DeleteCategories(string id);

        bool DeleteCategoriess(List<string> ids);

        bool UpdateCategories(Category category, out string msg);
    }
}

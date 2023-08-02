using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IMenuInfoBLL
    {
        object GetSelectOptions();
        List<GetMenuInfoDTO> getMenuInfoDTOs(int page ,int limit,string Title,out int  count);
        MenuInfo GetMenuInfoById(string id);
        bool CreateMenuInfo(MenuInfo entity,out string msg);
        bool DeleteMenuInfo(string id);
        bool DeleteMenuInfos(List<string> ids);
        bool UpdateMenuInfo(MenuInfo menuInfo, out string msg);
        List<GetMenuInfoDTO> GetMenuInfos();

        List<HomeMenuInfoDTO> GetMenus(string userId);
    }
}

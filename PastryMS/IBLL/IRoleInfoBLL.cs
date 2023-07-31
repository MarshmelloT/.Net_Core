using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IRoleInfoBLL
    {
        List<GetRoleInfoDTO> GetRoleInfos(int page, int limit, string roleName, out int count);

        bool CreateRoleInfos(RoleInfo entity, out string msg);

        bool DeleteRoleInfo(string id);

        bool DeleteRoleInfos(List<string> ids);

        bool UpdateRoleInfos(RoleInfo roleInfo, out string msg);

        List<string> GetBindUserIds(string roleId);

        bool BindUserInfo(List<string> userIds, string roleId);

        List<string> GetBindMenuids(string roleId);
        bool BindMenuInfo(List<string> userIds, string roleId);


    }
}

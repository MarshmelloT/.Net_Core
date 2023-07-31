using IBLL;
using IDAL;
using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoleInfoBLL : IRoleInfoBLL
    {
        private PastryMSDB _dbContext;
        private IRoleInfoDAL _RoleInfoDAL;//业务逻辑层引用的是数据访问层,你引入错乱
        private IR_UserInfo_RoleInfoDAL _R_UserInfo_RoleInfoDAL;
        private IR_RoleInfo_MenuInfoDAL _R_RoleInfo_MenuInfoDAL;

        public RoleInfoBLL(
            PastryMSDB dbContext
            , IRoleInfoDAL RoleInfoDAL
            , IR_UserInfo_RoleInfoDAL r_UserInfo_RoleInfoDAL
            , IR_RoleInfo_MenuInfoDAL r_RoleInfo_MenuInfoDAL
            )
        {
            _dbContext = dbContext;
            _RoleInfoDAL = RoleInfoDAL;
            _R_UserInfo_RoleInfoDAL = r_UserInfo_RoleInfoDAL;
            _R_RoleInfo_MenuInfoDAL = r_RoleInfo_MenuInfoDAL;
        }


        public List<GetRoleInfoDTO> GetRoleInfos(int page, int limit, string roleName, out int count)
        {
            var data = from r in _dbContext.RoleInfo.Where(r => r.IsDeleted == false).DefaultIfEmpty()
                       select new GetRoleInfoDTO
                       {
                           Id = r.Id,
                           RoleName = r.RoleName,
                           CreateTime = DateTime.Now,
                           Description = r.Description,
                       };

            count = data.Count();

            if (!string.IsNullOrWhiteSpace(roleName))
            {
                data = data.Where(r => r.RoleName.Contains(roleName));
            }

            var list = data.OrderByDescending(r => r.CreateTime).Skip(limit * (page - 1)).Take(limit).ToList();

            return list;
        }

        public bool CreateRoleInfos(RoleInfo entity, out string msg)
        {

            if (string.IsNullOrWhiteSpace(entity.RoleName))
            {
                msg = "角色名称不能为空";
                return false;
            }

            RoleInfo roleInfo = _RoleInfoDAL.GetEntities().FirstOrDefault(r => r.RoleName == entity.RoleName);
            if (roleInfo != null)
            {
                msg = "角色已存在";
                return false;
            }

            entity.Id = Guid.NewGuid().ToString();
            entity.CreateTime = DateTime.Now;

            bool Isuccess = _RoleInfoDAL.CreateEntity(entity);

            msg = Isuccess == true ? $"添加{entity.RoleName}成功" : "添加失败";

            return Isuccess;

        }

        public bool DeleteRoleInfo(string id)
        {
            RoleInfo roleInfo = _RoleInfoDAL.GetEntityById(id);
            if (roleInfo == null)
            {
                return false;
            }
            roleInfo.IsDeleted = true;
            roleInfo.DelTime = DateTime.Now;
            _RoleInfoDAL.UpdateEntity(roleInfo);

            return true;
        }
        public bool DeleteRoleInfos(List<string> ids)
        {
            foreach (var item in ids)
            {
                RoleInfo roleInfo = _RoleInfoDAL.GetEntityById(item);
                if (roleInfo == null)
                {
                    continue;
                }
                roleInfo.IsDeleted = true;
                roleInfo.DelTime = DateTime.Now;
                _RoleInfoDAL.UpdateEntity(roleInfo);

            }
            return true;
        }

        public bool UpdateRoleInfos(RoleInfo roleInfo, out string msg)
        {
            if (string.IsNullOrWhiteSpace(roleInfo.Id))
            {
                msg = "角色id不能为空";
                return false;
            }
            if (string.IsNullOrWhiteSpace(roleInfo.RoleName))
            {
                msg = "角色名称不能为空";
                return false;
            }

            RoleInfo entity = _RoleInfoDAL.GetEntityById(roleInfo.Id);
            if (entity == null)
            {
                msg = "id不存在";
                return false;
            }

            if (entity.RoleName != roleInfo.RoleName)
            {
                var oldRoleName = _RoleInfoDAL.GetEntities().FirstOrDefault(r => r.RoleName == roleInfo.RoleName);
                if (oldRoleName != null)
                {
                    msg = "角色名已存在";
                    return false;
                }
            }

            entity.RoleName = roleInfo.RoleName;
            entity.Description = roleInfo.Description;

            bool isOk = _RoleInfoDAL.UpdateEntity(entity);

            msg = isOk == true ? "修改成功" : "修改失败";

            return isOk;

        }

        public List<string> GetBindUserIds(string roleId)
        {
            List<string> userids = _R_UserInfo_RoleInfoDAL.GetEntities()
                                                      .Where(x => x.RoleId == roleId)
                                                      .Select(x => x.UserId)
                                                      .ToList();

            return userids;
        }

        public bool BindUserInfo(List<string> userIds, string roleId)
        {
            List<R_UserInfo_RoleInfo> bindlist = _R_UserInfo_RoleInfoDAL.GetEntities().Where(x => x.RoleId == roleId).ToList();

            foreach (var item in bindlist)
            {
                bool isHas = userIds == null ? false : userIds.Any(x => x == item.UserId);
                if (!isHas)
                {
                    _R_UserInfo_RoleInfoDAL.DeleteEntity(item);
                }
            }

            if (userIds == null)
            {
                return true;
            }

            foreach (var userid in userIds)
            {
                //var user=bindlist.FirstOrDefault(x=>x.UserId== userid);

                bool isHas = bindlist.Any(x => x.UserId == userid);//在序列中查找是否存在该用户id

                if (!isHas)
                {
                    R_UserInfo_RoleInfo entity = new R_UserInfo_RoleInfo();
                    entity.Id = Guid.NewGuid().ToString();
                    entity.RoleId = roleId;
                    entity.UserId = userid;
                    entity.CreateTime = DateTime.Now;
                    _R_UserInfo_RoleInfoDAL.CreateEntity(entity);
                }
            }
            return true;
        }

        public List<string> GetBindMenuids(string roleId)
        {
            List<string> mids = _R_RoleInfo_MenuInfoDAL.GetEntities()
                                                      .Where(x => x.RoleId == roleId)
                                                      .Select(x => x.MenuId)
                                                      .ToList();

            return mids;
        }

        public bool BindMenuInfo(List<string> mdis, string roleId)
        {
            List<R_RoleInfo_MenuInfo> bindlist = _R_RoleInfo_MenuInfoDAL.GetEntities().Where(x => x.RoleId == roleId).ToList();

            foreach (var item in bindlist)
            {
                bool isHas = mdis == null ? false : mdis.Any(x => x == item.MenuId);
                if (!isHas)
                {
                    _R_RoleInfo_MenuInfoDAL.DeleteEntity(item);
                }
            }

            if (mdis == null)
            {
                return true;
            }

            foreach (var mid in mdis)
            {
                //var user=bindlist.FirstOrDefault(x=>x.UserId== userid);

                bool isHas = bindlist.Any(x => x.MenuId == mid);//在序列中查找是否存在该用户id

                if (!isHas)
                {
                    R_RoleInfo_MenuInfo entity = new R_RoleInfo_MenuInfo();
                    entity.Id = Guid.NewGuid().ToString();
                    entity.RoleId = roleId;
                    entity.MenuId = mid;
                    entity.CreateTime = DateTime.Now;
                    _R_RoleInfo_MenuInfoDAL.CreateEntity(entity);
                }
            }
            return true;
        }
    }
}

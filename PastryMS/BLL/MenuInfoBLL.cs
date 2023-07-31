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
    public class MenuInfoBLL : IMenuInfoBLL
    {
        private PastryMSDB _dbContext;
        private IMenuInfoDAL _MenuInfoDAL;
        private IR_UserInfo_RoleInfoDAL _UserInfo_RoleInfoDAL;
        private IR_RoleInfo_MenuInfoDAL _RoleInfo_MenuInfoDAL;
        public MenuInfoBLL(
            PastryMSDB dbContext
            , IMenuInfoDAL MenuInfoDAL
            , IR_UserInfo_RoleInfoDAL UserInfo_RoleInfoDAL
            , IR_RoleInfo_MenuInfoDAL RoleInfo_MenuInfoDAL
            )
        {
            _dbContext = dbContext;
            _MenuInfoDAL = MenuInfoDAL;
            _UserInfo_RoleInfoDAL = UserInfo_RoleInfoDAL;
            _RoleInfo_MenuInfoDAL = RoleInfo_MenuInfoDAL;
        }

        public object GetSelectOptions()
        {
            var parentSelect = _dbContext.MenuInfo.Where(m => !m.IsDeleted)
                                                        .Select(d => new
                                                        {
                                                            value = d.Id,
                                                            title = d.Title
                                                        }).ToList();
            var data = new
            {
                parentSelect,
            };
            return data;
        }
        public MenuInfo GetMenuInfoById(string id)
        {
            return _MenuInfoDAL.GetEntityById(id);
        }
        public List<GetMenuInfoDTO> getMenuInfoDTOs(int page, int limit, string Title, out int count)
        {
            var data = from m in _dbContext.MenuInfo.Where(m => !m.IsDeleted)
                       join m2 in _dbContext.MenuInfo.Where (m => !m.IsDeleted)
                       on m.ParentId equals m2.Id
                       into tempMM
                       from MM in tempMM.DefaultIfEmpty()
                       select new GetMenuInfoDTO
                       {
                           Id = m.Id,
                           Title = m.Title,
                           Description = m.Description,
                           Level = m.Level,
                           Sort = m.Sort,
                           Href = m.Href,
                           ParentId = m.ParentId == null ? "" : MM.Title,
                           Icon = m.Icon,
                           Target = m.Target,
                           CreateTime = m.CreateTime == null ? DateTime.Now : m.CreateTime,
                       };

            count = data.Count();

            if (!string.IsNullOrWhiteSpace(Title))
            {
                data = data.Where(m => m.Title.Contains(Title));
                data = data.Where(m => m.Title == Title);
            }

            var list = data.OrderByDescending(m => m.CreateTime).Skip(limit * (page - 1)).Take(limit).ToList();

            return list;

        }
        public bool CreateMenuInfo(MenuInfo entity, out string msg)
        {
            if (string.IsNullOrWhiteSpace(entity.Title))
            {
                msg = "菜单标题不能为空";
                return false;
            }

            MenuInfo menuInfo = _MenuInfoDAL.GetEntities().FirstOrDefault(m => m.Title == entity.Title);

            if (menuInfo != null)
            {
                msg = "菜单标题已存在";
                return false;
            }
            entity.Id = Guid.NewGuid().ToString();
            entity.CreateTime = DateTime.Now;

            bool isok = _MenuInfoDAL.CreateEntity(entity);

            msg = isok ? $"添加{entity.Title}成功" : "添加失败";
            return isok;
        }
        public bool DeleteMenuInfo(string id)
        {
            MenuInfo menuInfo = _MenuInfoDAL.GetEntityById(id);
            if (menuInfo == null)
            {
                return false;
            }
            menuInfo.DelTime = DateTime.Now;
            menuInfo.IsDeleted = true;

            return _MenuInfoDAL.DeleteEntity(menuInfo);
        }
        public bool DeleteMenuInfos(List<string> ids)
        {
            foreach (string item in ids)
            {
                MenuInfo menuInfo = _MenuInfoDAL.GetEntityById(item);
                if (menuInfo == null)
                {
                    return false;
                }
                menuInfo.DelTime = DateTime.Now;
                menuInfo.IsDeleted = true;

                return _MenuInfoDAL.UpdateEntity(menuInfo);
            }
            return true;
        }
        public bool UpdateMenuInfo(MenuInfo menuInfo, out string msg)
        {
            if (string.IsNullOrEmpty(menuInfo.Title))
            {
                msg = "标题不能为空";
                return false;
            }
            if (string.IsNullOrEmpty(menuInfo.Id))
            {
                msg = "id不能为空";
                return false;
            }

            MenuInfo entity = _MenuInfoDAL.GetEntityById(menuInfo.Id);
            if (entity == null)
            {
                msg = "id无效";
                return false;
            }
            if (entity.Title != menuInfo.Title)
            {
                MenuInfo oldmenuInfo = _MenuInfoDAL.GetEntities().FirstOrDefault(m => m.Title == menuInfo.Title);
                if (oldmenuInfo != null)
                {
                    msg = "标题已存在";
                    return false;
                }
            }

            entity.Title = menuInfo.Title;
            entity.ParentId = menuInfo.ParentId;
            entity.Description = menuInfo.Description;
            entity.Href = menuInfo.Href;
            entity.Sort = menuInfo.Sort;
            entity.Level = menuInfo.Level;
            entity.Target = menuInfo.Target;
            entity.Icon = menuInfo.Icon;

            bool isok = _MenuInfoDAL.UpdateEntity(entity);
            msg = isok ? "更新成功" : "更新失败";
            return isok;
        }
        public List<GetMenuInfoDTO> GetMenuInfos()
        {
            List<GetMenuInfoDTO> Menulist = _MenuInfoDAL.GetEntities()
                                                       .Where(x => x.IsDeleted == false)
                                                       .Select(x => new GetMenuInfoDTO
                                                       {
                                                           Id = x.Id,
                                                           Title = x.Title,
                                                       })
                                                       .ToList();

            return Menulist;


        }
        public List<HomeMenuInfoDTO> GetMenus(string userid)
        {
            //先获取角色的id集合
            List<string> roleIds = _UserInfo_RoleInfoDAL.GetEntities().Where(x => x.UserId == userid).Select(x => x.RoleId).ToList();

            //通过角色查询可访问的菜单id集
            List<string> menuIds = _RoleInfo_MenuInfoDAL.GetEntities().Where(x => roleIds.Contains(x.RoleId)).Select(x => x.MenuId).ToList();

            //获取当前用户能访问的所有菜单集
            List<MenuInfo> allMenus = _MenuInfoDAL.GetEntities().Where(x => menuIds.Contains(x.Id)).OrderBy(x => x.Sort).ToList();

            //找顶级菜单
            List<HomeMenuInfoDTO> topMenus = allMenus.Where(x => x.Level == 1).OrderBy(x => x.Sort).Select(x => new HomeMenuInfoDTO()
            {
                Id = x.Id,
                Title = x.Title,
                Href = x.Href,
                Target = x.Target,
                Icon = x.Icon,
            }).ToList();
            #region 通过遍历查询顶级菜单的子菜单
            //foreach (var item in topMenus)
            //{
            //    List<HomeMenuInfoDTO> childMenus = allMenus.Where(x => x.ParentId == item.Id).Select(x => new HomeMenuInfoDTO()
            //    {
            //        Id = x.Id,
            //        Title = x.Title,
            //        Href = x.Href,
            //        Target = x.Target,
            //        Icon = x.Icon,
            //    }).ToList();

            //    item.Child = childMenus;
            //}
            #endregion

            //调用递归法
            GetChildMenu(topMenus, allMenus);
            return topMenus;
        }
        public void GetChildMenu(List<HomeMenuInfoDTO> parentMenus,List<MenuInfo> allMenus)
        {
            foreach (var item in parentMenus)
            {
                List<HomeMenuInfoDTO> childMenus = allMenus.Where(x => x.ParentId == item.Id).Select(x => new HomeMenuInfoDTO()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Href = x.Href,
                    Target = x.Target,
                    Icon = x.Icon,
                }).ToList();

                GetChildMenu(childMenus, allMenus);
                item.Child = childMenus;
            }
        }

    }
}

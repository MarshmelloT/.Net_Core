using IBLL;
using IDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBLL : ICategoryBLL
    {
        private PastryMSDB _dbContext;
        private ICategoryDAL _categoryDAL;
        public CategoryBLL(
            PastryMSDB dbContext
            , ICategoryDAL categoryDAL
            )
        {
            _dbContext = dbContext;
            _categoryDAL = categoryDAL;
        }

        public bool CreateCategories(Category entity, out string msg)
        {
            if (string.IsNullOrWhiteSpace(entity.CategoryName))
            {
                msg = "类别名称不能为空";
                return false;
            }
           

            Category category = _categoryDAL.GetEntities().FirstOrDefault(c => c.CategoryName == entity.CategoryName);
            if (category != null)
            {
                msg = "类别名称已存在";
                return false;
            }

            entity.Id = Guid.NewGuid().ToString();
            entity.CreateTime = DateTime.Now;

            bool isok = _categoryDAL.CreateEntity(entity);
            msg = isok ? $"添加{entity.CategoryName}成功" : "添加失败";
            return isok;

        }

        public bool DeleteCategories(string id)
        {
            Category category = _categoryDAL.GetEntityById(id);
            if (category == null)
            {
                return false;
            }
            category.IsDeleted = true;
            category.DelTime = DateTime.Now;

            return _categoryDAL.UpdateEntity(category);
        }

        public bool DeleteCategoriess(List<string> ids)
        {
            foreach (var id in ids)
            {
                Category category = _categoryDAL.GetEntityById(id);
                if (category == null)
                {
                    continue;
                }
                category.IsDeleted = true;
                category.DelTime = DateTime.Now;

                return _categoryDAL.UpdateEntity(category);
            }
            return true;
        }

        public List<GetCategoryDTO> GetCategories(int page, int limit, string CategoryName, out int count)
        {
            var data = from c in _dbContext.Category.Where(c => c.IsDeleted == false)
                       select new GetCategoryDTO
                       {
                           Id = c.Id,
                           CategoryName = c.CategoryName,
                           Description = c.Description,
                           CreateTime = c.CreateTime == null ? DateTime.Now : c.CreateTime,
                       };
            count = data.Count();

            if (!string.IsNullOrWhiteSpace(CategoryName))
            {
                data = data.Where(c => c.CategoryName.Contains(CategoryName));
            }
            var list = data.OrderByDescending(c => c.CreateTime).Skip(limit * (page - 1)).Take(limit).ToList();
            return list;
        }

        public bool UpdateCategories(Category category, out string msg)
        {
            if (string.IsNullOrWhiteSpace(category.Id))
            {
                msg = "id不能为空";
                return false;
            }

            Category entity = _categoryDAL.GetEntityById(category.Id);
            if (entity != null)
            {
                msg = "id无效";
                return false;
            }

            if (entity.CategoryName != category.CategoryName)
            {
                Category oldcategory = _categoryDAL.GetEntities().FirstOrDefault(c => c.CategoryName == category.CategoryName);
                if (oldcategory != null)
                {
                    msg = "类别名称已存在";
                    return false;
                }
            }
            entity.Description = category.Description;
            entity.CategoryName = category.CategoryName;

            bool isok=_categoryDAL.UpdateEntity(entity);
            msg = isok ? "更新成功" : "更新失败";
            return isok;

        }
    }
}

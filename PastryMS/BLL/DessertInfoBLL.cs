using common;
using IBLL;
using IDAL;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class DessertInfoBLL : IDessertInfoBLL
    {
        private PastryMSDB _dbContext;
        private IDessertInfoDAL _dessertInfoDAL;
        public DessertInfoBLL(
            PastryMSDB dbContext,
            IDessertInfoDAL dessertInfoDAL
            )
        {
            _dbContext = dbContext;
            _dessertInfoDAL = dessertInfoDAL;
        }
        public bool BuyDessertInfo(DessertInfo entity, out string msg)
        {
            throw new NotImplementedException();
        }

        public bool DownDessertInfo(string id)
        {
            //根据ID查询是否存在
            DessertInfo dessertInfo = _dessertInfoDAL.GetEntityById(id);
            if (dessertInfo == null)
            {
                return false;
            }

            //修改用户的状态
            dessertInfo.IsDeleted = true;
            dessertInfo.DelTime = DateTime.Now;
            //返回结果
            return _dessertInfoDAL.UpdateEntity(dessertInfo);
        }

        public bool DownDessertInfos(List<string> ids)
        {
            foreach (var item in ids)
            {
                //根据用户ID查询是否存在
                DessertInfo dessertInfo = _dessertInfoDAL.GetEntityById(item);
                if (dessertInfo == null)
                {
                    continue;//跳出本次循环
                }
                dessertInfo.IsDeleted = true;
                dessertInfo.DelTime = DateTime.Now;
                _dessertInfoDAL.UpdateEntity(dessertInfo);
            }
            return true;
        }

        public List<GetDessertInfoDTO> getDessertInfos(int page, int limit, string dessertName, string dessertTypeId, out int count)
        {
            var data = from d in _dbContext.DessertInfo
                       join dt in _dbContext.DessertTypeInfo.Where(dt => dt.IsDeleted == false)
                       on d.DessertTypeId equals dt.Id
                       into Tddt
                       from ddt in Tddt
                       select new GetDessertInfoDTO
                       {
                           Id = d.Id,
                           DessertName = d.DessertName,
                           DessertTypeName = ddt.DessertTypeName,
                           Price = d.Price,
                           Num = d.Num,
                           Description = d.Description,
                           Image = d.Image,
                           CreateTime = d.CreateTime == null ? DateTime.Now : d.CreateTime,

                       };

            if (!string.IsNullOrWhiteSpace(dessertName))
            {
                data = data.Where(d => d.DessertName.Contains(dessertName));
            }
            if (!string.IsNullOrWhiteSpace(dessertTypeId))
            {
                data = data.Where(d => d.DessertTypeId == dessertTypeId);
            }
            count = data.Count();
            var listpage = data.OrderByDescending(u => u.CreateTime).Skip(limit * (page - 1)).Take(limit).ToList();

            return listpage;

        }

        public bool ReUpLoadDessertInfo(DessertInfo dessertInfo, out string msg)
        {
            if (string.IsNullOrWhiteSpace(dessertInfo.DessertName))
            {
                msg = "商品名称不能为空";
                return false;
            }
            if (string.IsNullOrWhiteSpace(dessertInfo.DessertTypeId))
            {
                msg = "商品类型不能为空";
                return false;
            }
            if (dessertInfo.Price <= 0)
            {
                msg = "价格不能为空";
                return false;
            }
            if (dessertInfo.Num <= 0)
            {
                msg = "数量不能为空";
                return false;
            }
            DessertInfo entity = _dessertInfoDAL.GetEntityById(dessertInfo.Id);
            if (entity == null)
            {
                msg = "商品ID无效";
                return false;
            }
            if (entity.DessertName != dessertInfo.DessertName)
            {
                DessertInfo oldUser = _dessertInfoDAL.GetEntities().FirstOrDefault(u => u.DessertName == dessertInfo.DessertName);
                if (oldUser != null)
                {
                    msg = "账号已存在";
                    return false;
                }
            }
            entity.DessertName = dessertInfo.DessertName;
            entity.DessertTypeId = dessertInfo.DessertTypeId;
            entity.Price = dessertInfo.Price;
            entity.Num = dessertInfo.Num;
            entity.Image = dessertInfo.Image;
            entity.Description = dessertInfo.Description;
            entity.IsDeleted = false;
            entity.DelTime = null;

            bool isOK = _dessertInfoDAL.UpdateEntity(entity);
            msg = isOK ? "重新上架成功" : "重新上架失败";
            return isOK;
        }

        public bool UpLoadDessertInfo(DessertInfo entity, out string msg)
        {
            //先判断这个用户非空信息
            if (string.IsNullOrWhiteSpace(entity.DessertName))
            {
                msg = "商品名称不能为空";
                return false;
            }
            if (string.IsNullOrWhiteSpace(entity.DessertTypeId))
            {
                msg = "商品类型不能为空";
                return false;
            }
            if (entity.Price<=0)
            {
                msg = "价格不能为空";
                return false;
            }
            if (entity.Num <= 0)
            {
                msg = "数量不能为空";
                return false;
            }

            //判断账号是否重复
            DessertInfo user = _dessertInfoDAL.GetEntities().FirstOrDefault(u => u.DessertName == entity.DessertName);
            if (user != null)
            {
                msg = "用户账号已经存在";
                return false;
            }

            //赋值ID
            entity.Id = Guid.NewGuid().ToString();
            entity.CreateTime = DateTime.Now;

            bool IsSuccess = _dessertInfoDAL.CreateEntity(entity);


            msg = IsSuccess ? $"上架{entity.DessertName}成功!" : "上架失败";
            return IsSuccess;
        }
    }
}

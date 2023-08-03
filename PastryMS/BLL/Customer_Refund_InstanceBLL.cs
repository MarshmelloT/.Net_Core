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
    public class Customer_Refund_InstanceBLL:ICustomer_Refund_InstanceBLL
    {
        private PastryMSDB _dbContext;
        private IRefund_InstanceDAL _Refund_InstanceDAL;

        public Refund_InstanceBLL(PastryMSDB dbContext, IRefund_InstanceDAL refund_InstanceDAL)
        {
            _dbContext = dbContext;
            _Refund_InstanceDAL = refund_InstanceDAL;
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="modelIdint"></param>
        /// <param name="status"></param>
        /// <param name="count"></param>
        /// <returns></returns>
       public List<GetRefund_InstanceDTO> GetRefund_Instances(int page, int limit, string modelId, int status, out int count)
        {
            var data = from c in _dbContext.Refund_Instance.Where(c => c.ModelId == modelId)
                       select new GetRefund_InstanceDTO
                       {
                           Id = c.Id,
                           ModelId = c.ModelId,
                           Description = c.Description,
                           Reason = c.Reason,
                           CreateTime = DateTime.Now,
                           Creator = c.Creator,
                           OutGoodsId = c.OutGoodsId,
                           OutNum = c.OuntNum
                       };
            if(!string.IsNullOrWhiteSpace(modelId) )
            {
                data = data.Where(d => d.ModelId.Contains(modelId));
            }
            count= data.Count();
            var listPage=data.OrderByDescending(u=>u.ModelId).Skip(limit*(page-1)).Take(limit).ToList();
            return listPage;
        }

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool CreateRefund_Instance(Refund_Instance entity, out string msg)
        {
            if(string.IsNullOrWhiteSpace(entity.ModelId))
            {
                msg = "订单流模板不能为空！";
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(entity.Description))
            {
                msg = "描述不能为空！";
                return false;
            }
            if(string.IsNullOrWhiteSpace(entity.Reason))
            {
                msg = "申请理由不能为空！";
                return false;
            }
            if(string.IsNullOrWhiteSpace(entity.OutGoodsId))
            {
                msg = "出库物资id不能为空";
                return false;
            }
            Refund_Instance refund_Instance = _Refund_InstanceDAL.GetEntities().FirstOrDefault(u => u.ModelId == entity.ModelId);
            if (refund_Instance != null)
            {
                msg = "模板id已存在！";
                return false;
            }
            entity.Id=Guid.NewGuid().ToString();
            entity.CreateTime= DateTime.Now;
            bool isSuccess =_Refund_InstanceDAL.CreateEntity(entity);
            msg = isSuccess ? "添加成功！" : "添加失败";
            return isSuccess;
        }
        #endregion

        #region 更新

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="category"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateRefund_Instance(Refund_Instance refund_Instance, out string msg)
        {
            //非空判断
            if (string.IsNullOrWhiteSpace(refund_Instance.ModelId))
            {
                msg = "订单流模板不能为空！";
                return false;
            }

            if (string.IsNullOrWhiteSpace(refund_Instance.Description))
            {
                msg = "描述不能为空！";
                return false;
            }
            if (string.IsNullOrWhiteSpace(refund_Instance.Reason))
            {
                msg = "申请理由不能为空！";
                return false;
            }
            if (string.IsNullOrWhiteSpace(refund_Instance.OutGoodsId))
            {
                msg = "出库物资id不能为空";
                return false;
            }
            Refund_Instance info = _Refund_InstanceDAL.GetEntities().FirstOrDefault(t=>t.Id==refund_Instance.Id);
            if (info == null)
            {
                msg = "订单流模板不存在！";
                return false;
            }
            if (info.ModelId != refund_Instance.ModelId)
            {
                var entity = _Refund_InstanceDAL.GetEntities().FirstOrDefault(d => d.ModelId == refund_Instance.ModelId);
                if (entity != null)
                {
                    msg = "订单流模板重复！";
                    return false;
                }
            }
            info.ModelId= refund_Instance.ModelId;
            info.Description=refund_Instance.Description;
            bool isSuccess=_Refund_InstanceDAL.UpdateEntity(refund_Instance);
            msg = isSuccess ? "更新成功" : "更新失败";
            return isSuccess;
        }
        #endregion

        //#region 部门软删除方法
        //public bool DeleteRefund_Instance(string id)
        //{
        //    //根据Id查用户是否存在
        //    Refund_Instance entity = _Refund_InstanceDAL.GetEntities().Where(x => x.Id == id).ToList();
        //    if (entity == null)
        //    {
        //        return false;
        //    }
        //    //修改用户状态
        //    entity.IsDeleted = true;
        //    entity.DeleteTime = DateTime.Now;
        //    return _categoryInfoDAL.UpdateEntity(entity);
        //}
        //#endregion

        //#region 部门批量软删除方法

        //public bool DeleteRefund_Instance(List<string> ids)
        //{
        //    var refund_Instances = _Refund_InstanceDAL.GetEntities().Where(u => ids.Contains(u.Id)).ToList();
        //    foreach (var id in ids)
        //    {
        //        //根据用户Id查询用户
        //        MenuInfo menus = refund_Instances.FirstOrDefault(u => u.Id == ids);
        //        if (menus == null)
        //        {
        //            continue;//跳出本次循环
        //        }
        //        menus.IsDeleted = true;
        //        menus.DeleteTime = DateTime.Now;
        //        //执行修改
        //        _Refund_InstanceDAL.UpdateEntity(menus);
        //    }
        //    return true;
        //}

        ////#endregion
    }
}

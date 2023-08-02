using IBLL;
using IDAL;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BLL
{
    public class WorkFlow_InstanceBLL : IWorkFlow_InstanceBLL
    {
        private PastryMSDB _dbContext;
        private IWorkFlow_InstanceDAL _workFlow_InstanceDAL;
        private IWorkFlow_ModelDAL _workFlow_ModelDAL;
        public WorkFlow_InstanceBLL(PastryMSDB dbContext
            , IWorkFlow_InstanceDAL workFlow_InstanceDAL
            , IWorkFlow_ModelDAL workFlow_ModelDAL

            )
        {
            _dbContext = dbContext;
            _workFlow_InstanceDAL = workFlow_InstanceDAL;
            _workFlow_ModelDAL = workFlow_ModelDAL;
        }
        public bool CreateWorkFlow_Instance(WorkFlow_Instance entity, string userId, out string msg)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    WorkFlow_Instance workFlow_Instance = new WorkFlow_Instance();
                    workFlow_Instance.Id = Guid.NewGuid().ToString();
                    workFlow_Instance.CreateTime = DateTime.Now;
                    workFlow_Instance.Creator = userId;
                    workFlow_Instance.Description = entity.Description;
                    workFlow_Instance.ModelId = entity.ModelId;
                    workFlow_Instance.OutGoodsId = entity.OutGoodsId;
                    workFlow_Instance.OutNum = entity.OutNum;
                    workFlow_Instance.Reason = entity.Reason;
                    workFlow_Instance.Status = (int)WorkFlow_InstanceStatusEnum.审核中;

                    _dbContext.WorkFlow_Instance.Add(workFlow_Instance);
                    bool b = _dbContext.SaveChanges() > 0;
                    if (b == false)
                    {
                        transaction.Rollback();
                        msg = "工作流实例创建失败!(发起申领失败)";
                        return false;
                    }

                    //UserInfo userInfo = _dbContext.StaffInfo.FirstOrDefault(u => u.Id == userId);
                    //if (userInfo == null || string.IsNullOrWhiteSpace(userInfo.DepartmentId))
                    //{
                    //    transaction.Rollback();
                    //    msg = "当前用户没有部门";
                    //    return false;
                    //}

                    //DepartmentInfo departmentInfo = _dbContext.DepartmentInfo.FirstOrDefault(u => u.Id == userInfo.DepartmentId);
                    //if (departmentInfo == null || string.IsNullOrWhiteSpace(departmentInfo.LeaderId))
                    //{
                    //    transaction.Rollback();
                    //    msg = "当前部门未设置领导";
                    //    return false;
                    //}

                    //int count = (from ur in _dbContext.R_UserInfo_RoleInfo.Where(x => x.UserId == departmentInfo.LeaderId)
                    //             join r in _dbContext.RoleInfo.Where(x => x.RoleName == "部门经理")
                    //             on ur.RoleId equals r.Id
                    //             select r.RoleName).Count();

                    //if (count <= 0)
                    //{
                    //    transaction.Rollback();
                    //    msg = "当前领导不是部门经理这个角色";
                    //    return false;
                    //}

                    WorkFlow_InstanceStep workFlow_InstanceStep = new WorkFlow_InstanceStep();
                    workFlow_InstanceStep.Id = Guid.NewGuid().ToString();
                    workFlow_InstanceStep.CreateTime = DateTime.Now;
                    workFlow_InstanceStep.InstanceId = workFlow_Instance.Id;
                    //workFlow_InstanceStep.ReviewerId = departmentInfo.LeaderId;
                    workFlow_InstanceStep.ReviewTime = DateTime.Now;
                    workFlow_InstanceStep.ReviewStatus = (int)WorkFlow_InstanceStepStatusEnum.审核中;

                    _dbContext.WorkFlow_InstanceStep.Add(workFlow_InstanceStep);
                    bool b2 = _dbContext.SaveChanges() > 0;
                    if (b2 == false)
                    {
                        transaction.Rollback();
                        msg = "步骤发起失败!(发给领导时发生错误)";
                        return false;
                    }

                    msg = "耗材申领发起成功";
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    msg = ex.Message;
                    return false;
                }

            }
        }
        public object GetSelectOptions()
        {
            var outGoodsSelect = _dbContext.ConsumableInfo.Where(c => c.IsDeleted == false)
                                                .Select(c => new
                                                {
                                                    value = c.Id,
                                                    title = c.ConsumableName,

                                                }).ToList();

            var modelSelect = _dbContext.WorkFlow_Model.Where(c => c.IsDeleted == false)
                                                    .Select(c => new
                                                    {
                                                        value = c.Id,
                                                        title = c.Title,
                                                    }).ToList();

            var data = new
            {
                outGoodsSelect,
                modelSelect

            };
            return data;

        }
        public WorkFlow_Model GetWorkFlow_InstanceById(string id)
        {
            return _workFlow_ModelDAL.GetEntityById(id);
        }
        public List<GetWorkFlow_InstanceDTO> getWorkFlow_InstanceDTOs(int page, int limit, string userId, int status, out int count)
        {
            var data = from w in _dbContext.WorkFlow_Instance.Where(wi => wi.Creator == userId)
                       join m in _dbContext.WorkFlow_Model
                       on w.ModelId equals m.Id
                       into tempwm
                       from wm in tempwm
                       join u in _dbContext.StaffInfo.Where(u => u.IsDeleted == false)
                       on w.Creator equals u.Id
                       into tempwu
                       from wu in tempwu
                       join c in _dbContext.ConsumableInfo.Where(c => c.IsDeleted == false)
                       on w.OutGoodsId equals c.Id
                       into tempwc
                       from wc in tempwc
                       select new GetWorkFlow_InstanceDTO
                       {
                           Id = w.Id,
                           ModelId = w.ModelId,
                           Title = wm.Title,
                           Reason = w.Reason,
                           Creator = w.Creator,
                           ConsumableName = wc.ConsumableName,
                           UserName = wu.StaffName,
                           OutNum = w.OutNum,
                           Status = w.Status,
                           OutGoodsId = w.OutGoodsId,
                           CreateTime = w.CreateTime == null ? DateTime.Now : w.CreateTime,
                       };

            count = data.Count();

            if (status > 0)
            {
                data = data.Where(w => w.Status == status);
            }

            var list = data.OrderByDescending(w => w.CreateTime).Skip(limit * (page - 1)).Take(limit).ToList();

            return list;
        }
        public List<GetWorkFlow_InstanceDTO> getWorkFlow_InstanceDTOs()
        {
            List<GetWorkFlow_InstanceDTO> wlist = _workFlow_InstanceDAL.GetEntities()
                                                      .Select(x => new GetWorkFlow_InstanceDTO
                                                      {
                                                          Id = x.Id,
                                                          ModelId = x.ModelId,
                                                      })
                                                      .ToList();

            return wlist;
        }
        public bool UpdateWorkFlow_Instance(string id, out string msg)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    WorkFlow_Instance oldentity = _dbContext.WorkFlow_Instance.FirstOrDefault(x => x.Id == id);
                    if (oldentity == null)
                    {
                        transaction.Rollback();
                        msg = "找不到该实例";
                        return false;
                    }
                    if (oldentity.Status != (int)WorkFlow_InstanceStatusEnum.审核中)
                    {
                        transaction.Rollback();
                        msg = "工作流是不处于审批状态不可作废";
                        return false;

                    }
                    oldentity.Status = (int)WorkFlow_InstanceStatusEnum.作废;
                    _dbContext.Entry(oldentity).State = EntityState.Modified;
                    bool isok = _dbContext.SaveChanges() > 0;
                    if (isok == false)
                    {
                        transaction.Rollback();
                        msg = "作废状态更新失败";
                        return false;
                    }
                    List<WorkFlow_InstanceStep> lis = _dbContext.WorkFlow_InstanceStep.Where(x => x.InstanceId == oldentity.Id).ToList();
                    foreach (var item in lis)
                    {
                        item.ReviewStatus = (int)WorkFlow_InstanceStatusEnum.作废;
                        _dbContext.Entry(item).State = EntityState.Modified;
                        isok = _dbContext.SaveChanges() > 0;
                        if (isok == false)
                        {
                            break;
                        }

                    }
                    if (isok == false)
                    {
                        transaction.Rollback();
                        msg = "工作流步骤状态更新失败";
                        return false;
                    }

                    transaction.Commit();
                    msg = "实例作废成功";
                    return true;

                }
                catch (Exception ex)
                {


                    transaction.Rollback();
                    msg = "作废状态更新失败" + ex.Message;
                    return false;

                }
            }
        }
    }
}

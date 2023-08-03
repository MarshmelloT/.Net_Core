using IBLL;
using IDAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTO;
using Model.Enums;
using Models;
using NPOI.POIFS.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WorkFlow_InstanceStepBLL : IWorkFlow_InstanceStepBLL
    {
        private PastryMSDB _dbContext;
        private IWorkFlow_InstanceStepDAL _IWorkFlow_InstanceStepDAL;

        public WorkFlow_InstanceStepBLL(PastryMSDB dbContext
            , IWorkFlow_InstanceStepDAL iWorkFlow_InstanceStepDAL

            )
        {
            _dbContext = dbContext;
            _IWorkFlow_InstanceStepDAL = iWorkFlow_InstanceStepDAL;
        }

        public List<GetWorkFlow_InstanceStepDTO> GetWorkFlow_InstanceSteps(int page, int limit, string userId, int status, out int count)
        {
            var data = from ws in _dbContext.WorkFlow_InstanceStep.Where(x => x.ReviewerId == userId)
                       join wi in _dbContext.WorkFlow_Instance
                       on ws.InstanceId equals wi.Id
                       into Twswi
                       from wswi in Twswi
                       join c in _dbContext.ConsumableInfo
                       on wswi.OutGoodsId equals c.Id
                       into Twwu
                       from wc in Twwu
                       join wm in _dbContext.WorkFlow_Model
                       on wswi.ModelId equals wm.Id
                       into Twm
                       from wwm in Twm
                       join u in _dbContext.StaffInfo
                       on wswi.Creator equals u.Id
                       into Twmu
                       from wwu in Twmu
                       join u2 in _dbContext.StaffInfo
                       on ws.ReviewerId equals u2.Id
                       into Twmu2
                       from wwu2 in Twmu2
                       select new GetWorkFlow_InstanceStepDTO
                       {
                           Id = ws.Id,
                           Title = wwm.Title,
                           InstanceId = wswi.Id,
                           UserName = wwu.StaffName,
                           ReviewerId = ws.ReviewerId,
                           ReviewStatus = ws.ReviewStatus,
                           ReviewReason = ws.ReviewReason,
                           ReviewTime = ws.ReviewTime,
                           BeforeStepId = ws.BeforeStepId,
                           CreatorId = wswi.Creator,
                           CreateTime = ws.CreateTime,
                           Reason = wswi.Reason,
                           ConsumableName = wc.ConsumableName,
                           OutNum = wswi.OutNum,

                       };
            count = data.Count();

            if (status > 0)
            {
                data = data.Where(w => w.ReviewStatus == status);
            }

            var list = data.OrderByDescending(w => w.CreateTime).Skip(limit * (page - 1)).Take(limit).ToList();

            return list;
        }
        public bool UpdateWorkFlow_InstanceStep(string id, string reviewReason, WorkFlow_InstanceStepStatusEnum reviewStatus, string userId, int outNum, out string msg)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    WorkFlow_InstanceStep workFlow_InstanceStep = _dbContext.WorkFlow_InstanceStep.FirstOrDefault(d => d.Id == id);
                    if (workFlow_InstanceStep == null)
                    {
                        msg = "未找到工作流步骤";
                        transaction.Rollback();
                        return false;
                    }
                    if (workFlow_InstanceStep.ReviewerId != userId)
                    {
                        msg = "你没有权限审核";
                        transaction.Rollback();
                        return false;
                    }
                    workFlow_InstanceStep.ReviewReason = reviewReason;
                    workFlow_InstanceStep.ReviewStatus = (int)reviewStatus;
                    workFlow_InstanceStep.ReviewTime = DateTime.Now;
                    _dbContext.Entry(workFlow_InstanceStep).State = EntityState.Modified;
                    bool isok = _dbContext.SaveChanges() > 0;
                    if (isok == false)
                    {
                        msg = "审核失败";
                        transaction.Rollback();
                        return false;
                    }
                    List<string> roleName = (from ur in _dbContext.R_UserInfo_RoleInfo.Where(x => x.UserId == userId)
                                             join r in _dbContext.RoleInfo
                                             on ur.RoleId equals r.Id
                                             select r.RoleName).ToList();

                    if (roleName.Contains("部门经理"))
                    {
                        if (reviewStatus == WorkFlow_InstanceStepStatusEnum.同意)
                        {
                            List<string> ckUserIds = (from r in _dbContext.RoleInfo.Where(x => x.RoleName == "仓库管理员")
                                                      join ur in _dbContext.R_UserInfo_RoleInfo
                                                      on r.Id equals ur.RoleId
                                                      select ur.UserId).ToList();

                            string ckUserId = ckUserIds.FirstOrDefault();
                            if (ckUserId == null)
                            {
                                msg = "找不到仓库管理员";
                                transaction.Rollback();
                                return false;
                            }
                            WorkFlow_InstanceStep newWork = new WorkFlow_InstanceStep()
                            {
                                Id = Guid.NewGuid().ToString(),
                                BeforeStepId = id,
                                InstanceId = workFlow_InstanceStep.InstanceId,//工作实例
                                CreateTime = DateTime.Now,
                                ReviewerId = ckUserId,//审核人
                                ReviewStatus = (int)WorkFlow_InstanceStepStatusEnum.审核中,
                            };
                            _dbContext.WorkFlow_InstanceStep.Add(newWork);
                            isok = _dbContext.SaveChanges() > 0;
                            if (isok == false)
                            {
                                msg = "未找到工作流步骤流";
                                transaction.Rollback();
                                return false;
                            }
                        }
                        else if (reviewStatus == WorkFlow_InstanceStepStatusEnum.驳回)
                        {
                            WorkFlow_Instance workFlow_Instance = _dbContext.WorkFlow_Instance.FirstOrDefault(x => x.Id == workFlow_InstanceStep.InstanceId);
                            if (workFlow_Instance == null)
                            {
                                msg = "未找到工作流实例";
                                transaction.Rollback();
                                return false;
                            }

                            WorkFlow_InstanceStep newWork = new WorkFlow_InstanceStep()
                            {
                                Id = Guid.NewGuid().ToString(),
                                BeforeStepId = workFlow_InstanceStep.Id,
                                InstanceId = workFlow_InstanceStep.InstanceId,//工作实例
                                CreateTime = DateTime.Now,
                                ReviewerId = workFlow_Instance.Creator,//审核人
                                ReviewReason = "驳回理由:" + reviewReason,
                                ReviewStatus = (int)WorkFlow_InstanceStepStatusEnum.审核中,
                            };
                            _dbContext.WorkFlow_InstanceStep.Add(newWork);
                            isok = _dbContext.SaveChanges() > 0;
                            if (isok == false)
                            {
                                msg = "审核时创建工作步骤流失败";
                                transaction.Rollback();
                                return false;
                            }
                        }
                        else
                        {
                            msg = "审核失败";
                            transaction.Rollback();
                            return false;
                        }

                    }
                    else if (roleName.Contains("仓库管理员"))
                    {
                        if (reviewStatus == WorkFlow_InstanceStepStatusEnum.同意)
                        {
                            WorkFlow_Instance workFlow_Instance = _dbContext.WorkFlow_Instance.FirstOrDefault(x => x.Id == workFlow_InstanceStep.InstanceId);
                            if (workFlow_Instance == null)
                            {
                                msg = "未找到工作流实例";
                                transaction.Rollback();
                                return false;
                            }
                            workFlow_Instance.Status = (int)WorkFlow_InstanceStatusEnum.结束;
                            _dbContext.Update(workFlow_Instance);
                            isok = _dbContext.SaveChanges() > 0;
                            if (isok == false)
                            {
                                msg = "结束工作流实例失败";
                                transaction.Rollback();
                                return false;
                            }

                            ConsumableInfo consumableInfo = _dbContext.ConsumableInfo.FirstOrDefault(x => x.Id == workFlow_Instance.OutGoodsId);
                            if (consumableInfo == null)
                            {
                                msg = "未找到耗材物品";
                                transaction.Rollback();
                                return false;
                            }
                            if (consumableInfo.Num == workFlow_Instance.OutNum)
                            {
                                msg = "耗材库存不足";
                                transaction.Rollback();
                                return false;
                            }
                            consumableInfo.Num -= workFlow_Instance.OutNum;
                            _dbContext.Update(consumableInfo);
                            isok = _dbContext.SaveChanges() > 0;
                            if (isok == false)
                            {
                                msg = "减少耗材库存失败";
                                transaction.Rollback();
                                return false;
                            }
                            ConsumableRecord consumableRecord = new ConsumableRecord();
                            consumableRecord.Id = Guid.NewGuid().ToString();
                            consumableRecord.ConsumableId = consumableInfo.Id;
                            consumableRecord.CreateTime = DateTime.Now;
                            consumableRecord.Creator = userId;
                            consumableRecord.Num = workFlow_Instance.OutNum;
                            consumableRecord.Type = (int)ConsumableInfoTypeEnums.出库;

                            _dbContext.ConsumableRecord.Add(consumableRecord);
                            isok = _dbContext.SaveChanges() > 0;
                            if (isok == false)
                            {
                                msg = "出库失败";
                                transaction.Rollback();
                                return false;
                            }
                        }
                        else if (reviewStatus == WorkFlow_InstanceStepStatusEnum.驳回)
                        {
                            WorkFlow_InstanceStep oldWork = _dbContext.WorkFlow_InstanceStep.FirstOrDefault(x => x.Id == workFlow_InstanceStep.BeforeStepId);
                            if (oldWork == null)
                            {
                                msg = "无法找到上一个步骤";
                                transaction.Rollback();
                                return false;
                            }
                            WorkFlow_InstanceStep newWork = new WorkFlow_InstanceStep()
                            {
                                Id = Guid.NewGuid().ToString(),
                                BeforeStepId = id,
                                InstanceId = workFlow_InstanceStep.InstanceId,//工作实例
                                CreateTime = DateTime.Now,
                                ReviewerId = oldWork.ReviewerId,//审核人
                                ReviewStatus = (int)WorkFlow_InstanceStepStatusEnum.审核中,
                            };
                            _dbContext.WorkFlow_InstanceStep.Add(newWork);
                            isok = _dbContext.SaveChanges() > 0;
                            if (isok == false)
                            {
                                msg = "驳回失败";
                                transaction.Rollback();
                                return false;
                            }
                        }
                        else
                        {
                            msg = "审核失败";
                            transaction.Rollback();
                            return false;
                        }
                    }
                    else if (roleName.Contains("普通职员"))
                    {
                        WorkFlow_Instance workFlow_Instance = _dbContext.WorkFlow_Instance.FirstOrDefault(x => x.Id == workFlow_InstanceStep.InstanceId);
                        if (workFlow_Instance == null)
                        {
                            msg = "未找到工作流实例";
                            transaction.Rollback();
                            return false;
                        }
                        workFlow_Instance.OutNum = outNum;
                        _dbContext.Update(workFlow_Instance);
                        isok = _dbContext.SaveChanges() > 0;
                        if (isok == false)
                        {
                            msg = "修改工作流实例申请耗材数量失败";
                            transaction.Rollback();
                            return false;
                        }
                        WorkFlow_InstanceStep oldWork = _dbContext.WorkFlow_InstanceStep.FirstOrDefault(x => x.Id == workFlow_InstanceStep.BeforeStepId);
                        if (oldWork == null)
                        {
                            msg = "无法找到上一个步骤";
                            transaction.Rollback();
                            return false;
                        }
                        WorkFlow_InstanceStep newWork = new WorkFlow_InstanceStep()
                        {
                            Id = Guid.NewGuid().ToString(),
                            BeforeStepId = id,
                            InstanceId = workFlow_InstanceStep.InstanceId,//工作实例
                            CreateTime = DateTime.Now,
                            ReviewerId = oldWork.ReviewerId,//审核人
                            ReviewStatus = (int)WorkFlow_InstanceStepStatusEnum.审核中,
                        };
                        _dbContext.WorkFlow_InstanceStep.Add(newWork);
                        isok = _dbContext.SaveChanges() > 0;
                        if (isok == false)
                        {
                            msg = "审核失败(修改工作步骤流)";
                            transaction.Rollback();
                            return false;
                        }
                    }
                    else
                    {
                        msg = "审核失败";
                        transaction.Rollback();
                        return false;
                    }
                    WorkFlow_Instance upWorkFlow_Instance = _dbContext.WorkFlow_Instance.FirstOrDefault(x => x.Id == workFlow_InstanceStep.InstanceId);
                    if (reviewStatus == WorkFlow_InstanceStepStatusEnum.同意)
                    {
                        upWorkFlow_Instance.Status = (int)reviewStatus;
                        _dbContext.Update(upWorkFlow_Instance);
                        isok = _dbContext.SaveChanges() > 0;
                        if (isok == false)
                        {
                            msg = "更新错误";
                            transaction.Rollback();
                            return false;
                        }
                    }
                    transaction.Commit();
                    msg = "审核成功";
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    msg = "错误" + ex.Message;
                    return false;
                }

            }
        }


    }
}


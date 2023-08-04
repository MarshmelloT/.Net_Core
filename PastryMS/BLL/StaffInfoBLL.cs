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
    public class StaffInfoBLL : IStaffInfoBLL
    {
        #region 构造函数
        private PastryMSDB _dbContext;
        private IStaffInfoDAL _staffInfoDAL;

        public StaffInfoBLL(PastryMSDB dbContext
            , IStaffInfoDAL staffInfoDAL)
        {
            _dbContext = dbContext;
            _staffInfoDAL = staffInfoDAL;
        }
        #endregion

        #region 登录()
        public bool Login(string account, string password, out string msg, out string staffName, out string staffId)
        {
            //把密码加密为MD5
            string newPwd = MD5Help.GenerateMD5(password);
            //根据账号密码查询用户
            StaffInfo staffInfo = _staffInfoDAL.GetStaffInfos().FirstOrDefault(u => u.Account == account && u.Pwd == newPwd);

            staffName = "";
            staffId = "";
            //判断是否存在该用户
            if (staffInfo == null)
            {
                msg = "账号或密码错误！";
                return false;
            }
            else
            {
                msg = "成功!";
                staffName = staffInfo.StaffName;
                staffId = staffInfo.Id;
                return true;
            }
        }
        #endregion

        #region  查询（GetStaffInfos）
        public List<GetStaffInfoDTO> GetStaffInfos(int page, int limit, string account, string staffName, out int count)
        {
            var data = from m in _dbContext.StaffInfo.Where(m => !m.IsDeleted)
                       join m2 in _dbContext.StaffInfo.Where(m => !m.IsDeleted)
                       on m.LeaderId equals m2.Id
                       into tempMM
                       from MM in tempMM.DefaultIfEmpty()
                       select new GetStaffInfoDTO
                       {
                           Id = m.Id,
                           Account = m.Account,
                           Description = m.Description,
                           StaffName = m.StaffName,
                           LeaderId = m.LeaderId,
                           CreateTime = m.CreateTime == null ? DateTime.Now : m.CreateTime,
                       };

            count = data.Count();

            //优化姓名不能为空
            if (!string.IsNullOrWhiteSpace(staffName))
            {
                data = data.Where(u => u.StaffName.Contains(staffName));
            }

            if (!string.IsNullOrWhiteSpace(account))
            {
                data = data.Where(u => u.Account == account);
            }
            count = data.Count();

            var listpage = data.OrderByDescending(u => u.CreateTime).Skip(limit * (page - 1)).Take(limit).ToList();

            return listpage;
        }
        #endregion


        #region 添加(CreateStaffInfo)
        public bool CreateStaffInfo(StaffInfo entity, out string msg)
        {
            //先判断这个员工非空信息
            if (string.IsNullOrWhiteSpace(entity.Account))
            {
                msg = "账号不能为空";
                return false;
            }
            if (string.IsNullOrWhiteSpace(entity.Pwd))
            {
                msg = "密码不能为空";
                return false;
            }
            if (string.IsNullOrWhiteSpace(entity.StaffName))
            {
                msg = "姓名不能为空";
                return false;
            }
            if (string.IsNullOrWhiteSpace(entity.LeaderId))
            {
                msg = "主管id不能为空";
                return false;
            }

            //判断账号是否重复
            StaffInfo user = _staffInfoDAL.GetEntities().FirstOrDefault(u => u.Account == entity.Account);
            if (user != null)
            {
                msg = "用户账号已经存在";
                return false;
            }
            //赋值
            entity.Id = Guid.NewGuid().ToString();
            entity.CreateTime = DateTime.Now;
            entity.Pwd = MD5Help.GenerateMD5(entity.Pwd);

            bool IsSuccess = _staffInfoDAL.CreateEntity(entity);


            msg = IsSuccess ? $"添加{entity.StaffName}成功!" : "添加失败";
            return IsSuccess;
        }
        #endregion


        #region 用户软删除方法（DeleteStaffInfo）
        public bool DeleteStaffInfo(string id)
        {
            //根据ID查询是否存在
            StaffInfo user = _staffInfoDAL.GetEntityById(id);
            if (user == null)
            {
                return false;
            }

            //修改员工的状态
            user.IsDeleted = true;
            user.DelTime = DateTime.Now;
            //返回结果
            return _staffInfoDAL.UpdateEntity(user);
        }
        #endregion

        #region 批量用户软删除方法（DeleteStaffInfos）
        public bool DeleteStaffInfos(List<string> ids)
        {
            foreach (var item in ids)
            {
                //根据员工ID查询是否存在
                StaffInfo user = _staffInfoDAL.GetEntityById(item);
                if (user == null)
                {
                    continue;//跳出本次循环
                }
                user.IsDeleted = true;
                user.DelTime = DateTime.Now;
                _staffInfoDAL.UpdateEntity(user);
            }
            return true;
        }
        #endregion

        #region 更新（UpdateStaffInfo）
        public bool UpdateStaffInfo(StaffInfo staffInfo, out string msg)
        {
            if (string.IsNullOrWhiteSpace(staffInfo.Id))
            {
                msg = "ID不能为空";
                return false;
            }
            if (string.IsNullOrWhiteSpace(staffInfo.Account))
            {
                msg = "账号不能为空";
                return false;
            }
            if (string.IsNullOrWhiteSpace(staffInfo.StaffName))
            {
                msg = "姓名不能为空";
                return false;
            }
           
            StaffInfo entity = _staffInfoDAL.GetEntityById(staffInfo.Id);
            if (entity == null)
            {
                msg = "员工ID无效";
                return false;
            }
            if (entity.Account != staffInfo.Account)
            {
                StaffInfo oldUser = _staffInfoDAL.GetEntities().FirstOrDefault(u => u.Account == staffInfo.Account);
                if (oldUser != null)
                {
                    msg = "账号已存在";
                    return false;
                }
            }
            entity.Account = staffInfo.Account;
            entity.StaffName = staffInfo.StaffName;
            entity.LeaderId = staffInfo.LeaderId;
            entity.Description=staffInfo.Description;
            //用户的密码,如果传进来的是null或""字符串就使用原来的密码.否则就拿新密码MD5加密使用新密码
            entity.Pwd = string.IsNullOrWhiteSpace(staffInfo.Pwd) ? entity.Pwd : MD5Help.GenerateMD5(staffInfo.Pwd);

            bool isOK = _staffInfoDAL.UpdateEntity(entity);
            msg = isOK ? "修改用户成功" : "修改用户失败";
            return isOK;
        }
		#endregion

		public List<GetStaffInfoDTO> GetStaffInfoDTO()
		{
			List<GetStaffInfoDTO> userlist = _staffInfoDAL.GetEntities()
													  .Where(x => x.IsDeleted == false)
													  .Select(x => new GetStaffInfoDTO
													  {
														  Id = x.Id,
														  StaffName = x.StaffName,
													  })
													  .ToList();

			return userlist;
		}
	}
}

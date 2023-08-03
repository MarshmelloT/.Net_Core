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
    public class CustomerInfoBLL : ICustomerInfoBLL
    {
        private PastryMSDB _dbContext;
        private ICustomerInfoDAL _ICustomerInfoDAL;
        public CustomerInfoBLL(PastryMSDB dbContext, ICustomerInfoDAL iCustomerInfoDAL)
        {
            _dbContext = dbContext;
            _ICustomerInfoDAL = iCustomerInfoDAL;
        }

        public List<GetCustomerInfoDTO> getCustomerInfo(int page, int limit, string account, string customerName, out int count)
        {
            var data = from c in _dbContext.CustomerInfo.Where(c => c.IsDeleted == false)
                       select new GetCustomerInfoDTO
                       {
                           Id = c.Id,
                           Account = c.Account,
                           CustomerName = c.CustomerName,
                           Pwd = c.Pwd,
                           Sex = c.Sex,
                           Age = c.Age,
                           Description = c.Description,
                           CreateTime = c.CreateTime == null ? DateTime.Now : c.CreateTime,
                       };

            if (!string.IsNullOrWhiteSpace(customerName))
            {
                data = data.Where(c => c.CustomerName.Contains(customerName));
            }
            if (!string.IsNullOrWhiteSpace(account))
            {
                data = data.Where(c => c.Account == account);
            }

            count = data.Count();

            var list = data.OrderByDescending(c => c.CreateTime).Skip(limit * (page - 1)).Take(limit).ToList();

            return list;
        }

        public bool Login(string account, string pwd, out string msg, out string customerName, out string customerid)
        {
            string newpwd = MD5Help.GenerateMD5(pwd);

            CustomerInfo customerInfo = _ICustomerInfoDAL.GetCustomerInfo().FirstOrDefault(c => c.Account == account && c.Pwd == newpwd);
            customerName = "";
            customerid = "";

            if (customerInfo == null)
            {
                msg = "用户名或密码错误";
                return false;
            }
            else
            {
                msg = "成功";
                customerName = customerInfo.CustomerName;
                customerid = customerInfo.Id;
                return true;
            }
        }

        public bool CreateCustomerInfo(CustomerInfo entity, out string msg)
        {
            //先判断这个用户非空信息
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
            if (string.IsNullOrWhiteSpace(entity.CustomerName))
            {
                msg = "姓名不能为空";
                return false;
            }

            //判断账号是否重复
            CustomerInfo user = _ICustomerInfoDAL.GetEntities().FirstOrDefault(u => u.Account == entity.Account);
            if (user != null)
            {
                msg = "用户账号已经存在";
                return false;
            }

            //赋值ID
            entity.Id = Guid.NewGuid().ToString();
            entity.CreateTime = DateTime.Now;
            entity.Pwd = MD5Help.GenerateMD5(entity.Pwd);

            bool IsSuccess = _ICustomerInfoDAL.CreateEntity(entity);


            msg = IsSuccess ? $"添加{entity.CustomerName}成功!" : "添加失败";
            return IsSuccess;
        }

        #region 用户软删除方法

        public bool DeleteCustomerInfo(string id)
        {
            //根据ID查询是否存在
            CustomerInfo user = _ICustomerInfoDAL.GetEntityById(id);
            if (user == null)
            {
                return false;
            }

            //修改用户的状态
            user.IsDeleted = true;
            user.DelTime = DateTime.Now;
            //返回结果
            return _ICustomerInfoDAL.UpdateEntity(user);
        }
        #endregion
        #region 批量用户软删除

        public bool DeleteCustomerInfos(List<string> ids)
        {
            //var userlist=_UserInfoDAL.GetUserInfos().Where(u=>ids.Contains(u.Id)).ToList();
            foreach (var item in ids)
            {
                //根据用户ID查询是否存在
                CustomerInfo user = _ICustomerInfoDAL.GetEntityById(item);
                if (user == null)
                {
                    continue;//跳出本次循环
                }
                user.IsDeleted = true;
                user.DelTime = DateTime.Now;
                _ICustomerInfoDAL.UpdateEntity(user);
            }
            return true;
        }


        #endregion

        public bool UpdateCustomerInfo(CustomerInfo customerInfo, out string msg)
        {
            if (string.IsNullOrWhiteSpace(customerInfo.Id))
            {
                msg = "ID不能为空";
                return false;
            }
            if (string.IsNullOrWhiteSpace(customerInfo.Account))
            {
                msg = "账号不能为空";
                return false;
            }
            if (string.IsNullOrWhiteSpace(customerInfo.CustomerName))
            {
                msg = "姓名不能为空";
                return false;
            }

            CustomerInfo entity = _ICustomerInfoDAL.GetEntityById(customerInfo.Id);
            if (entity == null)
            {
                msg = "用户ID无效";
                return false;
            }
            if (entity.Account != customerInfo.Account)
            {
                CustomerInfo oldUser = _ICustomerInfoDAL.GetEntities().FirstOrDefault(u => u.Account == customerInfo.Account);
                if (oldUser != null)
                {
                    msg = "账号已存在";
                    return false;
                }
            }
            entity.Account = customerInfo.Account;
            entity.CustomerName = customerInfo.CustomerName;
            //用户的密码,如果传进来的是null或""字符串就使用原来的密码.否则就拿新密码MD5加密使用新密码
            entity.Description = customerInfo.Description;
            entity.Pwd = string.IsNullOrWhiteSpace(customerInfo.Pwd) ? entity.Pwd : MD5Help.GenerateMD5(customerInfo.Pwd);
            entity.Sex = customerInfo.Sex;

            bool isOK = _ICustomerInfoDAL.UpdateEntity(entity);
            msg = isOK ? "修改用户成功" : "修改用户失败";
            return isOK;
        }

        public List<GetCustomerInfoDTO> GetCustomerInfoDTO()
        {
            List<GetCustomerInfoDTO> userlist = _ICustomerInfoDAL.GetEntities()
                                                      .Where(x => x.IsDeleted == false)
                                                      .Select(x => new GetCustomerInfoDTO
                                                      {
                                                          Id = x.Id,
                                                          CustomerName = x.CustomerName,
                                                      })
                                                      .ToList();

            return userlist;
        }
    }
}

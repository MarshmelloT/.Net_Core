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
    }
}

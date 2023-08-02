using IBLL;
using IDAL;
using Models;
using Models.DTO;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Customer_Refund_InstanceStepBLL: ICustomer_Refund_InstanceStepBLL
    {
        private PastryMSDB _dbContext;//数据库上下文
        private ICustomer_Refund_InstanceStepDAL _customer_Refund_InstanceStepDAL;

        public Customer_Refund_InstanceStepBLL(
            PastryMSDB dbContext
            , ICustomer_Refund_InstanceStepDAL customer_Refund_InstanceStepDAL
            )
        {
            _dbContext = dbContext;
            _customer_Refund_InstanceStepDAL = customer_Refund_InstanceStepDAL;
        }

        /// <summary>
        /// 获取客户退款流步骤
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="staffId"></param>
        /// <param name="status"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<GetCustomer_Refund_InstanceStepDTO> GetCustomer_Refund_InstanceStepList(int page, int limit, string staffId, int status, out int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 审核客户退款流步骤的方法
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="id"></param>
        /// <param name="outNum"></param>
        /// <param name="reviewReason"></param>
        /// <param name="reviewStatus"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateCustomer_Refund_InstanceStep(string staffId, string id, int outNum, string reviewReason, Customer_Refund_InstanceStepStatusEnum reviewStatus, out string msg)
        {
            throw new NotImplementedException();
        }
    }
}

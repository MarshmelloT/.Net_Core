using System;
using System.Collections.Generic;
using System.Text;
using Models.DTO;
using Models.Enums;

namespace IBLL
{
    /// <summary>
    /// 客户退款流步骤表的业务逻辑层——接口
    /// </summary>
    public interface ICustomer_Refund_InstanceStepBLL
    {
        /// <summary>
        /// 获取客户退款流步骤（当前要审核步骤）
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="staffId">员工id</param>
        /// <param name="status"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<GetCustomer_Refund_InstanceStepDTO> GetCustomer_Refund_InstanceStepList(int page, int limit, string staffId, int status, out int count);

        /// <summary>
        /// 审核客户退款流的方法
        /// </summary>
        /// <param name="staffId">当前员工的id</param>
        /// <param name="id"></param>
        /// <param name="outNum">数量</param>
        /// <param name="reviewReason">审核意见</param>
        /// <param name="reviewStatus">审核状态</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool UpdateCustomer_Refund_InstanceStep(string staffId, string id, int outNum, string reviewReason, Customer_Refund_InstanceStepStatusEnum reviewStatus, out string msg);

    }
}

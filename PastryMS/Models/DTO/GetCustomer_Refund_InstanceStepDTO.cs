using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    /// <summary>
    /// 客户退款流步骤表返回的值
    /// </summary>
    public class GetCustomer_Refund_InstanceStepDTO
    {
        /// <summary>
        /// 退款流步骤id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrdersId { get; set; }

        /// <summary>
        /// 审核人id
        /// </summary>
        public string ReviewerId { get; set; }

        /// <summary>
        /// 审核理由
        /// </summary>
        public string ReviewReason { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public int ReviewStatus { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? ReviewTime { get; set; }

        /// <summary>
        /// 上一个步骤id
        /// </summary>
        public string BeforeStepId { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    /// <summary>
    /// 客户退款流步骤表
    /// </summary>
    public class Customer_Refund_InstanceStep : BaseEntity
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        [MaxLength(36)]
        public string OrdersId { get; set; }

        /// <summary>
        /// 审核人id
        /// </summary>
        [MaxLength(36)]
        public string ReviewerId { get; set; }

        /// <summary>
        /// 审核理由
        /// </summary>
        [MaxLength(64)]
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
        [MaxLength(36)]
        public string BeforeStepId { get; set; }



    }
}

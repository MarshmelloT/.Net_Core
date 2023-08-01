using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Customer_Refund_Instance:BaseDelEntity
    {
        /// <summary>
        /// 订单流模板Id
        /// </summary>
        [MaxLength(36)]
        public string ModelId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(64)]
        public string Description { get; set; }
        /// <summary>
        /// 申请理由
        /// </summary>
        [MaxLength(64)]
        public string Reason { get; set; }
        /// <summary>
        /// 添加人Id
        /// </summary>

        [MaxLength(36)]
        public string Creator { get; set; }
        /// <summary>
        /// 添加数量
        /// </summary>

        public int OuntNum { get; set; }
        /// <summary>
        /// 出库物资Id
        /// </summary>

        [MaxLength(36)]
        public string OutGoodsId { get; set; }
    }
}

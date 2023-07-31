using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class GetWorkFlow_InstanceStepDTO
    {
        public string Id { get; set; }
        public string InstanceId { get; set; }
        /// <summary>
        /// 审核人Id
        /// </summary>
        public string ReviewerId { get; set; }
        public string UserName { get; set; }
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
        /// 上一个步骤Id
        /// </summary>
        public string BeforeStepId { get; set; }
        public int OutNum { get; set; }
        public string Title { get; set; }
        public string Reason { get; set; }
        public string ConsumableName { get; set; }
        public string CreatorId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

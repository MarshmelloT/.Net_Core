using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    /// <summary>
    /// 员工信息表
    /// </summary>
    public class StaffInfo:BaseDelEntity
    {
        /// <summary>
        /// 员工账号
        /// </summary>
        /// 
        [MaxLength(32)]
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(32)]
        public string Pwd { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(32)]
        public string Description { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        [MaxLength(16)]
        public string StaffName { get; set; }
        /// <summary>
        /// 主管id
        /// </summary>
        [MaxLength(36)]
        public string LeaderId { get; set; }
    }
}

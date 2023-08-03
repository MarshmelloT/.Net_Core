using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class CustomerInfo : BaseDelEntity
    {
        /// <summary>
        /// 客户账号
        /// </summary>
        [MaxLength(32)]
        public string Account { get; set; }
        /// <summary>
        /// 客户密码
        /// </summary>
        [MaxLength(32)]
        public string Pwd { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        [MaxLength(50)]
        public string CustomerName { get; set; }
        /// <summary>
        /// 客户性别
        /// </summary>
        [MaxLength(16)]
        public string Sex { get; set; }
        /// <summary>
        /// 客户年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(32)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string PhoneNum { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
    }
}

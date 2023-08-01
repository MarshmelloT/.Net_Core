using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DTO
{
    public class GetCustomerInfoDTO
    {
        public string Id { get; set; }
        public string Account { get; set; }
        /// <summary>
        /// 客户密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 客户性别
        /// </summary>
        public char Sex { get; set; }
        /// <summary>
        /// 客户年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        public DateTime  CreateTime { get; set; }
    }
}

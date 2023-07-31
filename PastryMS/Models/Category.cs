﻿using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 耗材类别表
    /// </summary>
    public class Category:BaseDelEntity
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        [MaxLength(16)]
        public string CategoryName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(32)]
        public string Description { get; set; }
    }
}

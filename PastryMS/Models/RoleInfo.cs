﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class RoleInfo:BaseDelEntity
    {
        /// <summary>
        /// 角色名
        /// </summary>
        [MaxLength(16)]
        public string RoleName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(32)]
        public string Description { get; set; }
    }
}

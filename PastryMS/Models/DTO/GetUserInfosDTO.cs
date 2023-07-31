﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //获取用户表返回的实体类
   public class GetUserInfosDTO
    {
        public string Id { get; set; }
        public string Account { get; set; }
        public string UserName { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentId { get; set; }
        public string Sex { get; set; }
        public DateTime CreateTime { get; set; }

    }
}

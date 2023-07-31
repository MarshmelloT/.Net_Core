﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public  class GetWorkFlow_InstanceDTO
    {
        public string Id { get; set; }
        public string ModelId { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string ConsumableName { get; set; }
        public string Reason { get; set; }
        public DateTime  CreateTime { get; set; }
        public string Creator { get; set; }
        public string UserName { get; set; }
        public int OutNum { get; set; }
        public string OutGoodsId { get; set; }
    }
}

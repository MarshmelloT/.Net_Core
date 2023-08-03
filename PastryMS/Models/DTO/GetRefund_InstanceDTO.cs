using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class GetRefund_InstanceDTO
    {
        public string Id { get; set; }

        public string ModelId { get; set; }

        public int Status { get; set; }
        public string Description { get; set; }

        public string Reason { get; set; }
        public DateTime CreateTime { get; set; }

        public string Creator { get; set; }
        public int OutNum { get; set; }
        public string OutGoodsId { get; set; }
    }
}

using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    //客户订单信息表
    public class OrdersInfo : BaseDelEntity
    {
        [MaxLength(250)]
        public string OrdersDetailId { get; set; }//订单详情

        [MaxLength(36)]
        public string CustomerId { get; set; }//客户编号
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }//消费金额

        [MaxLength(50)]
        public string Description { get; set; }//备注
    }
}

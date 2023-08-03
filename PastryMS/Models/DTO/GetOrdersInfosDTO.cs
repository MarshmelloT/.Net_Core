using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DTO
{
    public class GetOrdersInfosDTO
    {
        [MaxLength(36)]
        public string Id { get; set; }//ID

        [MaxLength(250)]
        public string OrdersDetailId { get; set; }//订单详情

        [MaxLength(36)]
        public string CustomerId { get; set; }//客户编号

        public decimal Price { get; set; }//消费金额

        [MaxLength(50)]
        public string Description { get; set; }//备注

        public DateTime CreateTime { get; set; }//添加时间

        //public DateTime DeleteTime { get; set; }
    }
}

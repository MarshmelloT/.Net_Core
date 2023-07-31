using Castle.MicroKernel.SubSystems.Conversion;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class OrdersDetailInfo:BaseDelEntity
    {
        [MaxLength(36)]
        public string DessertId { get; set; }
        public int  Num { get; set; }
        [MaxLength(32)]
        public string Specification { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

    }
}

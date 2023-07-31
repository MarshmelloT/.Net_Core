using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class DessertInfo : BaseDelEntity
    {
        [MaxLength(50)]
        public string DessertName { get; set; }
        [MaxLength(36)]
        public string DessertTypeId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Num { get; set; }
        [MaxLength(36)]
        public string Description { get; set; }
        public string Image { get; set; }
    }
}

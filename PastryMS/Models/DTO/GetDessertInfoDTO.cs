using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DTO
{
    public class GetDessertInfoDTO
    {
        public string Id { get; set; }
        public string DessertName { get; set; }
        public string DessertTypeId { get; set; }
        public string DessertTypeName { get; set; }
        public decimal Price { get; set; }
        public int Num { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }
    }
}

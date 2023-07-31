using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public  class DessertTypeInfo:BaseDelEntity
    {
        [MaxLength(50)]
        public string DessertTypeName { get; set; }

    }
}

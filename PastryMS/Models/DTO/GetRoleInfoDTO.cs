using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GetRoleInfoDTO
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }

    }
}

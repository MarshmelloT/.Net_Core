using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class GetDepartmentInfoDTO
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string DepartmentName { get; set; }
        public string LeaderName { get; set; }
        
        public string ParentName { get; set; }
        public string ParentId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

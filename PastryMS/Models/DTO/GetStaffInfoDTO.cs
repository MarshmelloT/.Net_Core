using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class GetStaffInfoDTO
    {
        public string Id { get; set; }
        public string Account { get; set; }
        public string Pwd { get; set; }
        public string Description { get; set; }
        public string StaffName { get; set; }
        public string LeaderId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

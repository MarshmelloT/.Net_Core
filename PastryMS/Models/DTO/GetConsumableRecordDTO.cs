using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class GetConsumableRecordDTO
    {
        public string Id { get; set; }

        public string ConsumableId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public int Type { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

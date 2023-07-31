using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 删除的基类
    /// </summary>
    public class BaseDelEntity:BaseEntity
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DelTime { get; set; }
    }
}

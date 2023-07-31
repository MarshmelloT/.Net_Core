using IDAL;
using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 带有删除的数据访问层基类
    /// </summary>
    public class BaseDeleteDAL<T> : BaseDAL<T>, IBaseDeleteDAL<T> where T : BaseDelEntity
    {
        PastryMSDB _dbContext;

        public BaseDeleteDAL(PastryMSDB dbContext):base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public T GetEntityById(string id)
        {
           return _dbContext.Set<T>().FirstOrDefault(u => u.Id == id);
        }
    }
}

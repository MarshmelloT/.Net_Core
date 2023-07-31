using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IBaseDeleteDAL<T> :IBaseDAL<T> where T:BaseDelEntity
    {
        /// <summary>
        /// 通过ID获取实体
        /// </summary>
        /// <param name="id">对象的ID</param>
        /// <returns></returns>
        T GetEntityById(string id);
    }
}

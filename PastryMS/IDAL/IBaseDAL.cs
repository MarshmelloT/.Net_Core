using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    /// <summary>
    /// 基础数据访问层接口
    /// </summary>
    public interface IBaseDAL<T> where T : BaseEntity
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity">添加的实体</param>
        /// <returns></returns>
        bool CreateEntity(T entity);

        /// <summary>
        /// 根据ID来删除实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool DeleteEntity(string Id);

        /// <summary>
        /// 根据实体进行删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteEntity(T entity);

        /// <summary>
        /// 查询整表数据
        /// </summary>
        /// <returns></returns>
        DbSet<T> GetEntities();

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">需要更新的实体对象</param>
        /// <returns></returns>
        bool UpdateEntity(T entity);
    }
}

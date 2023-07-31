using IDAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class BaseDAL<T> : IBaseDAL<T> where T : BaseEntity
    {
        PastryMSDB _dbContext;
        public BaseDAL(PastryMSDB dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 新增实体对象
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool CreateEntity(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges() > 0;
        }

        //id删除
        public bool DeleteEntity(string Id)
        {
            T entity = _dbContext.Set<T>().FirstOrDefault(u => u.Id == Id);//想根据ID查有没有这个实体
            if (entity == null)//如果没有实体
            {
                return false;//返回删除失败 
            }
            else
            {
                _dbContext.Set<T>().Remove(entity);//把实体删除
                return _dbContext.SaveChanges() > 0;//返回删除结果
            }
        }

        //实体删除
        public bool DeleteEntity(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            else
            {
                _dbContext.Set<T>().Remove(entity);
                return _dbContext.SaveChanges() > 0;
            }
        }

        public DbSet<T> GetEntities()
        {
            return _dbContext.Set<T>();
        }

        public bool UpdateEntity(T entity)
        {
            //_dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges() > 0;
        }
    }
}

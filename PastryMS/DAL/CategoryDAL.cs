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
    public class CategoryDAL : BaseDeleteDAL<Category>, ICategoryDAL
    {
        private PastryMSDB _dbContext;
        public CategoryDAL(PastryMSDB dbContext) : base(dbContext)
        {
            _dbContext= dbContext;
        }

        public DbSet<Category> GetCategories()
        {
            return _dbContext.Category;
        }
    }
}

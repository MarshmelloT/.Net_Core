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
    public class MenuInfoDAL : BaseDeleteDAL<MenuInfo>, IMenuInfoDAL
    {
        private PastryMSDB _dbContext;
        public MenuInfoDAL(PastryMSDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<MenuInfo> MenuInfos()
        {
            return _dbContext.MenuInfo;
        }
    }
}

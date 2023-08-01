using IBLL;
using IDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class StaffInfoBLL : IStaffInfoBLL
    {
        #region 构造函数初始化
        //private UserInfoDAL _UserInfoDAL;
        private IStaffInfoDAL _StaffInfoDAL;
        private PastryMSDB _dbContext;

        public StaffInfoBLL(
            IStaffInfoDAL staffInfoDAL
            , PastryMSDB dbContext

            )
        {
            //_UserInfoDAL = new UserInfoDAL();
            _StaffInfoDAL = staffInfoDAL;
            _dbContext = dbContext;
        }
        #endregion
       
    }
}

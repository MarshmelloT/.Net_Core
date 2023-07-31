using IBLL;
using IDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CustomerInfoBLL: ICustomerInfoBLL
    {
        private PastryMSDB _dbContext;
        private ICustomerInfoDAL _ICustomerInfoDAL;
        public CustomerInfoBLL(PastryMSDB dbContext, ICustomerInfoDAL iCustomerInfoDAL)
        {
            _dbContext = dbContext;
            _ICustomerInfoDAL = iCustomerInfoDAL;
        }
    }
}

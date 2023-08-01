using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL
{
    public interface ICustomerInfoBLL
    {
        bool Login(string account, string pwd, out string msg, out string customerName, out string customerid);

        List<GetCustomerInfoDTO> getCustomerInfo(int page, int limit, string account, string customerName, out int count);
    }
}

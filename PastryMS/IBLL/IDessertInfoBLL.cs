using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL
{
    public interface IDessertInfoBLL
    {
        List<GetDessertInfoDTO> getDessertInfos(int page, int limit, string dessertName, string dessertTypeId, out int count);
        bool UpLoadDessertInfo(DessertInfo entity, out string msg);
        bool DownDessertInfo(DessertInfo dessertInfo, out string msg);
        bool BuyDessertInfo(DessertInfo entity, out string msg);

    }
}

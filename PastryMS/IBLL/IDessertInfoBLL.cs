using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL
{
    public interface IDessertInfoBLL
    {
        object GetSelectOptions();
        DessertInfo GetDessertInfoById(string id);
        List<GetDessertInfoDTO> getDessertInfos(int page, int limit, string dessertName, string dessertTypeId, out int count);
        bool UpLoadDessertInfo(DessertInfo entity, out string msg);
        bool ReUpLoadDessertInfo(DessertInfo entity, out string msg);
        bool DownDessertInfo(string id);
        bool DownDessertInfos(List<string> ids);
        bool BuyDessertInfo(DessertInfo entity, out string msg);

    }
}

using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IConsumableInfoBLL
    {
        object GetSelectOptions();
        object GetConsumableSelect();
        ConsumableInfo GetConsumableById(string id);
        List<GetConsumableInfosDTO> GetConsumableInfos(int page,int limit,string ConsumableName ,out int count);
        ConsumableInfo GetConsumableInfoById(string id);
        bool CreateConsumableInfo(ConsumableInfo entity,out string msg);
        bool DeleteConsumableInfo(string id);
        bool DeleteConsumableInfos(List<string> ids);
        bool UpdateConsumableInfo(ConsumableInfo consumableInfo, out string msg);
        bool Upload(Stream stream, string extension, string userId, out string msg);
        Stream GetDownload(out string downloadFileName);
    }
}

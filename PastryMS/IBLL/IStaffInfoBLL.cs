using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL
{
    public interface IStaffInfoBLL
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="msg"></param>
        /// <param name="staffName"></param>
        /// <param name="staffId"></param>
        /// <returns></returns>
        bool Login(string account, string pwd, out string msg, out string staffName, out string staffId);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="account"></param>
        /// <param name="staffName"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<GetStaffInfoDTO> GetStaffInfos(int page, int limit, string account, string staffName, out int count);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool CreateStaffInfo(StaffInfo entity, out string msg);

        /// <summary>
        /// 用户软删除方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteStaffInfo(string id);

        /// <summary>
        /// 批量用户软删除方法
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteStaffInfos(List<string> ids);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="staffInfo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool UpdateStaffInfo(StaffInfo staffInfo, out string msg);
    }
}

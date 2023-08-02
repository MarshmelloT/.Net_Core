using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace IBLL
{
    public interface IRefund_InstanceBLL
    {
        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="modelIdint"></param>
        /// <param name="status"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<GetRefund_InstanceDTO> GetRefund_Instances(int page, int limit, string modelId, int status, out int count);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool CreateRefund_Instance(Refund_Instance entity, out string msg);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="category"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool UpdateRefund_Instance(Refund_Instance refund_Instance, out string msg);
        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //bool DeleteRefund_Instance(string id);
        ///// <summary>
        ///// 批量删除
        ///// </summary>
        ///// <param name="ids"></param>
        ///// <returns></returns>
        //bool DeleteRefund_Instance(List<string> ids);

    }
}

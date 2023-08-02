using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using static System.Net.WebRequestMethods;

namespace common
{
    public class FileHelper
    {
    }


    public static class FileHelperExtensions
    {
        public static bool Upload(this IHelper helper, Stream stream, string extension, string userId, out string fileId, out string msg)
        {
            try
            {
                var _env = helper.GetServie<IHostingEnvironment>();
                string path = Path.Combine(_env.WebRootPath, "UploadFile\\" + userId);//文件夹
                fileId = Guid.NewGuid().ToString();//文件名
                var fileName = fileId + extension;//完整文件名
                string filepath = Path.Combine(path, fileName);//整个文件的具体路径
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite))
                {
                    stream.CopyTo(fs);
                }
                msg = "上传成功";
                return true;
            }
            catch (Exception ex)
            {
                fileId = "";
                msg = ex.Message;
                return false;
            }

        }
        public static Stream DownLoad(this IHelper helper, string fileId, string creatorId, string extension)
        {
            try
            {
                //获取当前项目运行的目录
                var _enviroment = helper.GetServie<IHostingEnvironment>();
                var path = Path.Combine(_enviroment.WebRootPath, "UploadFile", creatorId);

                var filename = fileId + extension;

                //拼接路径与文件名
                string filePath = Path.Combine(path, filename);

                //重新打开文件流去读取要下载的图片文件
                FileStream fileStream=new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return fileStream;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


    }


}

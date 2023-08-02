using IBLL;
using IDAL;
using Microsoft.EntityFrameworkCore;
using Model.Enums;
using Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ConsumableInfoBLL : IConsumableInfoBLL
    {
        private PastryMSDB _dbContext;
        private IConsumableInfoDAL _consumableInfoDAL;
        public ConsumableInfoBLL(PastryMSDB dbContext
            , IConsumableInfoDAL consumableInfoDAL
            )
        {
            _dbContext = dbContext;
            _consumableInfoDAL = consumableInfoDAL;
        }
        public List<GetConsumableInfosDTO> GetConsumableInfos(int page, int limit, string ConsumableName, out int count)
        {
            var data = from c in _dbContext.ConsumableInfo.Where(c => c.IsDeleted == false)
                       join ca in _dbContext.Category.Where(c => c.IsDeleted == false)
                       on c.CategoryId equals ca.Id
                       into TempCa
                       from cca in TempCa.DefaultIfEmpty()
                       select new GetConsumableInfosDTO
                       {
                           Id = c.Id,
                           Description = c.Description,
                           CategoryId = c.CategoryId,
                           CategoryName = cca.CategoryName,
                           ConsumableName = c.ConsumableName,
                           Specification = c.Specification,
                           Num = c.Num,
                           Unit = c.Unit,
                           Money = c.Money,
                           WarningNum = c.WarningNum,
                           CreateTime = c.CreateTime == null ? DateTime.Now : c.CreateTime,

                       };

            count = data.Count();

            if (!string.IsNullOrWhiteSpace(ConsumableName))
            {
                data = data.Where(c => c.ConsumableName.Contains(ConsumableName));
            }

            var list = data.OrderByDescending(c => c.CreateTime).Skip(limit * (page - 1)).Take(limit).ToList();

            return list;
        }
        public bool CreateConsumableInfo(ConsumableInfo entity, out string msg)
        {
            if (string.IsNullOrWhiteSpace(entity.ConsumableName))
            {
                msg = "耗材名称不能为空";
                return false;
            }

            ConsumableInfo consumableInfo = _consumableInfoDAL.GetEntities().FirstOrDefault(c => c.ConsumableName == entity.ConsumableName);
            if (consumableInfo != null)
            {
                msg = "耗材名称已存在";
                return false;
            }
            entity.Id = Guid.NewGuid().ToString();
            entity.CreateTime = DateTime.Now;

            bool isok = _consumableInfoDAL.CreateEntity(entity);
            msg = isok ? $"添加{entity.ConsumableName}成功" : "添加失败";

            return isok;
        }
        public bool DeleteConsumableInfo(string id)
        {
            ConsumableInfo consumableInfo = _consumableInfoDAL.GetEntityById(id);

            if (consumableInfo == null)
            {
                return false;
            }
            consumableInfo.IsDeleted = true;
            consumableInfo.DelTime = DateTime.Now;

            return _consumableInfoDAL.UpdateEntity(consumableInfo);
        }
        public bool DeleteConsumableInfos(List<string> ids)
        {
            foreach (string id in ids)
            {
                ConsumableInfo consumableInfo = _consumableInfoDAL.GetEntityById(id);
                if (consumableInfo == null)
                {
                    continue;
                }
                consumableInfo.IsDeleted = true;
                consumableInfo.DelTime = DateTime.Now;

                return _consumableInfoDAL.UpdateEntity(consumableInfo);
            }
            return true;
        }
        public ConsumableInfo GetConsumableInfoById(string id)
        {
            return _consumableInfoDAL.GetEntityById(id);
        }
        public bool UpdateConsumableInfo(ConsumableInfo consumableInfo, out string msg)
        {
            if (string.IsNullOrWhiteSpace(consumableInfo.Id))
            {
                msg = "id不能为空";
                return false;
            }

            ConsumableInfo entity = _consumableInfoDAL.GetEntityById(consumableInfo.Id);
            if (entity == null)
            {
                msg = "id无效";
                return false;
            }

            if (entity.ConsumableName != consumableInfo.ConsumableName)
            {

                ConsumableInfo oldConsumable = _consumableInfoDAL.GetEntities().FirstOrDefault(c => c.ConsumableName == entity.ConsumableName);
                if (oldConsumable != null)
                {
                    msg = "耗材名称已存在";
                    return false;
                }
            }

            entity.ConsumableName = consumableInfo.ConsumableName;
            entity.CategoryId = consumableInfo.CategoryId;
            entity.Description = consumableInfo.Description;
            entity.Specification = consumableInfo.Specification;
            entity.Num = consumableInfo.Num;
            entity.Unit = consumableInfo.Unit;
            entity.Money = consumableInfo.Money;
            entity.WarningNum = consumableInfo.WarningNum;

            bool isok = _consumableInfoDAL.UpdateEntity(entity);
            msg = isok ? "更新成功" : "更新失败";

            return isok;
        }
        public object GetSelectOptions()
        {
            var typeList = _dbContext.Category.Where(c => !c.IsDeleted)
                                                       .Select(c => new
                                                       {
                                                           value = c.Id,
                                                           title = c.CategoryName
                                                       }).ToList();

            var data = new
            {
                typeList
            };
            return data;
        }
        public object GetConsumableSelect()
        {
            var consumableSelect = _dbContext.ConsumableInfo.Where(c => !c.IsDeleted)
                                                       .Select(c => new
                                                       {
                                                           value = c.Id,
                                                           title = c.ConsumableName
                                                       }).ToList();

            return consumableSelect;
        }

        public ConsumableInfo GetConsumableById(string id)
        {
            return _consumableInfoDAL.GetEntityById(id);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <param name="extension">文件后缀</param>
        /// <param name="userId">上传用户的id</param>
        /// <param name="msg">返回的消息</param>
        /// <returns></returns>
        public bool Upload(Stream stream, string extension, string userId, out string msg)
        {
            IWorkbook wk = null;
            if (extension.Equals(".xls"))
            {
                //把文件流写入到工作簿
                wk = new HSSFWorkbook(stream);
            }
            else
            {
                wk = new XSSFWorkbook(stream);
            }

            stream.Close();//关闭支援
            stream.Dispose();//释放资源

            //获取第一个工作表sheet
            ISheet sheet = wk.GetSheetAt(0);//索引从0开始
            int rowNum = sheet.LastRowNum;//获取有多少行

            //打开事务
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //遍历获取
                    for (int i = 1; i <= rowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);//遍历获取每一列
                        ICell cell = row.GetCell(0);//每一行的第一列的商品名称
                        ICell cell2 = row.GetCell(2);//每一行的第三列的
                        string value = cell.ToString();//获取的值为商品名称
                        string value2 = cell2.ToString();//实际购买数量
                        int num;
                        bool b = int.TryParse(value2, out num);
                        if (b == false)
                        {
                            transaction.Rollback();//事务回滚
                            msg = $"第{i + 1}行耗材实际购买数量有误";
                            return false;
                        }

                        //查询该商品在数据库的数据
                        ConsumableInfo consumableInfo = _consumableInfoDAL.GetEntities().FirstOrDefault(x => x.IsDeleted == false && x.ConsumableName == value);
                        if (consumableInfo == null)
                        {
                            transaction.Rollback();//事务回滚
                            msg = $"第{i + 1}行{value}耗材不存在";
                            return false;
                        }

                        //实例化入库记录表
                        ConsumableRecord consumableRecord = new ConsumableRecord();
                        consumableRecord.Id = Guid.NewGuid().ToString();
                        consumableRecord.ConsumableId = consumableInfo.Id;
                        consumableRecord.CreateTime = DateTime.Now;
                        consumableRecord.Creator = userId;
                        consumableRecord.Num = num;
                        consumableRecord.Type = (int)ConsumableInfoTypeEnums.入库;

                        //添加到耗材记录表数据库
                        _dbContext.ConsumableRecord.Add(consumableRecord);
                        bool isok = _dbContext.SaveChanges() > 0;//执行提交到数据库
                        if (isok == false)
                        {
                            transaction.Rollback();
                            msg = $"第{i + 1}行耗材记录添加失败";
                            return false;
                        }

                        //更新耗材信息表库存
                        consumableInfo.Num += num;
                        //把实体改成修改状态
                        _dbContext.ConsumableInfo.Update(consumableInfo);
                        isok = _dbContext.SaveChanges() > 0;

                        if (isok == false)
                        {
                            transaction.Rollback();
                            msg = $"第{i + 1}行耗材信息表库存更新失败";
                            return false;
                        }
                    }

                    //提交事务
                    transaction.Commit();
                    msg = "入库成功";
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Commit();//报错事务回滚
                    msg = ex.Message;
                    return false;
                }

            }
        }
        //下载
        public Stream GetDownload(out string downloadFileName)
        {
            //查询要导出的数据
            var datas = (from cr in _dbContext.ConsumableRecord
                         join c in _dbContext.ConsumableInfo.Where(x => x.IsDeleted == false)
                         on cr.ConsumableId equals c.Id
                         into tempCRC
                         from cc in tempCRC.DefaultIfEmpty()

                         join u in _dbContext.StaffInfo
                         on cc.CategoryId equals u.Id
                         into tempCCU
                         from uu in tempCCU.DefaultIfEmpty()
                         select new
                         {
                             cc.ConsumableName,//耗材名称
                             cc.Specification,//耗材规格
                             Type = cr.Type == (int)ConsumableInfoTypeEnums.入库 ? "出库" : "入库",//出入库类型
                             cc.Num,//每次出入库的数量
                             CreateTime = cr.CreateTime,
                             uu.StaffName,//操作人
                         }).ToList();

            //开始对文件进行操作
            string path = Directory.GetCurrentDirectory();
            string fileName = "出入库导出记录" + DateTime.Now.ToString("yyyy-MM-dd hh mm ss") + ".xlsx";
            //拼接完整路径
            string filePath = Path.Combine(path, fileName);

            //创建一个Excel对象
            IWorkbook wk = null;
            //获取文件扩展名
            string extension = Path.GetExtension(filePath);

            //操作文件
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                if (extension.Equals(".xls"))
                {
                    wk = new HSSFWorkbook();
                }
                else
                {
                    wk = new XSSFWorkbook();
                }

                //先创一个sheet表
                ISheet sheet = wk.CreateSheet("表1");

                //表头
                IRow row = sheet.CreateRow(0);

                string[] title =
                {
                    "耗材名称",
                    "耗材规格",
                    "类型",
                    "出入库数量",
                    "出入库时间",
                    "操作人"
                };
                for (int i = 0; i < title.Length; i++)
                {
                    ICell cell = row.CreateCell(i);//每一列
                    cell.SetCellValue(title[i]);//给每一列复制
                }

                //主体部分
                for (int i = 0; i < datas.Count; i++)
                {
                    var data = datas[i];//获取数据
                    //创建行
                    IRow tempRow = sheet.CreateRow(i + 1);
                    //创建列
                    ICell tempCell = tempRow.CreateCell(0);
                    tempCell.SetCellValue(data.ConsumableName);

                    ICell tempCell1 = tempRow.CreateCell(1);
                    tempCell1.SetCellValue(data.Specification);

                    ICell tempCell2 = tempRow.CreateCell(2);
                    tempCell2.SetCellValue(data.Type);

                    ICell tempCell3 = tempRow.CreateCell(3);
                    tempCell3.SetCellValue(data.Num);

                    ICell tempCell4 = tempRow.CreateCell(4);
                    tempCell4.SetCellValue(data.CreateTime.ToString("yyyy-MM-dd hh:mm:ss"));

                    ICell tempCell5 = tempRow.CreateCell(5);
                    tempCell5.SetCellValue(data.StaffName);
                }

                //把Excel写入到文件里
                wk.Write(fs);
                //重新打开
                FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                downloadFileName = fileName;//文件名
                return fileStream;//文件

            }
        }
    }
}

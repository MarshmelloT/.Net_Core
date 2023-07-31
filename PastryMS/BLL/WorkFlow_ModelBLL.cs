using IBLL;
using IDAL;
using Model;
using Model.DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WorkFlow_ModelBLL : IWorkFlow_ModelBLL
    {
        private PastryMSDB _dbContext;
        private IWorkFlow_ModelDAL _workFlow_ModelDAL;
        public WorkFlow_ModelBLL(PastryMSDB dbContext
            , IWorkFlow_ModelDAL workFlow_ModelDAL
            )
        {
            _dbContext = dbContext;
            _workFlow_ModelDAL = workFlow_ModelDAL;
        }

        public bool CreateWorkFlow_Model(WorkFlow_Model entity, out string msg)
        {
            if (string.IsNullOrWhiteSpace(entity.Title))
            {
                msg = "标题不能为空";
                return false;
            }

            WorkFlow_Model workFlow_Model = _workFlow_ModelDAL.GetEntities().FirstOrDefault(w => w.Title == entity.Title);
            if (workFlow_Model != null)
            {
                msg = "标题已存在";
                return false;
            }
            entity.Id = Guid.NewGuid().ToString();
            entity.CreateTime = DateTime.Now;

            bool isok = _workFlow_ModelDAL.CreateEntity(entity);
            msg = isok ? "添加成功" : "添加失败";
            return isok;
        }



        public bool DeleteWorkFlow_Model(string id)
        {
            WorkFlow_Model workFlow_Model = _workFlow_ModelDAL.GetEntityById(id);
            if (workFlow_Model == null)
            {
                return false;
            }
            workFlow_Model.IsDeleted = true;
            workFlow_Model.DelTime = DateTime.Now;

            return _workFlow_ModelDAL.UpdateEntity(workFlow_Model);
        }

        public bool DeleteWorkFlow_Models(List<string> ids)
        {

            foreach (var id in ids)
            {
                WorkFlow_Model workFlow_Model = _workFlow_ModelDAL.GetEntityById(id);
                if (workFlow_Model == null)
                {
                    continue;
                }
                workFlow_Model.IsDeleted = true;
                workFlow_Model.DelTime = DateTime.Now;

                _workFlow_ModelDAL.UpdateEntity(workFlow_Model);
            }
            return true;
        }

        

        public List<GetWorkFlow_ModelDTO> getWorkFlow_ModelDTOs(int page, int limit, string title, out int count)
        {
            var data = from w in _dbContext.WorkFlow_Model.Where(w => w.IsDeleted == false)
                       select new GetWorkFlow_ModelDTO
                       {
                           Id = w.Id,
                           Title = w.Title,
                           CreateTime = w.CreateTime == null ? DateTime.Now : w.CreateTime,
                       };

            count = data.Count();

            if (!string.IsNullOrWhiteSpace(title))
            {
                data = data.Where(w => w.Title.Contains(title));
            }

            var list = data.OrderByDescending(w => w.CreateTime).Skip(limit * (page - 1)).Take(limit).ToList();

            return list;


        }

        public List<GetWorkFlow_ModelDTO> getWorkFlow_ModelDTOs()
        {
            List<GetWorkFlow_ModelDTO> modelSelect = _workFlow_ModelDAL.GetEntities()
                                                       .Where(x => x.IsDeleted == false)
                                                       .Select(x => new GetWorkFlow_ModelDTO
                                                       {
                                                           Id = x.Id,
                                                           Title = x.Title,
                                                       })
                                                       .ToList();

            return modelSelect;
        }
        public object GetModelSelect()
        {
            var list = _workFlow_ModelDAL.GetEntities().Where(d => !d.IsDeleted)
                                                       .Select(d => new
                                                       {
                                                           value = d.Id,
                                                           title = d.Title
                                                       }).ToList();


            return list;
        }
        public bool UpdateWorkFlow_Model(WorkFlow_Model workFlow_Model, out string msg)
        {
            throw new NotImplementedException();
        }
    }
}

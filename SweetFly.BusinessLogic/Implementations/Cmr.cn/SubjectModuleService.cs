using System;
using System.Collections.Generic;
using System.Linq;
using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Model.ApiControllers.BaseApiController;
using SweetFly.Model.ApiControllers.BaseApiController.Enums;
using SweetFly.Model.Entities.Cmr.cn;
using SweetFly.Repository.contract;

namespace SweetFly.BusinessLogic.Implementations.Cmr.cn
{
    public class SubjectModuleService : BaseSoftDeleteable<SubjectModule>, ISubjectModuleService
    {
        public ICmrcnRepository<SubjectModule> SubjectModuleRepository { get; set; }

        protected override IQueryable<SubjectModule> Search()
        {
            return SubjectModuleRepository.LoadEntities(x => false == x.DelFlag).AsQueryable();
        }
        protected override bool Remove(SubjectModule entity)
        {
            entity.DelFlag = true;
            return SubjectModuleRepository.Update(entity);
        }


        public List<SubjectModule> PageList(int pageIndex, int pageSize, out int total)
        {
            var result = SubjectModuleRepository.LoadPageEntities(pageIndex, pageSize, out total,
                                                                x => x.DelFlag == false,
                                                                x => x.CreateTime,
                                                                false)
                                                                .ToList();

            return result;
        }

        public ApiResponse<SubjectModule> Insert(SubjectModule model)
        {
            var result = new ApiResponse<SubjectModule>();
            if (model == null || string.IsNullOrEmpty(model.Name) || model.Subject_Id == 0)
            {
                return result.Failed(ResultEnum.ParameterError);
            }
            if (Search().Any(x => x.Subject_Id == model.Subject_Id && x.Name == model.Name))
            {
                return result.Failed(ResultEnum.FormatError, "存在Name相同的数据");
            }

            model.Name = model.Name.Trim();
            model.CreateTime = DateTime.Now;
            model.DelFlag = false;

            result.Result = SubjectModuleRepository.Insert(model);

            if (model.Id > 0) { result.Success(); }

            return result;
        }

        public ApiResponse<bool> Update(SubjectModule model)
        {
            var result = new ApiResponse<bool>();

            var entity = Search().FirstOrDefault(x => x.Id == model.Id);
            if (entity == null)
            {
                return result.Failed(ResultEnum.ParameterError);
            }
            entity.Name = model.Name.Trim();
            entity.Subject_Id = model.Subject_Id;

            result.Result = SubjectModuleRepository.Update(entity);

            if (result.Result) { result.Success(); }

            return result;
        }

        public ApiResponse<bool> Remove(int id)
        {
            var result = new ApiResponse<bool>();

            var entity = Search().FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return result.Failed(ResultEnum.NoData);
            }

            result.Result = Remove(entity);

            if (result.Result) { result.Success(); }

            return result;
        }
        
        public ApiResponse<List<SubjectModule>> LoadModulesBySubjectId(int subjectId)
        {
            var result = new ApiResponse<List<SubjectModule>>();
            if (subjectId <= 0)
            {
                return result.Failed(ResultEnum.ParameterError);
            }

            result.Result = Search().Where(x => x.Subject_Id == subjectId).ToList();

            if (result.Result.Count > 0) { result.Success(); }

            return result;
        }
    }
}
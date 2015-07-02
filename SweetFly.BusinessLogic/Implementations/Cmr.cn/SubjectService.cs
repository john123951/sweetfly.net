using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Model.ApiControllers.BaseApiController;
using SweetFly.Model.ApiControllers.BaseApiController.Enums;
using SweetFly.Model.Entities.Cmr.cn;
using SweetFly.Repository.contract;
using SweetFly.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SweetFly.BusinessLogic.Implementations.Cmr.cn
{
    public class SubjectService : BaseSoftDeleteable<Subject>, ISubjectService
    {
        public ICmrcnRepository<Subject> SubjectRepository { get; set; }

        protected override IQueryable<Subject> Search()
        {
            return SubjectRepository.LoadEntities(x => false == x.DelFlag).AsQueryable();
        }
        protected override bool Remove(Subject entity)
        {
            entity.DelFlag = true;
            return SubjectRepository.Update(entity);
        }

        public List<Subject> PageList(int pageIndex, int pageSize, out int total)
        {
            var result = SubjectRepository.LoadPageEntities(pageIndex, pageSize, out total,
                                                                x => x.DelFlag == false,
                                                                x => x.CreateTime,
                                                                false)
                                                                .ToList();

            return result;
        }

        public ApiResponse<Subject> Insert(Subject model)
        {
            var result = new ApiResponse<Subject>();
            if (model == null || string.IsNullOrEmpty(model.Name))
            {
                return result.Failed(ResultEnum.ParameterError);
            }
            if (Search().Any(x => x.Name == model.Name))
            {
                return result.Failed(ResultEnum.FormatError, "存在Name相同的数据");
            }

            model.Name = model.Name.Trim();
            model.PyShort = string.Join(",", PinyinUtility.GetShortPinyin(model.Name).ToArray());
            model.HomeworkUrl = model.HomeworkUrl.Trim();

            model.CreateTime = DateTime.Now;
            model.DelFlag = false;

            result.Result = SubjectRepository.Insert(model);

            if (model.Id > 0) { result.Success(); }

            return result;
        }

        public ApiResponse<bool> Update(Subject model)
        {
            var result = new ApiResponse<bool>();

            var entity = Search().FirstOrDefault(x => x.Id == model.Id);
            if (entity == null)
            {
                return result.Failed(ResultEnum.ParameterError);
            }
            entity.Name = model.Name.Trim();
            entity.PyShort = string.Join(",", PinyinUtility.GetShortPinyin(entity.Name).ToArray());
            entity.HomeworkUrl = model.HomeworkUrl.Trim();

            result.Result = SubjectRepository.Update(entity);

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

        public ApiResponse<List<Subject>> LoadAllSubjects()
        {
            var result = new ApiResponse<List<Subject>>();

            result.Result = Search().ToList();

            if (result.Result.Count > 0) { result.Success(); }

            return result;
        }
    }
}

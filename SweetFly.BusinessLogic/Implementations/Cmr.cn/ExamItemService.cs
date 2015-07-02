using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Model.Entities.Cmr.cn;
using SweetFly.Repository.contract;
using System.Collections.Generic;
using System.Linq;

namespace SweetFly.BusinessLogic.Implementations.Cmr.cn
{
    public class ExamItemService : BaseSoftDeleteable<ExamItem>, IExamItemService
    {
        public ICmrcnRepository<ExamItem> ExamItemRepository { get; set; }

        protected override IQueryable<ExamItem> Search()
        {
            return ExamItemRepository.LoadEntities(x => false == x.DelFlag).AsQueryable();
        }

        protected override bool Remove(ExamItem entity)
        {
            entity.DelFlag = true;
            return ExamItemRepository.Update(entity);
        }

        public List<ExamItem> PageList(int pageIndex, int pageSize, out int total)
        {
            var result = ExamItemRepository.LoadPageEntities(pageIndex, pageSize, out total,
                                                                x => x.DelFlag == false,
                                                                x => x.CreateTime,
                                                                false)
                                                                .ToList();

            return result;
        }

        public int SaveOrUpdate(IList<ExamItem> entities)
        {
            return ExamItemRepository.SaveOrUpdateTransaction(entities);
        }

        public bool CheckExam(int id)
        {
            return Search().Any(x => x.Id == id);
        }

        public ExamItem GetEntityById(int id)
        {
            return Search().FirstOrDefault(x => x.Id == id);
        }

        public int Count(Model.Search.ExamItemSearch search = null)
        {
            var data = Search();

            if (search == null)
            {
                return data.Count();
            }
            if (search.ModuleId != 0)
            {
                data = data.Where(x => x.Module_Id == search.ModuleId);
            }

            return data.Count();
        }

        public List<ExamItem> GetEntitiesByIds(List<int> ids)
        {
            var result = Search().Where(x => ids.Contains(x.Id));
            return result.ToList();
        }
    }
}
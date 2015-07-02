using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Model.ApiControllers.BaseApiController;
using SweetFly.Model.ApiControllers.BaseApiController.Enums;
using SweetFly.Model.Entities.Cmr.cn;
using SweetFly.Repository.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace SweetFly.BusinessLogic.Implementations.Cmr.cn
{
    public class CmrUserService : BaseSoftDeleteable<CmrUser>, ICmrUserService
    {
        public ICmrcnRepository<CmrUser> CmrUserRepository { get; set; }

        protected override IQueryable<CmrUser> Search()
        {
            return CmrUserRepository.LoadEntities(x => false == x.DelFlag).AsQueryable();
        }

        protected override bool Remove(CmrUser entity)
        {
            entity.DelFlag = true;
            return CmrUserRepository.Update(entity);
        }

        public List<CmrUser> PageList(int pageIndex, int pageSize, out int total)
        {
            var result = CmrUserRepository.LoadPageEntities(pageIndex, pageSize, out total,
                                                                x => x.DelFlag == false,
                                                                x => x.CreateTime,
                                                                false)
                                                                .ToList();

            return result;
        }

        public ApiResponse<bool> SaveOrUpdate(CmrUser model)
        {
            var result = new ApiResponse<bool>();
            if (model == null || string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password)) { result.Failed(ResultEnum.ParameterError); }

            model.UserName = model.UserName.Trim();
            model.Password = model.Password;

            var entity = Search().Where(x => x.UserName == model.UserName).FirstOrDefault();
            if (entity != null)
            {
                if (entity.Password != model.Password) { entity.Password = model.Password; }
                entity.LastUseTime = DateTime.Now;
                entity.UseTimes++;
            }
            else
            {
                entity = new CmrUser();
                entity.UserName = model.UserName.Trim();
                entity.Password = model.Password;
                entity.UseTimes = 1;
                entity.LastUseTime = DateTime.Now;
                entity.CreateTime = DateTime.Now;
                entity.DelFlag = false;
            }
            result.Result = CmrUserRepository.SaveOrUpdate(entity);

            return result.Success();
        }
    }
}
using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Model.ApiControllers.BaseApiController;
using SweetFly.Model.ApiControllers.BaseApiController.Enums;
using SweetFly.Model.Entities.Cmr.cn;
using SweetFly.Repository.contract;
using System.Collections.Generic;
using System.Linq;

namespace SweetFly.BusinessLogic.Implementations.Cmr.cn
{
    public class ItemTypeService : IItemTypeService
    {
        public ICmrcnRepository<ItemType> ItemTypeRepository { get; set; }

        public ItemType GetByText(string text)
        {
            var result = ItemTypeRepository.LoadEntities(x => text.Trim() == x.Text).FirstOrDefault();
            return result;
        }

        public List<ItemType> PageList(int pageIndex, int pageSize, out int total)
        {
            var result = ItemTypeRepository.LoadPageEntities(pageIndex, pageSize, out total,
                                                                x => true,
                                                                x => x.Id,
                                                                false)
                                                                .ToList();

            return result;
        }

        public ApiResponse<ItemType> Insert(ItemType model)
        {
            var result = new ApiResponse<ItemType>();
            if (model == null || string.IsNullOrEmpty(model.Text) || model.Subject_Id == 0)
            {
                return result.Failed(ResultEnum.ParameterError);
            }
            if (ItemTypeRepository.LoadEntities(x => x.Text == model.Text).Any())
            {
                return result.Failed(ResultEnum.FormatError, "存在Text相同的数据");
            }

            model.Text = model.Text.Trim();

            result.Result = ItemTypeRepository.Insert(model);

            if (model.Id > 0) { result.Success(); }

            return result;
        }

        public ApiResponse<bool> Update(ItemType model)
        {
            var result = new ApiResponse<bool>();

            var entity = ItemTypeRepository.LoadEntities(x => x.Id == model.Id).FirstOrDefault();
            if (entity == null)
            {
                return result.Failed(ResultEnum.ParameterError);
            }
            entity.Text = model.Text.Trim();
            entity.Subject_Id = model.Subject_Id;

            result.Result = ItemTypeRepository.Update(entity);

            if (result.Result) { result.Success(); }

            return result;
        }

        public ApiResponse<bool> Remove(int id)
        {
            var result = new ApiResponse<bool>();

            var entity = ItemTypeRepository.LoadEntities(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return result.Failed(ResultEnum.NoData);
            }

            result.Result = ItemTypeRepository.Remove(entity);

            if (result.Result) { result.Success(); }

            return result;
        }
    }
}

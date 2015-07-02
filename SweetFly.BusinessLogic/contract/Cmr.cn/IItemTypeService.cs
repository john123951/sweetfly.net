
using System.Collections.Generic;
using SweetFly.Model.ApiControllers.BaseApiController;
using SweetFly.Model.Entities.Cmr.cn;
namespace SweetFly.BusinessLogic.contract.Cmr.cn
{
    public interface IItemTypeService
    {
        /// <summary>
        /// 根据字符串查找对应的题目类别
        /// </summary>
        /// <param name="text">要查找的字符串</param>
        /// <returns></returns>
        ItemType GetByText(string text);

        /// <summary>
        /// 分页展示数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        List<ItemType> PageList(int pageIndex, int pageSize, out int total);

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResponse<ItemType> Insert(ItemType model);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResponse<bool> Update(ItemType model);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApiResponse<bool> Remove(int id);
    }
}
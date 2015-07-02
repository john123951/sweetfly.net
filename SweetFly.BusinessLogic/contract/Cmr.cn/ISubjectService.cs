
using SweetFly.Model.ApiControllers.BaseApiController;
using SweetFly.Model.Entities.Cmr.cn;
using System.Collections.Generic;
namespace SweetFly.BusinessLogic.contract.Cmr.cn
{
    public interface ISubjectService
    {
        /// <summary>
        /// 分页展示数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        List<Subject> PageList(int pageIndex, int pageSize, out int total);

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResponse<Subject> Insert(Subject model);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResponse<bool> Update(Subject model);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApiResponse<bool> Remove(int id);

        /// <summary>
        /// 返回所有可用的科目
        /// </summary>
        /// <returns></returns>
        ApiResponse<List<Subject>> LoadAllSubjects();
    }
}
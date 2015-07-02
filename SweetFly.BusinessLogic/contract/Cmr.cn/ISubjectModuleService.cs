
using System.Collections.Generic;
using SweetFly.Model.ApiControllers.BaseApiController;
using SweetFly.Model.Entities.Cmr.cn;

namespace SweetFly.BusinessLogic.contract.Cmr.cn
{
    public interface ISubjectModuleService
    {
        /// <summary>
        /// 分页展示数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        List<SubjectModule> PageList(int pageIndex, int pageSize, out int total);

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResponse<SubjectModule> Insert(SubjectModule model);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResponse<bool> Update(SubjectModule model);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApiResponse<bool> Remove(int id);

        /// <summary>
        /// 查询科目下的所有模块
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        ApiResponse<List<SubjectModule>> LoadModulesBySubjectId(int subjectId);
    }
}
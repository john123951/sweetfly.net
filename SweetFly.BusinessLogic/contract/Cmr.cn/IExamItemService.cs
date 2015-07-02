using SweetFly.Model.Entities.Cmr.cn;
using SweetFly.Model.Search;
using System.Collections.Generic;

namespace SweetFly.BusinessLogic.contract.Cmr.cn
{
    public interface IExamItemService
    {
        /// <summary>
        /// 分页展示数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        List<ExamItem> PageList(int pageIndex, int pageSize, out int total);

        /// <summary>
        /// 检查数据库中是否已存在，并保存数据
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        int SaveOrUpdate(IList<ExamItem> entities);

        /// <summary>
        /// 检查是否已经取回题目的答案
        /// </summary>
        /// <param name="id">题目Id</param>
        /// <returns></returns>
        bool CheckExam(int id);

        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ExamItem GetEntityById(int id);

        /// <summary>
        /// 查询多条数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<ExamItem> GetEntitiesByIds(List<int> ids);

        /// <summary>
        /// 题目总数
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        int Count(ExamItemSearch search = null);
    }
}
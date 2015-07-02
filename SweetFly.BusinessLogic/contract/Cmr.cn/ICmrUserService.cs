using SweetFly.Model.ApiControllers.BaseApiController;
using SweetFly.Model.Entities.Cmr.cn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetFly.BusinessLogic.contract.Cmr.cn
{
    public interface ICmrUserService
    {
        /// <summary>
        /// 分页展示数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        List<CmrUser> PageList(int pageIndex, int pageSize, out int total);

        /// <summary>
        /// 插入或更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResponse<bool> SaveOrUpdate(CmrUser model);
    }
}

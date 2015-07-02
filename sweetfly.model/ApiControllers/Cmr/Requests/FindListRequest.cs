using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetFly.Model.ApiControllers.Cmr.Requests
{
    public class FindListRequest
    {
        /// <summary>
        /// 需要查询的Id列表
        /// </summary>
        public List<int> Ids { set; get; }
    }
}

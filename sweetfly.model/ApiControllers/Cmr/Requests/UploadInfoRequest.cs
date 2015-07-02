using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetFly.Model.ApiControllers.Cmr.Requests
{
    /// <summary>
    /// 用户提交的信息
    /// </summary>
    public class UploadInfoRequest
    {
        /// <summary>
        /// Http Authorization 字符串
        /// </summary>
        public string AuthorizationString { get; set; }
    }
}

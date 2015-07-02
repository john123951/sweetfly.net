using System;
using System.Xml.Serialization;
namespace SweetFly.Job.Models.Cmr
{
    [Serializable]
    public class LoginInfo
    {
        /// <summary>
        /// Http请求Authorization值
        /// </summary>
        public string Authorization { get; set; }
    }
}

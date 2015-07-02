using SweetFly.Utility.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetFly.Infrastructure.Configs
{
    public sealed class WebConfig : BaseConfig
    {
        private WebConfig()
        {
        }

        private static WebConfig _instatnce;

        public static WebConfig GetInstance()
        {
            if (_instatnce == null)
            {
                _instatnce = new WebConfig();
            }
            return _instatnce;
        }

        /// <summary>
        /// 私钥文件位置
        /// </summary>
        public string RSAPrivateKeyFile { get; set; }
    }
}
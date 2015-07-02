using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCommon.Extentions
{
    public static class DateTimeExtention
    {
        /// <summary>
        /// 将Unix时间戳（格林威治时间）转换为DateTime类型
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime Parse(long timestamp)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime time = startTime.AddSeconds(timestamp);
            return time;
        }
    }
}

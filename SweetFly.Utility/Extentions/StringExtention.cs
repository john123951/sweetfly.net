using System.Text.RegularExpressions;
namespace SweetFly.Utility.Extentions
{
    /// <summary>
    /// 字符串类型扩展方法类
    /// </summary>
    public static class StringExtention
    {
        /// <summary>
        /// 移除字符串中的Html标签
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string RemoveHtml(this string src)
        {
            if (string.IsNullOrEmpty(src)) { return string.Empty; }

            string rx = @"<.*? />|<.*?>";       //      <(\S*?)[^>]*>.*?</\1>|<.*? />|<.*?>
            var result = Regex.Replace(src, rx, string.Empty, RegexOptions.IgnoreCase);
            return result;
        }

        /// <summary>
        /// 移除字符串中的Html编码字符
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string RemoveHtmlEncode(this string src)
        {
            if (string.IsNullOrEmpty(src)) { return string.Empty; }

            return src.Replace("&nbsp;", string.Empty);
        }

    }
}

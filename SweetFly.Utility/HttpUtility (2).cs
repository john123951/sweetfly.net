using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.IO;

namespace SweetFly.Utility
{
    /// <summary>
    /// Http通用类
    /// </summary>
    public static class HttpUtility
    {

        #region 公有方法
        /// <summary>
        /// 发送一个HttpPost请求
        /// </summary>
        /// <param name="address">远程地址</param>
        /// <param name="data">需要发送的数据</param>
        /// <returns></returns>
        public static string Post(string address, string data)
        {
            return Post(address, data, Encoding.UTF8);
        }

        /// <summary>
        /// 发送一个HttpPost请求
        /// </summary>
        /// <param name="address">远程地址</param>
        /// <param name="data">需要发送的数据</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static string Post(string address, string data, Encoding encoding)
        {
            var request = WebRequest.Create(address) as HttpWebRequest;
            Debug.Assert(request != null, "request != null");

            PackRequest(data, encoding, request);

            return PostRequest(request, encoding);
        }


        /// <summary>
        /// 发送一个HttpGet请求
        /// </summary>
        /// <param name="address"></param>
        /// <param name="modify"></param>
        /// <returns></returns>
        public static string Get(string address, Action<HttpWebRequest> modify = null)
        {
            return Get(address, modify, Encoding.UTF8);
        }

        /// <summary>
        /// 发送一个HttpGet请求
        /// </summary>
        /// <param name="address">远程地址</param>
        /// <param name="modify">供修改的回调函数</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string Get(string address, Action<HttpWebRequest> modify, Encoding encoding)
        {
            var request = WebRequest.Create(address) as HttpWebRequest;
            Debug.Assert(request != null, "request != null");

            request.Method = "GET";
            request.ContentType = "application/json;charset=UTF-8";
            request.Accept = "application/json";

            if (modify != null)
            {
                modify(request);
            }

            return PostRequest(request, encoding);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 包装Http Request
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <param name="request"></param>
        private static void PackRequest(string data, Encoding encoding, HttpWebRequest request)
        {
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            request.Accept = "application/json";

            byte[] byteArray = encoding.GetBytes(data);
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
        }

        /// <summary>
        /// 发送Http请求
        /// </summary>
        /// <param name="request">需要发送的请求</param>
        /// <returns></returns>
        private static string PostRequest(HttpWebRequest request)
        {
            return PostRequest(request, Encoding.UTF8);
        }

        private static string PostRequest(HttpWebRequest request, Encoding encoding)
        {
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, encoding))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
        #endregion

    }
}

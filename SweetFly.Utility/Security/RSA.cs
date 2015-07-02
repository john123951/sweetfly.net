using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace SweetFly.Utility.Security
{
    /// <summary>
    /// 非对称RSA
    /// </summary>
    public class RSA : IDisposable
    {
        private RSACryptoServiceProvider rsa;

        /// <summary>
        /// 初始化实例
        /// </summary>
        public RSA()
        {
            rsa = new RSACryptoServiceProvider();
        }

        /// <summary>
        /// 得到公钥
        /// </summary>
        /// <returns></returns>
        public string GetPublicKey()
        {
            return rsa.ToXmlString(false);
        }

        /// <summary>
        /// 得到私钥
        /// </summary>
        /// <returns></returns>
        public string GetPrivateKey()
        {
            return rsa.ToXmlString(true);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Source">待加密字符串</param>
        /// <param name="PublicKey">公钥</param>
        /// <returns></returns>
        public string Encrypt(string Source, string PublicKey)
        {
            string base64Encode = Base64Encrypt.EncryptString(Source);
            rsa.FromXmlString(PublicKey);
            byte[] done = rsa.Encrypt(Convert.FromBase64String(base64Encode), false);
            return Convert.ToBase64String(done);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Source">待加密字符数组</param>
        /// <param name="PublicKey">公钥</param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] Source, string PublicKey)
        {
            rsa.FromXmlString(PublicKey);
            return rsa.Encrypt(Source, false);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="inFileName">待加密文件路径</param>
        /// <param name="outFileName">加密后文件路径</param>
        /// <param name="PublicKey">公钥</param>
        public void Encrypt(string inFileName, string outFileName, string PublicKey)
        {
            rsa.FromXmlString(PublicKey);
            using (FileStream fin = new FileStream(inFileName, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fout = new FileStream(outFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fout.SetLength(0);

                    byte[] bin = new byte[1000];
                    long rdlen = 0;
                    long totlen = fin.Length;
                    int len;

                    while (rdlen < totlen)
                    {
                        len = fin.Read(bin, 0, 1000);
                        byte[] bout = rsa.Encrypt(bin, false);
                        fout.Write(bout, 0, bout.Length);
                        rdlen = rdlen + len;
                    }
                }
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Source">待解密字符串</param>
        /// <param name="PrivateKey">私钥</param>
        /// <returns></returns>
        public string Decrypt(string Source, string PrivateKey)
        {
            rsa.FromXmlString(PrivateKey);
            byte[] done = rsa.Decrypt(Convert.FromBase64String(Source), false);
            string base64Decode = Base64Encrypt.DecryptString(Convert.ToBase64String(done));
            return base64Decode;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Source">待解密字符数组</param>
        /// <param name="PrivateKey">私钥</param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] Source, string PrivateKey)
        {
            rsa.FromXmlString(PrivateKey);
            return rsa.Decrypt(Source, false);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="inFileName">待解密文件路径</param>
        /// <param name="outFileName">解密后文件路径</param>
        /// <param name="PrivateKey">私钥</param>
        public void Decrypt(string inFileName, string outFileName, string PrivateKey)
        {
            rsa.FromXmlString(PrivateKey);
            using (FileStream fin = new FileStream(inFileName, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fout = new FileStream(outFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fout.SetLength(0);

                    byte[] bin = new byte[1000];
                    long rdlen = 0;
                    long totlen = fin.Length;
                    int len;

                    while (rdlen < totlen)
                    {
                        len = fin.Read(bin, 0, 1000);
                        byte[] bout = rsa.Decrypt(bin, false);
                        fout.Write(bout, 0, bout.Length);
                        rdlen = rdlen + len;
                    }
                }
            }
        }

        #region IDisposable 成员

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            rsa.Clear();
        }

        #endregion IDisposable 成员
    }
}
using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;

namespace SweetFly.Utility.Security
{
    /// <summary>
    /// Base64 UUEncoded 编码
    /// 将二进制编码为ASCII文本，用于网络传输
    /// (可还原)
    /// </summary>
    public class Base64Encrypt
    {
        /// <summary>
        /// 解码字符串
        /// </summary>
        /// <param name="inputString">输入文本</param>
        /// <returns></returns>
        public static string DecryptString(string inputString)
        {
            return DecryptString(inputString, System.Text.Encoding.Default);
        }

        /// <summary>
        /// 解码字符串
        /// </summary>
        /// <param name="inputString">输入文本</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public static string DecryptString(string inputString, System.Text.Encoding encoding)
        {
            char[] sInput = inputString.ToCharArray();
            try
            {
                byte[] bOutput = System.Convert.FromBase64String(inputString);
                return encoding.GetString(bOutput);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 编码字符串
        /// </summary>
        /// <param name="inputString">输入文本</param>
        /// <returns></returns>
        public static string EncryptString(string inputString)
        {
            return EncryptString(inputString, System.Text.Encoding.Default);
        }

        /// <summary>
        /// 编码字符串
        /// </summary>
        /// <param name="inputString">输入文本</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public static string EncryptString(string inputString, System.Text.Encoding encoding)
        {
            byte[] bInput = encoding.GetBytes(inputString);
            try
            {
                return System.Convert.ToBase64String(bInput, 0, bInput.Length);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 解码文件
        /// </summary>
        /// <param name="inputFilename">输入文件</param>
        /// <param name="outputFilename">输出文件</param>
        public static void DecryptFile(string inputFilename, string outputFilename)
        {
            DecryptFile(inputFilename, outputFilename, System.Text.Encoding.ASCII);
        }


        /// <summary>
        /// 解码文件
        /// </summary>
        /// <param name="inputFilename">输入文件</param>
        /// <param name="outputFilename">输出文件</param>
        /// <param name="encoding">字符编码</param>
        public static void DecryptFile(string inputFilename, string outputFilename,System.Text.Encoding encoding)
        {
            char[] base64CharArray;
            try
            {
                using (System.IO.StreamReader inFile = new System.IO.StreamReader(inputFilename, encoding))
                {
                    base64CharArray = new char[inFile.BaseStream.Length];
                    inFile.Read(base64CharArray, 0, (int)inFile.BaseStream.Length);
                }
            }
            catch
            {
                throw;
            }

            // 转换Base64 UUEncoded为二进制输出
            byte[] binaryData;
            try
            {
                binaryData = System.Convert.FromBase64CharArray(base64CharArray, 0, base64CharArray.Length);
            }
            catch
            {
                throw;
            }

            // 写输出数据
            try
            {
                using (System.IO.FileStream outFile = new System.IO.FileStream(outputFilename, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    outFile.Write(binaryData, 0, binaryData.Length);
                }
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// 编码文件
        /// </summary>
        /// <param name="inputFilename">输入文件</param>
        /// <param name="outputFilename">输出文件</param>
        /// <param name="encoding">字符编码</param>
        public static void EncryptFile(string inputFilename, string outputFilename, System.Text.Encoding encoding)
        {
            byte[] binaryData;
            try
            {
                using (System.IO.FileStream inFile = new System.IO.FileStream(inputFilename, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    binaryData = new Byte[inFile.Length];
                    long bytesRead = inFile.Read(binaryData, 0, (int)inFile.Length);
                }
            }
            catch
            {
                throw;
            }

            // 转换二进制输入为Base64 UUEncoded输出
            // 每3个字节在源数据里作为4个字节 
            long arrayLength = (long)((4.0d / 3.0d) * binaryData.Length);

            // 如果无法整除4
            if (arrayLength % 4 != 0)
            {
                arrayLength += 4 - arrayLength % 4;
            }

            char[] base64CharArray = new char[arrayLength];
            try
            {
                System.Convert.ToBase64CharArray(binaryData, 0, binaryData.Length, base64CharArray, 0);
            }
            catch
            {
                throw;
            }
            // 写UUEncoded数据到文件内
            try
            {
                using (System.IO.StreamWriter outFile = new System.IO.StreamWriter(outputFilename, false, encoding))
                {
                    outFile.Write(base64CharArray);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

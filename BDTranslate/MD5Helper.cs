using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BDTranslateAPI
{
    class MD5Helper
    {
        // 首先初始化一个字符数组，用来存放每个16进制字符
        private static readonly char[] hexDigits = 
            { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

        /// <summary>
        /// 获得一个字符串的MD5值
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <returns>输入字符串的MD5值</returns>
        public static string GetMD5(string input)
        {
            if (input == null)
                return null;
            try
            {
                // 拿到一个MD5转换器（如果想要SHA1参数换成”SHA1”）
                MD5 md5 = new MD5CryptoServiceProvider();
                // 输入的字符串转换成字节数组inputByteArray
                byte[] inputByteArray = Encoding.UTF8.GetBytes(input);
                byte[] resultByteArray = md5.ComputeHash(inputByteArray);
                return byteArrayToHex(resultByteArray);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        private static String byteArrayToHex(byte[] byteArray)
        {
            // new一个字符数组，这个就是用来组成结果字符串的（解释一下：一个byte是八位二进制，也就是2位十六进制字符（2的8次方等于16的2次方））
            char[] resultCharArray = new char[byteArray.Length * 2];
            // 遍历字节数组，通过位运算（位运算效率高），转换成字符放到字符数组中去
            int index = 0;
            foreach (char b in byteArray)
            {
                resultCharArray[index++] = hexDigits[b >> 4 & 0xf];
                resultCharArray[index++] = hexDigits[b & 0xf];
            }

            // 字符数组组合成字符串返回
            return new String(resultCharArray);
        }

    }
}

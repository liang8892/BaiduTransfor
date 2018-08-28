using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace BaiduTransfor
{

    /// <summary>
    /// MD5编码相关的类
    /// 
    /// @author wangjingtao
    /// 
    /// </summary>
    public class MD5
    {
        // 首先初始化一个字符数组，用来存放每个16进制字符
        private static readonly char[] hexDigits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

        /// <summary>
        /// 获得一个字符串的MD5值
        /// </summary>
        /// <param name="input"> 输入的字符串 </param>
        /// <returns> 输入字符串的MD5值
        ///  </returns>
        public static string md5(string input)
        {
            if (string.ReferenceEquals(input, null))
            {
                return null;
            }

            try
            {
                // 拿到一个MD5转换器（如果想要SHA1参数换成"SHA1"）
                System.Security.Cryptography.MD5 md = System.Security.Cryptography.MD5.Create("MD5");
                // 输入的字符串转换成字节数组
                // inputByteArray是输入字符串转换得到的字节数组
                byte[] inputByteArray = null;
                byte[] resultByteArray = null;
                try
                {
                    inputByteArray = Encoding.UTF8.GetBytes(input);
                    resultByteArray = md.ComputeHash(inputByteArray);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                // 字符数组转换成字符串返回
                return byteArrayToHex(resultByteArray);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        ///// <summary>
        ///// 获取文件的MD5值
        ///// </summary>
        ///// <param name="file">
        ///// @return </param>
        //public static string md5(File file)
        //{
        //    try
        //    {
        //        if (!File.Exists(file))
        //        {
        //            Console.Error.WriteLine("文件" + file + "不存在或者不是文件");
        //            return null;
        //        }

        //        System.IO.FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);

        //        string result = md5(stream);

        //        stream.Close();

        //        return result;

        //    }
        //    catch (FileNotFoundException e)
        //    {
        //        Console.WriteLine(e.ToString());
        //        Console.Write(e.StackTrace);
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine(e.ToString());
        //        Console.Write(e.StackTrace);
        //    }

        //    return null;
        //}

        //public static string md5(System.IO.Stream @in)
        //{

        //    try
        //    {
        //        MessageDigest messagedigest = MessageDigest.getInstance("MD5");

        //        byte[] buffer = new byte[1024];
        //        int read = 0;
        //        while ((read = @in.Read(buffer, 0, buffer.Length)) != -1)
        //        {
        //            messagedigest.update(buffer, 0, read);
        //        }

        //        @in.Close();

        //        string result = byteArrayToHex(messagedigest.digest());

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.ToString());
        //    }
            
        //    return null;
        //}

        private static string byteArrayToHex(byte[] byteArray)
        {
            // new一个字符数组，这个就是用来组成结果字符串的（解释一下：一个byte是八位二进制，也就是2位十六进制字符（2的8次方等于16的2次方））
            char[] resultCharArray = new char[byteArray.Length * 2];
            // 遍历字节数组，通过位运算（位运算效率高），转换成字符放到字符数组中去
            int index = 0;
            foreach (byte b in byteArray)
            {
                resultCharArray[index++] = hexDigits[(int)((uint)b >> 4) & 0xf];
                resultCharArray[index++] = hexDigits[b & 0xf];
            }

            // 字符数组组合成字符串返回
            return new string(resultCharArray);

        }

    }

}
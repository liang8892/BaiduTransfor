using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace com.baidu.translate.demo
{


    internal class HttpGet
    {
        protected internal const int SOCKET_TIMEOUT = 10000; // 10S
        protected internal const string GET = "GET";

        public static string get(string host, IDictionary<string, string> @params)
        {
            try
            {
                // 设置SSLContext
                SSLContext sslcontext = SSLContext.getInstance("TLS");
                sslcontext.init(null, new TrustManager[] { myX509TrustManager }, null);

                string sendUrl = getUrlWithQueryString(host, @params);

                // System.out.println("URL:" + sendUrl);

                URL uri = new URL(sendUrl); // 创建URL对象
                HttpURLConnection conn = (HttpURLConnection)uri.openConnection();
                if (conn is HttpsURLConnection)
                {
                    ((HttpsURLConnection)conn).SSLSocketFactory = sslcontext.SocketFactory;
                }

                conn.ConnectTimeout = SOCKET_TIMEOUT; // 设置相应超时
                conn.RequestMethod = GET;
                int statusCode = conn.ResponseCode;
                if (statusCode != HttpURLConnection.HTTP_OK)
                {
                    Console.WriteLine("Http错误码：" + statusCode);
                }

                // 读取服务器的数据
                System.IO.Stream @is = conn.InputStream;
                System.IO.StreamReader br = new System.IO.StreamReader(@is);
                StringBuilder builder = new StringBuilder();
                string line = null;
                while (!string.ReferenceEquals((line = br.ReadLine()), null))
                {
                    builder.Append(line);
                }

                string text = builder.ToString();

                close(br); // 关闭数据流
                close(@is); // 关闭数据流
                conn.disconnect(); // 断开连接

                return text;
            }
            catch (MalformedURLException e)
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
            }
            catch (KeyManagementException e)
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
            }
            catch (NoSuchAlgorithmException e)
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
            }

            return null;
        }

        public static string getUrlWithQueryString(string url, IDictionary<string, string> @params)
        {
            if (@params == null)
            {
                return url;
            }

            StringBuilder builder = new StringBuilder(url);
            if (url.Contains("?"))
            {
                builder.Append("&");
            }
            else
            {
                builder.Append("?");
            }

            int i = 0;
            foreach (string key in @params.Keys)
            {
                string value = @params[key];
                if (string.ReferenceEquals(value, null))
                { // 过滤空的key
                    continue;
                }

                if (i != 0)
                {
                    builder.Append('&');
                }

                builder.Append(key);
                builder.Append('=');
                builder.Append(encode(value));

                i++;
            }

            return builder.ToString();
        }

        protected internal static void close(System.IDisposable closeable)
        {
            if (closeable != null)
            {
                try
                {
                    closeable.Dispose();
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.ToString());
                    Console.Write(e.StackTrace);
                }
            }
        }

        /// <summary>
        /// 对输入的字符串进行URL编码, 即转换为%20这种形式
        /// </summary>
        /// <param name="input"> 原文 </param>
        /// <returns> URL编码. 如果编码失败, 则返回原文 </returns>
        public static string encode(string input)
        {
            if (string.ReferenceEquals(input, null))
            {
                return "";
            }

            try
            {
                return URLEncoder.encode(input, "utf-8");
            }
            catch (UnsupportedEncodingException e)
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
            }

            return input;
        }

        private static TrustManager myX509TrustManager = new X509TrustManagerAnonymousInnerClass();

        private class X509TrustManagerAnonymousInnerClass : X509TrustManager
        {
            public X509TrustManagerAnonymousInnerClass()
            {
            }


            public override X509Certificate[] AcceptedIssuers
            {
                get
                {
                    return null;
                }
            }

            //JAVA TO C# CONVERTER CRACKED BY X-CRACKER WARNING: Method 'throws' clauses are not available in .NET:
            //ORIGINAL LINE: @Override public void checkServerTrusted(java.security.cert.X509Certificate[] chain, String authType) throws java.security.cert.CertificateException
            public override void checkServerTrusted(X509Certificate[] chain, string authType)
            {
            }

            //JAVA TO C# CONVERTER CRACKED BY X-CRACKER WARNING: Method 'throws' clauses are not available in .NET:
            //ORIGINAL LINE: @Override public void checkClientTrusted(java.security.cert.X509Certificate[] chain, String authType) throws java.security.cert.CertificateException
            public override void checkClientTrusted(X509Certificate[] chain, string authType)
            {
            }
        }

    }

}

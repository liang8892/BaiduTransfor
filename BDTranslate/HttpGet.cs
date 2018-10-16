using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;

namespace BDTranslateAPI
{
    public class HttpGet
    {
        protected static readonly int SOCKET_TIMEOUT = 10000;
        protected static readonly string GET = "GET";

        public static string Get(string host, Dictionary<string, string> param)
        {
            try
            {
                string uri = BuildURL(param, host);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Timeout = SOCKET_TIMEOUT;
                //request.Method = GET;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return null;
        }


        private static string BuildURL(Dictionary<string,string> param, string host)
        {
            if (param == null)
                return null;
            StringBuilder buider = new StringBuilder();
            buider.Append(host);
            buider.Append("?");

            int i = 0;
            foreach (KeyValuePair<string, string> keyValuePair in param)
            {
                if (keyValuePair.Value == "")
                    return null;
                if (i != 0)
                    buider.Append("&");
                
                buider.Append(keyValuePair.Key);
                buider.Append("=");
                buider.Append(keyValuePair.Value);
                i++;
            }

            return buider.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

namespace BDTranslateAPI
{
    public class TransAPI
    {
        private static readonly string TRANS_API_HOST = "http://api.fanyi.baidu.com/api/trans/vip/translate";
        private string appid;
        private string securityKey;

        public TransAPI(string appid, string securityKey)
        {
            this.appid = appid;
            this.securityKey = securityKey;
        }

        public string GetTransResult(string query, string from, string to)
        {
            Dictionary<string, string> param = BuildParam(query, from, to);
            //string response = HttpGet.Get(TRANS_API_HOST, param);
            //JObject jObject = (JObject) JsonConvert.DeserializeObject(response);
            //jObject = (JObject)JsonConvert.DeserializeObject(
            //    jObject["trans_result"].ToString().TrimStart('[').TrimEnd(']'));

            //return new Regex(@"\\u([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(
            //    jObject["dst"].ToString(), x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));

            return HttpGet.Get(TRANS_API_HOST, param);
        }

        private Dictionary<string, string> BuildParam(string query, string from, string to)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("q", query);
            param.Add("from", from);
            param.Add("to", to);
            param.Add("appid", appid);

            //随机数
            string salt = DateTimeHelper.CurrentUnixTimeMillis().ToString();
            param.Add("salt", salt);

            // 签名
            string src = appid + query + salt + securityKey; // 加密前的原文
            param.Add("sign", MD5Helper.GetMD5(src));

            return param;
        }


        //---------------------------------------------------------------------------------------------------------
        //	Copyright © 2007 - 2018 Tangible Software Solutions, Inc.
        //	This class can be used by anyone provided that the copyright notice remains intact.
        //
        //	This class is used to replace calls to Java's System.currentTimeMillis with the C# equivalent.
        //	Unix time is defined as the number of seconds that have elapsed since midnight UTC, 1 January 1970.
        //---------------------------------------------------------------------------------------------------------
        internal static class DateTimeHelper
        {
            private static readonly System.DateTime Jan1st1970 = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            public static long CurrentUnixTimeMillis()
            {
                return (long)(System.DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
            }
        }


    }
}

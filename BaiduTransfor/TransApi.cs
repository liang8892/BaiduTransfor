using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduTransfor
{
    class TransApi
    {
        private static readonly String TRANS_API_HOST = "http://api.fanyi.baidu.com/api/trans/vip/translate";

        private String appid;
        private String securityKey;

        public TransApi(String appid, String securityKey)
        {
            this.appid = appid;
            this.securityKey = securityKey;
        }

        public String getTransResult(String query, String from, String to)
        {
            Dictionary<String, String> paras = buildParams(query, from, to);
            return HttpGet.get(TRANS_API_HOST, paras);
        }

        private Dictionary<String, String> buildParams(String query, String from, String to)
        {
            Dictionary< String, String > paras = new Dictionary<String, String>();
            paras.Add("q", query);
            paras.Add("from", from);
            paras.Add("to", to);

            paras.Add("appid", appid);

            // 随机数
            string salt = DateTime.Now.Millisecond.ToString();
            paras.Add("salt", salt);

            // 签名
            String src = appid + query + salt + securityKey; // 加密前的原文
                paras.Add("sign", MD5.md5(src));

            return paras;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOP.Applications.TaobaoShopHelper.技术支持
{
    public class 请求服务器
    {
        public ResultObject RequestTOPResult(string method, Dictionary<string, string> q, Dictionary<string, FileInfo> files)
        {
            string responseBody = RequestTOP(method, q, files);
            return AnalyseDataItem<ResultObject>(responseBody);
        }

        private string RequestTOP(string method, Dictionary<string, string> q)
        {
            Dictionary<string, string> req_params = GetParams(method, q, null);
            //调用API
            TaobaoClient client = new TaobaoClient();
            return client.InvokeAPI(req_params);
        }

        private Dictionary<string, string> GetParams(string method, Dictionary<string, string> q, Type objType)
        {
            Dictionary<string, string> req_params = new Dictionary<string, string>();

            foreach (string key in q.Keys)
            {
                if (!string.IsNullOrEmpty(q[key]))
                {
                    req_params.Add(key, q[key]);
                }
            }
            if (objType != null)
            {
                //返回字段列表
                req_params.Add("fields", helper.GetDataObjFieldsString(objType));
            }
            //系统级输入参数 //api_key
            req_params.Add("api_key", currentAppKey);
            //返回格式
            req_params.Add("format", "xml");
            //api方法名
            req_params.Add("method", method);
            //时间戳
            req_params.Add("timestamp", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            //版本
            req_params.Add("v", currentVersion);
            //应用级输入参数
            //sign，生成签名字符串
            string sign = EncryptUtil.Signature(req_params, currentAppSecret, "sign");
            req_params.Add("sign", sign);

            return req_params;
        }
    }
}

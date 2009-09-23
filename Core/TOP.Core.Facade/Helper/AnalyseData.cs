using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;
using System.Xml;
using System.IO;

namespace TOP.Core.Facade
{
    public class AnalyseData
    {
        private AttributeHelper helper = new AttributeHelper();
        private string currentAppKey, currentAppSecret, currentVersion;

        public AnalyseData(string appKey, string appSecret) : this(appKey, appSecret, "1.0") { }

        public AnalyseData(string appKey, string appSecret, string version)
        {
            currentAppKey = appKey;
            currentAppSecret = appSecret;
            currentVersion = version;
        }

        public TOPDataList<T> AnalyseDataList<T>(string responseXml)
            where T : TOPDataItem, new()
        {
            TOPDataList<T> list = new TOPDataList<T>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseXml);
            XmlElement element = doc.DocumentElement;
            if (element.Name.Equals("rsp", StringComparison.OrdinalIgnoreCase))
            {
                list.AnalyseXML(element.OuterXml);

                return list;
            }
            else if (element.Name.Equals("error_rsp", StringComparison.OrdinalIgnoreCase))
            {
                throw new ResponseException(element.OuterXml, "服务器返回错误响应消息");
            }
            else
            {
                throw new Exception(string.Format("无法解析服务器返回XML格式 - \"{0}\"", element.Name));
            }
        }

        public T AnalyseDataItem<T>(string responseXml)
            where T : TOPDataItem, new()
        {
            T t = new T();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseXml);
            XmlElement element = doc.DocumentElement;
            if (element.Name.Equals("rsp", StringComparison.OrdinalIgnoreCase))
            {
                t.AnalyseXML(element.InnerXml);

                return t;
            }
            else if (element.Name.Equals("error_rsp", StringComparison.OrdinalIgnoreCase))
            {
                throw new ResponseException(element.OuterXml, "服务器返回错误响应消息");
            }
            else
            {
                throw new Exception(string.Format("无法解析服务器返回XML格式 - \"{0}\"", element.Name));
            }
        }

        public TOPDataList<T> RequestTOPDataList<T>(string method, Dictionary<string, string> q)
            where T : TOPDataItem, new()
        {
            string responseBody = RequestTOP<T>(method, q);
            return AnalyseDataList<T>(responseBody);
        }

        public T RequestTOPDataItem<T>(string method, Dictionary<string, string> q)
            where T : TOPDataItem, new()
        {
            string responseBody = RequestTOP<T>(method, q);
            return AnalyseDataItem<T>(responseBody);
        }

        public ResultObject RequestTOPResult(string method, Dictionary<string, string> q)
        {
            string responseBody = RequestTOP(method, q);
            return AnalyseDataItem<ResultObject>(responseBody);
        }

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

        private string RequestTOP(string method, Dictionary<string, string> q, Dictionary<string, FileInfo> files)
        {
            Dictionary<string, string> req_params = GetParams(method, q, null);
            //调用API
            TaobaoClient client = new TaobaoClient();
            return client.InvokeAPI(req_params, files);
        }

        private string RequestTOP<T>(string method, Dictionary<string, string> q)
        {
            Dictionary<string, string> req_params = GetParams(method, q, typeof(T));
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

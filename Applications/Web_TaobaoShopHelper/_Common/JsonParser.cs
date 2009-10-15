using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TOP.Applications.TaobaoShopHelper._Common
{
    public abstract class JsonObject
    {
    }

    public class JsonObjectList<T> : List<T>
        where T : JsonObject, new()
    {
        public int TotalCount { get; set; }
    }

    public class JsonParser
    {
        /// <summary>
        /// 解释JSON响应为相应的领域对象列表。
        /// </summary>
        /// <param name="property">JSON属性名称</param>
        /// <param name="body">JSON响应字符串</param>
        /// <returns>领域对象列表</returns>
        public static JsonObjectList<T> ParseJsonResponse<T>(string body)
            where T : JsonObject, new()
        {
            JsonObjectList<T> rspList = new JsonObjectList<T>();

            JObject jsonBody = JObject.Parse(body);
            JArray jsonRsp = jsonBody["Detail"] as JArray;
            rspList.TotalCount = jsonBody.Value<int>("Number");

            if (jsonRsp != null)
            {
                for (int i = 0; i < jsonRsp.Count; i++)
                {
                    JsonSerializer js = new JsonSerializer();
                    object obj = js.Deserialize(jsonRsp[i].CreateReader(), typeof(T));
                    rspList.Add((T)obj);
                }
            }

            return rspList;
        }
    }

    public class JsonItem : JsonObject
    {
        public string Id { get; set; }

        public string Nick { get; set; }

        public string Title { get; set; }

        public string DetailUrl { get; set; }

        public string ImageUrl { get; set; }

        public string Price { get; set; }

        public string ToJsonString()
        {
            return JObject.FromObject(this).ToString();
        }
    }
}

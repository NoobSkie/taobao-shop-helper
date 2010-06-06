using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Common.Xml;

namespace J.SLS.Facade
{
    public class HPCommunicationFacade
    {
        //public T AnalyzeHPObject<T>(string xml)
        //    where T : CommunicationObject, new()
        //{
        //    try
        //    {
        //        T t = new T();
        //        t.
        //        Dictionary<string, string> parameters = XmlAnalyzer.GetParameters(response);
        //        TranType type = (TranType)Enum.Parse(typeof(TranType), parameters["transType"]);
        //        switch (type)
        //        {
        //            case TranType.IssueNotifyRequest:  // 奖期通知请求
        //                AddIssuseNotify(parameters["transMessage"]);
        //                break;
        //            default:
        //                throw new ArgumentOutOfRangeException("不支持的通知类型 - " + type);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string errMsg = "处理通知失败！" + response;
        //        throw HandleException(LogCategory.Notice, errMsg, ex);
        //    }
        //}
    }
}

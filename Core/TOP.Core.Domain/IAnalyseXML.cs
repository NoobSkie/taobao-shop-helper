using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Core.Domain
{
    /// <summary>
    /// 可以解析XML文本的对象
    /// </summary>
    public interface IAnalyseXML
    {
        /// <summary>
        /// 获取原始XML文本
        /// </summary>
        string OrginXml { get; }
        /// <summary>
        /// 解析XML文本
        /// </summary>
        /// <param name="xml">被解析的XML文本</param>
        void AnalyseXML(string xml);
        /// <summary>
        /// 解析XML的状态
        /// </summary>
        XmlAnalyseState AnalyseState { get; set; }
    }

    /// <summary>
    /// XML文本解析状态
    /// </summary>
    public enum XmlAnalyseState
    {
        /// <summary>
        /// 等待解析
        /// </summary>
        Pending = 0,
        /// <summary>
        /// 解析中
        /// </summary>
        Analysing = 1,
        /// <summary>
        /// 成功
        /// </summary>
        Success = 2,
        /// <summary>
        /// 失败
        /// </summary>
        Fail = 4,
        /// <summary>
        /// 出错
        /// </summary>
        Error = 8,
    }
}

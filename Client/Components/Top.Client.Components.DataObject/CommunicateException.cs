using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Runtime.Serialization;

namespace Top.Client.Components.DataObject
{
    /// <summary>
    /// 通信过程发生的异常
    /// </summary>
    [DataContract]
    public class CommunicateException
    {
        // Fields
        private string _ClassFullName;
        private string _CustomErrorCode;
        private string[] _Parameters;

        // Methods
        public CommunicateException(string classFullName, string errorCode)
        {
            this._ClassFullName = classFullName;
            this._CustomErrorCode = errorCode;
        }

        public CommunicateException(string classFullName, string errorCode, params string[] parameters)
        {
            this._ClassFullName = classFullName;
            this._CustomErrorCode = errorCode;
            this._Parameters = parameters;
        }

        ~CommunicateException()
        {
        }

        // Properties
        [DataMember]
        public string ClassFullName
        {
            get
            {
                return this._ClassFullName;
            }
            set
            {
                this._ClassFullName = value;
            }
        }

        [DataMember]
        public string CustomErrorCode
        {
            get
            {
                return this._CustomErrorCode;
            }
            set
            {
                this._CustomErrorCode = value;
            }
        }

        [DataMember]
        public string[] Parameters
        {
            get
            {
                return this._Parameters;
            }
            set
            {
                this._Parameters = value;
            }
        }
    }
}

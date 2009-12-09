using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Top.Server.Wcf.Contract.TaobaoInterface
{
    [DataContract]
    public abstract class ApiBaseInfo
    {
        /// <summary>
        /// 对象创建时间（格式：yyyy-MM-dd HH:mm:ss）
        /// </summary>
        [DataMember]
        public string Created { get; set; }

        /// <summary>
        /// 对象修改时间（格式：yyyy-MM-dd HH:mm:ss）
        /// </summary>
        [DataMember]
        public string Modified { get; set; }
    }
}

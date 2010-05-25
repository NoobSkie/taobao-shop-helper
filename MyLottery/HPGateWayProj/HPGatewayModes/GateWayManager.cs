using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 恒朋各网关地址
    /// </summary>
    public class GateWayManager
    {
        /// <summary>
        /// 投注/查询接口
        /// </summary>
        public const string HPIssueQuery_GateWay = "http://szhelper.gicp.net:800/AgentPortalSh/common/HttpInterFaceServlet";
        /// <summary>
        ///  提款接口
        /// </summary>
        public const string HPDistill_GateWay = "http://szhelper.gicp.net:800/AgentPortalSh/common/HttpInterFaceServlet";
        /// <summary>
        /// 充值接口
        /// </summary>
        public const string HPAddBalance_GateWay = "http://szhelper.gicp.net:800/AgentPortalSh/common/HttpInterFaceServlet";
        /// <summary>
        /// 票验证接口
        /// </summary>
        public const string HPTicketVerification_GateWay = "http://szhelper.gicp.net:800/AgentPortalSh/common/HttpInterFaceServlet";
    }
}

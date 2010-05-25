using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHPGateway;
using HPGatewayModels;

namespace HPGatewayRealization
{
    /// <summary>
    /// 恒朋，投注/查询接口
    /// </summary>
    public class IssueQueryGateway:IIssueQueryGateway
    {
        public string GatewayUrl
        {
            get { return GateWayManager.HPIssueQuery_GateWay; }
        }


        //恒朋投注系统向本地系统发送的“奖期通知”
        //    1）用奖期查询，来代替。改变本地系统奖期状态，可能需要轮讯
        //恒朋投注系统向本地系统发送的“返奖通知”

        //暂时不考虑

        /// <summary>
        /// 发送响应信息到恒朋电话投注系统
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型 </param>
        /// <param name="messageID">消息ID</param>
        /// <param name="resStatus">返回恒朋系统的响应状态</param>
        public void ResponseNotice(AccountNumber accountNo, TransactionType transType, string messageID, ResponseStatus resStatus)
        {
            DateTime now = DateTime.Now;
            string body = "<body><response code=\"" + resStatus.StatusCode + "\" message=\"" + resStatus.Description + "\"/></body>";
            string timestamp = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
            string message = "<?xml version=\"1.0\" encoding=\"GBK\"?>";
            message = (((((((message + "<message version=\"1.0\" id=\"" + messageID + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>" + transType.TypeCode + "</transactionType>") + "<digest>" + PostManager.MD5(messageID + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>";
            PostManager.Post(GatewayUrl, "transType=" + transType.TypeCode + "&transMessage=" + message, 90);
        }


        ///<summary>
        /// 奖期查询
        /// transType=102
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型编号，如：102</param>
        /// <param name="issue">奖期信息</param>
        /// 奖期内容：
        ///          PlayMethodInfo.GameName   玩法的编号，如：ssq
        ///          Number                    奖期编号。如2007323表示2007年第323期.如果不指定，则获取当前奖期信息。
        /// <returns></returns>
        public string IssueQuery(AccountNumber accountNo, TransactionType transType, Issue issue)
        {
            if (transType.TypeCode.Trim() != "102")
            {
                throw new Exception("奖期查询请求对应的交易类型错误。");
            }

            if (issue != null && issue.PlayMethodInfo != null)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    string body = "<body><issueQuery><issue gameName=\"" + issue.PlayMethodInfo.GameName + "\" number=\"" + issue.Number + "\"/></issueQuery></body>";
                    string messageId = accountNo.UserName + now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                    string timestamp = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                    string requestMessage = "transType=" + transType.TypeCode + "&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>" + transType.TypeCode + "</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>");

                    Console.WriteLine("奖期查询传递的消息为：");
                    Console.WriteLine(requestMessage);

                    string responseMessage = PostManager.Post(GatewayUrl, requestMessage, 120);
                    return responseMessage;
                }
                catch (Exception ex)
                {   
                    throw ex;
                }
            }
            else
                throw new Exception("要查询的奖期不存在或者奖期信息部完整。");
        }

        /// <summary>
        /// 投注
        /// 在每个请求最多500票的限制内，尽可能携带更多的票，禁止一个投注请求仅携带一票
        /// transType=103
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型，如：103</param>
        /// <param name="tickets">要进行投注的彩票集合</param>
        /// <returns></returns>
        public string LotteryRequest(AccountNumber accountNo, TransactionType transType, List<Ticket> tickets)
        {
            if (transType.TypeCode.Trim() != "103")
            {
                throw new Exception("投注请求对应的交易类型错误。");
            }

            if (tickets.Count > 1 && tickets.Count <= 500)
            {
                try
                {
                    string body = "<body><lotteryRequest>";
                    foreach (Ticket ticket in tickets)
                    {
                        Issue issue = ticket.IssueInfo;
                        UserProfile userProfile = ticket.UserProfile;
                        string anteCodes = ticket.AnteCodes;
                        string ticketid = ticket.TicketId;

                        string ticketN = body + "<ticket id=\"" + ticketid + "\"";
                        string playType = ticketN + " playType=\"" + ticket.PlayTypeInfo.ID + "\" money=\"" + ticket.Money.Replace(",", "") + "\" amount=\"" + ticket.Amount + "\">";
                        string issueN = playType + "<issue gameName=\"" + issue.PlayMethodInfo.GameName + "\" number=\"" + issue.Number + "\"/>";
                        body = issueN + "<userProfile userName=\"" + userProfile.UserName + "\" cardType=\"" + ((int)userProfile.CardTypeInfo) + "\" mail=\"" + userProfile.Mail + "\" cardNumber=\"" + userProfile.CardNumber + "\" mobile=\"" + userProfile.Mobile + "\" realName=\"" + userProfile.RealName + "\"/>";
                        foreach (string anteCode in anteCodes.Split(new char[] { '\n' }))
                        {
                            if (!(anteCode.Trim() == ""))
                            {
                                body = body + "<anteCode>" + anteCode + "</anteCode>";
                            }
                        }
                        body = body + "</ticket>";
                    }
                    body = body + "</lotteryRequest></body>";
                    string messageId = accountNo.UserName + DateTime.Now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                    string timestamp = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss");
                    string message = "<?xml version=\"1.0\" encoding=\"GBK\"?>";
                    message = (((((((message + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>" + transType.TypeCode + "</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>";

                    Console.WriteLine("投注传递的消息为：");
                    Console.WriteLine("transType=" + transType.TypeCode + "&transMessage=" + message); 

                    string receiveString = "";
                    receiveString = PostManager.Post(GatewayUrl, "transType=" + transType.TypeCode + "&transMessage=" + message, 120);
                    return receiveString;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new Exception("每个投注请求最多500票的限制内，尽可能携带更多的票，禁止一个投注请求仅携带一票。");
        }

        /// <summary>
        /// 票查询,最多5票。如：<ticket>...</ticket>
        /// transType=105
        /// </summary>
        /// <param name="AccountNo">代理商账号</param>
        /// <param name="transType">交易类型编号，如：105</param>
        /// <param name="tickets">要进行票查询的彩票集合。要查询的票的票号，如：6000012007051012345678</param>
        /// <returns></returns>
        public string TicketQuery(AccountNumber accountNo, TransactionType transType, List<Ticket> tickets)
        {
            if (transType.TypeCode.Trim() != "105")
            {
                throw new Exception("票查询请求对应的交易类型错误。");
            }

            if (tickets.Count >= 1 && tickets.Count <= 5)
            {
                try
                {
                    int timeoutSeconds = 120;
                    string body = "<body><ticketQuery>";

                    foreach (Ticket ticket in tickets)
                    {
                        body = body + "<ticket id=\"" + ticket.TicketId + "\"/>";
                    }

                    body = body + "</ticketQuery></body>";
                    string messageId = accountNo.UserName + DateTime.Now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                    string timestamp = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss");
                    string requestMessage = "<?xml version=\"1.0\" encoding=\"GBK\"?>";
                    requestMessage = (((((((requestMessage + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>" + transType.TypeCode + "</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>";

                    Console.WriteLine("票查询传递的消息为：");
                    Console.WriteLine("transType=" + transType.TypeCode + "&transMessage=" + requestMessage); 

                    string responseMessage = PostManager.Post(GatewayUrl, "transType=" + transType.TypeCode + "&transMessage=" + requestMessage, timeoutSeconds);
                    return responseMessage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new Exception("每个票查询请求最多5票。");
        }


        /// <summary>
        /// 返奖查询
        /// transType="106"
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型</param>
        /// <param name="issue">要查询返奖信息的奖期对象</param>
        /// <returns></returns>
        public string BonusQuery(AccountNumber accountNo, TransactionType transType, Issue issue)
        {
            if (transType.TypeCode.Trim() != "106")
            {
                throw new Exception("返奖询请求对应的交易类型错误。");
            }
            try
            {
                DateTime now = DateTime.Now;
                string body = "<body><bonusQuery><issue gameName=\"" + issue.PlayMethodInfo.GameName + "\" number=\"" + issue.Number + "\"/></bonusQuery></body>";
                string messageId = accountNo.UserName + now.ToString("yyyyMMdd")  + PostManager.EightSerialNumber;
                string timestamp = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                string requestMessage="transType=" + transType.TypeCode + "&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>106</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>");
                Console.WriteLine("返奖查询传递的消息：\n" + requestMessage);
                string message = PostManager.Post(GatewayUrl,requestMessage , 120);
                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 销量查询
        /// transType="107"
        /// 代理商在收到恒朋电话投注系统发送的“完成期结”奖期通知或者
        /// 代理商查询到恒朋电话投注系统奖期状态为“完成期结”，才能发起销量查询。
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型</param>
        /// <param name="issue">要查询返奖信息的奖期对象</param>
        /// <returns></returns>
        public string BalanceQuery(AccountNumber accountNo, TransactionType transType, Issue issue)
        {
            if (transType.TypeCode.Trim() != "107")
            {
                throw new Exception("票查询请求对应的交易类型错误。");
            }

            try
            {
                DateTime now = DateTime.Now;
                string body = "<body><balanceQuery><issue gameName=\"" + issue.PlayMethodInfo.GameName + "\" number=\"" + issue.Number + "\"/></balanceQuery></body>";
                string messageId = accountNo.UserName + now.ToString("yyyyMMdd")  + PostManager.EightSerialNumber;
                string timestamp = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                string requestMessage="transType=" + transType.TypeCode + "&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>"+transType.TypeCode+"</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>");

                Console.WriteLine("销量查询传递的消息为：");
                Console.WriteLine(requestMessage);

                string message = PostManager.Post(GatewayUrl, requestMessage, 120);
                return message;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }



        /// <summary>
        /// 赠送彩金
        /// 单次最多500笔
        /// transType=114
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型编号，如：114</param>
        /// <param name="presents">要赠送彩金的赠送集合</param>
        /// <returns></returns>
        public string PresentMoney(AccountNumber accountNo, TransactionType transType, List<Present> presents)
        {
            if (transType.TypeCode.Trim() != "114")
                throw new Exception("交易类型和赠送彩金的交易类型不匹配。");

            if (presents.Count >= 1 && presents.Count <= 500)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    string body = "<body><presentMoney>";

                    foreach (Present present in presents)
                    {
                        string id = accountNo.UserName + now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                        body += "<present id=\"" + id + "\" ";
                        body += "userName=\"" + present.UserName + "\" ";
                        body += "realName=\"" + present.RealName + "\" ";
                        body += "cardType=\"" + (int)present.CardTypeInfo + "\" ";
                        body += "idCard=\"" + present.IdCard + "\" ";
                        body += "money=\"" + present.Money + "\" ";
                        body += " />";
                    }
                    body = body + "</presentMoney></body>";
                    string messageId = accountNo.UserName + now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                    string timestamp = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                    string requestMessage = "transType=" + transType.TypeCode + "&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>" + transType.TypeCode + "</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>");
                    string responseMessage = PostManager.Post(GatewayUrl, requestMessage, 120);
                    return responseMessage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new Exception("赠送彩金的用户个数个数超过了单次能查询的数目（必须为1~20）。");
        }

        /// <summary>
        /// 赠送彩金查询
        /// 单次最多20笔
        /// transType=115
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型编号，如：115</param>
        /// <param name="presents">要查询的赠送集合</param>
        /// <returns></returns>
        public string PresentQuery(AccountNumber accountNo, TransactionType transType, List<Present> presents)
        {
            if (transType.TypeCode.Trim() != "115")
                throw new Exception("交易类型和赠金查询的交易类型不匹配。");

            if (presents.Count >= 1 && presents.Count <= 20)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    string body = "<body><presentQuery>";

                    foreach (Present present in presents)
                        body = body + "<present id=" + present.Id + " />";

                    body = body + "</presentQuery></body>";
                    string messageId = accountNo.UserName + now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                    string timestamp = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                    string requestMessage = "transType=" + transType.TypeCode + "&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>" + transType.TypeCode + "</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>");
                    string responseMessage = PostManager.Post(GatewayUrl, requestMessage, 120);
                    return responseMessage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new Exception("赠金查询的个数超过了单次能查询的数目（必须为1~20）。");
        }

        /// <summary>
        /// 帐户查询
        /// transType=116
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型编号，如：116</param>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public string AccountQuery(AccountNumber accountNo, TransactionType transType, List<AccountQuery> accounts)
        {
            if (transType.TypeCode.Trim() != "116")
                throw new Exception("交易类型和帐户查询的交易类型不匹配。");

            if (accounts.Count >= 1 && accounts.Count <= 20)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    string body = "<body><accountQuery>";

                    foreach (AccountQuery account in accounts)
                        body = body + "<account userName=\"" + account.UserName + "\" />";

                    body = body + "</accountQuery></body>";
                    string messageId = accountNo.UserName + now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                    string timestamp = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                    string requestMessage = "transType=" + transType.TypeCode + "&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>" + transType.TypeCode + "</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>");

                    Console.WriteLine("账户查询请求消息为：\n" + requestMessage);

                    string responseMessage = PostManager.Post(GatewayUrl, requestMessage, 120);
                    return responseMessage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new Exception("帐户查询的个数超过了单次能查询的数目（必须为1~20）。");
        }


        /// <summary>
        /// 联合购买
        /// 代理商向恒朋系统发其一个联合购买请求只能包含一个联合购买方案。
        /// </summary>
        /// <param name="accountNo">代理商账户</param>
        /// <param name="transType">交易类型</param>
        /// <param name="anteInfo">联合购买方案信息</param>
        /// <param name="issue">奖期信息</param>
        /// <param name="anteTickets">联合购买方案投注票信息集合</param>
        /// <param name="anteBuies">联合购买方案认购主体信息集合</param>
        /// <param name="anteCommisions">联合购买方案佣金规则信息集合</param>
        /// <returns></returns>
        public string UniteAnteRequest(AccountNumber accountNo, TransactionType transType, UniteAnteInfo anteInfo, Issue issue, List<UniteAnteTicket> anteTickets, List<UniteAnteBuy> anteBuies, List<UniteAnteCommision> anteCommisions)
        {
            //if (transType.TypeCode.Trim() != "114")
            //    throw new Exception("交易类型和赠送彩金的交易类型不匹配。");

            try
            {
                DateTime now = DateTime.Now;
                    string body = "<body><uniteAnteRequest>";
                    //联合购买方案信息
                    body += "<uniteAnteInfo counterAnteId=\"" + anteInfo.CounterAnteId + "\" ";
                    body += "anteName=\"" + anteInfo.AnteName + "\" ";
                    body += "totalAnteMoney=\"" + anteInfo.TotalAnteMoney + "\" ";
                    body += "totalDeal=\"" + anteInfo.TotalDeal + "\" ";
                    body += "perDeal=\"" + anteInfo.PerDeal + "\" ";
                    body += "userName=\"" + anteInfo.UserName + "\" ";
                    body += "userName=\"" + anteInfo.UserName + "\" >";
                    body += "<issue gameName=\"" + issue.PlayMethodInfo.PlayName + "\" number=" + issue.Number + "\" /></uniteAnteInfo>";
                    //联合购买方案投注票明细信息
                    foreach(UniteAnteTicket anteTicket in anteTickets)
                    {
                        body += "<uniteAnteTicket ticketId=\"" + anteTicket.TicketId + "\" amount=\"" + anteTicket.Amount + "\" money=\"" + anteTicket.Money + "\" playType=\"" + anteTicket.PlayTypeInfo.ID + "\" >";
                        foreach (string anteCode in anteTicket.AnteCodes.Split(new char[] { '\n' }))//投注号
                        {
                            if (!(anteCode.Trim() == ""))
                            {
                                //<anteCode>01,02,03,04,05,06#01</anteCode>
                                body = body + "<anteCode>" + anteCode + "</anteCode>";
                            }
                        }
                        body += "</uniteAnteTicket>";
                    }
                    //联合购买方案认购主体的明细信息
                    foreach (UniteAnteBuy anteBuy in anteBuies)
                    {
                        //<uniteAnteBuy userName="lixia" cardType="1" mail="ramon@phoenix.com" 
                        //cardNumber="430923198009071234" bonusPhone="(0551)76526753" mobile="13098191231" realName="李侠" buyDeal="10" buyMoney="10"/>
                        body += "<uniteAnteBuy userName=\"" + anteBuy.UserName + "\" cardType=\"" + (int)anteBuy.CardType + "\" mail=\"" + anteBuy.Mail + "\" cardNumber=\"" + anteBuy.CardNumber + "\" bonusPhone=\"" + anteBuy.BonusPhone + "\" mobile=\"" + anteBuy.Mobile + "\" realName=\"" + anteBuy.RealName + "\" buyDeal=\"" + anteBuy.BuyDeal + "\" buyMoney=\"" +anteBuy.BuyMoney + "\" />";
                    }
                    //联合购买方案佣金规则信息
                    foreach (UniteAnteCommision anteCommision in anteCommisions)
                    {
                        //<uniteAnteCommision minMoney="100" maxMoney="1000" rate="4"/>
                        body += "<uniteAnteCommision minMoney=\"" + anteCommision.MinMoney +"\" maxMoney=\"" + anteCommision.MaxMoney + "\" rate=\"" + anteCommision.Rate + "\"/>";
                    }

                    body = body + "</uniteAnteRequest></body>";
                    string messageId = accountNo.UserName + now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                    string timestamp = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                    string requestMessage = "transType=" + transType.TypeCode + "&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>" + transType.TypeCode + "</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>");
                    string responseMessage = PostManager.Post(GatewayUrl, requestMessage, 120);
                    return responseMessage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }

        /// <summary>
        /// 联合购买查询
        /// </summary>
        /// <param name="accountNo">代理商账户</param>
        /// <param name="transType">交易类型</param>
        /// <param name="anteInfo">联合购买方案信息</param>
        /// <returns></returns>
        public string UniteAnteQuery(AccountNumber accountNo, TransactionType transType, UniteAnteInfo anteInfo)
        {
            //if (transType.TypeCode.Trim() != "114")
            //    throw new Exception("交易类型和赠送彩金的交易类型不匹配。");

            try
            {
                DateTime now = DateTime.Now;
                string body = "<body><uniteAnteQuery counterAnteId=\"" + anteInfo.CounterAnteId  + "\" /></body>";
                string messageId = accountNo.UserName + now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                string timestamp = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                string message = PostManager.Post(GatewayUrl, "transType=" + transType.TypeCode + "&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>106</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>"), 120);
                string responseMessage = PostManager.Post(GatewayUrl, message, 120);
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 风险控制查询
        /// tansType="134"
        /// </summary>
        /// <param name="accountNo">代理商账户</param>
        /// <param name="transType">交易类型</param>
        /// <param name="issue"></param>
        /// <param name="anteCode">投注号码.如果指定投注号码,表示查询特定号码的可投注注数,反之,表示查询所有可投注注数小于某个阀值的号码.</param>
        /// <returns></returns>
        public string RiskControlQuery(AccountNumber accountNo, TransactionType transType,Issue issue,string anteCode)
        {
            if (transType.TypeCode.Trim() != "134")
                throw new Exception("交易类型和赠送彩金的交易类型不匹配。");

            try
            {
                DateTime now = DateTime.Now;
                string body = "<body><riskControlQuery gameName=" + issue.PlayMethodInfo.PlayName + "\" number=\"" + issue.Number + "\" anteCode=\"" + anteCode + "\" /></body>";
                string messageId = accountNo.UserName + now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                string timestamp = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                string message = PostManager.Post(GatewayUrl, "transType=" + transType.TypeCode + "&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>106</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>"), 120);
                string responseMessage = PostManager.Post(GatewayUrl, message, 120);
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

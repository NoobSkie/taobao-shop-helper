using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHPGateway;
using HPGatewayModels;
using HPGatewayFactory;

namespace TextHP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("恒朋上海接口测试开始。。。。\n");


            AccountNumber accountN = new AccountNumber();
            Console.WriteLine("请输入代理商账号：");
            accountN.UserName = "200021";//Console.ReadLine();
            Console.WriteLine("请输入代理商密码：");
            accountN.UserPassword = "200021";//Console.ReadLine();
            Console.WriteLine("你输入的代理商账号为：" + accountN.UserName + "    密码为：" + accountN.UserPassword + "\n");

            IIssueQueryGateway gateway = GatewayFactroy.CreateIssueQueryGatewayFactory(LotteryType.ShangHaiWelfareLottery);
            Console.WriteLine("投注/查询网关地址：" + gateway.GatewayUrl + "\n");
            #region 奖期查询
            TransactionTypeManager transTypeM = new TransactionTypeManager(LotteryType.ShangHaiWelfareLottery);
            TransactionType transType = transTypeM.GetTransactionTypeByTypeCode(LotteryType.ShangHaiWelfareLottery, "102");


            ////奖期查询测试
            //Console.WriteLine("奖期查询开始。。。。");
            Issue issue=new Issue();
            PlayMethodManager pleyMethodM = new PlayMethodManager(LotteryType.ShangHaiWelfareLottery);
            //Console.WriteLine("请输入玩法名称(如：双色球、15选5、3D、七乐彩、6+1、天天彩4、时时乐)：");
            //issue.PlayMethodInfo=pleyMethodM.GetMethodType(LotteryType.ShangHaiWelfareLottery,Console.ReadLine());
            //Console.WriteLine("请输入期号：");
            //issue.Number=Console.ReadLine();

            //Console.WriteLine("你要进行的奖期查询玩法为：" + issue.PlayMethodInfo.PlayName + "    玩法编号为：" +issue.PlayMethodInfo.GameName + "    奖期为：" + issue.Number);

            //try
            //{
            //    string result = gateway.IssueQuery(accountN, transType, issue);
            //    Console.WriteLine("奖期查询结果：\n" + result);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("奖期查询结果：\n    错误：" + ex.Message);
            //}

            //Console.WriteLine("奖期查询结束。。。。\n");
            #endregion

            #region 投注
            //投注测试
            Console.WriteLine("投注开始(本测试会携带相同的两张彩票（票号不同）)。。。。");
            transType = transTypeM.GetTransactionTypeByTypeCode(LotteryType.ShangHaiWelfareLottery, "103");
            Console.WriteLine("构建彩票信息开始。。。。");
            List<Ticket> tickets = new List<Ticket>();
            Ticket ticketOne = new Ticket();
            ticketOne.TicketId = accountN.UserName + DateTime.Now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
            ticketOne.IssueInfo = new Issue();
            Console.WriteLine("请输入玩法名称(如：双色球、15选5、3D、七乐彩、6+1、天天彩4、时时乐)：");
            string gameName = "ssl";// Console.ReadLine();
            ticketOne.PlayTypeInfo = pleyMethodM.GetMethodType(LotteryType.ShangHaiWelfareLottery, gameName).PlayTypes[0];
            ticketOne.IssueInfo.PlayMethodInfo = pleyMethodM.GetMethodType(LotteryType.ShangHaiWelfareLottery, gameName);
            Console.WriteLine("请输入期号：");
            ticketOne.IssueInfo.Number = Console.ReadLine();
            Console.WriteLine("倍投数：");
            ticketOne.Amount = "1";// Console.ReadLine();
            Console.WriteLine("购买金额：");
            ticketOne.Money = "2";//Console.ReadLine();
            Console.WriteLine("要投注的彩票号码(测试时，每张彩票一注)：");
            ticketOne.AnteCodes = Console.ReadLine();

            UserProfile user = new UserProfile();
            Console.WriteLine("彩票用户名：");
            user.UserName = "zhongjy";// Console.ReadLine();
            Console.WriteLine("用户证件类型(1、身份证；2、军官证；3、护照)：");
            string cardType = "1";// Console.ReadLine();
            if (cardType == "1" || cardType == "2" || cardType == "3")
            {
                user.CardTypeInfo = (CardType)int.Parse(cardType);
                Console.WriteLine("证件号码：");
                user.CardNumber = "510212198105057410"; //Console.ReadLine();
                Console.WriteLine("用户邮箱地址：");
                user.Mail = "zhongjy001@gmail.com";// Console.ReadLine();
                Console.WriteLine("用户手机号(无纸化彩票中大奖的凭证之一)：");
                user.Mobile = "15902307117"; // Console.ReadLine();
                Console.WriteLine("用户真实姓名：");
                user.RealName = "钟家宇";// Console.ReadLine();
                Console.WriteLine("你输入的彩票用户信息为：  证件类型：" + (int)user.CardTypeInfo + "  证件号码：" + user.CardNumber + "  邮箱：" + user.Mail + "  手机号：" + user.Mobile + "  真实姓名：" + user.RealName);

                ticketOne.UserProfile = user;
                tickets.Add(ticketOne);
                ticketOne.TicketId = accountN.UserName + DateTime.Now.ToString("yyyyMMdd") + PostManager.TenSerialNumber;
                tickets.Add(ticketOne);


                transType = transTypeM.GetTransactionTypeByTypeCode(LotteryType.ShangHaiWelfareLottery, "103");
                try
                {
                    string result = gateway.LotteryRequest(accountN, transType, tickets);
                    Console.WriteLine("投注结果：");
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("投注结果：\n    错误：" + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("构建彩票用户错误：用户证件类型不正确");
            }
            Console.WriteLine("投注结束。。。。\n");
            #endregion

            #region 票查询
            Console.WriteLine("票查询开始(如果上面的投注成功，直接查询投票的彩票，否则请输入彩票号)。。。。");
            Console.WriteLine("上面的投注是否成功？(1、成功；2、失败)：");

            try
            {
                Ticket ticketP = null;
                if (Console.ReadLine() == "2")
                {
                    Console.WriteLine("请输入要查询的票号：");
                    ticketP = new Ticket();
                    ticketP.TicketId = Console.ReadLine();
                }
                else
                    ticketP = tickets[0];

                transType = transTypeM.GetTransactionTypeByTypeCode(LotteryType.ShangHaiWelfareLottery, "105");
                List<Ticket> ticketsP = new List<Ticket>();
                ticketsP.Add(ticketP);

                string result = gateway.TicketQuery(accountN, transType, ticketsP);
                Console.WriteLine("票查询结果：");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("票查询结果：\n    错误：" + ex.Message);
            }
            Console.WriteLine("票查询结束。。。。\n");
            #endregion

            #region 销量查询
            Console.WriteLine("销量查询开始。。。。");
            Console.WriteLine("请输入玩法名称(如：双色球、15选5、3D、七乐彩、6+1、天天彩4、时时乐)：");
            issue.PlayMethodInfo = pleyMethodM.GetMethodType(LotteryType.ShangHaiWelfareLottery, Console.ReadLine());
            Console.WriteLine("请输入期号：");
            issue.Number = Console.ReadLine();
            transType = transTypeM.GetTransactionTypeByTypeCode(LotteryType.ShangHaiWelfareLottery, "107");
            try
            {
                string result = gateway.BalanceQuery(accountN, transType, issue);
                Console.WriteLine("销量查询结果：\n" + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("销量查询结果：\n    错误：" + ex.Message);
            }
            Console.WriteLine("销量查询结束。。。。\n");
            #endregion

            #region 返奖查询
            Console.WriteLine("返奖查询开始。。。。");
            Console.WriteLine("请输入玩法名称(如：双色球、15选5、3D、七乐彩、6+1、天天彩4、时时乐)：");
            issue.PlayMethodInfo = pleyMethodM.GetMethodType(LotteryType.ShangHaiWelfareLottery, Console.ReadLine());
            Console.WriteLine("请输入期号：");
            issue.Number = Console.ReadLine();
            transType = transTypeM.GetTransactionTypeByTypeCode(LotteryType.ShangHaiWelfareLottery, "106");
            try
            {
                string result = gateway.BonusQuery(accountN, transType, issue);
                Console.WriteLine("返奖查询结果：\n" + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("返奖查询结果：\n    错误：" + ex.Message);
            }
            Console.WriteLine("返奖查询结束。。。。\n");
            #endregion

            #region 账户查询
            Console.WriteLine("账户查询开始。。。。");
            try
            {
                transType = transTypeM.GetTransactionTypeByTypeCode(LotteryType.ShangHaiWelfareLottery, "116");
                List<AccountQuery> users = new List<AccountQuery>();
                AccountQuery account = new AccountQuery();
                account.UserName = "huangzhiyu";
                users.Add(account);
                account = new AccountQuery();
                account.UserName = "huangzhiyu123";
                users.Add(account);

                string result = gateway.AccountQuery(accountN, transType, users);
                Console.WriteLine("账户查询结果：    \n" + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("账户查询结果：    \n错误：" + ex.Message);
            }
            Console.WriteLine("账户查询结束。。。。\n");
            #endregion



            IAddBalanceGateway gateway2 = GatewayFactroy.CreateAddBalanceGatewayFactory(LotteryType.ShangHaiWelfareLottery);
            Console.WriteLine("\n充值网关地址：" + gateway2.GatewayUrl + "\n");
            #region 充值
            Console.WriteLine("充值开始。。。。");
            Console.WriteLine("请输入支付提供商类型(1、银联；2、支付宝；3、腾讯财付通；4、汇付天下；5、快钱；6、网银在线；7、云网支付)：");
            AlipayProviderTypeManager alipayM = new AlipayProviderTypeManager();
            int alipayIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            AlipayProviderType alipayType = alipayM.providerTypes[alipayIndex];
            user = new UserProfile();
            Console.WriteLine("彩票用户名：");
            user.UserName = Console.ReadLine();
            Console.WriteLine("用户证件类型(1、身份证；2、军官证；3、护照)：");
            cardType = Console.ReadLine();
            if (cardType == "1" || cardType == "2" || cardType == "3")
            {
                user.CardTypeInfo = (CardType)int.Parse(cardType);
                Console.WriteLine("证件号码：");
                user.CardNumber = Console.ReadLine();
                Console.WriteLine("用户真是姓名：");
                user.RealName = Console.ReadLine();
                Console.WriteLine("你输入的彩票用户信息为：  证件类型：" + (int)user.CardTypeInfo + "  证件号码：" + user.CardNumber + "  邮箱：" + user.Mail + "  真实姓名：" + user.RealName);
                Console.WriteLine("请输入充值金额：");
                string money = Console.ReadLine();
                Console.WriteLine("请输入接受充值结果的URL地址：");
                string returnUrl = Console.ReadLine();

                try
                {
                    gateway2.PostAddBalance(accountN, alipayType, user, money, returnUrl);
                    Console.WriteLine("充值结果：成功");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("充值结果：\n    错误：" + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("构建彩票用户错误：用户证件类型不正确");
            }

            Console.WriteLine("充值结束。。。。\n");
            #endregion

            #region 充值查询
            Console.WriteLine("充值查询开始(本测试只查询一个充值)。。。。");
            Console.WriteLine("请输入号充值Id(请COPY上面\"充值请求信息\"中的id)：");
            string id = Console.ReadLine();

            try
            {
                Fill fill = new Fill();
                fill.Id = id;
                List<Fill> fills = new List<Fill>();
                fills.Add(fill);
                transType = transTypeM.GetTransactionTypeByTypeCode(LotteryType.ShangHaiWelfareLottery, "110");
                string result = gateway2.FillQuery(accountN, transType, fills);
                Console.WriteLine("充值查询结果：\n" + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("充值查询结果：\n    错误" + ex.Message);
            }

            Console.WriteLine("充值查询结束。。。。\n");
            #endregion




            IDrawingGateway gateway3 = GatewayFactroy.CreateDrawingGatewayFactory(LotteryType.ShangHaiWelfareLottery);
            Console.WriteLine("\n提款网关地址：" + gateway3.GatewayUrl + "\n");
            #region 提款
            Console.WriteLine("提款开始。。。。");
            Drawing drawing = new Drawing();
            try
            {
                drawing = new Drawing();
                drawing.Id = accountN.UserName + DateTime.Now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;

                Console.WriteLine("彩票用户名：");
                user.UserName = Console.ReadLine();
                Console.WriteLine("用户证件类型(1、身份证；2、军官证；3、护照)：");
                cardType = Console.ReadLine();
                if (cardType == "1" || cardType == "2" || cardType == "3")
                {
                    user.CardTypeInfo = (CardType)int.Parse(cardType);
                    Console.WriteLine("证件号码：");
                    user.CardNumber = Console.ReadLine();
                    Console.WriteLine("用户真是姓名：");
                    user.RealName = Console.ReadLine();
                    Console.WriteLine("你输入的彩票用户信息为：  证件类型：" + (int)user.CardTypeInfo + "  证件号码：" + user.CardNumber + "  邮箱：" + user.Mail + "  真实姓名：" + user.RealName);
                }

                drawing.User = user;
                Console.WriteLine("银行账号：");
                drawing.BankCard = Console.ReadLine();
                Console.WriteLine("开户行名称：");
                drawing.BankName = Console.ReadLine();
                Console.WriteLine("开户行所在省或直辖市名称：");
                drawing.Province = Console.ReadLine();
                Console.WriteLine("开户行所在城市：");
                drawing.City = Console.ReadLine();
                Console.WriteLine("分行或支行、分理处名称：");
                drawing.Branch = Console.ReadLine();
                Console.WriteLine("提款金额：");
                drawing.Money = Convert.ToInt32(Console.ReadLine());



                transType = transTypeM.GetTransactionTypeByTypeCode(LotteryType.ShangHaiWelfareLottery, "111");
                string result = gateway3.DrawingRequest(accountN, transType, drawing);

                Console.WriteLine("提款结果：\n" + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("提款结果：    \n错误：" + ex.Message);
            }
            Console.WriteLine("提款结束。。。。\n");
            #endregion

            #region 提款查询
            Console.WriteLine("提款查询开始。。。。");
            try
            {
                List<Drawing> drawings = new List<Drawing>();
                drawings.Add(drawing);
                transType = transTypeM.GetTransactionTypeByTypeCode(LotteryType.ShangHaiWelfareLottery, "113");
                string result = gateway3.DrawingQuery(accountN, transType, drawings);
                Console.WriteLine("提款查询结果：\n" + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("提款查询结果：    \n错误：" + ex.Message);
            }
            Console.WriteLine("提款查询结束。。。。\n");
            #endregion
        }
    }
}

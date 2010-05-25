using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 响应状态集合
    /// </summary>
    public class ResponseStatusManager
    {
        public List<ResponseStatus> Statuses = new List<ResponseStatus>();

        /// <summary>
        /// 根据彩票种类(如：上海福彩，重庆福彩，江西福彩，山东体彩)，得到该类彩票响应状态集合
        /// </summary>
        /// <param name="lotteryType">彩票种类</param>
        public ResponseStatusManager(LotteryType lotteryType)
        {
            this.Statuses.Clear();
            this.CreateResponseStatus(lotteryType);
        }

        /// <summary>
        /// 根据彩票种类(如：上海福彩，重庆福彩，江西福彩，山东体彩)，创建彩票响应状态集合
        /// </summary>
        /// <param name="lotteryType">彩票种类</param>
        private void CreateResponseStatus(LotteryType lotteryType)
        {
            this.Statuses.Clear();
            if (lotteryType == LotteryType.ShangHaiWelfareLottery)
            {
                #region 上海福彩响应状态
                ResponseStatus status = new ResponseStatus("0000", "成功,系统处理正常。",lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("0010", "消息格式错误。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("0011", "不支持的协议版本，比如设定了message的version属性为0.1。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("0012", "messageID格式错误。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("0014", "timestamp时间戳格式错误。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("0015", "消息摘要不匹配。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("0016", "不支持该交易类型。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("0017", "MessageId重复。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("0098", "单个请求超出最大并发数。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("0099", "单个请求与上次时间间隔不能小于最小时间间隔。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("0097", "调用委托投注接口的IP地址不是绑定的投注IP地址", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("1008", "玩法不存在。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("1009", "奖期不存在。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("1010", "处理投注过程中出现票投注失败。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("1011", "奖期非投注状态。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("1012", "请求消息中指定的玩法不存在。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("1013", "奖期未截止。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("1014", "奖期未完成期结。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("1015", "奖期未完成兑奖。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("1016", "代理不支持某个特定玩法（恒朋电话投注系统可以管理投注代理商支持的玩法）。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("1017", "请求消息中指定的某玩法的奖期不存在。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("1018", "代理商无此奖期销售统计数据。", lotteryType);
                this.Statuses.Add(status);



                status = new ResponseStatus("2001", "用户证件号码格式错误。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2002", "用户手机号码错误。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2003", "必须填写用户证件号码。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2004", "必须填写用户手机号码。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2010", "投注号码个数超出允许范围。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2011", "单个号码值超出允许范围（比如双色球投注号码中包含了78）。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2012", "禁止倍投。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2013", "禁止多期投注。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2014", "禁止胆拖投注。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2015", "禁止复式投注。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2016", "禁止组选投注。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2017", "禁止和值投注。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2018", "单票投注金额超出上限。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2030", "倍投的倍数超出范围。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2031", "多期投注的期数超出允许范围。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2032", "单个号码购买注数超出允许范围。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2040", "票金额不相符（比如ticket的money属性值与根据item计算出来的资金不符合）。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2041", "超出返奖截止时间,禁止返奖。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2042", "票流水号格式错误。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2043", "不支持的投注方式。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2044", "投注号码格式错误。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2045", "投注代理商的交易请求过于密集(系统可能对投注代理商的交易请求发送频率进行限制)", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2046", "单个投注请求中包含的投注票数超出上限。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2047", "单个票查询请求中包含的投注票数超出上限。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2048", "重复发送的投注票（该投注票已经发送到恒朋电话投注系统了）。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2049", "不存在该票号。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2051", "投注失败。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("2052", "投注中。", lotteryType);
                this.Statuses.Add(status);



                status = new ResponseStatus("3000", "非归集帐户", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3001", "投注代理商已经被冻结。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3002", "投注代理商已经被关闭。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3003", "投注代理商不存在，比如指定的messengerID非法。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3004", "投注代理商已经被暂停。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3005", "投注代理商未开启。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3010", "投注代理商销售金额已经超出上限。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3011", "投注代理商配置信息错误（管理资金账户代理商调用非管理资金账户投注接口）。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3012", "彩民帐户不存在", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3013", "彩民用户资金账户可用余额不足", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3014", "代理商资金账户不存在", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3015", "代理商帐户余额不足", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3016", "赠送彩金编号重复", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3017", "单次交易赠送笔数超限", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3018", "赠送彩金编号不存在", lotteryType);
                this.Statuses.Add(status);




                status = new ResponseStatus("3100", "发起人已存在", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3101", "发起人资格无法发起资格或发起人不存在", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3201", "代理商联合购买方案编号重复", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3202", "方案发起人无权限", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3203", "佣金比例超限", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3204", "佣金比例设置错误", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3205", "投注明细统计结果与总金额或总票数不符", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3206", "联合购买总票数超限", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3207", "代理商无联合购买权限", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3208", "代理联合购买方案不存在", lotteryType);
                this.Statuses.Add(status);


                status = new ResponseStatus("3220", "不支持的证件类型", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3221", "缺少用户登录名", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3222", "缺少用户登录密码", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3223", "帐户已经存在", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3224", "缺少证件类型", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("3225", "邮件格式不正确", lotteryType);
                this.Statuses.Add(status);



                status = new ResponseStatus("9001", "未找到支付提供商", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("9002", "未找到交易类型", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("9003", "提交参数不能为空", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("9004", "不支持的字符编码", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("9005", "支付网关返回错误", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("9006", "数字签名错误", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("9007", "交易金额不符", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("9008", "交易重复处理", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("9009", "交易不存在", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("9010", "电话投注卡不存在或密码错误。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("9011", "电话投注卡卡面余额不相符。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("9012", "电话投注卡状态处于非销售状态。", lotteryType);
                this.Statuses.Add(status);

                status = new ResponseStatus("9013", "电话投注卡已过期。", lotteryType);
                this.Statuses.Add(status);



                status = new ResponseStatus("9999", "系统未知异常。", lotteryType);
                this.Statuses.Add(status);
                #endregion
            }
        }

        /// <summary>
        /// 根据彩票种类和响应状态码得到状态对象
        /// </summary>
        /// <param name="lotteryType">彩票种类(如：上海福彩，重庆福彩，江西福彩，山东体彩)</param>
        /// <param name="playName">响应状态</param>
        /// <returns>状态对象</returns>
        public ResponseStatus GetResponseStatus(LotteryType lotteryType, string statusCode)
        {
            foreach (ResponseStatus status in this.Statuses)
            {
                if (status.LotteryType == lotteryType && status.StatusCode == statusCode)
                    return status;
            }
            return null;
        }
    }
}

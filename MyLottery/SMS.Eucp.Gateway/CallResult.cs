namespace SMS.Eucp.Gateway
{
    using System;

    public class CallResult
    {
        public int Code;
        public string Description;
        public object Value;

        public CallResult(int code)
        {
            this.Code = code;
            if (this.Code == 1)
            {
                this.Code = 0;
                this.Description = "";
            }
            else
            {
                if (this.Code == 0)
                {
                    this.Code = -9999;
                }
                if (this.Code > 0)
                {
                    this.Code *= -1;
                }
                int num = this.Code;
                if (num > -201)
                {
                    switch (num)
                    {
                        case -114:
                            this.Description = "得到标识错误";
                            return;

                        case -113:
                            this.Description = "旧密码或新密码为空";
                            return;

                        case -112:
                            this.Description = "定时时间为空或格式不正确";
                            return;

                        case -111:
                            this.Description = "附加号码过长(8位)";
                            return;

                        case -110:
                            this.Description = "短信内容为空或超长(70个汉字)";
                            return;

                        case -109:
                            this.Description = "部分手机号码不正确，已删除，其余手机号码被发送";
                            return;

                        case -108:
                            this.Description = "手机号码分割符号不正确";
                            return;

                        case -107:
                            this.Description = "手机号码为空或者超过1000个";
                            return;

                        case -106:
                            this.Description = "卡号或密码为空或无效";
                            return;

                        case -105:
                            this.Description = "需要传递的指针参数为空(C#组件内部错误)";
                            return;

                        case -104:
                            this.Description = "注册信息填写不完整";
                            return;

                        case -103:
                            this.Description = "注册企业基本信息失败，当软件注册号码注册成功，但整体还是失败，要重新注册";
                            return;

                        case -102:
                            this.Description = "其它故障";
                            return;

                        case -101:
                            this.Description = "网络故障";
                            return;

                        case -100:
                            this.Description = "序列号码为空或无效";
                            return;

                        case -1:
                            this.Description = "未知故障";
                            return;
                    }
                }
                else
                {
                    switch (num)
                    {
                        case -9999:
                            this.Description = "失败";
                            return;

                        case -201:
                            this.Description = "计费失败，请充值";
                            return;
                    }
                }
                this.Description = "未知故障";
            }
        }
    }
}


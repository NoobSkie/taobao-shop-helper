namespace SMS.Eucp.Gateway
{
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    public class Gateway
    {
        public ReceiveSmsContents rsc = new ReceiveSmsContents();
        private string password;
        private string name;

        public Gateway(string Name, string Password)
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Password))
            {
                throw new Exception("SMS.Gateway 需要设置用户名和密码。");
            }
            this.name = Name;
            this.password = Password;
        }

        [DllImport("EUCPComm.dll", EntryPoint="CancelTransfer")]
        public static extern int _CancelTransfer(string sn);
        [DllImport("EUCPComm.dll", EntryPoint="ChargeUp")]
        public static extern int _ChargeUp(string sn, string acco, string pass);
        [DllImport("EUCPComm.dll", EntryPoint="GetBalance")]
        public static extern int _GetBalance(string m, StringBuilder balance);
        [DllImport("EUCPComm.dll", EntryPoint="GetPrice")]
        public static extern int _GetPrice(string m, StringBuilder balance);
        [DllImport("EUCPComm.dll", EntryPoint="ReceiveSMS")]
        public static extern int _ReceiveSMS(string sn, deleSQF mySmsContent);
        [DllImport("EUCPComm.dll", EntryPoint="ReceiveSMSEx")]
        public static extern int _ReceiveSMSEx(string sn, deleSQF mySmsContent);
        [DllImport("EUCPComm.dll", EntryPoint="ReceiveStatusReport")]
        public static extern int _ReceiveStatusReport(string sn, delegSMSReport mySmsReport);
        [DllImport("EUCPComm.dll", EntryPoint="ReceiveStatusReportEx")]
        public static extern int _ReceiveStatusReportEx(string sn, delegSMSReportEx mySmsReportEx);
        [DllImport("EUCPComm.dll", EntryPoint="Register")]
        public static extern int _Register(string sn, string pwd, string EntName, string LinkMan, string Phone, string Mobile, string Email, string Fax, string sAddress, string Postcode);
        [DllImport("EUCPComm.dll", EntryPoint="RegistryPwdUpd")]
        public static extern int _RegistryPwdUpd(string sn, string oldPWD, string newPWD);
        [DllImport("EUCPComm.dll", EntryPoint="RegistryTransfer")]
        public static extern int _RegistryTransfer(string sn, string mn);
        [DllImport("EUCPComm.dll", EntryPoint="SendScheSMS")]
        public static extern int _SendScheSMS(string sn, string mn, string ct, string ti, string priority);
        [DllImport("EUCPComm.dll", EntryPoint="SendScheSMSEx")]
        public static extern int _SendScheSMSEx(string sn, string mn, string ct, string ti, string addi, string priority);
        [DllImport("EUCPComm.dll", EntryPoint="SendSMS")]
        public static extern int _SendSMS(string sn, string mn, string ct, string priority);
        [DllImport("EUCPComm.dll", EntryPoint="SendSMSEx")]
        public static extern int _SendSMSEx(string sn, string mn, string ct, string addi, string priority);
        [DllImport("EUCPComm.dll", EntryPoint="SetKey")]
        public static extern int _SetKey(string Key);
        [DllImport("EUCPComm.dll", EntryPoint="SetProxy")]
        public static extern int _SetProxy(string IP, string Port, string UserName, string PWD);
        [DllImport("EUCPComm.dll", EntryPoint="UnRegister")]
        public static extern int _UnRegister(string sn);
        public CallResult CancelTransfer()
        {
            return new CallResult(_CancelTransfer(this.name));
        }

        public CallResult Charge(string ChargeCardNumber, string ChargeCardPassword)
        {
            return new CallResult(_ChargeUp(this.name, ChargeCardNumber, ChargeCardPassword));
        }

        private void FgF4PPDs7(string p0, string p1, string p2, string p3, string p4, ref int p5)
        {
            if (p5 == 1)
            {
                this.rsc.Add(p0, p3);
            }
        }

        public CallResult GetBalance()
        {
            StringBuilder balance = new StringBuilder(20);
            CallResult result = new CallResult(_GetBalance(this.name, balance));
            if (result.Code == 0)
            {
                result.Value = balance.ToString(0, balance.Length - 2);
            }
            return result;
        }

        public CallResult GetPrice()
        {
            StringBuilder balance = new StringBuilder(20);
            CallResult result = new CallResult(_GetPrice(this.name, balance));
            if (result.Code == 0)
            {
                result.Value = balance.ToString();
            }
            return result;
        }

        private string[] hf3lxShBh(string p0)
        {
            p0 = p0.Trim();
            if (p0 == "")
            {
                return null;
            }
            ArrayList list = new ArrayList();
            string str = "";
            for (int i = 0; i < p0.Length; i++)
            {
                string str2 = p0[i].ToString();
                int num2 = this.m000001(str2);
                if ((this.m000001(str) + num2) > 140)
                {
                    list.Add(str);
                    str = str2;
                }
                else
                {
                    str = str + str2;
                }
            }
            if (str != "")
            {
                list.Add(str);
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private int m000001(string p0)
        {
            int length = p0.Length;
            char[] chArray = p0.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] >= 0x7fL)
                {
                    length++;
                }
            }
            return length;
        }

        public CallResult ReceiveSMS()
        {
            this.rsc.Clear();
            deleSQF mySmsContent = new deleSQF(this.FgF4PPDs7);
            int code = 2;
            int num2 = 0;
            while (code == 2)
            {
                code = _ReceiveSMS(this.name, mySmsContent);
                switch (code)
                {
                    case 2:
                    case 1:
                        num2++;
                        break;
                }
            }
            CallResult result = new CallResult(code);
            result.Value = num2.ToString();
            return result;
        }

        public CallResult ReceiveSMSEx()
        {
            this.rsc.Clear();
            deleSQF mySmsContent = new deleSQF(this.FgF4PPDs7);
            int code = 2;
            int num2 = 0;
            while (code == 2)
            {
                code = _ReceiveSMSEx(this.name, mySmsContent);
                switch (code)
                {
                    case 2:
                    case 1:
                        num2++;
                        break;
                }
            }
            CallResult result = new CallResult(code);
            result.Value = num2.ToString();
            return result;
        }

        public CallResult ReceiveStatusReport()
        {
            delegSMSReport mySmsReport = new delegSMSReport(this.sqqK62JCl);
            int code = 2;
            int num2 = 0;
            while (code == 2)
            {
                code = _ReceiveStatusReport(this.name, mySmsReport);
                switch (code)
                {
                    case 2:
                    case 1:
                        num2++;
                        break;
                }
            }
            CallResult result = new CallResult(code);
            result.Value = num2.ToString();
            return result;
        }

        public CallResult Register()
        {
            return new CallResult(_Register(this.name, this.password, "1", "1", "1", "1", "1", "1", "1", "1"));
        }

        public CallResult RegistryPwdUpd(string NewPassword)
        {
            int code = _RegistryPwdUpd(this.name, this.password, NewPassword);
            if (code == 1)
            {
                this.SetPassword(NewPassword);
            }
            return new CallResult(code);
        }

        public CallResult RegistryTransfer(string Mobile)
        {
            return new CallResult(_RegistryTransfer(this.name, Mobile));
        }

        public CallResult Send(string ToMobile, string Content)
        {
            int code = _SendSMS(this.name, ToMobile, Content, "5");
            CallResult result = new CallResult(code);
            if (code == 0x6d)
            {
                result.Code = 0;
                result.Value = 0x6d;
            }
            return result;
        }

        public CallResult Send(string ToMobile, string Content, DateTime SendTime)
        {
            int code = _SendScheSMS(this.name, ToMobile, Content, SendTime.ToString("yyyy-MM-dd hh:mm:ss"), "5");
            CallResult result = new CallResult(code);
            if (code == 0x6d)
            {
                result.Code = 0;
                result.Value = 0x6d;
            }
            return result;
        }

        public CallResult SendEx(string ToMobile, string Content, string AdditionalNumber)
        {
            int code = _SendSMSEx(this.name, ToMobile, Content, AdditionalNumber, "5");
            CallResult result = new CallResult(code);
            if (code == 0x6d)
            {
                result.Code = 0;
                result.Value = 0x6d;
            }
            return result;
        }

        public CallResult SendEx(string ToMobile, string Content, DateTime SendTime, string AdditionalNumber)
        {
            int code = _SendScheSMSEx(this.name, ToMobile, Content, SendTime.ToString("yyyy-MM-dd hh:mm:ss"), AdditionalNumber, "5");
            CallResult result = new CallResult(code);
            if (code == 0x6d)
            {
                result.Code = 0;
                result.Value = 0x6d;
            }
            return result;
        }

        public CallResult SetKey(string Key)
        {
            return new CallResult(_SetKey(Key));
        }

        public void SetPassword(string NewPassword)
        {
            this.password = NewPassword;
        }

        public CallResult SetProxy(string HostNameOrIPAddress, string Port, string HostUserName, string HostUserPassword)
        {
            return new CallResult(_SetProxy(HostNameOrIPAddress, Port, HostUserName, HostUserPassword));
        }

        private void sqqK62JCl(string p0, string p1, string p2, string p3, ref int p4)
        {
        }

        public CallResult UnRegister()
        {
            return new CallResult(_UnRegister(this.name));
        }

        private int uq0YQA247(string p0, char p1)
        {
            int num = 0;
            for (int i = 0; i < p0.Length; i++)
            {
                if (p0[i] == p1)
                {
                    num++;
                }
            }
            return num;
        }

        private void V1deDI6ZS(ref long p0, string p1, string p2, string p3, string p4, ref int p5)
        {
        }

        private string[] v60v2wZZZ(string p0)
        {
            p0 = p0.Trim();
            if (p0 == "")
            {
                return null;
            }
            string[] strArray = p0.Split(new char[] { ',' });
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length < 1)
            {
                return null;
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Trim() != "")
                {
                    list.Add(strArray[i].Trim());
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray2 = new string[(list.Count / 0x3e8) + 1];
            for (int j = 0; j < strArray2.Length; j++)
            {
                strArray2[j] = "";
            }
            for (int k = 0; k < list.Count; k++)
            {
                string[] strArray3;
                IntPtr ptr;
                (strArray3 = strArray2)[(int) (ptr = (IntPtr) (k / 0x3e8))] = strArray3[(int) ptr] + list[k].ToString() + ",";
            }
            for (int m = 0; m < strArray2.Length; m++)
            {
                if (strArray2[m].EndsWith(","))
                {
                    strArray2[m] = strArray2[m].Substring(0, strArray2[m].Length - 1);
                }
            }
            return strArray2;
        }

        public delegate void delegSMSReport(string mobile, string errorCode, string serviceCodeAdd, string reportType, ref int flag);

        public delegate void delegSMSReportEx(ref long seq, string mobile, string errorCode, string serviceCodeAdd, string reportType, ref int flag);

        public delegate void deleSQF(string FromMobile, string SenderAdditionalNumber, string ReceiveAdditionalNumber, string Content, string SendTime, ref int Flag);
    }
}


namespace Shove._Net
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class Internet
    {
        private const int f00001d = 1;
        private const int JBjYwnpSL = 2;

        [DllImport("winInet.dll", EntryPoint = "InternetGetConnectedState")]
        private static extern bool InternetGetConnectedState(ref int conState, int reder);
        /// <summary>
        /// 判断是否连接Internet
        /// </summary>
        /// <returns></returns>
        public static int GetInternetConnectedState()
        {
            int num = 0;
            if (!InternetGetConnectedState(ref num, 0))
            {
                return 0;
            }
            if ((num & 1) != 0)
            {
                return 1;
            }
            if ((num & 2) != 0)
            {
                return 2;
            }
            return -1;
        }

        /// <summary>
        /// 拨号类
        /// </summary>
        public class RasManager
        {
            private RASDIALPARAMS RasDialParams = new RASDIALPARAMS();
            public const int DNLEN = 15;
            private int Connection = 0;
            public const int MAX_PATH = 260;
            public const int PWLEN = 0x100;
            public const int RAS_MaxCallbackNumber = 0x80;
            public const int RAS_MaxDeviceType = 0x10;
            public const int RAS_MaxEntryName = 0x100;
            public const int RAS_MaxPhoneNumber = 0x80;
            public const int UNLEN = 0x100;

            public RasManager()
            {
                this.RasDialParams.dwSize = Marshal.SizeOf(this.RasDialParams);
            }

            public int Connect()
            {
                Callback lpvNotifier = new Callback(Internet.RasManager.RasDialFunc);
                this.RasDialParams.szEntryName = this.RasDialParams.szEntryName + "\0";
                this.RasDialParams.szUserName = this.RasDialParams.szUserName + "\0";
                this.RasDialParams.szPassword = this.RasDialParams.szPassword + "\0";
                return RasDial(0, null, ref this.RasDialParams, 0, lpvNotifier, ref this.Connection);
            }

            [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
            public static extern int RasDial(int lpRasDialExtensions, string lpszPhonebook, ref RASDIALPARAMS lprasdialparams, int dwNotifierType, Callback lpvNotifier, ref int lphRasConn);
            public static void RasDialFunc(uint unMsg, int rasconnstate, int dwError)
            {
            }

            public string EntryName
            {
                get
                {
                    return this.RasDialParams.szEntryName;
                }
                set
                {
                    this.RasDialParams.szEntryName = value;
                }
            }

            public string Password
            {
                get
                {
                    return this.RasDialParams.szPassword;
                }
                set
                {
                    this.RasDialParams.szPassword = value;
                }
            }

            public string UserName
            {
                get
                {
                    return this.RasDialParams.szUserName;
                }
                set
                {
                    this.RasDialParams.szUserName = value;
                }
            }

            public delegate void Callback(uint unMsg, int rasconnstate, int dwError);

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
            public struct RASDIALPARAMS
            {
                public int dwSize;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x101)]
                public string szEntryName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x81)]
                public string szPhoneNumber;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x81)]
                public string szCallbackNumber;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x101)]
                public string szUserName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x101)]
                public string szPassword;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x10)]
                public string szDomain;
                public int dwSubEntry;
                public int dwCallbackId;
                static RASDIALPARAMS()
                {
                }
            }
        }
    }
}


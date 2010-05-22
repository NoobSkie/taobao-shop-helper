namespace Shove
{
    using Microsoft.VisualBasic;
    using System;
    using System.Data;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class _Convert
    {
        public static int Asc(char ch)
        {
            return ch;
        }

        public static char Chr(int i)
        {
            return (char) i;
        }

        public static string DataTableToXML(DataTable dt)
        {
            MemoryStream w = null;
            XmlTextWriter writer = null;
            string str = "";
            try
            {
                w = new MemoryStream();
                writer = new XmlTextWriter(w, Encoding.UTF8);
                dt.WriteXml(writer);
                int length = (int) w.Length;
                byte[] buffer = new byte[length];
                w.Seek(0L, SeekOrigin.Begin);
                w.Read(buffer, 0, length);
                str = new UTF8Encoding().GetString(buffer).Trim();
            }
            catch
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
            return str;
        }

        public static bool StrToBool(string str, bool Default)
        {
            try
            {
                return bool.Parse(str);
            }
            catch
            {
                return Default;
            }
        }

        public static DateTime StrToDateTime(string str, string Default)
        {
            try
            {
                return DateTime.Parse(str);
            }
            catch
            {
                return DateTime.Parse(Default);
            }
        }

        public static double StrToDouble(string str, double Default)
        {
            try
            {
                return double.Parse(str);
            }
            catch
            {
                return Default;
            }
        }

        public static float StrToFloat(string str, float Default)
        {
            try
            {
                return float.Parse(str);
            }
            catch
            {
                return Default;
            }
        }

        public static int StrToInt(string str, int Default)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                return Default;
            }
        }

        public static long StrToLong(string str, long Default)
        {
            try
            {
                return long.Parse(str);
            }
            catch
            {
                return Default;
            }
        }

        public static short StrToShort(string str, short Default)
        {
            try
            {
                return short.Parse(str);
            }
            catch
            {
                return Default;
            }
        }

        public static string ToDBC(string input)
        {
            char[] chArray = input.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == '　')
                {
                    chArray[i] = ' ';
                }
                else if ((chArray[i] > 65280) && (chArray[i] < 65375))
                {
                    chArray[i] = (char)(chArray[i] - 65248);
                }
            }
            return new string(chArray);
        }

        public static string ToHtmlCode(string sourceStr)
        {
            return sourceStr.Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "''").Replace(" ", "&nbsp;").Replace("\r\n", "<br/>").Replace("\n", "<br/>").Trim();
        }

        public static string ToSBC(string input)
        {
            char[] chArray = input.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == ' ')
                {
                    chArray[i] = '　';
                }
                else if (chArray[i] < '\x007f')
                {
                    chArray[i] = (char) (chArray[i] + 0xfee0);
                }
            }
            return new string(chArray);
        }

        public static string ToTextCode(string sourceStr)
        {
            return sourceStr.Replace("&lt;", "<").Replace("&gt;", ">").Replace("''", "'").Replace("&nbsp;", " ").Replace("<br/>", "\r\n").Replace("<br>", "\n").Trim();
        }

        public static DataTable XMLToDataTable(string Xml)
        {
            StringReader input = null;
            XmlTextReader reader = null;
            DataSet set = new DataSet();
            try
            {
                input = new StringReader(Xml);
                reader = new XmlTextReader(input);
                set.ReadXml(reader);
            }
            catch
            {
                set = null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (input != null)
                {
                    input.Close();
                }
            }
            if ((set != null) && (set.Tables.Count >= 1))
            {
                return set.Tables[0];
            }
            return null;
        }

        public class Chinese
        {
            public static string ToPinYin(string input)
            {
                int[] numArray = new int[] { 
                    -20319, -20317, -20304, -20295, -20292, -20283, -20265, -20257, -20242, -20230, -20051, -20036, -20032, -20026, -20002, -19990, 
                    -19986, -19982, -19976, -19805, -19784, -19775, -19774, -19763, -19756, -19751, -19746, -19741, -19739, -19728, -19725, -19715, 
                    -19540, -19531, -19525, -19515, -19500, -19484, -19479, -19467, -19289, -19288, -19281, -19275, -19270, -19263, -19261, -19249, 
                    -19243, -19242, -19238, -19235, -19227, -19224, -19218, -19212, -19038, -19023, -19018, -19006, -19003, -18996, -18977, -18961, 
                    -18952, -18783, -18774, -18773, -18763, -18756, -18741, -18735, -18731, -18722, -18710, -18697, -18696, -18526, -18518, -18501, 
                    -18490, -18478, -18463, -18448, -18447, -18446, -18239, -18237, -18231, -18220, -18211, -18201, -18184, -18183, -18181, -18012, 
                    -17997, -17988, -17970, -17964, -17961, -17950, -17947, -17931, -17928, -17922, -17759, -17752, -17733, -17730, -17721, -17703, 
                    -17701, -17697, -17692, -17683, -17676, -17496, -17487, -17482, -17468, -17454, -17433, -17427, -17417, -17202, -17185, -16983, 
                    -16970, -16942, -16915, -16733, -16708, -16706, -16689, -16664, -16657, -16647, -16474, -16470, -16465, -16459, -16452, -16448, 
                    -16433, -16429, -16427, -16423, -16419, -16412, -16407, -16403, -16401, -16393, -16220, -16216, -16212, -16205, -16202, -16187, 
                    -16180, -16171, -16169, -16158, -16155, -15959, -15958, -15944, -15933, -15920, -15915, -15903, -15889, -15878, -15707, -15701, 
                    -15681, -15667, -15661, -15659, -15652, -15640, -15631, -15625, -15454, -15448, -15436, -15435, -15419, -15416, -15408, -15394, 
                    -15385, -15377, -15375, -15369, -15363, -15362, -15183, -15180, -15165, -15158, -15153, -15150, -15149, -15144, -15143, -15141, 
                    -15140, -15139, -15128, -15121, -15119, -15117, -15110, -15109, -14941, -14937, -14933, -14930, -14929, -14928, -14926, -14922, 
                    -14921, -14914, -14908, -14902, -14894, -14889, -14882, -14873, -14871, -14857, -14678, -14674, -14670, -14668, -14663, -14654, 
                    -14645, -14630, -14594, -14429, -14407, -14399, -14384, -14379, -14368, -14355, -14353, -14345, -14170, -14159, -14151, -14149, 
                    -14145, -14140, -14137, -14135, -14125, -14123, -14122, -14112, -14109, -14099, -14097, -14094, -14092, -14090, -14087, -14083, 
                    -13917, -13914, -13910, -13907, -13906, -13905, -13896, -13894, -13878, -13870, -13859, -13847, -13831, -13658, -13611, -13601, 
                    -13406, -13404, -13400, -13398, -13395, -13391, -13387, -13383, -13367, -13359, -13356, -13343, -13340, -13329, -13326, -13318, 
                    -13147, -13138, -13120, -13107, -13096, -13095, -13091, -13076, -13068, -13063, -13060, -12888, -12875, -12871, -12860, -12858, 
                    -12852, -12849, -12838, -12831, -12829, -12812, -12802, -12607, -12597, -12594, -12585, -12556, -12359, -12346, -12320, -12300, 
                    -12120, -12099, -12089, -12074, -12067, -12058, -12039, -11867, -11861, -11847, -11831, -11798, -11781, -11604, -11589, -11536, 
                    -11358, -11340, -11339, -11324, -11303, -11097, -11077, -11067, -11055, -11052, -11045, -11041, -11038, -11024, -11020, -11019, 
                    -11018, -11014, -10838, -10832, -10815, -10800, -10790, -10780, -10764, -10587, -10544, -10533, -10519, -10331, -10329, -10328, 
                    -10322, -10315, -10309, -10307, -10296, -10281, -10274, -10270, -10262, -10260, -10256, -10254
                 };
                string[] strArray = new string[] { 
                    "a", "ai", "an", "ang", "ao", "ba", "bai", "ban", "bang", "bao", "bei", "ben", "beng", "bi", "bian", "biao", 
                    "bie", "bin", "bing", "bo", "bu", "ca", "cai", "can", "cang", "cao", "ce", "ceng", "cha", "chai", "chan", "chang", 
                    "chao", "che", "chen", "cheng", "chi", "chong", "chou", "chu", "chuai", "chuan", "chuang", "chui", "chun", "chuo", "ci", "cong", 
                    "cou", "cu", "cuan", "cui", "cun", "cuo", "da", "dai", "dan", "dang", "dao", "de", "deng", "di", "dian", "diao", 
                    "die", "ding", "diu", "dong", "dou", "du", "duan", "dui", "dun", "duo", "e", "en", "er", "fa", "fan", "fang", 
                    "fei", "fen", "feng", "fo", "fou", "fu", "ga", "gai", "gan", "gang", "gao", "ge", "gei", "gen", "geng", "gong", 
                    "gou", "gu", "gua", "guai", "guan", "guang", "gui", "gun", "guo", "ha", "hai", "han", "hang", "hao", "he", "hei", 
                    "hen", "heng", "hong", "hou", "hu", "hua", "huai", "huan", "huang", "hui", "hun", "huo", "ji", "jia", "jian", "jiang", 
                    "jiao", "jie", "jin", "jing", "jiong", "jiu", "ju", "juan", "jue", "jun", "ka", "kai", "kan", "kang", "kao", "ke", 
                    "ken", "keng", "kong", "kou", "ku", "kua", "kuai", "kuan", "kuang", "kui", "kun", "kuo", "la", "lai", "lan", "lang", 
                    "lao", "le", "lei", "leng", "li", "lia", "lian", "liang", "liao", "lie", "lin", "ling", "liu", "long", "lou", "lu", 
                    "lv", "luan", "lue", "lun", "luo", "ma", "mai", "man", "mang", "mao", "me", "mei", "men", "meng", "mi", "mian", 
                    "miao", "mie", "min", "ming", "miu", "mo", "mou", "mu", "na", "nai", "nan", "nang", "nao", "ne", "nei", "nen", 
                    "neng", "ni", "nian", "niang", "niao", "nie", "nin", "ning", "niu", "nong", "nu", "nv", "nuan", "nue", "nuo", "o", 
                    "ou", "pa", "pai", "pan", "pang", "pao", "pei", "pen", "peng", "pi", "pian", "piao", "pie", "pin", "ping", "po", 
                    "pu", "qi", "qia", "qian", "qiang", "qiao", "qie", "qin", "qing", "qiong", "qiu", "qu", "quan", "que", "qun", "ran", 
                    "rang", "rao", "re", "ren", "reng", "ri", "rong", "rou", "ru", "ruan", "rui", "run", "ruo", "sa", "sai", "san", 
                    "sang", "sao", "se", "sen", "seng", "sha", "shai", "shan", "shang", "shao", "she", "shen", "sheng", "shi", "shou", "shu", 
                    "shua", "shuai", "shuan", "shuang", "shui", "shun", "shuo", "si", "song", "sou", "su", "suan", "sui", "sun", "suo", "ta", 
                    "tai", "tan", "tang", "tao", "te", "teng", "ti", "tian", "tiao", "tie", "ting", "tong", "tou", "tu", "tuan", "tui", 
                    "tun", "tuo", "wa", "wai", "wan", "wang", "wei", "wen", "weng", "wo", "wu", "xi", "xia", "xian", "xiang", "xiao", 
                    "xie", "xin", "xing", "xiong", "xiu", "xu", "xuan", "xue", "xun", "ya", "yan", "yang", "yao", "ye", "yi", "yin", 
                    "ying", "yo", "yong", "you", "yu", "yuan", "yue", "yun", "za", "zai", "zan", "zang", "zao", "ze", "zei", "zen", 
                    "zeng", "zha", "zhai", "zhan", "zhang", "zhao", "zhe", "zhen", "zheng", "zhi", "zhong", "zhou", "zhu", "zhua", "zhuai", "zhuan", 
                    "zhuang", "zhui", "zhun", "zhuo", "zi", "zong", "zou", "zu", "zuan", "zui", "zun", "zuo"
                 };
                byte[] bytes = new byte[2];
                string str = "";
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                char[] chArray = input.ToCharArray();
                for (int i = 0; i < chArray.Length; i++)
                {
                    bytes = Encoding.Default.GetBytes(chArray[i].ToString());
                    num2 = bytes[0];
                    num3 = bytes[1];
                    num = ((num2 * 0x100) + num3) - 0x10000;
                    if ((num > 0) && (num < 160))
                    {
                        str = str + chArray[i];
                    }
                    else
                    {
                        for (int j = numArray.Length - 1; j >= 0; j--)
                        {
                            if (numArray[j] <= num)
                            {
                                str = str + strArray[j];
                                break;
                            }
                        }
                    }
                }
                return str;
            }

            public static string ToPinYinFirstCharacter(string input)
            {
                int[] numArray = new int[] { 
                    0xb0a1, 0xb0c5, 0xb2c1, 0xb4ee, 0xb6ea, 0xb7a2, 0xb8c1, 0xb9fe, 0xbbf7, 0xbbf7, 0xbfa6, 0xc0ac, 0xc2e8, 0xc4c3, 0xc5b6, 0xc5be, 
                    0xc6da, 0xc8bb, 0xc8f6, 0xcbfa, 0xcdda, 0xcdda, 0xcdda, 0xcef4, 0xd1b9, 0xd4d1
                 };
                string str = "";
                for (int i = 0; i < input.Length; i++)
                {
                    char ch = input[i];
                    byte[] bytes = Encoding.Default.GetBytes(ch.ToString());
                    if (bytes.Length >= 2)
                    {
                        int num2 = bytes[0];
                        int num3 = bytes[1];
                        int num4 = (num2 << 8) + num3;
                        for (int j = 0; j < 0x1a; j++)
                        {
                            int num6 = 0xd7fa;
                            if (j != 0x19)
                            {
                                num6 = numArray[j + 1];
                            }
                            if ((numArray[j] <= num4) && (num4 < num6))
                            {
                                str = str + Encoding.Default.GetString(new byte[] { (byte) (0x41 + j) });
                            }
                        }
                    }
                }
                return str;
            }

            public static string ToSimplified(string str)
            {
                CultureInfo info = new CultureInfo("zh-CN", false);
                return Strings.StrConv(str, VbStrConv.SimplifiedChinese, info.LCID);
            }

            public static string ToTraditional(string str)
            {
                CultureInfo info = new CultureInfo("zh-CN", false);
                return Strings.StrConv(str, VbStrConv.TraditionalChinese, info.LCID);
            }
        }

        public class ChineseMoney
        {
            private StringBuilder sb = new StringBuilder();
            private static string digit = "零壹贰叁肆伍陆柒捌玖";
            private bool isPreZero = true;
            private long value;
            public string Fen = "分";
            private bool isAllZero = true;
            public string Jiao = "角";
            private long money100;
            private bool overFlow;
            public string Yuan = "元";

            public ChineseMoney(decimal money)
            {
                try
                {
                    this.money100 = (long)(money * 100M);
                }
                catch
                {
                    this.overFlow = true;
                }
                if (this.money100 == long.MinValue)
                {
                    this.overFlow = true;
                }
            }

            private void ParseSection(bool isJiaoFen)
            {
                string[] strArray = isJiaoFen ? new string[] { this.Fen, this.Jiao } : new string[] { "", "拾", "佰", "仟" };
                this.isAllZero = true;
                for (int i = 0; (i < strArray.Length) && (this.value > 0L); i++)
                {
                    int num2 = (int)(this.value % 10L);
                    if (num2 != 0)
                    {
                        if (this.isPreZero && !this.isAllZero)
                        {
                            this.sb.Append(digit[0]);
                        }
                        this.sb.AppendFormat("{0}{1}", strArray[i], digit[num2]);
                        this.isAllZero = false;
                    }
                    this.isPreZero = num2 == 0;
                    this.value /= 10L;
                }
            }

            public override string ToString()
            {
                if (this.overFlow)
                {
                    return "金额超出范围";
                }
                if (this.money100 == 0L)
                {
                    return this.ZeroString;
                }
                string[] strArray = new string[] { this.Yuan, "万", "亿", "万", "亿亿" };
                this.value = Math.Abs(this.money100);
                this.ParseSection(true);
                for (int i = 0; (i < strArray.Length) && (this.value > 0L); i++)
                {
                    if (this.isPreZero && !this.isAllZero)
                    {
                        this.sb.Append(digit[0]);
                    }
                    if ((i == 4) && this.sb.ToString().EndsWith(strArray[2]))
                    {
                        this.sb.Remove(this.sb.Length - strArray[2].Length, strArray[2].Length);
                    }
                    this.sb.Append(strArray[i]);
                    this.ParseSection(false);
                    if (((i % 2) == 1) && this.isAllZero)
                    {
                        this.sb.Remove(this.sb.Length - strArray[i].Length, strArray[i].Length);
                    }
                }
                if (this.money100 < 0L)
                {
                    this.sb.Append("负");
                }
                return _String.Reverse(this.sb.ToString());
            }

            public string ZeroString
            {
                get
                {
                    return (digit[0] + this.Yuan);
                }
            }
        }
    }
}


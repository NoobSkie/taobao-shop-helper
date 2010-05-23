using System;

namespace SLS.Site.App_Code
{
    public class OptionValue
    {
        public object Value;

        public OptionValue(object value)
        {
            this.Value = value;
        }

        public bool ToBoolean(bool DefaultValue)
        {
            bool flag = DefaultValue;
            try
            {
                flag = Convert.ToBoolean(this.Value);
            }
            catch
            {
            }
            return flag;
        }

        public DateTime ToDateTime(DateTime DefaultValue)
        {
            DateTime time = DefaultValue;
            try
            {
                time = Convert.ToDateTime(this.Value);
            }
            catch
            {
            }
            return time;
        }

        public double ToDouble(double DefaultValue)
        {
            double num = DefaultValue;
            try
            {
                num = Convert.ToDouble(this.Value);
            }
            catch
            {
            }
            return num;
        }

        public int ToInt(int DefaultValue)
        {
            int num = DefaultValue;
            try
            {
                num = Convert.ToInt32(this.Value);
            }
            catch
            {
            }
            return num;
        }

        public long ToLong(long DefaultValue)
        {
            long num = DefaultValue;
            try
            {
                num = Convert.ToInt64(this.Value);
            }
            catch
            {
            }
            return num;
        }

        public short ToShort(short DefaultValue)
        {
            short num = DefaultValue;
            try
            {
                num = Convert.ToInt16(this.Value);
            }
            catch
            {
            }
            return num;
        }

        public string ToString(string DefaultValue)
        {
            string str = DefaultValue;
            try
            {
                str = Convert.ToString(this.Value);
            }
            catch
            {
            }
            return str;
        }
    }
}

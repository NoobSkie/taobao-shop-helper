namespace Shove._Net
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text.RegularExpressions;

    public class IPAddress
    {
        public static string GetPlaceFromIPAddress(long IPAddress, DataSet ds)
        {
            if (ds == null)
            {
                return "读IP地址库错误";
            }
            DataRow[] rowArray = ds.Tables[0].Select("IPStart <= " + IPAddress.ToString() + " and IPEnd >= " + IPAddress.ToString());
            if (rowArray.Length < 1)
            {
                return "未知地址";
            }
            return (rowArray[0]["Country"].ToString().Trim() + rowArray[0]["City"].ToString().Trim());
        }

        public static string GetPlaceFromIPAddress(long IPAddress, string DataFileName)
        {
            DataSet set = new DataSet();
            try
            {
                set.ReadXml(DataFileName);
            }
            catch
            {
                return "读IP地址库错误";
            }
            DataRow[] rowArray = set.Tables[0].Select("IPStart <= " + IPAddress.ToString() + " and IPEnd >= " + IPAddress.ToString());
            if (rowArray.Length < 1)
            {
                return "未知地址";
            }
            string str = rowArray[0]["Country"].ToString().Trim() + rowArray[0]["City"].ToString().Trim();
            set.Dispose();
            return str;
        }

        public static string GetPlaceFromIPAddress(string sIPAddress, DataSet ds)
        {
            if (sIPAddress == "127.0.0.1")
            {
                return "本机地址";
            }
            if (ds == null)
            {
                return "读IP地址库错误";
            }
            return GetPlaceFromIPAddress(GetIPAddress(sIPAddress), ds);
        }

        public static string GetPlaceFromIPAddress(string sIPAddress, string DataFileName)
        {
            if (sIPAddress == "127.0.0.1")
            {
                return "本机地址";
            }
            return GetPlaceFromIPAddress(GetIPAddress(sIPAddress), DataFileName);
        }

        public static string GetPlaceFromIPAddress(long IPAddress, SqlConnection conn, string IPTable)
        {
            if (conn.State != ConnectionState.Open)
            {
                return "读IP数据库错误";
            }
            SqlCommand command = new SqlCommand("select top 1 ltrim(rtrim(isnull(Country, ''))) + ltrim(rtrim(isnull(City, ''))) from " + IPTable + " where IPStart <= " + IPAddress.ToString() + " and IPEnd >= " + IPAddress.ToString(), conn);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
            }
            catch
            {
                return "读IP数据库错误";
            }
            if (!reader.Read())
            {
                reader.Close();
                return "未知地址";
            }
            string str = reader[0].ToString();
            reader.Close();
            return str;
        }

        public static string GetPlaceFromIPAddress(string sIPAddress, SqlConnection conn, string IPTable)
        {
            if (sIPAddress == "127.0.0.1")
            {
                return "本机地址";
            }
            if (conn.State != ConnectionState.Open)
            {
                return "读IP数据库错误";
            }
            return GetPlaceFromIPAddress(GetIPAddress(sIPAddress), conn, IPTable);
        }

        public static long GetIPAddress(string IPAddress)
        {
            long num = 0L;
            IPAddress = IPAddress.Replace('.', '#');
            string[] strArray = Regex.Split(IPAddress, "#", RegexOptions.IgnoreCase);
            try
            {
                long num2 = Convert.ToInt64(strArray[0]);
                long num3 = Convert.ToInt64(strArray[1]);
                long num4 = Convert.ToInt64(strArray[2]);
                long num5 = Convert.ToInt64(strArray[3]);
                num = ((num2 * 0x100L) * 0x100L) * 0x100L;
                num += (num3 * 0x100L) * 0x100L;
                num += num4 * 0x100L;
                num += num5;
            }
            catch
            {
            }
            return num;
        }
    }
}


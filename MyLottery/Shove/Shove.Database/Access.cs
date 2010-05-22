namespace Shove.Database
{
    using System;
    using System.Data.OleDb;
    using System.Web;

    public class Access
    {
        public static OleDbConnection CreateDataConnection()
        {
            return CreateDataConnection("".Replace("{0}", AppDomain.CurrentDomain.BaseDirectory));
        }

        public static OleDbConnection CreateDataConnection(string ConnectionString)
        {
            OleDbConnection connection = new OleDbConnection(ConnectionString);
            try
            {
                connection.Open();
            }
            catch
            {
                return null;
            }
            return connection;
        }

        public static string GetConnectString()
        {
            return GetConnectString(HttpContext.Current.Server.MapPath(""), "Admin", "");
        }

        public static string GetConnectString(string DatabaseName, string UID, string Password)
        {
            return string.Format("Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password={0};Data Source=\"{1}\";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=\"Microsoft.Jet.OLEDB.4.0\";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID={2};Jet OLEDB:Encrypt Database=False", Password, DatabaseName, UID);
        }
    }
}


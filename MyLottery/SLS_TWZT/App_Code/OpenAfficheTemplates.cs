using Shove.Database;
using System;
using System.Data;
using System.Reflection;

public class OpenAfficheTemplates
{
    public string this[int LotteryID]
    {
        get
        {
            object obj2 = MSSQL.ExecuteScalar("select OpenAfficheTemplate from T_Lotteries where [ID] = " + LotteryID.ToString(), new MSSQL.Parameter[0]);
            if (obj2 == null)
            {
                return "";
            }
            return obj2.ToString();
        }
        set
        {
            MSSQL.ExecuteNonQuery("update T_Lotteries set OpenAfficheTemplate = @OpenAfficheTemplate where [ID] = " + LotteryID.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("OpenAfficheTemplate", SqlDbType.VarChar, 0, ParameterDirection.Input, value) });
        }
    }
}


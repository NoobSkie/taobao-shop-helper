using DAL;
using Shove._Web;
using System;
using System.Collections;
using System.Data;

public class TheadChart
{
    public DataTable SYDJ_DWZS(int DaySpan, int Type, int number, ref int ReturnValue, ref string returnDescription)
    {
        DataSet ds = null;
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        DateTime now = DateTime.Now;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SYDJ_DWZS");
        if (cacheAsDataTable == null)
        {
            Procedures.P_TrendChart_11YDJ_WINNUM(ref ds, now, 0x3eL, ref ReturnValue, ref returnDescription);
            if (ds == null)
            {
                return cacheAsDataTable;
            }
            cacheAsDataTable = ds.Tables[0];
            cacheAsDataTable.Columns.Add("b1", typeof(int));
            cacheAsDataTable.Columns.Add("b2", typeof(int));
            cacheAsDataTable.Columns.Add("b3", typeof(int));
            cacheAsDataTable.Columns.Add("b4", typeof(int));
            cacheAsDataTable.Columns.Add("b5", typeof(int));
            cacheAsDataTable.Columns.Add("b6", typeof(int));
            cacheAsDataTable.Columns.Add("b7", typeof(int));
            cacheAsDataTable.Columns.Add("b8", typeof(int));
            cacheAsDataTable.Columns.Add("b9", typeof(int));
            cacheAsDataTable.Columns.Add("b10", typeof(int));
            cacheAsDataTable.Columns.Add("b11", typeof(int));
            cacheAsDataTable.Columns.Add("sb0", typeof(int));
            cacheAsDataTable.Columns.Add("sb1", typeof(int));
            cacheAsDataTable.Columns.Add("sb2", typeof(int));
            cacheAsDataTable.Columns.Add("sb3", typeof(int));
            cacheAsDataTable.Columns.Add("sb4", typeof(int));
            cacheAsDataTable.Columns.Add("sb5", typeof(int));
            cacheAsDataTable.Columns.Add("yb0", typeof(int));
            cacheAsDataTable.Columns.Add("yb1", typeof(int));
            cacheAsDataTable.Columns.Add("yb2", typeof(int));
            cacheAsDataTable.Columns.Add("cb0", typeof(int));
            cacheAsDataTable.Columns.Add("cb1", typeof(int));
            cacheAsDataTable.Columns.Add("cb2", typeof(int));
            cacheAsDataTable.Columns.Add("cb3", typeof(int));
            for (int i = 0; i < cacheAsDataTable.Rows.Count; i++)
            {
                for (int j = 8; j <= 0x12; j++)
                {
                    if (i == 0)
                    {
                        if ((j - 7) == Convert.ToInt32(cacheAsDataTable.Rows[i][number]))
                        {
                            cacheAsDataTable.Rows[i][j] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][j] = 1;
                        }
                    }
                    else if ((j - 7) == Convert.ToInt32(cacheAsDataTable.Rows[i][number]))
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][j]) > 0)
                        {
                            cacheAsDataTable.Rows[i][j] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][j] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][j]) - 1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][j]) > 0)
                    {
                        cacheAsDataTable.Rows[i][j] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][j]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][j] = 1;
                    }
                }
                if (i == 0)
                {
                    if (((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 1) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 3)) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 5))
                    {
                        cacheAsDataTable.Rows[i][0x13] = -1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x13] = 1;
                    }
                    if (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 2)
                    {
                        cacheAsDataTable.Rows[i][20] = -1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][20] = 1;
                    }
                    if (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 4)
                    {
                        cacheAsDataTable.Rows[i][0x15] = -1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x15] = 1;
                    }
                    if ((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 7) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 11))
                    {
                        cacheAsDataTable.Rows[i][0x16] = -1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x16] = 1;
                    }
                    if (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 9)
                    {
                        cacheAsDataTable.Rows[i][0x17] = -1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x17] = 1;
                    }
                    if (((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 6) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 8)) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 10))
                    {
                        cacheAsDataTable.Rows[i][0x18] = -1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x18] = 1;
                    }
                    if (((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 3) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 6)) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 9))
                    {
                        cacheAsDataTable.Rows[i][0x19] = -1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x19] = 1;
                    }
                    if (((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 1) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 4)) || ((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 7) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 10)))
                    {
                        cacheAsDataTable.Rows[i][0x1a] = -1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x1a] = 1;
                    }
                    if (((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 2) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 5)) || ((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 8) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 11)))
                    {
                        cacheAsDataTable.Rows[i][0x1b] = -1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x1b] = 1;
                    }
                    cacheAsDataTable.Rows[i][0x1c] = 1;
                    cacheAsDataTable.Rows[i][0x1d] = 1;
                    cacheAsDataTable.Rows[i][30] = 1;
                    cacheAsDataTable.Rows[i][0x1f] = 1;
                }
                else
                {
                    if (((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 1) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 3)) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 5))
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x13]) < 0)
                        {
                            cacheAsDataTable.Rows[i][0x13] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x13]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][0x13] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x13]) > 0)
                    {
                        cacheAsDataTable.Rows[i][0x13] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x13]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x13] = 1;
                    }
                    if (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 2)
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][20]) < 0)
                        {
                            cacheAsDataTable.Rows[i][20] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][20]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][20] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][20]) > 0)
                    {
                        cacheAsDataTable.Rows[i][20] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][20]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][20] = 1;
                    }
                    if (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 4)
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x15]) < 0)
                        {
                            cacheAsDataTable.Rows[i][0x15] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x15]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][0x15] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x15]) > 0)
                    {
                        cacheAsDataTable.Rows[i][0x15] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x15]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x15] = 1;
                    }
                    if ((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 7) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 11))
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x16]) < 0)
                        {
                            cacheAsDataTable.Rows[i][0x16] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x16]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][0x16] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x16]) > 0)
                    {
                        cacheAsDataTable.Rows[i][0x16] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x16]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x16] = 1;
                    }
                    if (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 9)
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x17]) < 0)
                        {
                            cacheAsDataTable.Rows[i][0x17] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x17]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][0x17] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x17]) > 0)
                    {
                        cacheAsDataTable.Rows[i][0x17] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x17]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x17] = 1;
                    }
                    if (((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 6) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 8)) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 10))
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x18]) < 0)
                        {
                            cacheAsDataTable.Rows[i][0x18] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x18]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][0x18] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x18]) > 0)
                    {
                        cacheAsDataTable.Rows[i][0x18] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x18]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x18] = 1;
                    }
                    if (((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 3) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 6)) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 9))
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x19]) < 0)
                        {
                            cacheAsDataTable.Rows[i][0x19] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x19]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][0x19] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x19]) > 0)
                    {
                        cacheAsDataTable.Rows[i][0x19] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x19]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x19] = 1;
                    }
                    if (((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 1) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 4)) || ((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 7) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 10)))
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1a]) < 0)
                        {
                            cacheAsDataTable.Rows[i][0x1a] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1a]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][0x1a] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1a]) > 0)
                    {
                        cacheAsDataTable.Rows[i][0x1a] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1a]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x1a] = 1;
                    }
                    if (((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 2) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 5)) || ((Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 8) || (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == 11)))
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1b]) < 0)
                        {
                            cacheAsDataTable.Rows[i][0x1b] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1b]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][0x1b] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1b]) > 0)
                    {
                        cacheAsDataTable.Rows[i][0x1b] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1b]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x1b] = 1;
                    }
                    if (Convert.ToInt32(cacheAsDataTable.Rows[i][number]) == Convert.ToInt32(cacheAsDataTable.Rows[i - 1][number]))
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1c]) < 0)
                        {
                            cacheAsDataTable.Rows[i][0x1c] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1c]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][0x1c] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1c]) > 0)
                    {
                        cacheAsDataTable.Rows[i][0x1c] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1c]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x1c] = 1;
                    }
                    if (Math.Abs((int)(Convert.ToInt32(cacheAsDataTable.Rows[i][number]) - Convert.ToInt32(cacheAsDataTable.Rows[i - 1][number]))) == 1)
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1d]) < 0)
                        {
                            cacheAsDataTable.Rows[i][0x1d] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1d]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][0x1d] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1d]) > 0)
                    {
                        cacheAsDataTable.Rows[i][0x1d] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1d]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x1d] = 1;
                    }
                    if (Math.Abs((int)(Convert.ToInt32(cacheAsDataTable.Rows[i][number]) - Convert.ToInt32(cacheAsDataTable.Rows[i - 1][number]))) == 2)
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][30]) < 0)
                        {
                            cacheAsDataTable.Rows[i][30] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][30]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][30] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][30]) > 0)
                    {
                        cacheAsDataTable.Rows[i][30] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][30]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][30] = 1;
                    }
                    if (Math.Abs((int)(Convert.ToInt32(cacheAsDataTable.Rows[i][number]) - Convert.ToInt32(cacheAsDataTable.Rows[i - 1][number]))) > 2)
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1f]) < 0)
                        {
                            cacheAsDataTable.Rows[i][0x1f] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1f]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][0x1f] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1f]) > 0)
                    {
                        cacheAsDataTable.Rows[i][0x1f] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][0x1f]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][0x1f] = 1;
                    }
                }
            }
        }
        table2 = cacheAsDataTable.Clone();
        DataRow[] rowArray = null;
        if (Type == 1)
        {
            rowArray = cacheAsDataTable.Select("DaySpan <=" + DaySpan, "ID ASC");
        }
        else
        {
            rowArray = cacheAsDataTable.Select("DaySpan =" + DaySpan, "ID ASC");
        }
        foreach (DataRow row in rowArray)
        {
            table2.Rows.Add(row.ItemArray);
        }
        table2.Columns.Remove("ID");
        table2.Columns.Remove("DaySpan");
        return table2;
    }

    public DataTable SYDJ_FBZS(int DaySpan, int Type, ref int ReturnValue, ref string returnDescription)
    {
        DataSet ds = null;
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        DateTime now = DateTime.Now;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SYDJ_FBZS");
        if (cacheAsDataTable == null)
        {
            Procedures.P_TrendChart_11YDJ_WINNUM(ref ds, now, 0x3eL, ref ReturnValue, ref returnDescription);
            if (ds == null)
            {
                return cacheAsDataTable;
            }
            cacheAsDataTable = ds.Tables[0];
            cacheAsDataTable.Columns.Add("b1", typeof(int));
            cacheAsDataTable.Columns.Add("b2", typeof(int));
            cacheAsDataTable.Columns.Add("b3", typeof(int));
            cacheAsDataTable.Columns.Add("b4", typeof(int));
            cacheAsDataTable.Columns.Add("b5", typeof(int));
            cacheAsDataTable.Columns.Add("b6", typeof(int));
            cacheAsDataTable.Columns.Add("b7", typeof(int));
            cacheAsDataTable.Columns.Add("b8", typeof(int));
            cacheAsDataTable.Columns.Add("b9", typeof(int));
            cacheAsDataTable.Columns.Add("b10", typeof(int));
            cacheAsDataTable.Columns.Add("b11", typeof(int));
            cacheAsDataTable.Columns.Add("jb0", typeof(int));
            cacheAsDataTable.Columns.Add("jb1", typeof(int));
            cacheAsDataTable.Columns.Add("jb2", typeof(int));
            cacheAsDataTable.Columns.Add("jb3", typeof(int));
            cacheAsDataTable.Columns.Add("jb4", typeof(int));
            cacheAsDataTable.Columns.Add("jb5", typeof(int));
            cacheAsDataTable.Columns.Add("xb0", typeof(int));
            cacheAsDataTable.Columns.Add("xb1", typeof(int));
            cacheAsDataTable.Columns.Add("xb2", typeof(int));
            cacheAsDataTable.Columns.Add("xb3", typeof(int));
            cacheAsDataTable.Columns.Add("xb4", typeof(int));
            cacheAsDataTable.Columns.Add("xb5", typeof(int));
            cacheAsDataTable.Columns.Add("zb0", typeof(int));
            cacheAsDataTable.Columns.Add("zb1", typeof(int));
            cacheAsDataTable.Columns.Add("zb2", typeof(int));
            cacheAsDataTable.Columns.Add("zb3", typeof(int));
            cacheAsDataTable.Columns.Add("zb4", typeof(int));
            cacheAsDataTable.Columns.Add("zb5", typeof(int));
            for (int i = 0; i < cacheAsDataTable.Rows.Count; i++)
            {
                for (int j = 8; j <= 0x12; j++)
                {
                    if (i == 0)
                    {
                        if ((((j - 7) == Convert.ToInt32(cacheAsDataTable.Rows[i][1])) || ((j - 7) == Convert.ToInt32(cacheAsDataTable.Rows[i][2]))) || ((((j - 7) == Convert.ToInt32(cacheAsDataTable.Rows[i][3])) || ((j - 7) == Convert.ToInt32(cacheAsDataTable.Rows[i][4]))) || ((j - 7) == Convert.ToInt32(cacheAsDataTable.Rows[i][5]))))
                        {
                            cacheAsDataTable.Rows[i][j] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][j] = 1;
                        }
                    }
                    else if ((((j - 7) == Convert.ToInt32(cacheAsDataTable.Rows[i][1])) || ((j - 7) == Convert.ToInt32(cacheAsDataTable.Rows[i][2]))) || ((((j - 7) == Convert.ToInt32(cacheAsDataTable.Rows[i][3])) || ((j - 7) == Convert.ToInt32(cacheAsDataTable.Rows[i][4]))) || ((j - 7) == Convert.ToInt32(cacheAsDataTable.Rows[i][5]))))
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][j]) > 0)
                        {
                            cacheAsDataTable.Rows[i][j] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][j] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][j]) - 1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][j]) > 0)
                    {
                        cacheAsDataTable.Rows[i][j] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][j]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[i][j] = 1;
                    }
                }
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                if (i == 0)
                {
                    for (int k = 1; k <= 5; k++)
                    {
                        switch (cacheAsDataTable.Rows[i][k].ToString())
                        {
                            case "01":
                                num3++;
                                num4++;
                                num5++;
                                break;

                            case "02":
                                num4++;
                                num5++;
                                break;

                            case "03":
                                num3++;
                                num4++;
                                num5++;
                                break;

                            case "04":
                                num4++;
                                break;

                            case "05":
                                num3++;
                                num5++;
                                num4++;
                                break;

                            case "07":
                                num3++;
                                num5++;
                                break;

                            case "09":
                                num3++;
                                break;

                            case "11":
                                num3++;
                                num5++;
                                break;
                        }
                    }
                    for (int m = 0; m <= 5; m++)
                    {
                        if (m != num3)
                        {
                            cacheAsDataTable.Rows[i][m + 0x13] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][m + 0x13] = -1;
                        }
                        if (m != num4)
                        {
                            cacheAsDataTable.Rows[i][m + 0x19] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][m + 0x19] = -1;
                        }
                        if (m != num5)
                        {
                            cacheAsDataTable.Rows[i][m + 0x1f] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][m + 0x1f] = -1;
                        }
                    }
                }
                else
                {
                    for (int n = 1; n <= 5; n++)
                    {
                        switch (cacheAsDataTable.Rows[i][n].ToString())
                        {
                            case "01":
                                num3++;
                                num4++;
                                num5++;
                                break;

                            case "02":
                                num4++;
                                num5++;
                                break;

                            case "03":
                                num3++;
                                num4++;
                                num5++;
                                break;

                            case "04":
                                num4++;
                                break;

                            case "05":
                                num3++;
                                num5++;
                                num4++;
                                break;

                            case "07":
                                num3++;
                                num5++;
                                break;

                            case "09":
                                num3++;
                                break;

                            case "11":
                                num3++;
                                num5++;
                                break;
                        }
                    }
                    for (int num11 = 0; num11 <= 5; num11++)
                    {
                        if (num11 != num3)
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][num11 + 0x13]) <= 0)
                            {
                                cacheAsDataTable.Rows[i][num11 + 0x13] = 1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[i][num11 + 0x13] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][num11 + 0x13]) + 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][num11 + 0x13]) > 0)
                        {
                            cacheAsDataTable.Rows[i][num11 + 0x13] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][num11 + 0x13] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][num11 + 0x13]) - 1;
                        }
                        if (num11 != num4)
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][num11 + 0x19]) <= 0)
                            {
                                cacheAsDataTable.Rows[i][num11 + 0x19] = 1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[i][num11 + 0x19] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][num11 + 0x19]) + 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][num11 + 0x19]) > 0)
                        {
                            cacheAsDataTable.Rows[i][num11 + 0x19] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][num11 + 0x19] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][num11 + 0x19]) - 1;
                        }
                        if (num11 != num5)
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][num11 + 0x1f]) <= 0)
                            {
                                cacheAsDataTable.Rows[i][num11 + 0x1f] = 1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[i][num11 + 0x1f] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][num11 + 0x1f]) + 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[i - 1][num11 + 0x1f]) > 0)
                        {
                            cacheAsDataTable.Rows[i][num11 + 0x1f] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[i][num11 + 0x1f] = Convert.ToInt32(cacheAsDataTable.Rows[i - 1][num11 + 0x1f]) - 1;
                        }
                    }
                }
            }
            Cache.SetCache("SYDJ_FBZS", cacheAsDataTable, 600);
        }
        table2 = cacheAsDataTable.Clone();
        DataRow[] rowArray = null;
        if (Type == 1)
        {
            rowArray = cacheAsDataTable.Select("DaySpan <=" + DaySpan, "ID ASC");
        }
        else
        {
            rowArray = cacheAsDataTable.Select("DaySpan =" + DaySpan, "ID ASC");
        }
        foreach (DataRow row in rowArray)
        {
            table2.Rows.Add(row.ItemArray);
        }
        table2.Columns.Remove("ID");
        table2.Columns.Remove("DaySpan");
        return table2;
    }

    public DataTable SYDJ_HZFB(int DaySpan, int Type, ref int ReturnValue, ref string returnDescription)
    {
        DataSet ds = null;
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        DateTime now = DateTime.Now;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SYDJ_HZFB");
        if (cacheAsDataTable == null)
        {
            Procedures.P_TrendChart_11YDJ_WINNUM(ref ds, now, 0x3eL, ref ReturnValue, ref returnDescription);
            if (ds == null)
            {
                return cacheAsDataTable;
            }
            cacheAsDataTable = ds.Tables[0];
            for (int i = 15; i <= 0x2d; i++)
            {
                cacheAsDataTable.Columns.Add("b" + i.ToString(), typeof(int));
            }
            for (int j = 0; j <= 9; j++)
            {
                cacheAsDataTable.Columns.Add("b" + j.ToString(), typeof(int));
            }
            for (int k = 0; k < cacheAsDataTable.Rows.Count; k++)
            {
                for (int m = 15; m <= 0x2d; m++)
                {
                    if (k == 0)
                    {
                        if (m == ((((Convert.ToInt32(cacheAsDataTable.Rows[k][1]) + Convert.ToInt32(cacheAsDataTable.Rows[k][2])) + Convert.ToInt32(cacheAsDataTable.Rows[k][3])) + Convert.ToInt32(cacheAsDataTable.Rows[k][4])) + Convert.ToInt32(cacheAsDataTable.Rows[k][5])))
                        {
                            cacheAsDataTable.Rows[k][m - 7] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[k][m - 7] = 1;
                        }
                    }
                    else if (m == ((((Convert.ToInt32(cacheAsDataTable.Rows[k][1]) + Convert.ToInt32(cacheAsDataTable.Rows[k][2])) + Convert.ToInt32(cacheAsDataTable.Rows[k][3])) + Convert.ToInt32(cacheAsDataTable.Rows[k][4])) + Convert.ToInt32(cacheAsDataTable.Rows[k][5])))
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[k - 1][m - 7]) < 0)
                        {
                            cacheAsDataTable.Rows[k][m - 7] = Convert.ToInt32(cacheAsDataTable.Rows[k - 1][m - 7]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[k][m - 7] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[k - 1][m - 7]) > 0)
                    {
                        cacheAsDataTable.Rows[k][m - 7] = Convert.ToInt32(cacheAsDataTable.Rows[k - 1][m - 7]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[k][m - 7] = 1;
                    }
                }
                for (int n = 0; n < 10; n++)
                {
                    if (k == 0)
                    {
                        if (n.ToString() == Convert.ToString((int)((((Convert.ToInt32(cacheAsDataTable.Rows[k][1]) + Convert.ToInt32(cacheAsDataTable.Rows[k][2])) + Convert.ToInt32(cacheAsDataTable.Rows[k][3])) + Convert.ToInt32(cacheAsDataTable.Rows[k][4])) + Convert.ToInt32(cacheAsDataTable.Rows[k][5]))).Substring(1))
                        {
                            cacheAsDataTable.Rows[k][n + 0x27] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[k][n + 0x27] = 1;
                        }
                    }
                    else if (n.ToString() == Convert.ToString((int)((((Convert.ToInt32(cacheAsDataTable.Rows[k][1]) + Convert.ToInt32(cacheAsDataTable.Rows[k][2])) + Convert.ToInt32(cacheAsDataTable.Rows[k][3])) + Convert.ToInt32(cacheAsDataTable.Rows[k][4])) + Convert.ToInt32(cacheAsDataTable.Rows[k][5]))).Substring(1))
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[k - 1][n + 0x27]) < 0)
                        {
                            cacheAsDataTable.Rows[k][n + 0x27] = Convert.ToInt32(cacheAsDataTable.Rows[k - 1][n + 0x27]) - 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[k][n + 0x27] = -1;
                        }
                    }
                    else if (Convert.ToInt32(cacheAsDataTable.Rows[k - 1][n + 0x27]) > 0)
                    {
                        cacheAsDataTable.Rows[k][n + 0x27] = Convert.ToInt32(cacheAsDataTable.Rows[k - 1][n + 0x27]) + 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[k][n + 0x27] = 1;
                    }
                }
            }
            Cache.SetCache("SYDJ_HZFB", cacheAsDataTable, 600);
        }
        table2 = cacheAsDataTable.Clone();
        DataRow[] rowArray = null;
        if (Type == 1)
        {
            rowArray = cacheAsDataTable.Select("DaySpan <=" + DaySpan, "ID ASC");
        }
        else
        {
            rowArray = cacheAsDataTable.Select("DaySpan =" + DaySpan, "ID ASC");
        }
        foreach (DataRow row in rowArray)
        {
            table2.Rows.Add(row.ItemArray);
        }
        table2.Columns.Remove("ID");
        table2.Columns.Remove("DaySpan");
        return table2;
    }

    public DataTable SYDJ_Q2FBT(int DaySpan, int Type, ref int ReturnValue, ref string returnDescription)
    {
        DataSet ds = null;
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        DateTime now = DateTime.Now;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SYDJ_Q2FBT");
        if (cacheAsDataTable == null)
        {
            Procedures.P_TrendChart_11YDJ_WINNUM(ref ds, now, 0x3eL, ref ReturnValue, ref returnDescription);
            if (ds == null)
            {
                return cacheAsDataTable;
            }
            cacheAsDataTable = ds.Tables[0];
            for (int i = 1; i <= 11; i++)
            {
                cacheAsDataTable.Columns.Add("b" + i.ToString(), typeof(int));
            }
            for (int j = 1; j <= 11; j++)
            {
                cacheAsDataTable.Columns.Add("bb" + j.ToString(), typeof(int));
            }
            for (int k = 1; k <= 11; k++)
            {
                cacheAsDataTable.Columns.Add("bc" + k.ToString(), typeof(int));
            }
            for (int m = 0; m < cacheAsDataTable.Rows.Count; m++)
            {
                if (m == 0)
                {
                    for (int n = 0; n < 11; n++)
                    {
                        if ((n == (Convert.ToInt32(cacheAsDataTable.Rows[m][1]) - 1)) || (n == (Convert.ToInt32(cacheAsDataTable.Rows[m][2]) - 1)))
                        {
                            cacheAsDataTable.Rows[m][n + 8] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][n + 8] = 1;
                        }
                    }
                    for (int num6 = 0; num6 < 11; num6++)
                    {
                        if (num6 == (Convert.ToInt32(cacheAsDataTable.Rows[m][1]) - 1))
                        {
                            cacheAsDataTable.Rows[m][num6 + 0x13] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num6 + 0x13] = 1;
                        }
                    }
                    for (int num7 = 0; num7 < 11; num7++)
                    {
                        if (num7 == (Convert.ToInt32(cacheAsDataTable.Rows[m][2]) - 1))
                        {
                            cacheAsDataTable.Rows[m][num7 + 30] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num7 + 30] = 1;
                        }
                    }
                }
                else
                {
                    for (int num8 = 0; num8 < 11; num8++)
                    {
                        if ((num8 == (Convert.ToInt32(cacheAsDataTable.Rows[m][1]) - 1)) || (num8 == (Convert.ToInt32(cacheAsDataTable.Rows[m][2]) - 1)))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num8 + 8]) < 0)
                            {
                                cacheAsDataTable.Rows[m][num8 + 8] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num8 + 8]) - 1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[m][num8 + 8] = -1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num8 + 8]) > 0)
                        {
                            cacheAsDataTable.Rows[m][num8 + 8] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num8 + 8]) + 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num8 + 8] = 1;
                        }
                    }
                    for (int num9 = 0; num9 < 11; num9++)
                    {
                        if (num9 == (Convert.ToInt32(cacheAsDataTable.Rows[m][1]) - 1))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num9 + 0x13]) < 0)
                            {
                                cacheAsDataTable.Rows[m][num9 + 0x13] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num9 + 0x13]) - 1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[m][num9 + 0x13] = -1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num9 + 0x13]) > 0)
                        {
                            cacheAsDataTable.Rows[m][num9 + 0x13] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num9 + 0x13]) + 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num9 + 0x13] = 1;
                        }
                    }
                    for (int num10 = 0; num10 < 11; num10++)
                    {
                        if (num10 == (Convert.ToInt32(cacheAsDataTable.Rows[m][2]) - 1))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num10 + 30]) < 0)
                            {
                                cacheAsDataTable.Rows[m][num10 + 30] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num10 + 30]) - 1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[m][num10 + 30] = -1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num10 + 30]) > 0)
                        {
                            cacheAsDataTable.Rows[m][num10 + 30] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num10 + 30]) + 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num10 + 30] = 1;
                        }
                    }
                }
            }
            Cache.SetCache("SYDJ_Q2FBT", cacheAsDataTable, 600);
        }
        table2 = cacheAsDataTable.Clone();
        DataRow[] rowArray = null;
        if (Type == 1)
        {
            rowArray = cacheAsDataTable.Select("DaySpan <=" + DaySpan, "ID ASC");
        }
        else
        {
            rowArray = cacheAsDataTable.Select("DaySpan =" + DaySpan, "ID ASC");
        }
        foreach (DataRow row in rowArray)
        {
            table2.Rows.Add(row.ItemArray);
        }
        table2.Columns.Remove("ID");
        table2.Columns.Remove("DaySpan");
        return table2;
    }

    public DataTable SYDJ_Q2HZ(int DaySpan, int Type, ref int ReturnValue, ref string returnDescription)
    {
        DataSet ds = null;
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        DateTime now = DateTime.Now;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SYDJ_Q2HZ");
        if (cacheAsDataTable == null)
        {
            Procedures.P_TrendChart_11YDJ_WINNUM(ref ds, now, 0x3eL, ref ReturnValue, ref returnDescription);
            if (ds == null)
            {
                return cacheAsDataTable;
            }
            cacheAsDataTable = ds.Tables[0];
            for (int i = 3; i <= 0x15; i++)
            {
                cacheAsDataTable.Columns.Add("b" + i.ToString(), typeof(int));
            }
            for (int j = 0; j <= 9; j++)
            {
                cacheAsDataTable.Columns.Add("bb" + j.ToString(), typeof(int));
            }
            for (int k = 0; k <= 2; k++)
            {
                cacheAsDataTable.Columns.Add("bc3" + k.ToString(), typeof(int));
            }
            for (int m = 0; m <= 3; m++)
            {
                cacheAsDataTable.Columns.Add("bc4" + m.ToString(), typeof(int));
            }
            for (int n = 0; n <= 4; n++)
            {
                cacheAsDataTable.Columns.Add("bc5" + n.ToString(), typeof(int));
            }
            cacheAsDataTable.Columns.Add("bd1", typeof(int));
            cacheAsDataTable.Columns.Add("bd2", typeof(int));
            cacheAsDataTable.Columns.Add("bj1", typeof(int));
            cacheAsDataTable.Columns.Add("bj2", typeof(int));
            for (int num6 = 0; num6 < cacheAsDataTable.Rows.Count; num6++)
            {
                if (num6 == 0)
                {
                    for (int num7 = 3; num7 <= 0x15; num7++)
                    {
                        if (num7 == (Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])))
                        {
                            cacheAsDataTable.Rows[num6][num7 + 5] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num7 + 5] = 1;
                        }
                    }
                    for (int num8 = 0; num8 <= 9; num8++)
                    {
                        if (num8 == ((Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])) % 10))
                        {
                            cacheAsDataTable.Rows[num6][num8 + 0x1b] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num8 + 0x1b] = 1;
                        }
                    }
                    for (int num9 = 0; num9 < 3; num9++)
                    {
                        if (num9 == ((Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])) % 3))
                        {
                            cacheAsDataTable.Rows[num6][num9 + 0x25] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num9 + 0x25] = 1;
                        }
                    }
                    for (int num10 = 0; num10 < 4; num10++)
                    {
                        if (num10 == ((Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])) % 4))
                        {
                            cacheAsDataTable.Rows[num6][num10 + 40] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num10 + 40] = 1;
                        }
                    }
                    for (int num11 = 0; num11 < 5; num11++)
                    {
                        if (num11 == ((Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])) % 5))
                        {
                            cacheAsDataTable.Rows[num6][num11 + 0x2c] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num11 + 0x2c] = 1;
                        }
                    }
                    if ((Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])) > 11)
                    {
                        cacheAsDataTable.Rows[num6][0x31] = -1;
                        cacheAsDataTable.Rows[num6][50] = 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[num6][0x31] = 1;
                        cacheAsDataTable.Rows[num6][50] = -1;
                    }
                    if (((Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])) % 2) == 1)
                    {
                        cacheAsDataTable.Rows[num6][0x33] = -1;
                        cacheAsDataTable.Rows[num6][0x34] = 1;
                    }
                    else
                    {
                        cacheAsDataTable.Rows[num6][0x33] = 1;
                        cacheAsDataTable.Rows[num6][0x34] = -1;
                    }
                }
                else
                {
                    for (int num12 = 3; num12 <= 0x15; num12++)
                    {
                        if (num12 == (Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num12 + 5]) > 0)
                            {
                                cacheAsDataTable.Rows[num6][num12 + 5] = -1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[num6][num12 + 5] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num12 + 5]) - 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num12 + 5]) < 0)
                        {
                            cacheAsDataTable.Rows[num6][num12 + 5] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num12 + 5] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num12 + 5]) + 1;
                        }
                    }
                    for (int num13 = 0; num13 <= 9; num13++)
                    {
                        if (num13 == ((Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])) % 10))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num13 + 0x1b]) > 0)
                            {
                                cacheAsDataTable.Rows[num6][num13 + 0x1b] = -1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[num6][num13 + 0x1b] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num13 + 0x1b]) - 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num13 + 0x1b]) < 0)
                        {
                            cacheAsDataTable.Rows[num6][num13 + 0x1b] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num13 + 0x1b] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num13 + 0x1b]) + 1;
                        }
                    }
                    for (int num14 = 0; num14 < 3; num14++)
                    {
                        if (num14 == ((Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])) % 3))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num14 + 0x25]) > 0)
                            {
                                cacheAsDataTable.Rows[num6][num14 + 0x25] = -1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[num6][num14 + 0x25] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num14 + 0x25]) - 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num14 + 0x25]) < 0)
                        {
                            cacheAsDataTable.Rows[num6][num14 + 0x25] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num14 + 0x25] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num14 + 0x25]) + 1;
                        }
                    }
                    for (int num15 = 0; num15 < 4; num15++)
                    {
                        if (num15 == ((Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])) % 4))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num15 + 40]) > 0)
                            {
                                cacheAsDataTable.Rows[num6][num15 + 40] = -1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[num6][num15 + 40] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num15 + 40]) - 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num15 + 40]) < 0)
                        {
                            cacheAsDataTable.Rows[num6][num15 + 40] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num15 + 40] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num15 + 40]) + 1;
                        }
                    }
                    for (int num16 = 0; num16 < 5; num16++)
                    {
                        if (num16 == ((Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])) % 5))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num16 + 0x2c]) > 0)
                            {
                                cacheAsDataTable.Rows[num6][num16 + 0x2c] = -1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[num6][num16 + 0x2c] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num16 + 0x2c]) - 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num16 + 0x2c]) < 0)
                        {
                            cacheAsDataTable.Rows[num6][num16 + 0x2c] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num16 + 0x2c] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num16 + 0x2c]) + 1;
                        }
                    }
                    if ((Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])) > 11)
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][0x31]) > 0)
                        {
                            cacheAsDataTable.Rows[num6][0x31] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][0x31] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][0x31]) - 1;
                        }
                        if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][50]) < 0)
                        {
                            cacheAsDataTable.Rows[num6][50] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][50] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][50]) + 1;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][0x31]) < 0)
                        {
                            cacheAsDataTable.Rows[num6][0x31] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][0x31] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][0x31]) + 1;
                        }
                        if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][50]) > 0)
                        {
                            cacheAsDataTable.Rows[num6][50] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][50] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][50]) - 1;
                        }
                    }
                    if (((Convert.ToInt32(cacheAsDataTable.Rows[num6][1]) + Convert.ToInt32(cacheAsDataTable.Rows[num6][2])) % 2) == 1)
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][0x33]) > 0)
                        {
                            cacheAsDataTable.Rows[num6][0x33] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][0x33] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][0x33]) - 1;
                        }
                        if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][0x34]) < 0)
                        {
                            cacheAsDataTable.Rows[num6][0x34] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][0x34] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][0x34]) + 1;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][0x33]) < 0)
                        {
                            cacheAsDataTable.Rows[num6][0x33] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][0x33] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][0x33]) + 1;
                        }
                        if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][0x34]) > 0)
                        {
                            cacheAsDataTable.Rows[num6][0x34] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][0x34] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][0x34]) - 1;
                        }
                    }
                }
            }
            Cache.SetCache("SYDJ_Q2HZ", cacheAsDataTable, 600);
        }
        table2 = cacheAsDataTable.Clone();
        DataRow[] rowArray = null;
        if (Type == 1)
        {
            rowArray = cacheAsDataTable.Select("DaySpan <=" + DaySpan, "ID ASC");
        }
        else
        {
            rowArray = cacheAsDataTable.Select("DaySpan =" + DaySpan, "ID ASC");
        }
        foreach (DataRow row in rowArray)
        {
            table2.Rows.Add(row.ItemArray);
        }
        table2.Columns.Remove("ID");
        table2.Columns.Remove("DaySpan");
        return table2;
    }

    public DataTable SYDJ_Q2ZXDYB(int DaySpan, int Type, ref int ReturnValue, ref string returnDescription)
    {
        DataSet ds = null;
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        DateTime now = DateTime.Now;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SYDJ_Q2ZXDYB");
        if (cacheAsDataTable == null)
        {
            Procedures.P_TrendChart_11YDJ_WINNUM(ref ds, now, 0x3eL, ref ReturnValue, ref returnDescription);
            if (ds == null)
            {
                return cacheAsDataTable;
            }
            cacheAsDataTable = ds.Tables[0];
            cacheAsDataTable.Columns.Add("bh", typeof(int));
            for (int i = 3; i <= 0x15; i++)
            {
                cacheAsDataTable.Columns.Add("b" + i.ToString(), typeof(int));
            }
            for (int j = 0; j < cacheAsDataTable.Rows.Count; j++)
            {
                cacheAsDataTable.Rows[j][8] = Convert.ToInt32(cacheAsDataTable.Rows[j][1]) + Convert.ToInt32(cacheAsDataTable.Rows[j][2]);
                if (j == 0)
                {
                    for (int k = 3; k <= 0x15; k++)
                    {
                        if (k == (Convert.ToInt32(cacheAsDataTable.Rows[j][1]) + Convert.ToInt32(cacheAsDataTable.Rows[j][2])))
                        {
                            cacheAsDataTable.Rows[j][k + 6] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[j][k + 6] = 1;
                        }
                    }
                }
                else
                {
                    for (int m = 3; m <= 0x15; m++)
                    {
                        if (m == (Convert.ToInt32(cacheAsDataTable.Rows[j][1]) + Convert.ToInt32(cacheAsDataTable.Rows[j][2])))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[j - 1][m + 6]) < 0)
                            {
                                cacheAsDataTable.Rows[j][m + 6] = Convert.ToInt32(cacheAsDataTable.Rows[j - 1][m + 6]) - 1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[j][m + 6] = -1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[j - 1][m + 6]) > 0)
                        {
                            cacheAsDataTable.Rows[j][m + 6] = Convert.ToInt32(cacheAsDataTable.Rows[j - 1][m + 6]) + 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[j][m + 6] = 1;
                        }
                    }
                }
            }
            Cache.SetCache("SYDJ_Q2ZXDYB", cacheAsDataTable, 600);
        }
        table2 = cacheAsDataTable.Clone();
        DataRow[] rowArray = null;
        if (Type == 1)
        {
            rowArray = cacheAsDataTable.Select("DaySpan <=" + DaySpan, "ID ASC");
        }
        else
        {
            rowArray = cacheAsDataTable.Select("DaySpan =" + DaySpan, "ID ASC");
        }
        foreach (DataRow row in rowArray)
        {
            table2.Rows.Add(row.ItemArray);
        }
        table2.Columns.Remove("ID");
        table2.Columns.Remove("DaySpan");
        return table2;
    }

    public DataTable SYDJ_Q3FBT(int DaySpan, int Type, ref int ReturnValue, ref string returnDescription)
    {
        DataSet ds = null;
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        DateTime now = DateTime.Now;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SYDJ_Q3FBT");
        if (cacheAsDataTable == null)
        {
            Procedures.P_TrendChart_11YDJ_WINNUM(ref ds, now, 0x3eL, ref ReturnValue, ref returnDescription);
            if (ds == null)
            {
                return cacheAsDataTable;
            }
            cacheAsDataTable = ds.Tables[0];
            for (int i = 1; i <= 11; i++)
            {
                cacheAsDataTable.Columns.Add("b" + i.ToString(), typeof(int));
            }
            for (int j = 1; j <= 8; j++)
            {
                cacheAsDataTable.Columns.Add("bb" + j.ToString(), typeof(int));
            }
            for (int k = 1; k <= 8; k++)
            {
                cacheAsDataTable.Columns.Add("bc" + k.ToString(), typeof(int));
            }
            for (int m = 0; m < cacheAsDataTable.Rows.Count; m++)
            {
                if (m == 0)
                {
                    for (int n = 1; n <= 11; n++)
                    {
                        if (((n == Convert.ToInt32(cacheAsDataTable.Rows[m][1])) || (n == Convert.ToInt32(cacheAsDataTable.Rows[m][2]))) || (n == Convert.ToInt32(cacheAsDataTable.Rows[m][3])))
                        {
                            cacheAsDataTable.Rows[m][n + 7] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][n + 7] = 1;
                        }
                    }
                    ArrayList list = new ArrayList();
                    list.Add("111");
                    list.Add("110");
                    list.Add("101");
                    list.Add("011");
                    list.Add("100");
                    list.Add("010");
                    list.Add("001");
                    list.Add("000");
                    for (int num6 = 1; num6 <= 8; num6++)
                    {
                        if ((num6 - 1) == list.IndexOf(Convert.ToString((int)(Convert.ToInt32(cacheAsDataTable.Rows[m][1]) % 2)) + Convert.ToString((int)(Convert.ToInt32(cacheAsDataTable.Rows[m][2]) % 2)) + Convert.ToString((int)(Convert.ToInt32(cacheAsDataTable.Rows[m][3]) % 2))))
                        {
                            cacheAsDataTable.Rows[m][num6 + 0x12] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num6 + 0x12] = 1;
                        }
                    }
                    for (int num7 = 1; num7 <= 8; num7++)
                    {
                        if ((8 - num7) == list.IndexOf(Convert.ToString((Convert.ToInt32(cacheAsDataTable.Rows[m][1]) > 5) ? "1" : "0") + Convert.ToString((Convert.ToInt32(cacheAsDataTable.Rows[m][2]) > 5) ? "1" : "0") + Convert.ToString((Convert.ToInt32(cacheAsDataTable.Rows[m][3]) > 5) ? "1" : "0")))
                        {
                            cacheAsDataTable.Rows[m][num7 + 0x1a] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num7 + 0x1a] = 1;
                        }
                    }
                }
                else
                {
                    for (int num8 = 1; num8 <= 11; num8++)
                    {
                        if (((num8 == Convert.ToInt32(cacheAsDataTable.Rows[m][1])) || (num8 == Convert.ToInt32(cacheAsDataTable.Rows[m][2]))) || (num8 == Convert.ToInt32(cacheAsDataTable.Rows[m][3])))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num8 + 7]) > 0)
                            {
                                cacheAsDataTable.Rows[m][num8 + 7] = -1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[m][num8 + 7] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num8 + 7]) - 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num8 + 7]) < 0)
                        {
                            cacheAsDataTable.Rows[m][num8 + 7] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num8 + 7] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num8 + 7]) + 1;
                        }
                    }
                    ArrayList list2 = new ArrayList();
                    list2.Add("111");
                    list2.Add("110");
                    list2.Add("101");
                    list2.Add("011");
                    list2.Add("100");
                    list2.Add("010");
                    list2.Add("001");
                    list2.Add("000");
                    for (int num9 = 1; num9 <= 8; num9++)
                    {
                        if ((num9 - 1) == list2.IndexOf(Convert.ToString((int)(Convert.ToInt32(cacheAsDataTable.Rows[m][1]) % 2)) + Convert.ToString((int)(Convert.ToInt32(cacheAsDataTable.Rows[m][2]) % 2)) + Convert.ToString((int)(Convert.ToInt32(cacheAsDataTable.Rows[m][3]) % 2))))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num9 + 0x12]) > 0)
                            {
                                cacheAsDataTable.Rows[m][num9 + 0x12] = -1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[m][num9 + 0x12] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num9 + 0x12]) - 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num9 + 0x12]) < 0)
                        {
                            cacheAsDataTable.Rows[m][num9 + 0x12] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num9 + 0x12] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num9 + 0x12]) + 1;
                        }
                    }
                    for (int num10 = 1; num10 <= 8; num10++)
                    {
                        if ((8 - num10) == list2.IndexOf(Convert.ToString((Convert.ToInt32(cacheAsDataTable.Rows[m][1]) > 5) ? "1" : "0") + Convert.ToString((Convert.ToInt32(cacheAsDataTable.Rows[m][2]) > 5) ? "1" : "0") + Convert.ToString((Convert.ToInt32(cacheAsDataTable.Rows[m][3]) > 5) ? "1" : "0")))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num10 + 0x1a]) > 0)
                            {
                                cacheAsDataTable.Rows[m][num10 + 0x1a] = -1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[m][num10 + 0x1a] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num10 + 0x1a]) - 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num10 + 0x1a]) < 0)
                        {
                            cacheAsDataTable.Rows[m][num10 + 0x1a] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num10 + 0x1a] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num10 + 0x1a]) + 1;
                        }
                    }
                }
            }
            Cache.SetCache("SYDJ_Q3FBT", cacheAsDataTable, 600);
        }
        table2 = cacheAsDataTable.Clone();
        DataRow[] rowArray = null;
        if (Type == 1)
        {
            rowArray = cacheAsDataTable.Select("DaySpan <=" + DaySpan, "ID ASC");
        }
        else
        {
            rowArray = cacheAsDataTable.Select("DaySpan =" + DaySpan, "ID ASC");
        }
        foreach (DataRow row in rowArray)
        {
            table2.Rows.Add(row.ItemArray);
        }
        table2.Columns.Remove("ID");
        table2.Columns.Remove("DaySpan");
        return table2;
    }

    public DataTable SYDJ_Q3FWT(int DaySpan, int Type, ref int ReturnValue, ref string returnDescription)
    {
        DataSet ds = null;
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        DateTime now = DateTime.Now;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SYDJ_Q3FWT");
        if (cacheAsDataTable == null)
        {
            Procedures.P_TrendChart_11YDJ_WINNUM(ref ds, now, 0x3eL, ref ReturnValue, ref returnDescription);
            if (ds == null)
            {
                return cacheAsDataTable;
            }
            cacheAsDataTable = ds.Tables[0];
            for (int i = 1; i <= 11; i++)
            {
                cacheAsDataTable.Columns.Add("b" + i.ToString(), typeof(int));
            }
            for (int j = 1; j <= 11; j++)
            {
                cacheAsDataTable.Columns.Add("bb" + j.ToString(), typeof(int));
            }
            for (int k = 1; k <= 11; k++)
            {
                cacheAsDataTable.Columns.Add("bc" + k.ToString(), typeof(int));
            }
            for (int m = 0; m <= 3; m++)
            {
                cacheAsDataTable.Columns.Add("bd" + m.ToString(), typeof(int));
            }
            for (int n = 0; n <= 3; n++)
            {
                cacheAsDataTable.Columns.Add("be" + n.ToString(), typeof(int));
            }
            for (int num6 = 0; num6 < cacheAsDataTable.Rows.Count; num6++)
            {
                if (num6 == 0)
                {
                    for (int num7 = 1; num7 <= 11; num7++)
                    {
                        if (num7 == Convert.ToInt32(cacheAsDataTable.Rows[num6][1]))
                        {
                            cacheAsDataTable.Rows[num6][num7 + 7] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num7 + 7] = 1;
                        }
                    }
                    for (int num8 = 1; num8 <= 11; num8++)
                    {
                        if (num8 == Convert.ToInt32(cacheAsDataTable.Rows[num6][2]))
                        {
                            cacheAsDataTable.Rows[num6][num8 + 0x12] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num8 + 0x12] = 1;
                        }
                    }
                    for (int num9 = 1; num9 <= 11; num9++)
                    {
                        if (num9 == Convert.ToInt32(cacheAsDataTable.Rows[num6][3]))
                        {
                            cacheAsDataTable.Rows[num6][num9 + 0x1d] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num9 + 0x1d] = 1;
                        }
                    }
                    int num10 = 0;
                    int num11 = 0;
                    for (int num12 = 1; num12 <= 3; num12++)
                    {
                        if ((Convert.ToInt32(cacheAsDataTable.Rows[num6][num12]) % 2) == 1)
                        {
                            num10++;
                        }
                        if (Convert.ToInt32(cacheAsDataTable.Rows[num6][num12]) > 5)
                        {
                            num11++;
                        }
                    }
                    for (int num13 = 0; num13 <= 3; num13++)
                    {
                        if (num13 == num10)
                        {
                            cacheAsDataTable.Rows[num6][num13 + 0x29] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num13 + 0x29] = 1;
                        }
                    }
                    for (int num14 = 0; num14 <= 3; num14++)
                    {
                        if (num14 == num11)
                        {
                            cacheAsDataTable.Rows[num6][num14 + 0x2d] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num14 + 0x2d] = 1;
                        }
                    }
                }
                else
                {
                    for (int num15 = 1; num15 <= 11; num15++)
                    {
                        if (num15 == Convert.ToInt32(cacheAsDataTable.Rows[num6][1]))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num15 + 7]) < 0)
                            {
                                cacheAsDataTable.Rows[num6][num15 + 7] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num15 + 7]) - 1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[num6][num15 + 7] = -1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num15 + 7]) > 0)
                        {
                            cacheAsDataTable.Rows[num6][num15 + 7] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num15 + 7]) + 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num15 + 7] = 1;
                        }
                    }
                    for (int num16 = 1; num16 <= 11; num16++)
                    {
                        if (num16 == Convert.ToInt32(cacheAsDataTable.Rows[num6][2]))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num16 + 0x12]) < 0)
                            {
                                cacheAsDataTable.Rows[num6][num16 + 0x12] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num16 + 0x12]) - 1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[num6][num16 + 0x12] = -1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num16 + 0x12]) > 0)
                        {
                            cacheAsDataTable.Rows[num6][num16 + 0x12] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num16 + 0x12]) + 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num16 + 0x12] = 1;
                        }
                    }
                    for (int num17 = 1; num17 <= 11; num17++)
                    {
                        if (num17 == Convert.ToInt32(cacheAsDataTable.Rows[num6][3]))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num17 + 0x1d]) < 0)
                            {
                                cacheAsDataTable.Rows[num6][num17 + 0x1d] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num17 + 0x1d]) - 1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[num6][num17 + 0x1d] = -1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num17 + 0x1d]) > 0)
                        {
                            cacheAsDataTable.Rows[num6][num17 + 0x1d] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num17 + 0x1d]) + 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num17 + 0x1d] = 1;
                        }
                    }
                    int num18 = 0;
                    int num19 = 0;
                    for (int num20 = 1; num20 <= 3; num20++)
                    {
                        if ((Convert.ToInt32(cacheAsDataTable.Rows[num6][num20]) % 2) == 1)
                        {
                            num18++;
                        }
                        if (Convert.ToInt32(cacheAsDataTable.Rows[num6][num20]) > 5)
                        {
                            num19++;
                        }
                    }
                    for (int num21 = 0; num21 <= 3; num21++)
                    {
                        if (num21 == num18)
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num21 + 0x29]) < 0)
                            {
                                cacheAsDataTable.Rows[num6][num21 + 0x29] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num21 + 0x29]) - 1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[num6][num21 + 0x29] = -1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num21 + 0x29]) > 0)
                        {
                            cacheAsDataTable.Rows[num6][num21 + 0x29] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num21 + 0x29]) + 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num21 + 0x29] = 1;
                        }
                    }
                    for (int num22 = 0; num22 <= 3; num22++)
                    {
                        if (num22 == num19)
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num22 + 0x2d]) < 0)
                            {
                                cacheAsDataTable.Rows[num6][num22 + 0x2d] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num22 + 0x2d]) - 1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[num6][num22 + 0x2d] = -1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num22 + 0x2d]) > 0)
                        {
                            cacheAsDataTable.Rows[num6][num22 + 0x2d] = Convert.ToInt32(cacheAsDataTable.Rows[num6 - 1][num22 + 0x2d]) + 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[num6][num22 + 0x2d] = 1;
                        }
                    }
                }
            }
            Cache.SetCache("SYDJ_Q3FWT", cacheAsDataTable, 600);
        }
        table2 = cacheAsDataTable.Clone();
        DataRow[] rowArray = null;
        if (Type == 1)
        {
            rowArray = cacheAsDataTable.Select("DaySpan <=" + DaySpan, "ID ASC");
        }
        else
        {
            rowArray = cacheAsDataTable.Select("DaySpan =" + DaySpan, "ID ASC");
        }
        foreach (DataRow row in rowArray)
        {
            table2.Rows.Add(row.ItemArray);
        }
        table2.Columns.Remove("ID");
        table2.Columns.Remove("DaySpan");
        return table2;
    }

    public DataTable SYDJ_Q3HZT(int DaySpan, int Type, ref int ReturnValue, ref string returnDescription)
    {
        DataSet ds = null;
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        DateTime now = DateTime.Now;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SYDJ_Q3HZT");
        if (cacheAsDataTable == null)
        {
            Procedures.P_TrendChart_11YDJ_WINNUM(ref ds, now, 0x3eL, ref ReturnValue, ref returnDescription);
            if (ds == null)
            {
                return cacheAsDataTable;
            }
            cacheAsDataTable = ds.Tables[0];
            for (int i = 6; i <= 30; i++)
            {
                cacheAsDataTable.Columns.Add("b" + i.ToString(), typeof(int));
            }
            for (int j = 0; j <= 9; j++)
            {
                cacheAsDataTable.Columns.Add("bb" + j.ToString(), typeof(int));
            }
            for (int k = 0; k <= 3; k++)
            {
                cacheAsDataTable.Columns.Add("bc3" + k.ToString(), typeof(int));
            }
            for (int m = 0; m < cacheAsDataTable.Rows.Count; m++)
            {
                if (m == 0)
                {
                    for (int n = 6; n <= 30; n++)
                    {
                        if (n == ((Convert.ToInt32(cacheAsDataTable.Rows[m][1]) + Convert.ToInt32(cacheAsDataTable.Rows[m][2])) + Convert.ToInt32(cacheAsDataTable.Rows[m][3])))
                        {
                            cacheAsDataTable.Rows[m][n + 2] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][n + 2] = 1;
                        }
                    }
                    for (int num6 = 0; num6 <= 9; num6++)
                    {
                        if (num6 == (((Convert.ToInt32(cacheAsDataTable.Rows[m][1]) + Convert.ToInt32(cacheAsDataTable.Rows[m][2])) + Convert.ToInt32(cacheAsDataTable.Rows[m][3])) % 10))
                        {
                            cacheAsDataTable.Rows[m][num6 + 0x21] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num6 + 0x21] = 1;
                        }
                    }
                    for (int num7 = 0; num7 < 3; num7++)
                    {
                        if (num7 == (((Convert.ToInt32(cacheAsDataTable.Rows[m][1]) + Convert.ToInt32(cacheAsDataTable.Rows[m][2])) + Convert.ToInt32(cacheAsDataTable.Rows[m][3])) % 3))
                        {
                            cacheAsDataTable.Rows[m][num7 + 0x2b] = -1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num7 + 0x2b] = 1;
                        }
                    }
                }
                else
                {
                    for (int num8 = 6; num8 <= 30; num8++)
                    {
                        if (num8 == ((Convert.ToInt32(cacheAsDataTable.Rows[m][1]) + Convert.ToInt32(cacheAsDataTable.Rows[m][2])) + Convert.ToInt32(cacheAsDataTable.Rows[m][3])))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num8 + 2]) > 0)
                            {
                                cacheAsDataTable.Rows[m][num8 + 2] = -1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[m][num8 + 2] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num8 + 2]) - 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num8 + 2]) < 0)
                        {
                            cacheAsDataTable.Rows[m][num8 + 2] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num8 + 2] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num8 + 2]) + 1;
                        }
                    }
                    for (int num9 = 0; num9 <= 9; num9++)
                    {
                        if (num9 == (((Convert.ToInt32(cacheAsDataTable.Rows[m][1]) + Convert.ToInt32(cacheAsDataTable.Rows[m][2])) + Convert.ToInt32(cacheAsDataTable.Rows[m][3])) % 10))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num9 + 0x21]) > 0)
                            {
                                cacheAsDataTable.Rows[m][num9 + 0x21] = -1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[m][num9 + 0x21] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num9 + 0x21]) - 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num9 + 0x21]) < 0)
                        {
                            cacheAsDataTable.Rows[m][num9 + 0x21] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num9 + 0x21] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num9 + 0x21]) + 1;
                        }
                    }
                    for (int num10 = 0; num10 < 3; num10++)
                    {
                        if (num10 == (((Convert.ToInt32(cacheAsDataTable.Rows[m][1]) + Convert.ToInt32(cacheAsDataTable.Rows[m][2])) + Convert.ToInt32(cacheAsDataTable.Rows[m][3])) % 3))
                        {
                            if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num10 + 0x2b]) > 0)
                            {
                                cacheAsDataTable.Rows[m][num10 + 0x2b] = -1;
                            }
                            else
                            {
                                cacheAsDataTable.Rows[m][num10 + 0x2b] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num10 + 0x2b]) - 1;
                            }
                        }
                        else if (Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num10 + 0x2b]) < 0)
                        {
                            cacheAsDataTable.Rows[m][num10 + 0x2b] = 1;
                        }
                        else
                        {
                            cacheAsDataTable.Rows[m][num10 + 0x2b] = Convert.ToInt32(cacheAsDataTable.Rows[m - 1][num10 + 0x2b]) + 1;
                        }
                    }
                }
            }
            Cache.SetCache("SYDJ_Q3HZT", cacheAsDataTable, 600);
        }
        table2 = cacheAsDataTable.Clone();
        DataRow[] rowArray = null;
        if (Type == 1)
        {
            rowArray = cacheAsDataTable.Select("DaySpan <=" + DaySpan, "ID ASC");
        }
        else
        {
            rowArray = cacheAsDataTable.Select("DaySpan =" + DaySpan, "ID ASC");
        }
        foreach (DataRow row in rowArray)
        {
            table2.Rows.Add(row.ItemArray);
        }
        table2.Columns.Remove("ID");
        table2.Columns.Remove("DaySpan");
        return table2;
    }
}


using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;

public class BLL
{
    public static DataTable CJDLT_HMFB_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("CJDLT_YS_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_CJDLT_HMFB(ref ds, Number);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("CJDLT_YS_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable CJDLT_HZHeng_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("CJDLT_HZHeng_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_CJDLT_HZ_Heng(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("CJDLT_HZHeng_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable CJDLT_HZZhong_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("CJDLT_HZZhong_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_CJDLT_HZzong(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("CJDLT_HZZhong_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable CJDLT_JiMa_lengre_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_CJDLT_HMLR_JiMa(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable CJDLT_JiMa_lengrejj_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_CJDLT_HMLR_JiMajj(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable CJDLT_jima_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("CJDLT_jima_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_CJDLT_jima(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("CJDLT_jima_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable CJDLT_JiMaWeihao_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("CJDLT_JiMaWeihao_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_CJDLT_WH(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("CJDLT_JiMaWeihao_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable CJDLT_JO_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("CJDLT_JO_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_CJDLT_Jiou(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("CJDLT_JO_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable CJDLT_lengre_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_CJDLT_HMLR_Tema(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable CJDLT_lengrejj_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_CJDLT_HMLR_Temajj(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable CJDLT_LH_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("CJDLT_LH_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_CJDLT_LH(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("CJDLT_LH_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable CJDLT_TeMa_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(" CJDLT_TeMa_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_CJDLT_tema(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache(" CJDLT_TeMa_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable CJDLT_YS_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("CJDLT_YS_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_CJDLT_YS(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("CJDLT_YS_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable KLPK_012_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("KLPK_012_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_KLPK_012(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("KLPK_012_SeleteByNum_ds1", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable KLPK_DX_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("KLPK_DX_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_KLPK_DX(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("KLPK_DX_SeleteByNum_ds1", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable KLPK_DZX_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("KLPK_DZX_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_KLPK_DZX(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("KLPK_DZX_SeleteByNum_ds1", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable KLPK_KJFB_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("KLPK_KJFB_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_KLPK_KJFB(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("KLPK_KJFB_SeleteByNum_ds1", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable KLPK_ZH_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("KLPK_ZH_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_KLPK_ZH(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("KLPK_ZH_SeleteByNum_ds1", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable PL3_012_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_PL3_012(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable PL3_DX_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_PL3_DX(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable PL3_DZX_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_PL3_DZX(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable PL3_HMFB_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_PL3_HMFB(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable PL3_HZ_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_PL3_HZ(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable PL3_JO_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_PL3_JO(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable PL3_KD_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_PL3_KD(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable PL3_LH_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("PL3_LH_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_PL3_LH(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("PL3_LH_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable PL3_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("PL3_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_PL3(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("PL3_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable PL3_WH_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_PL3_WH(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable PL3_YS_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("PL3_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_PL3_YS(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("PL3_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable PL3_ZH_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_PL3_ZH(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable PL3_ZX_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_PL3_ZX(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable PL5_012_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("PL5_012_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_PL5_012(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("PL5_012_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable PL5_CF_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_PL5_CF(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable PL5_DX_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("1ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_PL5_DX(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("1ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable PL5_DZX_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("33ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_PL5_DZX(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("33ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable PL5_HMFB_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_PL5_HMFB(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable PL5_HZ_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_PL5_HZ(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable PL5_JO_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("PL5_JO_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_PL5_JO(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("PL5_JO_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable PL5_LH_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("AAds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_PL5_LH(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("AAds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable PL5_YS_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("PL5_YS_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_PL5_YS(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("PL5_YS_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable PL5_ZH_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_PL5_ZH(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable TC22X5_HMFB_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_22X5_HMFB(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable TC22X5_HZ_Heng_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("TC22X5_HZ_Heng_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_22X5_HZ_Heng(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("TC22X5_HZ_Heng_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable TC22X5_HZZong_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("TC22X5_HZZong_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_22X5_HZzong(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("TC22X5_HZZong_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable TC22X5_JO_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("TC22X5_JO_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_22X5_JO(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("TC22X5_JO_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable TC22X5_lengre_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_22X5_HMLR(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable TC22X5_lengrejj_SeleteByNum(int Number)
    {
        DataSet ds = null;
        Procedures.P_TrendChart_22X5_HMLRjj(ref ds, Number);
        return ds.Tables[0];
    }

    public static DataTable TC22X5_LH_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("TC22X5_LH_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_22X5_LH(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("TC22X5_LH_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable TC22X5_Weihao_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("TC22X5_Weihao_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_22X5_WH(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("TC22X5_Weihao_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable TC22X5_WeiHaoCF_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("TC22X5_WeiHaoCF_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_22X5_WeiHaoCF(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("TC22X5_WeiHaoCF_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable TC22X5_YS_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("TC22X5_YS_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_22X5_YS(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("TC22X5_YS_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable X7_012_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("X7_012_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_7X_012(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("X7_012_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable X7_CF_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("X7_CF_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_7X_CF(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("X7_CF_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable X7_DX_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_7X_DX(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable X7_DZX_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("X7_DZX_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_7X_DZX(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("X7_DZX_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable X7_HMFB_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("X7_HMFB_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_7X_HMFB(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("X7_HMFB_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable X7_HZHeng_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("X7_HZHeng_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_7X_HZHeng(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("X7_HZHeng_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable X7_HZZhong_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("X7_HZZhong_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_7X_HZzhong(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("X7_HZZhong_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable X7_JO_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("X7_JO_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_7X_JO(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("X7_JO_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable X7_LH_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("X7_LH_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_7X_LH(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("X7_LH_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable X7_YS_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_7X_YS(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }

    public static DataTable X7_ZH_SeleteByNum(int Number)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("X7_ZH_SeleteByNum_ds11");
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            Procedures.P_TrendChart_7X_ZH(ref ds);
            cacheAsDataTable = ds.Tables[0];
            Cache.SetCache("X7_ZH_SeleteByNum_ds11", ds.Tables[0]);
        }
        if (Number > cacheAsDataTable.Rows.Count)
        {
            Number = cacheAsDataTable.Rows.Count;
        }
        DataTable table2 = new DataTable();
        table2 = cacheAsDataTable.Clone();
        int num2 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0);
        int num4 = _Convert.StrToInt(cacheAsDataTable.Rows.Count.ToString(), 0) - Number;
        foreach (DataRow row in cacheAsDataTable.Select("id>" + num4.ToString() + " AND id<=" + num2.ToString()))
        {
            table2.Rows.Add(row.ItemArray);
        }
        return table2;
    }
}


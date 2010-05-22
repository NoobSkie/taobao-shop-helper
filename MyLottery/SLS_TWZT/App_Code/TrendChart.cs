using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;

public class TrendChart
{
    public DataTable C15X5_CGXMB_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("C15X5_CGXMB_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_15X5_CGXMB(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("C15X5_CGXMB_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable C15X5_ZHZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("C15X5_ZHZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_15X5_HMFB(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("C15X5_ZHZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable D4_CGXMB_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("D4_CGXMB_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_4D_CGXMB(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("D4_CGXMB_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable D4_ZHFB_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("D4_ZHFB_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_4D_ZHFB(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("D4_ZHFB_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable DF61_ZHFB_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("DF61_ZHFB_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_DF6J1_ZHFB(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("DF61_ZHFB_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable FC3D_C3YS_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("FC3D_C3YS_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_3D_C3YS(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("FC3D_C3YS_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable FC3D_DZX_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("FC3D_DZX_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_3D_DZX(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("FC3D_DZX_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable FC3D_HZ_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("FC3D_HZ_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_3D_HZ(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("FC3D_HZ_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable FC3D_KD_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("FC3D_KD_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_3D_KD(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("FC3D_KD_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable FC3D_XTZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("FC3D_XTZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_3D_XTZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("FC3D_XTZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable FC3D_ZHFB_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("FC3D_ZHFB_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_3D_ZHFB(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("FC3D_ZHFB_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable FC3D_ZHXT_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("FC3D_ZHXT_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_3D_ZHXT(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("FC3D_ZHXT_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable LC7_CGXMB_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("LC7_CGXMB_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_7LC_CGXMB(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("LC7_CGXMB_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable LC7_ZHFB_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("LC7_ZHFB_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_7CL_HMFB(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("LC7_ZHFB_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SHSSL_012_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SHSSL_012_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SHSSL_012(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SHSSL_012_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SHSSL_DX_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SHSSL_DX_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SHSSL_DX(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SHSSL_DX_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SHSSL_HZ_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SHSSL_HZ_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SHSSL_HZ(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SHSSL_HZ_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SHSSL_JO_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SHSSL_JO_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SHSSL_JO(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SHSSL_JO_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SHSSL_ZH_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SHSSL_ZH_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SHSSL_ZH(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SHSSL_ZH_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SHSSL_ZHFB_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SHSSL_ZHFB_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SHSSL_ZHFB(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SHSSL_ZHFB_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_2X_012ZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_2X_012ZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_2X_012_ZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_2X_012ZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_2X_DXDSZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_2X_DXDSZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_2XDXDSZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_2X_DXDSZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_2X_HZWZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_2X_HZWZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_2XHZWZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_2X_HZWZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_2X_HZZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_2X_HZZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_2XHZZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_2X_HZZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_2X_KDZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_2X_KDZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_2XKDZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_2X_KDZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_2X_MAXZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_2X_MAXZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_2XMaxZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_2X_MAXZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_2X_MinZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_2X_MinZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_2XMINZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_2X_MinZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_2X_PJZZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_2X_PJZZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_2XPJZZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_2X_PJZZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_2X_ZHFBZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_2X_ZHFBZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_2XZHFBZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_2X_ZHFBZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_3X_DX_012_ZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_3X_DX_012_ZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_3X_DX012_ZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_3X_DX_012_ZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_3X_DXZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_3X_DXZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_3XDXZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_3X_DXZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_3X_HZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_3X_HZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_3XHZZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_3X_HZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_3X_HZWST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_3X_HZWST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_3XHZWZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_3X_HZWST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_3X_JOZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_3X_JOZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_3XJOZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_3X_JOZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_3X_KDZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_3X_KDZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_3XKDZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_3X_KDZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_3X_ZHFBZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_3X_ZHFBZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_3XZHFBZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_3X_ZHFBZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_3X_ZHZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_3X_ZHZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_3XZHZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_3X_ZHZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_3X_ZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_3X_ZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_3XZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_3X_ZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_3X_ZX_012_ZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_3X_ZX_012_ZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_3X_ZX012_ZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_3X_ZX_012_ZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_4X_DXZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_4X_DXZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_4XDXZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_4X_DXZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_4X_HZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_4X_HZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_4XHZZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_4X_HZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_4X_JOZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_4X_JOZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_4XJOZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_4X_JOZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_4X_KDZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_4X_KDZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_4XKDZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_4X_KDZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_4X_PJZZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_4X_PJZZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_4XPJZZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_4X_PJZZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_4X_ZHFBZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_4X_ZHFBZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_4XZHFBZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_4X_ZHFBZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_4X_ZHZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_4X_ZHZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_4XZHZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_4X_ZHZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_4X_ZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_4X_ZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_4XZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_4X_ZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_5X_DXZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_5X_DXZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_5XDXZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_5X_DXZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_5X_HZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_5X_HZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_5XHZZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_5X_HZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_5X_JOZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_5X_JOZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_5XJOZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_5X_JOZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_5X_KDZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_5X_KDZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_5XKDZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_5X_KDZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_5X_PJZZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_5X_PJZZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_5XPJZZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_5X_PJZZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_5X_ZHFBZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_5X_ZHFBZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_5XZHFBZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_5X_ZHFBZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_5X_ZHZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_5X_ZHZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_5XZHZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_5X_ZHZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSC_5X_ZST_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSC_5X_ZST_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSC_5XZST(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSC_5X_ZST_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSQ_3QFB_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSQ_3QFB_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSQ_3FQ(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSQ_3QFB_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSQ_BQZH_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSQ_BQZH_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSQ_BQZH(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSQ_BQZH_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSQ_CGXMB_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSQ_CGXMB_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSQ_CGXMB(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSQ_CGXMB_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSQ_DX_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSQ_DX_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSQ_DX(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSQ_DX_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSQ_HL_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSQ_HL_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSQ_HL(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSQ_HL_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSQ_JO_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSQ_JO_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSQ_JO(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSQ_JO_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSQ_ZH_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSQ_ZH_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSQ_ZH(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSQ_ZH_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }

    public DataTable SSQ_ZHFB_Select(int num, string str1, string str2, ref string result)
    {
        DataTable cacheAsDataTable = null;
        DataTable table2 = null;
        cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("SSQ_ZHFB_Select");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
        {
            DataSet ds = null;
            Procedures.P_TrendChart_SSQ_HMFB(ref ds);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(1, "参数错误或者数据库--无数据", base.GetType().BaseType.FullName);
                return table2;
            }
            Cache.SetCache("SSQ_ZHFB_Select", ds.Tables[0]);
            cacheAsDataTable = ds.Tables[0];
        }
        table2 = cacheAsDataTable.Clone();
        if (num == 0)
        {
            int num2 = _Convert.StrToInt(str1, 0);
            int num3 = _Convert.StrToInt(str2, 0);
            foreach (DataRow row in cacheAsDataTable.Select(string.Concat(new object[] { "Isuse>=", num2, " and  Isuse<=", num3 })))
            {
                table2.Rows.Add(row.ItemArray);
            }
            return table2;
        }
        if (num >= cacheAsDataTable.Rows.Count)
        {
            num = cacheAsDataTable.Rows.Count;
        }
        int count = cacheAsDataTable.Rows.Count;
        int num6 = count - num;
        foreach (DataRow row2 in cacheAsDataTable.Select(string.Concat(new object[] { "id > ", num6, " and id <= ", count })))
        {
            table2.Rows.Add(row2.ItemArray);
        }
        return table2;
    }
}


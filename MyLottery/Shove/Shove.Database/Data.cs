namespace Shove.Database
{
    using System;
    using System.Data;

    public class Data
    {
        public static DataTable FilterDataTableData(DataTable dt, string Condition, long LimitStart, long RowCount)
        {
            if (dt == null)
            {
                return null;
            }
            if (string.IsNullOrEmpty(Condition) && ((LimitStart < 0L) || (RowCount < 1L)))
            {
                return dt;
            }
            DataRow[] array = null;
            if (!string.IsNullOrEmpty(Condition))
            {
                array = dt.Select(Condition);
            }
            else
            {
                array = new DataRow[dt.Rows.Count];
                dt.Rows.CopyTo(array, 0);
            }
            DataTable table = dt.Clone();
            if ((LimitStart >= 0L) && (RowCount >= 1L))
            {
                if (LimitStart >= array.LongLength)
                {
                    return table;
                }
                if ((LimitStart + RowCount) > array.LongLength)
                {
                    RowCount = array.LongLength - LimitStart;
                }
                DataRow[] rowArray2 = new DataRow[array.LongLength];
                array.CopyTo(rowArray2, 0);
                array = new DataRow[RowCount];
                for (long i = LimitStart; i < (LimitStart + RowCount); i += 1L)
                {
                    array[(int) ((IntPtr) (i - LimitStart))] = rowArray2[(int) ((IntPtr) i)];
                }
            }
            foreach (DataRow row in array)
            {
                DataRow row2 = table.NewRow();
                row2.ItemArray = row.ItemArray;
                table.Rows.Add(row2);
            }
            return table;
        }
    }
}


namespace Shove
{
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.UI;

    public class _Excel
    {
        private static void KillExcelProcess()
        {
            Process[] processesByName = Process.GetProcessesByName("EXCEL");
            DateTime startTime = new DateTime();
            int index = 0;
            for (int i = 0; i < processesByName.Length; i++)
            {
                if (startTime < processesByName[i].StartTime)
                {
                    startTime = processesByName[i].StartTime;
                    index = i;
                }
            }
            if (!processesByName[index].HasExited)
            {
                processesByName[index].Kill();
            }
        }

        public static void DataControlToExcelAndDownload(Control ctl)
        {
            DataControlToExcelAndDownload(ctl, "Excel.xls");
        }

        public static void DataControlToExcelAndDownload(Control ctl, string FileName)
        {
            if (string.IsNullOrEmpty(FileName))
            {
                FileName = "Excel.xls";
            }
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = Encoding.Default;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            ctl.Page.EnableViewState = false;
            StringWriter writer = new StringWriter();
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            ctl.RenderControl(writer2);
            HttpContext.Current.Response.Write(writer.ToString());
            HttpContext.Current.Response.End();
        }

        public static Workbook DataTableToWorkBook(System.Data.DataTable dt)
        {
            if (dt.Columns.Count < 1)
            {
                throw new Exception("_Excel.DataTableToWorkBook 方法提供的 DataTable 参数找不到任何可用的列。");
            }
            string[] cells = new string[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                cells[i] = dt.Columns[i].ColumnName;
            }
            return DataTableToWorkBook(dt, cells);
        }

        public static Workbook DataTableToWorkBook(System.Data.DataTable dt, string[] Cells)
        {
            if (dt.Columns.Count < 1)
            {
                throw new Exception("_Excel.DataTableToWorkBook 方法提供的 DataTable 参数找不到任何可用的列。");
            }
            Application application = new ApplicationClass();
            Workbook workbook = application.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet worksheet = (Worksheet) workbook.Worksheets[1];
            long count = dt.Rows.Count;
            long num2 = 0L;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (((Cells != null) && (Cells.Length > i)) && !string.IsNullOrEmpty(Cells[i]))
                {
                    worksheet.Cells[1, i + 1] = Cells[i].Trim();
                }
                else
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                }
                Microsoft.Office.Interop.Excel.Range range1 = (Microsoft.Office.Interop.Excel.Range) worksheet.Cells[1, i + 1];
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    worksheet.Cells[j + 2, k + 1] = dt.Rows[j][k];
                    Microsoft.Office.Interop.Excel.Range range2 = (Microsoft.Office.Interop.Excel.Range) worksheet.Cells[j + 2, k + 1];
                }
                num2 += 1L;
                float single1 = ((float) (100L * num2)) / ((float) count);
            }
            return workbook;
        }

        public static void DataTableToWorkBookAndDownload(System.Data.DataTable dt, string FileName)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.ContentEncoding = Encoding.GetEncoding("gb2312");
            if (string.IsNullOrEmpty(FileName))
            {
                FileName = "Excel.xls";
            }
            response.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
            response.Write(DataTableToWorkBook(dt));
            response.End();
        }

        public static void DataTableToWorkBookAndDownload(System.Data.DataTable dt, string FileName, string[] Cells)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.ContentEncoding = Encoding.GetEncoding("gb2312");
            if (string.IsNullOrEmpty(FileName))
            {
                FileName = "Excel.xls";
            }
            response.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
            response.Write(DataTableToWorkBook(dt, Cells));
            response.End();
        }
    }
}


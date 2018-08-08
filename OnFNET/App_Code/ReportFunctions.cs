using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using PBA.OnfDAL;
using PBA.OnfBLL;
using PBA.OnfInfo;

/// <summary>
/// Summary description for ReportFunctions
/// </summary>
public class ReportFunctions
{
    public static TableRow[] convertExcelToHTML(SpreadsheetGear.IWorkbook workbook, int excelCols, int excelRows)
    {
        // lets take this excel sheet and parse it into HTML
        List<TableRow> rows = new List<TableRow>();
        SpreadsheetGear.IRange cells = workbook.ActiveWorksheet.Cells;
        int rowCount = 0, colCount = 0;
        bool isMerged = false;

        while (rowCount <= excelRows)
        {
            TableRow row = new TableRow();
            isMerged = false;
            colCount = 0;

            while (colCount <= excelCols)
            {
                TableCell cell = new TableCell();

                if (cells[rowCount, colCount].MergeArea.Cells.Count > 1 && isMerged == false)
                {
                    cell.ColumnSpan = cells[rowCount, colCount].MergeArea.Cells.Count;
                    isMerged = true;
                }

                cell.Text = cells[rowCount, colCount].Text;
                
                if (cells[rowCount, colCount].Font.Bold)
                {
                    cell.Text = "<b>" + cell.Text + "</b>";
                }

                row.Cells.Add(cell);
                colCount++;
            }

            rows.Add(row);
            rowCount++;
        }

        return rows.ToArray();
    }
}

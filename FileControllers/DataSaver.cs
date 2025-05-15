using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using OfficeOpenXml;
using System.Windows.Forms;

namespace DataPreprocessingTool.FileControllers
{
    internal class DataSaver
    {
        public static void SaveWithDialog(DataTable table)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV 파일 (*.csv)|*.csv|Excel 파일 (*.xlsx)|*.xlsx";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = dialog.FileName;
                    string ext = Path.GetExtension(path).ToLower();

                    try
                    {
                        if (ext == ".csv")
                        {
                            SaveAsCsv(table, path);
                        }
                        else if (ext == ".xlsx")
                        {
                            SaveAsExcel(table, path);
                        }

                        MessageBox.Show("저장 완료");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("저장 실패: " + ex.Message);
                    }
                }
            }
        }

        public static void SaveAsCsv(DataTable table, string path)
        {
            var lines = new List<string>();
            lines.Add(string.Join(",", table.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));

            foreach (DataRow row in table.Rows)
            {
                lines.Add(string.Join(",", row.ItemArray.Select(v => v?.ToString())));
            }

            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        public static void SaveAsExcel(DataTable table, string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Sheet1");
                sheet.Cells["A1"].LoadFromDataTable(table, true);
                package.SaveAs(new FileInfo(path));
            }
        }
    }
}

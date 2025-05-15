using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Data;
using System.IO;

namespace DataPreprocessingTool.FileControllers
{
    public class ExcelFileLoader
    {
        public DataTable Load(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var dt = new DataTable();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column;
                int rowCount = worksheet.Dimension.End.Row;

                // 열 이름 추가
                for (int col = 1; col <= colCount; col++)
                    dt.Columns.Add(worksheet.Cells[1, col].Text);

                // 데이터 행 추가
                for (int row = 2; row <= rowCount; row++)
                {
                    var newRow = dt.NewRow();
                    for (int col = 1; col <= colCount; col++)
                        newRow[col - 1] = worksheet.Cells[row, col].Text;
                    dt.Rows.Add(newRow);
                }
            }

            return dt;
        }
    }
}

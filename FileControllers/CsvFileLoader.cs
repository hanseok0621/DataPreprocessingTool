using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace DataPreprocessingTool.FileControllers
{
    public class CsvFileLoader
    {
        public DataTable Load(string filePath)
        {
            var dt = new DataTable();

            using (var reader = new StreamReader(filePath, Encoding.Default))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            using (var dr = new CsvDataReader(csv)) // CsvHelper에서 제공
            {
                dt.Load(dr);
            }

            foreach (DataColumn col in dt.Columns)
                col.ReadOnly = false;

            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPreprocessingTool
{
    public partial class EncodingForm : Form
    {
        private DataTable data;
        private DataGridView grid;

        public EncodingForm(DataTable source, DataGridView targetGrid)
        {
            InitializeComponent();
            data = source;
            grid = targetGrid;

            comboColumns.DisplayMember = "Text";
            comboColumns.ValueMember = "Value";

            foreach (DataColumn col in data.Columns)
            {
                var distinctCount = data.AsEnumerable()
                    .Select(r => r[col]?.ToString()?.Trim())
                    .Where(v => !string.IsNullOrWhiteSpace(v))
                    .Distinct()
                    .Count();

                if (distinctCount > 0 && distinctCount <= 20) // 고유값이 20개 이하일 때만 인코딩 대상으로 간주
                {
                    comboColumns.Items.Add(new
                    {
                        Text = $"{col.ColumnName} ({distinctCount}개)",
                        Value = col.ColumnName
                    });
                }
            }


            comboMethod.Items.AddRange(new string[]
            {
                "Label Encoding",
                "One-Hot Encoding"
            });
        }

        private void btnApplyEncoding_Click(object sender, EventArgs e)
        {
            string col = (comboColumns.SelectedItem as dynamic)?.Value;
            string method = comboMethod.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(col) || string.IsNullOrWhiteSpace(method))
            {
                MessageBox.Show("컬럼과 인코딩 방식을 선택하세요.");
                return;
            }

            switch (method)
            {
                case "Label Encoding":
                    ApplyLabelEncoding(col);
                    break;
                case "One-Hot Encoding":
                    ApplyOneHotEncoding(col);
                    break;
            }

            grid.DataSource = null;
            grid.DataSource = data;
            this.Close();
        }
        private void ApplyLabelEncoding(string col)
        {
            var uniqueValues = data.AsEnumerable()
                .Select(r => r[col]?.ToString()?.Trim())
                .Distinct()
                .Where(v => !string.IsNullOrWhiteSpace(v))
                .Select((val, idx) => new { val, idx })
                .ToDictionary(x => x.val, x => x.idx);

            string newCol = $"{col}_인코딩";
            if (!data.Columns.Contains(newCol))
                data.Columns.Add(newCol, typeof(int));

            foreach (DataRow row in data.Rows)
            {
                var val = row[col]?.ToString()?.Trim();
                row[newCol] = uniqueValues.TryGetValue(val, out int code) ? code : -1;
            }
        }

        private void ApplyOneHotEncoding(string col)
        {
            var uniqueValues = data.AsEnumerable()
                .Select(r => r[col]?.ToString()?.Trim())
                .Distinct()
                .Where(v => !string.IsNullOrWhiteSpace(v))
                .ToList();

            foreach (var category in uniqueValues)
            {
                string newCol = $"{col}_{category}";
                if (!data.Columns.Contains(newCol))
                    data.Columns.Add(newCol, typeof(int));

                foreach (DataRow row in data.Rows)
                {
                    string val = row[col]?.ToString()?.Trim();
                    row[newCol] = val == category ? 1 : 0;
                }
            }
        }

    }
}

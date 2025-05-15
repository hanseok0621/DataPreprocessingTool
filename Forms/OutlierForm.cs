using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Statistics;

namespace DataPreprocessingTool
{
    public partial class OutlierForm : Form
    {
        private DataTable data;
        private DataGridView grid;

        public OutlierForm(DataTable source, DataGridView targetGrid)
        {
            InitializeComponent();
            data = source;
            grid = targetGrid;

            comboColumns.DisplayMember = "Text";
            comboColumns.ValueMember = "Value";

            foreach (DataColumn col in data.Columns)
            {
                if (IsNumericColumn(col))
                {
                    comboColumns.Items.Add(new { Text = col.ColumnName, Value = col.ColumnName });
                }
            }
        }

        private bool IsNumericColumn(DataColumn col)
        {
            foreach (DataRow row in data.Rows)
            {
                var val = row[col]?.ToString()?.Replace(",", "").Trim();
                if (!string.IsNullOrWhiteSpace(val))
                    return double.TryParse(val, out _);
            }
            return false;
        }

        private void btnApplyOutlier_Click(object sender, EventArgs e)
        {
            string col = (comboColumns.SelectedItem as dynamic)?.Value;

            if (string.IsNullOrWhiteSpace(col))
            {
                MessageBox.Show("열을 선택하세요.");
                return;
            }

            RemoveOutliers_Iqr(col);

            grid.DataSource = null;
            grid.DataSource = data;
            this.Close();
        }

        private void RemoveOutliers_Iqr(string col)
        {
            var values = data.AsEnumerable()
                .Where(r => double.TryParse(r[col]?.ToString()?.Trim(), out _))
                .Select(r => Convert.ToDouble(r[col].ToString().Trim()))
                .ToList();

            if (values.Count < 4) return;

            var sorted = values.OrderBy(x => x).ToArray();
            double q1 = Statistics.LowerQuartile(sorted);
            double q3 = Statistics.UpperQuartile(sorted);
            double iqr = q3 - q1;

            double lower = q1 - 1.5 * iqr;
            double upper = q3 + 1.5 * iqr;

            var rowsToRemove = data.AsEnumerable()
                .Where(r =>
                {
                    var raw = r[col]?.ToString()?.Trim();
                    if (double.TryParse(raw, out double val))
                        return val < lower || val > upper;
                    return false;
                }).ToList();

            foreach (var row in rowsToRemove)
                data.Rows.Remove(row);
        }

        private int CountIqrOutliers(string col)
        {
            var values = data.AsEnumerable()
                .Where(r => double.TryParse(r[col]?.ToString()?.Trim(), out _))
                .Select(r => Convert.ToDouble(r[col].ToString().Trim()))
                .OrderBy(v => v)
                .ToList();

            if (values.Count < 4) return 0;

            double q1 = Statistics.LowerQuartile(values);
            double q3 = Statistics.UpperQuartile(values);
            double iqr = q3 - q1;
            double lower = q1 - 1.5 * iqr;
            double upper = q3 + 1.5 * iqr;

            return values.Count(v => v < lower || v > upper);
        }

        private void comboColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = comboColumns.SelectedItem as dynamic;
            string col = selected?.Value;

            if (string.IsNullOrWhiteSpace(col)) return;

            int count = CountIqrOutliers(col);
            lblOutlierCount.Text = $"이상치 개수: {count}개";
        }
    }
}

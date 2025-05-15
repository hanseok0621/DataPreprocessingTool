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
    public partial class ScalingForm : Form
    {
        private DataTable data;
        private DataGridView grid;

        public ScalingForm(DataTable source, DataGridView targetGrid)
        {
            InitializeComponent();
            data = source;
            grid = targetGrid;

            comboColumns.DisplayMember = "Text";
            comboColumns.ValueMember = "Value";

            foreach (DataColumn col in data.Columns)
            {
                // 수치형 컬럼 판별
                bool isNumeric = data.AsEnumerable()
                    .Select(r => r[col]?.ToString()?.Trim())
                    .Where(v => !string.IsNullOrWhiteSpace(v))
                    .All(v => double.TryParse(v, out _));

                if (isNumeric)
                {
                    comboColumns.Items.Add(new
                    {
                        Text = col.ColumnName,
                        Value = col.ColumnName
                    });
                }
            }

            comboMethod.Items.AddRange(new string[] { "Min-Max Scaling", "Z-Score Scaling" });
        }

        private void btnApplyScaling_Click(object sender, EventArgs e)
        {
            string col = (comboColumns.SelectedItem as dynamic)?.Value;
            string method = comboMethod.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(col) || string.IsNullOrWhiteSpace(method))
            {
                MessageBox.Show("컬럼과 스케일링 방법을 선택하세요.");
                return;
            }

            switch (method)
            {
                case "Min-Max Scaling":
                    ApplyMinMaxScaling(col);
                    break;
                case "Z-Score Scaling":
                    ApplyZScoreScaling(col);
                    break;
            }

            grid.DataSource = null;
            grid.DataSource = data;
            this.Close();
        }

        private void ApplyMinMaxScaling(string col)
        {
            var values = data.AsEnumerable()
                .Where(r => double.TryParse(r[col]?.ToString()?.Trim(), out _))
                .Select(r => Convert.ToDouble(r[col].ToString().Trim()))
                .ToList();

            if (values.Count == 0) return;

            double min = values.Min();
            double max = values.Max();

            string newCol = $"{col}_scaled";
            if (!data.Columns.Contains(newCol))
                data.Columns.Add(newCol, typeof(double));

            foreach (DataRow row in data.Rows)
            {
                var raw = row[col]?.ToString()?.Trim();
                if (double.TryParse(raw, out double val))
                {
                    double scaled = Math.Round((val - min) / (max - min), 6);
                    row[newCol] = scaled;
                }
                else
                {
                    row[newCol] = DBNull.Value;
                }
            }
        }

        private void ApplyZScoreScaling(string col)
        {
            var values = data.AsEnumerable()
                .Where(r => double.TryParse(r[col]?.ToString()?.Trim(), out _))
                .Select(r => Convert.ToDouble(r[col].ToString().Trim()))
                .ToList();

            if (values.Count == 0) return;

            double mean = values.Mean();
            double std = values.StandardDeviation();

            string newCol = $"{col}_standardized";
            if (!data.Columns.Contains(newCol))
                data.Columns.Add(newCol, typeof(double));

            foreach (DataRow row in data.Rows)
            {
                var raw = row[col]?.ToString()?.Trim();
                if (double.TryParse(raw, out double val))
                {
                    double standardized = Math.Round((val - mean) / std, 6);
                    row[newCol] = standardized;
                }
                else
                {
                    row[newCol] = DBNull.Value;
                }
            }
        }

    }
}

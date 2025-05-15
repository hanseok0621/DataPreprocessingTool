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
    public partial class MissingValueForm : Form
    {
        private DataTable data;
        private DataGridView grid;

        public MissingValueForm(DataTable source, DataGridView targetGrid)
        {
            InitializeComponent();
            data = source;
            grid = targetGrid;

            comboColumns.DisplayMember = "Text";
            comboColumns.ValueMember = "Value";

            foreach (DataColumn col in data.Columns)
            {
                int missingCount = data.AsEnumerable()
                    .Count(r => string.IsNullOrWhiteSpace(r[col.ColumnName]?.ToString()));

                if (missingCount > 0)
                {
                    comboColumns.Items.Add(new
                    {
                        Text = $"{col.ColumnName} ({missingCount}개 결측)",
                        Value = col.ColumnName
                    });
                }
            }

            comboStrategy.Items.AddRange(new string[] { "평균으로 대체", "중앙값으로 대체", "최빈값으로 대체", "결측치 포함 행 제거" });
        }

        private void btnApplyMissing_Click(object sender, EventArgs e)
        {
            string selected = comboColumns.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selected))
            {
                MessageBox.Show("컬럼을 선택하세요.");
                return;
            }

            // "총인구수 (10개 결측)" → "총인구수"
            string col = (comboColumns.SelectedItem as dynamic)?.Value;

            string strategy = comboStrategy.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(strategy))
            {
                MessageBox.Show("처리 방식을 선택하세요.");
                return;
            }

            switch (strategy)
            {
                case "평균으로 대체":
                    FillWithMean(col);
                    break;
                case "중앙값으로 대체":
                    FillWithMedian(col);
                    break;
                case "최빈값으로 대체":
                    FillWithMode(col);
                    break;
                case "결측치 포함 행 제거":
                    RemoveRowsWithMissing(col);
                    break;
            }

            grid.DataSource = null;
            grid.DataSource = data;
            this.Close();
        }

        private void FillWithMean(string col)
        {
            var nums = data.AsEnumerable()
                .Where(r => !r.IsNull(col) && double.TryParse(r[col].ToString(), out _))
                .Select(r => Convert.ToDouble(r[col].ToString()))
                .ToList();

            if (nums.Count == 0) return;
            double mean = nums.Average();

            foreach (DataRow row in data.Rows)
            {
                var val = row[col]?.ToString();
                if (string.IsNullOrWhiteSpace(val))
                    row[col] = mean;
            }
        }

        private void FillWithMedian(string col)
        {
            var nums = data.AsEnumerable()
                .Where(r => !r.IsNull(col) && double.TryParse(r[col].ToString(), out _))
                .Select(r => Convert.ToDouble(r[col].ToString()))
                .OrderBy(x => x)
                .ToList();

            if (nums.Count == 0) return;
            double median = nums.Count % 2 == 0
                ? (nums[nums.Count / 2 - 1] + nums[nums.Count / 2]) / 2.0
                : nums[nums.Count / 2];

            foreach (DataRow row in data.Rows)
            {
                var val = row[col]?.ToString();
                if (string.IsNullOrWhiteSpace(val))
                    row[col] = median;
            }
        }

        private void FillWithMode(string col)
        {
            var nums = data.AsEnumerable()
                .Where(r => !r.IsNull(col) && double.TryParse(r[col].ToString(), out _))
                .Select(r => r[col].ToString())
                .GroupBy(v => v)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault()?.Key;

            if (nums == null) return;

            foreach (DataRow row in data.Rows)
            {
                var val = row[col]?.ToString();
                if (string.IsNullOrWhiteSpace(val))
                    row[col] = nums;
            }
        }

        private void RemoveRowsWithMissing(string col)
        {
            var rowsToRemove = data.AsEnumerable()
                .Where(r => string.IsNullOrWhiteSpace(r[col]?.ToString()))
                .ToList();

            foreach (var row in rowsToRemove)
                data.Rows.Remove(row);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MathNet.Numerics.Statistics;

namespace DataPreprocessingTool
{
    public partial class InfoForm : Form
    {
        public InfoForm(DataTable dt)
        {
            InitializeComponent();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"총 행 수: {dt.Rows.Count}");
            sb.AppendLine($"총 열 수: {dt.Columns.Count}");
            sb.AppendLine();

            sb.AppendLine("컬럼 목록:");
            foreach (DataColumn col in dt.Columns)
            {
                Type inferredType = InferColumnType(dt, col.ColumnName);
                sb.AppendLine($"- {col.ColumnName} ({inferredType.Name})");
            }

            sb.AppendLine();
            sb.AppendLine("📊 수치형 컬럼 통계:");

            foreach (DataColumn col in dt.Columns)
            {
                if (LooksLikeNumeric(dt, col.ColumnName))
                {
                    var stats = GetNumericStats(dt, col.ColumnName);
                    sb.AppendLine($"- {col.ColumnName}: {stats}");
                }
            }

            textBoxInfo.Text = sb.ToString();
            btnClose.Focus();
        }

        // 값으로부터 열의 타입을 추론함
        private Type InferColumnType(DataTable dt, string columnName)
        {
            bool allInt = true;

            foreach (DataRow row in dt.Rows)
            {
                var raw = row[columnName]?.ToString()?.Replace(",", "").Trim();
                if (string.IsNullOrWhiteSpace(raw)) continue;

                if (!double.TryParse(raw, out double num))
                    return typeof(string);

                if (num % 1 != 0)
                    allInt = false;
            }

            if (allInt) return typeof(int);
            return typeof(double);
        }

        // 숫자처럼 보이는 값이 있는지 확인
        private bool LooksLikeNumeric(DataTable dt, string columnName)
        {
            foreach (DataRow row in dt.Rows)
            {
                var raw = row[columnName]?.ToString()?.Replace(",", "").Trim();
                if (!string.IsNullOrWhiteSpace(raw))
                {
                    return double.TryParse(raw, out _);
                }
            }
            return false;
        }

        // 최솟값, 최댓값, 평균, 표준편차, 결측치 수 계산
        private string GetNumericStats(DataTable dt, string columnName)
        {
            List<double> values = new List<double>();
            int missing = 0;

            foreach (DataRow row in dt.Rows)
            {
                var raw = row[columnName]?.ToString()?.Replace(",", "").Trim();

                if (string.IsNullOrWhiteSpace(raw))
                {
                    missing++;
                    continue;
                }

                if (double.TryParse(raw, out double num))
                    values.Add(num);
                else
                    missing++;
            }

            if (values.Count == 0) return "(값 없음)";

            var stats = new DescriptiveStatistics(values);

            return $"최솟값: {stats.Minimum:N0}, 최댓값: {stats.Maximum:N0}, 평균: {stats.Mean:N2}, 표준편차: {stats.StandardDeviation:N2}, 결측치: {missing}";
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

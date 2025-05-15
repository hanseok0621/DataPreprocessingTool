using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataPreprocessingTool.FileControllers;

namespace DataPreprocessingTool
{
    public partial class MainForm : Form
    {
        private DataTable originalTable;
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Excel 또는 CSV 파일 (*.xlsx;*.csv)|*.xlsx;*.csv"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = dialog.FileName;
                string ext = Path.GetExtension(filePath).ToLower();

                DataTable dt;

                try
                {
                    switch (ext)
                    {
                        case ".xlsx":
                            var excelLoader = new ExcelFileLoader();
                            dt = excelLoader.Load(filePath);
                            break;
                        case ".csv":
                            var csvLoader = new CsvFileLoader();
                            dt = csvLoader.Load(filePath);
                            break;
                        default:
                            throw new NotSupportedException("지원하지 않는 파일 형식입니다.");
                    }

                    originalTable = dt;
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("파일 불러오기 중 오류: " + ex.Message);
                }
            }

            dataGridView1.Visible = true;
            tabControlSplit.Visible = false;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            Rectangle headerBounds = new Rectangle(
                e.RowBounds.Left, e.RowBounds.Top,
                grid.RowHeadersWidth, e.RowBounds.Height);

            e.Graphics.DrawString(rowIdx, grid.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource is DataTable dt)
            {
                InfoForm infoForm = new InfoForm(dt);
                infoForm.Show(); // 모달리스
            }
            else
            {
                MessageBox.Show("먼저 데이터를 불러오세요.");
            }
        }

        private void btnColumnRemove_Click(object sender, EventArgs e)
        {
            if (originalTable == null)
            {
                MessageBox.Show("먼저 데이터를 불러오세요.");
                return;
            }

            var removeForm = new ColumnRemoveForm(originalTable, dataGridView1);
            removeForm.Show(); // 모달리스로 열기
        }

        private void btnMissingValue_Click(object sender, EventArgs e)
        {
            if (originalTable == null)
            {
                MessageBox.Show("먼저 데이터를 불러오세요.");
                return;
            }

            var form = new MissingValueForm(originalTable, dataGridView1);
            form.Show(); // 모달리스
        }

        private void btnOutlier_Click(object sender, EventArgs e)
        {
            if (originalTable == null)
            {
                MessageBox.Show("먼저 데이터를 불러오세요.");
                return;
            }

            var form = new OutlierForm(originalTable, dataGridView1);
            form.Show(); // 모달리스
        }

        private void btnEncoding_Click(object sender, EventArgs e)
        {
            if (originalTable == null)
            {
                MessageBox.Show("먼저 데이터를 불러오세요.");
                return;
            }

            var form = new EncodingForm(originalTable, dataGridView1);
            form.Show();
        }

        private void btnScaling_Click(object sender, EventArgs e)
        {
            if (originalTable == null)
            {
                MessageBox.Show("먼저 데이터를 불러오세요.");
                return;
            }

            var form = new ScalingForm(originalTable, dataGridView1);
            form.Show();
        }

        private void btnSplitData_Click(object sender, EventArgs e)
        {
            if (originalTable == null)
            {
                MessageBox.Show("먼저 데이터를 불러오세요.");
                return;
            }

            var splitForm = new SplitForm();
            splitForm.OnSplitConfirmed = (trainRatio, valRatio, testRatio) =>
            {
                var (train, val, test) = SplitData(originalTable, trainRatio, valRatio, testRatio);

                dgvTrain.DataSource = train;
                dgvValidation.DataSource = val;
                dgvTest.DataSource = test;

                dgvTrain.RowPostPaint += dataGridView1_RowPostPaint;
                dgvValidation.RowPostPaint += dataGridView1_RowPostPaint;
                dgvTest.RowPostPaint += dataGridView1_RowPostPaint;

                tabControlSplit.Visible = true;
                dataGridView1.Visible = false;
            };

            splitForm.Show();
        }

        private (DataTable, DataTable, DataTable) SplitData(DataTable original, double trainRatio, double valRatio, double testRatio)
        {
            var rows = original.AsEnumerable().ToList();
            var rnd = new Random();
            rows = rows.OrderBy(r => rnd.Next()).ToList();

            int total = rows.Count;
            int trainCount = (int)(total * trainRatio);
            int valCount = (int)(total * valRatio);

            var trainRows = rows.Take(trainCount);
            var valRows = rows.Skip(trainCount).Take(valCount);
            var testRows = rows.Skip(trainCount + valCount);

            DataTable train = original.Clone();
            DataTable val = original.Clone();
            DataTable test = original.Clone();

            foreach (var r in trainRows) train.ImportRow(r);
            foreach (var r in valRows) val.ImportRow(r);
            foreach (var r in testRows) test.ImportRow(r);

            return (train, val, test);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible && dataGridView1.DataSource is DataTable dtOriginal)
            {
                DataSaver.SaveWithDialog(dtOriginal);
            }
            else if (tabControlSplit.Visible)
            {
                if (dgvTrain.DataSource is DataTable dtTrain)
                    DataSaver.SaveWithDialog(dtTrain);

                if (dgvValidation.DataSource is DataTable dtVal)
                    DataSaver.SaveWithDialog(dtVal);

                if (dgvTest.DataSource is DataTable dtTest)
                    DataSaver.SaveWithDialog(dtTest);
            }
            else
            {
                MessageBox.Show("저장할 데이터가 없습니다.");
            }
        }
    }
}

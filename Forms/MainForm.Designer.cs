using System.Windows.Forms;
using System.Drawing;
namespace DataPreprocessingTool
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnShowInfo = new System.Windows.Forms.Button();
            this.btnColumnRemove = new System.Windows.Forms.Button();
            this.btnMissingValue = new System.Windows.Forms.Button();
            this.btnOutlier = new System.Windows.Forms.Button();
            this.btnEncoding = new System.Windows.Forms.Button();
            this.btnScaling = new System.Windows.Forms.Button();
            this.tabControlSplit = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvTrain = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvValidation = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvTest = new System.Windows.Forms.DataGridView();
            this.btnSplitData = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControlSplit.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrain)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidation)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.Color.White;
            this.btnOpenFile.FlatAppearance.BorderSize = 0;
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnOpenFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnOpenFile.Location = new System.Drawing.Point(5, 0);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(100, 35);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "불러오기";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1166, 637);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // btnShowInfo
            // 
            this.btnShowInfo.BackColor = System.Drawing.Color.White;
            this.btnShowInfo.FlatAppearance.BorderSize = 0;
            this.btnShowInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowInfo.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnShowInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnShowInfo.Location = new System.Drawing.Point(110, 0);
            this.btnShowInfo.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnShowInfo.Name = "btnShowInfo";
            this.btnShowInfo.Size = new System.Drawing.Size(100, 35);
            this.btnShowInfo.TabIndex = 1;
            this.btnShowInfo.Text = "기본정보";
            this.btnShowInfo.UseVisualStyleBackColor = false;
            this.btnShowInfo.Click += new System.EventHandler(this.btnShowInfo_Click);
            // 
            // btnColumnRemove
            // 
            this.btnColumnRemove.BackColor = System.Drawing.Color.White;
            this.btnColumnRemove.FlatAppearance.BorderSize = 0;
            this.btnColumnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColumnRemove.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnColumnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnColumnRemove.Location = new System.Drawing.Point(215, 0);
            this.btnColumnRemove.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnColumnRemove.Name = "btnColumnRemove";
            this.btnColumnRemove.Size = new System.Drawing.Size(100, 35);
            this.btnColumnRemove.TabIndex = 2;
            this.btnColumnRemove.Text = "열 제거";
            this.btnColumnRemove.UseVisualStyleBackColor = false;
            this.btnColumnRemove.Click += new System.EventHandler(this.btnColumnRemove_Click);
            // 
            // btnMissingValue
            // 
            this.btnMissingValue.BackColor = System.Drawing.Color.White;
            this.btnMissingValue.FlatAppearance.BorderSize = 0;
            this.btnMissingValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMissingValue.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMissingValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnMissingValue.Location = new System.Drawing.Point(320, 0);
            this.btnMissingValue.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnMissingValue.Name = "btnMissingValue";
            this.btnMissingValue.Size = new System.Drawing.Size(100, 35);
            this.btnMissingValue.TabIndex = 3;
            this.btnMissingValue.Text = "결측치 처리";
            this.btnMissingValue.UseVisualStyleBackColor = false;
            this.btnMissingValue.Click += new System.EventHandler(this.btnMissingValue_Click);
            // 
            // btnOutlier
            // 
            this.btnOutlier.BackColor = System.Drawing.Color.White;
            this.btnOutlier.FlatAppearance.BorderSize = 0;
            this.btnOutlier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutlier.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnOutlier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnOutlier.Location = new System.Drawing.Point(425, 0);
            this.btnOutlier.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnOutlier.Name = "btnOutlier";
            this.btnOutlier.Size = new System.Drawing.Size(100, 35);
            this.btnOutlier.TabIndex = 4;
            this.btnOutlier.Text = "이상치 처리";
            this.btnOutlier.UseVisualStyleBackColor = false;
            this.btnOutlier.Click += new System.EventHandler(this.btnOutlier_Click);
            // 
            // btnEncoding
            // 
            this.btnEncoding.BackColor = System.Drawing.Color.White;
            this.btnEncoding.FlatAppearance.BorderSize = 0;
            this.btnEncoding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncoding.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEncoding.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnEncoding.Location = new System.Drawing.Point(530, 0);
            this.btnEncoding.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnEncoding.Name = "btnEncoding";
            this.btnEncoding.Size = new System.Drawing.Size(100, 35);
            this.btnEncoding.TabIndex = 5;
            this.btnEncoding.Text = "인코딩";
            this.btnEncoding.UseVisualStyleBackColor = false;
            this.btnEncoding.Click += new System.EventHandler(this.btnEncoding_Click);
            // 
            // btnScaling
            // 
            this.btnScaling.BackColor = System.Drawing.Color.White;
            this.btnScaling.FlatAppearance.BorderSize = 0;
            this.btnScaling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScaling.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnScaling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnScaling.Location = new System.Drawing.Point(635, 0);
            this.btnScaling.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnScaling.Name = "btnScaling";
            this.btnScaling.Size = new System.Drawing.Size(100, 35);
            this.btnScaling.TabIndex = 6;
            this.btnScaling.Text = "스케일링";
            this.btnScaling.UseVisualStyleBackColor = false;
            this.btnScaling.Click += new System.EventHandler(this.btnScaling_Click);
            // 
            // tabControlSplit
            // 
            this.tabControlSplit.Controls.Add(this.tabPage1);
            this.tabControlSplit.Controls.Add(this.tabPage2);
            this.tabControlSplit.Controls.Add(this.tabPage3);
            this.tabControlSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSplit.Location = new System.Drawing.Point(0, 0);
            this.tabControlSplit.Name = "tabControlSplit";
            this.tabControlSplit.SelectedIndex = 0;
            this.tabControlSplit.Size = new System.Drawing.Size(1166, 637);
            this.tabControlSplit.TabIndex = 8;
            this.tabControlSplit.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvTrain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1158, 611);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Train";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvTrain
            // 
            this.dgvTrain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrain.Location = new System.Drawing.Point(3, 3);
            this.dgvTrain.Name = "dgvTrain";
            this.dgvTrain.RowTemplate.Height = 23;
            this.dgvTrain.Size = new System.Drawing.Size(1152, 605);
            this.dgvTrain.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvValidation);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1158, 611);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Validation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvValidation
            // 
            this.dgvValidation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValidation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvValidation.Location = new System.Drawing.Point(3, 3);
            this.dgvValidation.Name = "dgvValidation";
            this.dgvValidation.RowTemplate.Height = 23;
            this.dgvValidation.Size = new System.Drawing.Size(1152, 605);
            this.dgvValidation.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvTest);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1158, 611);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Test";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvTest
            // 
            this.dgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTest.Location = new System.Drawing.Point(3, 3);
            this.dgvTest.Name = "dgvTest";
            this.dgvTest.RowTemplate.Height = 23;
            this.dgvTest.Size = new System.Drawing.Size(1152, 605);
            this.dgvTest.TabIndex = 1;
            // 
            // btnSplitData
            // 
            this.btnSplitData.BackColor = System.Drawing.Color.White;
            this.btnSplitData.FlatAppearance.BorderSize = 0;
            this.btnSplitData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSplitData.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSplitData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSplitData.Location = new System.Drawing.Point(740, 0);
            this.btnSplitData.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSplitData.Name = "btnSplitData";
            this.btnSplitData.Size = new System.Drawing.Size(100, 35);
            this.btnSplitData.TabIndex = 7;
            this.btnSplitData.Text = "데이터 분할";
            this.btnSplitData.UseVisualStyleBackColor = false;
            this.btnSplitData.Click += new System.EventHandler(this.btnSplitData_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSave.Location = new System.Drawing.Point(845, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "저장하기";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnOpenFile);
            this.flowLayoutPanel1.Controls.Add(this.btnShowInfo);
            this.flowLayoutPanel1.Controls.Add(this.btnColumnRemove);
            this.flowLayoutPanel1.Controls.Add(this.btnMissingValue);
            this.flowLayoutPanel1.Controls.Add(this.btnOutlier);
            this.flowLayoutPanel1.Controls.Add(this.btnEncoding);
            this.flowLayoutPanel1.Controls.Add(this.btnScaling);
            this.flowLayoutPanel1.Controls.Add(this.btnSplitData);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(69, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(955, 42);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelHeader.Controls.Add(this.flowLayoutPanel1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1166, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.dataGridView1);
            this.panelContent.Controls.Add(this.tabControlSplit);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1166, 637);
            this.panelContent.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 697);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "DataPreprocessingTool";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControlSplit.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrain)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidation)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnShowInfo;
        private System.Windows.Forms.Button btnColumnRemove;
        private System.Windows.Forms.Button btnMissingValue;
        private System.Windows.Forms.Button btnOutlier;
        private System.Windows.Forms.Button btnEncoding;
        private System.Windows.Forms.Button btnScaling;
        private System.Windows.Forms.TabControl tabControlSplit;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnSplitData;
        private System.Windows.Forms.DataGridView dgvTrain;
        private System.Windows.Forms.DataGridView dgvValidation;
        private System.Windows.Forms.DataGridView dgvTest;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelHeader;
        private Panel panelContent;
    }
}


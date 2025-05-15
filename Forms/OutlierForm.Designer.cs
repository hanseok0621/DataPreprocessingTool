namespace DataPreprocessingTool
{
    partial class OutlierForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutlierForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.lblOutlierCount = new System.Windows.Forms.Label();
            this.comboColumns = new System.Windows.Forms.ComboBox();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnApplyOutlier = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(400, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(20, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(300, 30);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "이상치 처리";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.lblOutlierCount);
            this.panelContent.Controls.Add(this.comboColumns);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(400, 180);
            this.panelContent.TabIndex = 1;
            // 
            // lblOutlierCount
            // 
            this.lblOutlierCount.AutoSize = true;
            this.lblOutlierCount.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblOutlierCount.Location = new System.Drawing.Point(20, 80);
            this.lblOutlierCount.Name = "lblOutlierCount";
            this.lblOutlierCount.Size = new System.Drawing.Size(92, 19);
            this.lblOutlierCount.TabIndex = 0;
            this.lblOutlierCount.Text = "이상치 개수: ";
            // 
            // comboColumns
            // 
            this.comboColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColumns.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.comboColumns.FormattingEnabled = true;
            this.comboColumns.Location = new System.Drawing.Point(20, 30);
            this.comboColumns.Name = "comboColumns";
            this.comboColumns.Size = new System.Drawing.Size(340, 25);
            this.comboColumns.TabIndex = 0;
            this.comboColumns.SelectedIndexChanged += new System.EventHandler(this.comboColumns_SelectedIndexChanged);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelFooter.Controls.Add(this.btnApplyOutlier);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 240);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(400, 60);
            this.panelFooter.TabIndex = 2;
            // 
            // btnApplyOutlier
            // 
            this.btnApplyOutlier.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnApplyOutlier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnApplyOutlier.FlatAppearance.BorderSize = 0;
            this.btnApplyOutlier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyOutlier.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnApplyOutlier.ForeColor = System.Drawing.Color.White;
            this.btnApplyOutlier.Location = new System.Drawing.Point(290, 15);
            this.btnApplyOutlier.Name = "btnApplyOutlier";
            this.btnApplyOutlier.Size = new System.Drawing.Size(90, 30);
            this.btnApplyOutlier.TabIndex = 0;
            this.btnApplyOutlier.Text = "확인";
            this.btnApplyOutlier.UseVisualStyleBackColor = false;
            this.btnApplyOutlier.Click += new System.EventHandler(this.btnApplyOutlier_Click);
            // 
            // OutlierForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutlierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "이상치 처리";
            this.panelHeader.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.ComboBox comboColumns;
        private System.Windows.Forms.Label lblOutlierCount;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnApplyOutlier;
    }
}

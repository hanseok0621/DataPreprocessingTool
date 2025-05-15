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
    public partial class SplitForm : Form
    {
        public Action<double, double, double> OnSplitConfirmed;
        public SplitForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            double train = (double)numTrain.Value / 100;
            double val = (double)numValidation.Value / 100;
            double test = (double)numTest.Value / 100;

            double total = train + val + test;

            if (Math.Abs(total - 1.0) > 0.01)
            {
                MessageBox.Show("세 비율의 합이 100%가 되어야 합니다.");
                return;
            }

            OnSplitConfirmed?.Invoke(train, val, test);
            this.Close();
        }
    }
}

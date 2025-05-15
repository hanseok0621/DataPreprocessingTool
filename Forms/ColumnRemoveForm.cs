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
    public partial class ColumnRemoveForm : Form
    {
        private DataTable data;
        private DataGridView targetGrid;

        public ColumnRemoveForm(DataTable source, DataGridView gridToUpdate)
        {
            InitializeComponent();
            data = source;
            targetGrid = gridToUpdate;
            LoadColumnList();
            btnRemove.Click += btnRemove_Click;
        }

        private void LoadColumnList()
        {
            checkedListBox1.Items.Clear();
            foreach (DataColumn col in data.Columns)
            {
                checkedListBox1.Items.Add(col.ColumnName);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            // 선택된 열 이름들 가져오기
            var selected = checkedListBox1.CheckedItems.Cast<string>().ToList();

            // 삭제
            foreach (var colName in selected)
            {
                if (data.Columns.Contains(colName))
                    data.Columns.Remove(colName);
            }

            // 변경 반영
            targetGrid.DataSource = null;
            targetGrid.DataSource = data;

            // 창 닫기
            this.Close();
        }
    }

}


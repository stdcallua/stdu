using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stdu.autobackup
{
    public partial class Main : Form
    {
        public List<BackupFileInfo> Files = new List<BackupFileInfo>();
        private BindingSource _tableSource;

        public Main()
        {
            InitializeComponent();
            ShowInTaskbar = false;
            Visible = false;
            _tableSource = new BindingSource();
            _tableSource.DataSource = Files;
            dataGridView.DataSource = _tableSource;

        }

        private void notifycator_DoubleClick(object sender, EventArgs e)
        {
            Visible = true;
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
            Activate();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            var ff = new BackupFileInfo() { FileName = openFileDialog1.FileName };
            ff.ShowSettings();
            Files.Add(ff);
            _tableSource.ResetBindings(false);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                Files[e.RowIndex].StartStop(notifycator);
            }
            if (e.ColumnIndex == 2)
            {
                Files[e.RowIndex].ShowSettings();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace stdu.autobackup
{
    public partial class BackupStorage : Form
    {
        private List<BackupStorageFileInfo> list = new List<BackupStorageFileInfo>();
        private BindingSource _tableSource;
        private BackupFileInfo _info;

        
        public void SetInfo(BackupFileInfo info)
        {
            _info = info;
            _tableSource = new BindingSource();
            var backupFiles = _info.GetBackupFiles();
            list.Clear();
            backupFiles.ForEach(b => list.Add(new BackupStorageFileInfo(b)));
            _tableSource.DataSource = list;
            dataGridView.DataSource = _tableSource;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public static void ShowBackupStorage(BackupFileInfo info)
        {
            var dialog = new BackupStorage();
            dialog.SetInfo(info);
            dialog.ShowDialog();
            dialog.Dispose();
        }

        public BackupStorage()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0) return;
            var recoveryFileName = list[dataGridView.SelectedRows[0].Index].GetFulName();
            try
            {
                File.Delete(_info.FileName);
                File.Copy(recoveryFileName, _info.FileName, true);
            }
            catch ( Exception exption)
            {
                MessageBox.Show(exption.ToString());
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}

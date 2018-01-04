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
    public partial class Main : Form
    {
        public List<BackupFileInfo> Files = new List<BackupFileInfo>();
        private BindingSource _tableSource;
        private String SettingsPath;
        public Main()
        {
            InitializeComponent();
            ShowInTaskbar = false;
            Visible = false;
            SettingsPath = Path.Combine(Application.StartupPath, "settings.xml");
            if (File.Exists(SettingsPath))
            {
                Files = Xml.Load(SettingsPath, typeof(List<BackupFileInfo>)) as List<BackupFileInfo>;
                if (Files == null) Files = new List<BackupFileInfo>();
            }
            _tableSource = new BindingSource();
            _tableSource.DataSource = Files;
            dataGridView.DataSource = _tableSource;
        }

        public void SaveSettings()
        {
            if (Files == null) Files = new List<BackupFileInfo>();
            Xml.Save(SettingsPath, Files, typeof(List<BackupFileInfo>));
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
            SaveSettings();
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
                SaveSettings();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Files.ForEach(f => f.Start(notifycator));
            _tableSource.ResetBindings(false);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Files.ForEach(f => f.Stop());
            _tableSource.ResetBindings(false);
        }
    }
}

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
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
        }

        public static void ShowSettingsDialog(BackupFileInfo info)
        {
            var dialog = new SettingsDialog();
            dialog.byAuto.Checked = info.UseWatch;
            dialog.byTimer.Checked = !info.UseWatch;
            dialog.TimerBox.Text = info.Interval.ToString();
            dialog.RepoGlobalFolder.Checked = info.RepoGlobalFolder;
            dialog.RepoNearSourceFolder.Checked = info.RepoNearSourceFolder;
            dialog.RepoUserFolder.Checked = info.RepoUserFolder;
            dialog.tbFolder.Text = info.UserFolder;
            dialog.tbMaxCount.Text = info.MaxCount.ToString();
            dialog.ShowDialog();
            info.UseWatch = dialog.byAuto.Checked;
            info.Interval = int.Parse(dialog.TimerBox.Text);
            info.RepoGlobalFolder = dialog.RepoGlobalFolder.Checked;
            info.RepoNearSourceFolder = dialog.RepoNearSourceFolder.Checked;
            info.RepoUserFolder = dialog.RepoUserFolder.Checked;
            info.UserFolder = dialog.tbFolder.Text;
            info.MaxCount = int.Parse(dialog.tbMaxCount.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() != DialogResult.OK) return;
            tbFolder.Text = folderDialog.SelectedPath;
        }
    }
}

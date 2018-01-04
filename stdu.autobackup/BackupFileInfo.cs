using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace stdu.autobackup
{
    public class BackupFileInfo
    {
        private System.IO.FileSystemWatcher Watcher;

        private System.Windows.Forms.Timer Timer; 

        public String FileName { get; set; }
        [Browsable(false)]
        public String BackupFolder { get; set; }
        [Browsable(false)]
        public int Interval { get; set; } = 5000;
        [Browsable(false)]
        public Boolean UseWatch { get; set; } = true;

        [Browsable(false)]
        public Boolean RepoNearSourceFolder { get; set; } = true;
        [Browsable(false)]
        public Boolean RepoGlobalFolder { get; set; } = false;
        [Browsable(false)]
        public Boolean RepoUserFolder { get; set; } = false;
        [Browsable(false)]
        public String UserFolder { get; set; }
        [Browsable(false)]
        public int MaxCount { get; set; } = 30;

        [XmlIgnore]
        public Image IsStartedImage
        {
            get {
                    if (IsStarted()) return Properties.Resources.media_stop;
                    else
                    return Properties.Resources.media_play;
            }
        }

        [XmlIgnore]
        public Image SettingsImage
        {
            get
            {
                return Properties.Resources.about;
            }
        }

        public Boolean IsStarted()
        {
            return (Watcher != null) || (Timer != null);
        }

        public void Start(NotifyIcon notivicator)
        {
            this.Notivicator = notivicator;
            if (IsStarted()) return;
            if (UseWatch)
            {

                Watcher = new System.IO.FileSystemWatcher(Path.GetDirectoryName(FileName), Path.GetFileName(FileName));
                Watcher.IncludeSubdirectories = false;
                Watcher.Changed += Watcher_Changed;
                Watcher.EnableRaisingEvents = true;

            }
            else
            {
                if (Interval < 999)
                {
                    MessageBox.Show("Слишком маленький интервал");
                    return;
                }
                Timer = new Timer();
                Timer.Interval = Interval;
                Timer.Tick += Timer_Tick;
                Timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Backup(FileName);
            ShowNotifi();
        }

        private DateTime lastRead = DateTime.MinValue;

        public void ShowNotifi()
        {
            if (Notivicator == null) return;
            Notivicator.BalloonTipTitle = "Создана резервная копия файла";
            Notivicator.BalloonTipText = FileName;
            Notivicator.ShowBalloonTip(3);
        }

        public void ShowNotifiRecovery()
        {
            if (Notivicator == null) return;
            Notivicator.BalloonTipTitle = "Восстановлена резервная копия файла";
            Notivicator.BalloonTipText = FileName;
            Notivicator.ShowBalloonTip(3);
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            DateTime lastWriteTime = File.GetLastWriteTime(FileName);
            if (lastWriteTime != lastRead)
            {
                Backup(FileName);
                lastRead = lastWriteTime;
                ShowNotifi();
            }
        }

        public void Stop()
        {
            if (!IsStarted()) return;
            if (UseWatch)
            {
                Watcher.Dispose();
                Watcher = null;
            }
            else
            {
                Timer.Stop();
                Timer.Dispose();
                Timer = null;
            }
        }

        public void ShowSettings()
        {
            SettingsDialog.ShowSettingsDialog(this);
        }

        [XmlIgnore]
        public NotifyIcon Notivicator;

        public void StartStop(NotifyIcon notivicator)
        {
            if (IsStarted()) Stop();
            else Start(notivicator);
        }

        private String GetDestDirectory()
        {
            FileInfo fileInfo = new FileInfo(FileName);
            String DestDirectory = fileInfo.DirectoryName;
            if (RepoGlobalFolder)
            {
                DestDirectory = Path.Combine(Application.StartupPath, "storage", fileInfo.Name);
                Directory.CreateDirectory(DestDirectory);
            }
            else
            if (RepoUserFolder)
            {
                DestDirectory = UserFolder;
            }
            return DestDirectory;
        }

        private void Backup(string value)
        {
            if (File.Exists(value))
            {
                
                FileInfo fileInfo = new FileInfo(value);
                String DestDirectory = fileInfo.DirectoryName;
                if (RepoGlobalFolder)
                {
                    DestDirectory = Path.Combine(Application.StartupPath, "storage", fileInfo.Name);
                    Directory.CreateDirectory(DestDirectory);
                }
                else
                if (RepoUserFolder)
                {
                    DestDirectory = UserFolder;
                }

                String newFileName = String.Empty;
                String sufix = String.Empty;
                var listFilesBackup = GetBackupFiles();//Directory.EnumerateFiles(DestDirectory, Path.GetFileNameWithoutExtension(value) + "_storage_*" + fileInfo.Extension, SearchOption.TopDirectoryOnly);
                if (listFilesBackup.Count() > MaxCount)
                {
                    //var orderedlist = listFilesBackup.OrderByDescending(f => File.GetCreationTime(f).ToFileTime()).ToList();
                    for (int i = MaxCount; i < listFilesBackup.Count(); i++)
                    {
                        File.Delete(listFilesBackup[i]);
                    }
                }

                int index = 0;
                while (true)
                {
                    String newName = Path.GetFileNameWithoutExtension(value) + "_storage_" + DateTime.Now.ToString("dd-M-yyyy--HH-mm-ss") + sufix + fileInfo.Extension;
                    newFileName = Path.Combine(DestDirectory, newName);
                    if (!File.Exists(newFileName)) break;
                    sufix = "_(" + index.ToString() + ")";
                    index++;
                }
                
                File.Copy(value, newFileName);
            }
        }

        public void ShowStorage()
        {
            BackupStorage.ShowBackupStorage(this);
        }

        public List<String> GetBackupFiles()
        {
            FileInfo fileInfo = new FileInfo(FileName);
            var result= Directory.EnumerateFiles(GetDestDirectory(), Path.GetFileNameWithoutExtension(FileName) + "_storage_*" + fileInfo.Extension, SearchOption.TopDirectoryOnly).ToList();
            result = result.OrderByDescending(f => File.GetCreationTime(f).ToFileTime()).ToList();
            return result;
        }
    }
}

﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        public Boolean RepoGlobalFolder { get; set; }
        [Browsable(false)]
        public Boolean RepoUserFolder { get; set; }
        [Browsable(false)]
        public String UserFolder { get; set; }
        [Browsable(false)]
        public int MaxCount { get; set; } = 30;

        public Image IsStartedImage
        {
            get {
                    if (IsStarted()) return Properties.Resources.media_stop;
                    else
                    return Properties.Resources.media_play;
            }
        }
        //[Browsable(false)]
        public Image SettingsImage
        {
            get
            {
                return Properties.Resources.about;
            }
        }

        private Boolean test;

        public Boolean IsStarted()
        {
            return (Watcher != null) || (Timer != null);
        }

        public void Start(NotifyIcon notivicator)
        {
            _notivicator = notivicator;
            if (IsStarted()) return;
            if (UseWatch)
            {

                Watcher = new System.IO.FileSystemWatcher(Path.GetDirectoryName(FileName), Path.GetFileName(FileName));
                Watcher.IncludeSubdirectories = false;
                //Watcher.NotifyFilter = NotifyFilters.FileName;
                Watcher.Changed += Watcher_Changed;
                Watcher.EnableRaisingEvents = true;

            }
            else
            {
                if (Interval < 999)
                {
                    System.Windows.Forms.MessageBox.Show("Слишком маленький интервал");
                    return;
                }
                Timer = new System.Windows.Forms.Timer();
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

        DateTime lastRead = DateTime.MinValue;

        private void ShowNotifi()
        {
            _notivicator.BalloonTipText = FileName;
            _notivicator.ShowBalloonTip(3);
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

        private NotifyIcon _notivicator;

        public void StartStop(NotifyIcon notivicator)
        {
            if (IsStarted()) Stop();
            else Start(notivicator);
        }

        private void Backup(string value)
        {
            if (File.Exists(value))
            {
                FileInfo fileInfo = new FileInfo(value);
                String newFileName = String.Empty;
                String sufix = String.Empty;
                int index = 0;
                while (true)
                {

                    String newName = Path.GetFileNameWithoutExtension(value) + "_" + DateTime.Today.ToShortDateString() + sufix + fileInfo.Extension;
                    newFileName = Path.Combine(fileInfo.DirectoryName, newName);
                    if (!File.Exists(newFileName)) break;
                    sufix = "(" + index.ToString() + ")";
                    index++;
                }
                File.Copy(value, newFileName);
            }
            else
            {
                DirectoryInfo dirInfo = new DirectoryInfo(value);
                if (dirInfo.Exists)
                {
                    String newDirName = String.Empty;
                    String sufix = String.Empty;
                    int index = 0;
                    while (true)
                    {
                        String newName = dirInfo.Name + "_" + DateTime.Today.ToShortDateString() + sufix;
                        newDirName = Path.Combine(dirInfo.Parent.FullName, newName);
                        if (!Directory.Exists(newDirName)) break;
                        sufix = "(" + index.ToString() + ")";
                        index++;
                    }
                    Directory.Move(value, newDirName);
                }
            }
        }
    }
}
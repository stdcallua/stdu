namespace stdu.autobackup
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TimerBox = new System.Windows.Forms.TextBox();
            this.byTimer = new System.Windows.Forms.RadioButton();
            this.byAuto = new System.Windows.Forms.RadioButton();
            this.gr = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbMaxCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.RepoUserFolder = new System.Windows.Forms.RadioButton();
            this.RepoGlobalFolder = new System.Windows.Forms.RadioButton();
            this.RepoNearSourceFolder = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.gr.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(166, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TimerBox);
            this.groupBox1.Controls.Add(this.byTimer);
            this.groupBox1.Controls.Add(this.byAuto);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 71);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Период сохранения";
            // 
            // TimerBox
            // 
            this.TimerBox.Location = new System.Drawing.Point(122, 42);
            this.TimerBox.Name = "TimerBox";
            this.TimerBox.Size = new System.Drawing.Size(100, 20);
            this.TimerBox.TabIndex = 6;
            // 
            // byTimer
            // 
            this.byTimer.AutoSize = true;
            this.byTimer.Location = new System.Drawing.Point(4, 42);
            this.byTimer.Name = "byTimer";
            this.byTimer.Size = new System.Drawing.Size(84, 17);
            this.byTimer.TabIndex = 5;
            this.byTimer.Text = "По таймеру";
            this.byTimer.UseVisualStyleBackColor = true;
            // 
            // byAuto
            // 
            this.byAuto.AutoSize = true;
            this.byAuto.Checked = true;
            this.byAuto.Location = new System.Drawing.Point(4, 19);
            this.byAuto.Name = "byAuto";
            this.byAuto.Size = new System.Drawing.Size(218, 17);
            this.byAuto.TabIndex = 4;
            this.byAuto.TabStop = true;
            this.byAuto.Text = "Автоматически при изменении файла";
            this.byAuto.UseVisualStyleBackColor = true;
            // 
            // gr
            // 
            this.gr.Controls.Add(this.button2);
            this.gr.Controls.Add(this.tbMaxCount);
            this.gr.Controls.Add(this.label1);
            this.gr.Controls.Add(this.tbFolder);
            this.gr.Controls.Add(this.RepoUserFolder);
            this.gr.Controls.Add(this.RepoGlobalFolder);
            this.gr.Controls.Add(this.RepoNearSourceFolder);
            this.gr.Location = new System.Drawing.Point(12, 98);
            this.gr.Name = "gr";
            this.gr.Size = new System.Drawing.Size(228, 161);
            this.gr.TabIndex = 5;
            this.gr.TabStop = false;
            this.gr.Text = "Хранилище";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 21);
            this.button2.TabIndex = 6;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbMaxCount
            // 
            this.tbMaxCount.Location = new System.Drawing.Point(166, 125);
            this.tbMaxCount.Name = "tbMaxCount";
            this.tbMaxCount.Size = new System.Drawing.Size(56, 20);
            this.tbMaxCount.TabIndex = 5;
            this.tbMaxCount.Text = "30";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ограничение по количеству";
            // 
            // tbFolder
            // 
            this.tbFolder.Location = new System.Drawing.Point(15, 94);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(188, 20);
            this.tbFolder.TabIndex = 3;
            // 
            // RepoUserFolder
            // 
            this.RepoUserFolder.AutoSize = true;
            this.RepoUserFolder.Location = new System.Drawing.Point(14, 68);
            this.RepoUserFolder.Name = "RepoUserFolder";
            this.RepoUserFolder.Size = new System.Drawing.Size(126, 17);
            this.RepoUserFolder.TabIndex = 2;
            this.RepoUserFolder.Text = "Указанный каталог";
            this.RepoUserFolder.UseVisualStyleBackColor = true;
            // 
            // RepoGlobalFolder
            // 
            this.RepoGlobalFolder.AutoSize = true;
            this.RepoGlobalFolder.Location = new System.Drawing.Point(14, 45);
            this.RepoGlobalFolder.Name = "RepoGlobalFolder";
            this.RepoGlobalFolder.Size = new System.Drawing.Size(191, 17);
            this.RepoGlobalFolder.TabIndex = 1;
            this.RepoGlobalFolder.Text = "Глобальное, рядом с бекапером";
            this.RepoGlobalFolder.UseVisualStyleBackColor = true;
            // 
            // RepoNearSourceFolder
            // 
            this.RepoNearSourceFolder.AutoSize = true;
            this.RepoNearSourceFolder.Checked = true;
            this.RepoNearSourceFolder.Location = new System.Drawing.Point(14, 22);
            this.RepoNearSourceFolder.Name = "RepoNearSourceFolder";
            this.RepoNearSourceFolder.Size = new System.Drawing.Size(110, 17);
            this.RepoNearSourceFolder.TabIndex = 0;
            this.RepoNearSourceFolder.TabStop = true;
            this.RepoNearSourceFolder.Text = "Рядом с файлом";
            this.RepoNearSourceFolder.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 301);
            this.Controls.Add(this.gr);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsDialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gr.ResumeLayout(false);
            this.gr.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox TimerBox;
        public System.Windows.Forms.RadioButton byTimer;
        public System.Windows.Forms.RadioButton byAuto;
        private System.Windows.Forms.GroupBox gr;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbMaxCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.RadioButton RepoUserFolder;
        private System.Windows.Forms.RadioButton RepoGlobalFolder;
        private System.Windows.Forms.RadioButton RepoNearSourceFolder;
    }
}
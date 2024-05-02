namespace M3u8FileDownload
{
    partial class frmMain
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPageDownLoad = new System.Windows.Forms.TabPage();
            this.tbFilm = new System.Windows.Forms.TextBox();
            this.lbUrl = new System.Windows.Forms.Label();
            this.lbFilm = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.lbDownLoadSize = new System.Windows.Forms.Label();
            this.tabPageSetting = new System.Windows.Forms.TabPage();
            this.chbM3u8 = new System.Windows.Forms.CheckBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.tbMaxTryCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMaxThreadCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMaxCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMark = new System.Windows.Forms.TextBox();
            this.lblMark = new System.Windows.Forms.Label();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.btnDeleteFiles = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grbLog = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.grbProcess = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.tabCtrl.SuspendLayout();
            this.tabPageDownLoad.SuspendLayout();
            this.tabPageSetting.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.grbLog.SuspendLayout();
            this.grbProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(103, 52);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(529, 25);
            this.txtUrl.TabIndex = 0;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(643, 52);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(4);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(91, 29);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPageDownLoad);
            this.tabCtrl.Controls.Add(this.tabPageSetting);
            this.tabCtrl.Controls.Add(this.tabSetting);
            this.tabCtrl.Location = new System.Drawing.Point(16, 15);
            this.tabCtrl.Margin = new System.Windows.Forms.Padding(4);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(752, 275);
            this.tabCtrl.TabIndex = 4;
            // 
            // tabPageDownLoad
            // 
            this.tabPageDownLoad.Controls.Add(this.tbFilm);
            this.tabPageDownLoad.Controls.Add(this.lbUrl);
            this.tabPageDownLoad.Controls.Add(this.lbFilm);
            this.tabPageDownLoad.Controls.Add(this.lbSpeed);
            this.tabPageDownLoad.Controls.Add(this.lbDownLoadSize);
            this.tabPageDownLoad.Controls.Add(this.txtUrl);
            this.tabPageDownLoad.Controls.Add(this.btnDownload);
            this.tabPageDownLoad.Location = new System.Drawing.Point(4, 25);
            this.tabPageDownLoad.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageDownLoad.Name = "tabPageDownLoad";
            this.tabPageDownLoad.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageDownLoad.Size = new System.Drawing.Size(744, 246);
            this.tabPageDownLoad.TabIndex = 0;
            this.tabPageDownLoad.Text = "下载项目";
            this.tabPageDownLoad.UseVisualStyleBackColor = true;
            // 
            // tbFilm
            // 
            this.tbFilm.Location = new System.Drawing.Point(103, 21);
            this.tbFilm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFilm.Name = "tbFilm";
            this.tbFilm.Size = new System.Drawing.Size(529, 25);
            this.tbFilm.TabIndex = 5;
            // 
            // lbUrl
            // 
            this.lbUrl.AutoSize = true;
            this.lbUrl.Location = new System.Drawing.Point(21, 60);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(75, 15);
            this.lbUrl.TabIndex = 4;
            this.lbUrl.Text = "下载地址:";
            // 
            // lbFilm
            // 
            this.lbFilm.AutoSize = true;
            this.lbFilm.Location = new System.Drawing.Point(21, 28);
            this.lbFilm.Name = "lbFilm";
            this.lbFilm.Size = new System.Drawing.Size(75, 15);
            this.lbFilm.TabIndex = 4;
            this.lbFilm.Text = "电影名称:";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Location = new System.Drawing.Point(17, 136);
            this.lbSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(75, 15);
            this.lbSpeed.TabIndex = 3;
            this.lbSpeed.Text = "下载速度:";
            // 
            // lbDownLoadSize
            // 
            this.lbDownLoadSize.AutoSize = true;
            this.lbDownLoadSize.Location = new System.Drawing.Point(19, 102);
            this.lbDownLoadSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDownLoadSize.Name = "lbDownLoadSize";
            this.lbDownLoadSize.Size = new System.Drawing.Size(60, 15);
            this.lbDownLoadSize.TabIndex = 3;
            this.lbDownLoadSize.Text = "已下载:";
            // 
            // tabPageSetting
            // 
            this.tabPageSetting.Controls.Add(this.chbM3u8);
            this.tabPageSetting.Controls.Add(this.lbInfo);
            this.tabPageSetting.Controls.Add(this.tbMaxTryCount);
            this.tabPageSetting.Controls.Add(this.label4);
            this.tabPageSetting.Controls.Add(this.tbMaxThreadCount);
            this.tabPageSetting.Controls.Add(this.label3);
            this.tabPageSetting.Controls.Add(this.label2);
            this.tabPageSetting.Controls.Add(this.tbMaxCount);
            this.tabPageSetting.Controls.Add(this.label1);
            this.tabPageSetting.Controls.Add(this.tbMark);
            this.tabPageSetting.Controls.Add(this.lblMark);
            this.tabPageSetting.Location = new System.Drawing.Point(4, 25);
            this.tabPageSetting.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSetting.Name = "tabPageSetting";
            this.tabPageSetting.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageSetting.Size = new System.Drawing.Size(744, 246);
            this.tabPageSetting.TabIndex = 1;
            this.tabPageSetting.Text = "下载设置";
            this.tabPageSetting.UseVisualStyleBackColor = true;
            // 
            // chbM3u8
            // 
            this.chbM3u8.AutoSize = true;
            this.chbM3u8.Checked = true;
            this.chbM3u8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbM3u8.Location = new System.Drawing.Point(165, 160);
            this.chbM3u8.Name = "chbM3u8";
            this.chbM3u8.Size = new System.Drawing.Size(44, 19);
            this.chbM3u8.TabIndex = 3;
            this.chbM3u8.Text = "是";
            this.chbM3u8.UseVisualStyleBackColor = true;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(84, 48);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(466, 15);
            this.lbInfo.TabIndex = 2;
            this.lbInfo.Text = "一般视频文件以ts结尾，有些不是的可以修改此项，用|分割多个条件";
            // 
            // tbMaxTryCount
            // 
            this.tbMaxTryCount.Location = new System.Drawing.Point(165, 112);
            this.tbMaxTryCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMaxTryCount.Name = "tbMaxTryCount";
            this.tbMaxTryCount.Size = new System.Drawing.Size(163, 25);
            this.tbMaxTryCount.TabIndex = 1;
            this.tbMaxTryCount.Text = "3";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(29, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 34);
            this.label4.TabIndex = 0;
            this.label4.Text = "总是重新下载M3u8文件:";
            // 
            // tbMaxThreadCount
            // 
            this.tbMaxThreadCount.Location = new System.Drawing.Point(559, 75);
            this.tbMaxThreadCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMaxThreadCount.Name = "tbMaxThreadCount";
            this.tbMaxThreadCount.Size = new System.Drawing.Size(163, 25);
            this.tbMaxThreadCount.TabIndex = 1;
            this.tbMaxThreadCount.Text = "5";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(29, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "失败参试数:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(440, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "最大线程数:";
            // 
            // tbMaxCount
            // 
            this.tbMaxCount.Location = new System.Drawing.Point(167, 76);
            this.tbMaxCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMaxCount.Name = "tbMaxCount";
            this.tbMaxCount.Size = new System.Drawing.Size(163, 25);
            this.tbMaxCount.TabIndex = 1;
            this.tbMaxCount.Text = "1000000";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "下载文件最大数:";
            // 
            // tbMark
            // 
            this.tbMark.Location = new System.Drawing.Point(84, 15);
            this.tbMark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMark.Name = "tbMark";
            this.tbMark.Size = new System.Drawing.Size(637, 25);
            this.tbMark.TabIndex = 1;
            this.tbMark.Text = ".ts|https://|http://";
            // 
            // lblMark
            // 
            this.lblMark.AutoSize = true;
            this.lblMark.Location = new System.Drawing.Point(19, 20);
            this.lblMark.Name = "lblMark";
            this.lblMark.Size = new System.Drawing.Size(60, 15);
            this.lblMark.TabIndex = 0;
            this.lblMark.Text = "源判断:";
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.btnDeleteFiles);
            this.tabSetting.Controls.Add(this.btnOpenFolder);
            this.tabSetting.Controls.Add(this.label6);
            this.tabSetting.Controls.Add(this.label5);
            this.tabSetting.Location = new System.Drawing.Point(4, 25);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetting.Size = new System.Drawing.Size(744, 246);
            this.tabSetting.TabIndex = 2;
            this.tabSetting.Text = "系统设置";
            this.tabSetting.UseVisualStyleBackColor = true;
            // 
            // btnDeleteFiles
            // 
            this.btnDeleteFiles.Location = new System.Drawing.Point(136, 55);
            this.btnDeleteFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteFiles.Name = "btnDeleteFiles";
            this.btnDeleteFiles.Size = new System.Drawing.Size(91, 29);
            this.btnDeleteFiles.TabIndex = 8;
            this.btnDeleteFiles.Text = "确定";
            this.btnDeleteFiles.UseVisualStyleBackColor = true;
            this.btnDeleteFiles.Click += new System.EventHandler(this.btnDeleteFiles_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(136, 18);
            this.btnOpenFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(91, 29);
            this.btnOpenFolder.TabIndex = 8;
            this.btnOpenFolder.Text = "打开";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "删除缓存文件:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "下载文件路径:";
            // 
            // grbLog
            // 
            this.grbLog.Controls.Add(this.rtbLog);
            this.grbLog.Location = new System.Drawing.Point(21, 412);
            this.grbLog.Margin = new System.Windows.Forms.Padding(4);
            this.grbLog.Name = "grbLog";
            this.grbLog.Padding = new System.Windows.Forms.Padding(4);
            this.grbLog.Size = new System.Drawing.Size(747, 256);
            this.grbLog.TabIndex = 5;
            this.grbLog.TabStop = false;
            this.grbLog.Text = "下载日志：";
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(4, 22);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(4);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(739, 230);
            this.rtbLog.TabIndex = 4;
            this.rtbLog.Text = "";
            // 
            // grbProcess
            // 
            this.grbProcess.Controls.Add(this.btnStop);
            this.grbProcess.Controls.Add(this.btnPause);
            this.grbProcess.Controls.Add(this.prgBar);
            this.grbProcess.Location = new System.Drawing.Point(16, 298);
            this.grbProcess.Margin = new System.Windows.Forms.Padding(4);
            this.grbProcess.Name = "grbProcess";
            this.grbProcess.Padding = new System.Windows.Forms.Padding(4);
            this.grbProcess.Size = new System.Drawing.Size(748, 74);
            this.grbProcess.TabIndex = 6;
            this.grbProcess.TabStop = false;
            this.grbProcess.Text = "下载进度";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(608, 75);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(131, 32);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "重置";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(417, 75);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(131, 32);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(25, 25);
            this.prgBar.Margin = new System.Windows.Forms.Padding(4);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(713, 28);
            this.prgBar.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 676);
            this.Controls.Add(this.grbProcess);
            this.Controls.Add(this.grbLog);
            this.Controls.Add(this.tabCtrl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "下载工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabCtrl.ResumeLayout(false);
            this.tabPageDownLoad.ResumeLayout(false);
            this.tabPageDownLoad.PerformLayout();
            this.tabPageSetting.ResumeLayout(false);
            this.tabPageSetting.PerformLayout();
            this.tabSetting.ResumeLayout(false);
            this.tabSetting.PerformLayout();
            this.grbLog.ResumeLayout(false);
            this.grbProcess.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPageDownLoad;
        private System.Windows.Forms.TabPage tabPageSetting;
        private System.Windows.Forms.GroupBox grbLog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.GroupBox grbProcess;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label lbDownLoadSize;
        private System.Windows.Forms.TextBox tbMark;
        private System.Windows.Forms.Label lblMark;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.TextBox tbFilm;
        private System.Windows.Forms.Label lbUrl;
        private System.Windows.Forms.Label lbFilm;
        private System.Windows.Forms.TextBox tbMaxCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaxTryCount;
        private System.Windows.Forms.TextBox tbMaxThreadCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbM3u8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeleteFiles;
    }
}


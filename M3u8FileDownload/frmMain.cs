using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Threading;
using System.Net;
using System.IO;
 
//using System.Diagnostics.pro



namespace M3u8FileDownload
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

    
        public  List<DownLoadFileInfo> aryList = new List<DownLoadFileInfo>();
        public  string DownloadPath = "";

        private  NameValueCollection nvcDownLoadFail = new NameValueCollection();
        private  int MaxTryTimsForDownLoadFail = 3;


        private  readonly Object myObject = new object();
        private  M3u8File m = null;
        private  String VideoName = "";

        private double downLoadSize =  0;
        private double downLoadSpeed = 0;

        private System.Threading.Thread[] aryThread = null;

        private DateTime dtStart;

        private void frmMain_Load(object sender, EventArgs e)
        {

            this.DownloadPath = Application.StartupPath + "\\ts\\";
            Control.CheckForIllegalCrossThreadCalls = false;
            //this.VideoName = Application.StartupPath + "\\1.ts";

        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {

            

            this.downLoadSize = 0;
            this.downLoadSpeed = 0;

            this.dtStart = DateTime.Now;
            //
            String url = this.txtUrl.Text.Trim();
            if (url == "" || (url.StartsWith("http://") == false && url.StartsWith("https://") == false))
            {
                MessageBox.Show("请输入正确的下载地址!");
            }
            else
            {
                this.rtbLog.AppendText("下载电影：" + this.tbFilm.Text + "\r\n");
                this.rtbLog.AppendText("下载地址："+url+"\r\n");

                this.VideoName = Application.StartupPath + "\\" + DownLoadFileInfo.GetFileName(url, this.tbFilm.Text) + ".mp4"; //最后下载文件名称

                if (File.Exists(this.VideoName))
                {
                    MessageBox.Show("电影名称《"+this.tbFilm.Text + "》已经存在，请修改！");
                    return;
                }

                string fileName = DownLoadFileInfo.DownLoadM3u8(url,this.chbM3u8.Checked);
               
                if (fileName != "")
                {
                    this.rtbLog.AppendText("下载视频文件：" + fileName+"\r\n"); 
                    m = new M3u8File(fileName, url,this.tbMark.Text);
                    m.setMaxCount(this.tbMaxCount.Text.Trim());
                    m.setVideoUrlAndAESKey(); //下载aes key 文件并获取密码
                    if (m.lstUrl.Count == 0)
                    {
                        MessageBox.Show("解析M3u8文件错误");
                        return;
                    }
                    this.rtbLog.AppendText("AES KEY：" + m.AESKey + "\r\n");
                    foreach (var tsUrl in m.lstUrl)
                    {

                        String name = m.getVideoName(tsUrl); //片段名称
                        DownLoadFileInfo d = new DownLoadFileInfo(tsUrl, name, m.AESKey);
                        aryList.Add(d);

                    }


                    int maxThreadCount = M3u8File.GetetMaxCount(this.tbMaxThreadCount.Text, 5);


                    this.aryThread = new Thread[maxThreadCount];
                    for (int i = 0; i < maxThreadCount; i++)
                    {
                        aryThread[i] = new Thread(new ThreadStart(StartDownLoadFile));
                        aryThread[i].IsBackground = true;
                        aryThread[i].Start();
                    }


                    System.Threading.Thread thread = new Thread(new ThreadStart(FinishDownLoadFile));
                    thread.IsBackground = true;
                    thread.Start();

                }

                
            }


        }




        private void RemoveItem(DownLoadFileInfo d)
        {

            lock (myObject)
            {
                aryList.Remove(d);
            }

        }

        //002 解密下载的ts文件并合并到一个文件中
        private void DecodeVideoAndAppendToFile()
        {

            if (m.lstUrl.Count > 0)
            {
                this.AddToLog("解密文件个数:" + m.lstUrl.Count.ToString());
                int i = 1;
                foreach (var url in m.lstUrl)
                {
                    String name     = m.getVideoName(url); //片段名称 
                    String fileName = DownloadPath + name;                
                    m.AppendContentToVideoFile(fileName, m.AESKey, VideoName); //解密并写入到videoname 中
                    this.AddToLog(m.erroInfo);
                    this.AddToLog("已经写入文件个数:" + i.ToString());
                    i = i + 1;


                }


            }

        }

 

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="info"></param>
        private void AddToLog(string info)
        {
            if (this.rtbLog.InvokeRequired)
            {
                info = info + "\r\n";
                this.rtbLog.Invoke(new Action<string>(n => { this.rtbLog.AppendText(n); }), info);
            }
        }

        private void setPrgBar(int value)
        {
            if (this.prgBar.InvokeRequired)
            {
                
                this.rtbLog.Invoke(new Action<int>(n => { this.prgBar.Value =value; }), value);
            }
        }

        /// <summary>
        /// 保存日志并重置界面
        /// </summary>
        private void resetInfo() {

            this.setPrgBar(0);
            this.downLoadSize = 0;
            this.lbDownLoadSize.Text = "已经下载：" + this.downLoadSize.ToString() + " KB";
            this.downLoadSpeed = 0;
            this.lbSpeed.Text = "下载速度：" + this.downLoadSpeed.ToString("#.##") + " KB/秒";
            String logFile = DateTime.Now.ToString("yyyyMMddhhss");
            this.rtbLog.SaveFile(Application.StartupPath+"/log/"+logFile+".txt", RichTextBoxStreamType.PlainText);
            this.rtbLog.Text = "";

           this.aryList = new List<DownLoadFileInfo>();
           this. nvcDownLoadFail = new NameValueCollection();
           
       

    }

        private void FinishDownLoadFile() {


            bool blnRun = true;

            while (blnRun) {


                if (aryList.Count <= 0 && m.lstUrl.Count > 0) {

                    //下载线程结束才开始合并
                    if (this.aryThread != null) {

                        foreach (var t in this.aryThread) {

                            if (t.ThreadState == ThreadState.Running) {
                                Thread.Sleep(1000);
                                continue;
                            }
                        
                        }
                    
                    }


                    try
                    {
                        this.DecodeVideoAndAppendToFile();
                    }
                    catch (Exception ex)
                    {
                        this.AddToLog("文件合成错误:"+ ex.Message);
                        MessageBox.Show(ex.Message);
                    }
                    this.resetInfo();
                    this.AddToLog("文件下载合成完成!");
                    MessageBox.Show("下载完成");

                    blnRun = false;



                }


                Thread.Sleep(1000);
            }


        }

        private void StartDownLoadFile() {

            while (aryList.Count>0)
            {
                DownLoadFileInfo d = aryList[0];
                this.RemoveItem(d);
                string url = d.Url; 
                String fileName = DownloadPath + d.Name;
                WebClient wc = new WebClient();

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                double percent = 1 - double.Parse(aryList.Count.ToString()) / double.Parse(aryList.Count.ToString(this.m.lstUrl.Count.ToString()));
                int prgBarValue = (int)(percent * 100);
                this.setPrgBar(prgBarValue);

                try
                {
                    if (d.checkFile(fileName) == false)
                    {

                        this.DownLoadFile(wc, d, new Uri(url), fileName);
                       
                    }
                    else
                    {                  
                        this.AddToLog("文件 :" + fileName + "下载过了，跳过；");
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    this.AddToLog("下载错误，地址 :" + url + ",信息：" + ex.Message);
                }

                Thread.Sleep(100);

            }
        
        }

        private void DownLoadFile(WebClient wc, DownLoadFileInfo d, Uri address, String fileName) {

            int maxTime = M3u8File.GetetMaxCount(this.tbMaxTryCount.Text,3);
            int i = 1;
            while (i < maxTime) {

                String errorInfo = "";
                try
                {
                    wc.DownloadFile(address, fileName);
                }
                catch (Exception ex) {
                    errorInfo = ex.Message;
                }
                if (d.checkFile(fileName) == true) {

                    //DownLoadFileInfo d = e.UserState as DownLoadFileInfo;
                    this.downLoadSize += d.getFileSize(d.Name) / 1024;
                    this.lbDownLoadSize.Text = "已经下载：" + this.downLoadSize.ToString() + " KB";

                    double s = DateTime.Now.Subtract(this.dtStart).TotalSeconds;
                    this.downLoadSpeed = this.downLoadSize / s;

                    this.lbSpeed.Text = "下载速度：" + this.downLoadSpeed.ToString("#.##") + " KB/秒";
                    this.AddToLog("文件 :" + fileName + "下载成功");
                    return;
                }
                else
                {
                    this.AddToLog("文件 :" + fileName + "下载失败，错误信息："+errorInfo+",重试："+i.ToString());
                    i = i + 1;
                }
                Thread.Sleep(1000);

            }
        
        
        }
 
        private void btnPause_Click(object sender, EventArgs e)
        {
            //4677027fdf8f99aa



            M3u8File m = new M3u8File();
            //string[] aryFileName = "D:\net_project\NetProject\M3u8FileDownload\M3u8FileDownload\bin\Debug\ts"
            String[] aryFileName = "Gj1F42Ro,lSzIYZvc,dZym1Jxx,tOoURf2Z,zGDrtjF1,wOI3dUPp".Split(',');

            foreach (var f in aryFileName)
            {
                m.AppendContentToVideoFile(@"D:\net_project\NetProject\M3u8FileDownload\M3u8FileDownload\bin\Debug\ts\"+f+".ts", "4677027fdf8f99aa", @"d:\1.ts");
            }
            //m.AppendContentToVideoFile(@"D:\net_project\NetProject\M3u8FileDownload\M3u8FileDownload\bin\Debug\ts\bqUIwfZG.ts", "4677027fdf8f99aa", @"d:\1.ts");
            //
          
            //byte[] aryContent = System.Text.Encoding.UTF8.GetBytes("1 start");
            //m.WriteToVideoFile(aryContent, "d:\\2.txt");
            //aryContent = System.Text.Encoding.UTF8.GetBytes("2 start");
            //m.WriteToVideoFile(aryContent, "d:\\2.txt");


        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.resetInfo();
        }

        /// <summary>
        /// 打开文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            string filePath = Application.StartupPath;
            //string folderPath = @"C:\Path\To\Your\Folder";

            try
            {
                // 使用Process.Start启动文件夹浏览器
                System.Diagnostics.Process.Start("explorer.exe", filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法打开文件夹: " + ex.Message);
            }


        }

        private void btnDeleteFiles_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("您确定要删除缓存的ts视频文件吗?","提示",MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                return;
            }

            string filePath = Application.StartupPath + "/ts";
            if (System.IO.Directory.Exists(filePath))
            {
                Task.Run(() =>
                {

                    string[] aryFiles = System.IO.Directory.GetFiles(filePath);
                    foreach(var f in aryFiles)
                    {
                        try
                        {

                            System.IO.File.Delete(f);

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    MessageBox.Show("删除完成");



                });

            }
            else
            {
                MessageBox.Show("缓存文件路径不存在");
            }

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("停止下载");
            Application.Exit();
        }

        //private void btnDecode_Click(object sender, EventArgs e)
        //{
        //    string fileName = this.tbFileName.Text.Trim();
        //    string fileKey  = this.tbAESKey.Text.Trim();
        //    string fileIV   = this.tbAESIV.Text.Trim();

        //    M3u8File m3U8File = new M3u8File();

        //    if (fileName=="" || fileKey == "")
        //    {
        //        MessageBox.Show("文件名和密码是必须的");
        //        return ;
        //    }

        //    if (File.Exists(fileName) == false)
        //    {
        //        MessageBox.Show("要解密的文件不存在");
        //        return;
        //    }

        //    m3U8File.StartDecode(fileName,fileKey, fileIV);
        //    MessageBox.Show(m3U8File.erroInfo);


        //}
    }
}

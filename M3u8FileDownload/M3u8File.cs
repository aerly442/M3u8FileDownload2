using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;


namespace M3u8FileDownload
{
    public class M3u8File
    {

        public String FileName { get; set; }
        public String Url { get; set; }

        public String AESKey { get; set; }

        public List<String> lstUrl = new List<string>();

        //默认扩张名为.ts   
        public String VideoExtName { get; set; }

        private String AESKeyUrl = "";

        private int maxCount = 1000000;//1000000; //方便测试，最大文件下载数

        private bool blnKeyTypeIsBase64 = false;

        public M3u8File(String fileName, String url,String extName)
        {
            this.FileName = fileName;
            if (url.EndsWith("/"))
            {
                url = url.Substring(0, url.Length - 1);
            }
            this.Url = url;
            this.VideoExtName = extName==""?".ts":extName;
        }

        public void setMaxCount(String aMaxCount) {



            this.maxCount = GetetMaxCount(aMaxCount, 100000);

            /*
            if (aMaxCount != null && aMaxCount != "") {

                int a = 0;
                bool blnResult = Int32.TryParse(aMaxCount,out  a);
                if (blnResult && a >0) {

                    this.maxCount =  a;
                }
                
            
            }
            */
        
        }

        public static int GetetMaxCount(String aMaxCount,int  defaultCount)
        {

            if (aMaxCount != null && aMaxCount != "")
            {

                int a = 0;
                bool blnResult = Int32.TryParse(aMaxCount, out a);
                if (blnResult && a > 0)
                {

                   return  a;
                }


            }

            return defaultCount;

        }
        public M3u8File()
        {
            
        }

        public void setVideoUrlAndAESKey()
        {

            this.ReadInfoFromM3u8File();
            if (String.IsNullOrEmpty(this.AESKeyUrl) == false)
            {
                this.AESKey = this.getAESKey(this.AESKeyUrl);
            }

        }

        //根据url获取下载文静名字
        public string getVideoName(String url)
        {

            return DownLoadFileInfo.GetFileName(url, "");

            String[] aryUrl = url.Split('/');
            if (aryUrl.Length > 0)
            {
                return aryUrl[aryUrl.Length - 1];
            }
            else
            {
                return "";
            }

        }

        //下载AES Key 最多试3次
        public string getAESKey(String aAESKeyUrl)
        {

            int i = 0;
            int maxTime = 3;
            while (i < maxTime)
            {

                string key = this.downLoadAESKey(aAESKeyUrl);
                if (String.IsNullOrEmpty(key) == false)
                {
                    return key;
                }
                i = i + 1;

            }

            return "";


        }

        //下载AES key
        public string downLoadAESKey(String aAESKeyUrl)
        {

            try
            {
                WebClient wc = new WebClient();
                Console.WriteLine("Key Url is:" + aAESKeyUrl);
                byte[] aryContent = wc.DownloadData(aAESKeyUrl);
                String key = Encoding.Default.GetString(aryContent);
                byte[] aryNewContent = Encoding.Default.GetBytes(key);

                //特殊情况
                if ((aryContent.Length != aryNewContent.Length && aryContent.Length > 0)
                     || (key.Length!=16 && key.Length!= 32)
                    ) {
                    //特殊key做了base64
                    this.blnKeyTypeIsBase64 = true;
                    return Convert.ToBase64String(aryContent);
                
                }
                else {
                    this.blnKeyTypeIsBase64 = false;
                }

                
                Console.WriteLine("AES Key is :" + key);
                return key;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return "";
            }

        }

//001 下载M3u8 文件并提取AESkey 和ts 分片下载地址到list中
        public void ReadInfoFromM3u8File()
        {

            //int i        = 0;
            

            StreamReader sr = new StreamReader(FileName);
            String line = "";
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
                //#EXT-X-KEY:METHOD=AES-128,URI="/20200814/YbVVesuV/1000kb/hls/key.key"
                //提取Key
                if (line.ToUpper().IndexOf("AES-128") > 0)
                {

                    String[] aryResult = line.Split('=');
                    if (aryResult.Length >= 3)
                    {
                        String keyPath = aryResult[2].Replace("\"", "").Split(',')[0];
                        string file = this.getVideoUrl(this.Url, keyPath);
                        file = file.Replace("\"", "");
                        if (this.AESKeyUrl == null || this.AESKeyUrl =="")
                        {
                            this.AESKeyUrl = file;
                        }
                        //return;

                    }

                }


               //MessageBox.Show("line content is :"+line);

                //保存下载地址到列表中
                if (this.isVideoUrl(line) && lstUrl.IndexOf(line) < 0)
                {

                    string videoUrl = this.getVideoUrl(this.Url, line);
                    lstUrl.Add(videoUrl);
                    Console.WriteLine("video url is :" + videoUrl);
                    //MessageBox.Show("url is "+videoUrl);

                    if (lstUrl.Count > maxCount) //测试的时候不搞那么多
                    {
                        return;
                    }

                }


            }


            sr.Close();

        }


        /// <summary>
        /// 根据输入的下载地区获取域名地址
        /// </summary>
        /// <param name="url"></param>
        /// <param name="lineUrl"></param>
        /// <returns></returns>
        private String getVideoUrl(String url, String lineUrl) {

            if (lineUrl.Contains("https://") || lineUrl.Contains("http://")) {

                return lineUrl;

            }

            String aUrl = "";
            if (url.Contains("https://")) {

                aUrl = "https://";
                url = url.Replace(aUrl, "");
            }

            if (url.Contains("http://"))
            {

                aUrl = "http://";
                url = url.Replace(aUrl, "");
            }

            String[] aryUrl = url.Split('/');
            String videoUrl = aryUrl[0];

            if (lineUrl.StartsWith("/"))
            {
                return aUrl + videoUrl + lineUrl;
            }
            else {
                return aUrl + url.Substring(0, url.LastIndexOf("/")) +"/"+ lineUrl;
            }



        }


        private bool isVideoUrl(String line) {

            String[] aryMark = this.VideoExtName.Split('|');
            foreach (var mark in aryMark) {

                if (line != "" && mark.Trim() != "") {
                    //MessageBox.Show("index of  is "+line+" vs "+mark);

                    bool blnResult =  line.Contains(mark);
                    if (blnResult){
                        return true;
                    }
                
                }
            
            
            }

            return false;


        
        
        }



        //追加写入文件，相当于把所有下载ts合并成为一个ts文件
        public void WriteToVideoFile(byte[] aryContent, string fileName)
        {

            FileStream fs = new FileStream(fileName, FileMode.Append);
            fs.Write(aryContent, 0, aryContent.Length);
            fs.Close();

        }


        public string erroInfo = "";

        //读取下载的分片ts文件解密后写入一个大的ts文件
        public void AppendContentToVideoFile(string fileName, String aesKey, string videoName)
        {

            this.erroInfo = "";

            if (File.Exists(fileName) == false) {
                return;
            }

            FileStream fs = new FileStream(fileName, FileMode.Open);
            byte[] aryContent = new byte[fs.Length];
            fs.Read(aryContent, 0, (int)fs.Length);
            fs.Close();
            //Console.WriteLine("ts file size is :" + aryContent.Length);
            //Console.WriteLine("aes key is :" + aesKey);
            if (aryContent.Length > 0)
            {

                if (String.IsNullOrEmpty(aesKey) == false)
                { //如果有aes key就解密写入
                    //string text = Convert.ToBase64String(aryContent);
                    byte[] aryDecodeContent = this.AESDecodeContent(aryContent, aesKey);

                    if (aryDecodeContent != null && aryDecodeContent.Length > 0)
                    {
                        //this.erroInfo = "文件：" + fileName + "解密";
                        this.WriteToVideoFile(aryDecodeContent, videoName);

                    }
                    else {
                        this.erroInfo = "文件：" + fileName + "解密失败";
                       // MessageBox.Show("文件："+ fileName+"解密失败");
                    }
                    
                }
                else
                { //没有则直接合并

                    this.erroInfo = "文件：" + fileName + "不需要解密";
                    //MessageBox.Show("文件：" + fileName + "不需要解密");
                    this.WriteToVideoFile(aryContent, videoName);
                }


            }

        }

        public byte[] getKeyOrIv(String keyOrIv) {

            if (String.IsNullOrEmpty(keyOrIv)) {

                return null;
            }

            if (File.Exists(keyOrIv))
            {

                return this.getFileContent(keyOrIv);
            }
            else {
                return null;
            }


     
        }
        public byte[] getFileContent(String fileName)
        {

            FileStream fs = new FileStream(fileName, FileMode.Open);
            byte[] aryContent = new byte[fs.Length];
            fs.Read(aryContent, 0, (int)fs.Length);
            fs.Close();

            return aryContent;

            //return Encoding.Default.GetString(aryContent);
        }

        public void StartDecode(String fileName, String key, String iV)
        {

            FileStream fs = new FileStream(fileName, FileMode.Open);
            byte[] aryContent = new byte[fs.Length];
            fs.Read(aryContent, 0, (int)fs.Length);
            fs.Close();
            //Console.WriteLine("ts file size is :" + aryContent.Length);
            //Console.WriteLine("aes key is :" + aesKey);
            if (aryContent.Length > 0)
            {
                byte[] aryDecodeContent = null;
   
                aryDecodeContent = this.AESDecodeContent(aryContent,key, iV);
  

                if (aryDecodeContent == null || aryDecodeContent.Length == 0) {

                    this.erroInfo = "解密错误";
                    return;

                }

                //写入文件
                String newFileName = fileName.Replace(".", "_decode.");
                FileStream fsDecode = new FileStream(newFileName, FileMode.Append);
                fsDecode.Write(aryDecodeContent, 0, aryDecodeContent.Length);
                fsDecode.Close();
                this.erroInfo = "解密成功";



            }
            else
            {
                this.erroInfo = "文件内容为空哦！";
            }
        }

        public byte[] AESDecodeContent(byte[] Data, string Key)
        {
            return this.AESDecodeContent(Data, Key, null);
        }

        private byte[] getAESKeyFromString(String key) {

            if (this.blnKeyTypeIsBase64)
            {
                return Convert.FromBase64String(key);
            }
            else {

              return  this.getKeyOrIv(key) == null ? Encoding.Default.GetBytes(key) : this.getKeyOrIv(key);

            }

        }

        public byte[] AESDecodeContent(byte[] Data, string Key,string iv)
        {
           //如果key是一个路径则直接读取
            byte[] bKey = this.getAESKeyFromString(Key);
            //Encoding.Default.GetBytes(Key);
            //Array.Copy(Encoding.UTF8.GetBytes(Key.PadRight(bKey.Length)), bKey, bKey.Length);
            byte[] bVector = new byte[16];
            // Array.Copy(Encoding.UTF8.GetBytes(Vector.PadRight(bVector.Length)), bVector, bVector.Length);
            byte[] original = null;//解密后的明文
            Rijndael Aes = Rijndael.Create();
            Aes.Key = bKey;
            if (String.IsNullOrEmpty(iv)== false)
            {
                Aes.IV = this.getKeyOrIv(iv) == null ? Encoding.Default.GetBytes(iv) : this.getKeyOrIv(iv); ;
            }
            //Aes.IV = Encoding.Default.GetBytes(iv);
            Aes.Mode = CipherMode.CBC;
            try
            {
                using (MemoryStream Memory = new MemoryStream(Data))
                {
                    //把内存流对象包装成加密对象
                    using (CryptoStream Decryptor = new CryptoStream(Memory, Aes.CreateDecryptor(bKey, bVector), CryptoStreamMode.Read))
                    {
                        //明文存储区
                        using (MemoryStream originalMemory = new MemoryStream())
                        {
                            byte[] Buffer = new byte[1024];
                            int readBytes = 0;
                            while ((readBytes = Decryptor.Read(Buffer, 0, Buffer.Length)) > 0)
                            {
                                originalMemory.Write(Buffer, 0, readBytes);
                            }
                            original = originalMemory.ToArray();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.erroInfo = ex.Message;
                //
                // MessageBox.Show(ex.Message);

                original = null;
            }
            return original;
        }
         
    }
}
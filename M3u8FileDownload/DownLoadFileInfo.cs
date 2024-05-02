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
    public class DownLoadFileInfo
    {
        public String Url { get; set; }
        public String Name { get; set; }

        public String AESKey { get; set; }

        public DownLoadFileInfo(String url, String name, string aseKey)
        {

            this.Url = url;
            this.Name = name;
            this.AESKey = aseKey;

        }

        public DownLoadFileInfo()
        {

  

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="allwaysDownLoadM3u8">是否总是重新下载m3u8文件</param>
        /// <returns></returns>
        public static string DownLoadM3u8(String url,bool allwaysDownLoadM3u8)
        {
            String filename =  GetFileName(url,"");
            string fileName =  Application.StartupPath + "\\m3u8\\" + filename + ".m3u8";
            WebClient wc = new System.Net.WebClient();
            if (File.Exists(fileName))
            {
                if (allwaysDownLoadM3u8)
                {
                    File.Delete(fileName);
                }
                else
                {
                    return fileName;
                }
                
            }
            try
            {
                wc.DownloadFile(url, fileName);
                return fileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("下载m3u8错误，信息："+ex.Message);
                return "";

            }



        }

        public static string GetFileName(string url,string filmName){

           String name = filmName!=""?filmName:System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(url,"MD5");
           return name ; 

        }


        public long getFileSize(String name) {

            string fileName = Application.StartupPath + "\\ts\\" + name;
            if (File.Exists(fileName)) {

                FileInfo fileInfo = new FileInfo(fileName);
                Console.WriteLine("check download file ,its length is:" + fileInfo.Length);
                return fileInfo.Length ;
            }

            return 0;

        }
        

        //判断文件是否下载成功
        public bool checkFile(String fileName)
        {

            Console.WriteLine("check download file:" + fileName);
            if (File.Exists(fileName))
            {
                FileInfo fileInfo = new FileInfo(fileName);
                Console.WriteLine("check download file ,its length is:"+fileInfo.Length);
              
                return fileInfo.Length > 0;
            }
            else
            {
                Console.WriteLine("check download file ,it downloaded fail");
                return false;
            }



        }

    }
}
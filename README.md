# M3u8FileDownload
## 简介 
   ### IDM是一个十分优秀的下载工具，几乎可以解决90%以上的视频下载需求。不过有些视频下载它会报告“由于法律原因，IDM无法下载此受保护的数据...”这个工具就是用来解决这个问题的。你可以使用IDM拿到视频地址后丢到这个小工具里完成最终的下载。
   ![](http://gfrjxz.com/images/m3u8/7.png "下载")
   ### M3u8FileDownload是一个通过解析m3u8文件来下载视频的工具，采用C#的Winform开发，最低要求是net framework 4.8，基本上可以运行在win7之后的电脑上。我自己用是在win10下。其实使用IDM（Internet Download Mananger）下载的时候，有些URL它会报告“由于法律原因，IDM无法下载此受保护的数据...”，是因为里面的视频片段使用了AES加密。这个小工具会先下载m3u8文件接着解析内容获得视频分片文件的URL和AES密钥，按照URL下载文件后解密最终合并为一个视频文件。   
***
## 安装和设置 
+ ### 没有依赖项目直接下载源码编译即可，我是用visual studio 2022 社区版编译的
+ ### 运行的话直接点exe文件   
***


## 使用说明 
### 1. 双击运行 
### 2. 输入电影名称和m3u8的地址
![](http://gfrjxz.com/images/m3u8/1.png "下载")
### 3. 点运行
### 4. 如果同时下载多个视频直接再双击exe文件
### 5. 点【下载设置】可以设置一些参数，不建议修改
![](http://gfrjxz.com/images/m3u8/6.png "下载")
### 6. 点【系统设置】可以打开已下载完成视频文件夹，点清除可以删除视频下载过程产生的缓存文件（确保所有下载完成）
![](http://gfrjxz.com/images/m3u8/8.png "下载")
### 7. 点击右上叫的X关闭程序
***
## 其他说明
+ ### IDM的视频嗅探功能十分优秀，所以这个小工具不提供视频地址嗅探的功能。
+ ### IDM功能还提供了其他格式文件的下载，这个小工具只能下载m3u8类的文件。
+ ### 理论上多时开多线程下载下载m3u8，速度应该差不多 
+ ### 界面上的下载速度可能不太准确
  ![](http://gfrjxz.com/images/m3u8/3.png "下载")
+ ### 通常的AES加解密还有一个IV，有些m3u8文件也有这个值，不过似乎他们加密的时候没用所以解密的时候也忽略了

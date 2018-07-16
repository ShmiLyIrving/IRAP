using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

//----------------------------------------------------------------*/
// 版权所有：
// 文 件 名：DownFile.cs
// 功能描述：
// 修改描述：
//----------------------------------------------------------------*/
namespace PlanMGMT.Utility
{
    /// <summary>
    /// 下载文件类
    /// </summary>
    public class DownFile
    {
        #region 远程服务器下载文件
        /// <summary>
        /// 远程提取文件保存至服务器上(使用WebRequest)
        /// </summary>
        /// <param name="url">一个URI上的文件</param>
        /// <param name="savePath">文件保存在服务器上的全路径</param>
        public void DownloadFileByWebRequest(string url, string savePath)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream stream = webResponse.GetResponseStream();

            int fileSize = (int)webResponse.ContentLength;
            int bufferSize = 102400;
            byte[] buffer = new byte[bufferSize];
            string dirPath = savePath.Substring(0, savePath.LastIndexOf(@"\") + 1);
            MSL.Tool.IOHelper.Instance.CreateFolder(dirPath);

            FileStream fileStream = File.Create(savePath, bufferSize);
            int bytesRead;

            do
            {
                bytesRead = stream.Read(buffer, 0, buffer.Length);
                fileStream.Write(buffer, 0, bytesRead);
            } while (bytesRead > 0);

            fileStream.Flush();
            fileStream.Close();
            stream.Flush();
            stream.Close();
        }

        /// <summary>
        /// 远程提取一个文件保存至服务器上(使用WebClient)
        /// </summary>
        /// <param name="url">一个URI上的文件</param>
        /// <param name="savePath">保存文件</param>
        public bool DownloadFileByWebClient(string url, string savePath)
        {
            if (String.IsNullOrEmpty(url) || String.IsNullOrEmpty(savePath))
            {
                return false;
            }
            System.Net.WebClient wc = new System.Net.WebClient();
            try
            {
                string dirPath = savePath.Substring(0, savePath.LastIndexOf(@"\") + 1);
                MSL.Tool.IOHelper.Instance.CreateFolder(dirPath);

                //避免出现 远程服务器返回错误:(403)已禁止 错误
                wc.Credentials = CredentialCache.DefaultCredentials;//获取或这设置发送到主机并用于请求进行身份验证的网络凭据
                wc.Headers.Set("User-Agent", "Microsoft Internet Explorer");//设置标头
                wc.DownloadFile(url, savePath);
            }
            catch
            {
                return false;
            }

            wc.Dispose();
            return true;
        }
        #endregion
    }
}

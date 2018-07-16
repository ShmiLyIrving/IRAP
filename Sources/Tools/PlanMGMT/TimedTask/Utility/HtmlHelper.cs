using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

//----------------------------------------------------------------*/
// 版权所有：
// 文 件 名：HtmlHelper.cs
// 功能描述：
// 创建标识：m.sh.lin0328@163.com 2014/8/28 20:52:06
// 修改描述：
//----------------------------------------------------------------*/
namespace PlanMGMT.Utility
{
    /// <summary>
    /// HTML相关类<br/>
    /// add by mashanlin 2013-6-25 <br/>
    /// 修改记录：<br/>
    /// 1.2013-06-27 mashanlin 增加获取网页源码<br/>
    /// 2.2013-07-02 mashanlin 增加html清除样式<br/>
    /// 3.2014-03-12 mashanlin 增加POST方式获取源码<br/>
    /// 4.2014-05-01 mashanlin 静态方法修改成为单例<br/>
    /// </summary>
    public class HtmlHelper
    {
        #region 变量

        //图片正则
        private const string REG_IMG = "<img[^>]+src=\\s*(?:'(?<src>[^']+)'|\"(?<src>[^\"]+)\"|(?<src>[^>\\s]+))\\s*[^>]*>";
        //链接
        private const string REG_LINK = @"<a(.*?)href=\s*(?:'(?<href>[^']+)'|""(?<href>[^""]+)""|(?<href>[^>\s]+))\s*[^>]*>";
        private const string REG_LINK1 = "<a(.*?)href=\\s*['\"](?<href>[^\"']+)['\"][^>]*>(?<title>(?:[\\s\\S]*?))</a>";
        //HTML标题
        private const string REG_TITLE = "<Title[^>]*>(?<Title>[\\s\\S]{5,})</Title>";
        private static HtmlHelper _instance;
        private static readonly object _lock = new Object();

        #endregion

        #region 单一实例
        /// <summary>
        /// 
        /// </summary>
        private HtmlHelper()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        ~HtmlHelper()
        {
            Dispose();
        }
        /// <summary>
        /// 返回唯一实例
        /// </summary>
        public static HtmlHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new HtmlHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region 获得链接

        /// <summary>
        /// 多个链接
        /// </summary>
        /// <param name="input">输入内容</param>
        public ArrayList GetLinks(string input)
        {
            ArrayList al = new ArrayList();

            Regex re = new Regex(REG_LINK1, RegexOptions.IgnoreCase | RegexOptions.Multiline);//| RegexOptions.IgnorePatternWhitespace
            MatchCollection mcs = re.Matches(input);

            foreach (Match mc in mcs)
            {
                string[] link = new String[3];
                link[0] = mc.Groups["title"].Value;
                link[1] = mc.Groups["href"].Value;
                al.Add(link);
            }
            return al;
        }
        #endregion

        #region 获取页面内容
        /// <summary>
        /// 获取网页源码
        /// </summary>
        /// <param name="url">链接</param>
        /// <returns></returns>
        public string GetHtml(string url)
        {
            return GetHtml(ref url, "");
        }
        /// <summary>
        /// 获取网页源码
        /// </summary>
        /// <param name="url">链接</param>
        /// <param name="pageEncode">文本编码:utf-8 gb2312</param>
        /// <returns></returns>
        public string GetHtml(ref string url, string pageEncode)
        {
            string content = "";
            try
            {
                HttpWebResponse response = GetResponse(url);
                if (response == null)
                {
                    return content;
                }
                url = response.ResponseUri.AbsoluteUri;
                Stream stream = response.GetResponseStream();
                byte[] buffer = GetContent(stream);
                stream.Close();
                stream.Dispose();
                string charset = "";
                if (pageEncode == null || pageEncode == "")
                {
                    //首先，从返回头信息中寻找
                    string ht = response.GetResponseHeader("Content-Type");
                    response.Close();
                    string regCharSet = "[\\s\\S]*charset=(?<charset>[\\S]*)";
                    Regex r = new Regex(regCharSet, RegexOptions.IgnoreCase);
                    Match m = r.Match(ht);
                    charset = (m.Captures.Count != 0) ? m.Result("${charset}") : "";
                    if (charset == "-8") charset = "utf-8";

                    if (charset == "")//找不到，则在文件信息本身中查找
                    {
                        //先按gb2312来获取文件信息
                        content = System.Text.Encoding.GetEncoding("gb2312").GetString(buffer);
                        regCharSet = "(<meta[^>]*charset=(?<charset>[^>'\"]*)[\\s\\S]*?>)|(xml[^>]+encoding=(\"|')*(?<charset>[^>'\"]*)[\\s\\S]*?>)";
                        r = new Regex(regCharSet, RegexOptions.IgnoreCase);
                        m = r.Match(content);
                        if (m.Captures.Count == 0)//没办法，都找不到编码，只能返回按"gb2312"获取的信息
                        {
                            return content;
                        }
                        charset = m.Result("${charset}");
                    }
                }
                else
                {
                    response.Close();
                    charset = pageEncode.ToLower();
                }
                try
                {
                    content = System.Text.Encoding.GetEncoding(charset).GetString(buffer);
                }
                catch (ArgumentException)
                {//指定的编码不可识别
                    content = System.Text.Encoding.GetEncoding("gb2312").GetString(buffer);
                }
            }
            catch
            {
                content = "";
            }
            return content;
        }

        #endregion

        #region 补全链接
        /// <summary>
        /// 基于baseUrl，补全html代码中的链接 马山林 2014-3-13 添加
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="html"></param>
        public string FixUrl(string baseUrl, string html)
        {
            html = Regex.Replace(html, "(?is)(href|src)=(\"|\')([^(\"|\')]+)(\"|\')", (match) =>
            {
                string org = match.Value;
                string link = match.Groups[3].Value;
                if (link.StartsWith("http"))
                {
                    return org;
                }
                try
                {
                    Uri uri = new Uri(baseUrl);
                    Uri thisUri = new Uri(uri, link);
                    string fullUrl = String.Format("{0}=\"{1}\"", match.Groups[1].Value, thisUri.AbsoluteUri);
                    return fullUrl;
                }
                catch (Exception)
                {
                    return org;
                }
            });
            return html;
        }
        #endregion

        #region 获得特定内容

        /// <summary>
        /// 图片地址
        /// </summary>
        /// <param name="input">输入内容</param>
        public List<String> GetImgLinks(string input)
        {
            return Helper.Instance.GetList(input, REG_IMG, "src");
        }

        #endregion 获得特定内容

        #region 私有方法

        private HttpWebResponse GetResponse(string url)
        {
            int timeOut = 10000;
            bool isCookie = false;
            bool isRepeat = false;
            Uri target = new Uri(url);
        ReCatch:
            try
            {
                HttpWebRequest resquest = (HttpWebRequest)WebRequest.Create(target);
                resquest.MaximumResponseHeadersLength = -1;
                resquest.ReadWriteTimeout = 120000;//120秒就超时
                resquest.Timeout = timeOut;
                resquest.MaximumAutomaticRedirections = 50;
                resquest.MaximumResponseHeadersLength = 5;
                resquest.AllowAutoRedirect = true;
                if (isCookie)
                {
                    resquest.CookieContainer = new CookieContainer();
                }
                resquest.UserAgent = "Mozilla/6.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                return (HttpWebResponse)resquest.GetResponse();
            }
            catch (WebException)
            {
                if (!isRepeat)
                {
                    isRepeat = true;
                    isCookie = true;
                    goto ReCatch;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        private byte[] GetContent(Stream stream)
        {
            ArrayList al = new ArrayList();
            try
            {
                byte[] buffer = new byte[4096];
                int count = stream.Read(buffer, 0, 4096);
                while (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        al.Add(buffer[i]);
                    }
                    count = stream.Read(buffer, 0, 4096);
                }
            }
            catch { }

            return (byte[])al.ToArray(System.Type.GetType("System.Byte"));
        }

        #endregion

        /// <summary>
        /// 获取网页body
        /// </summary>
        /// <param name="htmlCode">源码</param>
        /// <returns></returns>
        public string GetBody(string htmlCode)
        {
            if (htmlCode.Contains("<body"))
            {
                htmlCode = htmlCode.Substring(htmlCode.IndexOf("<body"));
            }
            else if (htmlCode.Contains("<BODY"))
            {
                htmlCode = htmlCode.Substring(htmlCode.IndexOf("<BODY"));
            }
            htmlCode = Regex.Replace(htmlCode, @"</\bbody\b[^>]*>\s*</html>", "", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
            return htmlCode;
        }
    }
}

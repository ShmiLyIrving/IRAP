using System;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

using Newtonsoft.Json;

using IRAP.WebAPI.Enums;

namespace IRAP.WebAPI
{
    public abstract class TCustomWebAPICall
    {
        /// <summary>
        /// WebAPI 服务地址，由于是在配置文件中定义，因此无需向派生类开放
        /// </summary>
        private string webAPIUrl = "";
        /// <summary>
        /// 模块类别，需要在派生类中显式指定，因此需要向派生类开放。
        /// 默认值：Exchange
        /// </summary>
        protected TModuleType moduleType = TModuleType.Exchange;
        /// <summary>
        /// 报文格式，由于是在配置文件中定义，因此无需向派生类开放。
        /// 默认值：JSON
        /// </summary>
        private TContentType contentType = TContentType.JSON;
        /// <summary>
        /// 客户端标识，由于是在配置文件中定义，因此无需向派生类开放
        /// </summary>
        private string clientID = "Demo";
        /// <summary>
        /// 交易代码，需要在派生类中显示指定，因此需要向派生类开放
        /// </summary>
        protected string exCode = "";
        /// <summary>
        /// 交易执行后的结果消息对象（属性：ErrCode==0时，交易成功）
        /// </summary>
        private TErrorMessage errorMessage = new TErrorMessage();

        public TCustomWebAPICall()
        {
            webAPIUrl = GetValueFromAppSettings("WebAPI Broker", "http://127.0.0.1:55552/");

            string temp = GetValueFromAppSettings("Content Type", "JSON");
            try { contentType = (TContentType)Enum.Parse(typeof(TContentType), temp); }
            catch { contentType = TContentType.JSON; }

            clientID = GetValueFromAppSettings("ClientID", "MESDeveloper");
        }

        /// <summary>
        /// 交易执行后的结果消息对象（属性：ErrCode==0时，交易成功）
        /// </summary>
        public TErrorMessage Error
        {
            get { return errorMessage; }
        }

        /// <summary>
        /// 根据指定的关键字，从应用程序配置文件中读取配置的值，如果没有则返回 defaultValue 中指定的值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="defaultValue">指定的缺省值</param>
        /// <returns>配置文件中配置的</returns>
        private string GetValueFromAppSettings(string key, string defaultValue = "")
        {
            if (ConfigurationManager.AppSettings[key] != null)
                return ConfigurationManager.AppSettings["key"];
            else
                return defaultValue;
        }

        /// <summary>
        /// 调用 WebAPI 服务，发送请求报文，接收响应报文后，转换成指定类型的对象
        /// </summary>
        /// <typeparam name="T">返回的对象类型</typeparam>
        /// <param name="requestObject">请求报文对象</param>
        /// <param name="result">交易结果对象</param>
        /// <returns>返回的对象</returns>
        protected T Call<T>(
            object requestObject,
            out TErrorMessage result)
        {
            string url = "";
            result = new TErrorMessage();

            switch (moduleType)
            {
                case TModuleType.Exchange:
                    url = 
                        string.Format(
                            "{0}{1}/{2}/{3}/{4}",
                            webAPIUrl,
                            moduleType.ToString(),
                            clientID,
                            contentType.ToString(),
                            exCode);
                    break;
                default:
                    string errText = string.Format("目前不支持模块 [{0}]", moduleType.ToString());
                    Exception error = new Exception(errText);
                    error.Data["ErrCode"] = 999999;
                    error.Data["ErrText"] = errText;
                    throw error;
            }

            switch (contentType)
            {
                case TContentType.JSON:
                    break;
                default:
                    string errText = string.Format("目前不支持 [{0}] 报文格式", contentType.ToString());
                    Exception error = new Exception(errText);
                    error.Data["ErrCode"] = 999999;
                    error.Data["ErrText"] = errText;
                    throw error;
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/stream;";
            request.KeepAlive = false;
            request.AllowAutoRedirect = true;
            request.CookieContainer = new CookieContainer();
            request.Timeout = 30000;        // 单位：毫秒

            try
            {
                Stream stream = request.GetRequestStream();

                #region 根据传入的指定报文格式，生成交易请求对象的相应格式的报文文本
                string content = "";
                switch (contentType)
                {
                    case TContentType.JSON:
                        content = requestObject.ToJSON();
                        break;
                    case TContentType.XML:
                        content = requestObject.ToXML();
                        break;
                }
                #endregion

                byte[] requestContext = Encoding.UTF8.GetBytes(content);
                stream.Write(requestContext, 0, requestContext.Length);
                stream.Flush();
                stream.Close();
                Application.DoEvents();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string resJson = "";
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    resJson = sr.ReadToEnd();
                }

                T rtnObject = default(T);
                switch (contentType)
                {
                    case TContentType.JSON:
                        result = JsonConvert.DeserializeObject<TErrorMessage>(resJson);
                        rtnObject = JsonConvert.DeserializeObject<T>(resJson);
                        break;
                }

                result.SourceREQContent = content;
                result.SourceRESPContent = resJson;

                return rtnObject;
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"] = error.Message;
                throw error;
            }
        }

        /// <summary>
        /// 执行具体的报文发送和接收交易
        /// </summary>
        protected abstract void Communicate(out TErrorMessage errorMsg);

        /// <summary>
        /// 执行交易
        /// </summary>
        /// <returns>交易是否成功</returns>
        public virtual bool Do()
        {
            try
            {
                Communicate(out errorMessage);
                return errorMessage.ErrCode == 0;
            }
            catch (Exception error)
            {
                errorMessage.ErrCode = 999999;
                errorMessage.ErrText = error.Message;

                if (error.Data["ErrCode"] != null)
                    errorMessage.ErrCode = (int)error.Data["ErrCode"];
                if (error.Data["ErrText"] != null)
                    errorMessage.ErrText = error.Data["ErrText"].ToString();

                return false;
            }
        }
    }
}

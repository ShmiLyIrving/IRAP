using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

using IRAPShared;

namespace IRAP.WCF.Client
{
    public class HttpClientUtil
    {
        private static string restFulServer_URL =
            ConfigurationManager.AppSettings["RESTFulAddress"].ToString();

        /// <summary>
        /// REST @GET 方法，根据泛型自动转换成实体，支持 List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methodURL"></param>
        /// <returns></returns>
        public static T doGetMethodToObj<T>(string methodURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                string.Format(
                    "{0}{1}",
                    restFulServer_URL,
                    methodURL));
            request.Method = "GET";
            request.ContentType = "application/json;charset=UTF-8";

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException error)
            {
                response = (HttpWebResponse)error.Response;
                throw;
            }

            string json = getResponseString(response);
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 讲 HttpWebResponse 返回结果转换成 string
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static string getResponseString(HttpWebResponse response)
        {
            string json = null;
            using (StreamReader reader = new StreamReader(response.GetResponseStream(),
                Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }
            return json;
        }

        /// <summary>
        /// 获取异常信息
        /// </summary>
        /// <param name="errorResponse"></param>
        /// <returns></returns>
        private static string getRestErrorMessage(HttpWebResponse errorResponse)
        {
            string errorHtml = getResponseString(errorResponse);
            string errorKey = "spi.UnhandleException:";

            errorHtml = errorHtml.Substring(errorHtml.IndexOf(errorKey) + errorKey.Length);
            errorHtml = errorHtml.Substring(0, errorHtml.IndexOf("\n"));

            return errorHtml;
        }

        /// <summary>
        /// REST @POST 方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methodURL"></param>
        /// <param name="jsonBody"></param>
        /// <returns></returns>
        public static T doPostWidthDict<T>(string methodURL, Dictionary<string, object> jsonBody)
        {
            List<KeyValueEntity> keyValueList = new List<KeyValueEntity>();
            foreach (KeyValuePair<string, object> item in jsonBody)
            {
                KeyValueEntity e1 = new KeyValueEntity()
                {
                    Key = item.Key.ToString(),
                    Value = item.Value,
                };
                keyValueList.Add(e1);
            }
            string json = JsonConvert.SerializeObject(keyValueList);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                string.Format(
                    "{0}{1}",
                    restFulServer_URL,
                    methodURL));
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";

            var stream = request.GetRequestStream();
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(json);
                writer.Flush();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string resJson = getResponseString(response);

            return JsonConvert.DeserializeObject<T>(resJson);
        }

        public static T doPostWidthClass<T>(string methodURL, object jsonBody)
        {
            List<KeyValueEntity> keyValueList = new List<KeyValueEntity>();
            foreach (PropertyInfo pi in jsonBody.GetType().GetProperties())
            {
                KeyValueEntity e1 = new KeyValueEntity()
                {
                    Key = pi.Name,
                    Value = pi.GetValue(jsonBody, null).ToString(),
                };
                keyValueList.Add(e1);
            }

            string json = JsonConvert.SerializeObject(keyValueList);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                string.Format(
                    "{0}{1}",
                    restFulServer_URL,
                    methodURL));
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";

            var stream = request.GetRequestStream();
            using (var writer=new StreamWriter(stream))
            {
                writer.Write(json);
                writer.Flush();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string resJson = getResponseString(response);

            return JsonConvert.DeserializeObject<T>(resJson);
        }

        /// <summary>
        /// REST @PUT 方法
        /// </summary>
        /// <param name="methodURL"></param>
        /// <returns></returns>
        public static string doPutMethod(string methodURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                string.Format(
                    "{0}{1}",
                    restFulServer_URL,
                    methodURL));
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(
                response.GetResponseStream(),
                Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// REST @PUT 方法，带发送内容主体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methodURL"></param>
        /// <param name="jsonBody"></param>
        /// <returns></returns>
        public static T doPutMethodToObj<T>(string methodURL, string jsonBody)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                string.Format("{0}{1}",
                    restFulServer_URL,
                    methodURL));
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";

            var stream = request.GetRequestStream();
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(jsonBody);
                writer.Flush();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string json = getResponseString(response);

            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// REST @DELETE 方法
        /// </summary>
        /// <param name="methodURL"></param>
        /// <returns></returns>
        public static bool doDeleteMethod(string methodURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                string.Format("{0}{1}",
                    restFulServer_URL,
                    methodURL));
            request.Method = "DELETE";
            request.ContentType = "application/json;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                string responseString = reader.ReadToEnd();
                if (responseString.Equals("1"))
                    return true;
                else
                    return false;
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace OPCClient.Classes
{
    public class OPCWSClient
    {
        private static OPCWSClient _instance = null;

        public static OPCWSClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new OPCWSClient();
                return _instance;
            }
        }

        private string uri = "http://127.0.0.1:16912/OPCGateway/Method";

        private OPCWSClient() { }

        public string WSCall(string reqContent)
        {
            string rlt = "";
            Guid id = Guid.NewGuid();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/xmlstream";
            request.Timeout = 300000;

            try
            {
                var stream = request.GetRequestStream();
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(reqContent);
                    writer.Flush();
                }
                Application.DoEvents();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string resJson = string.Empty;
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8")))
                {
                    resJson = reader.ReadToEnd();
                }
                rlt = resJson;

                byte[] strBytes = Encoding.UTF8.GetBytes(resJson);
                if (!Directory.Exists(@"C:\Temp\"))
                {
                    Directory.CreateDirectory(@"C:\Temp\");
                }
                FileStream fw = new FileStream(@"C:\Temp\Temp.xml", FileMode.Create);
                fw.Write(strBytes, 0, strBytes.Length);
                fw.Flush();
                fw.Close();

                WriteLog.Instance.Write(id, "收到的返回报文：");
                WriteLog.Instance.Write(id, rlt);
                return rlt;
            }
            catch (Exception error)
            {
                throw new Exception(
                    string.Format(
                        "调用 WebService:[{0}]，调用参数[{1}]时出错：[{2}]",
                        uri,
                        reqContent,
                        error.Message));
            }
        }
    }
}

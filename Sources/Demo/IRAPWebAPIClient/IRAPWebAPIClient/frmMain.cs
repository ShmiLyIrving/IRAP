﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Configuration;

using IRAP.WebAPI.Exchange.MES;
using IRAP.WebAPI.Entities.MES;

namespace IRAPWebAPIClient
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void WriteParam(string paramKey, string paramValue)
        {
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[paramKey] == null)
            {
                config.AppSettings.Settings.Add(paramKey, paramValue);
            }
            else
            {
                config.AppSettings.Settings[paramKey].Value = paramValue;
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private string ReadParam(string paramKey, string defaultValue)
        {
            if (ConfigurationManager.AppSettings[paramKey] != null)
            {
                return ConfigurationManager.AppSettings[paramKey];
            }
            else
            {
                return defaultValue;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string url = "";

            switch (cboModuleName.Text)
            {
                case "Exchange":
                    url = string.Format(
                        "{0}{1}/{2}/{3}/{4}",
                        edtAddress.Text,
                        cboModuleName.Text,
                        edtClientID.Text,
                        cboContextType.Text,
                        edtExCode.Text);
                    break;
                default:
                    MessageBox.Show(
                        string.Format("目前不支持模块 [{0}]", cboModuleName.Text),
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
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

                byte[] requestContext = Encoding.UTF8.GetBytes(edtRequest.Text);
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

                edtResponse.Text = resJson;
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    error.Message,
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            edtAddress.Text = ReadParam("URI", "http://127.0.0.1:55552/");

            cboModuleName.SelectedIndex = 0;
            cboContextType.SelectedIndex = 0;

            edtClientID.Text = ReadParam("ClientID", "MESDeveloper");
            edtExCode.Text = ReadParam("ExCode", "IRAP_MES_GetOPCServerTagList");

            edtRequest.Text = ReadParam("Request", "{\"CommunityID\":\"60002\",\"SysLogID\":\"1\"}");
        }

        private void btnExTest_Click(object sender, EventArgs e)
        {
            //TGetOPCServerTagList exchange = 
            //    new TGetOPCServerTagList();

            //exchange.Request =
            //    new TREQOPCServerTagList()
            //    {
            //        CommunityID = 60002,
            //        SysLogID = 1,
            //    };

            //if (exchange.Do())
            //    MessageBox.Show(string.Format("({0}){1}", exchange.Error.ErrCode, exchange.Error.ErrText));
            //else
            //    MessageBox.Show(string.Format("({0}){1}", exchange.Error.ErrCode, exchange.Error.ErrText));

            //edtRequest.Text = exchange.Error.SourceREQContent;
            //edtResponse.Text = exchange.Error.SourceRESPContent;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteParam("URI", edtAddress.Text);
            WriteParam("ClientID", edtClientID.Text);
            WriteParam("ExCode", edtExCode.Text);
            WriteParam("Request", edtRequest.Text);
        }
    }
}

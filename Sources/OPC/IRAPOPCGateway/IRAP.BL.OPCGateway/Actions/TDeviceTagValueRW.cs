using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Threading;

using IRAP.BL.OPCGateway.Interfaces;
using IRAP.Interface.OPC;
using IRAP.OPC.Entity.IRAPServer;

namespace IRAP.BL.OPCGateway.Actions
{
    internal class TDeviceTagValueRW : IWebAPIAction
    {
        private TDeviceTagValueRWContent content = new TDeviceTagValueRWContent();

        public TDeviceTagValueRW(string xmlContent)
        {
            try
            {
                content.ResolveRequest(xmlContent);
            }
            catch (Exception error)
            {
                foreach (DictionaryEntry de in error.Data)
                {
                    if (de.Key.ToString().ToUpper() == "ERRCODE")
                        content.Response.ErrCode = de.Value.ToString();
                    if (de.Key.ToString().ToUpper() == "ERRTEXT")
                        content.Response.ErrText = de.Value.ToString();
                }
            }
        }

        private void WriteTagValueToKepServer(
            string kepServerName, 
            TDeviceTagValueRWReqBodyTags write,
            out int errCode,
            out string errText)
        {
            errCode = 0;
            errText = "";

            for (int i = 0; i < write.Tags.Count; i++)
            {
                TIRAPOPCTag opcTag =
                    TIRAPOPCDevices.Instance.FindOPCTagItem(
                        string.Format(
                            "{0}.{1}",
                            kepServerName,
                            write.Tags[i].TagName));
                if (opcTag == null)
                {
                    errCode = 903341;
                    errText = string.Format("回写失败：标签[{0}]在 KepServer 中未定义", write.Tags[i].TagName);
                    return;
                }
                else
                {
                    try
                    {
                        opcTag.WriteTagValueBack(write.Tags[i].TagValue, out errCode, out errText);
                        if (errCode != 0)
                        {
                            errCode = 903341;
                            errText =
                                string.Format(
                                    "标签[{0}]回写失败：[{1}]",
                                    write.Tags[i].TagName,
                                    errText);
                            return;
                        }
                    }
                    catch (Exception error)
                    {
                        errCode = 903341;
                        errText = 
                            string.Format(
                                "标签[{0}]回写失败：[{1}]", 
                                write.Tags[i].TagName, 
                                error.Message);
                        return;
                    }
                }
            }
        }

        private void ReadTagValueFromKepServer(
            string kepServerName,
            TDeviceTagValueRWReqBodyTags read,
            out int errCode,
            out string errText)
        {
            errCode = 0;
            errText = "";

            for (int i = 0; i < read.Tags.Count; i++)
            {
                TIRAPOPCTag opcTag =
                    TIRAPOPCDevices.Instance.FindOPCTagItem(
                        string.Format(
                            "{0}.{1}",
                            kepServerName,
                            read.Tags[i].TagName));
                if (opcTag == null)
                {
                    errCode = 903341;
                    errText = string.Format("读取失败：标签[{0}]在 KepServer 中未定义", read.Tags[i].TagName);
                    return;
                }
                else
                {
                    content.Response.ReadTags.Add(
                        new TDeviceTagValueRWRspBodyTag()
                        {
                            TagName = read.Tags[i].TagName,
                            TagValue = opcTag.TagValue,
                        });
                }
            }
        }

        private void WaittingFor(
            string kepServerName,
            TDeviceTagValueRWReqBodyFlagTags flags,
            out int errCode,
            out string errText)
        {
            errCode = 0;
            errText = "";

            List<TIRAPOPCTag> opcTags = new List<TIRAPOPCTag>();
            for (int i = 0; i < flags.Tags.Count; i++)
            {
                TIRAPOPCTag opcTag =
                    TIRAPOPCDevices.Instance.FindOPCTagItem(
                        string.Format(
                            "{0}.{1}",
                            kepServerName,
                            flags.Tags[i].TagName));
                if (opcTag == null)
                {
                    errCode = 903341;
                    errText =
                        string.Format(
                            "标识标签错误：标签[{0}]在 KepServer 中未定义",
                            flags.Tags[i].TagName);
                    return;
                }
                else
                    opcTags.Add(opcTag);
            }

            DateTime start = DateTime.Now;
            TimeSpan span = DateTime.Now - start;
            bool allAbove = true;
            while (span.TotalSeconds <= flags.TimeOut)
            {
                allAbove = true;
                for (int i = 0; i < opcTags.Count; i++)
                {
                    if (opcTags[i].TagValue != flags.Tags[i].TagValue)
                    {
                        allAbove = false;
                        break;
                    }
                }

                if (allAbove)
                    break;

                Thread.Sleep(300);
                span = DateTime.Now - start;
            }

            if (!allAbove)
            {
                errCode = 903342;
                errText =
                    string.Format(
                        "在[{0}]秒内，未满足规定的读取条件。",
                        flags.TimeOut);
            }
        }

        public string DoAction()
        {
            if (content.Request != null)
            {
                content.Response.ErrCode = "999999";
                content.Response.ErrText = "功能正在开发中......";

                try
                {
                    if (content.Request.ExCode == "DeviceTagValueRW")
                    {
                        int errCode = 0;
                        string errText = "";

                        if (content.Request.WriteTags.Tags.Count > 0)
                            WriteTagValueToKepServer(
                                content.Request.KepServName,
                                content.Request.WriteTags,
                                out errCode,
                                out errText);
                        if (errCode != 0)
                        {
                            content.Response.ErrCode = errCode.ToString();
                            content.Response.ErrText = errText;
                        }
                        else
                        {
                            WaittingFor(
                                content.Request.KepServName,
                                content.Request.FlagTags,
                                out errCode,
                                out errText);
                            if (errCode != 0)
                            {
                                content.Response.ErrCode = errCode.ToString();
                                content.Response.ErrText = errText;
                            }
                            else
                            {
                                ReadTagValueFromKepServer(
                                    content.Request.KepServName,
                                    content.Request.ReadTags,
                                    out errCode,
                                    out errText);
                                if (errCode != 0)
                                {
                                    content.Response.ErrCode = errCode.ToString();
                                    content.Response.ErrText = errText;
                                }
                                else
                                {
                                    content.Response.ErrCode = "0";
                                    content.Response.ErrText = "设备标签值回写并读取成功";
                                }
                            }
                        }
                    }
                    else
                    {
                        content.Response.ErrCode = "900000";
                        content.Response.ErrText = "报文体中的交易代码和报文头中的交易代码不一致";
                    }
                }
                catch (Exception error)
                {
                    content.Response.ErrText = string.Format("系统抛出的错误：[{0}]", error.Message);
                    foreach (DictionaryEntry de in error.Data)
                    {
                        if (de.Key.ToString().ToUpper() == "ERRCODE")
                            content.Response.ErrCode = de.Value.ToString();
                        if (de.Key.ToString().ToUpper() == "ERRTEXT")
                            content.Response.ErrText = de.Value.ToString();
                    }
                }
            }

            return content.GenerateResponseContent();
        }
    }
}

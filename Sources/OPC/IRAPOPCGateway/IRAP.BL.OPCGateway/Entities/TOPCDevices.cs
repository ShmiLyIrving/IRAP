using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using IRAP.WebAPI.Enums;
using IRAP.WebAPI.Entities.MES;
using IRAP.WebAPI.Exchange.MES;

namespace IRAP.BL.OPCGateway.Entities
{
    public class TOPCDevices
    {
        private static TOPCDevices _instance = null;
        private object lockObject = new object();
        private string webAPIUrl = "http://127.0.0.1:55552/";
        private TContentType contentType = TContentType.JSON;
        private string clientID = "MESDeveloper";
        private TOPCDeviceCollection devices = new TOPCDeviceCollection();

        private TOPCDevices()
        {
            
        }

        public static TOPCDevices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TOPCDevices();
                return _instance;
            }
        }

        /// <summary>
        /// OPC 设备集合
        /// </summary>
        public TOPCDeviceCollection Devices
        {
            get
            {
                return devices;
            }
        }

        /// <summary>
        /// 设置 WebAPI 调用参数
        /// </summary>
        /// <param name="url">WebAPI 地址</param>
        /// <param name="contentType">报文类型：JSON, XML</param>
        /// <param name="clientID">客户端标识</param>
        public void SetWebAPIParams(string url, string contentType, string clientID)
        {
            webAPIUrl = url;
            try
            {
                this.contentType =
                    (TContentType)Enum.Parse(typeof(TContentType), contentType);
            }
            catch { this.contentType = TContentType.JSON; }
            this.clientID = clientID;
        }

        /// <summary>
        /// 获取数据库中注册的 OPC 设备及标签
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void GetDevices(int communityID, long sysLogID)
        {
            TGetOPCServerTagList exchange = new TGetOPCServerTagList(webAPIUrl, contentType, clientID);
            exchange.Request =
                new TREQOPCServerTagList()
                {
                    CommunityID = communityID,
                    SysLogID = sysLogID,
                };

            if (!exchange.Do())
            {
                Debug.WriteLine(
                    string.Format(
                        "({0}){1}",
                        exchange.Error.ErrCode,
                        exchange.Error.ErrText),
                    "");
            }
            else
            {
                devices.Clear();
                foreach (TRESPOPCServerTagList item in exchange.Response.Rows)
                {
                    TOPCDevice device =
                        TOPCDevice.CreateInstance(item);
                    if (device != null)
                        devices.Add(device);
                }
                devices.IndexDevices =
                    devices.IndexDevices.OrderBy(
                        p => p.Key).ToDictionary(
                            p => p.Key, o => o.Value);
            }
        }

        /// <summary>
        /// 根据传入的 deviceName 查找系统中已注册的 TOPCDevice 对象。
        /// 如果找到，则返回 TOPCDevice 对象；如果未找到，则返回 null
        /// </summary>
        /// <param name="deviceName">设备代码，必须和 IRAP 中定义的 T133Code 一致</param>
        /// <returns></returns>
        public TOPCDevice FindOPCDevice(string deviceName)
        {
            TOPCDevice rlt = null;
            if (devices.IndexDevices.TryGetValue(deviceName, out rlt))
                return rlt;
            else
                return null;
        }

        /// <summary>
        /// 根据传入的 TagName 查找系统中已注册的 TOPCTag 对象。
        /// 如果找到，则返回 TOPCTag 对象；如果未找到，则返回 null
        /// </summary>
        public TOPCTag FindOPCDeviceTag(string tagName)
        {
            string[] tempStrings = tagName.Split('.');
            if (tempStrings.Length > 1)
                return null;

            TOPCDevice device = null;
            if (devices.IndexDevices.TryGetValue(tempStrings[0], out device))
            {
                TOPCTag tag = null;
                if (device.IndexTags.TryGetValue(tagName, out tag))
                    return tag;
                else
                    return null;
            }
            else
                return null;
        }
    }
}

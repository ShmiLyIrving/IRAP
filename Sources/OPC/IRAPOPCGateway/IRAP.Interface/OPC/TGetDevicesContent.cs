using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;

namespace IRAP.Interface.OPC
{
    public class TGetDevicesContent : TSoftlandContent
    {
        private TGetDevicesReqBody reqBody = new TGetDevicesReqBody();
        private TGetDevicesRspBody rspBody = new TGetDevicesRspBody();

        public TGetDevicesContent()
        {
            bodyRequest = new TGetDevicesReqBody();
            bodyResponse = new TGetDevicesRspBody();
        }

        public TGetDevicesRspBody ResponseBody
        {
            get { return bodyResponse as TGetDevicesRspBody; }
        }
    }

    public class TGetDevicesReqBody : TSoftlandBody
    {
        protected override XmlNode GenerateUserDefineNode()
        {
            return null;
        }
    }

    public class TGetDevicesRspBody : TSoftlandBody
    {
        private List<TGetDevicesRspDetail> details = new List<TGetDevicesRspDetail>();

        public string ExCode { get { return "GetDevices"; } }
        public string ErrCode { get; set; }
        public string ErrText { get; set; }

        public TGetDevicesRspBody()
        {
        }

        public void AddDeviceDetail(TGetDevicesRspDetail item)
        {
            details.Add(item);
        }

        public XmlNode GenerateXMLNode(XmlDocument xml, XmlNode row)
        {
            PropertyInfo[] fields = GetType().GetProperties();
            row.Attributes.RemoveAll();
            foreach (PropertyInfo field in fields)
            {
                XmlAttribute attr = xml.CreateAttribute(field.Name);

                if (field.GetValue(this, null) == null)
                    attr.Value = "";
                else
                    attr.Value = field.GetValue(this, null).ToString();
                row.Attributes.Append(attr);
            }

            return row;
        }

        protected override XmlNode GenerateUserDefineNode()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode result = xml.CreateElement("Result");

            XmlNode node = xml.CreateElement("Param");
            node = GenerateXMLNode(xml, node);
            result.AppendChild(node);

            node = xml.CreateElement("ParamXML");
            result.AppendChild(node);

            for (int i = 0; i < details.Count; i++)
            {
                XmlNode row = xml.CreateElement("Row");
                row = details[i].GenerateXMLNode(xml, row);

                if (row.Attributes["Ordinal"] != null)
                    row.Attributes["Ordinal"].Value = (i + 1).ToString();
                else
                {
                    XmlAttribute attr = xml.CreateAttribute("Ordinal");
                    attr.Value = (i + 1).ToString();
                    row.Attributes.Append(attr);
                }

                node.AppendChild(row);
            }

            return result;
        }
    }

    public class TGetDevicesRspDetail
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 设备代码
        /// </summary>
        public string DeviceCode { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// KepServer的IP地址
        /// </summary>
        public string KepServAddr { get; set; }
        /// <summary>
        /// KepServer的服务器名称
        /// </summary>
        public string KepServName { get; set; }
        /// <summary>
        /// KepServer中定义的Channel
        /// </summary>
        public string KepServChannel { get; set; }
        /// <summary>
        /// KepServer中定义的Device
        /// </summary>
        public string KepServDevice { get; set; }

        public TGetDevicesRspDetail Clone()
        {
            return MemberwiseClone() as TGetDevicesRspDetail;
        }

        public XmlNode GenerateXMLNode(XmlDocument xml, XmlNode row)
        {
            PropertyInfo[] fields = GetType().GetProperties();
            row.Attributes.RemoveAll();
            foreach (PropertyInfo field in fields)
            {
                XmlAttribute attr = xml.CreateAttribute(field.Name);
                attr.Value = field.GetValue(this, null).ToString();
                row.Attributes.Append(attr);
            }

            return row;
        }
    }
}

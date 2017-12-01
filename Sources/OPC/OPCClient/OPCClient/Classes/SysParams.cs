using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCClient
{
    public class SysParams
    {
        private static SysParams _instance = null;

        private ESBParam esbParams = new ESBParam();
        private ContentParams esbXMLParams = new ContentParams();

        private SysParams()
        {
        }

        public static SysParams Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SysParams();
                return _instance;
            }
        }

        /// <summary>
        /// 企业消息总线（ESB）配置参数
        /// </summary>
        public ESBParam ESB
        {
            get { return esbParams; }
        }

        /// <summary>
        /// 企业消息总线（ESB）报文参数
        /// </summary>
        public ContentParams Content
        {
            get { return esbXMLParams; }
        }

        public void Save()
        {
            esbParams.Save();
            esbXMLParams.Save();
        }
    }

    /// <summary>
    /// 系统全局参数
    /// </summary>
    public class SysGlobalVariable
    {
        private static SysGlobalVariable _instance = null;

        private string sysParamFileName =
            string.Format(
                "{0}IRAPOPCClient.ini",
                AppDomain.CurrentDomain.BaseDirectory);

        private SysGlobalVariable() { }

        public static SysGlobalVariable Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SysGlobalVariable();
                return _instance;
            }
        }

        /// <summary>
        /// 系统参数配置文件名
        /// </summary>
        public string SysParamsFileName
        {
            get { return sysParamFileName; }
        }
    }

    /// <summary>
    /// 企业消息总线（ESB）配置参数
    /// </summary>
    public class ESBParam
    {
        public ESBParam()
        {
            Load();
        }

        /// <summary>
        /// ESB 连接地址
        /// </summary>
        public string ESBAddress { get; set; }
        /// <summary>
        /// 消息队列名称
        /// </summary>
        public string ESBQueue { get; set; }
        /// <summary>
        /// 消息过滤字符串
        /// </summary>
        public string ESBFilterSring { get; set; }

        public void Load()
        {
            ESBAddress = IniFile.ReadString("ESB", "Address", "", SysGlobalVariable.Instance.SysParamsFileName);
            ESBQueue = IniFile.ReadString("ESB", "QueueName", "", SysGlobalVariable.Instance.SysParamsFileName);
            ESBFilterSring = IniFile.ReadString("ESB", "Filter", "", SysGlobalVariable.Instance.SysParamsFileName);
        }

        public void Save()
        {
            IniFile.WriteString("ESB", "Address", ESBAddress, SysGlobalVariable.Instance.SysParamsFileName);
            IniFile.WriteString("ESB", "QueueName", ESBQueue, SysGlobalVariable.Instance.SysParamsFileName);
            IniFile.WriteString("ESB", "Fitler", ESBFilterSring, SysGlobalVariable.Instance.SysParamsFileName);
        }
    }

    public class ContentParams
    {
        public ContentParams()
        {
            Load();            
        }

        public string ExCode { get; set; }
        public int CommunityID { get; set; }
        public long SysLogID { get; set; }
        public string UserCode { get; set; }
        public int AgencyLeaf { get; set; }
        public int RoleLeaf { get; set; }
        public string StationID { get; set; }

        public void Load()
        {
            int intValue = 0;
            long longValue = 0;

            ExCode = IniFile.ReadString("Content", "ExCode", "", SysGlobalVariable.Instance.SysParamsFileName);

            int.TryParse(
                IniFile.ReadString("Content", "CommunityID", "0", SysGlobalVariable.Instance.SysParamsFileName),
                out intValue);
            CommunityID = intValue;

            long.TryParse(
                IniFile.ReadString("Content", "SysLogID", "0", SysGlobalVariable.Instance.SysParamsFileName),
                out longValue);
            SysLogID = longValue;

            UserCode = IniFile.ReadString("Content", "UserCode", "", SysGlobalVariable.Instance.SysParamsFileName);

            int.TryParse(
                IniFile.ReadString("Content", "AgencyLeaf", "0", SysGlobalVariable.Instance.SysParamsFileName),
                out intValue);
            AgencyLeaf = intValue;

            int.TryParse(
                IniFile.ReadString("Content", "RoleLeaf", "0", SysGlobalVariable.Instance.SysParamsFileName),
                out intValue);
            RoleLeaf = intValue;

            StationID = IniFile.ReadString("Content", "StationID", "", SysGlobalVariable.Instance.SysParamsFileName);
        }

        public void Save()
        {
            IniFile.WriteString(
                "Content",
                "ExCode",
                ExCode,
                SysGlobalVariable.Instance.SysParamsFileName);
            IniFile.WriteString(
                "Content",
                "CommunityID",
                CommunityID.ToString(),
                SysGlobalVariable.Instance.SysParamsFileName);
            IniFile.WriteString(
                "Content",
                "SysLogID",
                SysLogID.ToString(),
                SysGlobalVariable.Instance.SysParamsFileName);
            IniFile.WriteString(
                "Content",
                "UserCode",
                UserCode,
                SysGlobalVariable.Instance.SysParamsFileName);
            IniFile.WriteString(
                "Content",
                "AgencyLeaf",
                AgencyLeaf.ToString(),
                SysGlobalVariable.Instance.SysParamsFileName);
            IniFile.WriteString(
                "Content",
                "RoleLeaf",
                RoleLeaf.ToString(),
                SysGlobalVariable.Instance.SysParamsFileName);
            IniFile.WriteString(
                "Content",
                "StationID",
                StationID,
                SysGlobalVariable.Instance.SysParamsFileName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// 用于人工检查的在制品信息（包括子在制品）
    /// </summary>
    public class Inspecting
    {
        private WIPIDCode mainWIPIDCode = new WIPIDCode();
        private List<SubWIPIDCodeInfo_Inspecting> subWIPIDCodes = 
            new List<SubWIPIDCodeInfo_Inspecting>();

        public Inspecting()
        {
            ScanTime = DateTime.Now;
        }

        public WIPIDCode MainWIPIDCode
        {
            get { return mainWIPIDCode; }
            set { mainWIPIDCode = value; }
        }

        public List<SubWIPIDCodeInfo_Inspecting> SubWIPIDCodes
        {
            get { return subWIPIDCodes; }
            set { subWIPIDCodes = value; }
        }

        /// <summary>
        /// 条码扫描时间
        /// </summary>
        public DateTime ScanTime { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace IRAP_FVS_SPCO.XBarR
{
    public class XBarRConstant
    {
        private static XBarRConstant _instance = null;
        private int cntOfPerGroup = 0;

        private XBarRConstant()
        {
            if (ConfigurationManager.AppSettings["Count of per Group"] != null)
                int.TryParse(
                    ConfigurationManager.AppSettings["Count of per Group"],
                    out cntOfPerGroup);

            if (cntOfPerGroup == 0)
                cntOfPerGroup = 4;
        }

        public static XBarRConstant Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new XBarRConstant();
                return _instance;
            }
        }

        /// <summary>
        /// 每组需要测量的样品个数
        /// </summary>
        public int CntOfPerGroup { get { return cntOfPerGroup; } }
        public double A2
        {
            get
            {
                switch (cntOfPerGroup)
                {
                    case 2:
                        return 1.880;
                    case 3:
                        return 1.023;
                    case 4:
                        return 0.729;
                    case 5:
                        return 0.577;
                    case 6:
                        return 0.483;
                    default:
                        return 0;
                }
            }
        }
        public double D2
        {
            get
            {
                switch (cntOfPerGroup)
                {
                    case 2:
                        return 1.128;
                    case 3:
                        return 1.693;
                    case 4:
                        return 2.059;
                    case 5:
                        return 2.326;
                    case 6:
                        return 2.534;
                    default:
                        return 1;
                }
            }
        }
        public double D3
        {
            get { return 0; }
        }
        public double D4
        {
            get
            {
                switch (cntOfPerGroup)
                {
                    case 2:
                        return 3.267;
                    case 3:
                        return 2.574;
                    case 4:
                        return 2.282;
                    case 5:
                        return 2.114;
                    case 6:
                        return 2.004;
                    default:
                        return 0;
                }
            }
        }
    }
}

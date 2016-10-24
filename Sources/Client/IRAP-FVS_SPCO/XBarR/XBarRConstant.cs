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

        private XBarRConstant()
        {
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
        /// 
        /// </summary>
        /// <param name="cntOfPerGroup">每组需要测量的样品个数</param>
        /// <returns></returns>
        public double A2(int cntOfPerGroup)
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
        public double D2(int cntOfPerGroup)
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
        public double D3(int cntOfPerGroup)
        {
            return 0;
        }
        public double D4(int cntOfPerGroup)
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

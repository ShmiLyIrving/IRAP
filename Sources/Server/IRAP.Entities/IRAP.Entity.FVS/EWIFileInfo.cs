using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    /// <summary>
    /// ufn_EWI_GetInfo_ShowPaper的返回结果
    /// </summary>
    public class EWIShowPaperInfo
    {
        public string PartNumber { get; set; }
        public string WorkUnit { get; set; }
        public string VersionNo { get; set; }

        public EWIShowPaperInfo Clone()
        {
            return MemberwiseClone() as EWIShowPaperInfo;
        }
    }

    /// <summary>
    /// ufn_GetInfo_PSShowPaper的返回结果
    /// </summary>
    public class EWIPSShowPaperInfo
    {
        public string ProductSeries { get; set; }
        public string WorkUnit { get; set; }
        public string VersionNo { get; set; }

        public EWIPSShowPaperInfo Clone()
        {
            return MemberwiseClone() as EWIPSShowPaperInfo;
        }
    }
}
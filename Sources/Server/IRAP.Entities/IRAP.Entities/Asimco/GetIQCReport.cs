using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.Asimco
{
    public class GetIQCReport
    {
        /// <summary>
        /// PDF 格式电子质保书(Base64编码)
        /// </summary>
        public string WarrantyBook { get; set; } = "";
        /// <summary>
        /// PDF 格式检验报告(Base64编码)
        /// </summary>
        public string IQCReport { get; set; } = "";
    }
}

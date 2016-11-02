using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
    public class TemplateContent
    {
        /// <summary>
        /// 
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 模板叶标识
        /// </summary>
        public int T117LeafID { get; set; }
        /// <summary>
        /// 模板代码
        /// </summary>
        public string T117Code { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        public string T117Name { get; set; }
        /// <summary>
        /// 标签模板明文(FastReport格式)
        /// </summary>
        public string TemplateFMTStr { get; set; }
        /// <summary>
        /// ZPL文件
        /// </summary>
        public string PreloadZPL { get; set; }
        /// <summary>
        /// Lab文件地址信息
        /// </summary>
        public string LabFilePath { get; set; }

        public TemplateContent Clone()
        {
            return MemberwiseClone() as TemplateContent;
        }
    }
}
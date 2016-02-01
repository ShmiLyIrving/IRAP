using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.SSO
{
    /// <summary>
    /// 工位或功能信息
    /// </summary>
    public class WorkUnitInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工位标识
        /// </summary>
        public int WorkUnitID { get; set; }
        /// <summary>
        /// 工位叶标识
        /// </summary>
        public int WorkUnitLeaf { get; set; }
        /// <summary>
        /// 工位代码
        /// </summary>
        public string WorkUnitCode { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string WorkUnitName { get; set; }
        /// <summary>
        /// 工位状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 工位状态字符串
        /// </summary>
        public string StatusStr { get; set; }
        /// <summary>
        /// 良品容器编号
        /// </summary>
        public string ContainerNo1 { get; set; }
        /// <summary>
        ///  不良品容器编号‘
        /// </summary>
        public string ContainerNo2 { get; set; }
        /// <summary>
        /// 是否记录前工位生产
        /// </summary>
        public bool RecordPrevWorkUnit { get; set; }

        public override string ToString()
        {
            return WorkUnitName;
        }

        public WorkUnitInfo Clone()
        {
            return MemberwiseClone() as WorkUnitInfo;
        }
    }
}
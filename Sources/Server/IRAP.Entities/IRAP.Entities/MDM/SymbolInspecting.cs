using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
    /// <summary>
    /// 检查工序的部件位置
    /// </summary>
    public class SymbolInspecting
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 部件位置标识
        /// </summary>
        public int T110EntityID { get; set; }
        /// <summary>
        /// 部件位置叶标识
        /// </summary>
        public int T110LeafID { get; set; }
        /// <summary>
        /// 部件位置代号
        /// </summary>
        public string T110Code { get; set; }
        /// <summary>
        /// 部件位置分组代码(0-不分 1-正面 2-反面)
        /// </summary>
        public string T123Code { get; set; }
        /// <summary>
        /// 部件类型树标识(101-原辅材料 102-半成品)
        /// </summary>
        public int ComponentTreeID { get; set; }
        /// <summary>
        /// 部件叶标识
        /// </summary>
        public int ComponentLeafID { get; set; }
        /// <summary>
        /// 部件物料代码(材料代码/产品编号)
        /// </summary>
        public string ComponentCode { get; set; }
        /// <summary>
        /// 维修次数限制
        /// </summary>
        public long RepairTimesLimit { get; set; }
        /// <summary>
        /// 部件位置X坐标(世界坐标)
        /// </summary>
        public double XCoordinate { get; set; }
        /// <summary>
        /// 部件位置Y坐标(世界坐标)
        /// </summary>
        public double YCoordinate { get; set; }
        /// <summary>
        /// 部件位置Z坐标(世界坐标)
        /// </summary>
        public double ZCoordinate { get; set; }
        /// <summary>
        /// 生产任务种类叶标识
        /// </summary>
        public int PWOCategoryLeaf { get; set; }
        /// <summary>
        /// 生产任务种类名称
        /// </summary>
        public string PWOCategoryName { get; set; }

        public SymbolInspecting Clone()
        {
            SymbolInspecting rlt = MemberwiseClone() as SymbolInspecting;

            return rlt;
        }
    }
}
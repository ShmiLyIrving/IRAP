using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
    /// <summary>
    /// 工位
    /// </summary>
    public class WorkUnit
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// 工位叶标识
        /// </summary>
        public int T107LeafID { get; set; }

        /// <summary>
        /// 工位实体标识
        /// </summary>
        public int T107EntityID { get; set; }

        /// <summary>
        /// 工位代码
        /// </summary>
        public string T107Code { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string T107Name { get; set; }

        /// <summary>
        /// 主关联设备叶标识
        /// </summary>
        public int T133LeafID { get; set; }

        /// <summary>
        /// 主关联设备代码
        /// </summary>
        public string T133Code { get; set; }

        /// <summary>
        /// 主关联设备名称
        /// </summary>
        public string T133Name { get; set; }

        /// <summary>
        /// 工序类型叶标识
        /// </summary>
        public int T116LeafID { get; set; }

        public WorkUnit Clone()
        {
            WorkUnit rlt = MemberwiseClone() as WorkUnit;

            return rlt;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}",
                T107Code == "" ? "" : string.Format("[{0}]", T107Code), T107Name);
        }
    }

    public class WorkUnit_CompareByCode : IComparer<WorkUnit>
    {
        public int Compare(WorkUnit x, WorkUnit y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (y == null)
                    return 1;
                else
                    return x.T107Code.CompareTo(y.T107Code);
            }
        }
    }

    public class WorkUnit_CompareByName : IComparer<WorkUnit>
    {
        public int Compare(WorkUnit x, WorkUnit y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (y == null)
                    return 1;
                else
                    return x.T107Name.CompareTo(y.T107Name);
            }
        }
    }
}

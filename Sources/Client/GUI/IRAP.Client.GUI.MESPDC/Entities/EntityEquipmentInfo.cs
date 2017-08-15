using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Client.GUI.MESPDC.Entities
{
    /// <summary>
    /// 批次系统中的工位设备信息
    /// </summary>
    public class EntityEquipmentInfo
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
        /// 工序代码
        /// </summary>
        public string T107AltCode { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string T107Name { get; set; }
        /// <summary>
        /// 产线叶标识
        /// </summary>
        public int T134LeafID { get; set; }
        /// <summary>
        /// 产线实体标识
        /// </summary>
        public int T134EntityID { get; set; }
        /// <summary>
        /// 产线代码
        /// </summary>
        public string T134Code { get; set; }
        /// <summary>
        /// 产线替代代码
        /// </summary>
        public string T134AltCode { get; set; }
        /// <summary>
        /// 工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }
        /// <summary>
        /// 工序实体标识
        /// </summary>
        public int T216EntityID { get; set; }
        /// <summary>
        /// 工序代码
        /// </summary>
        public string T216Code { get; set; }
        /// <summary>
        /// 工序替代代码
        /// </summary>
        public string T216AltCode { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string T216Name { get; set; }
        /// <summary>
        /// 设备叶标识
        /// </summary>
        public int T133LeafID { get; set; }
        /// <summary>
        /// 设备实体标识
        /// </summary>
        public int T133EntityID { get; set; }
        /// <summary>
        /// 设备代码
        /// </summary>
        public string T133Code { get; set; }
        /// <summary>
        /// 设备替代代码
        /// </summary>
        public string T133AltCode { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}]{1}", T133AltCode, T107Name);
        }

        public EntityEquipmentInfo Clone()
        {
            return MemberwiseClone() as EntityEquipmentInfo;
        }
    }

    public class EntityEquipmentInfo_CompareByT133AltCode : 
        IComparer<EntityEquipmentInfo>
    {
        public int Compare(EntityEquipmentInfo x, EntityEquipmentInfo y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    return x.T133AltCode.CompareTo(y.T133AltCode);
                }
            }
        }
    }
}

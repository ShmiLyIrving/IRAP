using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 工序作业标准
    /// </summary>
    public class OPStandard
    {
        private byte[] t112Icon;
        private Image imageT112Icon = null;
        private byte[] sopImage;
        private Image imageSOPImage = null;

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工序步骤序号
        /// </summary>
        public int StepNo { get; set; }
        /// <summary>
        /// 生产资源序号
        /// </summary>
        public int ResourceNo { get; set; }
        /// <summary>
        /// 人或设备（1=人；2-设备）
        /// </summary>
        public int ManOrMachine { get; set; }
        /// <summary>
        /// 动素叶标识
        /// </summary>
        public int T112LeafID { get; set; }
        /// <summary>
        /// 动素代码
        /// </summary>
        public string T112Code { get; set; }
        /// <summary>
        /// 动素名称
        /// </summary>
        public string T112Name { get; set; }
        /// <summary>
        /// 动素图标
        /// </summary>
        public byte[] T112Icon
        {
            get { return t112Icon; }
            set
            {
                t112Icon = value;
                imageT112Icon = Tools.BytesToImage(value);
            }
        }
        /// <summary>
        /// 工作元素描述
        /// </summary>
        public string JobElementDesc { get; set; }
        /// <summary>
        /// 开始时间偏移量（ms）
        /// </summary>
        public int StatTimeOffset { get; set; }
        /// <summary>
        /// 截止时间偏移量（ms）
        /// </summary>
        public int EndTimeOffset { get; set; }
        /// <summary>
        /// 作业指导图像
        /// </summary>
        public byte[] SOPImage
        {
            get { return sopImage; }
            set
            {
                sopImage = value;
                imageSOPImage = Tools.BytesToImage(value);
            }
        }
        /// <summary>
        ///  是否引用自模板
        /// </summary>
        public bool Reference { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public Image ImageT112Icon
        {
            get { return imageT112Icon; }
            set
            {
                imageT112Icon = value;
                if (value != null)
                    t112Icon = Tools.ImageToBytes(value);
            }
        }

        [IRAPORMMap(ORMMap = false)]
        public Image ImageSOPImage
        {
            get { return imageSOPImage; }
            set
            {
                imageSOPImage = value;
                if (value != null)
                    sopImage = Tools.ImageToBytes(value);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}", StepNo, T112Name);
        }

        public OPStandard Clone()
        {
            return MemberwiseClone() as OPStandard;
        }
    }
}
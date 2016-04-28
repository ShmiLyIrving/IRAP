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
    /// 指定产品指定工序的操作工技能矩阵
    /// </summary>
    public class SkillMatrixByMethod
    {
        private byte[] qualificationFactIcon;
        private Image qualificationFactImage = null;

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 操作工工号
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 操作工姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 操作工技能等级(1-优秀 2=老练 3-良好 4-合格)
        /// </summary>
        public int QualificationLevel { get; set; }
        /// <summary>
        /// 资质脸谱图标
        /// </summary>
        public byte[] QualificationFaceIcon
        {
            get { return qualificationFactIcon; }
            set
            {
                qualificationFactIcon = value;
                qualificationFactImage = Tools.BytesToImage(value);
            }
        }
        /// <summary>
        /// 是否来自模板(供参考)
        /// </summary>
        public bool Reference { get; set; }

        [IRAPORMMap(ORMMap =false)]
        public Image QualificationFactImage
        {
            get { return qualificationFactImage; }
            set
            {
                qualificationFactImage = value;
                if (value != null)
                    qualificationFactIcon = Tools.ImageToBytes(value);
            }
        }

        public SkillMatrixByMethod Clone()
        {
            return MemberwiseClone() as SkillMatrixByMethod;
        }
    }
}
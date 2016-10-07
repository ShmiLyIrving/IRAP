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
    /// 一点课
    /// </summary>
    public class OnePointLesson
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 问题编号
        /// </summary>
        public int IssueNo { get; set; }
        /// <summary>
        /// 工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }
        /// <summary>
        /// 工序代码
        /// </summary>
        public string T216Code { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string T216Name { get; set; }
        /// <summary>
        /// 问题类型
        /// </summary>
        public string IssueType { get; set; }
        /// <summary>
        /// 缺陷描述
        /// </summary>
        public string DefectDesc { get; set; }
        /// <summary>
        /// 缺陷根源叶标识
        /// </summary>
        public int T144LeafID { get; set; }
        /// <summary>
        /// 缺陷根源代码
        /// </summary>
        public string T144Code { get; set; }
        /// <summary>
        /// 缺陷根源
        /// </summary>
        public string T144Name { get; set; }
        /// <summary>
        /// 操作要求
        /// </summary>
        public string OperationReq { get; set; }
        /// <summary>
        /// 不正确的图片Base64编码
        /// </summary>
        public string IncorrectPic { get; set; }
        /// <summary>
        /// 正确的图片Base64编码
        /// </summary>
        public string CorrectPic { get; set; }
        /// <summary>
        /// 培训日期
        /// </summary>
        public string TrainingDate { get; set; }
        /// <summary>
        /// 培训者工号
        /// </summary>
        public string TrainerCode { get; set; }
        /// <summary>
        /// 培训者姓名
        /// </summary>
        public string TrainerName { get; set; }

        /// <summary>
        /// 不正确的图片
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public Image IncorrectPicture
        {
            get { return Base64ToImage(IncorrectPic); }
        }
        /// <summary>
        /// 正确的图片
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public Image CorrectPicture
        {
            get { return Base64ToImage(CorrectPic); }
        }

        private Image Base64ToImage(string stringBase64)
        {
            byte[] imageBytes;
            try
            {
                imageBytes = Convert.FromBase64String(stringBase64);
                return Tools.BytesToImage(imageBytes);
            }
            catch
            {
                return null;
            }
        }

        public OnePointLesson Clone()
        {
            return MemberwiseClone() as OnePointLesson;
        }
    }
}
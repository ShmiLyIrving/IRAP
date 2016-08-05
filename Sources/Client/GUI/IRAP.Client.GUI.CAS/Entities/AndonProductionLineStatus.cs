using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IRAP.Client.GUI.CAS.Entities
{
    public class AndonProductionLineStatus
    {
        /// <summary>
        /// 区域 NodeID
        /// </summary>
        public int NodeID { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 产线标识
        /// </summary>
        public int T134LeafID { get; set; }
        /// <summary>
        /// 产线名称
        /// </summary>
        public string T134NodeName { get; set; }
        /// <summary>
        /// 物料状态图片
        /// </summary>
        public Image MaterialStatusPic
        {
            get { return GetPICFormResource("M", MaterialStatus, MaterialResponded); }
        }
        /// <summary>
        /// 物料状态
        /// </summary>
        public int MaterialStatus { get; set; }
        /// <summary>
        /// 物料呼叫已过时间
        /// </summary>
        public int MaterialTimeElapsed { get; set; }
        /// <summary>
        /// 维修状态图片
        /// </summary>
        public Image EquipmentStatusPic
        {
            get { return GetPICFormResource("R", EquipmentStatus, EquipmentResponded); }
        }
        /// <summary>
        /// 物料状态
        /// </summary>
        public int EquipmentStatus { get; set; }
        /// <summary>
        /// 质量状态图片
        /// </summary>
        public Image QualifyStatusPic
        {
            get { return GetPICFormResource("Q", QualifyStatus, QualifyResponded); }
        }
        /// <summary>
        /// 质量状态
        /// </summary>
        public int QualifyStatus { get; set; }
        /// <summary>
        /// 安全状态图片
        /// </summary>
        public Image SecurityStatusPic
        {
            get { return GetPICFormResource("S", SecurityStatus, SecurityResponded); }
        }
        /// <summary>
        /// 安全状态
        /// </summary>
        public int SecurityStatus { get; set; }
        /// <summary>
        /// 技术状态图片
        /// </summary>
        public Image TechnologyStatusPic
        {
            get { return GetPICFormResource("T", TechnologyStatus, TechnologyResponded); }
        }
        /// <summary>
        /// 技术状态
        /// </summary>
        public int TechnologyStatus { get; set; }
        /// <summary>
        /// 设计状态图片
        /// </summary>
        public Image DesignStatusPic
        {
            get { return GetPICFormResource("D", DesignStatus, DesignResponded); }
        }
        /// <summary>
        /// 设计状态
        /// </summary>
        public int DesignStatus { get; set; }
        /// <summary>
        /// 其他状态图片
        /// </summary>
        public Image OtherStatusPic
        {
            get { return GetPICFormResource("O", OtherStatus, OtherResponded); }
        }
        /// <summary>
        /// 其他状态
        /// </summary>
        public int OtherStatus { get; set; }
        /// <summary>
        /// 工装状态图片
        /// </summary>
        public Image ToolingStatusPic
        {
            get { return GetPICFormResource("F", ToolingStatus, ToolingResponded); }
        }
        /// <summary>
        /// 工装状态
        /// </summary>
        public int ToolingStatus { get; set; }
        /// <summary>
        /// 设计呼叫已过时间
        /// </summary>
        public int DesignTimeElapsed { get; set; }
        /// <summary>
        /// 维修呼叫已过时间
        /// </summary>
        public int EquipmentTimeElapsed { get; set; }
        /// <summary>
        /// 其他呼叫已过时间
        /// </summary>
        public int OtherTimeElapsed { get; set; }
        /// <summary>
        /// 质量呼叫已过时间
        /// </summary>
        public int QualifyTimeElapsed { get; set; }
        /// <summary>
        /// 安全呼叫已过时间
        /// </summary>
        public int SecurityTimeElapsed { get; set; }
        /// <summary>
        /// 技术呼叫已过时间
        /// </summary>
        public int TechnologyTimeElapsed { get; set; }
        /// <summary>
        /// 工装呼叫已过时间
        /// </summary>
        public int ToolingTimeElapsed { get; set; }
        public string DesignTimeElapsedString
        {
            get { return GetTimeElapsedString(DesignTimeElapsed); }
        }
        public string EquipmentTimeElapsedString
        {
            get { return GetTimeElapsedString(EquipmentTimeElapsed); }
        }
        public string OtherTimeElapsedString
        {
            get { return GetTimeElapsedString(OtherTimeElapsed); }
        }
        public string QualifyTimeElapsedString
        {
            get { return GetTimeElapsedString(QualifyTimeElapsed); }
        }
        public string SecurityTimeElapsedString
        {
            get { return GetTimeElapsedString(SecurityTimeElapsed); }
        }
        public string TechnologyTimeElapsedString
        {
            get { return GetTimeElapsedString(TechnologyTimeElapsed); }
        }
        public string ToolingTimeElapsedString
        {
            get { return GetTimeElapsedString(ToolingTimeElapsed); }
        }
        public string MaterialTimeElapsedString
        {
            get { return GetTimeElapsedString(MaterialTimeElapsed); }
        }
        /// <summary>
        /// 设计事件响应
        /// </summary>
        public bool DesignResponded { get; set; }
        /// <summary>
        /// 维修事件响应
        /// </summary>
        public bool EquipmentResponded { get; set; }
        /// <summary>
        /// 物料事件响应
        /// </summary>
        public bool MaterialResponded { get; set; }
        /// <summary>
        /// 其他事件响应
        /// </summary>
        public bool OtherResponded { get; set; }
        /// <summary>
        /// 质量事件响应
        /// </summary>
        public bool QualifyResponded { get; set; }
        /// <summary>
        /// 安全事件响应
        /// </summary>
        public bool SecurityResponded { get; set; }
        /// <summary>
        /// 技术事件响应
        /// </summary>
        public bool TechnologyResponded { get; set; }
        /// <summary>
        /// 工装事件响应
        /// </summary>
        public bool ToolingResponded { get; set; }

        public Image GetPICFormResource(string prefix, int status, bool responded)
        {
            string picName = "";

            switch (status)
            {
                case 0:
                case 1:
                    picName = string.Format("{0}{1}_48", prefix, status);
                    break;
                case 2:
                case 3:
                    if (responded)
                        picName = string.Format("{0}{1}_R_48", prefix, status);
                    else
                        picName = string.Format("{0}{1}_48", prefix, status);
                    break;
            }

            Image img = null;
            if (picName != "")
            {
                img = (IRAP.Client.Global.Resources.Properties.Resources.ResourceManager.GetObject(picName) as Bitmap);
            }
            return img;
        }

        public string GetTimeElapsedString(int timeElapsedSeconds)
        {
            if (timeElapsedSeconds / 60 < 1)
                return "";
            else
                return string.Format("已过{0}分钟", timeElapsedSeconds / 60);
        }

        public AndonProductionLineStatus Clone()
        {
            return this.MemberwiseClone() as AndonProductionLineStatus;
        }
    }
}

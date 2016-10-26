using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    public class AvailableSite
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 客户叶标识
        /// </summary>
        public int T105LeafID { get; set; }
        /// <summary>
        /// 客户代码
        /// </summary>
        public string T105Code { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string T105Name { get; set; }
        /// <summary>
        /// 地点叶标识
        /// </summary>
        public int T172LeafID { get; set; }
        /// <summary>
        /// 地点名称
        /// </summary>
        public string T172Code { get; set; }
        /// <summary>
        /// 地点名称
        /// </summary>
        public string T172Name { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string ToContact { get; set; }
        /// <summary>
        /// 办公电话
        /// </summary>
        public string OPhoneNo { get; set; }
        /// <summary>
        /// 邮件地址
        /// </summary>
        public string EmailAddr { get; set; }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string MPhoneNo { get; set; }
        /// <summary>
        /// 经度坐标(±ddd°ff′mm″)
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 纬度坐标(±dd°ff′mm″)
        /// </summary>
        public string Latitude { get; set; }

        public AvailableSite Clone()
        {
            return MemberwiseClone() as AvailableSite;
        }

        public override string ToString()
        {
            return string.Format(
                "[{0}]{1} 地址：{2} 联系人：{3} 办公电话：{4}", 
                T172Code, 
                T172Name.Trim(), 
                Address.Trim(),
                ToContact.Trim(),
                OPhoneNo.Trim());
        }
    }
}
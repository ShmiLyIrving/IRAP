using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 万能表单控件信息
    /// </summary>
    public class FormCtrlInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// TAB序
        /// </summary>
        public int TabOrder { get; set; }
        /// <summary>
        /// 控件类型
        /// </summary>
        public string CtrlType { get; set; }
        /// <summary>
        /// 控件标题
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 控件顶部位置(Pixel)
        /// </summary>
        public int CtrlTop { get; set; }
        /// <summary>
        /// 控件左边位置(Pixel)
        /// </summary>
        public int CtrlLeft { get; set; }
        /// <summary>
        /// 控件高度(Pixel)
        /// </summary>
        public int CtrlHeight { get; set; }
        /// <summary>
        /// 控件宽度(Pixel)
        /// </summary>
        public int CtrlWidth { get; set; }
        /// <summary>
        /// 控件字体
        /// </summary>
        public string FontName { get; set; }
        /// <summary>
        /// 控件字号
        /// </summary>
        public string FontSize { get; set; }
        /// <summary>
        /// 控件颜色
        /// </summary>
        public int FontColor { get; set; }
        /// <summary>
        /// 对齐方式
        /// </summary>
        public string Alignment { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 是否可见
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// 文字环绕
        /// </summary>
        public bool WordWrap { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Hint { get; set; }
        /// <summary>
        /// 外连控件类名
        /// </summary>
        public string RunFormClassName { get; set; }
        /// <summary>
        /// 外连控件程序集名
        /// </summary>
        public string RunFormAtLibraryName { get; set; }
        /// <summary>
        /// 需要申请的交易号数
        /// </summary>
        public int NumTransToApply { get; set; }
        /// <summary>
        /// 需要申请的事实编号数
        /// </summary>
        public int NumFactsToApply { get; set; }
        /// <summary>
        /// 默认的字串输入
        /// </summary>
        public string DefaultValueStr { get; set; }
        /// <summary>
        /// 是否需要校验
        /// </summary>
        public bool CheckRequired { get; set; }
        /// <summary>
        /// 字体大小
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public float FontSizeFloat
        {
            get
            {
                switch (this.FontSize)
                {
                    case "八号":
                    case "七号":
                        return 5.25f;
                    case "小六号":
                    case "小六":
                        return 6.25f;
                    case "六号":
                        return 7.25f;
                    case "小五号":
                    case "小五":
                        return 9f;
                    case "五号":
                        return 10.5f;
                    case "小四号":
                    case "小四":
                        return 12f;
                    case "四号":
                        return 14.25f;
                    case "小三号":
                    case "小三":
                        return 15f;
                    case "三号":
                        return 15.75f;
                    case "小二号":
                    case "小二":
                        return 18f;
                    case "二号":
                        return 21.75f;
                    case "小一号":
                    case "小一":
                        return 24f;
                    case "一号":
                        return 26.25f;
                    case "小初号":
                    case "小初":
                        return 36f;
                    case "初号":
                        return 42f;
                    default:
                        return Convert.ToSingle(this.FontSize);
                }
            }
        }

        public FormCtrlInfo Clone()
        {
            FormCtrlInfo rlt = MemberwiseClone() as FormCtrlInfo;

            return rlt;
        }
    }
}
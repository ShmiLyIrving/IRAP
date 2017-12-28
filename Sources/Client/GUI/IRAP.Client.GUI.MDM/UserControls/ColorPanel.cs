using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IRAP.Entity.UTS;

namespace IRAP.Client.GUI.MDM {
    public partial class ColorPanel : XtraUserControl {
        public ColorPanel() {
            InitializeComponent();
        }

        private static Point INITIAL_LOCATION = new Point(5, 5);//初始位置
        private static int SPACINT = 2;//间距
        private static int LABEL_HEIGHT = 20;//高度

        public void InitColorPanel(List<ImportErrorTypes> importErrType) {
            if (importErrType==null||importErrType.Count == 0) {
                return;
            }
            int currentHeight = INITIAL_LOCATION.Y;
            foreach (ImportErrorTypes item in importErrType) {
                var newlabel = CreateColorLabel(item.ErrType, item.BGColor);
                if (importErrType.IndexOf(item) == 0) {
                    newlabel.Location = INITIAL_LOCATION;
                } else {
                    var height = currentHeight + LABEL_HEIGHT + SPACINT;
                    newlabel.Location = new Point(INITIAL_LOCATION.X, height);
                    currentHeight = height;
                }
                this.panelControl1.Controls.Add(newlabel);               
            }
        }

        /// <summary>
        /// 创建label
        /// </summary>
        /// <param name="err">错误信息</param>
        /// <param name="color">颜色，十六进制</param>
        /// <returns></returns>
        private ColorLabel CreateColorLabel(string err,string color) {
            ColorLabel label = new ColorLabel();
            label.Text = err;
            label.Color = ConvertColorHx16ToRGB(color);
            label.Size = new System.Drawing.Size(this.Width-SPACINT,LABEL_HEIGHT);
            label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            return label;
        }

        /// <summary>
        /// [颜色：16进制转成RGB]
        /// </summary>
        /// <param name="strColor">设置16进制颜色 [返回RGB]</param>
        /// <returns></returns>
        public static System.Drawing.Color ConvertColorHx16ToRGB(string strHxColor) {
            try {
                if (strHxColor.Length == 0) {//如果为空
                    return System.Drawing.Color.FromArgb(0, 0, 0);//设为黑色
                } else {//转换颜色
                    return System.Drawing.Color.FromArgb(System.Int32.Parse(strHxColor.Substring(1, 2), System.Globalization.NumberStyles.AllowHexSpecifier), System.Int32.Parse(strHxColor.Substring(3, 2), System.Globalization.NumberStyles.AllowHexSpecifier), System.Int32.Parse(strHxColor.Substring(5, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
                }
            } catch {//设为黑色
                return System.Drawing.Color.FromArgb(0, 0, 0);
            }
        }
    }
}

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

        private static int VERTICAL_SPACINT = 2;//间距
        private static int LABEL_HEIGHT = 17;//高度
        private static int EDGE_SPACING = 2;//边缘距离
        private static int LABEL_WIDTH = 128;//label宽度

        private double _horizontalSpacing = 2;//水平间距

        /// <summary>
        /// 每行的个数
        /// </summary>
        [Browsable(true)]
        public int EachRowNumber {
            get { return _eachRowNumber; }
            set { _eachRowNumber = value; }
        }
        private int _eachRowNumber = 6;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="importErrType"></param>
        public void InitColorPanel(List<ImportErrorTypes> importErrType) {
            if (importErrType==null||importErrType.Count == 0) {
                return;
            }
            #region 测试数据
            if (importErrType==null) {
                importErrType = new List<ImportErrorTypes> ();
            }
            importErrType.Add(new ImportErrorTypes() {Ordinal = 2,ErrType="测试11111111111",BGColor= "#CC00FF"});
            importErrType.Add(new ImportErrorTypes() {Ordinal = 3,ErrType="测试222222222",BGColor= "#FFB6C1"});
            importErrType.Add(new ImportErrorTypes() { Ordinal = 4, ErrType = "测试3333333333333", BGColor = "#FFC0CB" });
            importErrType.Add(new ImportErrorTypes() { Ordinal = 5, ErrType = "测试4444444444444444", BGColor = "#DC143C" });
            importErrType.Add(new ImportErrorTypes() { Ordinal = 6, ErrType = "测试5555555555555555", BGColor = "#8B008B" });
            importErrType.Add(new ImportErrorTypes() { Ordinal = 7, ErrType = "测试6666666666666666", BGColor = "#9370DB" });
            importErrType.Add(new ImportErrorTypes() { Ordinal = 8, ErrType = "测试777777777777", BGColor = "#000080" });
            importErrType.Add(new ImportErrorTypes() { Ordinal = 9, ErrType = "测试88", BGColor = "#00BFFF" });
            importErrType.Add(new ImportErrorTypes() { Ordinal = 10, ErrType = "测试9", BGColor = "#3CB371" });
            importErrType.Add(new ImportErrorTypes() { Ordinal = 11, ErrType = "测试10101010101", BGColor = "#228B22" });
            importErrType.Add(new ImportErrorTypes() { Ordinal = 12, ErrType = "测试121212121212121212", BGColor = "#FFFF00" });
            #endregion
            this.Controls.Clear();
            _horizontalSpacing = CreateLabelWidth();
            var row = Convert.ToInt32(Math.Ceiling((double)importErrType.Count / _eachRowNumber));
            foreach (ImportErrorTypes item in importErrType) {
                var newLabel = CreateColorLabel(item.ErrType, item.BGColor);
                var index = importErrType.IndexOf(item);
                int i = Convert.ToInt32(Math.Floor((double)index/_eachRowNumber));//行序号
                int j = index % _eachRowNumber;//列序号
                newLabel.Location = new Point(Convert.ToInt32(EDGE_SPACING + j * LABEL_WIDTH + j * _horizontalSpacing), Convert.ToInt32(EDGE_SPACING + i * LABEL_HEIGHT + i * VERTICAL_SPACINT));
                
                #region 另一种计算方法
                //if (index == 0) {
                //    newLabel.Location = new Point(currentX, currentY);
                //} else {
                //    if (index / _eachRowNumber == 0) {
                //        currentY += VERTICAL_SPACINT + LABEL_HEIGHT;
                //        currentX = EDGE_SPACING;
                //    } else {
                //        currentX += LABEL_WIDTH + Convert.ToInt32(Math.Floor(_horizontalSpacing));
                //    }
                //    newLabel.Location = new Point(currentX, currentY);

                //}
                #endregion
                
                this.Controls.Add(newLabel);               
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
            label.Size = new System.Drawing.Size(LABEL_WIDTH,LABEL_HEIGHT);
            //label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            //| System.Windows.Forms.AnchorStyles.Right)));
            return label;
        }

        /// <summary>
        /// [颜色：16进制转成RGB]
        /// </summary>
        /// <param name="strColor">设置16进制颜色 [返回RGB]</param>
        /// <returns></returns>
        private static System.Drawing.Color ConvertColorHx16ToRGB(string strHxColor) {
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

        /// <summary>
        /// 计算宽度
        /// </summary>
        /// <returns></returns>
        private double CreateLabelWidth() {
            var result = (this.Width-20 - 2 * EDGE_SPACING - LABEL_WIDTH * _eachRowNumber) / (_eachRowNumber-1);
            return result > 0 ? result : 2;
        }

        /// <summary>
        /// 清除label
        /// </summary>
        public void ClearLabel() {
            this.Controls.Clear();
        }

    }
}

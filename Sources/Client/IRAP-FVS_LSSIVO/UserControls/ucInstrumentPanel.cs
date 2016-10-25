using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using IRAP.Client.Global.Enums;

namespace IRAP_FVS_LSSIVO.UserControls
{
    public partial class ucInstrumentPanel : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// KPI 状态字段
        /// </summary>
        private KPIStatus status = KPIStatus.ksNotProduced;
        /// <summary>
        /// 标题字段
        /// </summary>
        private string titleName = "";
        /// <summary>
        /// 指标值字段
        /// </summary>
        private decimal kpiValue = 0.00M;
        /// <summary>
        /// 指标值格式化字段
        /// </summary>
        private string valueFormatter = "0";

        public ucInstrumentPanel()
        {
            InitializeComponent();

            lblTitle.Parent = picTitle;
            lblValue.Parent = picKPI;
        }

        /// <summary>
        /// KPI 状态属性
        /// </summary>
        [Browsable(true)]
        [DefaultValue(KPIStatus.ksNotProduced)]
        [Description("KPI 状态")]
        public KPIStatus Status
        {
            get { return status; }
            set
            {
                status = value;

                switch (status)
                {
                    case KPIStatus.ksNotProduced:
                        picTitle.BackgroundImage = Properties.Resources.rectangle_gray;
                        picTitle.BackgroundImageLayout = ImageLayout.Stretch;
                        picKPI.BackgroundImage = Properties.Resources.circular_gray;
                        pnlBody.Appearance.BorderColor = Color.Gray;

                        break;
                    case KPIStatus.ksRegular:
                        picTitle.BackgroundImage = Properties.Resources.rectangle_green;
                        picTitle.BackgroundImageLayout = ImageLayout.Stretch;
                        picKPI.BackgroundImage = Properties.Resources.circular_green;
                        pnlBody.Appearance.BorderColor = Color.Green;

                        break;
                    case KPIStatus.ksWarning:
                        picTitle.BackgroundImage = Properties.Resources.rectangle_yellow;
                        picTitle.BackgroundImageLayout = ImageLayout.Stretch;
                        picKPI.BackgroundImage = Properties.Resources.circular_yellow;
                        pnlBody.Appearance.BorderColor = Color.Brown;

                        break;
                    case KPIStatus.ksAbnormal:
                        picTitle.BackgroundImage = Properties.Resources.rectangle_red;
                        picTitle.BackgroundImageLayout = ImageLayout.Stretch;
                        picKPI.BackgroundImage = Properties.Resources.circular_red;
                        pnlBody.Appearance.BorderColor = Color.Red;

                        break;
                    default:
                        picTitle.BackgroundImage = Properties.Resources.rectangle_gray;
                        picTitle.BackgroundImageLayout = ImageLayout.Stretch;
                        picKPI.BackgroundImage = Properties.Resources.circular_gray;
                        pnlBody.Appearance.BorderColor = Color.Gray;

                        break;
                }
            }
        }

        /// <summary>
        /// 标题属性
        /// </summary>
        [Browsable(true)]
        [Description("标题")]
        [DefaultValue("")]
        public string Title
        {
            get { return titleName; }
            set
            {
                titleName = value;
                lblTitle.Text = titleName;
            }
        }

        /// <summary>
        /// KPI 指标值属性
        /// </summary>
        [Browsable(true)]
        [Description("KPI 指标值")]
        [DefaultValue(0.00)]
        public decimal Value
        {
            get { return kpiValue; }
            set
            {
                kpiValue = value;
                lblValue.Text = kpiValue.ToString(valueFormatter) + "%";
            }
        }

        [Browsable(true)]
        [Description("指标值格式化字符串")]
        [DefaultValue("0")]
        public string Formatter
        {
            get { return valueFormatter; }
            set
            {
                valueFormatter = value;
                lblValue.Text = kpiValue.ToString(valueFormatter) + "%";
            }
        }

        private void ucInstrumentPanel_Resize(object sender, EventArgs e)
        {
            pnlTitle.Height = Height * 30 / 100;
        }
    }
}

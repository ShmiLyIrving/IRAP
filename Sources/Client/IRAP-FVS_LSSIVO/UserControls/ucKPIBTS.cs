using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace IRAP_FVS_LSSIVO.UserControls
{
    public partial class ucKPIBTS : ucCustomFVSKanban
    {
        private double minimumValue = 0;
        private double maximumValue = 100;
        private TrackBarStyle trackBar = TrackBarStyle.tbsNormal;
        private bool showVernier = false;
        private double actualOutputQuantity = 0;
        private double kpiValue = 0;
        private string kpiName = "BTS";
        private double kpiProgress = 0;

        public ucKPIBTS()
        {
            InitializeComponent();

            TrackBarStyle = TrackBarStyle.tbsNormal;
            ActualOutputQuantity = 0;
        }

        [Browsable(true)]
        [Category("Data")]
        [DefaultValue(0.00)]
        [Description("最小值")]
        public double Minimum
        {
            get { return minimumValue; }
            set { minimumValue = value; }
        }

        [Browsable(true)]
        [Category("Data")]
        [DefaultValue(100.00)]
        [Description("最大值")]
        public double Maximum
        {
            get { return maximumValue; }
            set { maximumValue = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(TrackBarStyle.tbsNormal)]
        [Description("进度条颜色")]
        public TrackBarStyle TrackBarStyle
        {
            get { return trackBar; }
            set
            {
                trackBar = value;

                switch (trackBar)
                {
                    case TrackBarStyle.tbsNormal:
                        picActualBar.BackgroundImage = Properties.Resources.green;
                        break;
                    case TrackBarStyle.tbsFaster:
                    case TrackBarStyle.tbsTooFast:
                        picActualBar.BackgroundImage = Properties.Resources.yellow;
                        break;
                    case TrackBarStyle.tbsSlower:
                    case TrackBarStyle.tbsTooSlow:
                        picActualBar.BackgroundImage = Properties.Resources.red;
                        break;
                    case TrackBarStyle.tbsNone:
                        picActualBar.BackgroundImage = Properties.Resources.gray;
                        break;
                }
            }
        }

        [Browsable(true)]
        [Category("Data")]
        [DefaultValue(0.00)]
        [Description("实际产量")]
        public double ActualOutputQuantity
        {
            get { return actualOutputQuantity; }
            set
            {
                actualOutputQuantity = value;

                double width = Convert.ToDouble(picPlanBar.Width) / maximumValue * value;
                picActualBar.Width = Convert.ToInt32(width);
            }
        }

        [Browsable(true)]
        [Category("Data")]
        [DefaultValue(0.00)]
        [Description("KPI/BTS 指标值")]
        public double KPIValue
        {
            get { return kpiValue; }
            set
            {
                kpiValue = value;

                lblKPI.Text = string.Format("{0} {1}%", kpiName, kpiValue);
                int left = picVernier.Left - (lblKPI.Width - picVernier.Width) / 2;
                if (left + lblKPI.Width > Width)
                    lblKPI.Left = Width - lblKPI.Width;
                else
                    lblKPI.Left = left;
            }
        }

        [Browsable(true)]
        [Category("Data")]
        [DefaultValue("BTS")]
        [Description("指标名称")]
        public string KPIName
        {
            get { return kpiName; }
            set
            {
                kpiName = value;
            }
        }

        [Browsable(true)]
        [Category("Data")]
        [DefaultValue(0.00)]
        [Description("应完成百分比")]
        public double KPIProgress
        {
            get { return kpiProgress; }
            set
            {
                kpiProgress = value;

                double locateX = Convert.ToDouble(picPlanBar.Width) / 100 * kpiProgress;
                picVernier.Left = picPlanBar.Left + Convert.ToInt32(locateX) - picVernier.Width / 2;
                int left = picVernier.Left - (lblKPI.Width - picVernier.Width) / 2;
                if (left + lblKPI.Width > Width)
                    lblKPI.Left = Width - lblKPI.Width;
                else
                    lblKPI.Left = left;
            }
        }

        private void ucKPIBTS_SizeChanged(object sender, EventArgs e)
        {
            KPIValue = kpiValue;
            ActualOutputQuantity = actualOutputQuantity;
        }
    }

    public enum TrackBarStyle
    {
        [Description("正常")]
        tbsNormal=0,
        [Description("偏快")]
        tbsFaster,
        [Description("太快")]
        tbsTooFast,
        [Description("偏慢")]
        tbsSlower,
        [Description("太慢")]
        tbsTooSlow,
        [Description("未定义")]
        tbsNone,
    };
}

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
        private TrackBarStyle trackBar = TrackBarStyle.Gray;
        private bool showVernier = false;
        private double actualOutputQuantity = 0;
        private double quota = 0;
        private string quotaName = "BTS";

        public ucKPIBTS()
        {
            InitializeComponent();

            TrackBarStyle = TrackBarStyle.Gray;
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
        [DefaultValue(TrackBarStyle.Gray)]
        [Description("进度条颜色")]
        public TrackBarStyle TrackBarStyle
        {
            get { return trackBar; }
            set
            {
                trackBar = value;

                switch (trackBar)
                {
                    case TrackBarStyle.Gray:
                        picActualBar.BackgroundImage = Properties.Resources.gray;
                        break;
                    case TrackBarStyle.Green:
                        picActualBar.BackgroundImage = Properties.Resources.green;
                        break;
                    case TrackBarStyle.Yellow:
                        picActualBar.BackgroundImage = Properties.Resources.yellow;
                        break;
                    case TrackBarStyle.Red:
                        picActualBar.BackgroundImage = Properties.Resources.red;
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
        public double Quota
        {
            get { return quota; }
            set
            {
                quota = value;

                double locateX = Convert.ToDouble(picPlanBar.Width) / 100 * Quota;
                picVernier.Left = picPlanBar.Left + Convert.ToInt32(locateX) - picVernier.Width / 2;

                lblQuato.Text = string.Format("{0} {1}%", quotaName, quota);
                int left = picVernier.Left - (lblQuato.Width - picVernier.Width) / 2;
                if (left + lblQuato.Width > Width)
                    lblQuato.Left = Width - lblQuato.Width;
                else
                    lblQuato.Left = left;
            }
        }

        [Browsable(true)]
        [Category("Data")]
        [DefaultValue("BTS")]
        [Description("指标名称")]
        public string QuotaName
        {
            get { return quotaName; }
            set
            {
                quotaName = value;
            }
        }

        private void ucKPIBTS_SizeChanged(object sender, EventArgs e)
        {
            Quota = quota;
            ActualOutputQuantity = actualOutputQuantity;
        }
    }

    public enum TrackBarStyle
    {
        Gray,
        Green,
        Yellow,
        Red,
    };
}

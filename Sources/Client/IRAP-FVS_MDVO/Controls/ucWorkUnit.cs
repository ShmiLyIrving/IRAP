using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using IRAP.Entity.MDM;

namespace IRAP_FVS_MDVO
{
    public partial class ucWorkUnit : DevExpress.XtraEditors.XtraUserControl
    {
        private WIPStationProductionStatus station = null;

        public ucWorkUnit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 鼠标点击事件
        /// </summary>
        public event EventHandler MouseLeftClick;

        public WIPStationProductionStatus Station
        {
            get { return station; }
            set
            {
                station = value;

                // 设置当前设备名称
                lblEquipmentName.Text = station.T107Name;

                // 设置当前设备生产状态
                if (station.PWONo_InExecution == "")
                {
                    lblWorkingStatus.Text =
                        station.T102LeafID_InProduction == 0 ?
                        "未生产" :
                        "待生产";
                }
                else
                    lblWorkingStatus.Text = "正在生产";

                // 设置当前设备的图片
                if (station.T107Picture == null)
                    picEquipment.Image = Properties.Resources.device_manager;
                else
                    picEquipment.Image = station.T107Picture;

                if (station.PWONo_InExecution != "")
                {
                    lblMemo.Text =
                        string.Format(
                            "在产产品：\n{0}\n工单号：\n{1}\n待加工容器编号：{2}\n" +
                            "已加工容器编号：{3}\n完工后存放库位：{4}",
                            station.T102Code_InProduction,
                            station.PWONo_InExecution,
                            station.ContainerNo,
                            station.ContainerNo_Output,
                            station.DstStoreLocCode);
                }
                else
                {
                    lblMemo.Text =
                        string.Format(
                            "待生产产品：\n{0}\n待执行工单号：\n{1}\n" +
                            "容器编号：{2}\n滞在库位：{3}",
                            station.T102Code_InProduction,
                            station.NextPWOToExecute,
                            station.NextContainerNo,
                            station.AtStoreLocCode);
                }
            }
        }

        private void picEquipment_Click(object sender, EventArgs e)
        {
            if (MouseLeftClick != null)
                MouseLeftClick(this, e);
        }

        private void lblMemo_Click(object sender, EventArgs e)
        {
            if (MouseLeftClick != null)
                MouseLeftClick(this, e);
        }
    }
}

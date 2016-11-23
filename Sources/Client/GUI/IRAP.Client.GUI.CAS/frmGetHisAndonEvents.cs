using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmGetHisAndonEvents : IRAP.Client.GUI.CAS.frmCustomAndonForm
    {
        public frmGetHisAndonEvents()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 起始时间
        /// </summary>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }
    }
}

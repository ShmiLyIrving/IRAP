using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRAP_UFMPS.UserControls
{
    public partial class UCWatchTypeFlagFile : UserControl
    {
        public UCWatchTypeFlagFile()
        {
            InitializeComponent();
        }

        private void rbFlagFileGetDataFileType_0_CheckedChanged(object sender, EventArgs e)
        {
            edtFlagFileDataFileExt.Enabled = rbFlagFileGetDataFileType_0.Checked;
        }

        private void edtFlagFileDataFileFolder_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            edtFlagFileDataFileFolder.Text = Comm.Tools.SelectFolder(
                "请选择数据文件所在文件夹：",
                edtFlagFileDataFileFolder.Text);
        }
    }
}

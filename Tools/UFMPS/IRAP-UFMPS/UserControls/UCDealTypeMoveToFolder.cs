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
    public partial class UCDealTypeMoveToFolder : UserControl
    {
        public UCDealTypeMoveToFolder()
        {
            InitializeComponent();
        }

        private void edtCopyDestinationFolder_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            edtCopyDestinationFolder.Text = Comm.Tools.SelectFolder(
                "请选择目标文件夹：",
                edtCopyDestinationFolder.Text);
        }
    }
}

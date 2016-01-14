using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace IRAP_UFMPS.UserControls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class UCWatchTypeNormal : UserControl
    {
        public UCWatchTypeNormal()
        {
            InitializeComponent();
        }

        private void chkNormalKeepUndealFile_CheckedChanged(object sender, EventArgs e)
        {
            edtNormalKeepUndealFileFolder.Enabled = chkNormalKeepUndealFile.Checked;
        }

        private void edtNormalKeepUndealFileFolder_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            edtNormalKeepUndealFileFolder.Text = Comm.Tools.SelectFolder(
                "请选择保存不处理文件的文件夹：",
                edtNormalKeepUndealFileFolder.Text);
        }
    }
}

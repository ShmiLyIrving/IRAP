using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.Global;

namespace IRAP.Client.GUI.MESPDC.Dialogs
{
    public partial class frmShowPDFFileContent : IRAP.Client.Global.frmCustomBase
    {
        public frmShowPDFFileContent()
        {
            InitializeComponent();

            Text = "检验报告";

            axAcroPDF1.BeginInit();
        }

        public string Base64String
        {
            set
            {
                if (value != "")
                    try
                    {
                        string tempFileName =
                            string.Format(
                                "{0}{1}.pdf",
                                IRAPConst.Instance.SystemTemplateDirectory,
                                Guid.NewGuid().ToString());
                        byte[] buffer = Convert.FromBase64String(value);
                        FileStream fs = new FileStream(tempFileName, FileMode.Create);
                        fs.Write(buffer, 0, buffer.Length);
                        fs.Flush();
                        fs.Close();

                        axAcroPDF1.LoadFile(tempFileName);
                        File.Delete(tempFileName);
                    }
                    catch (Exception error)
                    {
                        XtraMessageBox.Show(error.Message);
                    }
            }
        }
    }
}

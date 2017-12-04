using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;

namespace IRAP.Client.Global.GUI
{
    public partial class xucIRAPListView : DevExpress.XtraEditors.XtraUserControl
    {
        private int maxLineNumber = 200;

        public xucIRAPListView()
        {
            InitializeComponent();
        }

        [Browsable(true), Category("Appearence"), Description("标题")]
        public string Caption
        {
            get { return gpcLogs.Text; }
            set { gpcLogs.Text = value; }
        }

        [Browsable(true)]
        [Category("Data")]
        [Description("最大显示行数")]
        [DefaultValue(200)]
        public int MaxLineNumber
        {
            get { return maxLineNumber; }
            set { maxLineNumber = value; }
        }

        public void WriteLog(int errCode, string errText, DateTime dateTime)
        {
            // 根据最大行数，清除多余日志行
            if (tlLogs.Nodes.Count > maxLineNumber)
            {
                for (int i = tlLogs.Nodes.Count - 1; i >= maxLineNumber; i--)
                    tlLogs.Nodes.Remove(tlLogs.Nodes[i]);
            }

            string[] multiLine = errText.Split('\n');
            for (int i = multiLine.Length - 1; i >= 0; i--)
            {
                TreeListNode newNode = tlLogs.AppendNode(
                    new object[]
                    {
                        dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        errCode,
                        multiLine[i],
                    },
                    null);
                tlLogs.SetNodeIndex(newNode, 0);
                tlLogs.FocusedNode = newNode;
            }

            tlLogs.BestFitColumns();

            if (errCode != 0)
            {
                if (ConfigurationManager.AppSettings["SoundAlert"] != null &&
                    ConfigurationManager.AppSettings["SoundAlert"].ToUpper() == "TRUE")
                    IRAP.Global.Tools.Play(IRAP.Client.Global.Resources.Properties.Resources.ALARM9);
            }
        }

        private void tlLogs_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e != null)
            {
                if (e.Node.GetValue(tclmnErrCode.AbsoluteIndex).ToString() == "0")
                {
                    e.Appearance.ForeColor = Color.Blue;
                }
                else
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                e.Appearance.Options.UseForeColor = true;
            }
        }
    }
}

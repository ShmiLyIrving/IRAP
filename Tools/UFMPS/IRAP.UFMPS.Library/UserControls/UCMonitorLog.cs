using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;

namespace IRAP.UFMPS.Library.UserControls
{
    public partial class UCMonitorLog : UserControl
    {
        private TTask _task = null;
        public TTask Task
        {
            get { return _task; }
            set { _task = value; }
        }

        public UCMonitorLog()
        {
            InitializeComponent();
        }

        public void OnTaskLogEvent(object sender, string monitorMSG)
        {
            if (sender == null)
            {
                WriteLog(monitorMSG);
            }
            else if (sender is TreeListNode)
            {
                WriteLog(monitorMSG, (TreeListNode)sender);
            }
        }

        public TreeListNode WriteLog(string monitorMSG, TreeListNode parent = null)
        {
            TreeListNode newNode = tlLog.AppendNode(
                new object[]
                {
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    monitorMSG
                },
                parent);
            tlLog.FocusedNode = tlLog.Nodes[tlLog.Nodes.Count - 1];

            foreach (TreeListColumn column in tlLog.Columns)
            {
                column.BestFit();
            }

            Application.DoEvents();

            return newNode;
        }
    }
}

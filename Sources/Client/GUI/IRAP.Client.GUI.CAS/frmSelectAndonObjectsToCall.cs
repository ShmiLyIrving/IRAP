using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using IRAP.Entity.MDM;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmSelectAndonObjectsToCall : IRAP.Client.Global.frmCustomBase
    {
        public frmSelectAndonObjectsToCall()
        {
            InitializeComponent();
        }

        public frmSelectAndonObjectsToCall(
            AndonEventType andonEventTypeItem,
            string opNode,
            ProductionLineForStationBound pLine) : this()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS.UserControls
{
    public partial class ucDeviceFailureModes : DevExpress.XtraEditors.XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string t133Code = "";

        public ucDeviceFailureModes()
        {
            InitializeComponent();
        }

        public string T133Code
        {
            get
            {
                if (cboEquipmentList.SelectedItem == null)
                    return "";
                else
                {
                    return (cboEquipmentList.SelectedItem as AndonCallObject).Code;
                }
            }
            set
            {
                t133Code = value;

                if (t133Code != "")
                {
                    for (int i = 0; i < cboEquipmentList.Properties.Items.Count; i++)
                    {
                        AndonCallObject device = cboEquipmentList.Properties.Items[i] as AndonCallObject;
                        if (device.Code == t133Code)
                        {
                            cboEquipmentList.SelectedIndex = i;
                            cboEquipmentList.Enabled = false;

                            break;
                        }
                    }
                }
                else
                {
                    cboEquipmentList.Enabled = true;
                }
            }
        }

        public int FailureModeLeafID
        {
            get
            {
                int idx = grdvAndonCallObjects.GetFocusedDataSourceRowIndex();

                if (idx < 0)
                    return 0;
                else
                {
                    return (grdAndonCallObjects.DataSource as List<AndonCallObject>)[idx].LeafID;
                }
            }
        }

        private void GetDeviceList()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            int errCode = 0;
            string errText = "";
            List<AndonCallObject> devices = new List<AndonCallObject>();

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IRAPMDMClient.Instance.ufn_GetList_AndonCallObjects(
                    IRAPUser.Instance.CommunityID,
                    1325156,
                    0,
                    0,
                    IRAPUser.Instance.SysLogID,
                    ref devices,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    foreach (AndonCallObject device in devices)
                        cboEquipmentList.Properties.Items.Add(device);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void ucDeviceFailureModes_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                GetDeviceList();
        }

        private void cboEquipmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEquipmentList.SelectedItem != null)
            {
                string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        className,
                        MethodBase.GetCurrentMethod().Name);

                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    AndonCallObject selectedEquipment =
                        cboEquipmentList.SelectedItem as AndonCallObject;

                    t133Code = selectedEquipment.Code;

                    int errCode = 0;
                    string errText = "";
                    List<AndonCallObject> failureModeList =
                        new List<AndonCallObject>();

                    IRAPMDMClient.Instance.ufn_GetList_AndonCallObjects(
                        IRAPUser.Instance.CommunityID,
                        1325156,
                        0,
                        selectedEquipment.LeafID,
                        IRAPUser.Instance.SysLogID,
                        ref failureModeList,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                    if (errCode != 0)
                    {
                        IRAPMessageBox.Instance.Show(
                            string.Format("({0}){1}", errCode, errText),
                            this.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        grdAndonCallObjects.DataSource = null;
                        return;
                    }

                    grdAndonCallObjects.DataSource = failureModeList;
                    for (int i = 0; i < grdvAndonCallObjects.Columns.Count; i++)
                    {
                        grdvAndonCallObjects.Columns[i].BestFit();
                    }
                    grdvAndonCallObjects.OptionsView.RowAutoHeight = true;
                    grdvAndonCallObjects.LayoutChanged();
                }
                catch (Exception error)
                {
                    grdAndonCallObjects.DataSource = null;
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    IRAPMessageBox.Instance.Show(
                        error.Message,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }

        }
    }
}

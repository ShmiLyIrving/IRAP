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
using IRAP.Entities.MDM;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS.UserControls
{
    public partial class ucFailureModes : DevExpress.XtraEditors.XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private int t179LeafID = 0;
        private List<AndonCallObject> failureModeList = new List<AndonCallObject>();

        public ucFailureModes()
        {
            InitializeComponent();
        }

        public int T179LeafID
        {
            get { return t179LeafID; }
            set
            {
                if (t179LeafID != value)
                {
                    t179LeafID = value;
                    failureModeList.Clear();
                    if (value == 0)
                        return;
                    else
                        GetAndonCallObjects(t179LeafID);
                }
            }
        }

        /// <summary>
        /// 当前选择的失效模式叶标识
        /// </summary>
        public int FailureModeLeafID
        {
            get
            {
                int idx = grdvAndonCallObjects.GetFocusedDataSourceRowIndex();
                if (idx < 0)
                    return 0;
                else
                {
                    return failureModeList[idx].LeafID;
                }
            }
        }

        private void GetAndonCallObjects(int t179LeafID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                IRAPMDMClient.Instance.ufn_GetList_AndonCallObjects(
                    IRAPUser.Instance.CommunityID,
                    t179LeafID,
                    0,
                    0,
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

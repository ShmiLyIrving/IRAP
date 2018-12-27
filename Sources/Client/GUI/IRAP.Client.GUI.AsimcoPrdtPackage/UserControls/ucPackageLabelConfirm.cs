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
using DevExpress.XtraEditors.ButtonsPanelControl;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.Asimco;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.AsimcoPrdtPackage.UserControls
{
    public partial class ucPackageLabelConfirm : XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public ucPackageLabelConfirm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取当前待确认的包装标签清单
        /// </summary>
        /// <returns></returns>
        private List<ConfirmPackageLabel> GetConfirmLabels()
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<WaitConfirmPrint> datas = new List<WaitConfirmPrint>();

                AsimcoPackageClient.Instance.ufn_GetList_WaitConfirmPrint(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode == 0)
                {
                    List<ConfirmPackageLabel> rlt = new List<ConfirmPackageLabel>();
                    foreach (WaitConfirmPrint data in datas)
                    {
                        rlt.Add(ConfirmPackageLabel.Mapper<ConfirmPackageLabel, WaitConfirmPrint>(data));
                    }
                    return rlt;
                }
                else
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(errText);
                    return new List<ConfirmPackageLabel>();
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void RefreshPackageLabels()
        {
            grdPackageLabels.DataSource = GetConfirmLabels();
            grdvPackageLabels.BestFitColumns();
        }

        /// <summary>
        /// 获取当前选择的包装标签个数
        /// </summary>
        /// <returns></returns>
        private int GetSelectedPkgLabelCnt()
        {
            if (grdPackageLabels.DataSource == null)
            {
                return 0;
            }

            List<ConfirmPackageLabel> items =
                grdPackageLabels.DataSource as List<ConfirmPackageLabel>;
            int rlt = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Choice)
                {
                    rlt++;
                }
            }
            return rlt;
        }

        private string GeneratParamXML()
        {
            if (grdPackageLabels.DataSource== null)
            {
                return "<Param></Param>";
            }

            List<ConfirmPackageLabel> items =
                grdPackageLabels.DataSource as List<ConfirmPackageLabel>;
            string rlt = "";
            foreach(ConfirmPackageLabel item in items)
            {
                if (item.Choice)
                {
                    if (rlt != "")
                    {
                        rlt += "\n";
                    }
                    else
                    {
                        rlt +=
                            $"<Row Ordinal=\"{item.Ordinal}\" " +
                            $"FactID=\"{item.FactID}\" " +
                            $"TransactNo=\"{item.TransactNo}\" />";
                    }
                }
            }
            return $"<Param>{rlt}</Param>";
        }

        private void ucPackageLabelConfirm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                RefreshPackageLabels();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (GetSelectedPkgLabelCnt() <= 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "还未勾选包装标签，请至少勾选一个包装标签！");
                return;
            }

            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                AsimcoPackageClient.Instance.usp_SaveFact_PrintConfirm(
                    IRAPUser.Instance.CommunityID,
                    GeneratParamXML(),
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode != 0)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(errText);
                }

                RefreshPackageLabels();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnRequestReprint_Click(object sender, EventArgs e)
        {
            if (GetSelectedPkgLabelCnt() <= 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "还未勾选包装标签，请至少勾选一个包装标签！");
                return;
            }
            string strProcedureName =
               $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                AsimcoPackageClient.Instance.usp_RequestReprint(
                    IRAPUser.Instance.CommunityID,
                    GeneratParamXML(),
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode != 0)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(errText);
                }

                RefreshPackageLabels();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void gpcPackageSOs_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            GroupBoxButton button = e.Button as GroupBoxButton;
            switch (button.Caption)
            {
                case "刷新":
                    RefreshPackageLabels();

                    break;
                default:
                    break;
            }
        }
    }

    internal class ConfirmPackageLabel : WaitConfirmPrint
    {
        public bool Choice { get; set; }

        public static ConfirmPackageLabel Mapper<ConfirmPackageLabe, WaitConfirmPrint>(WaitConfirmPrint s)
        {
            ConfirmPackageLabel d = Activator.CreateInstance<ConfirmPackageLabel>();

            Type types = s.GetType();
            Type typed = typeof(ConfirmPackageLabel);
            foreach (PropertyInfo spi in types.GetProperties())
            {
                foreach (PropertyInfo dpi in typed.GetProperties())
                {
                    if (dpi.Name == spi.Name)
                    {
                        dpi.SetValue(d, spi.GetValue(s, null), null);
                        break;
                    }
                }
            }

            return d;
        }
    }
}

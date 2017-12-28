using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.MDM;
using IRAP.Entity.MES;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESRPC
{
    public partial class frmReworkUnloadingSheetItem_SymbolSelect : IRAP.Client.Global.frmCustomBase
    {
        private CurrentLoadingSheetItem loadingSheetItem = new CurrentLoadingSheetItem();
        private WorkUnit workUnit = new WorkUnit();
        private int t102LeafID = 0;
        private List<ReworkPWOUnloadingSheetItem> unloadingSheetItems = new List<ReworkPWOUnloadingSheetItem>();

        public frmReworkUnloadingSheetItem_SymbolSelect()
        {
            InitializeComponent();
        }

        public List<ReworkPWOUnloadingSheetItem> UnloadingSheetItems
        {
            get { return unloadingSheetItems; }
        }

        public frmReworkUnloadingSheetItem_SymbolSelect(
            CurrentLoadingSheetItem loadingSheet,
            WorkUnit workUnit,
            int t102LeafID)
            : this()
        {
            this.loadingSheetItem = loadingSheet;
            this.workUnit = workUnit;
            this.t102LeafID = t102LeafID;

            edtT107CodeAndName.Text = string.Format(
                "[{0}]{1}",
                workUnit.T107Code,
                workUnit.T107Name);
            edtT133CodeAndName.Text = string.Format(
                "{0}{1}",
                workUnit.T133Code == "" ? "" :
                    string.Format("[{0}]", workUnit.T133Code),
                workUnit.T133Name);
            edtSlotCode.Text = loadingSheet.SlotCode;
            edtMaterialCode.Text = loadingSheet.MaterialCode;
            edtMaterialName.Text = loadingSheet.MaterialName;

            if (loadingSheet.ComponentLocList == "")
            {
                chklstSymbols.Enabled = false;
            }
            else
            {
                string[] symbols = loadingSheet.ComponentLocList.Split(
                    new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < symbols.Length; i++)
                {
                    chklstSymbols.Items.Add(symbols[i]);
                }
                if (chklstSymbols.Items.Count == 1)
                {
                    chklstSymbols.Items[0].CheckState = CheckState.Checked;
                }

                edtUnloadQuantity.Value = 1;
                edtUnloadQuantity.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strProcedureName = string.Format("{0}.{1}",
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name);

            if (loadingSheetItem.ComponentLocList == "")
            {
                if (edtUnloadQuantity.Value <= 0)
                {
                    MessageBox.Show("请输入“卸料数量”！",
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                unloadingSheetItems.Add(new ReworkPWOUnloadingSheetItem()
                {
                    T107LeafID = workUnit.T107LeafID,
                    T107Code = workUnit.T107Code,
                    T107Name = workUnit.T107Name,
                    T133LeafID = workUnit.T133LeafID,
                    T133Code = workUnit.T133Code,
                    T133Name = workUnit.T133Name,
                    T108LeafID = loadingSheetItem.T108LeafID,
                    SlotCode = loadingSheetItem.SlotCode,
                    T110LeafID = 0,
                    Symbol = "",
                    T101LeafID = loadingSheetItem.T101LeafID,
                    T102LeafID = loadingSheetItem.T102LeafID,
                    MaterialCode = loadingSheetItem.MaterialCode,
                    MaterialDesc = loadingSheetItem.MaterialName,
                    UnloadQty = decimal.ToInt32(edtUnloadQuantity.Value),
                    QtyScale = loadingSheetItem.Scale,
                    UnitOfMeasure = loadingSheetItem.UnitOfMeasure,
                    ScrapOnUnloading = chkScrapOnUnloading.Checked,
                });

                DialogResult = DialogResult.OK;
            }
            else
            {
                if (chklstSymbols.CheckedItemsCount <= 0)
                {
                    MessageBox.Show("请至少选择一个“部件位置编号”！",
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                unloadingSheetItems.Clear();
                for (int i = 0; i < chklstSymbols.CheckedItemsCount; i++)
                {
                    int t110LeafID = 0;
                    string symbol = chklstSymbols.CheckedItems[i].ToString();

                    #region 根据部件编号获取部件编号的叶标识
                    try
                    {
                        int errCode = 0;
                        string errText = "";

                        IRAPMDMClient.Instance.ufn_GetT110LeafID(
                            IRAPUser.Instance.CommunityID,
                            t102LeafID,
                            symbol,
                            ref t110LeafID,
                            out errCode,
                            out errText);
                        if (errCode != 0)
                        {
                            errText = string.Format("({0}){1}", errCode, errText);
                            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                            WriteLog.Instance.Write(errText, strProcedureName);
                            WriteLog.Instance.WriteEndSplitter(strProcedureName);
                            MessageBox.Show(errText,
                                "系统信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }

                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                        MessageBox.Show(error.Message,
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    #endregion

                    unloadingSheetItems.Add(new ReworkPWOUnloadingSheetItem()
                    {
                        T107LeafID = workUnit.T107LeafID,
                        T107Code = workUnit.T107Code,
                        T107Name = workUnit.T107Name,
                        T133LeafID = workUnit.T133LeafID,
                        T133Code = workUnit.T133Code,
                        T133Name = workUnit.T133Name,
                        T108LeafID = loadingSheetItem.T108LeafID,
                        SlotCode = loadingSheetItem.SlotCode,
                        T110LeafID = t110LeafID,
                        Symbol = symbol,
                        T101LeafID = loadingSheetItem.T101LeafID,
                        T102LeafID = loadingSheetItem.T102LeafID,
                        MaterialCode = loadingSheetItem.MaterialCode,
                        MaterialDesc = loadingSheetItem.MaterialName,
                        UnloadQty = decimal.ToInt32(edtUnloadQuantity.Value),
                        QtyScale = loadingSheetItem.Scale,
                        UnitOfMeasure = loadingSheetItem.UnitOfMeasure,
                        ScrapOnUnloading = chkScrapOnUnloading.Checked,
                    });
                }

                DialogResult = DialogResult.OK;
            }
        }
    }
}

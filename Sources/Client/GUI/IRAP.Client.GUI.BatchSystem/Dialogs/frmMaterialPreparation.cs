using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

using IRAP.Global;
using IRAP.Entities.MDM;
using IRAP.Entities.MES;
using IRAP.Client.Global.Enums;

using IRAP.Client.GUI.BatchSystem.Tools;
using IRAP.Client.GUI.BatchSystem.Entities;
using IRAP.Client.GUI.BatchSystem.Dialogs;

namespace IRAP.Client.GUI.BatchSystem.Dialogs
{
    public partial class frmMaterialPreparation : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        #region 由调用者传递进来的参数
        private WIPStation stationInfo;
        #endregion

        private TMaterialPreparationInfos mps = new TMaterialPreparationInfos();
        private string fileMaterialPreparation;

        public frmMaterialPreparation()
        {
            InitializeComponent();

            string directory = $"{AppDomain.CurrentDomain.BaseDirectory}Temp\\";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            fileMaterialPreparation = $"{directory}MaterialPreparation.mp";
        }

        public frmMaterialPreparation(WIPStation stationInfo) : this()
        {
            this.stationInfo = stationInfo;
        }

        private void SaveToFile()
        {
            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";

            try
            {
                FileStream fs = new FileStream(fileMaterialPreparation, FileMode.Create);
                byte[] data = Encoding.UTF8.GetBytes(mps.ToJSON());
                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
        }

        private TMaterialPreparationInfos LoadFromFile()
        {
            string buffer = "";

            if (File.Exists(fileMaterialPreparation))
            {
                StreamReader sr =
                    new StreamReader(
                        fileMaterialPreparation,
                        Encoding.UTF8);

                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    buffer += temp;
                }

                sr.Close();
            }

            if (buffer != "")
            {
                return JSONHelper.GetObjectFromJSON<TMaterialPreparationInfos>(buffer);
            }
            else
            {
                return new TMaterialPreparationInfos();
            }
        }

        private void frmMaterialPreparation_Shown(object sender, EventArgs e)
        {
            ilstMaterialPreparation.Items.Clear();

            mps = LoadFromFile();
            foreach (TMaterialPreparationInfo item in mps.Items)
            {
                ilstMaterialPreparation.Items.Add(item, 0);
            }
        }

        private void ilstMaterialPreparation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageListBoxItem item = ilstMaterialPreparation.SelectedItem as ImageListBoxItem;

            if (item != null)
            {
                TMaterialPreparationInfo mp = item.Value as TMaterialPreparationInfo;

                if (mp != null)
                {
                    grdPWOs.DataSource = mp.PWOs;
                }
                else
                {
                    grdPWOs.DataSource = null;
                }
            }
            else
            {
                grdPWOs.DataSource = null;
            }
            grdvPWOs.BestFitColumns();

            Refresh();
        }

        private void frmMaterialPreparation_Paint(object sender, PaintEventArgs e)
        {
            if (ilstMaterialPreparation.SelectedItem == null)
            {
                btnMPRemove.Enabled = false;
            }
            else
            {
                btnMPRemove.Enabled = true;
            }

            if (grdPWOs.DataSource == null)
            {
                btnPWONew.Enabled = false;
                btnPWOModify.Enabled = false;
                btnPWORemove.Enabled = false;
            }
            else
            {
                btnPWONew.Enabled = true;
                if (grdvPWOs.GetFocusedDataSourceRowIndex() >= 0)
                {
                    btnPWOModify.Enabled = true;
                    btnPWORemove.Enabled = true;
                }
                else
                {
                    btnPWOModify.Enabled = false;
                    btnPWORemove.Enabled = false;
                }
            }
        }

        private void btnMPNew_Click(object sender, EventArgs e)
        {
            TMaterialPreparationInfo mp = new TMaterialPreparationInfo();
            mp.PreparateTime = DateTime.Now;
            mps.Items.Add(mp);

            ilstMaterialPreparation.Items.Add(mp, 0);
            ilstMaterialPreparation.SelectedIndex =
                ilstMaterialPreparation.Items.Count - 1;
        }

        private void btnMPRemove_Click(object sender, EventArgs e)
        {
            if (ilstMaterialPreparation.SelectedIndex >= 0)
            {
                TMaterialPreparationInfo mp =
                    mps.Items[ilstMaterialPreparation.SelectedIndex];
                if (
                    XtraMessageBox.Show(
                        "是否要删除当前选择的配料信息？",
                        "系统信息",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    mps.Items.Remove(mp);
                    ilstMaterialPreparation.Items.Remove(ilstMaterialPreparation.SelectedItem);

                    SaveToFile();

                    Refresh();
                }
            }
        }

        private void btnPWONew_Click(object sender, EventArgs e)
        {
            List<EntityBatchPWO> pwos =
                grdPWOs.DataSource as List<EntityBatchPWO>;
            EntityBatchPWO newPWO = new EntityBatchPWO();

            using (frmPWOInProductionEditor formEditor =
                new frmPWOInProductionEditor(
                    EditStatus.New,
                    stationInfo.T134LeafID,
                    stationInfo.T216LeafID,
                    0,
                    pwos,
                    ref newPWO))
            {
                if (formEditor.ShowDialog() == DialogResult.OK)
                {
                    pwos.Add(newPWO);
                    grdvPWOs.BestFitColumns();

                    SaveToFile();

                    Refresh();
                }
            }
        }

        private void btnPWOModify_Click(object sender, EventArgs e)
        {
            List<EntityBatchPWO> pwos =
                grdPWOs.DataSource as List<EntityBatchPWO>;
            int idx = grdvPWOs.GetFocusedDataSourceRowIndex();

            if (idx >= 0 && idx < pwos.Count)
            {
                EntityBatchPWO pwo = pwos[idx];

                using (frmPWOInProductionEditor formEditor =
                    new frmPWOInProductionEditor(
                        EditStatus.Edit,
                        stationInfo.T134LeafID,
                        stationInfo.T216LeafID,
                        0,
                        pwos,
                        ref pwo))
                {
                    if (formEditor.ShowDialog() == DialogResult.OK)
                    {
                        grdvPWOs.UpdateCurrentRow();
                        grdvPWOs.BestFitColumns();

                        SaveToFile();

                        Refresh();
                    }
                }
            }
        }

        private void btnPWORemove_Click(object sender, EventArgs e)
        {
            List<EntityBatchPWO> pwos =
                grdPWOs.DataSource as List<EntityBatchPWO>;
            int idx = grdvPWOs.GetFocusedDataSourceRowIndex();

            if (idx >= 0 && idx < pwos.Count)
            {
                if (
                    XtraMessageBox.Show(
                        string.Format(
                            "是否要删除工单[{0}]的信息？",
                            pwos[idx].PWONo),
                        "系统信息",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    pwos.Remove(pwos[idx]);
                    grdvPWOs.UpdateCurrentRow();
                    grdvPWOs.BestFitColumns();

                    SaveToFile();

                    Refresh();
                }
            }
        }
    }
}

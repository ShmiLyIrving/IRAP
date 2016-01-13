using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

using IRAP.Global;
using IRAP.UFMPS.Library;

namespace IRAP_UFMPS
{
    public partial class frmTaskEditor : DevExpress.XtraEditors.XtraForm
    {
        private TTask task = null;
        public TTask Task
        {
            get { return task; }
            set 
            { 
                task = value;
                InitialComponents(task);
            }
        }

        public frmTaskEditor()
        {
            InitializeComponent();

            #region 初始化监控方式列表和文件处理方式列表
            ImageComboBoxItem item = null;

            foreach (var value in Enum.GetValues(typeof(TDocumentProcessType)))
            {
                item = new ImageComboBoxItem(string.Format("{0} - {1}",
                    (int)value,
                    EnumHelper.GetDescription((TDocumentProcessType)value)));
                item.Value = (int)value;
                cboFileDealType.Properties.Items.Add(item);
            }

            foreach (var value in Enum.GetValues(typeof(TWatchType)))
            {
                item = new ImageComboBoxItem(string.Format("{0} - {1}监控方式",
                    (int)value,
                    EnumHelper.GetDescription((TWatchType)value)));
                item.Value = (int)value;
                cboWatchType.Properties.Items.Add(item);
            }
            #endregion
        }

        private void InitialComponents(TTask task)
        {
            edtTaskName.Text = task.TaskName;
            cboWatchType.EditValue = (int)task.WatchType;
            edtWatchFolder.Text = task.WatchFolder;

            #region 普通监控方式
            ucWatchTypeNormal.edtNormalWatchFileExts.Text = task.NormalWatchFileExts;
            ucWatchTypeNormal.chkNormalKeepUndealFile.Checked = task.NormalKeepUndealFile;
            ucWatchTypeNormal.edtNormalKeepUndealFileFolder.Text = task.NormalKeepUndealFileFolder;
            #endregion

            #region 信号旗监控方式
            ucWatchTypeFlagFile.edtFlagFileName.Text = task.FlagFileName;
            if (task.FlagFileGetDataFileType == 0)
                ucWatchTypeFlagFile.rbFlagFileGetDataFileType_0.Checked = true;
            else
                ucWatchTypeFlagFile.rbFlagFileGetDataFileType_1.Checked = true;
            ucWatchTypeFlagFile.edtFlagFileDataFileExt.Text = task.FlagFileDataFileExt;
            ucWatchTypeFlagFile.edtFlagFileDataFileFolder.Text = task.FlagFileDataFileFolder;
            #endregion

            chkBackupFileFlag.Checked = task.BackupFileFlag;
            edtBackupFileFolder.Text = task.BackupFileFolder;
            cboFileDealType.EditValue = (int)task.FileDealType;

            #region 文件处理方式：FTP
            ucDealTypeFTP.edtFTPAdress.Text = task.Ftp_Address;
            ucDealTypeFTP.edtFTPPort.Text = task.Ftp_Port.ToString();
            ucDealTypeFTP.edtFTPUserID.Text = task.Ftp_UserID;
            ucDealTypeFTP.edtFTPUserPWD.Text = task.Ftp_UserPWD;
            #endregion

            #region 文件处理方式：移动到指定文件夹
            ucDealTypeMoveToFolder.edtCopyDestinationFolder.Text = task.Copy_DestFolder;
            #endregion

            #region 文件处理方式：调用存储过程
            ucDealTypeCallStoreProcedure.edtDBAddress.Text = task.DbServer;
            ucDealTypeCallStoreProcedure.edtDBUserID.Text = task.DbUserID;
            ucDealTypeCallStoreProcedure.edtDBUserPWD.Text = task.DbUserPWD;
            ucDealTypeCallStoreProcedure.edtDBName.Text = task.DbName;

            ucDealTypeCallStoreProcedure.edtImportTypeID.Text = task.Db_ImportTypeID.ToString();
            ucDealTypeCallStoreProcedure.edtNumFields.Text = task.Db_NumFields.ToString();
            ucDealTypeCallStoreProcedure.edtFirstRow.Text = task.Db_FirstRow.ToString();
            ucDealTypeCallStoreProcedure.edtFieldTerminator.Text = task.Db_FieldTerminator;
            ucDealTypeCallStoreProcedure.edtRowTerminator.Text = task.Db_RowTerminator;
            ucDealTypeCallStoreProcedure.edtFormatFileName.Text = task.Db_FormatFile;
            #endregion

            #region 文件处理方式：插入指定表中
            ucDealTypeInsertIntoTable.edtDBAddress.Text = task.DbServer;
            ucDealTypeInsertIntoTable.edtDBUserID.Text = task.DbUserID;
            ucDealTypeInsertIntoTable.edtDBUserPWD.Text = task.DbUserPWD;
            ucDealTypeInsertIntoTable.edtDBName.Text = task.DbName;
            ucDealTypeInsertIntoTable.edtTableName.Text = task.TbTableName;

            ucDealTypeInsertIntoTable.cboThreadStartMark.EditValue = (int)task.ThreadStartMark;

            ucDealTypeInsertIntoTable.edtSplitter.Text = task.TbTxtFileSplitter;
            ucDealTypeInsertIntoTable.edtNumOfTextFields.Text = task.TbNumOfTxtFields.ToString();
            ucDealTypeInsertIntoTable.edtDataStartLineNo.Text = task.TbDataFirstRow.ToString();
            ucDealTypeInsertIntoTable.chkSaveIncludeFileName.Checked = task.TbIncludeTxtFileName;
            #endregion
        }

        private void SetValue(TTask task)
        {
            task.TaskName = edtTaskName.Text.Trim();
            task.WatchType = (TWatchType)Convert.ToInt32(cboWatchType.EditValue.ToString());
            task.WatchFolder = edtWatchFolder.Text.Trim();

            task.NormalWatchFileExts = ucWatchTypeNormal.edtNormalWatchFileExts.Text.Trim();
            task.NormalKeepUndealFile = ucWatchTypeNormal.chkNormalKeepUndealFile.Checked;
            task.NormalKeepUndealFileFolder = ucWatchTypeNormal.edtNormalKeepUndealFileFolder.Text.Trim();

            task.FlagFileName = ucWatchTypeFlagFile.edtFlagFileName.Text.Trim();
            task.FlagFileGetDataFileType = ucWatchTypeFlagFile.rbFlagFileGetDataFileType_0.Checked ? 0 : 1;
            task.FlagFileDataFileExt = ucWatchTypeFlagFile.edtFlagFileDataFileExt.Text.Trim();
            task.FlagFileDataFileFolder = ucWatchTypeFlagFile.edtFlagFileDataFileFolder.Text.Trim();

            task.BackupFileFlag = chkBackupFileFlag.Checked;
            task.BackupFileFolder = edtBackupFileFolder.Text.Trim();
            task.FileDealType = (TDocumentProcessType)Convert.ToInt32(cboFileDealType.EditValue.ToString());

            task.Ftp_Address = ucDealTypeFTP.edtFTPAdress.Text.Trim();
            task.Ftp_Port = Convert.ToInt32(ucDealTypeFTP.edtFTPPort.Text.Trim());
            task.Ftp_UserID = ucDealTypeFTP.edtFTPUserID.Text.Trim();
            task.Ftp_UserPWD = ucDealTypeFTP.edtFTPUserPWD.Text.Trim();

            task.Copy_DestFolder = ucDealTypeMoveToFolder.edtCopyDestinationFolder.Text.Trim();

            if (task.FileDealType == TDocumentProcessType.CallStoreProcedure)
            {
                task.DbServer = ucDealTypeCallStoreProcedure.edtDBAddress.Text.Trim();
                task.DbUserID = ucDealTypeCallStoreProcedure.edtDBUserID.Text.Trim();
                task.DbUserPWD = ucDealTypeCallStoreProcedure.edtDBUserPWD.Text.Trim();
                task.DbName = ucDealTypeCallStoreProcedure.edtDBName.Text.Trim();
            }
            task.Db_ImportTypeID = Convert.ToInt32(ucDealTypeCallStoreProcedure.edtImportTypeID.Text.Trim());
            task.Db_NumFields = Convert.ToInt32(ucDealTypeCallStoreProcedure.edtNumFields.Text.Trim());
            task.Db_FirstRow = Convert.ToInt32(ucDealTypeCallStoreProcedure.edtFirstRow.Text.Trim());
            task.Db_FieldTerminator = ucDealTypeCallStoreProcedure.edtFieldTerminator.Text.Trim();
            task.Db_RowTerminator = ucDealTypeCallStoreProcedure.edtRowTerminator.Text.Trim();
            task.Db_FormatFile = ucDealTypeCallStoreProcedure.edtFormatFileName.Text.Trim();

            if (task.FileDealType == TDocumentProcessType.InsertIntoTableThread)
            {
                task.DbServer = ucDealTypeInsertIntoTable.edtDBAddress.Text.Trim();
                task.DbUserID = ucDealTypeInsertIntoTable.edtDBUserID.Text.Trim();
                task.DbUserPWD = ucDealTypeInsertIntoTable.edtDBUserPWD.Text.Trim();
                task.DbName = ucDealTypeInsertIntoTable.edtDBName.Text.Trim();
            }
            task.TbTableName = ucDealTypeInsertIntoTable.edtTableName.Text.Trim();
            task.TbTxtFileSplitter = ucDealTypeInsertIntoTable.edtSplitter.Text.Trim();
            task.TbNumOfTxtFields = Convert.ToInt32(ucDealTypeInsertIntoTable.edtNumOfTextFields.Text.Trim());
            task.TbDataFirstRow = Convert.ToInt32(ucDealTypeInsertIntoTable.edtDataStartLineNo.Text.Trim());
            task.TbIncludeTxtFileName = ucDealTypeInsertIntoTable.chkSaveIncludeFileName.Checked;

            task.ThreadStartMark = (TThreadStartMark)Convert.ToInt32(ucDealTypeInsertIntoTable.cboThreadStartMark.EditValue.ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cboWatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboWatchType.SelectedItem != null)
            {
                ImageComboBoxItem selectItem = cboWatchType.SelectedItem as ImageComboBoxItem;
                switch ((int)selectItem.Value)
                {
                    case 0:
                        pnlWatchTypeNormal.Visible = true;
                        pnlWatchTypeFlagFile.Visible = false;
                        break;
                    case 1:
                        pnlWatchTypeNormal.Visible = false;
                        pnlWatchTypeFlagFile.Visible = true;
                        break;
                    default:
                        pnlWatchTypeFlagFile.Visible = false;
                        pnlWatchTypeNormal.Visible = false;
                        break;
                }
            }
            else
            {
                pnlWatchTypeFlagFile.Visible = false;
                pnlWatchTypeNormal.Visible = false;
            }
        }

        private void cboFileDealType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFileDealType.SelectedItem != null)
            {
                ImageComboBoxItem selectItem = cboFileDealType.SelectedItem as ImageComboBoxItem;
                switch ((int)selectItem.Value)
                {
                    case 0:
                        pnlDealTypeFTP.Visible = true;
                        pnlDealTypeMoveToFolder.Visible = false;
                        pnlDealTypeCallStoreProcedure.Visible = false;
                        pnlDealTypeInsertIntoTable.Visible = false;
                        break;
                    case 1:
                        pnlDealTypeFTP.Visible = false;
                        pnlDealTypeMoveToFolder.Visible = true;
                        pnlDealTypeCallStoreProcedure.Visible = false;
                        pnlDealTypeInsertIntoTable.Visible = false;
                        break;
                    case 2:
                        pnlDealTypeFTP.Visible = false;
                        pnlDealTypeMoveToFolder.Visible = false;
                        pnlDealTypeCallStoreProcedure.Visible = true;
                        ucDealTypeCallStoreProcedure.tcDBSPParams.TabIndex = 0;
                        pnlDealTypeInsertIntoTable.Visible = false;
                        break;
                    case 3:
                        pnlDealTypeFTP.Visible = false;
                        pnlDealTypeMoveToFolder.Visible = true;
                        pnlDealTypeCallStoreProcedure.Visible = false;
                        pnlDealTypeInsertIntoTable.Visible = true;
                        ucDealTypeInsertIntoTable.tcDBParams.TabIndex = 0;
                        ucDealTypeInsertIntoTable.tpThreadControl.PageVisible = false;
                        break;
                    case 4:
                        pnlDealTypeFTP.Visible = false;
                        pnlDealTypeMoveToFolder.Visible = true;
                        pnlDealTypeCallStoreProcedure.Visible = false;
                        pnlDealTypeInsertIntoTable.Visible = true;
                        ucDealTypeInsertIntoTable.tcDBParams.TabIndex = 0;
                        ucDealTypeInsertIntoTable.tpThreadControl.PageVisible = true;
                        break;
                    default:
                        pnlDealTypeFTP.Visible = false;
                        pnlDealTypeMoveToFolder.Visible = false;
                        pnlDealTypeCallStoreProcedure.Visible = false;
                        pnlDealTypeInsertIntoTable.Visible = false;
                        break;
                }
            }
            else
            {
                pnlDealTypeFTP.Visible = false;
                pnlDealTypeMoveToFolder.Visible = false;
                pnlDealTypeCallStoreProcedure.Visible = false;
                pnlDealTypeInsertIntoTable.Visible = false;
            }
        }

        private void cboWatchType_EditValueChanged(object sender, EventArgs e)
        {
            foreach (ImageComboBoxItem item in cboWatchType.Properties.Items)
            {
                if (item.Value.ToString() == cboWatchType.EditValue.ToString())
                {
                    cboWatchType.SelectedItem = item;
                    break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetValue(task);
            this.DialogResult = DialogResult.OK;
        }

        private void frmTaskEditor_Load(object sender, EventArgs e)
        {
        }

        private void edtWatchFolder_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            edtWatchFolder.Text = Comm.Tools.SelectFolder(
                "请选择本任务监控的文件夹：",
                edtWatchFolder.Text);
        }

        private void edtBackupFileFolder_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            edtBackupFileFolder.Text = Comm.Tools.SelectFolder(
                "请选择备份文件保存的文件夹：",
                edtBackupFileFolder.Text);
        }

        private void chkBackupFileFlag_CheckedChanged(object sender, EventArgs e)
        {
            edtBackupFileFolder.Enabled = chkBackupFileFlag.Checked;
        }
    }
}
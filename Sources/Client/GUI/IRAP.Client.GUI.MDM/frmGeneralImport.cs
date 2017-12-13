using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using IRAP.Entity.Kanban;
using IRAP.Entity.UTS;
using IRAP.Global;
using IRAP.WCF.Client.Method;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace IRAP.Client.GUI.MDM {
    public partial class frmGeneralImport : IRAP.Client.Global.GUI.frmCustomFuncBase {
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        #region Debug
        private int _communityID = 60006;
        private long _sysLogID = 737942;
        private int _languageID = 30;
        private string _tvCtrlParameters = "19,2,1216,300,67327,17,(0:0;1:0;2:0;255:1),(),()";
        #endregion

        private List<IRAPTreeViewNode> _treeData = new List<IRAPTreeViewNode>();
        private LinkedTreeTip _treeInfo = new LinkedTreeTip();
        private IRAPTreeViewNode _currentNode;
        private List<LeafSet> _leafSet = new List<LeafSet>();
        private LeafSet _currentLeaf = new LeafSet();
        private ImportParam _importPara = new ImportParam();
        private List<ImportMetaData> _importMetaData = new List<ImportMetaData>();


        public frmGeneralImport() {
            InitializeComponent();
        }

        private void frmGeneralImport_Load(object sender, EventArgs e) {
            _treeData = GetTreeList();
            CreateTree();
        }

        #region 创建树
        private void CreateTree() {
            if (_treeData == null || _treeData.Count == 0) {
                return;
            }
            treeList.DataSource = _treeData;
            treeList.FocusedNode = null;
        }

        private List<IRAPTreeViewNode> GetTreeList() {

            int errCode;
            string errText;
            string strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);
            try {
                var paras = IRAPTreeClient.Instance.GetTreeViewCtrlParameters(_communityID, _tvCtrlParameters, _languageID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                } else {
                    var lists = IRAPTreeClient.Instance.GetTreeViewList(_communityID, _sysLogID, paras, out errCode, out errText);
                    if (errCode != 0) {
                        WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                        XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    } else {
                        return lists;
                    }
                }
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }
        #endregion

        #region 获取下拉列表信息
        private LinkedTreeTip GetLinkedTreeOfImpExp(int t19LeafID) {
            int errCode;
            string errText;
            string strProcedureName =
               string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                var lists = IRAPTreeClient.Instance.GetLinkedTreeOfImpExp(_communityID, t19LeafID, _sysLogID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                } else if (lists == null || lists.Count == 0) {
                    return null;
                } else {
                    return lists[0];
                }
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        private List<LeafSet> GetLeafSet() {
            int errCode;
            string errText;
            string strProcedureName =
               string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                var lists = IRAPTreeClient.Instance.GetAccessibleFilteredLeafSet(_communityID, _treeInfo.TreeID, 1, "", 255, this.comboBoxEdit1.Text, _sysLogID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                } else {
                    return lists;
                }
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        private void SetSelectTitle() {

            var treeId = 0 - _currentNode.NodeID;

            _treeInfo = GetLinkedTreeOfImpExp(treeId);
            if (_treeInfo == null) {
                _treeInfo = new LinkedTreeTip();
                return;
            }
            //设置提示信息
            if (_treeInfo.TreeID == 0) {
                this.layoutItemSelect.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            } else {
                this.layoutItemSelect.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.layoutItemSelect.Text = _treeInfo.PromptStr;
            }
        }

        private void SetDropDownList() {
            _leafSet = GetLeafSet();
            if (_leafSet == null || _leafSet.Count == 0) {
                return;
            }
            this.comboBoxEdit1.Properties.Items.Clear();
            foreach (LeafSet item in _leafSet) {
                this.comboBoxEdit1.Properties.Items.Add(item.LeafName);
            }
            //this.comboBoxEdit1.ShowPopup();
        }
        #endregion

        #region 获取导入信息
        private LeafSet GetSelectItem(string selectText, List<LeafSet> leafSet) {
            if (leafSet == null || leafSet.Count == 0 || string.IsNullOrEmpty(selectText)) {
                return null;
            }
            foreach (LeafSet leaf in leafSet) {
                if (selectText == leaf.LeafName) {
                    return leaf;
                }
            }
            return null;
        }

        private bool GetImportInfoXml() {
            int errCode;
            string errText;
            string strProcedureName =
               string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                IRAPTreeClient.Instance.GetImportInfoEntity(_communityID, -_currentNode.NodeID, _treeInfo.TreeID, _currentLeaf.LeafID, _sysLogID,
                    out _importPara, out _importMetaData, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void CreateGridColumn() {
            this.gridView1.Columns.Clear();
            if (!GetImportInfoXml()) {
                return;
            }
            foreach (ImportMetaData item in _importMetaData) {
                GridColumn col = new GridColumn();
                col.FieldName = item.ColName;
                col.Caption = item.ColDisplayName;
                col.Name = item.ColName;
                col.Visible = Convert.ToInt32(item.Visible) == 1;
                col.OptionsColumn.AllowEdit = Convert.ToInt32(item.EditEnabled) == 1;
                this.gridView1.Columns.Add(col);
            }
            this.gridView1.BestFitColumns();
        }

        #endregion

        #region 事件
        private void treeList_AfterFocusNode(object sender, NodeEventArgs e) {
            var node = this.treeList.GetDataRecordByNode(e.Node) as IRAPTreeViewNode;
            if (node.NodeID > 0) {
                return;
            }
            _currentNode = node;
            SetSelectTitle();
        }

        private void comboBoxEdit1_SelectedValueChanged(object sender, EventArgs e) {
            var selectItem = this.comboBoxEdit1.SelectedText;
            _currentLeaf = GetSelectItem(selectItem, _leafSet);
            if (_currentLeaf == null) {
                return;
            }
            CreateGridColumn();
        }

        private void comboBoxEdit1_QueryPopUp(object sender, CancelEventArgs e) {
            if (!this.layoutControlGroup2.Visible) {
                return;
            }
            SetDropDownList();
        }
        #endregion
    }
}

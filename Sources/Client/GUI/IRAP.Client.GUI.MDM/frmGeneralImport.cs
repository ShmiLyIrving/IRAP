using DevExpress.XtraEditors;
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
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.MDM {
    public partial class frmGeneralImport : IRAP.Client.Global.GUI.frmCustomFuncBase {
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        #region Debug
        private int _communityID =  60006;
        private long _sysLogID = 737942;
        private int _languageID = 30;
        private string _tvCtrlParameters = "19,2,1216,300,67327,17,(0:0;1:0;2:0;255:1),(),()";
        #endregion

        private List<IRAPTreeViewNode> _treeData = new List<IRAPTreeViewNode>();
        private LinkedTreeTip _treeInfo = new LinkedTreeTip();
        private IRAPTreeViewNode _currentNode;
        
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

        private List<LeafSet> GetLinkedTreeOfImpExp() {
            int errCode;
            string errText;
            string strProcedureName =
               string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                var lists = IRAPTreeClient.Instance.GetAccessibleFilteredLeafSet(_communityID,_treeInfo.TreeID,1,"",_currentNode.NodeDepth,"",_sysLogID,out errCode, out errText);
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
                return;
            }
            //设置提示信息
            if (_treeInfo.TreeID == 0) {
                this.layoutItemSelect.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            } else {
                this.layoutItemSelect.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.layoutItemSelect.Text = _treeInfo.PromptStr;
                SetDropDownList();
            }
        }

        private void SetDropDownList() {
            var lists = GetLinkedTreeOfImpExp();
            if (lists==null||lists.Count==0) {
                return;
            }
            this.comboBoxEdit1.Properties.Items.Clear();
            foreach (LeafSet item in lists) {
                this.comboBoxEdit1.Properties.Items.Add(item.LeafName);
            }
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
    
	#endregion
    } 
}

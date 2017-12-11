using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using IRAP.Entity.Kanban;
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
        private List<IRAPTreeViewNode> _treeData = new List<IRAPTreeViewNode>();

        public frmGeneralImport() {
            InitializeComponent();
        }
        private void frmGeneralImport_Load(object sender, EventArgs e) {
            //CreateColumns(treeList);
            _treeData = GetTreeList();
            if (_treeData == null||_treeData.Count==0) {
                return;
            }
            CreateTree();
            //CreateNodes(treeList);
        }

        private void CreateTree() {
            treeList.DataSource = _treeData;
        }

        private List<IRAPTreeViewNode> GetTreeList() {
            #region Debug
            int communityID = 60006;
            long sysLogID = 737942;
            int languageID = 30;
            string tvCtrlParameters = "19,2,1216,300,67327,17,(0:0;1:0;2:0;255:1),(),()";
            #endregion
            int errCode;
            string errText;
            string strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);
            try {
                var paras = IRAPTreeClient.Instance.GetTreeViewCtrlParameters(communityID, tvCtrlParameters, languageID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                } else {
                    var lists = IRAPTreeClient.Instance.GetTreeViewList(communityID, sysLogID, paras, out errCode, out errText);
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

        private void CreateNodes(TreeList tl) {
            tl.BeginUnboundLoad();
            // Create a root node .
            TreeListNode parentForRootNodes = null;
            TreeListNode rootNode = tl.AppendNode(
                new object[] { "Alfreds Futterkiste" },
                parentForRootNodes);
            // Create a child of the rootNode
            tl.AppendNode(new object[] { "Suyama, Michael" }, rootNode);
            // Creating more nodes
            // ...
            tl.AppendNode(new object[] { "sss" }, parentForRootNodes);
            tl.EndUnboundLoad();
        }

        private void button1_Click(object sender, EventArgs e) {
            GetTreeList();
        }
    }
}

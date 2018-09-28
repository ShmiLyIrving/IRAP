using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.Global.Enums;
using IRAP.Entities.MDM;

namespace IRAP.Client.GUI.BatchSystem.Dialogs
{
    public partial class frmItemsEditor : IRAP.Client.Global.frmCustomBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        protected EditStatus editStatus = EditStatus.Browse;
        protected DataTable dtParams = new DataTable();

        protected int recordNo = 0;

        protected List<TextEdit> edits = new List<TextEdit>();

        public frmItemsEditor()
        {
            InitializeComponent();
        }

        public  frmItemsEditor(
            EditStatus editStatus,
            string caption,
            DataTable dt,
            int recordNo) :
            this()
        {
            dtParams = dt;
            this.recordNo = recordNo;

            InitEditorGUI(dtParams, recordNo);

            groupControl1.Text = caption;

            this.editStatus = editStatus;
            switch (editStatus)
            {
                case EditStatus.New:
                    Text = "新增";
                    break;
                case EditStatus.Edit:
                    Text = "修改";
                    break;
            }
        }

        protected virtual void InitEditorGUI(DataTable items, int recordNo)
        {
            DataRow dr = null;
            if (recordNo >= 0 && recordNo < items.Rows.Count)
                dr = items.Rows[recordNo];
            int extraCol = 0;
            for (int i = 0; i < items.Columns.Count; i++)
            {
                //ReadOnly和FactID两列不用显示
                if (items.Columns[i].ColumnName == "ReadOnly") {
                    extraCol ++;
                    continue;
                }
                if (items.Columns[i].ColumnName == "FactID") {
                    extraCol++;
                    continue;
                }
                LabelControl label =
                    new LabelControl()
                    {
                        Text = string.Format("{0}：", items.Columns[i].Caption),
                        Font = new Font("微软雅黑", 10.5f),
                        Location = new Point(10, 40 + (i * 30)),
                        AutoSizeMode = LabelAutoSizeMode.None,
                        Size = new Size(200, 26),
                        Parent = groupControl1,
                    };
                label.Appearance.Options.UseTextOptions = true;
                label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                TextEdit textEdit =
                    new TextEdit()
                    {
                        EnterMoveNextControl = true,

                        Font = new Font("微软雅黑", 10.5f),
                        Location = new Point(220, 40 + (i * 30)),
                        Size = new Size(300, 26),
                        Parent = groupControl1,
                    };
                if (dr != null)
                    textEdit.Text = dr[i].ToString();
                edits.Add(textEdit);
            }

            Height = 40 + ((items.Columns.Count - extraCol) * 30) + 116;
        }

        protected virtual void btnOK_Click(object sender, EventArgs e)
        {
            DataRow dr = null;
            switch (editStatus)
            {
                case EditStatus.New:
                    dr = dtParams.NewRow();
                    for (int i = 0; i < edits.Count; i++)
                    {
                        dr[i] = edits[i].Text;
                    }
                    dtParams.Rows.Add(dr);

                    DialogResult = DialogResult.OK;
                    break;
                case EditStatus.Edit:
                    dr = dtParams.Rows[recordNo];
                    for (int i = 0; i < edits.Count; i++)
                        dr[i] = edits[i].Text;

                    DialogResult = DialogResult.OK;
                    break;
            }
        }
    }
}

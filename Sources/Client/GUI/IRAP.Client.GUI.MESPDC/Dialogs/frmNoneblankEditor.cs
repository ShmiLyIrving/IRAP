using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using IRAP.Client.Global.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.MESPDC.Dialogs
{
    public partial class frmNoneblankEditor : IRAP.Client.GUI.MESPDC.Dialogs.frmItemsEditor
    {
        public frmNoneblankEditor()
        {
            InitializeComponent();
        }
        public frmNoneblankEditor(
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
        protected override void InitEditorGUI(DataTable items, int recordNo)
        {
            DataRow dr = null;
            if (recordNo >= 0 && recordNo < items.Rows.Count)
                dr = items.Rows[recordNo];
            ConditionValidationRule notEmptyValidationRule = new ConditionValidationRule();
            notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            for (int i = 0; i < items.Columns.Count; i++)
            {
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
                notEmptyValidationRule.ErrorText = label.Text+"不能为空";
                dxValidationProvider1.SetValidationRule(textEdit, notEmptyValidationRule);
                this.dxValidationProvider1.SetIconAlignment(textEdit, ErrorIconAlignment.MiddleRight);
            }

            Height = 40 + (items.Columns.Count * 30) + 116;
        }
        protected override void btnOK_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
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
}

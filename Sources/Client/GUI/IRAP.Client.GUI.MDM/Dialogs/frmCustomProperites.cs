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
using IRAP.Client.User;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MDM
{
    public partial class frmCustomProperites : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string propertiesType = "";
        private int rowSetID = 0;
        protected int c64ID = 0;

        public frmCustomProperites()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 行集属性类型名称
        /// </summary>
        [Browsable(true)]
        [Description("行集属性类型名称")]
        public string PropertiesType
        {
            get { return propertiesType; }
            set
            {
                propertiesType = value;
                lblTitle.Text = value;
                Text = value + "行集属性";
            }
        }

        /// <summary>
        /// 行集属性号
        /// </summary>
        [Browsable(true)]
        [Description("行集属性号")]
        public int RowSetID
        {
            get { return rowSetID; }
            set { rowSetID = value; }
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="productName">产品名称</param>
        /// <param name="operationName">工序名称</param>
        public virtual void SetCaption(string productName, string operationName)
        {
            lblTitle.Text =
                string.Format(
                    "[{0}]在工序[{1}]的{2}",
                    productName,
                    operationName,
                    propertiesType);
        }

        /// <summary>
        /// 根据 T102LeafID 和 T216LeafID 获取行集属性值
        /// </summary>
        public virtual void GetProperties(int t102LeafID, int t216LeafID)
        {

        }

        protected virtual void btnSave_Click(object sender, EventArgs e)
        {
            #region 保存修改后的行集
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
                string effectiveTime = "";

                if (!chkEffectiveType.Checked)
                {
                    #region 要求输入生效日期和时间

                    #endregion
                }

                IRAPMDMClient.Instance.ssp_SaveRSAttrChange(
                    IRAPUser.Instance.CommunityID,
                    -64,
                    c64ID,
                    rowSetID,
                    "",
                    effectiveTime,
                    true,
                    GenerateRSAttrXML(),
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText, 
                        Text, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    XtraMessageBox.Show(
                        string.Format(
                            "{0}保存成功！",
                            lblTitle.Text),
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    btnCancel.PerformClick();
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            #endregion
        }

        protected virtual string GenerateRSAttrXML()
        {
            return "<RSAttr></RSAttr>";
        }

        protected virtual void SetEditorMode(bool isEnabled)
        {
            btnSave.Enabled = isEnabled;
        }
    }
}

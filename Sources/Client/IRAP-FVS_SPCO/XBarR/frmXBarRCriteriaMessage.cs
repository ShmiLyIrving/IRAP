using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace IRAP_FVS_SPCO.XBarR
{
    public partial class frmXBarRCriteriaMessage : DevExpress.XtraEditors.XtraForm
    {
        private List<CriteriaResult> xbarResults = new List<CriteriaResult>();
        private List<CriteriaResult> rResults = new List<CriteriaResult>();

        public frmXBarRCriteriaMessage()
        {
            InitializeComponent();

            xbarResults.Add(
                new CriteriaResult()
                {
                    Ordinal = 1,
                    CriteriaContent = "准则1：1点落在A区以外",
                    Result = true,
                });
            xbarResults.Add(
                new CriteriaResult()
                {
                    Ordinal = 2,
                    CriteriaContent = "准则2：连续6点递增或递减",
                    Result = true,
                });
            xbarResults.Add(
                new CriteriaResult()
                {
                    Ordinal = 3,
                    CriteriaContent = "准则3：连续7点落在中心线同一侧",
                    Result = true,
                });
            xbarResults.Add(
                new CriteriaResult()
                {
                    Ordinal = 4,
                    CriteriaContent = "准则4：连续14点中相邻点交替上下",
                    Result = true,
                });
            xbarResults.Add(
                new CriteriaResult()
                {
                    Ordinal = 5,
                    CriteriaContent = "准则5：连续3点中有2点落在中心线同一侧的B区以外",
                    Result = true,
                });
            xbarResults.Add(
                new CriteriaResult()
                {
                    Ordinal = 6,
                    CriteriaContent = "准则6：连续5点中有4点落在中心线同一侧的C区以外",
                    Result = true,
                });
            xbarResults.Add(
                new CriteriaResult()
                {
                    Ordinal = 7,
                    CriteriaContent = "准则7：连续15点落在中心线两侧的C区之内",
                    Result = true,
                });
            xbarResults.Add(
                new CriteriaResult()
                {
                    Ordinal = 8,
                    CriteriaContent = "准则8：连续8点落在中心线两侧且无一在C区之内",
                    Result = true,
                });

            foreach (CriteriaResult result in xbarResults)
            {
                rResults.Add(result.Clone());
            }

            grdXBarCriteriaResult.DataSource = xbarResults;
            grdRCriterialResult.DataSource = rResults;
        }

        public void SetCriteriaResult(bool[] xbars, bool[] rs)
        {
            for (int i = 0; i < xbars.Length; i++)
            {
                xbarResults[i].Result = xbars[i];
                rResults[i].Result = rs[i];
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    internal class CriteriaResult
    {
        public int Ordinal { get; set; }
        public string CriteriaContent { get; set; }
        public bool Result { get; set; }

        public CriteriaResult Clone()
        {
            return MemberwiseClone() as CriteriaResult;
        }
    }
}
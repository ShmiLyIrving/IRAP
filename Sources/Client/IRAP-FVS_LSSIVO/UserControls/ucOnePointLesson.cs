using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_LSSIVO.UserControls
{
    public partial class ucOnePointLesson : DevExpress.XtraEditors.XtraUserControl
    {
        private OnePointLesson data = null;
        private List<OPLTrainee> trainee = null;

        public ucOnePointLesson()
        {
            InitializeComponent();
        }

        public OnePointLesson OnePointLesson
        {
            get { return data; }
            set
            {
                data = value;

                if (data != null)
                {
                    lblIssueNo.Text = string.Format("NO.{0}", data.IssueNo.ToString("D2"));
                    picCorrect.Image = data.CorrectPicture;
                    picIncorrect.Image = data.IncorrectPicture;

                    lblWorkUnit.Text =
                        string.Format(
                            "工位：{0}",
                            data.T216Name);
                    lbl.Text = "";
                    lblIssueType.Text =
                        string.Format(
                            "类型：{0}",
                            data.IssueType);
                    lblDefect.Text =
                        string.Format(
                            "缺陷：{0}",
                            data.DefectDesc);
                    lblFailureCause.Text =
                        string.Format(
                            "失效原因：{0}",
                            data.T144Name);
                    lblOperationRequirement.Text =
                        string.Format(
                            "操作要求：{0}",
                            data.OperationReq);
                    lblTrainer.Text =
                        string.Format(
                            "班长：{0}",
                            data.TrainerName);
                    lblTrainingDate.Text =
                        string.Format(
                            "培训日期：{0}",
                            data.TrainingDate);
                }
            }
        }

        public List<OPLTrainee> Trainee
        {
            get { return trainee; }
            set
            {
                trainee = value;
                vgrdTrainees.DataSource = trainee;
            }
        }

        private void ucOnePointLesson_SizeChanged(object sender, EventArgs e)
        {
            int picWidth = (Width - picCorrect.Left * 3) / 2;

            picCorrect.Width = picWidth;
            picIncorrect.Width = picWidth;
            picIncorrect.Left = picCorrect.Left * 2 + picCorrect.Width;
        }
    }
}

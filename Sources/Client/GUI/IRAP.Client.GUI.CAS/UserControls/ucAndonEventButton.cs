using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Entity.MDM;
using IRAP.Client.Global.Resources;

namespace IRAP.Client.GUI.CAS.UserControls
{
    public partial class ucAndonEventButton : DevExpress.XtraEditors.XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private AndonEventType eventTypeItem = new AndonEventType();
        /// <summary>
        /// 鼠标点击事件
        /// </summary>
        public event EventHandler MouseLeftClick;

        public ucAndonEventButton()
        {
            InitializeComponent();
        }

        [Browsable(true), Description("设置标题")]
        public string Caption
        {
            get { return lblCaption.Text; }
            set { lblCaption.Text = value; }
        }

        [Browsable(true), Description("安灯类型")]
        public string EventType
        {
            get { return eventTypeItem.EventTypeCode; }
            set
            {
                eventTypeItem.EventTypeCode = value;
                RefreshButtonImage();
            }
        }

        [Browsable(true), Description("是否可用")]
        public bool Available
        {
            get { return eventTypeItem.Available; }
            set
            {
                eventTypeItem.Available = value;
                if (value && Statue != 0)
                    picButton.Cursor = Cursors.Hand;
                else
                    picButton.Cursor = Cursors.Default;

                RefreshButtonImage();
            }
        }

        [Browsable(true), Description("安灯状态")]
        public int Statue
        {
            get { return eventTypeItem.Status; }
            set
            {
                eventTypeItem.Status = value;

                RefreshButtonImage();

                if (value != 0 && Available)
                    picButton.Cursor = Cursors.Hand;
                else
                    picButton.Cursor = Cursors.Default;
            }
        }

        public AndonEventType EventTypeItem
        {
            get { return eventTypeItem; }
            set
            {
                eventTypeItem = value;

                Caption = eventTypeItem.EventTypeName;
                EventType = eventTypeItem.EventTypeCode;
                Available = eventTypeItem.Available;
                Statue = eventTypeItem.Status;
            }
        }

        public void RefreshButtonImage()
        {
            string strBMPName = "";
            string eventTypeCode = "";

            switch (eventTypeItem.EventTypeCode)
            {
                case "T":
                    eventTypeCode = "F";
                    break;
                case "X":
                    eventTypeCode = "T";
                    break;
                default:
                    eventTypeCode = eventTypeItem.EventTypeCode;
                    break;
            }

            if (eventTypeItem.Available)
            {
                strBMPName =
                    string.Format(
                        "{0}{1}",
                        eventTypeCode,
                        eventTypeItem.Status);
            }
            else
            {
                strBMPName =
                    string.Format(
                        "{0}0",
                        eventTypeCode);
            }
            picButton.Image = IRAP.Client.Global.Resources.Properties.Resources.ResourceManager.GetObject(strBMPName) as Bitmap;
        }

        private void picButton_Click(object sender, EventArgs e)
        {
            if (MouseLeftClick != null)
                MouseLeftClick(this, e);
        }
    }
}

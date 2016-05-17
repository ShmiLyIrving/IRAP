using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace IRAP_FVS_MDVO.Controls
{
    public partial class ucCustomDocumentKanban : DevExpress.XtraEditors.XtraUserControl
    {
        protected int communityID = -1;
        protected int t102LeafID = -1;
        protected int t216LeafID = -1;
        protected long sysLogID = -1;

        public ucCustomDocumentKanban()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 社区标识
        /// </summary>
        public int CommunityID
        {
            get { return communityID; }
            set { communityID = value; }
        }

        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID
        {
            get { return t102LeafID; }
            set
            {
                t102LeafID = value;
                if (!timer.Enabled)
                    timer.Enabled = true;
            }
        }

        /// <summary>
        /// 工序叶标识
        /// </summary>
        public int T216LeafID
        {
            get { return t216LeafID; }
            set
            {
                t216LeafID = value;
                if (!timer.Enabled)
                    timer.Enabled = true;
            }
        }

        /// <summary>
        /// 系统登录标识
        /// </summary>
        public long SysLogID
        {
            get { return sysLogID; }
            set { sysLogID = value; }
        }
    }
}

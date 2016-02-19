using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class TVCtrlParam
    {
        public int IRAPTreeID { get; set; }
        public int TreeViewType { get; set; }
        public int EntryNode { get; set; }
        public int DefaultWinWidth { get; set; }
        public bool WinWidthAdjustable { get; set; }
        public string CtrlPrompt { get; set; }
        public bool IncludeLeaves { get; set; }
        public bool ShowNodeID { get; set; }
        public bool ShowNodeCode { get; set; }
        public int OrderByMode { get; set; }
        public int Accessibility { get; set; }
        public int DITVCtrlVar { get; set; }
        public string DSTVCtrlBlk { get; set; }
        public string FilterClickStream { get; set; }
        public string SelectClickStream { get; set; }

        public TVCtrlParam Clone()
        {
            TVCtrlParam rlt = MemberwiseClone() as TVCtrlParam;

            return rlt;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    /// <summary>
    /// IRAP树视图节点信息
    /// </summary>
    public class IRAPTreeViewNode
    {
        public int NodeID { get; set; }
        public int TreeViewType { get; set; }
        public int NodeType { get; set; }
        public string NodeCode { get; set; }
        public string NodeName { get; set; }
        public int Parent { get; set; }
        public int NodeDepth { get; set; }
        public int CSTRoot { get; set; }
        public double UDFOrdinal { get; set; }
        public int NodeStatus { get; set; }
        public int Accessibility { get; set; }
        public int SelectStatus { get; set; }
        public string SearchCode1 { get; set; }
        public string SearchCode2 { get; set; }
        public string HelpMemoryCode { get; set; }
        public string IconFile { get; set; }
        public byte[] IconImage { get; set; }

        public IRAPTreeViewNode Clone()
        {
            IRAPTreeViewNode rlt = MemberwiseClone() as IRAPTreeViewNode;

            return rlt;
        }
    }
}
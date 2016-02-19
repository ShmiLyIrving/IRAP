using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class TreeEntity
    {
        public double Ordinal { get; set; }
        public string EntityName { get; set; }
        public int LeafID { get; set; }
        public string Code { get; set; }
        public int EntityID { get; set; }

        public TreeEntity Clone()
        {
            TreeEntity rlt = MemberwiseClone() as TreeEntity;

            return rlt;
        }
    }
}
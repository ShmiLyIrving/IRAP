using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Client.GUI.MESPDC.Entities
{
    public class EntityMethodStarndardParams
    {
        public string StandardName { get; set; }
        public long Value01 { get; set; }
        public long Value02 { get; set; }
        public long Value03 { get; set; }
        public long Value04 { get; set; }
        public long Value05 { get; set; }
        public long Value06 { get; set; }
        public long Value07 { get; set; }
        public long Value08 { get; set; }
        public long Value09 { get; set; }
        public long Value10 { get; set; }
        public long Value11 { get; set; }
        public long Value12 { get; set; }
        public long Value13 { get; set; }
        public long Value14 { get; set; }
        public long Value15 { get; set; }
        public long Value16 { get; set; }

        public EntityMethodStarndardParams Clone()
        {
            return MemberwiseClone() as EntityMethodStarndardParams;
        }
    }
}

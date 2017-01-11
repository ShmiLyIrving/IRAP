using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class PackageType
    {
        public int CorrelationID { get; set; }
        public int Ordinal { get; set; }
        public string SpecDesc { get; set; }
        public int StdPackagingQty { get; set; }
        public int QtyPerColOfBox { get; set; }
        public int QtyPerRowOfBox { get; set; }
        public int NumLayersOfBox { get; set; }
        public int T117LabelID_Box { get; set; }
        public int NumBoxPerColOfCarton { get; set; }
        public int NumBoxPerRowOfCarton { get; set; }
        public int NumLayersOfCarton { get; set; }
        public int T117LabelID_Carton { get; set; }
        public int NumCartonsPerLayerOfPallet { get; set; }
        public int NumLayersOfPallet { get; set; }
        public int T117LabelID_Layer { get; set; }
        public int T117LabelID_Pallet { get; set; }
        public string SerialNoLeadingStr { get; set; }
        public int NextSerialNumber { get; set; }
    }
}

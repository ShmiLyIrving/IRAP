using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MES
{
    public class WIPBarCodeInfo
    {
        public string RoutingStatusStr { get; set; }
        public string BarcodeStatusStr { get; set; }
        public int RoutingStatus { get; set; }
        public string ContainerNo { get; set; }
        public int WorkUnitLeaf { get; set; }
        public int ProcessLeaf { get; set; }
        public string SerialNumber { get; set; }
        public string PartIDCode3 { get; set; }
        public string PartIDCode2 { get; set; }
        public string PartIDCode1 { get; set; }
        public int NumOfSubPCBs { get; set; }
        public int BarcodeStatus { get; set; }

        public WIPBarCodeInfo Clone()
        {
            WIPBarCodeInfo rlt = MemberwiseClone() as WIPBarCodeInfo;

            return rlt;
        }
    }
}
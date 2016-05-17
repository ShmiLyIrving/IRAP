using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using IRAPShared;
using IRAP.Global;

namespace IRAP.Entity.MDM.Tables
{
    [IRAPDB(TableName = "IRAPMDM..GenAttr_Product")]
    public class GenAttr_Product
    {
        private long partitioningKey = 0;
        private int entityID = 0;
        private int barcodeStart = 0;
        private int barcodeEnd = 0;
        private string productSNParttern = "";
        private string serialNoPrefix = "";
        private string dateShiftPattern = "";
        private string hardwareVersion = "";
        private string version = "";
        private string modelID = "";
        private int serialNoDigits = 0;
        private int nextProductSerialNo = 0;
        private string sequenceCode = "";
        private string checkDigit = "";
        private int serialNoSystem = 0;
        private string resetCycle = "";
        private string serialNoSuffix = "";
        private string unitOfMeasure = "";
        private byte[] productSketch;
        private Image productImage = null;

        [IRAPKey()]
        public long PartitioningKey
        {
            get { return partitioningKey; }
            set { partitioningKey = value; }
        }

        [IRAPKey()]
        public int EntityID
        {
            get { return entityID; }
            set { entityID = value; }
        }

        public int BarcodeStart
        {
            get { return barcodeStart; }
            set { barcodeStart = value; }
        }

        public int BarcodeEnd
        {
            get { return barcodeEnd; }
            set { barcodeEnd = value; }
        }

        public string ProductSNPattern
        {
            get { return productSNParttern; }
            set { productSNParttern = value; }
        }

        public string SerialNoPrefix
        {
            get { return serialNoPrefix; }
            set { serialNoPrefix = value; }
        }

        public string DateShiftPattern
        {
            get { return dateShiftPattern; }
            set { dateShiftPattern = value; }
        }

        public string HardwareVersion
        {
            get { return hardwareVersion; }
            set { hardwareVersion = value; }
        }

        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        public string ModelID
        {
            get { return modelID; }
            set { modelID = value; }
        }

        public int SerialNoDigits
        {
            get { return serialNoDigits; }
            set { serialNoDigits = value; }
        }

        public int NextProductSerialNo
        {
            get { return nextProductSerialNo; }
            set { nextProductSerialNo = value; }
        }

        public string SequenceCode
        {
            get { return sequenceCode; }
            set { sequenceCode = value; }
        }

        public string CheckDigit
        {
            get { return checkDigit; }
            set { checkDigit = value; }
        }

        public int SerialNoSystem
        {
            get { return serialNoSystem; }
            set { serialNoSystem = value; }
        }

        public string ResetCycle
        {
            get { return resetCycle; }
            set { resetCycle = value; }
        }

        public string SerialNoSuffix
        {
            get { return serialNoSuffix; }
            set { serialNoSuffix = value; }
        }

        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }

        public byte[] ProductSketch
        {
            get { return productSketch; }
            set { productSketch = value; }
        }

        [IRAPORMMap(ORMMap = false)]
        public Image ProductImage
        {
            get { return productImage; }
            set
            {
                productImage = value;
                productSketch = Tools.ImageToBytes(value);
            }
        }

        public GenAttr_Product Clone()
        {
            GenAttr_Product rlt = this.MemberwiseClone() as GenAttr_Product;
            rlt.productImage = Tools.BytesToImage(productSketch);

            return rlt;
        }
    }
}

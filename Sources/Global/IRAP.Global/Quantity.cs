using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Global
{
    /// <summary>
    /// 数量
    /// </summary>
    public class Quantity
    {
        private long intValue = 0;
        private int scale = 0;
        private string unitOfMeasure = "";
    
        public long IntValue
        {
            get { return intValue; }
            set { intValue = value; }
        }

        public double DoubleValue
        {
            get { return intValue / Math.Pow(10, scale); }
            set { intValue = Convert.ToInt64(value * Math.Pow(10, scale)); }
        }

        public int Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }

        public override string ToString()
        {
            string valueSring = "";
            if (scale > 0)
                valueSring = DoubleValue.ToString("0.".PadRight(scale + 2, '0'));
            else
                valueSring = DoubleValue.ToString("0");

            return string.Format("{0} {1}", valueSring, unitOfMeasure);
        }

        public Quantity Clone()
        {
            return this.MemberwiseClone() as Quantity;
        }
    }
}

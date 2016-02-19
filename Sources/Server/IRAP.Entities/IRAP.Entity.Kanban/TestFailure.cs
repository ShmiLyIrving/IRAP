using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class TestFailure
    {
        public double Metric12 { get; set; }
        public double Metric11 { get; set; }
        public double Metric10 { get; set; }
        public double Metric09 { get; set; }
        public double Metric08 { get; set; }
        public double Metric07 { get; set; }
        public double Metric06 { get; set; }
        public double Metric05 { get; set; }
        public double Metric04 { get; set; }
        public double Metric03 { get; set; }
        public double Metric02 { get; set; }
        public double Metric01 { get; set; }
        public string Criterion { get; set; }
        public string Units { get; set; }
        public string MetricName { get; set; }
        public int Ordinal { get; set; }

        public TestFailure Clone()
        {
            TestFailure rlt = MemberwiseClone() as TestFailure;

            return rlt;
        }
    }
}
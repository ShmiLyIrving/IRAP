using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class RPTMOExecution
    {
        public string MONumber { get; set; }
        public int MOLineNo { get; set; }
        public string ProductNo { get; set; }
        public string ProductName { get; set; }
        public string ScheduleStartTime { get; set; }
        public string ScheduleCloseTime { get; set; }
        public string ActualStartTime { get; set; }
        public string ActualCloseTime { get; set; }
        public int OrderQty { get; set; }
        public int MaterialQty { get; set; }
        public int WIPQty { get; set; }
        public double ScrapRate { get; set; }

        public RPTMOExecution Clone()
        {
            RPTMOExecution rlt = MemberwiseClone() as RPTMOExecution;

            return rlt;
        }
    }
}
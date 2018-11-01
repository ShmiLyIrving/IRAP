using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Entities.MES;

namespace IRAP.Client.GUI.BatchSystem.Entities
{
    internal class TMaterialPreparationInfos
    {
        private List<TMaterialPreparationInfo> items =
            new List<TMaterialPreparationInfo>();

        public int Count { get { return items.Count; } }
        public List<TMaterialPreparationInfo> Items
        {
            get { return items; }
            set { items = value; }
        }
    }

    internal class TMaterialPreparationInfo
    {
        private List<EntityBatchPWO> pwos = new List<EntityBatchPWO>();

        public string Title
        {
            get
            {
                return $"备料批次 {PreparateTime.ToString("MMddhhmmss")}";
            }
        }
        public DateTime PreparateTime { get; set; }
        public List<EntityBatchPWO> PWOs
        {
            get { return pwos; }
            set { pwos = value; }
        }

        public override string ToString()
        {
            return Title;
        }
    }
}

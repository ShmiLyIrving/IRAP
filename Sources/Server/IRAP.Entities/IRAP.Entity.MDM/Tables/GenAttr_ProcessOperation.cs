using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entity.MDM.Tables
{
    /// <summary>
    /// T216 一般属性
    /// </summary>
    [IRAPDB(TableName = "IRAPMDM..GenAttr_ProcessOperation")]
    public class GenAttr_ProcessOperation
    {
        private long partitioningKey = 0;
        private int entityID = 0;
        private byte[] operationSketch;

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

        public byte[] OperationSketch
        {
            get { return operationSketch; }
            set { operationSketch = value; }
        }

        //[IRAPORMMap(ORMMap = false)]
        //public Image OperationImage
        //{
        //    get { return Tools.BytesToImage(operationSketch); }
        //}

        public GenAttr_ProcessOperation Clone()
        {
            return this.MemberwiseClone() as GenAttr_ProcessOperation;
        }
    }
}

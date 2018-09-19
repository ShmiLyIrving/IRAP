using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IRAP.Entities.MES
{
    public class SubWIPIDCode_TroubleShooting : SubWIPIDCodes_TS
    {
        private int repairStatus = 0;
        private List<SubWIPIDCode_TSItem> tsItems = new List<SubWIPIDCode_TSItem>();
        private DataTable tsItemsDT = null;

        public SubWIPIDCode_TroubleShooting()
        {
            tsItemsDT = new DataTable("RepairItems");
            tsItemsDT.Columns.Add("ItemLeafID", typeof(int));
            tsItemsDT.Columns.Add("ItemLeafTreeID", typeof(int));
            tsItemsDT.Columns.Add("T118LeafID", typeof(int));
            tsItemsDT.Columns.Add("FailurePointCount", typeof(int));
            tsItemsDT.Columns.Add("T216LeafID", typeof(int));
            tsItemsDT.Columns.Add("T183LeafID", typeof(int));
            tsItemsDT.Columns.Add("T184LeafID", typeof(int));
            tsItemsDT.Columns.Add("T119LeafID", typeof(int));
            tsItemsDT.Columns.Add("TrackReferenceValue", typeof(string));
            tsItemsDT.Columns.Add("IsInspectItem", typeof(bool));
            tsItemsDT.Columns.Add("SKUID1", typeof(string));
            tsItemsDT.Columns.Add("SKUID2", typeof(string));
            tsItemsDT.Columns.Add("T10xLeafID", typeof(int));
        }

        /// <summary>
        /// 维修状态
        /// </summary>
        public int RepairStatus
        {
            get { return repairStatus; }
            set { repairStatus = value; }
        }

        /// <summary>
        /// 生产工单号
        /// </summary>
        public string PWONo { get; set; }

        public List<SubWIPIDCode_TSItem> TSItems
        {
            get { return tsItems; }
            set { tsItems = value; }
        }

        public DataTable TSItemsDT
        {
            get { return tsItemsDT; }
            set { tsItemsDT = value; }
        }

        public void GetListFromDataTable()
        {
            this.tsItems.Clear();
            foreach (DataRow dr in this.tsItemsDT.Rows)
            {
                SubWIPIDCode_TSItem item = new SubWIPIDCode_TSItem();

                int itemLeafTreeID = 0;
                try { itemLeafTreeID = (int)dr["ItemLeafTreeID"]; }
                catch { itemLeafTreeID = 0; }

                if (itemLeafTreeID == 110)
                {
                    try { item.T110LeafID = (int)dr["ItemLeafID"]; }
                    catch { item.T110LeafID = 0; }
                }

                try { item.T101LeafID = (int)dr["T10xLeafID"]; }
                catch { item.T101LeafID = 0; }
                try { item.T118LeafID = (int)dr["T118LeafID"]; }
                catch { item.T118LeafID = 0; }
                try { item.T119LeafID = (int)dr["T119LeafID"]; }
                catch { item.T119LeafID = 0; }
                try { item.T183LeafID = (int)dr["T183LeafID"]; }
                catch { item.T183LeafID = 0; }
                try { item.T184LeafID = (int)dr["T184LeafID"]; }
                catch { item.T184LeafID = 0; }
                try { item.T216LeafID = (int)dr["T216LeafID"]; }
                catch { item.T216LeafID = 0; }
                try { item.FailurePointCount = (int)dr["FailurePointCount"]; }
                catch { item.FailurePointCount = 0; }
                try { item.TrackReferenceValue = dr["TrackReferenceValue"].ToString(); }
                catch { item.TrackReferenceValue = ""; }
                try { item.IsInspectItem = (bool)dr["IsInspectItem"]; }
                catch { item.IsInspectItem = false; }
                try { item.SKUID1 = dr["SKUID1"].ToString(); }
                catch { item.SKUID1 = ""; }
                try { item.SKUID2 = dr["SKUID2"].ToString(); }
                catch { item.SKUID2 = ""; }

                this.tsItems.Add(item);
            }
        }

        public void PutListIntoDataTable()
        {
            tsItemsDT.Clear();
            foreach (SubWIPIDCode_TSItem item in tsItems)
            {
                if (item.T110LeafID != 0)
                {
                    tsItemsDT.Rows.Add(new object[]
                        {
                            item.T110LeafID,
                            "110",
                            item.T118LeafID,
                            item.FailurePointCount,
                            item.T216LeafID,
                            item.T183LeafID,
                            item.T184LeafID,
                            item.T119LeafID,
                            item.TrackReferenceValue,
                            item.IsInspectItem,
                            item.SKUID1,
                            item.SKUID2,
                            item.T101LeafID,
                        });
                }
                else
                {
                    tsItemsDT.Rows.Add(new object[]
                        {
                            item.T101LeafID,
                            "101",
                            item.T118LeafID,
                            item.FailurePointCount,
                            item.T216LeafID,
                            item.T183LeafID,
                            item.T184LeafID,
                            item.T119LeafID,
                            item.TrackReferenceValue,
                            item.IsInspectItem,
                            item.SKUID1,
                            item.SKUID2,
                            item.T101LeafID,
                        });
                }
            }
        }

        public string GetDataTableString()
        {
            string rlt = "";
            foreach (DataRow dr in this.tsItemsDT.Rows)
            {
                rlt += string.Format("<ItemLeafTrerID>{0}</ItemLeafTrerID>", (int)dr["ItemLeafTreeID"]);
                rlt += string.Format("<ItemLeafID>{0}</ItemLeafID>", (int)dr["ItemLeafID"]);
                rlt += string.Format("<T118LeafID>{0}</T118LeafID>", (int)dr["T118LeafID"]);
                rlt += string.Format("<FailurePointCount>{0}</FailurePointCount>", (int)dr["FailurePointCount"]);
                rlt += string.Format("<T216LeafID>{0}</T216LeafID>", (int)dr["T216LeafID"]);
                rlt += string.Format("<T183LeafID>{0}</T183LeafID>", (int)dr["T183LeafID"]);
                rlt += string.Format("<T184LeafID>{0}</T184LeafID>", (int)dr["T184LeafID"]);
                rlt += string.Format("<T119LeafID>{0}</T119LeafID>", (int)dr["T119LeafID"]);
                rlt += string.Format("<TrackReferenceValue>{0}</TrackReferenceValue>", dr["TrackReferenceValue"].ToString());

                rlt = string.Format("<Record>{0}</Record>", rlt);
            }
            return rlt;
        }

        public string GetListString()
        {
            string rlt = "";
            foreach (SubWIPIDCode_TSItem item in tsItems)
            {
                rlt += string.Format("<T110LeafID>{0}</T110LeafID>", item.T110LeafID);
                rlt += string.Format("<T101LeafID>{0}</T101LeafID>", item.T101LeafID);
                rlt += string.Format("<T118LeafID>{0}</T118LeafID>", item.T118LeafID);
                rlt += string.Format("<FailurePointCount>{0}</FailurePointCount>", item.FailurePointCount);
                rlt += string.Format("<T216LeafID>{0}</T216LeafID>", item.T216LeafID);
                rlt += string.Format("<T183LeafID>{0}</T183LeafID>", item.T183LeafID);
                rlt += string.Format("<T184LeafID>{0}</T184LeafID>", item.T184LeafID);
                rlt += string.Format("<T119LeafID>{0}</T119LeafID>", item.T119LeafID);
                rlt += string.Format("<TrackReferenceValue>{0}</TrackReferenceValue>", item.TrackReferenceValue);

                rlt = string.Format("<List>{0}</List>", rlt);
            }
            return rlt;
        }

        public void CopyFrom(SubWIPIDCodes_TS origin)
        {
            Ordinal = origin.Ordinal;
            PartNumber = origin.PartNumber;
            SubWIPIDCode = origin.SubWIPIDCode;
            LinkedFactID = origin.LinkedFactID;
            PWOCategoryLeaf = origin.PWOCategoryLeaf;
            T132Leaf = origin.T132Leaf;
        }
    }
}

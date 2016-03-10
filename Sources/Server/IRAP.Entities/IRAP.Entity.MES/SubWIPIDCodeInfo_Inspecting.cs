using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// 用于人工检查的子在制品信息
    /// </summary>
    public class SubWIPIDCodeInfo_Inspecting : SubWIPIDCodeInfo
    {
        private List<InspectingFailureItem> failureItems =
            new List<InspectingFailureItem>();
        private DataTable failureItemsDT = null;

        public SubWIPIDCodeInfo_Inspecting()
        {
            failureItemsDT = new DataTable("InspectingItems");
            failureItemsDT.Columns.Add("T101LeafID", typeof(int));
            failureItemsDT.Columns.Add("T110LeafID", typeof(int));
            failureItemsDT.Columns.Add("T118LeafID", typeof(int));
            failureItemsDT.Columns.Add("T216LeafID", typeof(int));
            failureItemsDT.Columns.Add("T183LeafID", typeof(int));
            failureItemsDT.Columns.Add("T184LeafID", typeof(int));
            failureItemsDT.Columns.Add("CntDefect", typeof(int));

            InspectingStatus = 1;
        }

        /// <summary>
        /// 检查结论
        /// </summary>
        public int InspectingStatus { get; set; }
        /// <summary>
        /// 检查失效项
        /// </summary>
        public List<InspectingFailureItem> FailureItems
        {
            get { return failureItems; }
            set { failureItems = value; }
        }
        public DataTable FailureItemsDT
        {
            get { return failureItemsDT; }
            set { failureItemsDT = value; }
        }

        public void GetListFromDataTable()
        {
            failureItems.Clear();
            foreach (DataRow dr in failureItemsDT.Rows)
            {
                InspectingFailureItem item = new InspectingFailureItem();
                try { item.T101LeafID = (int) dr["T101LeafID"]; }
                catch { item.T101LeafID = 0; }
                try { item.T110LeafID = (int) dr["T110LeafID"]; }
                catch { item.T110LeafID = 0; }
                try { item.T118LeafID = (int) dr["T118LeafID"]; }
                catch { item.T118LeafID = 0; }
                try { item.T216LeafID = (int) dr["T216LeafID"]; }
                catch { item.T216LeafID = 0; }
                try { item.T183LeafID = (int) dr["T183LeafID"]; }
                catch { item.T183LeafID = 0; }
                try { item.T184LeafID = (int) dr["T184LeafID"]; }
                catch { item.T184LeafID = 0; }
                try { item.CntDefect = (int) dr["CntDefect"]; }
                catch { item.CntDefect = 0; }

                failureItems.Add(item);
            }
        }

        public void PutListIntoDataTable()
        {
            failureItemsDT.Clear();
            foreach (InspectingFailureItem item in failureItems)
            {
                failureItemsDT.Rows.Add(new object[]
                    {
                        item.T101LeafID,
                        item.T110LeafID,
                        item.T118LeafID,
                        item.T216LeafID,
                        item.T183LeafID,
                        item.T184LeafID,
                        item.CntDefect,
                    });
            }
        }
    }
}
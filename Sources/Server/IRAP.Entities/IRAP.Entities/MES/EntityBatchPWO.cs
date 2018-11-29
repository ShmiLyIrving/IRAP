using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.MES
{
    public class EntityBatchPWO
    {
        private string remark = "";
        private int quantity1 = 0;
        private int quantity2 = 0;
        private string displayRemark = "";

        /// <summary>
        /// 事实编号
        /// </summary>
        public long FactID { get; set; }
        /// <summary>
        /// 工单号
        /// </summary>
        public string PWONo { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产品物料号
        /// </summary>
        public string T102Code { get; set; }
        /// <summary>
        /// 产品物料名称
        /// </summary>
        public string T102Name { get; set; }
        /// <summary>
        /// 产品标识代码
        /// </summary>
        public string WIPCode { get; set; }
        /// <summary>
        /// 工单批次号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 产品序列号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 产品替代标识代码
        /// </summary>
        public string AltWIPCode { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public string Texture { get; set; }
        /// <summary>
        /// 容次号
        /// </summary>
        public string BatchLot { get; set; }
        /// <summary>
        /// 工单生产数量
        /// </summary>
        public long Quantity { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set
            {
                remark = value.Replace("生产记载", "");

                #region 解析 Remark
                displayRemark = "";

                string[] strSplit = remark.Split('|');
                for (int i = 0; i < strSplit.Length; i++)
                {
                    if (strSplit[i].Contains("大头数量："))
                    {
                        int rlt = 0;
                        if (int.TryParse(strSplit[i].Replace("大头数量：", ""), out rlt))
                        {
                            Quantity1 = rlt;
                        }
                    }
                    else if (strSplit[i].Contains("小头数量："))
                    {
                        int rlt = 0;
                        if (int.TryParse(strSplit[i].Replace("小头数量：", ""), out rlt))
                        {
                            Quantity2 = rlt;
                        }
                    }
                    else if (strSplit[i].Contains("备注："))
                    {
                        displayRemark = strSplit[i].Replace("备注：", "");
                    }
                }
                #endregion
            }
        }
        /// <summary>
        /// 大头数量
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public int Quantity1
        {
            get { return quantity1; }
            set
            {
                quantity1 = value;
                GenerateRemark();
            }
        }
        /// <summary>
        /// 小头数量
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public int Quantity2
        {
            get { return quantity2; }
            set
            {
                quantity2 = value;
                GenerateRemark();
            }
        }
        public string DisplayRemark
        {
            get { return displayRemark; }
            set
            {
                displayRemark = value;
                GenerateRemark();
            }
        }

        private void GenerateRemark()
        {
            if (quantity1 + quantity2 > 0)
            {
                Quantity = quantity1 + quantity2;
            }
            remark =
                $"大头数量：{Quantity1}|小头数量：{Quantity2}|备注：{displayRemark}";
        }

        public EntityBatchPWO Clone()
        {
            return MemberwiseClone() as EntityBatchPWO;
        }
    }
}

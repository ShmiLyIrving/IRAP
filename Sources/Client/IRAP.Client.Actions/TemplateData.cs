namespace IRAP.Client.Actions
{
    internal class TemplateData
    {
        /// <summary>
        /// 打印的份数
        /// </summary>
        public int Cnt { get; set; }
        /// <summary>
        /// 发货地址
        /// </summary>
        public string SendAddress { get; set; }
        /// <summary>
        /// 客户代码
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string ReceiveAddress { get; set; }
        /// <summary>
        /// 客户零件号
        /// </summary>
        public string CustomerPartNumber { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string SupplierCode { get; set; }
        /// <summary>
        /// 供应商零件号
        /// </summary>
        public string SupplierPartNumber { get; set; }
        /// <summary>
        /// 零件名称
        /// </summary>
        public string PartName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string Quantity { get; set; }
        /// <summary>
        /// 托盘号
        /// </summary>
        public string ContainerNo { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public string ProductDate { get; set; }
        /// <summary>
        /// 客户序列号
        /// </summary>
        public string CustomerSN { get; set; }

        public TemplateData Clone()
        {
            return MemberwiseClone() as TemplateData;
        }
    }
}
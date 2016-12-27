using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPORM;
using IRAP.Entities.IRAP;
using IRAP.Entities.UTS;

namespace IRAPDAL
{
    public class UTS
    {
        private static UTS _intance = null;

        private UTS() { }

        public static UTS Instance
        {
            get
            {
                if (_intance == null)
                    _intance = new UTS();
                return _intance;
            }
        }

        /// <summary>
        /// 向序列服务器申请序列号
        /// </summary>
        /// <param name="sequenceName">序列名称</param>
        /// <param name="count">申请个数</param>
        /// <returns>申请到的序列号（申请多个的话，返回第一个）</returns>
        public long msp_GetSequenceNo(string sequenceName, long count)
        {
            if (count > 10000)
            {
                throw new Exception("申请序列号过多，每次不能超过10000个！");
            }
            string hostIp = IRAPSQLConnection.SequenceAddress;
            long sequenceNo = IRAPSequence.GetSequenceNo(hostIp, sequenceName, count);

            return sequenceNo;
        }

        public long msp_GetTransactNo(
            int communityID, 
            int count, 
            string tableName, 
            string userCode, 
            long sysLogID, 
            string opNodes,
            string voucherNo, 
            out int errCode, 
            out string errText, 
            bool isCheckTran = false)
        {
            try
            {
                if (count > 10000)
                {
                    errCode = 999999;
                    errText = "申请序列号过多！";
                    return -1;
                }
                long transactNo = msp_GetSequenceNo("NextTransactNo", 1);
                if (transactNo < 1)
                {
                    errCode = 999999;
                    errText = "申请序列号不正确，请检查服务器地址配置是否正确！IRAPORM.xml";
                    return -1;
                }

                IRAPSQLConnection conn = new IRAPSQLConnection();
                STB009 sysLogIDRow = (STB009)conn.Get(
                    new STB009()
                    {
                        PartitioningKey = 10000L * communityID,
                        SysLogID = sysLogID
                    });

                if (sysLogIDRow == null)
                {
                    errCode = 99999;
                    errText = string.Format(
                        "无效的登陆标识 [{0}]！",
                        sysLogID);
                    return -1;
                }

                STB010 tRow = new STB010();
                tRow.PartitionPolicy = 
                    long.Parse(
                        (DateTime.Now.Year.ToString() +
                        (100000000L + communityID).ToString().Substring(1, 8)));
                tRow.TransactNo = transactNo;
                tRow.IPAddress = "";
                tRow.OperTime = DateTime.Now;
                if (isCheckTran)
                {
                    tRow.OkayTime = DateTime.Now;
                    tRow.Status = 5;
                    tRow.Checked = userCode;
                    tRow.AgencyLeaf2 = sysLogIDRow.AgencyLeaf;
                    tRow.AgencyLeaf1 = sysLogIDRow.AgencyLeaf;
                }
                else
                {
                    tRow.Status = 0;
                    tRow.OkayTime = new DateTime(1800, 1, 1);
                }

                tRow.RevokeTime = new DateTime(1800, 1, 1);
                tRow.OpNodes = opNodes;
                tRow.VoucherNo = voucherNo;
                tRow.VoucherNoEx = "";
                tRow.WFInstanceID = "";

                tRow.Operator = userCode;
                conn.Insert(tableName, tRow);
                conn.Close();
                errCode = 0;
                errText = "申请交易号成功！";
                return transactNo;
            }
            catch (Exception err)
            {
                errCode = 9999;
                errText = string.Format("申请交易号出错：[{0}]", err.Message);
                return -1;
            }
        }
    }
}

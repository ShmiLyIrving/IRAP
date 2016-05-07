using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC
{
    class UDFForm1Ex_30
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        #region 字段定义
        private int ctrlParameter1 = 0;
        private int ctrlParameter2 = 0;
        private int ctrlParameter3 = 0;
        private int numFactsToApply = 0;
        private int numTransToApply = 0;
        private string opNode = "";
        private string outputStr = "";
        private char splitChar = '|';
        private string strParameter1 = "";
        private string strParameter2 = "";
        private string strParameter3 = "";
        private string strParameter4 = "";
        private string strParameter5 = "";
        private string strParameter6 = "";
        private string strParameter7 = "";
        private string strParameter8 = "";
        private int errorCode = 0;
        private string errorMessage = "";
        #endregion

        #region 属性定义
        public int CtrlParameter1
        {
            get { return ctrlParameter1; }
        }

        public int CtrlParameter2
        {
            get { return ctrlParameter2; }
        }

        public int CtrlParameter3
        {
            get { return ctrlParameter3; }
        }

        public int NumFactsToApply
        {
            get { return numFactsToApply; }
            set { numFactsToApply = value; }
        }

        public int NumTransToApply
        {
            get { return numTransToApply; }
            set { numTransToApply = value; }
        }

        public string OpNode
        {
            get { return opNode; }
            set { opNode = value; }
        }

        public string OutputStr
        {
            get { return outputStr; }
        }

        public char SplitChar
        {
            get { return splitChar; }
            set { splitChar = value; }
        }

        public string StrParameter1
        {
            get { return strParameter1; }
        }

        public string StrParameter2
        {
            get { return strParameter2; }
        }

        public string StrParameter3
        {
            get { return strParameter3; }
        }

        public string StrParameter4
        {
            get { return strParameter4; }
        }

        public string StrParameter5
        {
            get { return strParameter5; }
        }

        public string StrParameter6
        {
            get { return strParameter6; }
        }

        public string StrParameter7
        {
            get { return strParameter7; }
        }

        public string StrParameter8
        {
            get { return strParameter8; }
        }

        public int ErrorCode
        {
            get { return errorCode; }
        }

        /// <summary>
        /// 运行结果信息
        /// </summary>
        public string ErrorMessage
        {
            get { return errorMessage; }
        }
        #endregion

        public void ClearOutputStr()
        {
            outputStr = "";
        }

        public void SaveOLTPUDFFormData(int processLeaf, int workUnitLeaf)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                long intTransactNo = 0;
                long intFactID = 0;

                #region 申请交易号和事实编号
                try
                {
                    intTransactNo =
                        numTransToApply == 0 ?
                            0 :
                            IRAPUTSClient.Instance.mfn_GetTransactNo(
                                IRAPUser.Instance.CommunityID,
                                numTransToApply,
                                IRAPUser.Instance.SysLogID,
                                opNode);
                    intFactID =
                        numFactsToApply == 0 ?
                            0 :
                            IRAPUTSClient.Instance.mfn_GetFactID(
                                IRAPUser.Instance.CommunityID,
                                numFactsToApply,
                                IRAPUser.Instance.SysLogID,
                                opNode);
                }
                catch (Exception error)
                {
                    throw error;
                }
                #endregion

                #region 保存
                try
                {
                    if (ctrlParameter2 >= 0)
                    {
                        IRAPUTSClient.Instance.ssp_OLTP_UDFForm(
                            IRAPUser.Instance.CommunityID,
                            intTransactNo,
                            intFactID,
                            ctrlParameter1,
                            ctrlParameter2,
                            ctrlParameter3,
                            IRAPUser.Instance.SysLogID,
                            strParameter1,
                            strParameter2,
                            strParameter3,
                            strParameter4,
                            strParameter5,
                            strParameter6,
                            strParameter7,
                            strParameter8,
                            ref outputStr,
                            out errorCode,
                            out errorMessage);
                    }
                    else
                    {
                        IRAPUTSClient.Instance.ssp_OLTP_UDFForm(
                            IRAPUser.Instance.CommunityID,
                            intTransactNo,
                            intFactID,
                            ctrlParameter1,
                            processLeaf,
                            workUnitLeaf,
                            IRAPUser.Instance.SysLogID,
                            strParameter1,
                            strParameter2,
                            strParameter3,
                            strParameter4,
                            strParameter5,
                            strParameter6,
                            strParameter7,
                            strParameter8,
                            ref outputStr,
                            out errorCode,
                            out errorMessage);
                    }
                }
                catch (Exception error)
                {
                    outputStr = "";
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    throw error;
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void SetCtrlParameter(string parameters)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            string ctrlParameter = "";

            // 确定字符串的第一个字符是否为非数字字符
            if (Char.IsNumber(parameters, 1))
            {
                splitChar = '|';
                ctrlParameter = parameters;
            }
            else
            {
                splitChar = parameters[0];
                ctrlParameter = parameters.Substring(1, parameters.Length - 1);
            }

            string[] strAfterSplit = ctrlParameter.Split(new char[] { splitChar }, StringSplitOptions.RemoveEmptyEntries);
            try { ctrlParameter1 = Convert.ToInt32(strAfterSplit[0]); }
            catch (Exception error)
            {
                WriteLog.Instance.Write(string.Format("转换第一个参数时发生错误：{0}", error.Message), strProcedureName);
                ctrlParameter1 = 0;
            }
            try { ctrlParameter2 = Convert.ToInt32(strAfterSplit[1]); }
            catch (Exception error)
            {
                WriteLog.Instance.Write(string.Format("转换第二个参数时发生错误：{0}", error.Message), strProcedureName);
                ctrlParameter2 = -1;
            }
            try { ctrlParameter3 = Convert.ToInt32(strAfterSplit[2]); }
            catch (Exception error)
            {
                WriteLog.Instance.Write(string.Format("转换第三个参数时发生错误：{0}", error.Message), strProcedureName);
                ctrlParameter3 = -1;
            }
        }

        public void SetStrParameterValue(string value, int index)
        {
            switch (index)
            {
                case 1:
                    strParameter1 = value;
                    break;
                case 2:
                    strParameter2 = value;
                    break;
                case 3:
                    strParameter3 = value;
                    break;
                case 4:
                    strParameter4 = value;
                    break;
                case 5:
                    strParameter5 = value;
                    break;
                case 6:
                    strParameter6 = value;
                    break;
                case 7:
                    strParameter7 = value;
                    break;
                case 8:
                    strParameter8 = value;
                    break;
            }
        }

        public void PrintLabel()
        {
            throw new NotImplementedException();
        }
    }
}
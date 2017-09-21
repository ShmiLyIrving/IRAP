using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.WCF.Client.Method;
using IRAP.Client.GUI.MESPDC.Actions;

namespace IRAP.Client.GUI.MESPDC
{
    class UDFForm1Ex
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

        public void SaveOLTPUDFFormData(
            int processLeaf, 
            int workUnitLeaf, 
            ExtendEventHandler extendAction,
            object tag)
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
                int ctrlParameter1 = this.ctrlParameter1;
                int ctrlParameter2 = this.ctrlParameter2;
                int ctrlParameter3 = this.ctrlParameter3;
                int ctrlParameter2_bk = 0;
                int ctrlParameter3_bk = 0;

                #region 统一防错校验
                try
                {

                    if (ctrlParameter2 >= 0)
                    {
                        ctrlParameter2_bk = ctrlParameter2;
                        ctrlParameter3_bk = ctrlParameter3;

                        IRAPUTSClient.Instance.ssp_PokaYoke_UDFForm(
                            IRAPUser.Instance.CommunityID,
                            ctrlParameter1,
                            ref ctrlParameter2,
                            ref ctrlParameter3,
                            IRAPUser.Instance.SysLogID,
                            ref strParameter1,
                            ref strParameter2,
                            ref strParameter3,
                            ref strParameter4,
                            ref strParameter5,
                            ref strParameter6,
                            ref strParameter7,
                            ref strParameter8,
                            ref outputStr,
                            out errorCode,
                            out errorMessage);
                    }
                    else
                    {
                        ctrlParameter2 = processLeaf;
                        ctrlParameter3 = workUnitLeaf;
                        ctrlParameter2_bk = ctrlParameter2;
                        ctrlParameter3_bk = ctrlParameter3;

                        IRAPUTSClient.Instance.ssp_PokaYoke_UDFForm(
                            IRAPUser.Instance.CommunityID,
                            ctrlParameter1,
                            ref ctrlParameter2,
                            ref ctrlParameter3,
                            IRAPUser.Instance.SysLogID,
                            ref strParameter1,
                            ref strParameter2,
                            ref strParameter3,
                            ref strParameter4,
                            ref strParameter5,
                            ref strParameter6,
                            ref strParameter7,
                            ref strParameter8,
                            ref outputStr,
                            out errorCode,
                            out errorMessage);
                    }
                    WriteLog.Instance.Write(
                        string.Format(
                            "{0}.{1}",
                            errorCode,
                            errorMessage),
                        strProcedureName);

                    WriteLog.Instance.Write(
                        string.Format("Output={0}", outputStr),
                        strProcedureName);
                    if (outputStr != "")
                    {
                        try
                        {
                            UDFActions.DoActions(
                                outputStr,
                                extendAction,
                                tag);
                        }
                        catch (Exception error)
                        {
                            outputStr = "";
                            WriteLog.Instance.Write(
                                string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                                    error.Message,
                                    error.StackTrace),
                                strProcedureName);
                            throw error;
                        }
                    }

                    outputStr = "";
                }
                catch (Exception err)
                {
                    outputStr = "";
                    WriteLog.Instance.Write(err.Message, strProcedureName);
                    throw err;
                }
                if (errorCode != 0)
                    return;
                #endregion

                #region 如果交易存储过程返回的 CtrlParameter2 和 CtrlParameter3 有变化，则刷新选项一和选项二
                if (ctrlParameter2 != ctrlParameter2_bk)
                    outputStr =
                        string.Format(
                            "T107LeafID=\"{0}\" ",
                            ctrlParameter2);
                else
                    outputStr = "T107LeafID=\"\" ";
                if (ctrlParameter3 != ctrlParameter3_bk)
                    outputStr +=
                        string.Format(
                            " T102LeafID=\"{1}\" ",
                            ctrlParameter3);
                else
                    outputStr += " T102LeafID=\"\" ";

                outputStr =
                    string.Format(
                        "<ROOT><Action Ordinal=\"1\" Action=\"SelectChoice\" {0}/></ROOT>",
                        outputStr);
                if (ctrlParameter2 != ctrlParameter2_bk ||
                    ctrlParameter3 != ctrlParameter3_bk)
                {
                    try
                    {
                        UDFActions.DoActions(
                            outputStr,
                            extendAction,
                            tag);
                    }
                    catch (Exception error)
                    {
                        outputStr = "";
                        WriteLog.Instance.Write(
                            string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                                error.Message,
                                error.StackTrace),
                            strProcedureName);
                        throw error;
                    }
                }
                #endregion

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
                            ref errorMessage);
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
                            ref errorMessage);
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

        public void SaveOLTPUDFFormDataWithoutFactIDAndTransactNo(
            int processLeaf,
            int workUnitLeaf,
            ExtendEventHandler extendAction,
            object tag)
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
                int ctrlParameter1 = this.ctrlParameter1;
                int ctrlParameter2 = this.ctrlParameter2;
                int ctrlParameter3 = this.ctrlParameter3;
                int ctrlParameter2_bk = 0;
                int ctrlParameter3_bk = 0;

                #region 统一防错校验
                try
                {
                    if (ctrlParameter2 >= 0)
                    {
                        ctrlParameter2_bk = ctrlParameter2;
                        ctrlParameter3_bk = ctrlParameter3;

                        IRAPUTSClient.Instance.ssp_PokaYoke_UDFForm(
                            IRAPUser.Instance.CommunityID,
                            ctrlParameter1,
                            ref ctrlParameter2,
                            ref ctrlParameter3,
                            IRAPUser.Instance.SysLogID,
                            ref strParameter1,
                            ref strParameter2,
                            ref strParameter3,
                            ref strParameter4,
                            ref strParameter5,
                            ref strParameter6,
                            ref strParameter7,
                            ref strParameter8,
                            ref outputStr,
                            out errorCode,
                            out errorMessage);
                    }
                    else
                    {
                        ctrlParameter2 = processLeaf;
                        ctrlParameter3 = workUnitLeaf;
                        ctrlParameter2_bk = ctrlParameter2;
                        ctrlParameter3_bk = ctrlParameter3;

                        IRAPUTSClient.Instance.ssp_PokaYoke_UDFForm(
                            IRAPUser.Instance.CommunityID,
                            ctrlParameter1,
                            ref ctrlParameter2,
                            ref ctrlParameter3,
                            IRAPUser.Instance.SysLogID,
                            ref strParameter1,
                            ref strParameter2,
                            ref strParameter3,
                            ref strParameter4,
                            ref strParameter5,
                            ref strParameter6,
                            ref strParameter7,
                            ref strParameter8,
                            ref outputStr,
                            out errorCode,
                            out errorMessage);
                    }
                    WriteLog.Instance.Write(
                        string.Format(
                            "{0}.{1}",
                            errorCode,
                            errorMessage),
                        strProcedureName);

                    WriteLog.Instance.Write(
                        string.Format("Output={0}", outputStr),
                        strProcedureName);
                    if (outputStr != "")
                    {
                        try
                        {
                            UDFActions.DoActions(
                                outputStr,
                                extendAction,
                                tag);
                        }
                        catch (Exception error)
                        {
                            outputStr = "";
                            WriteLog.Instance.Write(
                                string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                                    error.Message,
                                    error.StackTrace),
                                strProcedureName);
                            throw error;
                        }
                    }

                    outputStr = "";
                }
                catch (Exception err)
                {
                    outputStr = "";
                    WriteLog.Instance.Write(err.Message, strProcedureName);
                    throw err;
                }
                if (errorCode != 0)
                    return;
                #endregion

                #region 如果交易存储过程返回的 CtrlParameter2 和 CtrlParameter3 有变化，则刷新选项一和选项二
                if (ctrlParameter2 != ctrlParameter2_bk)
                    outputStr =
                        string.Format(
                            "T107LeafID=\"{0}\" ",
                            ctrlParameter2);
                else
                    outputStr = "T107LeafID=\"\" ";
                if (ctrlParameter3 != ctrlParameter3_bk)
                    outputStr +=
                        string.Format(
                            " T102LeafID=\"{1}\" ",
                            ctrlParameter3);
                else
                    outputStr += " T102LeafID=\"\" ";

                outputStr =
                    string.Format(
                        "<ROOT><Action Ordinal=\"1\" Action=\"SelectChoice\" {0}/></ROOT>",
                        outputStr);
                if (ctrlParameter2 != ctrlParameter2_bk ||
                    ctrlParameter3 != ctrlParameter3_bk)
                {
                    try
                    {
                        UDFActions.DoActions(
                            outputStr,
                            extendAction,
                            tag);
                    }
                    catch (Exception error)
                    {
                        outputStr = "";
                        WriteLog.Instance.Write(
                            string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                                error.Message,
                                error.StackTrace),
                            strProcedureName);
                        throw error;
                    }
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
                            ref errorMessage);
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
                            ref errorMessage);
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

            string[] strAfterSplit = ctrlParameter.Split(new char[] { splitChar }, StringSplitOptions.None);
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

            if (strAfterSplit.Length >= 4)
                numFactsToApply = Tools.ConvertToInt32(strAfterSplit[3], 1);
            else
                NumFactsToApply = 1;
            if (strAfterSplit.Length >= 5)
                numTransToApply = Tools.ConvertToInt32(strAfterSplit[4], 1);
            else
                NumTransToApply = 1;
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
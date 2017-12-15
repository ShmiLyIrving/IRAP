using IRAP.Entity.Kanban;
using IRAP.Entity.UTS;
using IRAP.Global;
using IRAPShared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace IRAP.WCF.Client.Method {
    public class IRAPTreeClient {
        private static IRAPTreeClient _instance = null;
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private IRAPTreeClient() {

        }

        public static IRAPTreeClient Instance {
            get {
                if (_instance == null)
                    _instance = new IRAPTreeClient();
                return _instance;
            }
        }

        /// <summary>
        /// 解析树视图控制参数
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="tvCtrlParameters">树视图控制参数</param>
        /// <param name="languageID">语言标识 </param>
        /// <returns></returns>
        public TVCtrlParam GetTreeViewCtrlParameters(
            int communityID,
            string tvCtrlParameters,
            int languageID,
            out int errCode,
            out string errText) {
            string strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("tvCtrlParameters", tvCtrlParameters);
                hashParams.Add("languageID", languageID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_TreeViewCtrlParameters 函数， " +
                        "参数：communityID={0}|tvCtrlParameters={1}|languageID={2}",
                        communityID,
                        tvCtrlParameters,
                        languageID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.Kanban.dll",
                            "IRAP.BL.Kanban.IRAPKanban",
                            "sfn_TreeViewCtrlParameters",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
                        var datas = rlt as List<TVCtrlParam>;
                        if (datas == null || datas.Count == 0) {
                            errCode = 99;
                            errText = "没有找到树视图控制参数，请检查配置！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                            return null;
                        }
                        return datas[0];
                    }
                }
                #endregion
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        public List<LinkedTreeTip> GetLinkedTreeOfImpExp(int communityID, int t19LeafID, long sysLogID,
            out int errCode,out string errText) {
            string strProcedureName =
               string.Format("{0}.{1}",className,MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("t19LeafID", t19LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(string.Format(
                        "调用 sfn_GetInfo_LinkedTreeOfImpExp 函数，参数：communityID={0}|t19LeafID={1}|sysLogID={2} ",
                        communityID, t19LeafID, sysLogID));
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.UTS.dll",
                            "IRAP.BL.UTS.GeneralImport",
                            "sfn_GetInfo_LinkedTreeOfImpExp",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
                        var datas = rlt as List<LinkedTreeTip>;
                        if (datas == null || datas.Count == 0) {
                            errCode = 99;
                            errText = "没有找到树视图，请检查配置！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                            return null;
                        }
                        return datas;
                    }
                }
                #endregion
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        public List<LeafSet> GetAccessibleFilteredLeafSet(int communityID, int treeID, int scenarioIndex,
            string dicingFilter, int nodeDepth, string keyword, long sysLogID,out int errCode, out string errText) {
            string strProcedureName =
               string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("treeID", treeID);
                hashParams.Add("scenarioIndex", scenarioIndex);
                hashParams.Add("dicingFilter", dicingFilter);
                hashParams.Add("nodeDepth",  nodeDepth);
                hashParams.Add("keyword",  keyword);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(string.Format(
                        "调用 sfn_AccessibleFilteredLeafSet 函数，参数：communityID={0}|treeID={1}|scenarioIndex={2}|dicingFilter={3}|nodeDepth={4}|keyword={5}|sysLogID={6}",
                        communityID, treeID, scenarioIndex, dicingFilter, nodeDepth, keyword, sysLogID));
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.UTS.dll",
                            "IRAP.BL.UTS.GeneralImport",
                            "sfn_AccessibleFilteredLeafSet",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
                        var datas = rlt as List<LeafSet>;
                        if (datas == null || datas.Count == 0) {
                            errCode = 99;
                            errText = "没有找到树视图，请检查配置！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                            return null;
                        }
                        return datas;
                    }
                }
                #endregion
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        public string GetImportInfoXml(int communityID, int t19LeafID, int txLeafID,
             long sysLogID, out int errCode, out string errText) {
            string strProcedureName =
               string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("t19LeafID", t19LeafID);
                hashParams.Add("txLeafID", txLeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(string.Format(
                        "调用 sfn_GetXML_ImportInfo 函数，参数：communityID={0}|t19LeafID={1}|txLeafID={2}|sysLogID={3}",
                        communityID, t19LeafID, txLeafID, sysLogID));
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.UTS.dll",
                            "IRAP.BL.UTS.GeneralImport",
                            "sfn_GetXML_ImportInfo",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
                        var datas = rlt as List<string>;
                        if (datas == null||datas.Count == 0||string.IsNullOrEmpty(datas[0])) {
                            errCode = 99;
                            errText = "没有找到导入信息XML报文！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                            return null;
                        }
                        return datas[0];
                    }
                }
                #endregion
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }



        public void GetImportInfoEntity(int communityID, int t19LeafID, int treeID, int txLeafID,
             long sysLogID, out ImportParam param, out List<ImportMetaData> metaDatas, out int errCode, out string errText) {
            string strProcedureName =
               string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            errCode = 0;
            param = null;
            metaDatas = new List<ImportMetaData>();
            var xmlStr = GetImportInfoXml(communityID, t19LeafID, txLeafID, sysLogID, out errCode, out errText);
            if (errCode != 0 || string.IsNullOrEmpty(xmlStr)) {
                return;
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);
            //使用xpath表达式选择文档中所有的student子节点
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("Result").ChildNodes;
            if (nodeList == null) {
                errCode = 9999;
                errText = "没有找到Result节点，请检查！";
                WriteLog.Instance.Write(errText, strProcedureName);
                return;
            }
            foreach (XmlNode childNode in nodeList) {
                XmlElement childElement = (XmlElement)childNode;
                if (childElement.Name == "Param") {
                    param = new ImportParam();
                    param.FlagFilePath = childElement.Attributes["FlagFilePath"].Value;
                    param.DataFilePath = childElement.Attributes["DataFilePath"].Value;
                    param.FileNamePrefix = childElement.Attributes["FileNamePrefix"].Value;
                    param.FileExtensionName = childElement.Attributes["FileExtensionName"].Value;
                    param.FormatFileName = childElement.Attributes["FormatFileName"].Value;
                    param.DstTableName = childElement.Attributes["DstTableName"].Value;
                    param.DstTableExist = childElement.Attributes["DstTableExist"].Value;
                    param.ProcToCreateTBL = childElement.Attributes["ProcToCreateTBL"].Value;
                    param.ToolTip = childElement.Attributes["ToolTip"].Value;
                    param.ProcOnVerification = childElement.Attributes["ProcOnVerification"].Value;
                    param.PartialLoadPermitted = childElement.Attributes["PartialLoadPermitted"].Value;
                    param.ProcOnLoad = childElement.Attributes["ProcOnLoad"].Value;
                }
                if (childElement.Name == "MetaData") {
                    XmlNodeList datalist = childElement.ChildNodes;
                    foreach (XmlNode dataNode in datalist) {
                        ImportMetaData metaData = new ImportMetaData();
                        XmlElement data = (XmlElement)dataNode;
                        metaData.Ordinal = int.Parse(data.Attributes["Ordinal"].Value);
                        metaData.ColName = data.Attributes["ColName"].Value;
                        metaData.ColDisplayName = data.Attributes["ColDisplayName"].Value;
                        metaData.ColType = data.Attributes["ColType"].Value;
                        metaData.Length = int.Parse(data.Attributes["Length"].Value);
                        metaData.Prec = int.Parse(data.Attributes["Prec"].Value);
                        metaData.Scale = int.Parse(data.Attributes["Scale"].Value);
                        metaData.Nullable = int.Parse(data.Attributes["Nullable"].Value);
                        metaData.Alignment = data.Attributes["Alignment"].Value;
                        metaData.DisplayWidth = int.Parse(data.Attributes["DisplayWidth"].Value);
                        metaData.EditEnabled = int.Parse(data.Attributes["EditEnabled"].Value);
                        metaData.Visible = data.Attributes["Visible"].Value;
                        metaDatas.Add(metaData);
                    }
                }
            }

            if (!ImportParaValidate(param, out errText)) {
                errCode = 9999;
                WriteLog.Instance.Write(errText, strProcedureName);
                return;
            }
            if (Convert.ToInt32(param.DstTableExist)==0) {
                CreateTable(communityID, t19LeafID, treeID, txLeafID, sysLogID, param.ProcToCreateTBL, out errCode, out errText);
                if (errCode!=0) {
                    WriteLog.Instance.Write(errText, strProcedureName);
                    return;
                }
                GetImportInfoEntity(communityID, t19LeafID, treeID, txLeafID, sysLogID, out param, out metaDatas, out errCode, out errText);
            }
            if (!ImportMetaDataValidate(metaDatas, out errText)) {
                errCode = 9999;
                WriteLog.Instance.Write(errText, strProcedureName);
                return;
            }

            errText = "成功获取导入的xml信息！";
            WriteLog.Instance.Write(errText, strProcedureName);
            return;
        }
           

        private bool ImportParaValidate(ImportParam para,out string errText) {
            errText = "";
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            if (para==null) {
                errText = "获取的XML报文不完整，请重新配置！";
                WriteLog.Instance.Write(errText, strProcedureName);
                return false;
            }
            if (string.IsNullOrEmpty(para.DstTableName)) {
                errText = "目标表名不存在";
                WriteLog.Instance.Write(errText, strProcedureName);
                return false;
            }
            if (string.IsNullOrEmpty(para.ProcOnVerification)) {
                errText = "检验的存储过程为空！请重新配置";
                WriteLog.Instance.Write(errText, strProcedureName);
                return false;
            }
            if (string.IsNullOrEmpty(para.ProcOnLoad)) {
                errText = "加载存储过程为空！请重新配置";
                WriteLog.Instance.Write(errText, strProcedureName);
                return false;
            }
            if (Convert.ToInt32(para.DstTableExist)==1) {
                return true;
            }
            //如果表名不为空，并且目标表不存在，就创建表
            if (string.IsNullOrEmpty(para.ProcToCreateTBL)) {
                errText = " 创建表的存储过程不存在，请重新配置！";
                WriteLog.Instance.Write(errText, strProcedureName);
                return false;
            }
            return true;
        }

        private bool ImportMetaDataValidate(List<ImportMetaData> metaDatas, out string errText) {
            string strProcedureName =string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);

            errText = "";
            if (metaDatas==null||metaDatas.Count==0) {
                errText = "表头数据为空！请配置表头！";
                WriteLog.Instance.Write(errText, strProcedureName);
                return false;
            }
            return true;
        }

        private void CreateTable(int communityID, int t19LeafID, int treeID, int txLeafID,
            long sysLogID, string blName, out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);

            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("t19LeafID", t19LeafID);
                hashParams.Add("treeID", treeID);
                hashParams.Add("txLeafID", txLeafID);
                hashParams.Add("sysLogID", sysLogID);
                hashParams.Add("blName", blName);
                WriteLog.Instance.Write(string.Format(
                        "调用 sfn_Get_ProcToCreateTBL 存储过程，参数：communityID={0}|t19LeafID={1}|treeID={2}|txLeafID={3}|sysLogID={4}|blName={5}",
                        communityID, t19LeafID, treeID, txLeafID, sysLogID, blName));
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.UTS.dll",
                            "IRAP.BL.UTS.GeneralImport",
                            "sfn_Get_ProcToCreateTBL",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    var err = rlt as List<IRAPError>;
                    errCode = err[0].ErrCode;
                    errText = err[0].ErrText;
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion
            } catch (Exception ex) {
                WriteLog.Instance.Write(ex.Message, strProcedureName);
                errCode = -1001;
                errText = ex.Message;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public List<IRAPTreeViewNode> GetTreeViewList(
            int communityID,
            long sysLogID,
            TVCtrlParam ctrlPara,
            out int errCode,
            out string errText) {
            string strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("irapTreeID", ctrlPara.IRAPTreeID);
                hashParams.Add("treeViewType", ctrlPara.TreeViewType);
                hashParams.Add("entryNode", ctrlPara.EntryNode);
                hashParams.Add("ditvCtrlVar", ctrlPara.DITVCtrlVar);
                hashParams.Add("dstvCtrlBlk", ctrlPara.DSTVCtrlBlk);
                hashParams.Add("filterClickStream", ctrlPara.FilterClickStream);
                hashParams.Add("selectClickStream", ctrlPara.SelectClickStream);
                hashParams.Add("sysLogID", sysLogID);
                hashParams.Add("orderByMode", ctrlPara.OrderByMode);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_TreeViewCtrlParameters 函数， " +
                        "参数：communityID={0}|irapTreeID={1}|treeViewType={2}|entryNode={3}|ditvCtrlVar={4}|dstvCtrlBlk={5}|filterClickStream={6}|selectClickStream={7}|sysLogID={8}",
                        communityID, ctrlPara.IRAPTreeID,
                        ctrlPara.TreeViewType, ctrlPara.EntryNode, ctrlPara.DITVCtrlVar,
                        ctrlPara.DSTVCtrlBlk, ctrlPara.FilterClickStream, ctrlPara.SelectClickStream,
                        ctrlPara.OrderByMode, strProcedureName));
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.Kanban.dll",
                            "IRAP.BL.Kanban.IRAPKanban",
                            "sfn_IRAPTreeView",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
                        var datas = rlt as List<IRAPTreeViewNode>;
                        if (datas == null || datas.Count == 0) {
                            errCode = 99;
                            errText = "没有找到树视图，请检查配置！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                            return null;
                        }
                        return datas;
                    }
                }
                #endregion
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        public void DeleteOldTableData(string tableName, long importLogId, out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);

            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("tableName", tableName);
                hashParams.Add("importLogId", importLogId);
                WriteLog.Instance.Write(
                    string.Format("执行SQL delete from IRAPDPA..{0} where ImportLogID ={1}", tableName, importLogId),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.UTS.dll",
                            "IRAP.BL.UTS.GeneralImport",
                            "DeleteOldTableData",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    var err = rlt as List<IRAPError>;
                    errCode = err[0].ErrCode;
                    errText = err[0].ErrText;
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion
            } catch (Exception ex) {
                WriteLog.Instance.Write(ex.Message, strProcedureName);
                errCode = -1001;
                errText = ex.Message;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }


        public void InsertTempTableData(string tableName, DataTable data, out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);

            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("tableName", tableName);
                hashParams.Add("data", data);
                WriteLog.Instance.Write(string.Format("将数据插入临时表{0}中", tableName),strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.UTS.dll",
                            "IRAP.BL.UTS.GeneralImport",
                            "InsertTempTableData",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    var err = rlt as List<IRAPError>;
                    errCode = err[0].ErrCode;
                    errText = err[0].ErrText;
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion
            } catch (Exception ex) {
                WriteLog.Instance.Write(ex.Message, strProcedureName);
                errCode = -1001;
                errText = ex.Message;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
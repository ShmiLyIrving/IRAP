using IRAP.Entity.Kanban;
using IRAP.Entity.UTS;
using IRAP.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

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
    }
}
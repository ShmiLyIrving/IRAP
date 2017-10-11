using IRAPORM;
using IRAPShared;
using MESPDC.Areas.MESPDC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MESPDC.Areas.MESPDC.Controllers
{
    public class SerachController : EnvController
    {
        #region 获取可访问叶集
        /// <summary>
        /// 获取可访问叶集(带名称)
        /// </summary>
        /// <returns></returns>
        public ActionResult Get_AccessibleLeafSetEx() 
        {
            long CommunityID = this.CommunityID;
            long SysLogID = this.SysLogID;
            int errCode = 0;
            string errText = "";
            try
            {
                Int16 TreeID = Int16.Parse(Request["TreeID"].ToString());
                int ScenarioIndex = int.Parse(Request["ScenarioIndex"].ToString());
                IList<IDataParameter> oraParam = new List<IDataParameter>(4);
                oraParam.Add(new IRAPProcParameter("CommunityID", DbType.Int32, CommunityID));
                oraParam.Add(new IRAPProcParameter("TreeID",DbType.Int16,TreeID));
                oraParam.Add(new IRAPProcParameter("ScenarioIndex", DbType.Int32, ScenarioIndex));
                oraParam.Add(new IRAPProcParameter("SysLogID", DbType.Int64, SysLogID));
                IRAPSQLConnection conn = new IRAPSQLConnection();
                IList<AccessibleModel> list = conn.CallTableFunc<AccessibleModel>("select * from IRAP..sfn_AccessibleLeafSetEx(@CommunityID,@TreeID,@ScenarioIndex,@SysLogID)",
                oraParam);
                conn.Close();
                errCode = 0;
                errText = "获取完成！";
                return Json(new { errCode = errCode,errText=errText,DataList=list},JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) 
            {
                return Json(new {errCode=9999,errText=ex.Message},JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 获取工序
        /// <summary>
        /// 获取工序
        /// </summary>
        /// <returns></returns>

        public ActionResult GetList_ProcessOfProductLine() 
        {
            long CommunityID = this.CommunityID;
            long SysLogID = this.SysLogID;
            int errCode = 0;
            string errText = "";
            try
            {
                int ProductLineID = 0;
                try
                {
                    ProductLineID = int.Parse(Request["ProductLineID"].ToString());
                }
                catch
                {
                    ProductLineID = 0;
                }

                IList<IDataParameter> oraParam = new List<IDataParameter>(3);
                oraParam.Add(new IRAPProcParameter("CommunityID", DbType.Int32, CommunityID));
                oraParam.Add(new IRAPProcParameter("ProductLineID",DbType.Int32,ProductLineID));
                oraParam.Add(new IRAPProcParameter("SysLogID",DbType.Int64,SysLogID));
                IRAPSQLConnection conn = new IRAPSQLConnection();
                IList<ProductLineModel> list = conn.CallTableFunc<ProductLineModel>("select * from IRAPMDM..ufn_GetList_ProcessOfProductLine(@CommunityID,@ProductLineID,@SysLogID)",oraParam);
                conn.Close();
                errCode = 0;
                errText = "获取完成";
                return Json(new { errCode=errCode,errText=errText,DataList=list},JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { errCode = 9999, errText = ex.Message },JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 获取检验类型
        public ActionResult GetList_InspectType()
        {
            long CommunityID = this.CommunityID;
            long SysLogID = this.SysLogID;
            int errCode = 0;
            string errText = "";
            try
            {
                int T134LeafID = 0;
                try
                {
                    T134LeafID = int.Parse(Request["T134LeafID"].ToString());
                }
                catch
                {
                    T134LeafID = 0;
                }

                int T216LeafID = 0;
                try
                {
                    T216LeafID = int.Parse(Request["T216LeafID"].ToString());
                }
                catch
                {
                    T216LeafID = 0;
                }
                IList<IDataParameter> oraParam = new List<IDataParameter>(4);
                oraParam.Add(new IRAPProcParameter("CommunityID", DbType.Int32, CommunityID));
                oraParam.Add(new IRAPProcParameter("T134LeafID", DbType.Int32, T134LeafID));
                oraParam.Add(new IRAPProcParameter("T216LeafID", DbType.Int32, T216LeafID));
                oraParam.Add(new IRAPProcParameter("SysLogID", DbType.Int64, SysLogID));
                IRAPSQLConnection conn = new IRAPSQLConnection();
                IList<InspectType_S_Model> list = conn.CallTableFunc<InspectType_S_Model>("select * from IRAPMES..ufn_GetList_InspectType(@CommunityID,@T134LeafID,@T216LeafID,@SysLogID)", oraParam);
                conn.Close();
                errCode = 0;
                errText = "获取完成";
                return Json(new { errCode = errCode, errText = errText, DataList = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { errCode = 9999, errText = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 获取工单号
        /// <summary>
        /// 获取工单号
        /// </summary>
        public ActionResult GetFactList_InspectToPWO()

        {
            long CommunityID = this.CommunityID;
            long SysLogID = this.SysLogID;
            int errCode = 0;
            string errText = "";
            try {
                int T134LeafID = 0;
                try
                {
                    T134LeafID = int.Parse(Request["T134LeafID"].ToString());
                }
                catch
                {
                    T134LeafID = 0;
                }

                int T216LeafID = 0;
                try
                {
                   T216LeafID = int.Parse(Request["T216LeafID"].ToString());
                }
                catch 
                {
                    T216LeafID = 0;
                }
                int InspectType = 0;
                try
                {
                    InspectType = int.Parse(Request["InspectType"].ToString());
                }
                catch{
                    InspectType = 0;
                }
                IList<IDataParameter> oraParam = new List<IDataParameter>(5);
                oraParam.Add(new IRAPProcParameter("CommunityID", DbType.Int32, CommunityID));
                oraParam.Add(new IRAPProcParameter("T134LeafID", DbType.Int32, T134LeafID));
                oraParam.Add(new IRAPProcParameter("T216LeafID", DbType.Int32, T216LeafID));
                oraParam.Add(new IRAPProcParameter("InspectType", DbType.Int32, InspectType));
                oraParam.Add(new IRAPProcParameter("SysLogID", DbType.Int64, SysLogID));
                IRAPSQLConnection conn = new IRAPSQLConnection();
                IList<InspectToPWOModel> list = conn.CallTableFunc<InspectToPWOModel>("select * from IRAPMES..ufn_GetFactList_InspectToPWO(@CommunityID,@T134LeafID,@T216LeafID,@InspectType,@SysLogID)", oraParam);
                conn.Close();
                errCode = 0;
                errText = "获取完成";
                return Json(new { errCode = errCode, errText = errText, DataList = list }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { errCode = 9999, errText = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 获取Table名称
        public ActionResult GetList_InspectTypeOfProcess() 
        {
            long CommunityID = this.CommunityID;
            long SysLogID = this.SysLogID;
            int errCode = 0;
            string errText = "";
            try
            {
                int T134LeafID = 0;
                try
                {
                    T134LeafID = int.Parse(Request["T134LeafID"].ToString());
                }
                catch 
                {
                    T134LeafID = 0;
                }

                int T216LeafID = 0;
                try
                {
                    T216LeafID = int.Parse(Request["T216LeafID"].ToString());
                }
                catch 
                {
                    T216LeafID = 0;
                }
                int InspectType = 0;
                try
                {
                    InspectType =int.Parse(Request["InspectType"].ToString());
                }
                catch
                {
                    InspectType = 0;
                }
                IList<IDataParameter> oraParam = new List<IDataParameter>(5);
                oraParam.Add(new IRAPProcParameter("CommunityID", DbType.Int32, CommunityID));
                oraParam.Add(new IRAPProcParameter("T134LeafID", DbType.Int32, T134LeafID));
                oraParam.Add(new IRAPProcParameter("T216LeafID", DbType.Int32, T216LeafID));
                oraParam.Add(new IRAPProcParameter("InspectType", DbType.Int32, InspectType));
                oraParam.Add(new IRAPProcParameter("SysLogID", DbType.Int64, SysLogID));
                IRAPSQLConnection conn = new IRAPSQLConnection();
                IList<InspectTypeModel> list = conn.CallTableFunc<InspectTypeModel>("select * from IRAPMES..ufn_GetList_InspectTypeOfProcess(@CommunityID,@T134LeafID,@T216LeafID,@InspectType,@SysLogID)", oraParam);
                conn.Close();
                errCode = 0;
                errText = "获取完成";
                return Json(new { errCode = errCode, errText = errText, DataList = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { errCode = 9999, errText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 获取Tab内容
        public ActionResult GetList_MethodParameters()
        {
            long CommunityID = this.CommunityID;
            long SysLogID = this.SysLogID;
            int errCode = 0;
            string errText = "";
            try
            {
                int T134LeafID = 0;
                try
                {
                    T134LeafID = int.Parse(Request["T134LeafID"].ToString());
                }
                catch
                {
                    T134LeafID = 0;
                }

                int T216LeafID = 0;
                try
                {
                    T216LeafID = int.Parse(Request["T216LeafID"].ToString());
                }
                catch
                {
                    T216LeafID = 0;
                }
                int InspectType = 0;
                try
                {
                    InspectType = int.Parse(Request["InspectType"].ToString());
                }
                catch
                {
                    InspectType = 0;
                }
                string PWONo = Request["PWONo"].ToString();
                int InspectTab = 0;
                try
                {
                    InspectTab = int.Parse(Request["InspectTab"].ToString());
                }
                catch 
                {
                    InspectTab = 0;
                }
                IList<IDataParameter> oraParam = new List<IDataParameter>(7);
                oraParam.Add(new IRAPProcParameter("CommunityID", DbType.Int32, CommunityID));
                oraParam.Add(new IRAPProcParameter("T134LeafID", DbType.Int32, T134LeafID));
                oraParam.Add(new IRAPProcParameter("T216LeafID", DbType.Int32, T216LeafID));
                oraParam.Add(new IRAPProcParameter("InspectType", DbType.Int32, InspectType));
                oraParam.Add(new IRAPProcParameter("PWONo", DbType.String, PWONo));
                oraParam.Add(new IRAPProcParameter("InspectTab", DbType.Int32, InspectTab));
                oraParam.Add(new IRAPProcParameter("SysLogID", DbType.Int64, SysLogID));
                IRAPSQLConnection conn = new IRAPSQLConnection();
                IList<MethodParametersModel> list = conn.CallTableFunc<MethodParametersModel>("select * from IRAPMES..ufn_GetList_MethodParameters(@CommunityID,@T134LeafID,@T216LeafID,@InspectType,@PWONo,@InspectTab,@SysLogID)", oraParam);
                conn.Close();
                errCode = 0;
                errText = "获取完成";
                return Json(new { errCode = errCode, errText = errText, DataList = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { errCode = 9999, errText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region 验证
        public ActionResult GetList_MethodStandard() 
        {
            int Coummuntity = this.CommunityID;
            long SysLogID = this.SysLogID;
            int errCode = 0;
            string errText = "";
            try
            {
                int T102LeafID = 0;
                try { T102LeafID = int.Parse(Request["T102LeafID"].ToString()); }
                catch { T102LeafID = 0; }
                int T216LeafID = 0;
                try { T216LeafID = int.Parse(Request["T216LeafID"].ToString()); }
                catch { T216LeafID = 0; }
                IList<IDataParameter> oraParam = new List<IDataParameter>(4);
                oraParam.Add(new IRAPProcParameter("CommunityID", DbType.Int32, CommunityID));
                oraParam.Add(new IRAPProcParameter("T102LeafID", DbType.Int32, T102LeafID));
                oraParam.Add(new IRAPProcParameter("T216LeafID", DbType.Int32, T216LeafID));;
                oraParam.Add(new IRAPProcParameter("SysLogID", DbType.Int64, SysLogID));
                IRAPSQLConnection conn = new IRAPSQLConnection();
                IList<MethodStandardModel> list = conn.CallTableFunc<MethodStandardModel>("select * from IRAPMES..ufn_GetList_MethodStandard(@CommunityID,@T102LeafID,@T216LeafID,@SysLogID)", oraParam);
                conn.Close();
                errCode = 0;
                errText = "获取完成";
                return Json(new { errCode = errCode, errText = errText, DataList = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { errCode = 9999, errText = ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 保存
        public JsonResult SaveFact_ManualInspecting_ForNCD() 
        {
            long CommunityID = this.CommunityID;
            long SysLogID = this.SysLogID;
            int errCode = 0;
            string errText = "";
            try
            {
                Int64 TransactNo = GetTransactNo("-6",out errCode,out errText); //申请到的交易号
                if (errCode != 0)
                {
                    return Json(new {errCode=errCode,errText=errText },JsonRequestBehavior.AllowGet);
                }
                Int64 FactID = GetFactID(1,out errCode,out errText);//申请到的事实编号；
                if (errCode != 0)
                {
                    return Json(new {errCode=errCode,errText=errText},JsonRequestBehavior.AllowGet);
                }
                int QCType = 0;
                try { QCType = int.Parse(Request["QCType"].ToString());}//检验类型 
                catch { QCType = 0; }
                int T102LeafID = 0;
                try { T102LeafID=int.Parse(Request["T102LeafID"].ToString());}//产品叶标识
                catch{T102LeafID=0;}
                int T107LeafID = 0;
                try { T107LeafID = int.Parse(Request["T107LeafID"].ToString()); }//工位叶标识
                catch{T107LeafID=0;}
                Int64 InspectedQty = Int64.Parse(Request["InspectedQty"].ToString());//检查数量
                string ContainerNo = Request["ContainerNo"].ToString();//容器编号
                string LotNumber = Request["LotNumber"].ToString();//生产批次号
                string PWONo = Request["PWONo"].ToString();//生产工单号
                string MONo = Request["MONo"].ToString();//制造订单号
                string insertStr = Request["Data"].ToString();
                dynamic ja = JsonConvert.DeserializeObject(insertStr);
                string xmlStr = "<RSFact>";
                string LotXml = string.Empty;
                for (var i = 0; i < ja.Count;i++)
                {
                    LotXml += "<RF6_2  Ordinal=\"" + ja[i].Ordinal + "\"  T20LeafID=\"" + ja[i].ParameterID + "\" Metric01=\"" + (ja[i].Sample01 == null ? "-999999" : ja[i].Sample01 )+ "\"  Metric02=\"" + (ja[i].Sample02 ==null? "-999999" : ja[i].Sample02) + "\" " +
                        " Metric03=\"" + (ja[i].Sample03 == null ? "-999999":ja[i].Sample03)+ "\" Metric04=\"" + (ja[i].Sample04 == null ? "-999999" : ja[i].Sample04) + "\" Metric05=\"" + (ja[i].Sample05 == null? "-999999" : ja[i].Sample05) + "\"   Metric06=\"" +(ja[i].Sample06 == null? "-999999" : ja[i].Sample06 )+ "\"  Metric07=\"" + (ja[i].Sample07 ==null? "-999999" : ja[i].Sample07 )+ "\"  Metric08=\"" + (ja[i].Sample08 == null ? "-999999" : ja[i].Sample08 )+ "\"   Conclusion=\"P\">" +
                       "</RF6_2>";
                }
                xmlStr = xmlStr + LotXml + "</RSFact>";
                IRAPSQLConnection sqlConn = new IRAPSQLConnection();
                IList<IDataParameter> list1 = new List<IDataParameter>();
                IRAPProcParameter param1 = new IRAPProcParameter("@CommunityID", DbType.Int32, CommunityID);
                list1.Add(param1);
                IRAPProcParameter param2 = new IRAPProcParameter("@TransactNo", DbType.Int64, TransactNo);
                list1.Add(param2);
                IRAPProcParameter param3 = new IRAPProcParameter("@FactID", DbType.Int64, FactID);
                list1.Add(param3);
                IRAPProcParameter param4 = new IRAPProcParameter("@QCType", DbType.Int32, QCType);
                list1.Add(param4);
                IRAPProcParameter param5 = new IRAPProcParameter("@T102LeafID", DbType.Int32, T102LeafID);
                list1.Add(param5);
                IRAPProcParameter param6 = new IRAPProcParameter("@T107LeafID", DbType.Int32, T107LeafID);
                list1.Add(param6);
                IRAPProcParameter param7 = new IRAPProcParameter("@InspectedQty", DbType.Int64, InspectedQty);
                list1.Add(param7);
                IRAPProcParameter param8 = new IRAPProcParameter("@ContainerNo", DbType.String, ContainerNo);
                list1.Add(param8);
                IRAPProcParameter param9 = new IRAPProcParameter("@LotNumber", DbType.String, LotNumber);
                list1.Add(param9);
                IRAPProcParameter param10 = new IRAPProcParameter("@PWONo", DbType.String, PWONo);
                list1.Add(param10);
                IRAPProcParameter param11 = new IRAPProcParameter("@MONo", DbType.String, MONo);
                list1.Add(param11);
                IRAPProcParameter param12 = new IRAPProcParameter("@RSFactXML", DbType.Xml, xmlStr);
                list1.Add(param12);
                IRAPProcParameter param13 = new IRAPProcParameter("@SysLogID", DbType.Int64, SysLogID);
                list1.Add(param13);
                IRAPProcParameter param14 = new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4);
                list1.Add(param14);
                IRAPProcParameter param15 = new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 800);
                list1.Add(param15);
                IRAPError errInfo = sqlConn.CallProc("IRAPMES..usp_SaveFact_ManualInspecting_ForNCD", ref list1);
                errCode = errInfo.ErrCode;
                errText = errInfo.ErrText;
                return Json(new { errCode = errCode, errText = errText }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                IRAPSQLConnection.WriteLocalMsg("IRAPMES..usp_SaveFact_ManualInspecting_ForNCD异常：" + ex.Message, MsgType.error);
                return Json(new{errCode=999,errText=ex.Message},JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


        #region 验证输入的数据是否正确
        public JsonResult Check_ForNCD()
        {
           try{
               int errCode = 0;
               string errText = "";
               string checkData = Request["rowstr"];
               DataTable dt = JsonConvert.DeserializeObject<DataTable>(checkData);
               IList<MethodParametersModel_String> MList=new List<MethodParametersModel_String>();
               //dynamic ja = JsonConvert.DeserializeObject(checkData);
               foreach(DataRow dr in dt.Rows)
               {
                   MethodParametersModel_String list = new MethodParametersModel_String();
                   list.Ordinal =Convert.ToInt32(dr["Ordinal"]);
                   list.ParameterName = dr["ParameterName"].ToString();
                   list.ParameterID =Convert.ToInt32(dr["ParameterID"].ToString());
                   if (dr["Sample01"].ToString()== "-999999")
                   {
                       list.Sample01 =dr["Sample01"].ToString();
                   }
                   else
                   {
                       if (dr["Sample01"].ToString()== "0" || dr["Sample01"].ToString()=="")
                       {
                           list.ErrCode = 9999;
                           list.ErrText = "样品01不能为空";
                           list.Sample01 = dr["Sample01"].ToString();
                       }
                       else
                       {
                           list.Sample01 = dr["Sample01"].ToString();
                       }
                   }

                   if (dr["Sample02"].ToString() == "-999999")
                   {
                       list.Sample02 = dr["Sample02"].ToString();
                   }
                   else
                   {
                       if (dr["Sample02"].ToString() == "0" || dr["Sample02"].ToString() == "")
                       {
                           list.ErrCode = 9999;
                           list.ErrText = "样品02不能为空";
                           list.Sample02 = dr["Sample02"].ToString();
                       }
                       else
                       {
                           list.Sample02 = dr["Sample02"].ToString();
                       }
                   }
                   if (dr["Sample03"].ToString() == "-999999")
                   {
                       list.Sample03 = dr["Sample03"].ToString();
                   }
                   else
                   {
                       if (dr["Sample03"].ToString() == "0" || dr["Sample03"].ToString() == "")
                       {
                           list.ErrCode = 9999;
                           list.ErrText = "样品03不能为空";
                           list.Sample03= dr["Sample03"].ToString();
                       }
                       else
                       {
                           list.Sample03 = dr["Sample03"].ToString();
                       }
                   }

                   if (dr["Sample04"].ToString() == "-999999")
                   {
                       list.Sample04 = dr["Sample04"].ToString();
                   }
                   else
                   {
                       if (dr["Sample04"].ToString() == "0" || dr["Sample04"].ToString() == "")
                       {
                           list.ErrCode = 9999;
                           list.ErrText = "样品04不能为空";
                           list.Sample04 = dr["Sample04"].ToString();
                       }
                       else
                       {
                           list.Sample04 = dr["Sample04"].ToString();
                       }
                   }
                   if (dr["Sample05"].ToString() == "-999999")
                   {
                       list.Sample05= dr["Sample05"].ToString();
                   }
                   else
                   {
                       if (dr["Sample05"].ToString() == "0" || dr["Sample05"].ToString() == "")
                       {
                           list.ErrCode = 9999;
                           list.ErrText = "样品05不能为空";
                           list.Sample05 = dr["Sample05"].ToString();
                       }
                       else
                       {
                           list.Sample05 = dr["Sample05"].ToString();
                       }
                   }

                   if (dr["Sample06"].ToString() == "-999999")
                   {
                       list.Sample06 = dr["Sample06"].ToString();
                   }
                   else
                   {
                       if (dr["Sample06"].ToString() == "0" || dr["Sample06"].ToString() == "")
                       {
                           list.ErrCode = 9999;
                           list.ErrText = "样品06不能为空";
                           list.Sample06 = dr["Sample06"].ToString();
                       }
                       else
                       {
                           list.Sample06 = dr["Sample06"].ToString();
                       }
                   }

                   if (dr["Sample07"].ToString() == "-999999")
                   {
                       list.Sample07 = dr["Sample07"].ToString();
                   }
                   else
                   {
                       if (dr["Sample07"].ToString() == "0" || dr["Sample07"].ToString() == "")
                       {
                           list.ErrCode = 9999;
                           list.ErrText = "样品07不能为空";
                           list.Sample07 = dr["Sample07"].ToString();
                       }
                       else
                       {
                           list.Sample07 = dr["Sample07"].ToString();
                       }
                   }

                   if (dr["Sample08"].ToString() == "-999999")
                   {
                       list.Sample08 = dr["Sample08"].ToString();
                   }
                   else
                   {
                       if (dr["Sample08"].ToString() == "0" || dr["Sample08"].ToString() == "")
                       {
                           list.ErrCode = 9999;
                           list.ErrText = "样品08不能为空";
                           list.Sample08 = dr["Sample08"].ToString();
                       }
                       else
                       {
                           list.Sample08 = dr["Sample08"].ToString();
                       }
                   }
                   MList.Add(list);
               }
               string result = JsonConvert.SerializeObject(MList);
               errText = "验证通过";
               return Json(new { errCode = errCode, errText = errText, Data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
               
                return Json(new { errCode = 999, errText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

    }
}
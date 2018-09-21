using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using System.Dynamic;

using IRAP.Global;
using IRAP.DBUtility;
using IRAPGeneralGateway.Entities;

namespace IRAPGeneralGateway
{
    /// <summary>
    /// IRAP 通用 WebAPI 服务类
    /// </summary>
    public class TIRAPGeneralWebAPIService : IIRAPWebAPI
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static DateTime _lastTime = DateTime.Now;
        /// <summary>
        /// 当前的客户端连接数
        /// </summary>
        private static int _connectedCount = 0;
        /// <summary>
        /// 每秒允许的最大客户端连接数
        /// </summary>
        private int _maxConnectedPerSecond = 10;
        /// <summary>
        /// 当前服务连接的数据库类型
        /// </summary>
        private TDBServerType _dbType = TDBServerType.SQLServer;

        private static Dictionary<string, DateTime> _accessList =
            new Dictionary<string, DateTime>();

        /// <summary>
        /// 服务中的令牌清单
        /// </summary>
        public static Dictionary<string, DateTime> AccessList
        {
            get { return _accessList; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public TIRAPGeneralWebAPIService()
        {
        }

        /// <summary>
        /// 验证消息报文格式是否被支持
        /// </summary>
        /// <param name="msgFormat"></param>
        /// <returns></returns>
        private bool MsgFormatValidate(string msgFormat)
        {
            switch (msgFormat.ToUpper())
            {
                case "JSON":
                case "XML":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// 创建错误信息流
        /// </summary>
        /// <param name="exCode">交易代码</param>
        /// <param name="clientID">客户端标识</param>
        /// <param name="msgFormat">消息格式</param>
        /// <param name="errCode">错误代码</param>
        /// <param name="errText">错误信息</param>
        private Stream ErrorStream(
                    string exCode,
                    string clientID,
                    string msgFormat,
                    int errCode,
                    string errText)
        {
            Entities.TEntityResComm res =
                new Entities.TEntityResComm()
                {
                    ExCode = exCode,
                    ErrCode = errCode,
                    ErrText = errText,
                };
            if (msgFormat.ToUpper() == "XML")
                return EncryptContent(clientID, res.ToXML());
            else
                return EncryptContent(clientID, res.ToJSON());
        }

        /// <summary>
        /// 根据客户端标识中对于安全级别的配置，对报文进行响应的处理
        /// </summary>
        /// <param name="clientID">客户端标识</param>
        /// <param name="msgContent">消息报文</param>
        private Stream EncryptContent(string clientID, string msgContent)
        {
            byte[] strBytes = null;
            string desPWD = "12345678";
            TSecurityLevel thisSL = TSecurityLevel.None;

            try
            {
                if (TRegistClients.Instance.Clients.ContainsKey(clientID))
                {
                    TEntityClient clientEntity = TRegistClients.Instance.Clients[clientID];
                    thisSL = (TSecurityLevel)clientEntity.SecurityLevel;
                    desPWD = clientEntity.SecurityPassword;
                }

                switch (thisSL)
                {
                    case TSecurityLevel.None:
                        strBytes = Encoding.UTF8.GetBytes(msgContent);
                        break;
                    case TSecurityLevel.Compressed:
                        strBytes = Encoding.UTF8.GetBytes(IRAP.ZipUtil.Zip(msgContent));
                        break;
                    case TSecurityLevel.DES:
                        IRAP.DES des = new IRAP.DES();
                        string desStr = des.EncryptDES(msgContent, desPWD);
                        string zipStr = IRAP.ZipUtil.Zip(desStr);
                        strBytes = Encoding.UTF8.GetBytes(zipStr);
                        break;
                    case TSecurityLevel.AES:
                        strBytes =
                            Encoding.UTF8.GetBytes(
                                IRAP.AES.Encrypt(
                                    msgContent,
                                    desPWD,
                                    desPWD));
                        break;
                    default:
                        strBytes =
                            Encoding.UTF8.GetBytes(
                                string.Format(
                                    "{ErrCode:999999,ErrText:'系统无法识别加密安全级别[{0}]，无法完成加密操作'}",
                                    thisSL));
                        break;
                }
            }
            catch (Exception error)
            {
                strBytes =
                    Encoding.UTF8.GetBytes(
                        string.Format(
                            "{ErrCode:999998,ErrText:'{0}'}",
                            error.Message));
            }

            return new MemoryStream(strBytes);
        }

        /// <summary>
        /// 接收通过服务程序传递的流
        /// </summary>
        /// <param name="clientID">客户端标识</param>
        /// <param name="stream">流对象</param>
        private string GetStringFromStreamModelTwo(string clientID, Stream stream)
        {
            string inputContent = "";
            using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
            {
                inputContent = sr.ReadToEnd();
            }

            int securityLevelWithClientID = TRegistClients.Instance.Clients[clientID].SecurityLevel;
            string rlt = "";
            switch (securityLevelWithClientID)
            {
                case 1:     // 明文
                    rlt = inputContent;
                    break;
                case 2:     // 压缩
                case 3:     // DES 加密和 GZIP 压缩（Base64）
                case 4:     // AES 加密（Base64）
                default:
                    rlt =
                        string.Format(
                            "{ErrCode:999999,ErrText:'目前不支持[{0}]加密安全级别，无法操作！'}",
                            securityLevelWithClientID);
                    break;
            }

            return rlt.Replace("\0", "");
        }

        /// <summary>
        /// 调用 SQL Server 的存储过程
        /// </summary>
        /// <param name="exCode">交易代码</param>
        /// <param name="clientID">客户端标识</param>
        /// <param name="msgFormat">消息报文格式</param>
        /// <param name="requestContent">请求报文内容</param>
        /// <param name="exCodeObj">交易定义对象</param>
        private Stream CallSP_SQLServer(
            string exCode,
            string clientID,
            string msgFormat,
            string requestContent,
            TEntityExCode exCodeObj)
        {
            DBHelperSQLServer db2 =
                new DBHelperSQLServer()
                {
                    ConnectionString = TDBConnections.Instance.GetFirstConnection().ConnectionString,
                };

            Dictionary<string, TEntityInputParam> paramList =
                TExCodes.Instance.GetInputParam(exCodeObj);

            #region 遍历字典对输入参数赋值
            List<IDataParameter> inputParamList = new List<IDataParameter>();
            dynamic dn = requestContent.GetSimpleObjectFromJson();
            IDictionary<string, object> dict = (IDictionary<string, object>)dn;
            string resultStr = "";
            foreach (KeyValuePair<string, TEntityInputParam> p in paramList)
            {
                SqlParameter sqlp = new SqlParameter();
                sqlp.ParameterName = p.Value.ParamName;

                #region 参数类型判断
                switch (p.Value.ParamType.ToLower())
                {
                    case "varchar":
                        sqlp.SqlDbType = SqlDbType.VarChar;
                        break;
                    case "nvarchar":
                        sqlp.SqlDbType = SqlDbType.NVarChar;
                        break;
                    case "int":
                        sqlp.SqlDbType = SqlDbType.Int;
                        break;
                    case "bigint":
                        sqlp.SqlDbType = SqlDbType.BigInt;
                        break;
                    case "tinyint":
                        sqlp.SqlDbType = SqlDbType.TinyInt;
                        break;
                    case "smallint":
                        sqlp.SqlDbType = SqlDbType.SmallInt;
                        break;
                    case "datetime":
                        sqlp.SqlDbType = SqlDbType.VarChar;
                        sqlp.Size = 23;
                        break;
                    case "xml":
                        sqlp.SqlDbType = SqlDbType.Xml;
                        sqlp.Size = -1;
                        break;
                    case "decimal":
                        sqlp.SqlDbType = SqlDbType.Decimal;
                        sqlp.Precision = byte.Parse(p.Value.Precision.ToString());
                        sqlp.Scale = byte.Parse(p.Value.Scale.ToString());
                        break;
                    default:
                        sqlp.SqlDbType = SqlDbType.VarChar;
                        sqlp.Size = -1;
                        break;
                }
                #endregion

                if (p.Value.IsOutput == 1)
                {
                    sqlp.Direction = ParameterDirection.Output;
                    sqlp.Size = p.Value.Length == 0 ? 8 : p.Value.Length;
                    inputParamList.Add(sqlp);
                    continue;
                }

                #region 赋值判断
                if (!dict.ContainsKey(p.Key))
                {
                    if (p.Key != "client_id" && p.Key != "ClientID")
                    {
                        return ErrorStream(
                            exCode,
                            clientID,
                            msgFormat,
                            999999,
                            string.Format(
                                "未提供参数：{0}，请检查请求报文是否符合规范定义。",
                                p.Key));
                    }
                }

                if (p.Value.ParamType.ToLower() == "xml")
                {
                    XmlDocument xml = new XmlDocument();
                    XmlNode rootNode = xml.CreateElement("Parameters");
                    XmlElement param = xml.CreateElement("Param");
                    rootNode.AppendChild(param);

                    foreach (KeyValuePair<string, object> item in dict)
                    {
                        if (item.Value.GetType() == typeof(Object[]))
                        {
                            Object[] subArray = (Object[])item.Value;
                            int i = 0;

                            XmlNode rows = xml.CreateElement("ParamXML");

                            foreach (Object subItem in subArray)
                            {
                                XmlElement row = xml.CreateElement("Row");
                                IDictionary<string, object> field = (IDictionary<string, object>)subItem;
                                i++;

                                foreach (KeyValuePair<string, object> fieldKey in field)
                                {
                                    row.SetAttribute(fieldKey.Key, fieldKey.Value.ToString());
                                }
                                rows.AppendChild(row);
                            }
                            rootNode.AppendChild(rows);
                        }
                        else
                            param.SetAttribute(item.Key, item.Value.ToString());
                    }
                    sqlp.Value = rootNode.OuterXml;
                }
                else
                {
                    if (p.Key == "client_id" || p.Key == "ClientID")
                        sqlp.Value = clientID;
                    else
                        sqlp.Value = dict[p.Key];
                }
                #endregion

                sqlp.Direction = ParameterDirection.Input;
                if (sqlp.Size == 0)
                    sqlp.Size = p.Value.Length == 0 ? p.Value.Precision : p.Value.Length;

                inputParamList.Add(sqlp);
            }
            #endregion

            DataSet ds = null;
            Dictionary<string, object> resDict = new Dictionary<string, object>();
            if (exCodeObj.HasRowSet == 1)
            {
                ds = db2.RunProcedureEx(
                    exCodeObj.DBName,
                    exCodeObj.Schema,
                    exCodeObj.ProcName,
                    ref inputParamList);
                List<object> rows = new List<object>();
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        dynamic dobj = new ExpandoObject();
                        var dic = (IDictionary<string, object>)dobj;
                        foreach (DataColumn c in ds.Tables[0].Columns)
                        {
                            if (c.DataType == typeof(long))
                                dic[c.ColumnName] = r[c.ColumnName].ToString();
                            else
                                dic[c.ColumnName] = r[c.ColumnName];
                        }
                        rows.Add(dobj);
                    }
                }
                resDict.Add("Rows", rows);
            }
            else
            {
                db2.RunProcedureEx2(
                    exCodeObj.DBName,
                    exCodeObj.Schema,
                    exCodeObj.ProcName,
                    ref inputParamList);
            }

            foreach (SqlParameter parameter in inputParamList)
            {
                if (parameter.Direction == ParameterDirection.Output)
                    resDict.Add(parameter.ParameterName.Replace("@", ""), parameter.Value);
            }

            if (!resDict.ContainsKey("ExCode"))
                resDict.Add("ExCode", exCode);
            switch (msgFormat.ToUpper())
            {
                case "XML":
                    resultStr = resDict.ToXML();
                    break;
                default:
                    resultStr = resDict.ToJSON();
                    break;
            }
            return EncryptContent(clientID, resultStr);
        }

        /// <summary>
        /// 通用 WebAPI 服务调用入口（非加密）
        /// </summary>
        /// <param name="reqContent">请求报文的流</param>
        /// <param name="clientID">客户端 ID</param>
        /// <param name="msgFormat">请求报文格式类型（Json/XML）</param>
        /// <param name="exCode">交易代码</param>
        /// <returns></returns>
        public Stream GeneralCall(Stream reqContent, string clientID, string msgFormat, string exCode)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (!MsgFormatValidate(msgFormat))
            {
                return ErrorStream(
                    exCode, 
                    clientID, 
                    "JSON", 
                    999999, 
                    string.Format("不支持[{0}]报文格式，仅支持 JSON 或 XML", msgFormat));
            }

            if (!TRegistClients.Instance.Clients.ContainsKey(clientID))
            {
                return ErrorStream(
                    exCode,
                    clientID,
                    msgFormat,
                    999999,
                    string.Format("客户标识[{0}]未授权或未在服务端注册", clientID));
            }

            try
            {
                #region 服务的最大连接数控制
                if (DateTime.Now.Subtract(_lastTime).TotalMilliseconds > 1000)
                {
                    _lastTime = DateTime.Now;
                    _connectedCount = 0;
                }
                else
                    _connectedCount++;
                if (_connectedCount > _maxConnectedPerSecond)
                {
                    // 记录日志
                    WriteLog.Instance.Write(
                        string.Format(
                            "客户端：[{0}|{1}]连接数量超过最大允许数量[{2}]",
                            clientID,
                            exCode,
                            _maxConnectedPerSecond),
                        strProcedureName);

                    return ErrorStream(
                        exCode,
                        clientID,
                        msgFormat,
                        100021,
                        "当前访问的用户过多，请稍后再试。");
                }
                #endregion

                string requestContent = GetStringFromStreamModelTwo(clientID, reqContent);
                // 记录日志
                WriteLog.Instance.Write(
                    string.Format(
                        "接收到的报文内容：[{0}]",
                        requestContent),
                    strProcedureName);

                #region 判断交易代码的合法性（行业系统_模块_方法）
                string[] tmpExCode = exCode.Split('_');
                if (tmpExCode.Length < 3)
                    return ErrorStream(
                        exCode,
                        clientID,
                        msgFormat,
                        999999,
                        "ExCode 传递不合法，必须是：'行业系统_模块_方法'格式");
                #endregion

                TEntityExCode exCodeObj =
                    TExCodes.Instance.GetExCode(
                        string.Format("{0}_{1}", tmpExCode[0], tmpExCode[1]),
                        tmpExCode[2]);
                if (exCodeObj == null)
                {
                    return ErrorStream(
                        exCode,
                        clientID,
                        msgFormat,
                        999999,
                        string.Format(
                            "业务交易代码 [{0}] 不存在，可能是服务器没有配置",
                            exCode));
                }

                string rltString = "";
                switch ((TInvokeType)exCodeObj.InvokeType)
                {
                    case TInvokeType.Demo:
                        rltString = exCodeObj.ResponseText;
                        break;
                    case TInvokeType.StoreProcedure:         // 直接连接数据库，调用存储过程
                        if (exCodeObj.VerifyToken == 1)         // 需要验证令牌
                        {
                            dynamic dn = requestContent.GetSimpleObjectFromJson();
                            if (!((IDictionary<string, object>)dn).ContainsKey("Access_Token"))
                            {
                                return ErrorStream(
                                    exCode,
                                    clientID,
                                    msgFormat,
                                    999999,
                                    "此接口要求验证令牌，请在请求报文中提供令牌！");
                            }

                            string accessToken = dn.Access_Token.ToString();
                            int errCode = 0;
                            string errText = "";

                            #region 以下是通过数据库的存储过程来验证客户端提供的令牌
                            switch (_dbType)
                            {
                                case TDBServerType.SQLServer:
                                    return ErrorStream(
                                        exCode,
                                        clientID,
                                        msgFormat,
                                        999999,
                                        string.Format("当前版本的通用网关暂不支持SQL Server数据库方式验证令牌"));
                                default:
                                    return ErrorStream(
                                        exCode,
                                        clientID,
                                        msgFormat,
                                        999999,
                                        string.Format("未知的数据库类型定义[{0}]", _dbType));
                            }
                            #endregion

                            if (errCode != 0)
                                return ErrorStream(
                                    exCode,
                                    clientID,
                                    msgFormat,
                                    errCode,
                                    errText);
                        }

                        #region 以下是调用数据库中的存储过程来提供服务
                        switch (_dbType)
                        {
                            case TDBServerType.SQLServer:
                                return 
                                    CallSP_SQLServer(
                                        exCode, 
                                        clientID, 
                                        msgFormat, 
                                        requestContent, 
                                        exCodeObj);
                            default:
                                return ErrorStream(
                                    exCode,
                                    clientID,
                                    msgFormat,
                                    999999,
                                    string.Format("未知的数据库类型定义[{0}]", _dbType));
                        }
                        #endregion
                    case TInvokeType.Interface:         // 调用类库中的接口
                        rltString = "{\"ErrCode\":999999, \"ErrText\":\"未实现该接口调用方式\"}";
                        break;
                    default:
                        rltString = "{\"ErrCode\":999999, \"ErrText\":\"不支持的接口调用方式\"}";
                        break;
                }

                return EncryptContent(clientID, rltString);
            }
            catch (Exception error)
            {
                string errCode = "999999";
                string errText = error.Message;

                if (error.Data["ErrCode"] != null)
                    errCode = error.Data["ErrCode"].ToString();
                if (error.Data["ErrText"] != null)
                    errText = error.Data["ErrText"].ToString();

                Debug.WriteLine(string.Format("[({0}){1}]", errCode, errText));

                return ErrorStream(exCode, clientID, msgFormat, int.Parse(errCode), errText);
            }
        }

        public Stream ChannelValidate(Stream reqContent, string clientID, string msgFormat)
        {
            throw new NotImplementedException();
        }

        public Stream OpenAuth(Stream reqContent, string clientID, string msgFormat)
        {
            throw new NotImplementedException();
        }

        public Stream SafeRecord(Stream reqContent, string clientID, string msgFormat)
        {
            throw new NotImplementedException();
        }

        public Stream Upload(Stream fileStream, string clientID, string exCode, string parameters)
        {
            throw new NotImplementedException();
        }

        public Stream Download(string clientID, string exCode, string parameters)
        {
            throw new NotImplementedException();
        }
    }
}   

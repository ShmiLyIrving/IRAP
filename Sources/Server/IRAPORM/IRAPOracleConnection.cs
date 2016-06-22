using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Reflection;
using System.ComponentModel;

using log4net;
using Oracle.DataAccess.Client;

using IRAP.Global;
using IRAPShared;

namespace IRAPORM
{
    public class IRAPOracleConnection : iIRAPConnection, IDisposable
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string _connStr = "";
        private string _sequenceAddress = "";
        private OracleConnection conn = null;
        private Dictionary<string, string> _paramList = new Dictionary<string, string>();
        private Assembly[] _loadAssembly;
        private static ILog _logger = LogManager.GetLogger("IRAPORM");
        private OracleTransaction _trans = null;

        public IRAPOracleConnection()
        {
            _paramList = ReadAssemblyXML();

            string dllPath =
                Path.Combine(
                    Environment.CurrentDirectory,
                    "IRAPORM.dll");
            _connStr = _paramList["OracleConnectionString"];
            _sequenceAddress = _paramList["SeqServerAddr"];

            conn = new OracleConnection(_connStr);
            _loadAssembly = AppDomain.CurrentDomain.GetAssemblies();
        }

        public IRAPOracleConnection(string connectionString)
        {
            _connStr = connectionString;

            conn = new OracleConnection(_connStr);
            _loadAssembly = AppDomain.CurrentDomain.GetAssemblies();
        }

        /// <summary>
        /// 序列服务器地址
        /// </summary>
        public static string SequenceAddress
        {
            get
            {
                Dictionary<string, string> _paramList = ReadAssemblyXML();

                if (_paramList["SeqServerAddr"] != null)
                    return _paramList["SeqServerAddr"].ToString();
                else
                    return "";
            }
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return _connStr; }
            set { _connStr = value; }
        }

        public void Dispose()
        {
            if (conn.State != ConnectionState.Closed &&
                conn.State != ConnectionState.Broken)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public IList<T> List<T>(string querySql)
        {
            throw new NotImplementedException();
        }

        private static Dictionary<string, string> ReadAssemblyXML()
        {
            Dictionary<string, string> rlt = new Dictionary<string, string>();

            XmlDocument _xmlDoc = new XmlDocument();
            string _assetXMLPath = AppDomain.CurrentDomain.BaseDirectory + @"ServiceDlls\IRAPORM.xml";

            _xmlDoc.Load(_assetXMLPath);

            XmlElement xmlContent = _xmlDoc.DocumentElement;

            XmlNode rowNode = xmlContent.SelectSingleNode("/configuration/appSettings");

            foreach (XmlNode node in rowNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    rlt.Add(node.Attributes["key"].Value, node.Attributes["value"].Value);
                }
            }

            return rlt;
        }

        public List<string> LoadedAssembly()
        {
            List<string> rlt = new List<string>();

            foreach (Assembly item in _loadAssembly)
            {
                rlt.Add(item.FullName);
            }

            return rlt;
        }

        public IRAPError CallProc(string procName, ref IList<IDataParameter> paramList)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            bool IsOutputInfo = false;
            OracleCommand command = new OracleCommand();
            command.Connection = conn;

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            foreach (IRAPProcParameter param in paramList)
            {
                if (param.ParameterName == "@ErrCode")
                {
                    IsOutputInfo = true;
                }

                OracleDbType oraType = ConvertOracleType.ToOracleType(param.DbType);
                OracleParameter trueParam = new OracleParameter(param.ParameterName, oraType);

                trueParam.Direction = param.Direction;
                trueParam.Size = param.Size;
                trueParam.IsNullable = param.IsNullable;
                trueParam.SourceColumn = param.SourceColumn;
                trueParam.SourceVersion = param.SourceVersion;
                if (trueParam.Direction == ParameterDirection.Input || trueParam.Direction == ParameterDirection.InputOutput)
                {
                    trueParam.Value = param.Value;
                }
                command.Parameters.Add(trueParam);
            }

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (_trans != null)
            {
                command.Transaction = _trans;
            }
            IRAPError error = new IRAPError();

            try
            {
                command.Prepare();
                command.ExecuteNonQuery();
                if (IsOutputInfo)
                {
                    error.ErrCode = int.Parse(command.Parameters["@ErrCode"].Value.ToString());
                    error.ErrText = command.Parameters["@ErrText"].Value.ToString();
                }
                else
                {
                    error.ErrCode = 0;
                    error.ErrText = string.Format("过程：{0}调用成功！", procName);
                }

                //赋值给参数
                foreach (OracleParameter item in command.Parameters)
                {
                    if (item.Direction == ParameterDirection.Output || item.Direction == ParameterDirection.InputOutput)
                    {
                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (item.ParameterName == param.ParameterName)
                            {
                                param.Value = item.Value;
                            }
                        }
                    }
                }

                return error;
            }
            catch (OracleException err)
            {
                foreach (OracleError item in err.Errors)
                {
                    WriteLog.Instance.Write(
                        className, 
                        string.Format("{0}({1})", item.Message, item.Number),
                        strProcedureName);
                }

                IRAPError errorExcept = new IRAPError();
                errorExcept.ErrText = string.Format("存储过程异常，[{0}]:{1}", procName, err.Message);
                errorExcept.ErrCode = 9999;
                return errorExcept;
            }
            catch (Exception err)
            {
                WriteLog.Instance.Write(
                    className,
                    err.Message,
                    strProcedureName);
                throw new IRAPException(9999, "调用过程出现错误，可能是输出参数长度设置不正确。", err);
            }
        }

        public Object CallScalarFunc(string funcName, IList<IDataParameter> paramList)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            StringBuilder sql = new StringBuilder("SELECT " + funcName + "(");

            OracleCommand command = new OracleCommand();
            command.Connection = conn;
            foreach (IRAPProcParameter param in paramList)
            {
                sql.Append(param.ParameterName + ",");

                OracleDbType oraType = ConvertOracleType.ToOracleType(param.DbType);
                OracleParameter trueParam = new OracleParameter(param.ParameterName, oraType);
                trueParam.Direction = param.Direction;
                trueParam.Size = param.Size;
                trueParam.IsNullable = param.IsNullable;
                trueParam.SourceColumn = param.SourceColumn;
                trueParam.SourceVersion = param.SourceVersion;
                if (trueParam.Direction == ParameterDirection.Input ||
                    trueParam.Direction == ParameterDirection.InputOutput)
                {
                    trueParam.Value = param.Value;
                }

                command.Parameters.Add(trueParam);
            }
            command.CommandText = sql.ToString(0, sql.Length - 1) + ") FROM DUAL";

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            try
            {
                object obj = command.ExecuteScalar();
                Console.WriteLine(obj.ToString());
                if (obj == null) return "";
                if (obj == System.DBNull.Value) return "0";
                return obj;
            }
            catch (OracleException err)
            {
                foreach (OracleError item in err.Errors)
                {
                    WriteLog.Instance.Write(
                        className,
                        string.Format("{0}({1})", item.Message, item.Number),
                        strProcedureName);
                }
                throw err;
            }
        }

        public IList<T> CallTableFunc<T>(string selectSql, IList<IDataParameter> paramList)
        {
            string strProcedureName =
              string.Format(
                  "{0}.{1}",
                  className,
                  MethodBase.GetCurrentMethod().Name);

            OracleCommand command = new OracleCommand();
            command.Connection = conn;
            command.CommandText = selectSql;
            IList<T> pList = new BindingList<T>(); // new List<T>();

            foreach (IRAPProcParameter param in paramList)
            {
                OracleDbType oraType = ConvertOracleType.ToOracleType(param.DbType);
                OracleParameter trueParam = new OracleParameter(param.ParameterName, oraType);
                trueParam.Direction = param.Direction;
                trueParam.Size = param.Size;
                trueParam.IsNullable = param.IsNullable;
                trueParam.SourceColumn = param.SourceColumn;
                trueParam.SourceVersion = param.SourceVersion;
                if (trueParam.Direction == ParameterDirection.Input ||
                    trueParam.Direction == ParameterDirection.InputOutput)
                {
                    trueParam.Value = param.Value;
                }

                command.Parameters.Add(trueParam);
            }

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                OracleDataReader reader = command.ExecuteReader();
                System.Type tt2 = null;
                foreach (Assembly item in _loadAssembly)
                {
                    tt2 = item.GetType(typeof(T).ToString());
                    if (tt2 != null)
                    {
                        break;
                    }
                }
                if (tt2 == null)
                {
                    WriteLog.Instance.Write(
                        className,
                        string.Format("没有获取到类型：[{0}]", typeof(T).ToString()),
                        strProcedureName);
                }

                object ff2 = Activator.CreateInstance(tt2, null);
                PropertyInfo[] fields2 = ff2.GetType().GetProperties();//获取指定对象的所有公共属性
                try
                {
                    while (reader.Read())
                    {
                        object obj = Activator.CreateInstance(tt2, null);
                        foreach (PropertyInfo ti in fields2)
                        {
                            bool isContinue = true;
                            //获取特性清单
                            object[] attributes = ti.GetCustomAttributes(false);
                            foreach (object item in attributes)
                            {
                                if (item.GetType() == typeof(IRAPORMMapAttribute))
                                {
                                    if (!(item as IRAPORMMapAttribute).ORMMap)
                                    {
                                        isContinue = false;
                                        break;
                                    }
                                }
                            }
                            if (!isContinue)
                            {
                                continue;
                            }

                            try
                            {
                                if (reader[ti.Name] != null)
                                {
                                    /*
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.DateTime))
                                    {
                                        ti.SetValue(obj, new DateTime(1900, 1, 2), null);//给对象赋值
                                        continue;
                                    }

                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Byte[]))
                                    {
                                        ti.SetValue(obj, new byte[9], null);//如果对象为空赋值
                                        continue;
                                    }
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Decimal))
                                    {
                                        ti.SetValue(obj, Convert.ToDecimal(0.00), null);
                                        continue;
                                    }
                                    */
                                    if (reader[ti.Name] != DBNull.Value)
                                        ti.SetValue(obj, reader[ti.Name], null);//给对象赋值
                                }
                            }
                            catch (IndexOutOfRangeException outErr)
                            {
                                throw new IRAPException(9999, string.Format("数据库表中没有字段：[{0}]", ti.Name), outErr);
                            }
                            continue;
                        }
                        pList.Add((T)obj);//将对象填充到list集合
                    }
                }
                finally
                {
                    reader.Close();
                }
                return pList;
            }
            catch (OracleException err)
            {
                foreach (OracleError item in err.Errors)
                {
                    WriteLog.Instance.Write(
                        className,
                        string.Format("{0}({1})", item.Message, item.Number),
                        strProcedureName);
                }

                throw err;
            }
            catch (Exception err)
            {
                WriteLog.Instance.Write(
                    className,
                    err.Message,
                    strProcedureName);
                WriteLog.Instance.Write(
                    className,
                    err.StackTrace,
                    strProcedureName);
                throw new IRAPException(9999, "调用表值函数出现错误，可能是输出参数长度设置不正确。", err);

            }
        }

        public IList<T> CallFunction<T>(string functionName, IList<IDataParameter> paramList)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            #region 拼接 SQL 语句
            StringBuilder sql =
                new StringBuilder(
                    string.Format("SELECT * FROM TABLE({0}(", functionName));
            OracleCommand command = new OracleCommand();
            command.Connection = conn;
            foreach (IRAPProcParameter param in paramList)
            {
                sql.Append(param.ParameterName + ",");

                OracleDbType oraType = ConvertOracleType.ToOracleType(param.DbType);
                OracleParameter trueParam = new OracleParameter(param.ParameterName, oraType);
                trueParam.Direction = param.Direction;
                trueParam.Size = param.Size;
                trueParam.IsNullable = param.IsNullable;
                trueParam.SourceColumn = param.SourceColumn;
                trueParam.SourceVersion = param.SourceVersion;
                if (trueParam.Direction == ParameterDirection.Input ||
                    trueParam.Direction == ParameterDirection.InputOutput)
                {
                    trueParam.Value = param.Value;
                }

                command.Parameters.Add(trueParam);
            }
            command.CommandText = sql.ToString(0, sql.Length - 1) + ")";
            #endregion

            #region 执行 SQL 语句，并组织返回结果
            IList<T> pList = new BindingList<T>();
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                OracleDataReader reader = command.ExecuteReader();
                System.Type tt2 = null;
                foreach (Assembly item in _loadAssembly)
                {
                    tt2 = item.GetType(typeof(T).ToString());
                    if (tt2 != null)
                    {
                        break;
                    }
                }
                if (tt2 == null)
                {
                    WriteLog.Instance.Write(
                        className,
                        string.Format("没有获取到类型：[{0}]", typeof(T).ToString()),
                        strProcedureName);
                    throw new IRAPException(99999, string.Format("没有获取到类型：[{0}]", typeof(T).ToString()));
                }

                object ff2 = Activator.CreateInstance(tt2, null);
                PropertyInfo[] fields2 = ff2.GetType().GetProperties();//获取指定对象的所有公共属性
                try
                {
                    while (reader.Read())
                    {
                        object obj = Activator.CreateInstance(tt2, null);
                        foreach (PropertyInfo ti in fields2)
                        {
                            bool isContinue = true;
                            //获取特性清单
                            object[] attributes = ti.GetCustomAttributes(false);
                            foreach (object item in attributes)
                            {
                                if (item.GetType() == typeof(IRAPORMMapAttribute))
                                {
                                    if (!(item as IRAPORMMapAttribute).ORMMap)
                                    {
                                        isContinue = false;
                                        break;
                                    }
                                }
                            }
                            if (!isContinue)
                            {
                                continue;
                            }

                            try
                            {
                                if (reader[ti.Name] != null)
                                {
                                    if (reader[ti.Name] != DBNull.Value)
                                        ti.SetValue(obj, reader[ti.Name], null);//给对象赋值
                                }
                            }
                            catch (IndexOutOfRangeException outErr)
                            {
                                WriteLog.Instance.Write(
                                    className,
                                    string.Format("数据库表中没有字段：[{0}]", ti.Name),
                                    strProcedureName);
                                throw new IRAPException(9999, string.Format("数据库表中没有字段：[{0}]", ti.Name), outErr);
                            }
                            continue;
                        }
                        pList.Add((T)obj);//将对象填充到list集合
                    }
                }
                finally
                {
                    reader.Close();
                }
                return pList;
            }
            catch (OracleException err)
            {
                foreach (OracleError item in err.Errors)
                {
                    WriteLog.Instance.Write(
                        className,
                        string.Format("{0}({1})", item.Message, item.Number),
                        strProcedureName);
                }

                throw err;
            }
            catch (Exception err)
            {
                WriteLog.Instance.Write(
                    className,
                    err.Message,
                    strProcedureName);
                WriteLog.Instance.Write(
                    className,
                    err.StackTrace,
                    strProcedureName);
                throw new IRAPException(9999, "调用表值函数出现错误，可能是输出参数长度设置不正确。", err);
            }
            #endregion
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.Serialization;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using log4net;
using IRAPShared;
using System.Xml;
using System.ComponentModel;

namespace IRAPORM
{

    public interface iIRAPConnection
    {
        IList<T> List<T>(string querySql);
    }

    public class IRAPSQLConnection : iIRAPConnection, IDisposable
    {
        private SqlConnection conn;
        // private Assembly t;
        private SqlTransaction _trans = null;
        private string _connStr;
        private static ILog _logger = log4net.LogManager.GetLogger("IRAPORM");
        private Dictionary<string, string> _paramList = new Dictionary<string, string>();
        private Assembly[] _LoadAssembly;
        private string _sequenceAddress;
        private int _commandTimeout = 60;
        public IRAPSQLConnection()
        {
            ReadAssemblyXML();
            //  t = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + @"Entity\IRAPEntity.dll");
            string dllPath = System.IO.Path.Combine(Environment.CurrentDirectory, "IRAPORM.dll");
            _connStr = _paramList["ConnectionString"];
            _sequenceAddress = _paramList["SeqServerAddr"];

            int.TryParse(_paramList["CommandTimeout"], out _commandTimeout);

            conn = new SqlConnection(_connStr);
            System.AppDomain _Domain = System.AppDomain.CurrentDomain;
            _LoadAssembly = _Domain.GetAssemblies();
            //foreach (Assembly item in _LoadAssembly)
            //{
            //    Console.WriteLine(item.FullName);
            //}
        }
        public IRAPSQLConnection(string connectionStr)
        {
            _connStr = connectionStr;
            conn = new SqlConnection(_connStr);
            System.AppDomain _Domain = System.AppDomain.CurrentDomain;
            _LoadAssembly = _Domain.GetAssemblies();
        }
        public static string SequenceAddress
        {
            get
            {
                Dictionary<string, string> _paramList = new Dictionary<string, string>();
                XmlDocument _xmlDoc = new XmlDocument();
                string _assetXMLPath = AppDomain.CurrentDomain.BaseDirectory + @"ServiceDlls\IRAPORM.xml";

                _xmlDoc.Load(_assetXMLPath);

                XmlElement xmlContent = _xmlDoc.DocumentElement;

                XmlNode rowNode = xmlContent.SelectSingleNode("/configuration/appSettings");

                foreach (XmlNode node in rowNode.ChildNodes)
                {
                    if (node.NodeType == XmlNodeType.Element)
                    {
                        _paramList.Add(node.Attributes["key"].Value, node.Attributes["value"].Value);
                    }
                }
                return _paramList["SeqServerAddr"].ToString();
            }
        }
        public List<string> LoadedAssembly()
        {
            List<string> reList = new List<string>();
            foreach (Assembly item in _LoadAssembly)
            {
                reList.Add(item.FullName);
            }
            return reList;
        }
        private void ReadAssemblyXML()
        {
            XmlDocument _xmlDoc = new XmlDocument();
            string _assetXMLPath = AppDomain.CurrentDomain.BaseDirectory + @"ServiceDlls\IRAPORM.xml";

            _xmlDoc.Load(_assetXMLPath);

            XmlElement xmlContent = _xmlDoc.DocumentElement;

            XmlNode rowNode = xmlContent.SelectSingleNode("/configuration/appSettings");

            foreach (XmlNode node in rowNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    _paramList.Add(node.Attributes["key"].Value, node.Attributes["value"].Value);
                }
            }
        }

        public string ConnectionStr
        {
            get { return _connStr; }
            set { _connStr = value; }
        }

        ~IRAPSQLConnection()
        {
            if (conn.State != ConnectionState.Closed && conn.State != ConnectionState.Broken)
            {
                // conn.Close();
                // conn.Dispose();
            }
        }
        public void Close()
        {
            if (conn.State != ConnectionState.Closed && conn.State != ConnectionState.Broken)
            {
                conn.Close();
                // conn.Dispose();
            }
        }
        public bool BeginTran()
        {
            conn.Open();
            try
            {
                _trans = conn.BeginTransaction();
                return true;
            }
            catch (Exception err)
            {
                throw new IRAPException(9998, "开始新事务时失败", err);
            }
        }
        public bool Commit()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                throw new IRAPException(9999, "连接已关闭");
            }

            try
            {
                if (_trans != null)
                {
                    _trans.Commit();
                    conn.Close();
                    _trans = null;
                    return true;
                }
                return false;
            }
            catch (Exception err)
            {
                throw new IRAPException(9999, "提交事务时出错", err);
            }
        }
        public bool RollBack()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                throw new IRAPException(9999, "连接已关闭");
            }

            try
            {
                if (_trans != null)
                {
                    _trans.Rollback();
                    conn.Close();
                    _trans = null;
                    return true;
                }
                return false;
            }
            catch (Exception err)
            {
                throw new IRAPException(9999, "提交事务时出错", err);
            }
        }

        public IList<T> List<T>()
        {
            try
            {
                System.Type tt2 = null;
                foreach (Assembly item in _LoadAssembly)
                {
                    tt2 = item.GetType(typeof(T).ToString());
                    if (tt2 != null)
                    {
                        break;
                    }
                }
                object ff2 = Activator.CreateInstance(tt2, null);//创建指定类型实例
                PropertyInfo[] fields2 = ff2.GetType().GetProperties();//获取指定对象的所有公共属性
                string[] assemblyName = ff2.GetType().ToString().Split('.');

                string dbTableName = assemblyName[assemblyName.Length - 1];
                object[] classAttributes = ff2.GetType().GetCustomAttributes(false);
                foreach (object item in classAttributes)
                {
                    if (item.GetType() == typeof(IRAPDBAttribute))
                    {
                        dbTableName = (item as IRAPDBAttribute).TableName;
                    }
                }
                string sql = "select * from " + dbTableName;

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand command2 = new SqlCommand(sql, conn) { CommandTimeout = _commandTimeout, };
                SqlDataReader reader = command2.ExecuteReader();
                List<T> pList = new List<T>();
                //获取指定名称的类型
                try
                {
                    while (reader.Read())
                    {
                        object obj = Activator.CreateInstance(tt2, null);
                        foreach (PropertyInfo ti in fields2)
                        {
                            //获取特性清单
                            object[] attributes = ti.GetCustomAttributes(false);
                            bool isContinue = true;
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
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.DateTime))
                                    {
                                        ti.SetValue(obj, new DateTime(1900, 1, 2), null);//给对象赋值
                                        continue;
                                    }
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Byte[]))
                                    {
                                        ti.SetValue(obj, new byte[1], null);//如果对象为空赋值
                                        continue;
                                    }
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Decimal))
                                    {
                                        ti.SetValue(obj, Convert.ToDecimal(0.00), null);
                                        continue;
                                    }
                                    ti.SetValue(obj, reader[ti.Name], null);//给对象赋值
                                }
                            }
                            catch (IndexOutOfRangeException outErr)
                            {
                                throw new IRAPException(9999, "数据库表中没有此字段：" + ti.Name, outErr); ;
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
            catch (Exception err)
            {
                throw err;
            }

        }

        public IList<T> List<T>(string whereSql, string tableName = "")
        {
            try
            {
                System.Type tt2 = null;
                foreach (Assembly item in _LoadAssembly)
                {
                    tt2 = item.GetType(typeof(T).ToString());
                    if (tt2 != null)
                    {
                        break;
                    }
                }
                object ff2 = Activator.CreateInstance(tt2, null);//创建指定类型实例
                PropertyInfo[] fields2 = ff2.GetType().GetProperties();//获取指定对象的所有公共属性
                string[] assemblyName = ff2.GetType().ToString().Split('.');

                string dbTableName = assemblyName[assemblyName.Length - 1];
                object[] classAttributes = ff2.GetType().GetCustomAttributes(false);
                if (tableName == "")
                {
                    foreach (object item in classAttributes)
                    {
                        if (item.GetType() == typeof(IRAPDBAttribute))
                        {
                            dbTableName = (item as IRAPDBAttribute).TableName;
                        }
                    }
                }
                else
                {
                    dbTableName = tableName;
                }

                string sql = "";
                if (whereSql == string.Empty)
                {
                    sql = "select * from " + dbTableName;
                }
                else
                {
                    sql = "select * from " + dbTableName + " where " + whereSql;
                }
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand command2 = new SqlCommand(sql, conn) { CommandTimeout = _commandTimeout, };
                SqlDataReader reader = command2.ExecuteReader();
                List<T> pList = new List<T>();
                //获取指定名称的类型
                try
                {
                    while (reader.Read())
                    {
                        object obj = Activator.CreateInstance(tt2, null);
                        foreach (PropertyInfo ti in fields2)
                        {
                            //获取特性清单
                            object[] attributes = ti.GetCustomAttributes(false);
                            bool isContinue = true;
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
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.DateTime))
                                    {
                                        ti.SetValue(obj, new DateTime(1900, 1, 2), null);//给对象赋值
                                        continue;
                                    }
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Byte[]))
                                    {
                                        ti.SetValue(obj, new byte[1], null);//如果对象为空赋值
                                        continue;
                                    }
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Decimal))
                                    {
                                        ti.SetValue(obj, Convert.ToDecimal(0.00), null);
                                        continue;
                                    }
                                    ti.SetValue(obj, reader[ti.Name], null);//给对象赋值
                                }
                            }
                            catch (IndexOutOfRangeException outErr)
                            {
                                throw new IRAPException(9999, "数据库表中没有此字段：" + ti.Name, outErr); ;
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
            catch (Exception err)
            {
                throw err;
            }

        }

        public IList<T> List<T>(string querySql, IList<IDataParameter> paramList)
        {
            System.Type tempType = null;
            foreach (Assembly item in _LoadAssembly)
            {
                tempType = item.GetType(typeof(T).ToString());
                if (tempType != null)
                {
                    break;
                }
            }
            object obj = Activator.CreateInstance(tempType, null);//创
            PropertyInfo[] propertyList = obj.GetType().GetProperties();
            try
            {
                conn.Close();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand command2 = new SqlCommand(querySql, conn) { CommandTimeout = _commandTimeout, };
                foreach (IRAPProcParameter param in paramList)
                {
                    SqlDbType sqlType = ConvertSqlType.ToSqlType(param.DbType);
                    SqlParameter trueParam = new SqlParameter(param.ParameterName, sqlType);
                    trueParam.Direction = param.Direction;
                    trueParam.Size = param.Size;
                    trueParam.IsNullable = param.IsNullable;
                    trueParam.SourceColumn = param.SourceColumn;
                    trueParam.SourceVersion = param.SourceVersion;
                    if (trueParam.Direction == ParameterDirection.Input || trueParam.Direction == ParameterDirection.InputOutput)
                    {
                        trueParam.Value = param.Value;
                    }
                    command2.Parameters.Add(trueParam);
                }
                SqlDataReader reader = command2.ExecuteReader();

                IList<T> returnList = new List<T>();
                try
                {
                    while (reader.Read())
                    {
                        object returnObj = Activator.CreateInstance(tempType, null);//创建指定类型实例
                        foreach (PropertyInfo ti in propertyList)
                        {
                            object[] attributes = ti.GetCustomAttributes(false);
                            bool isContinue = true;
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
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.DateTime))
                                    {
                                        ti.SetValue(returnObj, new DateTime(1900, 1, 2), null);//给对象赋值
                                        continue;
                                    }
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Decimal))
                                    {
                                        ti.SetValue(obj, Convert.ToDecimal(0.00), null);
                                        continue;
                                    }
                                    ti.SetValue(returnObj, reader[ti.Name], null);//给对象赋值
                                }
                            }
                            catch (IndexOutOfRangeException outErr)
                            {
                                throw new IRAPException(9999, "数据库表中没有此字段：" + ti.Name, outErr);
                            }
                        }
                        returnList.Add((T)returnObj);
                    }
                }
                finally
                {
                    reader.Close();
                }
                return returnList;
            }
            catch (SqlException err)
            {
                throw new IRAPException(9999, "List查询数据异常！", err);
            }

        }


        public IList<object> List(string className)
        {
            try
            {
                System.Type tt2 = null;
                foreach (Assembly item in _LoadAssembly)
                {
                    tt2 = item.GetType(className);
                    if (tt2 != null)
                    {
                        break;
                    }
                }
                object ff2 = Activator.CreateInstance(tt2, null);//创建指定类型实例
                PropertyInfo[] fields2 = ff2.GetType().GetProperties();//获取指定对象的所有公共属性
                string[] assemblyName = ff2.GetType().ToString().Split('.');

                string dbTableName = assemblyName[assemblyName.Length - 1];
                object[] classAttributes = ff2.GetType().GetCustomAttributes(false);
                foreach (object item in classAttributes)
                {
                    if (item.GetType() == typeof(IRAPDBAttribute))
                    {
                        dbTableName = (item as IRAPDBAttribute).TableName;
                    }
                }
                string sql = "select * from " + dbTableName;

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand command2 = new SqlCommand(sql, conn) { CommandTimeout = _commandTimeout, };
                SqlDataReader reader = command2.ExecuteReader();
                List<object> pList = new List<object>();
                //获取指定名称的类型
                try
                {
                    while (reader.Read())
                    {
                        object obj = Activator.CreateInstance(tt2, null);
                        foreach (PropertyInfo ti in fields2)
                        {
                            //获取特性清单
                            object[] attributes = ti.GetCustomAttributes(false);
                            bool isContinue = true;
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
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.DateTime))
                                    {
                                        ti.SetValue(obj, new DateTime(1900, 1, 2), null);//给对象赋值
                                        continue;
                                    }
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Byte[]))
                                    {
                                        ti.SetValue(obj, new byte[1], null);//如果对象为空赋值
                                        continue;
                                    }
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Decimal))
                                    {
                                        ti.SetValue(obj, Convert.ToDecimal(0.00), null);
                                        continue;
                                    }
                                    ti.SetValue(obj, reader[ti.Name], null);//给对象赋值
                                }
                            }
                            catch (IndexOutOfRangeException outErr)
                            {
                                throw new IRAPException(9999, "数据库表中没有此字段：" + ti.Name, outErr); ;
                            }

                            continue;
                        }
                        pList.Add((object)obj);//将对象填充到list集合
                    }
                }
                finally
                {
                    reader.Close();
                }
                return pList;
            }
            catch (Exception err)
            {
                throw err;
            }

        }


        public IList<object> List(string className, string whereSql, IList<IDataParameter> paramList)
        {
            try
            {
                System.Type tt2 = null;
                foreach (Assembly item in _LoadAssembly)
                {
                    tt2 = item.GetType(className);
                    if (tt2 != null)
                    {
                        break;
                    }
                }
                object ff2 = Activator.CreateInstance(tt2, null);//创建指定类型实例
                PropertyInfo[] fields2 = ff2.GetType().GetProperties();//获取指定对象的所有公共属性
                string[] assemblyName = ff2.GetType().ToString().Split('.');

                string dbTableName = assemblyName[assemblyName.Length - 1];
                object[] classAttributes = ff2.GetType().GetCustomAttributes(false);
                foreach (object item in classAttributes)
                {
                    if (item.GetType() == typeof(IRAPDBAttribute))
                    {
                        dbTableName = (item as IRAPDBAttribute).TableName;
                    }
                }
                string sql = "select * from " + dbTableName + " " + (whereSql == string.Empty ? "" : "WHERE ") + whereSql;

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand command2 = new SqlCommand(sql, conn) { CommandTimeout = _commandTimeout, };
                foreach (IRAPProcParameter param in paramList)
                {
                    SqlDbType sqlType = ConvertSqlType.ToSqlType(param.DbType);
                    SqlParameter trueParam = new SqlParameter(param.ParameterName, sqlType);
                    trueParam.Direction = param.Direction;
                    trueParam.Size = param.Size;
                    trueParam.IsNullable = param.IsNullable;
                    trueParam.SourceColumn = param.SourceColumn;
                    trueParam.SourceVersion = param.SourceVersion;
                    if (trueParam.Direction == ParameterDirection.Input || trueParam.Direction == ParameterDirection.InputOutput)
                    {
                        trueParam.Value = param.Value;
                    }
                    command2.Parameters.Add(trueParam);
                }
                SqlDataReader reader = command2.ExecuteReader();
                List<object> pList = new List<object>();
                //获取指定名称的类型
                try
                {
                    while (reader.Read())
                    {
                        object obj = Activator.CreateInstance(tt2, null);
                        foreach (PropertyInfo ti in fields2)
                        {
                            //获取特性清单
                            object[] attributes = ti.GetCustomAttributes(false);
                            bool isContinue = true;
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
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.DateTime))
                                    {
                                        ti.SetValue(obj, new DateTime(1900, 1, 2), null);//给对象赋值
                                        continue;
                                    }
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Byte[]))
                                    {
                                        ti.SetValue(obj, new byte[1], null);//如果对象为空赋值
                                        continue;
                                    }
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Decimal))
                                    {
                                        ti.SetValue(obj, Convert.ToDecimal(0.00), null);
                                        continue;
                                    }
                                    ti.SetValue(obj, reader[ti.Name], null);//给对象赋值
                                }
                            }
                            catch (IndexOutOfRangeException outErr)
                            {
                                throw new IRAPException(9999, "数据库表中没有此字段：" + ti.Name, outErr); ;
                            }

                            continue;
                        }
                        pList.Add((object)obj);//将对象填充到list集合
                    }
                }
                finally
                {
                    reader.Close();
                }
                return pList;
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        public int Insert(string tableName, Object obj)
        {
            //WriteLocalMsg(obj.GetType().ToString(), MsgType.info);
            try
            {
                StringBuilder insertSql = new StringBuilder();
                StringBuilder paramSql = new StringBuilder();
                // System.Type tt2 = t.GetType(typeof(T).ToString());//获取指定名称的类型
                // System.Type tt3 = obj.GetType();
                //object ff2 = Activator.CreateInstance(tt2, null);//创建指定类型实例
                PropertyInfo[] propertyList = obj.GetType().GetProperties();//获取指定对象的所有公共属性

                string[] assemblyName = obj.GetType().ToString().Split('.');

                string dbTableName = tableName;

                insertSql.Append("INSERT INTO " + dbTableName + "(");
                paramSql.Append("SELECT ");

                List<SqlParameter> paramList = new List<SqlParameter>();

                foreach (PropertyInfo ti in propertyList)
                {
                    //获取特性清单
                    object[] propertyAttributes = ti.GetCustomAttributes(false);
                    //foreach (object item in propertyAttributes)
                    //{
                    //    if (item.GetType() == typeof(IRAPKeyAttribute))
                    //    {
                    //        Console.WriteLine(ti.Name + " 特性：IRAPKEY=" + (item as IRAPKeyAttribute).IsKey.ToString());
                    //    }
                    //}
                    bool isContinue = true;
                    foreach (object item in propertyAttributes)
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
                    object valueObj = ti.GetValue(obj, null);
                    if (valueObj != null)
                    {
                        insertSql.Append(ti.Name + ",");
                        paramSql.Append("@" + ti.Name + ",");

                        SqlDbType sqldbType = Convert2DBType.ToSqlType(ti.PropertyType.Name);
                        SqlParameter param = new SqlParameter("@" + ti.Name, sqldbType);
                        param.Value = valueObj;
                        paramList.Add(param);

                    }
                    //ti.SetValue(obj, reader[ti.Name], null);//给对象赋值
                    continue;
                }

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string saveSql = insertSql.ToString(0, insertSql.Length - 1) + ") \n" +
                    paramSql.ToString(0, paramSql.Length - 1);

                SqlCommand command = new SqlCommand(saveSql, conn) { CommandTimeout = _commandTimeout, };
                if (_trans != null)
                {
                    command.Transaction = _trans;
                }
                foreach (SqlParameter param in paramList)
                {
                    command.Parameters.Add(param);
                }
                int resInt = command.ExecuteNonQuery();

                return resInt;
            }
            catch (SqlException err)
            {
                throw new IRAPException(9999, "保存数据异常！", err);
            }

        }

        public int Insert(Object obj)
        {
            //WriteLocalMsg(obj.GetType().ToString(), MsgType.info);
            try
            {
                StringBuilder insertSql = new StringBuilder();
                StringBuilder paramSql = new StringBuilder();
                // System.Type tt2 = t.GetType(typeof(T).ToString());//获取指定名称的类型
                // System.Type tt3 = obj.GetType();
                //object ff2 = Activator.CreateInstance(tt2, null);//创建指定类型实例
                PropertyInfo[] propertyList = obj.GetType().GetProperties();//获取指定对象的所有公共属性

                string[] assemblyName = obj.GetType().ToString().Split('.');

                string dbTableName = assemblyName[assemblyName.Length - 1];
                object[] classAttributes = obj.GetType().GetCustomAttributes(false);
                foreach (object item in classAttributes)
                {
                    if (item.GetType() == typeof(IRAPDBAttribute))
                    {
                        dbTableName = (item as IRAPDBAttribute).TableName;
                    }
                }
                insertSql.Append("INSERT INTO " + dbTableName + "(");
                paramSql.Append("SELECT ");

                List<SqlParameter> paramList = new List<SqlParameter>();

                foreach (PropertyInfo ti in propertyList)
                {
                    //获取特性清单
                    object[] propertyAttributes = ti.GetCustomAttributes(false);
                    bool isContinue = true;
                    foreach (object item in propertyAttributes)
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
                    object valueObj = ti.GetValue(obj, null);
                    if (valueObj != null)
                    {
                        insertSql.Append(ti.Name + ",");
                        paramSql.Append("@" + ti.Name + ",");

                        SqlDbType sqldbType = Convert2DBType.ToSqlType(ti.PropertyType.Name);
                        SqlParameter param = new SqlParameter("@" + ti.Name, sqldbType);
                        param.Value = valueObj;
                        paramList.Add(param);
                    }
                    //ti.SetValue(obj, reader[ti.Name], null);//给对象赋值
                    continue;
                }

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string saveSql = insertSql.ToString(0, insertSql.Length - 1) + ") \n" +
                    paramSql.ToString(0, paramSql.Length - 1);

                SqlCommand command = new SqlCommand(saveSql, conn) { CommandTimeout = _commandTimeout, };
                if (_trans != null)
                {
                    command.Transaction = _trans;
                }
                foreach (SqlParameter param in paramList)
                {
                    command.Parameters.Add(param);
                }
                int resInt = command.ExecuteNonQuery();

                return resInt;
            }
            catch (SqlException err)
            {
                if (_trans != null)
                {
                    RollBack();
                }
                throw new IRAPException(9999, "保存数据异常！", err);
            }

        }

        public int UpdateTable(string tableName, Object obj)
        {
            try
            {
                StringBuilder updateSql = new StringBuilder();
                //StringBuilder paramSql = new StringBuilder();
                StringBuilder whereSql = new StringBuilder();
                // System.Type tt2 = t.GetType(typeof(T).ToString());//获取指定名称的类型
                // System.Type tt3 = obj.GetType();
                //object ff2 = Activator.CreateInstance(tt2, null);//创建指定类型实例
                PropertyInfo[] propertyList = obj.GetType().GetProperties();//获取指定对象的所有公共属性

                string[] assemblyName = obj.GetType().ToString().Split('.');

                string dbTableName = tableName;

                updateSql.Append("UPDATE " + dbTableName + " SET ");
                whereSql.Append(" WHERE ");

                List<SqlParameter> paramList = new List<SqlParameter>();

                foreach (PropertyInfo ti in propertyList)
                {
                    object valueObj = ti.GetValue(obj, null);
                    bool isKey = false;
                    bool isContinue = true;
                    //获取特性清单
                    object[] propertyAttributes = ti.GetCustomAttributes(false);
                    foreach (object item in propertyAttributes)
                    {
                        if (item.GetType() == typeof(IRAPORMMapAttribute))
                        {
                            if (!(item as IRAPORMMapAttribute).ORMMap)
                            {
                                isContinue = false;
                                break;
                            }
                        }

                        if (item.GetType() == typeof(IRAPKeyAttribute))
                        {
                            //Console.WriteLine(ti.Name + " 特性：IRAPKEY=" + (item as IRAPKeyAttribute).IsKey.ToString());
                            if ((item as IRAPKeyAttribute).IsKey)
                            {
                                if (valueObj == null)
                                {
                                    throw new IRAPException(9991, ti.Name + "字段被定义为主键，因此更新时不能为NULL，请检查。");
                                }
                                if (whereSql.Length > 8)
                                {
                                    whereSql.Append(" AND ");
                                }
                                whereSql.Append(ti.Name + "=@k_" + ti.Name);
                                SqlDbType sqldbType = Convert2DBType.ToSqlType(ti.PropertyType.Name);
                                SqlParameter param = new SqlParameter("@k_" + ti.Name, sqldbType);
                                param.Value = valueObj;
                                paramList.Add(param);
                                isKey = true;
                            }
                        }
                    }
                    if (!isContinue)
                    {
                        continue;
                    }
                    if (valueObj != null)
                    {
                        if (!isKey)
                        {
                            updateSql.Append(ti.Name + "=@" + ti.Name + ",");

                            SqlDbType sqldbType = Convert2DBType.ToSqlType(ti.PropertyType.Name);
                            SqlParameter param = new SqlParameter("@" + ti.Name, sqldbType);
                            param.Value = valueObj;
                            paramList.Add(param);
                        }
                    }
                    //ti.SetValue(obj, reader[ti.Name], null);//给对象赋值
                    continue;
                }

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string saveSql = updateSql.ToString(0, updateSql.Length - 1) + " \n" + whereSql.ToString();

                SqlCommand command = new SqlCommand(saveSql, conn) { CommandTimeout = _commandTimeout, };
                if (_trans != null)
                {
                    command.Transaction = _trans;
                }
                foreach (SqlParameter param in paramList)
                {
                    command.Parameters.Add(param);
                }
                int resInt = command.ExecuteNonQuery();

                return resInt;
            }
            catch (SqlException err)
            {
                if (_trans != null)
                {
                    RollBack();
                }
                throw new IRAPException(9999, "更新数据异常！", err);
            }

        }
        public int Update(Object obj)
        {
            try
            {
                StringBuilder updateSql = new StringBuilder();
                //StringBuilder paramSql = new StringBuilder();
                StringBuilder whereSql = new StringBuilder();
                // System.Type tt2 = t.GetType(typeof(T).ToString());//获取指定名称的类型
                // System.Type tt3 = obj.GetType();
                //object ff2 = Activator.CreateInstance(tt2, null);//创建指定类型实例
                PropertyInfo[] propertyList = obj.GetType().GetProperties();//获取指定对象的所有公共属性

                string[] assemblyName = obj.GetType().ToString().Split('.');

                string dbTableName = assemblyName[assemblyName.Length - 1];
                object[] classAttributes = obj.GetType().GetCustomAttributes(false);
                foreach (object item in classAttributes)
                {
                    if (item.GetType() == typeof(IRAPDBAttribute))
                    {
                        dbTableName = (item as IRAPDBAttribute).TableName;
                    }
                }
                updateSql.Append("UPDATE " + dbTableName + " SET ");
                whereSql.Append(" WHERE ");

                List<SqlParameter> paramList = new List<SqlParameter>();

                foreach (PropertyInfo ti in propertyList)
                {
                    object valueObj = ti.GetValue(obj, null);
                    bool isKey = false;
                    //获取特性清单
                    object[] propertyAttributes = ti.GetCustomAttributes(false);
                    bool isContinue = true;
                    foreach (object item in propertyAttributes)
                    {

                        if (item.GetType() == typeof(IRAPORMMapAttribute))
                        {
                            if (!(item as IRAPORMMapAttribute).ORMMap)
                            {
                                isContinue = false;
                                break;
                            }
                        }

                        if (item.GetType() == typeof(IRAPKeyAttribute))
                        {
                            //Console.WriteLine(ti.Name + " 特性：IRAPKEY=" + (item as IRAPKeyAttribute).IsKey.ToString());
                            if ((item as IRAPKeyAttribute).IsKey)
                            {
                                if (valueObj == null)
                                {
                                    throw new IRAPException(9991, ti.Name + "字段被定义为主键，因此更新时不能为NULL，请检查。");
                                }
                                if (whereSql.Length > 8)
                                {
                                    whereSql.Append(" AND ");
                                }
                                whereSql.Append(ti.Name + "=@k_" + ti.Name);
                                SqlDbType sqldbType = Convert2DBType.ToSqlType(ti.PropertyType.Name);
                                SqlParameter param = new SqlParameter("@k_" + ti.Name, sqldbType);
                                param.Value = valueObj;
                                paramList.Add(param);
                                isKey = true;
                            }
                        }
                    }
                    if (!isContinue)
                    {
                        continue;
                    }
                    if (valueObj != null)
                    {
                        if (!isKey)
                        {
                            updateSql.Append(ti.Name + "=@" + ti.Name + ",");

                            SqlDbType sqldbType = Convert2DBType.ToSqlType(ti.PropertyType.Name);
                            SqlParameter param = new SqlParameter("@" + ti.Name, sqldbType);
                            param.Value = valueObj;
                            paramList.Add(param);
                        }
                    }
                    //ti.SetValue(obj, reader[ti.Name], null);//给对象赋值
                    continue;
                }

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string saveSql = updateSql.ToString(0, updateSql.Length - 1) + " \n" + whereSql.ToString();

                SqlCommand command = new SqlCommand(saveSql, conn) { CommandTimeout = _commandTimeout, };
                if (_trans != null)
                {
                    command.Transaction = _trans;
                }
                foreach (SqlParameter param in paramList)
                {
                    command.Parameters.Add(param);
                }
                int resInt = command.ExecuteNonQuery();

                return resInt;
            }
            catch (SqlException err)
            {
                if (_trans != null)
                {
                    RollBack();
                }
                throw new IRAPException(9999, "更新数据异常！", err);
            }

        }

        public int Update(string updateSql, IList<IDataParameter> paramList)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand command = new SqlCommand(updateSql, conn) { CommandTimeout = _commandTimeout, };
                foreach (IRAPProcParameter param in paramList)
                {
                    SqlDbType sqlType = ConvertSqlType.ToSqlType(param.DbType);
                    SqlParameter trueParam = new SqlParameter(param.ParameterName, sqlType);
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
                if (_trans != null)
                {
                    command.Transaction = _trans;
                }
                int resInt = command.ExecuteNonQuery();
                return resInt;
            }
            catch (SqlException err)
            {
                if (_trans != null)
                {
                    RollBack();
                }
                throw new IRAPException(9999, "更新数据异常！", err);
            }

        }
        public int Delete<T>(string whereSql)
        {
            try
            {
                System.Type tempType = null;
                foreach (Assembly item in _LoadAssembly)
                {
                    tempType = item.GetType(typeof(T).ToString());
                    if (tempType != null)
                    {
                        break;
                    }
                }
                object obj = Activator.CreateInstance(tempType, null);//创
                StringBuilder deleteSql = new StringBuilder();
                string dbTableName = string.Empty;
                object[] classAttributes = obj.GetType().GetCustomAttributes(false);
                foreach (object item in classAttributes)
                {
                    if (item.GetType() == typeof(IRAPDBAttribute))
                    {
                        dbTableName = (item as IRAPDBAttribute).TableName;
                    }
                }
                deleteSql.Append("DELETE FROM " + dbTableName + " WHERE " + whereSql);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                SqlCommand command = new SqlCommand(deleteSql.ToString(), conn) { CommandTimeout = _commandTimeout, };
                if (_trans != null)
                {
                    command.Transaction = _trans;
                }

                int resInt = command.ExecuteNonQuery();

                return resInt;
            }
            catch (SqlException err)
            {
                if (_trans != null)
                {
                    RollBack();
                }
                throw new IRAPException(9999, "删除数据异常！", err);
            }
        }
        public int Delete(string tableName, Object obj)
        {
            try
            {
                StringBuilder deleteSql = new StringBuilder();
                //StringBuilder paramSql = new StringBuilder();
                StringBuilder whereSql = new StringBuilder();
                // System.Type tt2 = t.GetType(typeof(T).ToString());//获取指定名称的类型
                // System.Type tt3 = obj.GetType();
                //object ff2 = Activator.CreateInstance(tt2, null);//创建指定类型实例
                PropertyInfo[] propertyList = obj.GetType().GetProperties();//获取指定对象的所有公共属性

                string[] assemblyName = obj.GetType().ToString().Split('.');

                string dbTableName = tableName;
                deleteSql.Append("DELETE FROM " + dbTableName);
                whereSql.Append(" WHERE ");

                List<SqlParameter> paramList = new List<SqlParameter>();
                foreach (PropertyInfo ti in propertyList)
                {
                    object valueObj = ti.GetValue(obj, null);
                    //获取特性清单
                    object[] propertyAttributes = ti.GetCustomAttributes(false);
                    foreach (object item in propertyAttributes)
                    {
                        if (item.GetType() == typeof(IRAPKeyAttribute))
                        {
                            //Console.WriteLine(ti.Name + " 特性：IRAPKEY=" + (item as IRAPKeyAttribute).IsKey.ToString());
                            if ((item as IRAPKeyAttribute).IsKey)
                            {
                                if (valueObj == null)
                                {
                                    throw new IRAPException(9991, ti.Name + "字段被定义为主键，因此更新时不能为NULL，请检查。");
                                }
                                if (whereSql.Length > 8)
                                {
                                    whereSql.Append(" AND ");
                                }
                                whereSql.Append(ti.Name + "=@k_" + ti.Name);
                                SqlDbType sqldbType = Convert2DBType.ToSqlType(ti.PropertyType.Name);
                                SqlParameter param = new SqlParameter("@k_" + ti.Name, sqldbType);
                                param.Value = valueObj;
                                paramList.Add(param);

                            }
                        }
                    }
                    //ti.SetValue(obj, reader[ti.Name], null);//给对象赋值
                    continue;
                }

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string saveSql = deleteSql.ToString() + " \n" + whereSql.ToString();

                SqlCommand command = new SqlCommand(saveSql, conn) { CommandTimeout = _commandTimeout, };
                if (_trans != null)
                {
                    command.Transaction = _trans;
                }
                foreach (SqlParameter param in paramList)
                {
                    command.Parameters.Add(param);
                }
                int resInt = command.ExecuteNonQuery();

                return resInt;
            }
            catch (SqlException err)
            {
                if (_trans != null)
                {
                    RollBack();
                }
                throw new IRAPException(9999, "删除数据异常！", err);
            }
        }
        public int Delete(Object obj)
        {
            try
            {
                StringBuilder deleteSql = new StringBuilder();
                //StringBuilder paramSql = new StringBuilder();
                StringBuilder whereSql = new StringBuilder();
                // System.Type tt2 = t.GetType(typeof(T).ToString());//获取指定名称的类型
                // System.Type tt3 = obj.GetType();
                //object ff2 = Activator.CreateInstance(tt2, null);//创建指定类型实例
                PropertyInfo[] propertyList = obj.GetType().GetProperties();//获取指定对象的所有公共属性

                string[] assemblyName = obj.GetType().ToString().Split('.');

                string dbTableName = assemblyName[assemblyName.Length - 1];
                object[] classAttributes = obj.GetType().GetCustomAttributes(false);
                foreach (object item in classAttributes)
                {
                    if (item.GetType() == typeof(IRAPDBAttribute))
                    {
                        dbTableName = (item as IRAPDBAttribute).TableName;
                    }
                }
                deleteSql.Append("DELETE FROM " + dbTableName);
                whereSql.Append(" WHERE ");

                List<SqlParameter> paramList = new List<SqlParameter>();

                foreach (PropertyInfo ti in propertyList)
                {
                    object valueObj = ti.GetValue(obj, null);
                    //获取特性清单
                    object[] propertyAttributes = ti.GetCustomAttributes(false);
                    foreach (object item in propertyAttributes)
                    {
                        if (item.GetType() == typeof(IRAPKeyAttribute))
                        {
                            //Console.WriteLine(ti.Name + " 特性：IRAPKEY=" + (item as IRAPKeyAttribute).IsKey.ToString());
                            if ((item as IRAPKeyAttribute).IsKey)
                            {
                                if (valueObj == null)
                                {
                                    throw new IRAPException(9991, ti.Name + "字段被定义为主键，因此更新时不能为NULL，请检查。");
                                }
                                if (whereSql.Length > 8)
                                {
                                    whereSql.Append(" AND ");
                                }
                                whereSql.Append(ti.Name + "=@k_" + ti.Name);
                                SqlDbType sqldbType = Convert2DBType.ToSqlType(ti.PropertyType.Name);
                                SqlParameter param = new SqlParameter("@k_" + ti.Name, sqldbType);
                                param.Value = valueObj;
                                paramList.Add(param);

                            }
                        }
                    }
                    //ti.SetValue(obj, reader[ti.Name], null);//给对象赋值
                    continue;
                }

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string saveSql = deleteSql.ToString() + " \n" + whereSql.ToString();

                SqlCommand command = new SqlCommand(saveSql, conn) { CommandTimeout = _commandTimeout, };
                if (_trans != null)
                {
                    command.Transaction = _trans;
                }
                foreach (SqlParameter param in paramList)
                {
                    command.Parameters.Add(param);
                }
                int resInt = command.ExecuteNonQuery();

                return resInt;
            }
            catch (SqlException err)
            {
                if (_trans != null)
                {
                    RollBack();
                }
                throw new IRAPException(9999, "删除数据异常！", err);
            }
        }

        public int BatchInsert<T>(IList<T> objList)
        {
            int res = 0;
            BeginTran();
            try
            {
                foreach (T obj in objList)
                {
                    res += Insert(obj);
                }
                Commit();
                return res;
            }
            catch (IRAPException err)
            {
                WriteLocalMsg("批量保存异常：" + err.Message, MsgType.error);
                RollBack();
                throw err;
            }
        }

        public DataSet CallProcEx(string procName, ref IList<IDataParameter> paramList)
        {
            bool IsOutputInfo = false;
            SqlCommand command = new SqlCommand() { CommandTimeout = _commandTimeout, };
            command.Connection = conn;

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            foreach (IRAPProcParameter param in paramList)
            {
                if (param.ParameterName == "@ErrCode")
                {
                    IsOutputInfo = true;
                }
                SqlDbType sqlType = ConvertSqlType.ToSqlType(param.DbType);
                SqlParameter trueParam = new SqlParameter(param.ParameterName, sqlType);
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

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(command);

            try
            {
                da.Fill(ds);
                if (IsOutputInfo)
                {
                    error.ErrCode = int.Parse(command.Parameters["@ErrCode"].Value.ToString());
                    error.ErrText = command.Parameters["@ErrText"].Value.ToString();
                }
                else
                {
                    error.ErrCode = 0;
                    error.ErrText = "过程：" + procName + "调用成功！";
                }
                //赋值给参数
                foreach (SqlParameter item in command.Parameters)
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

                return ds;
            }
            catch (SqlException err)
            {
                foreach (SqlError item in err.Errors)
                {
                    WriteLocalMsg(item.Message + "(" + item.LineNumber.ToString() + ")", MsgType.error);

                }
                IRAPError errorExcept = new IRAPError();
                errorExcept.ErrText = err.Message;
                errorExcept.ErrCode = 9999;
                return ds;
            }
            catch (Exception err)
            {
                throw new IRAPException(9999, err.ToString(), err);
            }
        }
        public IRAPError CallProc(string procName, ref IList<IDataParameter> paramList)
        {
            bool IsOutputInfo = false;
            SqlCommand command = new SqlCommand() { CommandTimeout = _commandTimeout, };
            command.Connection = conn;

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            foreach (IRAPProcParameter param in paramList)
            {
                if (param.ParameterName == "@ErrCode")
                {
                    IsOutputInfo = true;
                }

                SqlDbType sqlType = ConvertSqlType.ToSqlType(param.DbType);
                SqlParameter trueParam = new SqlParameter(param.ParameterName, sqlType);

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
                    error.ErrText = "过程：" + procName + "调用成功！";
                }
                //赋值给参数
                foreach (SqlParameter item in command.Parameters)
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
            catch (SqlException err)
            {
                foreach (SqlError item in err.Errors)
                {
                    WriteLocalMsg(item.Message + "(" + item.LineNumber.ToString() + ")", MsgType.error);

                }
                IRAPError errorExcept = new IRAPError();
                errorExcept.ErrText = "存储过程异常：" + procName + ":" + err.Message;
                errorExcept.ErrCode = 9999;
                return errorExcept;
            }
            catch (Exception err)
            {
                throw new IRAPException(9999, "调用过程出现错误，可能是输出参数长度设置不正确。", err);
            }
        }

        public Object GetFirst<T>(Type tt2, string whereSql)
        {

            object ff2 = Activator.CreateInstance(tt2, null);//创建指定类型实例
            PropertyInfo[] fields2 = ff2.GetType().GetProperties();//获取指定对象的所有公共属性
            string[] assemblyName = ff2.GetType().ToString().Split('.');
            string dbTableName = assemblyName[assemblyName.Length - 1];
            object[] classAttributes = ff2.GetType().GetCustomAttributes(false);
            foreach (object item in classAttributes)
            {
                if (item.GetType() == typeof(IRAPDBAttribute))
                {
                    dbTableName = (item as IRAPDBAttribute).TableName;
                }
            }
            StringBuilder selectSql = new StringBuilder();
            selectSql.Append("select * from " + dbTableName);

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string querySql = selectSql.ToString() + " \n" + whereSql.ToString();
                SqlCommand command2 = new SqlCommand(querySql, conn) { CommandTimeout = _commandTimeout, };

                SqlDataReader reader = command2.ExecuteReader();
                object resobj = Activator.CreateInstance(tt2, null);
                PropertyInfo[] fieldsList = ff2.GetType().GetProperties();
                try
                {
                    while (reader.Read())
                    {
                        foreach (PropertyInfo ti in fieldsList)
                        {
                            bool isContinue = true;
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
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.DateTime))
                                    {
                                        ti.SetValue(resobj, new DateTime(1900, 1, 2), null);//给对象赋值
                                        continue;
                                    }
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Decimal))
                                    {
                                        ti.SetValue(resobj, Convert.ToDecimal(0.00), null);
                                        continue;
                                    }
                                    ti.SetValue(resobj, reader[ti.Name], null);//给对象赋值
                                }
                            }
                            catch (IndexOutOfRangeException outErr)
                            {
                                throw new IRAPException(9999, "数据库表中没有此字段：" + ti.Name, outErr);
                            }
                        }
                        return resobj;
                    }
                }
                finally
                {
                    reader.Close();
                }
                throw new Exception("没有发现记录！");
            }
            catch (SqlException err)
            {
                throw new IRAPException(9999, "Get查询数据异常！", err);
            }

        }
        public Object Get<T>(T obj)
        {
            StringBuilder selectSql = new StringBuilder();
            StringBuilder whereSql = new StringBuilder();
            PropertyInfo[] propertyList = obj.GetType().GetProperties();//获取指定对象的所有公共属性
            string[] assemblyName = obj.GetType().ToString().Split('.');
            string dbTableName = assemblyName[assemblyName.Length - 1];
            object[] classAttributes = obj.GetType().GetCustomAttributes(false);
            foreach (object item in classAttributes)
            {
                if (item.GetType() == typeof(IRAPDBAttribute))
                {
                    dbTableName = (item as IRAPDBAttribute).TableName;
                }
            }

            List<SqlParameter> paramList = new List<SqlParameter>();
            selectSql.Append("select * from " + dbTableName);
            whereSql.Append(" WHERE ");
            //获取特性清单
            foreach (PropertyInfo ti in propertyList)
            {
                object valueObj = ti.GetValue(obj, null);
                object[] propertyAttributes = ti.GetCustomAttributes(false);
                foreach (object item in propertyAttributes)
                {
                    if (item.GetType() == typeof(IRAPKeyAttribute))
                    {
                        //Console.WriteLine(ti.Name + " 特性：IRAPKEY=" + (item as IRAPKeyAttribute).IsKey.ToString());
                        if ((item as IRAPKeyAttribute).IsKey)
                        {
                            if (valueObj == null)
                            {
                                throw new IRAPException(9991, ti.Name + "字段被定义为主键，因此查询时不能为NULL，请检查。");
                            }
                            if (whereSql.Length > 8)
                            {
                                whereSql.Append(" AND ");
                            }
                            whereSql.Append(ti.Name + "=@k_" + ti.Name);
                            SqlDbType sqldbType = Convert2DBType.ToSqlType(ti.PropertyType.Name);
                            SqlParameter param = new SqlParameter("@k_" + ti.Name, sqldbType);
                            param.Value = valueObj;
                            paramList.Add(param);
                        }
                    }
                }
            }

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string querySql = selectSql.ToString() + " \n" + whereSql.ToString();
                SqlCommand command2 = new SqlCommand(querySql, conn) { CommandTimeout = _commandTimeout, };
                foreach (SqlParameter param in paramList)
                {
                    command2.Parameters.Add(param);
                }
                SqlDataReader reader = command2.ExecuteReader();
                bool getData = false;
                object resobj = Activator.CreateInstance(obj.GetType(), null);
                while (reader.Read())
                {
                    foreach (PropertyInfo ti in propertyList)
                    {
                        bool isContinue = true;
                        try
                        {
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
                            if (reader[ti.Name] != null)
                            {
                                if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.DateTime))
                                {
                                    ti.SetValue(resobj, new DateTime(1900, 1, 2), null);//给对象赋值
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
                                ti.SetValue(resobj, reader[ti.Name], null);//给对象赋值
                            }
                        }
                        catch (IndexOutOfRangeException outErr)
                        {
                            reader.Close();
                            throw new IRAPException(9999, "数据库表中没有此字段：" + ti.Name, outErr);
                        }
                    }
                    getData = true;
                }
                reader.Close();
                if (getData)
                {
                    return resobj;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException err)
            {
                throw new IRAPException(9999, "Get查询数据异常！", err);
            }

        }

        public Object Get<T>(string tableName, T obj)
        {
            StringBuilder selectSql = new StringBuilder();
            StringBuilder whereSql = new StringBuilder();
            PropertyInfo[] propertyList = obj.GetType().GetProperties();//获取指定对象的所有公共属性
            string[] assemblyName = obj.GetType().ToString().Split('.');
            string dbTableName = assemblyName[assemblyName.Length - 1];
            object[] classAttributes = obj.GetType().GetCustomAttributes(false);
            //foreach (object item in classAttributes)
            //{
            //    if (item.GetType() == typeof(IRAPDBAttribute))
            //    {
            //        dbTableName = (item as IRAPDBAttribute).TableName;
            //    }
            //}
            dbTableName = tableName;

            List<SqlParameter> paramList = new List<SqlParameter>();
            selectSql.Append("select * from " + dbTableName);
            whereSql.Append(" WHERE ");
            //获取特性清单
            foreach (PropertyInfo ti in propertyList)
            {
                object valueObj = ti.GetValue(obj, null);
                object[] propertyAttributes = ti.GetCustomAttributes(false);
                foreach (object item in propertyAttributes)
                {
                    if (item.GetType() == typeof(IRAPKeyAttribute))
                    {
                        //Console.WriteLine(ti.Name + " 特性：IRAPKEY=" + (item as IRAPKeyAttribute).IsKey.ToString());
                        if ((item as IRAPKeyAttribute).IsKey)
                        {
                            if (valueObj == null)
                            {
                                throw new IRAPException(9991, ti.Name + "字段被定义为主键，因此查询时不能为NULL，请检查。");
                            }
                            if (whereSql.Length > 8)
                            {
                                whereSql.Append(" AND ");
                            }
                            whereSql.Append(ti.Name + "=@k_" + ti.Name);
                            SqlDbType sqldbType = Convert2DBType.ToSqlType(ti.PropertyType.Name);
                            SqlParameter param = new SqlParameter("@k_" + ti.Name, sqldbType);
                            param.Value = valueObj;
                            paramList.Add(param);
                        }
                    }
                }
            }

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string querySql = selectSql.ToString() + " \n" + whereSql.ToString();
                SqlCommand command2 = new SqlCommand(querySql, conn) { CommandTimeout = _commandTimeout, };
                foreach (SqlParameter param in paramList)
                {
                    command2.Parameters.Add(param);
                }
                SqlDataReader reader = command2.ExecuteReader();
                bool getData = false;
                object resobj = Activator.CreateInstance(obj.GetType(), null);
                while (reader.Read())
                {
                    foreach (PropertyInfo ti in propertyList)
                    {
                        bool isContinue = true;
                        try
                        {
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
                            if (reader[ti.Name] != null)
                            {
                                if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.DateTime))
                                {
                                    ti.SetValue(resobj, new DateTime(1900, 1, 2), null);//给对象赋值
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
                                ti.SetValue(resobj, reader[ti.Name], null);//给对象赋值
                            }
                        }
                        catch (IndexOutOfRangeException outErr)
                        {
                            reader.Close();
                            throw new IRAPException(9999, "数据库表中没有此字段：" + ti.Name, outErr);
                        }
                    }
                    getData = true;
                }
                reader.Close();
                if (getData)
                {
                    return resobj;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException err)
            {
                throw new IRAPException(9999, "Get查询数据异常！", err);
            }

        }
        public Object Get<T>(string querySql, IList<IDataParameter> paramList)
        {
            System.Type tempType = null;
            foreach (Assembly item in _LoadAssembly)
            {
                tempType = item.GetType(typeof(T).ToString());
                if (tempType != null)
                {
                    break;
                }
            }
            object returnObj = Activator.CreateInstance(tempType, null);//创建指定类型实例
            PropertyInfo[] propertyList = returnObj.GetType().GetProperties();
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand command2 = new SqlCommand(querySql, conn) { CommandTimeout = _commandTimeout, };
                foreach (IRAPProcParameter param in paramList)
                {
                    SqlDbType sqlType = ConvertSqlType.ToSqlType(param.DbType);
                    SqlParameter trueParam = new SqlParameter(param.ParameterName, sqlType);
                    trueParam.Direction = param.Direction;
                    trueParam.Size = param.Size;
                    trueParam.IsNullable = param.IsNullable;
                    trueParam.SourceColumn = param.SourceColumn;
                    trueParam.SourceVersion = param.SourceVersion;
                    if (trueParam.Direction == ParameterDirection.Input || trueParam.Direction == ParameterDirection.InputOutput)
                    {
                        trueParam.Value = param.Value;
                    }
                    command2.Parameters.Add(trueParam);
                }
                SqlDataReader reader = command2.ExecuteReader();


                while (reader.Read())
                {
                    foreach (PropertyInfo ti in propertyList)
                    {
                        bool isContinue = true;
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
                                if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.DateTime))
                                {
                                    ti.SetValue(returnObj, new DateTime(1900, 1, 2), null);//给对象赋值
                                    continue;
                                }
                                if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Decimal))
                                {
                                    ti.SetValue(returnObj, Convert.ToDecimal(0.00), null);
                                    continue;
                                }
                                ti.SetValue(returnObj, reader[ti.Name], null);//给对象赋值
                            }
                        }
                        catch (IndexOutOfRangeException outErr)
                        {
                            reader.Close();
                            throw new IRAPException(9999, "数据库表中没有此字段：" + ti.Name, outErr);
                        }
                    }
                    return returnObj; ;
                }
                reader.Close();
                throw new KeyNotFoundException("没有找到数据，请检查语句是否正确。");
            }
            catch (SqlException err)
            {
                throw new IRAPException(9999, "Get查询数据异常！", err);
            }

        }


        public Object CallScalar(string sql)
        {
            SqlCommand command = new SqlCommand(sql, conn) { CommandTimeout = _commandTimeout, };
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                object obj = command.ExecuteScalar();
                return obj;
            }
            catch (SqlException err)
            {
                foreach (SqlError item in err.Errors)
                {
                    WriteLocalMsg(item.Message + "(" + item.LineNumber.ToString() + ")", MsgType.error);
                }
                throw err;
            }
        }
        public Object CallScalar(string sql, IList<IDataParameter> paramList)
        {
            SqlCommand command = new SqlCommand(sql, conn) { CommandTimeout = _commandTimeout, };
            foreach (IRAPProcParameter param in paramList)
            {
                SqlDbType sqlType = ConvertSqlType.ToSqlType(param.DbType);
                SqlParameter trueParam = new SqlParameter(param.ParameterName, sqlType);
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
            try
            {
                object obj = command.ExecuteScalar();
                return obj;
            }
            catch (SqlException err)
            {
                foreach (SqlError item in err.Errors)
                {
                    WriteLocalMsg(item.Message + "(" + item.LineNumber.ToString() + ")", MsgType.error);
                }
                throw err;
            }
        }

        public Object CallScalarFunc(string funcName, IList<IDataParameter> paramList)
        {
            StringBuilder sql = new StringBuilder("SELECT " + funcName + "(");
            StringBuilder paramSql = new StringBuilder();

            SqlCommand command = new SqlCommand() { CommandTimeout = _commandTimeout, };
            command.Connection = conn;
            foreach (IRAPProcParameter param in paramList)
            {
                sql.Append(param.ParameterName + ",");

                SqlDbType sqlType = ConvertSqlType.ToSqlType(param.DbType);
                SqlParameter trueParam = new SqlParameter(param.ParameterName, sqlType);
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
            command.CommandText = sql.ToString(0, sql.Length - 1) + ")";
            //WriteLocalMsg(command.CommandText, MsgType.debug);
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
            catch (SqlException err)
            {
                foreach (SqlError item in err.Errors)
                {
                    WriteLocalMsg(item.Message + "(" + item.LineNumber.ToString() + ")", MsgType.error);
                }
                throw err;
            }
        }

        public IList<T> CallTableFunc<T>(string selectSql, IList<IDataParameter> paramList)
        {
            SqlCommand command = new SqlCommand() { CommandTimeout = _commandTimeout, };
            command.Connection = conn;
            // command.CommandType = CommandType.StoredProcedure;
            command.CommandText = selectSql;
            IList<T> pList = new BindingList<T>(); // new List<T>();

            foreach (IRAPProcParameter param in paramList)
            {
                SqlDbType sqlType = ConvertSqlType.ToSqlType(param.DbType);
                SqlParameter trueParam = new SqlParameter(param.ParameterName, sqlType);
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
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlDataReader reader = command.ExecuteReader();
                System.Type tt2 = null;
                foreach (Assembly item in _LoadAssembly)
                {
                    tt2 = item.GetType(typeof(T).ToString());
                    if (tt2 != null)
                    {
                        break;
                    }
                }
                if (tt2 == null)
                {
                    WriteLocalMsg("没有获取到类型：tt2", MsgType.error);
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
                                    if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.DateTime))
                                    {
                                        ti.SetValue(obj, new DateTime(1900, 1, 2), null);//给对象赋值
                                        continue;
                                    }
                                    else if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Byte[]))
                                    {
                                        ti.SetValue(obj, new byte[9], null);//如果对象为空赋值
                                        continue;
                                    }
                                    else if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.Decimal))
                                    {
                                        ti.SetValue(obj, Convert.ToDecimal(0.00), null);
                                        continue;
                                    }
                                    else if (reader[ti.Name] == System.DBNull.Value && ti.PropertyType == typeof(System.String))
                                    {
                                        ti.SetValue(obj, "", null);
                                        continue;
                                    }
                                    else
                                        ti.SetValue(obj, reader[ti.Name], null);//给对象赋值
                                }
                            }
                            catch (IndexOutOfRangeException outErr)
                            {
                                throw new IRAPException(9999, "数据库表中没有此字段：" + ti.Name, outErr); ;
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
            catch (SqlException err)
            {
                foreach (SqlError item in err.Errors)
                {
                    WriteLocalMsg(item.Message + "(" + item.LineNumber.ToString() + ")", MsgType.error);

                }
                //IRAPError errorExcept = new IRAPError();
                //errorExcept.ErrText = err.Message;
                //errorExcept.ErrCode = 9999;
                throw err;
            }
            catch (Exception err)
            {
                WriteLocalMsg(err.StackTrace, MsgType.error);
                throw new IRAPException(9999, "调用表值函数出现错误，可能是输出参数长度设置不正确。", err);

            }
        }

        public DataTable QuerySQL(string sql)
        {
            SqlCommand command = new SqlCommand(sql, conn) { CommandTimeout = _commandTimeout, };
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable("ORMTBL");
                adapter.Fill(dt);
                return dt;
            }
            catch (SqlException err)
            {
                foreach (SqlError item in err.Errors)
                {
                    WriteLocalMsg(item.Message + "(" + item.LineNumber.ToString() + ")", MsgType.error);
                }
                throw err;
            }
        }

        public DataTable QuerySQL(string sql, IList<IDataParameter> paramList)
        {
            SqlCommand command = new SqlCommand(sql, conn) { CommandTimeout = _commandTimeout, };
            foreach (IRAPProcParameter param in paramList)
            {

                SqlDbType sqlType = ConvertSqlType.ToSqlType(param.DbType);
                SqlParameter trueParam = new SqlParameter(param.ParameterName, sqlType);
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
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (SqlException err)
            {
                foreach (SqlError item in err.Errors)
                {
                    WriteLocalMsg(item.Message + "(" + item.LineNumber.ToString() + ")", MsgType.error);
                }
                throw err;
            }
        }

        #region 使用log4net写日志
        public static void WriteLocalMsg(string msg, MsgType infotype)
        {
            switch (infotype)
            {
                case MsgType.debug:
                    _logger.Debug(msg);
                    break;
                case MsgType.info:
                    _logger.Info(msg);
                    break;
                case MsgType.error:
                    _logger.Error(msg);
                    break;
                case MsgType.fatal:
                    _logger.Fatal(msg);
                    break;
                case MsgType.warn:
                    _logger.Debug(msg);
                    break;
                default:
                    _logger.Info(msg);
                    break;
            }

        }
        #endregion

        public void Dispose()
        {
            if (conn.State != ConnectionState.Closed && conn.State != ConnectionState.Broken)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public IList<T> List<T>(string querySql)
        {
            throw new NotImplementedException();
        }
    }
}

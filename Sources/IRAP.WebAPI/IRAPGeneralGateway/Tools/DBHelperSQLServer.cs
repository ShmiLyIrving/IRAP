using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Collections;

using IRAP.Global;

namespace IRAP.DBUtility
{
    /// <summary>
    /// 数据访问抽象基础类
    /// </summary>
    public class DBHelperSQLServer
    {
        /// <summary>
        /// 超时时长
        /// </summary>
        private int _timeOut = 60;
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string connectionString = "";

        public DBHelperSQLServer()
        {

        }

        /// <summary>
        /// 超时时长
        /// </summary>
        public int Timeout
        {
            get { return _timeOut; }
            set { _timeOut = value; }
        }

        /// <summary>
        /// SQL Server 数据库连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        /// <summary>
        /// 判断指定数据表的指定字段是否存在
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="colunmName">字段名</param>
        public bool ColumnExists(string tableName, string colunmName)
        {
            string sql =
                string.Format(
                    "SELECT COUNT(1) FROM SysColumns WHERE [id]=object_id('{0}') and [name]='{1}'",
                    tableName,
                    colunmName);

            object res = GetSingle(sql);
            if (res == null)
                return false;
            else
                return Convert.ToInt32(res) > 0;
        }

        /// <summary>
        /// 获取指定表中指定字段值的最大值
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="columnName">字段名</param>
        public int GetMaxID(string tableName, string columnName)
        {
            string sql =
                string.Format(
                    "SELECT MAX({0}) + 1 FROM {1}",
                    columnName,
                    tableName);

            object res = GetSingle(sql);
            if (res == null)
                return 1;
            else
                return Convert.ToInt32(res.ToString());
        }

        /// <summary>
        /// 用途未知
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        public bool Exists(string stringSQL)
        {
            object res = GetSingle(stringSQL);

            int cmdResult = 0;
            if (Equals(res, null) || Equals(res, DBNull.Value))
                cmdResult = 0;
            else
                cmdResult = int.Parse(res.ToString());

            if (cmdResult == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 用途未知
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        /// <param name="cmdParams">参数组</param>
        public bool Exists(string stringSQL, params SqlParameter[] cmdParams)
        {
            object res = GetSingle(stringSQL, cmdParams);

            int cmdResult = 0;
            if (Equals(res, null) || Equals(res, DBNull.Value))
                cmdResult = 0;
            else
                cmdResult = int.Parse(res.ToString());

            if (cmdResult == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 指定的数据表是否存在
        /// </summary>
        /// <param name="tableName">数据表名</param>
        public bool TableExists(string tableName)
        {
            string stringSQL =
                string.Format(
                    "SELECT COUNT(*) " +
                    "FROM SysObjects " +
                    "WHERE id=object_id(N'[{0}]') " +
                    "AND OBJECTPROPERTY(id, N'IsUserTable') = 1",
                    tableName);

            object res = GetSingle(stringSQL);
            int cmdResult = 0;
            if (Equals(res, null) || Equals(res, DBNull.Value))
                cmdResult = 0;
            else
                cmdResult = int.Parse(res.ToString());

            if (cmdResult == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 执行 SQL 语句，返回影响的记录数
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        public int ExecuteSQL(string stringSQL)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(stringSQL, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SqlException error)
                    {
                        connection.Close();
                        throw error;
                    }
                }
            }
        }

        /// <summary>
        /// 执行带一个存储过程参数的 SQL 语句
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        /// <param name="content">参数内容，比如一个字段是格式复杂的文章，有特殊符号。可以通过这个方式添加</param>
        public int ExecuteSQL(string stringSQL, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand(stringSQL, connection);
                SqlParameter param = new SqlParameter("@content", SqlDbType.NText);
                param.Value = content;
                sqlCmd.Parameters.Add(param);
                try
                {
                    connection.Open();
                    int rows = sqlCmd.ExecuteNonQuery();
                    return rows;
                }
                catch (SqlException error)
                {
                    throw error;
                }
                finally
                {
                    sqlCmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行 SQL 语句，返回影响的记录数
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        /// <param name="cmdParams">参数组</param>
        public int ExecuteSQL(string stringSQL, params SqlParameter[] cmdParams)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand(stringSQL, connection))
                {
                    try
                    {
                        PrepareCommand(sqlCmd, connection, null, stringSQL, cmdParams);
                        int rows = sqlCmd.ExecuteNonQuery();
                        sqlCmd.Parameters.Clear();
                        return rows;
                    }
                    catch (SqlException error)
                    {
                        throw error;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行 SQL 语句，返回影响的记录数，并指定执行超时时间
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        /// <param name="timeOut">超时时间</param>
        public int ExecuteSQLByTimeout(string stringSQL, int timeOut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(stringSQL, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = timeOut;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SqlException error)
                    {
                        connection.Close();
                        throw error;
                    }
                }
            }
        }

        /// <summary>
        /// 在事务中执行 SQL 语句命令列表
        /// </summary>
        /// <param name="cmdList">SQL 命令列表</param>
        public int ExecuteSQLTran(List<TCommandInfo> cmdList)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = connection;
                SqlTransaction tx = connection.BeginTransaction();
                sqlCmd.Transaction = tx;

                try
                {
                    foreach (TCommandInfo cmd in cmdList)
                    {
                        string cmdText = cmd.CommandText;
                        SqlParameter[] cmdParams = (SqlParameter[])cmd.Parameters;
                        PrepareCommand(sqlCmd, connection, tx, cmdText, cmdParams);

                        if (cmd.EffentNextType == TEffentNextType.SolicitationEvent)
                        {
                            if (!cmd.CommandText.ToLower().Contains("count("))
                            {
                                tx.Rollback();
                                throw new Exception(
                                    string.Format(
                                        "SQL 语句违背要求，[{0}] 必须符合 SELECT COUNT(... 的格式",
                                        cmd.CommandText));
                            }

                            object res = sqlCmd.ExecuteScalar();
                            bool isHave = false;
                            if (res == null && res == DBNull.Value)
                                isHave = false;
                            else
                                isHave = Convert.ToInt32(res) > 0;
                            if (isHave)
                                cmd.OnSolicitationEvent();      // 引发事件
                        }

                        if (cmd.EffentNextType == TEffentNextType.WhenHaveContinue ||
                            cmd.EffentNextType == TEffentNextType.WhenNoHaveContinue)
                        {
                            if (cmd.CommandText.ToLower().Contains("count("))
                            {
                                tx.Rollback();
                                throw new Exception(
                                    string.Format(
                                        "SQL 语句违背要求，[{0}] 必须符合 SELECT COUNT(... 的格式",
                                        cmd.CommandText));
                            }

                            object res = sqlCmd.ExecuteScalar();
                            bool isHave = false;
                            if (res == null && res == DBNull.Value)
                                isHave = false;
                            else
                                isHave = Convert.ToInt32(res) > 0;

                            if (cmd.EffentNextType == TEffentNextType.WhenHaveContinue && !isHave)
                            {
                                tx.Rollback();
                                throw new Exception(
                                    string.Format(
                                        "SQL 语句违背要求，[{0}] 的返回值必须大于 0",
                                        cmd.CommandText));
                            }
                            if (cmd.EffentNextType == TEffentNextType.WhenNoHaveContinue && isHave)
                            {
                                tx.Rollback();
                                throw new Exception(
                                    string.Format(
                                        "SQL 语句违背要求，[{0}] 的返回值必须小于 0",
                                        cmd.CommandText));
                            }

                            continue;
                        }

                        if (cmd.EffentNextType == TEffentNextType.None ||
                            cmd.EffentNextType == TEffentNextType.ExecuteEffectRows)
                        {
                            int val = sqlCmd.ExecuteNonQuery();
                            if (cmd.EffentNextType == TEffentNextType.ExecuteEffectRows && val == 0)
                            {
                                tx.Rollback();
                                throw new Exception(
                                    string.Format(
                                        "SQL 语句违背要求，[{0}] 的必须有影响行",
                                        cmd.CommandText));
                            }
                        }

                        sqlCmd.Parameters.Clear();
                    }

                    tx.Commit();
                    return 1;
                }
                catch (SqlException error)
                {
                    tx.Rollback();
                    throw error;
                }
                catch (Exception error)
                {
                    tx.Rollback();
                    throw error;
                }
            }
        }

        /// <summary>
        /// 在数据库事务中执行多条 SQL 语句
        /// </summary>
        /// <param name="cmds">SQL 语句集</param>
        public int ExecuteSQLTran(List<string> cmds)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = connection;
                SqlTransaction tx = connection.BeginTransaction();
                sqlCmd.Transaction = tx;

                try
                {
                    int count = 0;
                    foreach (string cmd in cmds)
                    {
                        if (cmd.Trim() != "")
                        {
                            sqlCmd.CommandText = cmd;
                            count += sqlCmd.ExecuteNonQuery();
                        }
                    }

                    tx.Commit();
                    return count;
                }
                catch (Exception error)
                {
                    tx.Rollback();
                    throw error;
                }
            }
        }

        /// <summary>
        /// 在数据库事务中执行多条 SQL 语句
        /// </summary>
        /// <param name="htCmds">SQL 语句的哈希表（Key 为 SQL 语句，Value 是该语句的 SqlParameter[]）</param>
        public void ExecuteSQLTran(Hashtable htCmds)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction trans = connection.BeginTransaction())
                {
                    SqlCommand sqlCmd = new SqlCommand();
                    try
                    {
                        foreach (DictionaryEntry cmd in htCmds)
                        {
                            string cmdText = cmd.Key.ToString();
                            SqlParameter[] cmdParams = (SqlParameter[])cmd.Value;
                            PrepareCommand(sqlCmd, connection, trans, cmdText, cmdParams);
                            int value = sqlCmd.ExecuteNonQuery();
                            sqlCmd.Parameters.Clear();
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 执行带一个存储过程参数的 SQL 语句，并返回结果集的第一行第一列
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        /// <param name="content">参数内容，比如一个字段是格式复杂的文章，有特殊符号。可以通过这个方式添加</param>
        public object ExecuteSQLGet(string stringSQL, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand(stringSQL, connection);
                SqlParameter param = new SqlParameter("@content", SqlDbType.NText);
                param.Value = content;
                sqlCmd.Parameters.Add(param);
                try
                {
                    connection.Open();
                    object res = sqlCmd.ExecuteScalar();
                    if (Equals(res, null) || Equals(res, DBNull.Value))
                        return null;
                    else
                        return res;
                }
                catch (SqlException error)
                {
                    throw error;
                }
                finally
                {
                    sqlCmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 向数据库中插入图像格式的字段
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        /// <param name="fs">图像字节，数据库的字段类型为 image 的情况</param>
        public int ExecuteSQLInsertImg(string stringSQL, byte[] fs)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand(stringSQL, connection);
                SqlParameter param = new SqlParameter("@fs", SqlDbType.Image);
                param.Value = fs;
                sqlCmd.Parameters.Add(param);
                try
                {
                    connection.Open();
                    int rows = sqlCmd.ExecuteNonQuery();
                    return rows;
                }
                catch (SqlException error)
                {
                    throw error;
                }
                finally
                {
                    sqlCmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（Object）
        /// </summary>
        /// <param name="stringSQL">计算查询结果语句</param>
        public object GetSingle(string stringSQL)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand(stringSQL, connection))
                {
                    try
                    {
                        connection.Open();
                        object res = sqlCmd.ExecuteScalar();
                        if (Equals(res, null) || Equals(res, DBNull.Value))
                            return null;
                        else
                            return res;
                    }
                    catch (SqlException error)
                    {
                        throw error;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 在超时时间范围内执行一条计算查询结果语句，返回查询结果，
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        /// <param name="timeOut">超时时间</param>
        public object GetSingle(string stringSQL, int timeOut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand(stringSQL, connection))
                {
                    try
                    {
                        connection.Open();
                        sqlCmd.CommandTimeout = timeOut;
                        object res = sqlCmd.ExecuteScalar();
                        if (Equals(res, null) || Equals(res, DBNull.Value))
                            return null;
                        else
                            return res;
                    }
                    catch (SqlException error)
                    {
                        throw error;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（Object）
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        /// <param name="cmdParams">参数组</param>
        public object GetSingle(string stringSQL, params SqlParameter[] cmdParams)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand(stringSQL, connection))
                {
                    try
                    {
                        PrepareCommand(sqlCmd, connection, null, stringSQL, cmdParams);
                        object res = sqlCmd.ExecuteScalar();
                        sqlCmd.Parameters.Clear();

                        if (Equals(res, null) || Equals(res, DBNull.Value))
                            return null;
                        else
                            return res;
                    }
                    catch (SqlException error)
                    {
                        throw error;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回 SqlDataReader（注意：需要手动关闭 SqlDataReader）
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        public SqlDataReader ExecuteReader(string stringSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(stringSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader sdr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return sdr;
            }
            catch (SqlException error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 执行查询语句，返回 SqlDataReader（注意：需要手动关闭 SqlDataReader）
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        /// <param name="cmdParams">参数组</param>
        public SqlDataReader ExecuteReader(string stringSQL, params SqlParameter[] cmdParams)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(stringSQL, connection);
            try
            {
                PrepareCommand(sqlCmd, connection, null, stringSQL, cmdParams);
                SqlDataReader sdr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                sqlCmd.Parameters.Clear();
                return sdr;
            }
            catch (SqlException error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 执行查询语句，返回 DataSet
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        public DataSet Query(string stringSQL)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(stringSQL, connection);
                    sda.Fill(ds, "ds");
                }
                catch (SqlException error)
                {
                    throw new Exception(error.Message);
                }

                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回 DataSet
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        /// <param name="timeOut">超时时间</param>
        public DataSet Query(string stringSQL, int timeOut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(stringSQL, connection);
                    sda.SelectCommand.CommandTimeout = timeOut;
                    sda.Fill(ds, "ds");
                }
                catch (SqlException error)
                {
                    throw new Exception(error.Message);
                }

                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回 DataSet
        /// </summary>
        /// <param name="stringSQL">SQL 语句</param>
        /// <param name="cmdParams">参数组</param>
        public DataSet Query(string stringSQL, params SqlParameter[] cmdParams)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand();
                PrepareCommand(sqlCmd, connection, null, stringSQL, cmdParams);
                using (SqlDataAdapter sda = new SqlDataAdapter(sqlCmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        sda.Fill(ds, "ds");
                        sqlCmd.Parameters.Clear();
                    }
                    catch (SqlException error)
                    {
                        throw new Exception(error.Message);
                    }

                    return ds;
                }
            }
        }

        /// <summary>
        /// 在数据库事务中执行多条 SQL 语句
        /// </summary>
        /// <param name="cmds">SQL 命令列表</param>
        public void ExecuteSQLTranWithIndentity(List<TCommandInfo> cmds)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction trans = connection.BeginTransaction())
                {
                    SqlCommand sqlCmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;

                        foreach (TCommandInfo cmd in cmds)
                        {
                            string cmdText = cmd.CommandText;
                            SqlParameter[] cmdParams = (SqlParameter[])cmd.Parameters;
                            foreach (SqlParameter param in cmdParams)
                            {
                                if (param.Direction == ParameterDirection.InputOutput)
                                    param.Value = indentity;
                            }

                            PrepareCommand(sqlCmd, connection, trans, cmdText, cmdParams);
                            int value = sqlCmd.ExecuteNonQuery();
                            foreach (SqlParameter param in cmdParams)
                            {
                                if (param.Direction == ParameterDirection.Output)
                                    indentity = Convert.ToInt32(param.Value);
                            }

                            sqlCmd.Parameters.Clear();
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 在数据库事务中执行多条 SQL 语句
        /// </summary>
        /// <param name="htCmds">SQL 语句的哈希表（Key 为 SQL 语句，Value 是该语句的 SqlParameter[]）</param>
        public void ExecuteSQLTranWithIndentity(Hashtable htCmds)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction trans = connection.BeginTransaction())
                {
                    SqlCommand sqlCmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;

                        foreach (DictionaryEntry cmd in htCmds)
                        {
                            string cmdText = cmd.Key.ToString();
                            SqlParameter[] cmdParams = (SqlParameter[])cmd.Value;
                            foreach (SqlParameter param in cmdParams)
                                if (param.Direction == ParameterDirection.InputOutput)
                                    param.Value = indentity;

                            PrepareCommand(sqlCmd, connection, trans, cmdText, cmdParams);
                            int value = sqlCmd.ExecuteNonQuery();
                            foreach (SqlParameter param in cmdParams)
                                if (param.Direction == ParameterDirection.Output)
                                    indentity = Convert.ToInt32(param.Value);

                            sqlCmd.Parameters.Clear();
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        private void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParams)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            if (cmdParams != null)
            {
                foreach (SqlParameter param in cmdParams)
                {
                    if ((param.Direction == ParameterDirection.InputOutput ||
                        param.Direction == ParameterDirection.Input) &&
                        param.Value == null)
                        param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);
                }
            }
        }

        /// <summary>
        /// 执行存储过程，返回 SqlDataReader（手工关闭 SqlDataReader）
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="schema">所有者</param>
        /// <param name="storeProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        public SqlDataReader RunProcedure(
            string dbName,
            string schema,
            string storeProcName,
            IDataParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader sdr = null;

            connection.Open();
            SqlCommand cmd = BuildQueryCommand(connection, dbName, schema, storeProcName, parameters);
            cmd.CommandType = CommandType.StoredProcedure;
            sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            return sdr;
        }

        /// <summary>
        /// 执行存储过程，返回 DataSet
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="schema">所有者</param>
        /// <param name="storeProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet 结果中的表名</param>
        public DataSet RunProcedure(
            string dbName,
            string schema,
            string storeProcName,
            IDataParameter[] parameters,
            string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();

                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = BuildQueryCommand(connection, dbName, schema, storeProcName, parameters);
                sda.Fill(ds, tableName);
                connection.Close();

                return ds;
            }
        }

        /// <summary>
        /// 执行存储过程，返回 DataSet
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="schema">所有者</param>
        /// <param name="storeProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet 结果中的表名</param>
        /// <param name="timeOut">超时时间</param>
        public DataSet RunProcedure(
            string dbName,
            string schema,
            string storeProcName,
            IDataParameter[] parameters,
            string tableName, int timeOut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();

                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = BuildQueryCommand(connection, dbName, schema, storeProcName, parameters);
                sda.SelectCommand.CommandTimeout = timeOut;
                sda.Fill(ds, tableName);
                connection.Close();

                return ds;
            }
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="schema">所有者</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        public int RunProcedure(
            string dbName,
            string schema,
            string storedProcName,
            IDataParameter[] parameters,
            out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result = 0;

                connection.Open();
                SqlCommand cmd = BuildIntCommand(connection, dbName, schema, storedProcName, parameters);
                rowsAffected = cmd.ExecuteNonQuery();
                result = (int)cmd.Parameters["ReturnValue"].Value;

                return result;
            }
        }

        /// <summary>
        /// 执行存储过程，返回输出参数组
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="schema">所有者</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rtnParams">返回的输出参数组</param>
        public int RunProcedure(
            string dbName,
            string schema,
            string storedProcName,
            IDataParameter[] parameters,
            out List<IDataParameter> rtnParams)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result = 0;

                connection.Open();
                SqlCommand cmd = BuildIntCommand(connection, dbName, schema, storedProcName, parameters);
                cmd.ExecuteNonQuery();

                result = (int)cmd.Parameters["ReturnValue"].Value;
                rtnParams = new List<IDataParameter>();
                foreach (SqlParameter parameter in cmd.Parameters)
                    rtnParams.Add(parameter);

                return result;
            }
        }

        /// <summary>
        /// 构建 SqlCommand 对象（用来返回一个结果集，而不是一个整数值）
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="dbName">数据库名</param>
        /// <param name="schema">所有者s</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        private SqlCommand BuildQueryCommand(
            SqlConnection connection,
            string dbName,
            string schema,
            string storedProcName,
            IDataParameter[] parameters)
        {
            SqlCommand command =
                new SqlCommand(
                    string.Format(
                        "{0}.{1}.{2}",
                        dbName,
                        schema,
                        storedProcName), connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter param in parameters)
            {
                if (param != null)
                {
                    // 检查未分配值的输出参数，将其分配为 DBNull.Value
                    if ((param.Direction == ParameterDirection.InputOutput ||
                        param.Direction == ParameterDirection.Input) &&
                        param.Value == null)
                        param.Value = DBNull.Value;
                }
                command.Parameters.Add(param);
            }

            return command;
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例（用来返回一个整数值）
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="dbName">数据库名</param>
        /// <param name="schema">所有者</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        private SqlCommand BuildIntCommand(
            SqlConnection connection,
            string dbName,
            string schema,
            string storedProcName,
            IDataParameter[] parameters)
        {
            SqlCommand cmd = BuildQueryCommand(connection, dbName, schema, storedProcName, parameters);
            cmd.Parameters.Add(
                new SqlParameter(
                    "ReturnValue",
                    SqlDbType.Int,
                    4,
                    ParameterDirection.ReturnValue,
                    false,
                    0,
                    0,
                    string.Empty,
                    DataRowVersion.Default,
                    null));
            return cmd;
        }

        /// <summary>
        /// 运行指定数据库中的存储过程
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="schema">所有者</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        public DataSet RunProcedureEx(
            string dbName,
            string schema,
            string storedProcName,
            ref List<IDataParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd =
                    new SqlCommand(
                        string.Format(
                            "{0}.{1}.{2}",
                            dbName,
                            schema,
                            storedProcName),
                        connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Timeout;
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter != null)
                    {
                        // 检查未分配值的输出参数,将其分配以DBNull.Value.
                        if ((parameter.Direction == ParameterDirection.InputOutput ||
                            parameter.Direction == ParameterDirection.Input) &&
                            (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(parameter);
                    }
                }

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    da.Fill(ds);
                    foreach (SqlParameter parameter in parameters)
                    {
                        if (parameter.Direction == ParameterDirection.Output)
                        {
                            parameter.Value = cmd.Parameters[parameter.ParameterName].Value;
                        }
                    }
                    return ds;
                }
                catch (SqlException err)
                {
                    foreach (SqlError item in err.Errors)
                    {
                        WriteLog.Instance.Write(
                            string.Format(
                                "{0}({1})",
                                item.Message,
                                item.LineNumber));
                    }
                    throw err;
                }

            }
        }

        /// <summary>
        /// 运行指定数据库中的存储过程
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="schema">拥有者</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">参数组</param>
        public void RunProcedureEx2(
            string dbName,
            string schema,
            string storedProcName,
            ref List<IDataParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(storedProcName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Timeout;
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter != null)
                    {
                        // 检查未分配值的输出参数,将其分配以DBNull.Value.
                        if ((parameter.Direction == ParameterDirection.InputOutput ||
                            parameter.Direction == ParameterDirection.Input) &&
                            (parameter.Value == null))
                            parameter.Value = DBNull.Value;
                        cmd.Parameters.Add(parameter);
                    }
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    foreach (SqlParameter parameter in parameters)
                    {
                        if (parameter.Direction == ParameterDirection.Output)
                            parameter.Value = cmd.Parameters[parameter.ParameterName].Value;
                    }
                }
                catch (SqlException err)
                {
                    foreach (SqlError item in err.Errors)
                    {
                        WriteLog.Instance.Write(
                            string.Format(
                                "{0}({1})",
                                item.Message,
                                item.LineNumber));
                    }
                    throw err;
                }
            }
        }
    }
}
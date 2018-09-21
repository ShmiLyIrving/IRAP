using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Data;

using IRAP.Global;
using IRAP.DBUtility;

namespace IRAPGeneralGateway.Entities
{
    /// <summary>
    /// 交易代码列表全局单例类
    /// </summary>
    public class TExCodes
    {
        private static TExCodes _instance = null;

        public static TExCodes Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TExCodes();
                return _instance;
            }
        }

        private Dictionary<string, TEntityExCode> excodes = new Dictionary<string, TEntityExCode>();

        private TExCodes() { }

        public Dictionary<string, TEntityExCode> ExCodes
        {
            get { return excodes; }
        }

        public void AddItem(TEntityExCode exCode)
        {
            if (!excodes.ContainsKey(exCode.ExCode))
                excodes.Add(
                    string.Format("{0}_{1}", exCode.Prefix, exCode.ExCode),
                    exCode);
        }

        /// <summary>
        /// 从 XML 节点的子节点中导入已注册的交易代码列表
        /// </summary>
        /// <param name="parentNode">XML 节点(ExCodes)</param>
        public void Load(XmlNode parentNode)
        {
            foreach (XmlNode node in parentNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    TEntityExCode exCode = new TEntityExCode();
                    exCode = IRAPXMLUtils.LoadValueFromXMLNode(node, exCode) as TEntityExCode;

                    AddItem(exCode);
                }
            }
        }

        /// <summary>
        /// 从指定文件名的 XML 文件中导入已注册的交易代码列表
        /// </summary>
        /// <param name="dataFileName">交易代码列表所在的 XML 文件名</param>
        public void Load(string dataFileName)
        {
            excodes.Clear();

            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(dataFileName);
            }
            catch (Exception error)
            {
                Debug.WriteLine(string.Format("加载[{0}]文件时出错：[{1}]", dataFileName, error.Message));
                return;
            }

            XmlNode parentNode = xml.SelectSingleNode("root/Configuration/ExCodes");
            if (parentNode != null)
            {
                Load(parentNode);
            }
            else
            {
                Debug.WriteLine("配置文件中没有找到 root/Configuration/ExCodes 节点(请注意大小写)");
            }
        }

        /// <summary>
        /// 将注册到内存中的交易代码列表持久化到指定的本地 XML 文件中
        /// </summary>
        /// <param name="dataFileName">持久化的本地 XML 文件名</param>
        public void Save(string dataFileName)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode rootNode = null;

            if (!File.Exists(dataFileName))
            {
                xml.AppendChild(xml.CreateXmlDeclaration("1.0", "utf-8", ""));
                rootNode = xml.AppendChild(xml.CreateElement("root"));
                rootNode = rootNode.AppendChild(xml.CreateElement("Configuration"));
            }
            else
            {
                try
                {
                    xml.Load(dataFileName);
                }
                catch (Exception error)
                {
                    Debug.WriteLine(string.Format("加载[{0}]文件时出错：[{1}]", dataFileName, error.Message));
                    return;
                }

                rootNode = xml.SelectSingleNode("root/Configuration");
                if (rootNode == null)
                {
                    Debug.WriteLine(
                        string.Format(
                            "[{0}] 文件中不存在 root/Configuration 根节点"));
                    return;
                }
            }

            // 在 rootNode 的第一层子节点中查找 ExCodes 节点，如果没有找到则创建
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Name == "ExCodes")
                {
                    rootNode.RemoveChild(node);
                }
            }

            XmlNode excodeNode = xml.CreateElement("ExCodes");
            rootNode.AppendChild(excodeNode);

            foreach (TEntityExCode excode in excodes.Values)
            {
                XmlNode node = xml.CreateElement("ExCode");
                node = IRAPXMLUtils.GenerateXMLAttribute(node, excode);
                excodeNode.AppendChild(node);
            }

            xml.Save(dataFileName);
        }

        /// <summary>
        /// 根据前缀和交易代码获取该交易代码的所有属性
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <param name="exCode">交易代码</param>
        /// <returns>交易代码定义对象</returns>
        public TEntityExCode GetExCode(string prefix, string exCode)
        {
            string fullExCode = string.Format("{0}_{1}", prefix, exCode);
            TEntityExCode rlt = null;
            if (excodes.TryGetValue(fullExCode, out rlt))
                return rlt;
            else
                return null;
        }

        public Dictionary<string, TEntityInputParam> GetInputParam(TEntityExCode exCode)
        {
            Dictionary<string, TEntityInputParam> spParams =
                new Dictionary<string, TEntityInputParam>();

            DBHelperSQLServer db = new DBHelperSQLServer();
            db.ConnectionString = TDBConnections.Instance.GetFirstConnection().ConnectionString;

            SqlParameter p1 = 
                new SqlParameter()
                {
                    ParameterName = "@procedure_name",
                    Value = exCode.ProcName,
                    SqlDbType = SqlDbType.VarChar,
                };
            SqlParameter p2 =
                new SqlParameter()
                {
                    ParameterName = "@group_number",
                    Value = 1,
                    SqlDbType = SqlDbType.Int,
                };

            IDataParameter[] paramArray =
                new IDataParameter[]
                {
                    p1,
                    p2,
                    new SqlParameter("@procedure_schema", null),
                    new SqlParameter("@parameter_name", null),
                };
            List<IDataParameter> paramArra = new List<IDataParameter>();
            paramArra.Add(p1);
            paramArra.Add(p2);
            paramArra.Add(new SqlParameter("@procedure_schema", null));
            paramArra.Add(new SqlParameter("@parameter_name", null));

            DataSet ds = 
                db.RunProcedureEx(
                    exCode.DBName,
                    "sys",
                    "sp_procedure_params_rowset", ref paramArra);
            try
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    //跳过返回值
                    if (int.Parse(r["ORDINAL_POSITION"].ToString()) == 0)
                    {
                        continue;
                    }
                    TEntityInputParam param = new TEntityInputParam();
                    param.ProcName = exCode.ProcName;
                    //把参数中的@去掉
                    param.ParamName = r["PARAMETER_NAME"].ToString().Replace("@", "");

                    param.Ordinal = int.Parse(r["ORDINAL_POSITION"].ToString());

                    param.ParamType = r["TYPE_NAME"].ToString();
                    param.CanNull = r["IS_NULLABLE"].ToString().ToUpper() == "TRUE";
                    if (r["PARAMETER_TYPE"].ToString() == "1")
                    {
                        param.IsOutput = 0;
                    }
                    else if (r["PARAMETER_TYPE"].ToString() == "2")
                    {
                        param.IsOutput = 1;
                    }
                    if (r["CHARACTER_MAXIMUM_LENGTH"] != null && r["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value)
                    {
                        param.Length = int.Parse(r["CHARACTER_MAXIMUM_LENGTH"].ToString());
                    }

                    if (r["NUMERIC_PRECISION"] != null && r["NUMERIC_PRECISION"] != DBNull.Value)
                    {
                        param.Precision = int.Parse(r["NUMERIC_PRECISION"].ToString());
                    }
                    if (r["NUMERIC_SCALE"] != null && r["NUMERIC_SCALE"] != DBNull.Value)
                    {
                        param.Scale = int.Parse(r["NUMERIC_SCALE"].ToString());
                    }
                    spParams.Add(param.ParamName, param);
                }
            }
            catch (Exception err)
            {
                err.Data["ErrCode"] = 9999;
                err.Data["ErrText"] = err.Message;
                throw err;
            }

            return spParams;
        }
    }
}

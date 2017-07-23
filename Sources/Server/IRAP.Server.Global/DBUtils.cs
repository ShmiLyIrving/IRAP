using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace IRAP.Server.Global
{
    public class DBUtils
    {
        public static Hashtable DBParamsToHashtable(IList<IDataParameter> paramList)
        {
            Hashtable rlt = new Hashtable();

            foreach (IDataParameter param in paramList)
            {
                if (param.Direction == ParameterDirection.InputOutput ||
                    param.Direction == ParameterDirection.Output)
                {
                    if (param.Value == DBNull.Value)
                    {
                        if (param.DbType == DbType.Int32 ||
                            param.DbType == DbType.Int64 ||
                            param.DbType == DbType.Int16)
                            rlt.Add(param.ParameterName.Replace("@", ""), 0);
                        else
                        if (param.DbType == DbType.Boolean)
                            rlt.Add(param.ParameterName.Replace("@", ""), false);
                        else
                        if (param.DbType == DbType.String ||
                            param.DbType == DbType.Xml)
                            rlt.Add(param.ParameterName.Replace("@", ""), "");
                        else
                        if (param.DbType == DbType.Date ||
                            param.DbType == DbType.DateTime ||
                            param.DbType == DbType.DateTime2)
                            rlt.Add(param.ParameterName.Replace("@", ""), new DateTime(0));
                    }
                    else
                    {
                        rlt.Add(param.ParameterName.Replace("@", ""), param.Value);
                    }
                }
            }

            return rlt;
        }
    }
}

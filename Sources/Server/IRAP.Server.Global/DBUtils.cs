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
                        switch (param.DbType)
                        {
                            case DbType.Int16:
                            case DbType.Int32:
                            case DbType.Int64:
                                rlt.Add(param.ParameterName.Replace("@", ""), 0);
                                break;
                            case DbType.Boolean:
                                rlt.Add(param.ParameterName.Replace("@", ""), false);
                                break;
                            case DbType.String:
                            case DbType.Xml:
                                rlt.Add(param.ParameterName.Replace("@", ""), "");
                                break;
                            case DbType.Date:
                            case DbType.DateTime:
                            case DbType.DateTime2:
                                rlt.Add(param.ParameterName.Replace("@", ""), new DateTime(0));
                                break;
                            default:
                                rlt.Add(param.ParameterName.Replace("@", ""), null);
                                break;
                        }
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

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
                if (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                {
                    if (param.Value == DBNull.Value)
                    {
                        if (param.GetType() == typeof(int) || param.GetType() == typeof(long))
                            rlt.Add(param.ParameterName.Replace("@", ""), 0);
                        else if (param.GetType() == typeof(bool))
                            rlt.Add(param.ParameterName.Replace("@", ""), false);
                        else if (param.GetType() == typeof(string))
                            rlt.Add(param.ParameterName.Replace("@", ""), "");
                        else if (param.GetType() == typeof(DateTime))
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

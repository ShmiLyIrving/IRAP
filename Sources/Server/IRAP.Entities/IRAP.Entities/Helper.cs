using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace IRAP.Entities
{
    public class Helper
    {
        public static List<T> ToList<T>(DataTable dt)
        {
            List<T> datas = new List<T>();
            Type t = typeof(T);
            try
            {
                var plist = new List<PropertyInfo>(t.GetProperties());
                foreach (DataRow row in dt.Rows)
                {
                    T s = Activator.CreateInstance<T>();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        PropertyInfo pi =
                            plist.Find(p => p.Name == dt.Columns[i].ColumnName);

                        if (pi != null)
                        {
                            Type tType = pi.PropertyType;
                            object obj = Convert.ChangeType(row[i], tType);
                            pi.SetValue(s, obj, null);
                        }
                    }

                    datas.Add(s);
                }
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"] =
                    $"[{t.FullName.ToString()}]转换出错：[{error.Message}]";
                throw error;
            }

            return datas;
        }
    }
}

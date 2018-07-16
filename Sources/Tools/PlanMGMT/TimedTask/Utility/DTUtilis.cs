using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace PlanMGMT
{
    public class DTUtilis
    {
        public static bool IsDTMap(PropertyInfo field)
        {
            object[] attrs = field.GetCustomAttributes(false);
            foreach (object attr in attrs)
            {
                if (attr.GetType() == typeof(IRAPDTAttrORMapAttribute))
                {
                    if (!(attr as IRAPDTAttrORMapAttribute).IsDTMap)
                        return false;
                }
            }
            return true;
        }
        //单条记录
        public static object LoadValueFromDT(DataTable dt, object obj)
        {
            try
            {
                if (dt != null && dt.Rows.Count == 1)
                {
                    PropertyInfo[] fields = obj.GetType().GetProperties();
                    foreach (PropertyInfo field in fields)
                    {
                        if (IsDTMap(field))
                        {
                            if (dt.Columns[field.Name] != null && !string.IsNullOrEmpty(dt.Rows[0][field.Name].ToString()))
                            {
                                if (field.PropertyType == typeof(string))
                                    field.SetValue(obj, dt.Rows[0][field.Name], null);
                                else if (field.PropertyType == typeof(short))
                                    field.SetValue(obj, Convert.ToInt16(dt.Rows[0][field.Name]), null);
                                else if (field.PropertyType == typeof(int))
                                    field.SetValue(obj, Convert.ToInt32(dt.Rows[0][field.Name]), null);
                                else if (field.PropertyType == typeof(long))
                                    field.SetValue(obj, Convert.ToInt64(dt.Rows[0][field.Name]), null);
                                else if (field.PropertyType == typeof(DateTime?) || field.PropertyType == typeof(DateTime))
                                    field.SetValue(obj, Convert.ToDateTime(dt.Rows[0][field.Name]), null);
                                else if (field.PropertyType == typeof(decimal))
                                    field.SetValue(obj, Convert.ToDecimal(dt.Rows[0][field.Name]), null);
                                else if (field.PropertyType == typeof(float))
                                    field.SetValue(obj, (float)Convert.ToDouble(dt.Rows[0][field.Name]), null);
                            }
                        }
                    }
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        //多条记录
        public static List<T> LoadValueFromDT<T>(DataTable dt, List<T> objs)
        {
            try
            {
                if (dt != null)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Type type = typeof(T);
                        Object o = Activator.CreateInstance(type);
                        PropertyInfo[] fields = o.GetType().GetProperties();
                        foreach (PropertyInfo field in fields)
                        {
                            if (IsDTMap(field))
                            {
                                if (r[field.Name] != null && !string.IsNullOrEmpty(r[field.Name].ToString()))
                                {
                                    if (field.PropertyType == typeof(string))
                                        field.SetValue(o, r[field.Name].ToString(), null);
                                    else if (field.PropertyType == typeof(short))
                                        field.SetValue(o,Convert.ToInt16(r[field.Name]), null);
                                    else if (field.PropertyType == typeof(int))
                                        field.SetValue(o, Convert.ToInt32(r[field.Name]), null);
                                    else if (field.PropertyType == typeof(long))
                                        field.SetValue(o, Convert.ToInt64(r[field.Name]), null);
                                    else if (field.PropertyType == typeof(DateTime?)||field.PropertyType ==typeof(DateTime))
                                        field.SetValue(o, Convert.ToDateTime(r[field.Name]), null);
                                    else if (field.PropertyType == typeof(decimal))
                                        field.SetValue(o, Convert.ToDecimal(r[field.Name]), null);
                                    else if(field.PropertyType ==typeof(float))
                                        field.SetValue(o,(float)Convert.ToDouble(r[field.Name]),null);
                                }
                            }
                        }
                        objs.Add((T)o);
                    }
                    return objs;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public static string GetUpdateSql(string TableName,object obj)
        {
            string s = "update "+TableName+" set ";
            PropertyInfo[] fields = obj.GetType().GetProperties();
            foreach (PropertyInfo field in fields)
            {
                if (IsDTMap(field))
                {
                    if (field.GetValue(obj,null) != null)
                    {
                        if (field.PropertyType == typeof(string)||field.PropertyType ==typeof(DateTime)||field.PropertyType ==typeof(DateTime?))
                            s += field.Name+"="+"'" + field.GetValue(obj, null).ToString() + "',";
                        else if (field.PropertyType == typeof(int)||field.PropertyType == typeof(long)||field.PropertyType ==typeof(short)||field.PropertyType ==typeof(decimal)||field.PropertyType ==typeof(float))
                            s += field.Name + "=" + field.GetValue(obj, null).ToString()+",";
                    }
                }
            }
            s = s.Substring(0, s.Length - 1);
            return s;
        }
        public static string GetAddValue(object obj)
        {
            string s = "(";
            PropertyInfo[] fields = obj.GetType().GetProperties();
            foreach (PropertyInfo field in fields)
            {
                if (IsDTMap(field))
                {
                    if (field.GetValue(obj,null) != null)
                    {
                        if (field.PropertyType == typeof(string) || field.PropertyType == typeof(DateTime) || field.PropertyType == typeof(DateTime?))
                            s +="'"+ field.GetValue(obj,null).ToString()+ "',";
                        else if (field.PropertyType == typeof(int) || field.PropertyType == typeof(long) || field.PropertyType == typeof(short) || field.PropertyType == typeof(decimal) || field.PropertyType == typeof(float))
                            s +=field.GetValue(obj, null).ToString()+",";   
                    }
                }
            }
            s = s.Substring(0, s.Length - 1);
            s += ")";
            return s;
        }
        public static string GetAddField(object obj)
        {
            string s = "(";
            PropertyInfo[] fields = obj.GetType().GetProperties();
            foreach (PropertyInfo field in fields)
            {
                if (IsDTMap(field))
                {
                    if (field.GetValue(obj, null) != null)
                    {
                        s += field.Name + ",";
                    }
                }
            }
            s = s.Substring(0, s.Length - 1);
            s += ")";
            return s;
        }
        public static string GetInsertSql(string TableName,object obj)
        {
            string s = "insert into " + TableName;
            s += GetAddField(obj);
            s += "VALUES";
            s += GetAddValue(obj);
            return s;
        }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class IRAPDTAttrORMapAttribute : Attribute
    {
        bool _isDTMap = true;
        public bool IsDTMap
        {
            get { return _isDTMap;  }
            set { _isDTMap = value; }
        }

        public IRAPDTAttrORMapAttribute()
        {
            _isDTMap = true;
        }

        public IRAPDTAttrORMapAttribute(bool value)
        {
            _isDTMap = value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;

namespace IRAP.Global
{
    public class IRAPXMLUtils
    {
        public static bool IsORMap(PropertyInfo field)
        {
            object[] attrs = field.GetCustomAttributes(false);
            foreach (object attr in attrs)
            {
                if (attr.GetType() == typeof(IRAPXMLNodeAttrORMapAttribute))
                {
                    if (!(attr as IRAPXMLNodeAttrORMapAttribute).IsORMap)
                        return false;
                }
            }
            return true;
        }

        public static XmlNode GenerateXMLAttribute(XmlNode node, object obj)
        {
            PropertyInfo[] fields = obj.GetType().GetProperties();
            node.Attributes.RemoveAll();
            foreach (PropertyInfo field in fields)
            {
                if (IsORMap(field))
                {
                    XmlAttribute attr = node.OwnerDocument.CreateAttribute(field.Name);
                    if (field.GetValue(obj, null) == null)
                        attr.Value = "";
                    else
                        attr.Value = field.GetValue(obj, null).ToString();
                    node.Attributes.Append(attr);
                }
            }

            return node;
        }

        public static object LoadValueFromXMLNode(XmlNode node, object obj)
        {
            PropertyInfo[] fields = obj.GetType().GetProperties();
            foreach(PropertyInfo field in fields)
            {
                if (IsORMap(field))
                {
                    if (node.Attributes[field.Name] != null)
                    {
                        if (field.PropertyType == typeof(string))
                            field.SetValue(obj, node.Attributes[field.Name].Value, null);
                        else if (field.PropertyType == typeof(int))
                            field.SetValue(obj, Convert.ToInt32(node.Attributes[field.Name].Value), null);
                        else if (field.PropertyType == typeof(long))
                            field.SetValue(obj, Convert.ToInt64(node.Attributes[field.Name].Value), null);
                        else if (field.PropertyType == typeof(DateTime))
                            field.SetValue(obj, Convert.ToDateTime(node.Attributes[field.Name].Value), null);
                    }
                }
            }
            return obj;
        }

        /// <summary>
        /// 在 XML 节点的子节点中查找指定属性名和值的子节点
        /// </summary>
        /// <param name="parentNode">节点</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="propertyValue">属性值</param>
        /// <returns>子节点</returns>
        public static XmlNode GetChildNodeWithPropertyValue(
            XmlNode parentNode,
            string propertyName,
            string propertyValue)
        {
            foreach (XmlNode node in parentNode.ChildNodes)
            {
                if (node.Attributes[propertyName] != null)
                {
                    if (node.Attributes[propertyName].Value == propertyValue)
                        return node;
                }
            }
            return null;
        }

        /// <summary>
        /// 在 XML 节点的子节点中查找节点属性值完全符合输入对象公共映射属性值的节点
        /// </summary>
        /// <param name="parentNode">节点</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static XmlNode GetChildNodeWithPropertyValue(
            XmlNode parentNode,
            object obj)
        {
            List<PropertyInfo> fields = new List<PropertyInfo>();
            foreach (PropertyInfo field in obj.GetType().GetProperties())
            {
                if (IsORMap(field))
                    fields.Add(field);
            }

            foreach (XmlNode node in parentNode.ChildNodes)
            {
                bool isMateched = true;
                foreach (PropertyInfo field in fields)
                {
                    if (node.Attributes[field.Name] == null)
                    {
                        isMateched = false;
                        break;
                    }
                    if (node.Attributes[field.Name].Value != field.GetValue(obj, null).ToString())
                    {
                        isMateched = false;
                        break;
                    }
                }
                if (isMateched)
                    return node;
            }

            return null;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class IRAPXMLNodeAttrORMapAttribute : Attribute
    {
        bool _isORMap = true;

        public bool IsORMap
        {
            get { return _isORMap; }
            set { _isORMap = value; }
        }

        public IRAPXMLNodeAttrORMapAttribute()
        {
            _isORMap = true;
        }

        public IRAPXMLNodeAttrORMapAttribute(bool value)
        {
            _isORMap = value;
        }
    }
}

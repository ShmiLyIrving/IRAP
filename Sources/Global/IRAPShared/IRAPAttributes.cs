using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAPShared
{
    //对实体增加的特性
    //限定特性类的应用范围  
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    //定制MsgAttribute特性类，继承于Attribute  
    public class IRAPDBAttribute : Attribute
    {
        //定义_msg字段和Msg属性//Msg属性用于读写msg字段  
        string _tableName;
        public string TableName { get { return _tableName; } set { _tableName = value; } }
        public IRAPDBAttribute() { }
        //重载构造函数接收一个参数，赋值给_msg字段  
        public IRAPDBAttribute(string s) { _tableName = s; }
    }


    //限定特性类的应用范围  
    [AttributeUsage( AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    //定制MsgAttribute特性类，继承于Attribute  
    public class IRAPKeyAttribute : Attribute
    {
        //定义_msg字段和Msg属性//Msg属性用于读写msg字段  
        bool _isKey;
        public bool IsKey { get { return _isKey; } set { _isKey = value; } }
        public IRAPKeyAttribute() { _isKey = true; }
        public IRAPKeyAttribute(bool s) { _isKey = s; }
    }

   
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class IRAPORMMapAttribute : Attribute
    {
        //定义_msg字段和Msg属性//Msg属性用于读写msg字段  
        bool _isMap;
        public bool ORMMap { get { return _isMap; } set { _isMap = value; } }
        public IRAPORMMapAttribute() { _isMap = true; }
        public IRAPORMMapAttribute(bool s) { _isMap = s; }
    }
}

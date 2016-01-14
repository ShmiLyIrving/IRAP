using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace IRAPShared
{
    [Serializable]
    public sealed class IRAPError : Exception
    {
        private int _errCode;
        private string _errText="No Error";
        private string _className = string.Empty;
       
        public IRAPError()
        {
            _errCode = 999999;
            _errText = "错误未初始化";
        }

        public IRAPError(int errCode, string errText)
            : base(errText)
        {
            _errCode = errCode;
            _errText = errText;
        }
        public IRAPError(string message, Exception inner) 
            : base(message, inner) { 
        }
        private string GetClassName()
        {
            // Will include namespace but not full instantiation and assembly name.
            if (_className == null)
                _className = GetType().ToString();

            return _className;
        }
        private IRAPError(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _errCode = info.GetInt32("ErrCode");

           _errText = info.GetString("ErrText");
        }

        public IRAPError(string message, int errCode, string errText)
            : base(message)
        {
            this._errCode = errCode;
            this._errText = errText;
        }
        public IRAPError(string message, Exception inner, int errCode, string errText)
            : base(message, inner)
        {
            this._errCode = errCode;
            this._errText = errText;
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
            // 序列化自定义数据成员
            info.AddValue("ErrCode", _errCode);
            info.AddValue("ErrText", _errText);
           // info.AddValue("ClassName", GetType().ToString());
            // 调用基类方法，序列化它的成员
            base.GetObjectData(info, context);
        }

        public override string Message
        {
            get
            {
               string message = string.Empty;
               message +=string.Format("[{0}] [1]",_errCode.ToString(), _errText);
               return message;
            }
        }

        public int ErrCode
        {
            get { return _errCode; }
            set { _errCode = value; }
        }

        public string ErrText
        {
            set { _errText = value; }
            get { return _errText; }
        }
    }
}

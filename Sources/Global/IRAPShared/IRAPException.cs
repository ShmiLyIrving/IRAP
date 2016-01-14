using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace IRAPShared
{
    [Serializable]
    public enum MsgType { info, debug, error, warn, fatal }

    [Serializable]
    public sealed class IRAPException : Exception, ISerializable
    {
        //三个共有构造器
        public IRAPException()
            : base()//调用基类的构造器
        {
        }
        public IRAPException(string message)
            : base(message)//调用基类的构造器
        {
        }
        public IRAPException(string message, Exception innerException)
            : base(message, innerException)//调用基类的构造器
        {

        }
        //定义了一个私有字段
        private int _errCode;
        private string _errText;
        //顶一个只读属性，改属性返回新定义的字段
        public string ErrText { get { return _errText; } }
        public int ErrCode { get { return _errCode; } }
        //重新共有属性Message，将新定义的字段包含在异常的信息文本中
        public override string Message
        {
            get
            {
                string msg = base.Message;
                if (ErrText != string.Empty)
                {
                    msg += Environment.NewLine + "ErrText：" + ErrText;
                }
                return msg;
            }
        }
        //因为定义了至少新的字段，所以要定义一个特殊的构造器用于反序列化
        //由于该类是密封类，所以该构造器的访问限制被定义为私有方式。否则，该构造器
        //被定义为受保护方式
        private IRAPException(SerializationInfo info, StreamingContext context)
            : base(info, context)//让基类反序列化其内定义的字段
        {
            _errText = info.GetString("ErrText");
            _errCode = info.GetInt32("ErrCode");
        }
        //因为定义了至少一个字段，所以要定义序列化方法
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //序列化新定义的每个字段
            info.AddValue("ErrText", _errText);
            info.AddValue("ErrCode", _errCode);
            //让基类序列化其内定义的字段
            base.GetObjectData(info, context);
        }
        //定义额外的构造器设置新定义的字段
        public IRAPException(int errCode, string errText)
            : this(errText)//调用另外一个构造器
        {
            this._errCode = errCode;
            this._errText = errText;

        }
        public IRAPException(int errCode, string errText, Exception innerException)
            : this(errText, innerException)
        {
            this._errCode = errCode;
            this._errText = errText + Environment.NewLine + innerException.Message;
        }
    }

}

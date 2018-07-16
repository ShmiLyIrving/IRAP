// 文 件 名：Error.cs
// 功能描述：自动运行实体
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT
{
    public class Error
    {
        public Error() { }
        public Error(int code,string text)
        {
            ErrCode = code;
            ErrText = text;
        }
        /// <summary>
        /// 错误代码
        /// </summary>
        public int ErrCode;
       /// <summary>
       /// 错误信息
       /// </summary>
        public string ErrText;
    }
}

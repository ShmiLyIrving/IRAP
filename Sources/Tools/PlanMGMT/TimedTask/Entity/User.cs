// 文 件 名：Department.cs
// 功能描述：自动运行实体
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.Entity
{
    public class User
    {
        public User() { }
        public User(string code, string name)
        {
            this.UserCode = code;
            this.UserName = name;
        }
        /// <summary>
        /// 用户代码
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
       public string UserName { get; set; }
        public override string ToString()
        {
            return UserName;
        }
    }
}

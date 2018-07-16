// 文 件 名：Department.cs
// 功能描述：自动运行实体
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT
{
    public class PSPUser
    {
        /// <summary>
        /// 用户登录代码
        /// </summary>
        public string UserCode
        {
            get;set;
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get;set;
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPass
        {
            get;set;
        }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string Email
        {
            get;set;
        }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string MPHoneNo
        {
            get;set;
        }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID
        {
            get;set;
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get;set;
        }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int deptID
        {
            get;set;
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string deptname
        {
            get;set;
        }
    }
}

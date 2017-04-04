using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VA_ITCMS2000
{
    public class ITCMS2000Param : Param
    {
        /// <summary>
        /// ITC MS 2000 广播服务器地址
        /// </summary>
        public string Address
        {
            get { return GetString("ITC Server Address"); }
            set { SaveParam("ITC Server Address", value); }
        }

        public string UserID
        {
            get { return GetString("ITC Server UserID"); }
            set { SaveParam("ITC Server UserID", value); }
        }

        public string UserPWD
        {
            get { return GetString("ITC Server UserPWD"); }
            set { SaveParam("ITC Server UserPWD", value); }
        }
    }
}

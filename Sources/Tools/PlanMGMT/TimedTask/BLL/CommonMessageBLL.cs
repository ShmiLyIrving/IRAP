using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.BLL
{
    public class CommonMessageBLL: MSL.Tool.Data.DBAccessBase<CommonMessage>
    {
        public CommonMessageBLL()
            : base("CommonMessage", "Id", true)
        {

        }
        public CommonMessageBLL(string connString)
            : base(connString, "CommonMessage", "Id", true)
        {

        }
    }
}

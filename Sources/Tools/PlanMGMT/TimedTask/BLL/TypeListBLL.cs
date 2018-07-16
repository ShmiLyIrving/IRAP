using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.BLL
{
    /// <summary>
    /// 系统类别 逻辑类
    /// </summary>
    public class TypeListBLL : MSL.Tool.Data.DBAccessBase<Model.TypeList>
    {
        public TypeListBLL()
            : base("TypeList", "Id", true)
        {

        }
        public TypeListBLL(string connString)
            : base(connString, "TypeList", "Id", true)
        {

        }
    }
}

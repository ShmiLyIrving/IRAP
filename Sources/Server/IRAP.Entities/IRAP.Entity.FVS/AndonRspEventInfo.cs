﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entity.FVS
{
    public class AndonRspEventInfo : AndonEventInfo
    {
        /// <summary>
        /// 安灯事件隶属关系：
        /// 0-通知了别人，但我可响应；
        /// 1-通知我的，还未响应；
        /// 2-别人已响应，但追加呼叫我的
        /// </summary>
        public int AndonEventOwnership { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public bool Choice { get; set; }

        public new AndonRspEventInfo Clone()
        {
            AndonRspEventInfo rlt = MemberwiseClone() as AndonRspEventInfo;

            return rlt;
        }

        public override string ToString()
        {
            return EventDescription;
        }
    }
}
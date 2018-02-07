using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.WebAPI.Enums;

namespace IRAP.WebAPI.Exchange.IRAP
{
    /// <summary>
    /// 返回指定信息站点的系统登录信息（适合无登录的展现系统）
    /// </summary>
    public class TGetInfoStationLogin : TCustomWebAPICall
    {
        public TGetInfoStationLogin(
            string webAPIUrl,
            TContentType contentType,
            string clientID) : base(webAPIUrl, contentType, clientID)
        {
            moduleType = TModuleType.Exchange;
            exCode = "IRAP_Core_GetInfoStationLogin";
        }

        protected override void Communicate(out TErrorMessage errorMsg)
        {
            throw new NotImplementedException();
        }
    }
}

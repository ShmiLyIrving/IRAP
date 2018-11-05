using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.WebAPI.Enums;

namespace IRAP.WebAPI.Exchange.SCES
{
    public class TGetDeliveryOrdersOnRoad : TCustomWebAPICall
    {
        public TGetDeliveryOrdersOnRoad(
            string webAPIUrl,
            TContentType contentType,
            string clientID) : base(webAPIUrl, contentType, clientID)
        {

        }

        protected override void Communicate(out TErrorMessage errorMsg)
        {
            throw new NotImplementedException();
        }
    }
}

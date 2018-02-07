using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.WebAPI.Entities.MES;
using IRAP.WebAPI.Enums;

namespace IRAP.WebAPI.Exchange.MES
{
    public class TGetOPCServerTagList : TCustomWebAPICall
    {
        private TREQOPCServerTagList reqBody = null;
        private TRESPOPCServerTagListSet respBody = null;

        public TGetOPCServerTagList(
            string webAPIUrl,
            TContentType contentType,
            string clientID) : base(webAPIUrl, contentType, clientID)
        {
            moduleType = TModuleType.Exchange;
            exCode = "IRAP_MES_GetOPCServerTagList";
        }

        /// <summary>
        /// 交易请求对象
        /// </summary>
        public TREQOPCServerTagList Request
        {
            get { return reqBody; }
            set { reqBody = value; }
        }

        /// <summary>
        /// 交易响应对象
        /// </summary>
        public TRESPOPCServerTagListSet Response
        {
            get { return respBody; }
        }

        protected override void Communicate(out TErrorMessage errorMsg)
        {
            if (reqBody == null)
            {
                Exception error = new Exception("请求报文 [TREQOPCServerTagList] 类未实例化");
                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"] = error.Message;
                throw error;
            }

            respBody =
                Call<TRESPOPCServerTagListSet>(
                    reqBody,
                    out errorMsg);
        }
    }
}

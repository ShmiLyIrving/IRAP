using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

using IRAPGeneralGateway.Entities;

namespace IRAPGeneralGateway
{
    /// <summary>
    /// IRAP 通用 WebAPI 服务类
    /// </summary>
    public class TIRAPGeneralWebAPIService : IIRAPWebAPI
    {
        private static DateTime _lastTime = DateTime.Now;
        private static int _ConnectedCount = 0;

        public static Dictionary<string, TClientEntity> clients =
            new Dictionary<string, TClientEntity>();
        public static Dictionary<string, TExCodeEntity> excodes =
            new Dictionary<string, TExCodeEntity>();

        private int _maxConnectedPerSecond = 0;

        public TIRAPGeneralWebAPIService()
        {

        }

        private Stream ErrorStream(
            string exCode, 
            string clientID, 
            string msgFormat, 
            int errCode, 
            string errText)
        {
            Entities.TResCommEntity res =
                new Entities.TResCommEntity()
                {
                    ExCode = exCode,
                    ErrCode = errCode,
                    ErrText = errText,
                };
            if (msgFormat.ToUpper() == "XML")
                return EncryptContent(clientID, res.ToXML());
            else
                return EncryptContent(clientID, res.ToJSON());
        }

        private Stream EncryptContent(string clientID, string msgContent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 通用 WebAPI 服务调用入口（非加密）
        /// </summary>
        /// <param name="reqContent">请求报文的流</param>
        /// <param name="clientID">客户端 ID</param>
        /// <param name="msgFormat">请求报文格式类型（Json/XML）</param>
        /// <param name="exCode">交易代码</param>
        /// <returns></returns>
        public Stream GeneralCall(Stream reqContent, string clientID, string msgFormat, string exCode)
        {
            msgFormat = msgFormat.ToUpper();
            if (msgFormat != "JSON" && msgFormat != "XML")
            {
                return ErrorStream(
                    exCode, 
                    clientID, 
                    "JSON", 
                    999999, 
                    string.Format("不支持[{0}]报文格式，仅支持 JSON 或 XML", msgFormat));
            }

            if (!clients.ContainsKey(clientID))
            {
                return ErrorStream(
                    exCode,
                    clientID,
                    msgFormat,
                    999999,
                    string.Format("客户标识[{0}]未授权或未在服务端注册", clientID));
            }

            try
            {
                #region 服务的最大连接数控制
                if (DateTime.Now.Subtract(_lastTime).TotalMilliseconds > 1000)
                {
                    _lastTime = DateTime.Now;
                    _ConnectedCount = 0;
                }
                else
                    _ConnectedCount++;
                if (_ConnectedCount > _maxConnectedPerSecond)
                {

                }
                #endregion

                string rltString = "";

                return EncryptContent(clientID, rltString);
            }
            catch (Exception error)
            {
                string errCode = "999999";
                string errText = error.Message;

                if (error.Data["ErrCode"] != null)
                    errCode = error.Data["ErrCode"].ToString();
                if (error.Data["ErrText"] != null)
                    errText = error.Data["ErrText"].ToString();

                Debug.WriteLine(string.Format("[({0}){1}]", errCode, errText));

                return ErrorStream(exCode, clientID, msgFormat, int.Parse(errCode), errText);
            }
        }
    }
}   

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

using IRAP.Global;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.SubSystem
{
    public class AvailableProducts
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static AvailableProducts _instance = null;
        private int processLeaf = 0;
        private List<ProductViaStation> _products = new List<ProductViaStation>();

        private AvailableProducts()
        {
        }

        public static AvailableProducts Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AvailableProducts();
                return _instance;
            }
        }

        public int ProcessLeaf
        {
            get { return processLeaf; }
        }

        public List<ProductViaStation> Products
        {
            get { return _products; }
        }

        public int GetProducts(int communityID, long sysLogID, int t107LeafID, bool isWorkFlowNode)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                _products.Clear();

                IRAPMDMClient.Instance.ufn_GetList_ProductsViaStation(
                    communityID,
                    t107LeafID,
                    isWorkFlowNode,
                    sysLogID,
                    ref _products,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                    return _products.Count;
                else
                    throw new Exception(errText);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                    throw new Exception(
                        string.Format(
                            "Unable to obtain products/processes, reason: {0}",
                            error.Message));
                else
                    throw new Exception(
                        string.Format(
                            "无法获取产品/流程，原因：{0}",
                            error.Message));
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public int IndexOf(ProductViaStation product)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (Products[i].T102LeafID == product.T102LeafID)
                    return i;
            }
            return -1;
        }
    }
}
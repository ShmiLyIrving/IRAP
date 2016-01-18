using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Reflection;

using IRAP.Global;
using IRAP.General.Server.Library;

namespace IRAP.Server.Host
{
    class Program
    {
        private static ServiceHost _host = null;
        private static string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        static void Main(string[] args)
        {
            string strProcedureName = string.Format(
                "{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            WriteLog.Instance.Write("服务开始运行......", strProcedureName);
            try
            {
                if (_host == null)
                    _host = new ServiceHost(typeof(ServiceIRAPGeneral));
                _host.Open();

                Console.WriteLine("服务开始运行......");
                Console.ReadLine();
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.Write("服务结束", strProcedureName);
            }
        }
    }
}

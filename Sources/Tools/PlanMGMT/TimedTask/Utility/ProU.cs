using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.Utility
{
     public class ProU
    {
        private static ProU _instance;
        private static readonly object _lock = new Object();
        #region 单一实例
        /// <summary>
        /// 
        /// </summary>
        private ProU()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        ~ProU()
        {
            Dispose();
        }
        /// <summary>
        /// 返回唯一实例
        /// </summary>
        public static ProU Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ProU();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        public PSPUser PspUser = new PSPUser();
    }
}

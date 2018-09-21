using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAPGeneralGateway
{
    internal class TEntityService
    {
        private int _success = 0;
        private int _failed = 0;
        private int _reject = 0;
        private int _except = 0;
        private DateTime _lastCallDate = DateTime.Now;
        private int _year;
        private int _month;
        private int _hour;

        /// <summary>
        /// 成功次数
        /// </summary>
        public int Success
        {
            get { return _success; }
        }

        /// <summary>
        /// 失败次数
        /// </summary>
        public int Failed
        {
            get { return _failed; }
        }

        /// <summary>
        /// 拒绝次数
        /// </summary>
        public int Reject
        {
            get { return _reject; }
        }

        /// <summary>
        /// 出错次数
        /// </summary>
        public int Except
        {
            get { return _except; }
        }

        /// <summary>
        /// 最后调用时间
        /// </summary>
        public DateTime LastCallDate
        {
            get { return _lastCallDate; }
            set { _lastCallDate = value; }
        }

        /// <summary>
        /// 年份
        /// </summary>
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        /// <summary>
        /// 月份
        /// </summary>
        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        /// <summary>
        /// 小时
        /// </summary>
        public int Hour
        {
            get { return _hour; }
            set { _hour = value; }
        }

        public TEntityService()
        {

        }

        /// <summary>
        /// 调用服务调用状态
        /// </summary>
        /// <param name="result"></param>
        public void SetServiceCallStatus(TServiceCallResult result)
        {
            switch (result)
            {
                case TServiceCallResult.Success:
                    _success++;
                    break;
                case TServiceCallResult.Failure:
                    _failed++;
                    break;
                case TServiceCallResult.Reject:
                    _reject++;
                    break;
                case TServiceCallResult.Except:
                    _except++;
                    break;
            }

            _lastCallDate = DateTime.Now;
        }
    }
}

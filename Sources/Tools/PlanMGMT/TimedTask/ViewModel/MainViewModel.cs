//using GalaSoft.MvvmLight;
//using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using PlanMGMT.BLL;
using PlanMGMT.Utility;

namespace PlanMGMT.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// 初始化 MainViewModel
        /// </summary>
        public MainViewModel()
        {
            if (!IsInDesignMode)
            {
                Loading();
            }
        }
        #region 属性
        /// <summary> 程序版本 </summary>
        public string Verson { get; set; }
        public string UserName { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Loading()
        {
            this.Verson = "主程序版本 V" + Helper.Instance.GetVersion();
            this.UserName = ProU.Instance.PspUser.UserName;
        }
        #endregion
    }
}

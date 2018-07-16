using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

//using GalaSoft.MvvmLight;
//using GalaSoft.MvvmLight.Command;

//----------------------------------------------------------------*/
// 版权所有：
// 文 件 名：WindowViewModelBase.cs
// 功能描述：
// 修改描述：
//----------------------------------------------------------------*/
namespace PlanMGMT.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsInDesignMode;

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #region 支持.NET4.5
        //protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        //{
        //    if (object.Equals(storage, value)) { return false; }
        //    storage = value;
        //    this.OnPropertyChanged(propertyName);
        //    return true;
        //}
        //private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    var eventHandler = this.PropertyChanged;
        //    if (eventHandler != null)
        //    {
        //        eventHandler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        #endregion

        #region 支持.NET4.0

        private static string GetProperyName(string methodName)
        {
            if (methodName.StartsWith("get_") || methodName.StartsWith("set_") ||
                methodName.StartsWith("put_"))
            {
                return methodName.Substring("get_".Length);
            }
            throw new Exception(methodName + " not a method of Property");
        }

        protected bool SetProperty<T>(ref T storage, T value)
        {
            if (object.Equals(storage, value)) { return false; }
            storage = value;
            string propertyName = GetProperyName(new System.Diagnostics.StackTrace(true).GetFrame(1).GetMethod().Name);
            this.OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}

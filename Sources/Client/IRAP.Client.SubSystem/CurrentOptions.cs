﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entity.SSO;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.SubSystem
{
    public class CurrentOptions
    {
        private static string className =
        MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static CurrentOptions _instance = null;
        private int indexOfOptionTwo = -1;
        private WIPStation optionOne = new WIPStation();
        private ProductViaStation optionTwo = new ProductViaStation();
        private List<ProductViaStation> optionTwos = new List<ProductViaStation>();

        private CurrentOptions()
        {
        }

        public static CurrentOptions Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CurrentOptions();
                return _instance;
            }
        }

        /// <summary>
        ///  获取/设置当前选择的产品/流程在产品/流程列表中的索引号
        /// </summary>
        public int IndexOfOptionTwo
        {
            get { return indexOfOptionTwo; }
            set
            {
                if (value > optionTwos.Count)
                {
                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        throw new Exception("Index is out of range.");
                    else
                        throw new Exception("索引超出列表的范围");
                }

                if (indexOfOptionTwo != value)
                {
                    if (indexOfOptionTwo < 0)
                    {
                        indexOfOptionTwo = -1;
                        optionTwo = null;
                    }
                    else
                    {
                        optionTwo = OptionTwos[value];
                        indexOfOptionTwo = value;
                    }
                }
            }
        }

        /// <summary>
        /// 获取/设置当前的工位/工作流结点
        /// </summary>
        public WIPStation OptionOne
        {
            get
            {
                if (optionOne != null)
                    return optionOne;
                else
                    return new WIPStation();
            }
            set
            {
                if (value != null)
                {
                    if (value != null)
                    {
                        optionOne = value.Clone();
                        try
                        {
                            GetProductsWithCurrentStatioin();
                        }
                        catch
                        {
                            indexOfOptionTwo = -1;
                            optionTwo = new ProductViaStation();
                            return;
                        }

                        if (OptionTwos.Count > 0)
                        {
                            foreach (ProductViaStation prdt in optionTwos)
                            {
                                if (prdt.T102LeafID == optionTwo.T102LeafID)
                                {
                                    optionTwo = prdt;
                                    indexOfOptionTwo = optionTwos.IndexOf(prdt);
                                    return;
                                }
                            }

                            indexOfOptionTwo = 0;
                            optionTwo = optionTwos[0];
                        }
                        else
                        {
                            indexOfOptionTwo = -1;
                            OptionTwo = new ProductViaStation();
                        }
                    }
                    else
                    {
                        optionOne = new WIPStation();
                    }
                }
            }
        }

        /// <summary>
        /// 获取/设置当前选择的产品/流程
        /// </summary>
        public ProductViaStation OptionTwo
        {
            get
            {
                if (optionTwo != null)
                    return optionTwo;
                else
                    return new ProductViaStation();
            }
            set
            {
                if (optionTwo == null ||
                    optionTwo.T102LeafID != value.T102LeafID)
                {
                    for (int i = 0; i < optionTwos.Count; i++)
                    {
                        if (optionTwos[i].T102LeafID == value.T102LeafID)
                        {
                            optionTwo = optionTwos[i];
                            indexOfOptionTwo = i;
                            return;
                        }
                    }

                    if (value.T102LeafID != 0)
                    {
                        if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                            throw new Exception("The product/process to switch is not in the list of the current position/process");
                        else
                            throw new Exception("要切换产品/流程的不在当前工位/工序允许的列表中");
                    }
                    else
                    {
                        optionTwo = value;
                        indexOfOptionTwo = -1;
                    }
                }
                
                if (optionTwo == null)
                {
                    optionTwo = new ProductViaStation();
                }
            }
        }

        public List<ProductViaStation> OptionTwos
        {
            get { return optionTwos; }
        }

        private void GetProductsWithCurrentStatioin()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                optionTwos.Clear();

                AvailableProducts.Instance.GetProducts(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    optionOne.T107LeafID,
                    optionOne.IsWorkFlowNode);

                foreach (ProductViaStation prod in AvailableProducts.Instance.Products)
                    optionTwos.Add(prod.Clone());
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                throw error;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
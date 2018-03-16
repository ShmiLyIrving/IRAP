using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IRAP.WCF.Client.Method
{
    public class HashtableTools
    {
        private static HashtableTools _instance = null;

        public static HashtableTools Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HashtableTools();
                return _instance;
            }
        }

        public void GetValue(Hashtable dict, string key, out string value)
        {
            value = "";
            if (dict.ContainsKey(key))
            {
                try
                {
                    if (dict[key] != null)
                        value = dict[key].ToString();
                    else
                        value = "";
                }
                catch (Exception error)
                {
                    throw new Exception(string.Format("无法获取 [{0}] 的值：[{1}]", key, error.Message));
                }
            }
            else
            {
                throw new Exception(string.Format("Hashtable 中没有包含 [{0}] ", key));
            }
        }

        public void GetValue(Hashtable dict, string key, out long value)
        {
            value = 0;
            if (dict.ContainsKey(key))
            {
                try
                {
                    if (dict[key] != null)
                        value = Convert.ToInt64(dict[key].ToString());
                    else
                        value = -1;
                }
                catch (Exception error)
                {
                    throw new Exception(string.Format("无法获取 [{0}] 的值：[{1}]", key, error.Message));
                }
            }
            else
            {
                throw new Exception(string.Format("Hashtable 中没有包含 [{0}] ", key));
            }
        }

        public void GetValue(Hashtable dict, string key, out int value)
        {
            value = 0;
            if (dict.ContainsKey(key))
            {
                try
                {
                    if (dict[key] != null)
                        value = Convert.ToInt32(dict[key].ToString());
                    else
                        value = -1;
                }
                catch (Exception error)
                {
                    throw new Exception(string.Format("无法获取 [{0}] 的值：[{1}]", key, error.Message));
                }
            }
            else
            {
                throw new Exception(string.Format("Hashtable 中没有包含 [{0}] ", key));
            }
        }

        public void GetValue(Hashtable dict, string key, out bool value)
        {
            value = false;
            if (dict.ContainsKey(key))
            {
                try
                {
                    if (dict[key] != null)
                        value = Convert.ToBoolean(dict[key].ToString());
                    else
                        value = false;
                }
                catch (Exception error)
                {
                    throw new Exception(string.Format("无法获取 [{0}] 的值：[{1}]", key, error.Message));
                }
            }
            else
            {
                throw new Exception(string.Format("Hashtable 中没有包含 [{0}] ", key));
            }
        }
    }
}
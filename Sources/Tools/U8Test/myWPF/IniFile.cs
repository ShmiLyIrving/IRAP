using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace myWPF
{
    public class IniFile
    {
        /// <summary>
        /// 函数作用：向 INI 文件中写入信息
        /// </summary>
        /// <param name="section">小节名称</param>
        /// <param name="key">项目名称或条目名称。如果为null，则删除指定的节点及其所有的项目</param>
        /// <param name="val1">参数值。如果为null，则删除指定节点中指定的键</param>
        /// <param name="filePath">INI 文件的完整路径</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        static extern long WritePrivateProfileString(string section, string key, string val1, string filePath);

        /// <summary>
        /// 函数作用：从私有文件中获取字符串（读取 INI 文件）
        /// </summary>
        /// <param name="section">小节名称</param>
        /// <param name="key">项目名称或者条目名称</param>
        /// <param name="def">默认值</param>
        /// <param name="retVal">字符串缓冲区</param>
        /// <param name="size">字符串缓冲区大小</param>
        /// <param name="filePath">INI 文件的完整路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        protected static void IniWriteValue(string section, string key, string value, string filePath)
        {
            WritePrivateProfileString(section, key, value, filePath);
        }

        /// <summary>
        /// 将 BOOL 型的配置参数写入 INI 文件中
        /// </summary>
        /// <param name="section">小节名</param>
        /// <param name="key">项目名或者条目名</param>
        /// <param name="value">参数值</param>
        /// <param name="filePath">INI 文件名</param>
        public static void WriteBool(string section, string key, bool value, string filePath)
        {
            string strValue = "";
            if (value)
                strValue = "1";
            else
                strValue = "0";

            try
            {
                WritePrivateProfileString(section, key, strValue, filePath);
            }
            catch
            {

            }
        }
        /// <summary>
        /// 将 string 型的配置参数写入 INI 文件中
        /// </summary>
        /// <param name="section">小节名</param>
        /// <param name="key">项目名或者条目名</param>
        /// <param name="value">参数值</param>
        /// <param name="filePath">INI 文件名</param>
        public static void WriteString(string section, string key, string value, string filePath)
        {
            try
            {
                WritePrivateProfileString(section, key, value, filePath);
            }
            catch
            {

            }
        }

        protected static string IniReadValue(string section, string key, string filePath)
        {
            StringBuilder tempStr = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", tempStr, 255, filePath);
            return tempStr.ToString();
        }

        /// <summary>
        /// 读取 INI 文件中的 BOOL 型配置参数
        /// </summary>
        /// <param name="section">小节名</param>
        /// <param name="key">项目名或者条目名</param>
        /// <param name="def">默认值</param>
        /// <param name="filePath">INI 文件名</param>
        /// <returns>参数值</returns>
        public static bool ReadBool(string section, string key, bool def, string filePath)
        {
            StringBuilder tempStr = new StringBuilder(255);
            string strDef = "";

            if (def)
                strDef = "1";
            else
                strDef = "0";

            try
            {
                int i = GetPrivateProfileString(section, key, strDef, tempStr, 255, filePath);
                if (tempStr.ToString() == "1")
                    return true;
                else
                    return false;
            }
            catch
            {
                return def;
            }
        }
        /// <summary>
        /// 读取 INI 文件中的 string 型配置参数
        /// </summary>
        /// <param name="section">小节名</param>
        /// <param name="key">项目名或者条目名</param>
        /// <param name="def">默认值</param>
        /// <param name="filePath">INI 文件名</param>
        /// <returns>参数值</returns>
        public static string ReadString(string section, string key, string def, string filePath)
        {
            StringBuilder tempStr = new StringBuilder(10000);
            try
            {
                int i = GetPrivateProfileString(section, key, def, tempStr, 10000, filePath);
                return tempStr.ToString();
            }
            catch
            {
                return def;
            }
        }


        /// <summary>  
        /// 在INI文件中，删除指定节点中的指定的键。  
        /// </summary>  
        /// <param name="iniFile">INI文件</param>  
        /// <param name="section">节点</param>  
        /// <param name="key">键</param>  
        /// <returns>操作是否成功</returns>  
        public static void INIDeleteKey(string section, string key, string iniFile)
        {
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("必须指定键名称", "key");
            }
            try
            {
                WritePrivateProfileString(section, key, null, iniFile);
            }
            catch
            {

            }
        }

        /// <summary>  
        /// 在INI文件中，删除指定的节点。  
        /// </summary>  
        /// <param name="iniFile">INI文件</param>  
        /// <param name="section">节点</param>  
        /// <returns>操作是否成功</returns>  
        public static void INIDeleteSection(string iniFile, string section)
        {
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }
            try
            {
                WritePrivateProfileString(section, null, null, iniFile);
            }
            catch
            {

            }
        }
    }
}

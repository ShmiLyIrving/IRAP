using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace IRAP.Global
{
    public class Encrypt
    {
        /// <summary>
        /// 声明对称算法变量
        /// </summary>
        private SymmetricAlgorithm mCSP;
        /// <summary>
        /// 初始化向量
        /// </summary>
        private const string CIV = "Mi9l/+7Zujhy12se6Yjy111A";
        /// <summary>
        /// 密钥（常量）
        /// </summary>
        private const string CKEY = "jkHuIy9D/9i=";
        private static Encrypt instance = null;

        /// <summary>
        /// 实例化
        /// </summary>
        public Encrypt()
        {
            mCSP = new DESCryptoServiceProvider();  // 定义访问数据加密标准（DES）算法的加密服务提供程序（CSP）版本的包装对象，此类是 SymmetricAlgorithm 的派生类
        }

        public static Encrypt Instance
        {
            get
            {
                if (instance == null)
                    instance = new Encrypt();
                return instance;
            }
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="value">需加密的字符串</param>
        public string EncryptString(string value)
        {
            if (value.Trim() == "")
            {
                return "";
            }
            else
            {
                ICryptoTransform ct;    // 定义基本的加密转换算法
                MemoryStream ms;        // 定义内存流
                CryptoStream cs;        // 定义将内存流链接到加密转换的流
                byte[] byt;

                // CreateEncryptor 创建（对称数据）加密对象
                ct = mCSP.CreateEncryptor(Convert.FromBase64String(CKEY), Convert.FromBase64String(CIV));   // 用指定的密钥和初始化向量创建对称数据加密标准
                byt = Encoding.UTF8.GetBytes(value);    // 将 value 字符转换为 UTF-8 编码的字节序列
                ms = new MemoryStream();                // 创建内存流
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);      // 将内存流连接到加密转换的流
                cs.Write(byt, 0, byt.Length);           // 写入内存流
                cs.FlushFinalBlock();                   // 将缓冲区中的数据写入内存流，并清除缓冲区
                cs.Close();                             // 释放内存流
                return Convert.ToBase64String(ms.ToArray());                // 将内存流转写入字节数组并转换为 string 字符
            }
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="value">要解密的字符串</param>
        public string DecryptString(string value)
        {
            if (value.Trim() == "")
            {
                return "";
            }
            else
            {
                ICryptoTransform ct;                    // 定义基本的加密转换运算
                MemoryStream ms;                        // 定义内存流
                CryptoStream cs;                        // 定义将内存流链接到加密转换的流
                byte[] byt;

                ct = mCSP.CreateDecryptor(Convert.FromBase64String(CKEY), Convert.FromBase64String(CIV));   // 用指定的密钥和初始化向量创建对称数据解密标准
                byt = Convert.FromBase64String(value);  // 将 value(Base64) 字符转换成字节数组
                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();
                cs.Close();
                return Encoding.UTF8.GetString(ms.ToArray());               // 将字节数组中的所有字符解码为一个字符串
            }
        }
    }
}

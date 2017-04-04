using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VA_ITCMS2000
{
    public class DBConnectParam : Param
    {
        public string DBAddress
        {
            get { return GetString("DBAddress"); }
            set { SaveParam("DBAddress", value); }
        }
        public string DBUserID
        {
            get { return GetString("DBUserID"); }
            set { SaveParam("DBUserID", value); }
        }
        public string DBUserPWD
        {
            get { return GetString("DBUserPWD"); }
            set { SaveParam("DBUserPWD", value); }
        }
        public string DBName
        {
            get { return GetString("DBName"); }
            set { SaveParam("DBName", value); }
        }
        public string ConnectionString
        {
            get
            {
                return string.Format(
                    "Server={0};initial catalog={1};UID={2};" +
                    "Password={3};Min Pool Size=2;Max Pool Size=60;",
                    DBAddress,
                    DBName,
                    DBUserID,
                    DBUserPWD);
            }
        }
    }
}

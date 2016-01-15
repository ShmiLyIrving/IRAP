using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;

namespace IRAP.Server.Global
{
    public class DBConfigParams
    {
        private string _dbConnectionString;
        private const string configurationFileName = "IRAP.Server.ini";
        private string configurationFileFullName = "";
        private string _dbAddress = "";
        private string _dbName = "";
        private string _dbUserID = "";
        private string _dbUserPWD = "";
        private string _serverName = "";

        public DBConfigParams(string serverName)
        {
            _serverName = serverName;
            configurationFileFullName = string.Format("{0}{1}",
                AppDomain.CurrentDomain.BaseDirectory,
                configurationFileName);

            _dbAddress = IniFile.ReadString(serverName, "Host", "127.0.0.1", configurationFileFullName);
            _dbName = IniFile.ReadString(serverName, "Database", "IRAP", configurationFileFullName);
            _dbUserID = IniFile.ReadString(serverName, "UserID", "sa", configurationFileFullName);
            _dbUserPWD = IniFile.ReadString(serverName, "UserPWD", "", configurationFileFullName);

            _dbConnectionString = string.Format("Data Source={0};" +
                "Initial Catalog={1};Persist Security Info=True;" +
                "User ID={2};Password={3}",
                _dbAddress,
                _dbName,
                _dbUserID,
                Encrypt.Instance.DecryptString(_dbUserPWD));
        }

        public string DBConnectionString
        {
            get { return _dbConnectionString; }
        }

        public string DBAddress
        {
            get { return _dbAddress; }
            set
            {
                _dbAddress = value;
                IniFile.WriteString(_serverName, "Host", value, configurationFileFullName);
            }
        }

        public string DBName
        {
            get { return _dbName; }
            set
            {
                _dbName = value;
                IniFile.WriteString(_serverName, "Database", value, configurationFileFullName);
            }
        }

        public string DBUserID
        {
            get { return _dbUserID; }
            set
            {
                _dbUserID = value;
                IniFile.WriteString(_serverName, "UserID", value, configurationFileFullName);
            }
        }

        public string DBUserPWD
        {
            set
            {
                _dbUserPWD = Encrypt.Instance.EncryptString(value);
                IniFile.WriteString(_serverName, "UserPWD", _dbUserPWD, configurationFileFullName);
            }
        }
    }
}

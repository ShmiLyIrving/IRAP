using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;

namespace IRAP.UFMPS.Library
{
		public class TTaskInfo: System.Object
		{
			public TTaskInfo(string regKeyItem, TObjectCreateType objCreateType)
			{
				createType = objCreateType;
				registryKeyItem = regKeyItem;

				switch (objCreateType)
				{
					case TObjectCreateType.octNew:
						taskID = Guid.NewGuid().ToString();
						registryKeyItem = string.Format("{0}{1}",
							FolderCheck(registryKeyItem),
							taskID);
						break;
					case TObjectCreateType.octLoad:
						LoadTaskInfo(regKeyItem);
						break;
					default:
							break;
				}
			}

			private TTaskInfo()
			{
			}
			private TObjectCreateType createType;
			private string registryKeyItem = "";

			public TTaskInfo Clone()
			{
				return (TTaskInfo)this.MemberwiseClone();
			}

			public virtual void Delete()
			{
				if (createType == TObjectCreateType.octLoad)
				{
					string strParentItem = registryKeyItem.Replace(
						string.Format(@"\{0}", taskID),
						"");
					try
					{
						Registry.CurrentUser.DeleteSubKeyTree(registryKeyItem);
					}
					catch (Exception error)
					{
						throw new Exception(string.Format("无法从注册表中删除监控任务：{0}，原因：{1}",
							this.taskName,
							error.Message));
					}

					RegistryKey reg = Registry.CurrentUser.CreateSubKey(strParentItem);
					int intTaskCount = Convert.ToInt32(reg.GetValue("TaskCount").ToString());
					intTaskCount--;
					reg.SetValue("TaskCount", intTaskCount, RegistryValueKind.DWord);
				}
			}

			public virtual void Save()
			{
				RegistryKey reg = Registry.CurrentUser.CreateSubKey(registryKeyItem);

				try
				{
					reg.SetValue("TaskID", taskID, RegistryValueKind.String);
					reg.SetValue("TaskName", taskName, RegistryValueKind.String);
					reg.SetValue("WatchDirectory", watchFolder, RegistryValueKind.String);

					reg.SetValue("WatchType", (int)watchType, RegistryValueKind.DWord);
					reg.SetValue("NormalWatchFileExts", normalWatchFileExts, RegistryValueKind.String);
					reg.SetValue("NormalKeepUndealFile", normalKeepUndealFile, RegistryValueKind.DWord);
					reg.SetValue("NormalKeepUndealFileDirectory", normalKeepUndealFileFolder, RegistryValueKind.String);

					reg.SetValue("FlagFileName", flagFileName, RegistryValueKind.String);
					reg.SetValue("FlagFileGetDataFileType", flagFileGetDataFileType, RegistryValueKind.DWord);
					reg.SetValue("FlagFileDataFileExt", flagFileDataFileExt, RegistryValueKind.String);
					reg.SetValue("FlagFileDataFileDirectory", flagFileDataFileFolder, RegistryValueKind.String);

					reg.SetValue("BackupFileFlag", backupFileFlag, RegistryValueKind.DWord);
					reg.SetValue("BackupFileDirectory", backupFileFolder, RegistryValueKind.String);

					reg.SetValue("FileDealType", (int)fileDealType, RegistryValueKind.DWord);

					reg.SetValue("FTP_Address", ftp_Address, RegistryValueKind.String);
					reg.SetValue("FTP_Port", ftp_Port, RegistryValueKind.DWord);
					reg.SetValue("FTP_UserID", ftp_UserID, RegistryValueKind.String);
					reg.SetValue("FTP_UserPWD", ftp_UserPWD, RegistryValueKind.String);

					reg.SetValue("DBServer", dbServer, RegistryValueKind.String);
					reg.SetValue("DBUserID", dbUserID, RegistryValueKind.String);
					reg.SetValue("DBUserPWD", dbUserPWD, RegistryValueKind.String);
					reg.SetValue("DBName", dbName, RegistryValueKind.String);
					reg.SetValue("DB_ImportTypeID", db_ImportTypeID, RegistryValueKind.DWord);
					reg.SetValue("DB_NumFields", db_NumFields, RegistryValueKind.DWord);
					reg.SetValue("DB_FieldTeminator", db_FieldTerminator, RegistryValueKind.String);
					reg.SetValue("DB_RowTerminator", db_RowTerminator, RegistryValueKind.String);
					reg.SetValue("DB_FormatFile", db_FormatFile, RegistryValueKind.String);
					reg.SetValue("DB_FirstRow", db_FirstRow, RegistryValueKind.DWord);

					reg.SetValue("Copy_DestDirectory", copy_DestFolder, RegistryValueKind.String);
					reg.SetValue("UnrecognizedFolder", unrecognizedFloder, RegistryValueKind.String);

                    reg.SetValue("tb_TableName", tbTableName, RegistryValueKind.String);
                    reg.SetValue("tb_TextFileSplitter", tbTxtFileSplitter, RegistryValueKind.String);
                    reg.SetValue("tb_NumberOfTextFields", tbNumOfTxtFields, RegistryValueKind.DWord);
                    reg.SetValue("tb_DataFirstRow", tbDataFirstRow, RegistryValueKind.DWord);
                    reg.SetValue("tb_IncludeTextFileName", tbIncludeTxtFileName, RegistryValueKind.DWord);
				}
				finally
				{
					reg.Close();
					reg.Dispose();
				}

				if (createType == TObjectCreateType.octNew)
				{
					string strParentItem = registryKeyItem.Replace(
						string.Format(@"\{0}", taskID),
						"");
					reg = Registry.CurrentUser.CreateSubKey(strParentItem);
					try
					{
						int intTaskCount = Convert.ToInt32(reg.GetValue("TaskCount", "0"));
						intTaskCount++;
						reg.SetValue("TaskCount", intTaskCount);
					}
					finally
					{
						reg.Close();
					}
				}

				createType = TObjectCreateType.octLoad;
			}

			private string FolderCheck(string directory)
			{
				string rlt = "";

				rlt = directory.Trim();
				if (rlt.Length > 0)
				{
					if (rlt.Substring(rlt.Length - 1, 1) != @"\")
					{
						rlt = rlt + @"\";
					}
				}
				return rlt;
			}

			private void LoadTaskInfo(string regKey)
			{
				RegistryKey reg = Registry.CurrentUser.OpenSubKey(regKey);

				try
				{
					taskID = reg.GetValue("TaskID").ToString();
				}
				catch
				{
					throw new Exception("Wrong task information");
				}

				taskName = reg.GetValue("TaskName", "").ToString();
				watchFolder = reg.GetValue("WatchDirectory", "").ToString();
				watchType = (TWatchType)Convert.ToInt32(reg.GetValue("WatchType", "0"));

				NormalWatchFileExts = reg.GetValue("NormalWatchFileExts", "").ToString();
				normalKeepUndealFile = Convert.ToInt32(reg.GetValue("NormalKeepUndealFile", "0").ToString()) == 1;
				normalKeepUndealFileFolder = reg.GetValue("NormalKeepUndealFileDirectory", "").ToString();

				FlagFileName = reg.GetValue("FlagFileName", "").ToString();
				flagFileGetDataFileType = Convert.ToInt32(reg.GetValue("FlagFileGetDataFileType", "1").ToString());
				flagFileDataFileExt = reg.GetValue("FlagFileDataFileExt", "").ToString();
				flagFileDataFileFolder = reg.GetValue("FlagFileDataFileDirectory", "").ToString();

				backupFileFlag = Convert.ToInt32(reg.GetValue("BackupFileFlag", "0").ToString()) == 1;
				backupFileFolder = reg.GetValue("BackupFileDirectory", "").ToString();

				fileDealType = (TDocumentProcessType)Convert.ToInt32(reg.GetValue("FileDealType", "0").ToString());

				ftp_Address = reg.GetValue("FTP_Address", "").ToString();
				ftp_Port = Convert.ToInt32(reg.GetValue("FTP_Port", "21").ToString());
				ftp_UserID = reg.GetValue("FTP_UserID", "").ToString();
				ftp_UserPWD = reg.GetValue("FTP_UserPWD", "").ToString();

				dbServer = reg.GetValue("DBServer", "").ToString();
				dbUserID = reg.GetValue("DBUserID", "").ToString();
				dbUserPWD = reg.GetValue("DBUserPWD", "").ToString();
				dbName = reg.GetValue("DBName", "").ToString();
				db_ImportTypeID = Convert.ToInt32(reg.GetValue("DB_ImportTypeID", "0").ToString());
				db_NumFields = Convert.ToInt32(reg.GetValue("DB_NumFields", "0").ToString());
				db_FieldTerminator = reg.GetValue("DB_FieldTerminator", "").ToString();
				db_RowTerminator = reg.GetValue("DB_RowTerminator", "").ToString();
				db_FormatFile = reg.GetValue("DB_FormatFile", "").ToString();
				db_FirstRow = Convert.ToInt32(reg.GetValue("Db_FirstRow", "0").ToString());

				copy_DestFolder = reg.GetValue("Copy_DestDirectory", "").ToString();
				unrecognizedFloder = reg.GetValue("UnRecognizedFolder", "").ToString();

                // 数据导入数据库指定表的配置信息
                tbTableName = reg.GetValue("tb_TableName", "").ToString();
                tbTxtFileSplitter = reg.GetValue("tb_TextFileSplitter", "|").ToString();
                tbNumOfTxtFields = Convert.ToInt32(reg.GetValue("tb_NumberOfTextFields", "0").ToString());
                tbDataFirstRow = Convert.ToInt32(reg.GetValue("tb_DataFirstRow", "0").ToString());
                tbIncludeTxtFileName = Convert.ToInt32(reg.GetValue("tb_IncludeTextFileName", "0").ToString()) == 1;
			}

            public bool BackupFileFlag
            {
                get { return backupFileFlag; }
                set
                {
                    if (backupFileFlag != value)
                        backupFileFlag = value;
                }
            }
			private bool backupFileFlag = false;

            public string BackupFileFolder
            {
                get { return backupFileFolder; }
                set
                {
                    if (backupFileFolder != value)
                        backupFileFolder = FolderCheck(value);
                }
            }
			private string backupFileFolder = "";

            public string Copy_DestFolder
            {
                get { return copy_DestFolder; }
                set
                {
                    if (copy_DestFolder != value)
                        copy_DestFolder = FolderCheck(value);
                }
            }
			private string copy_DestFolder = "";

            public string DbName
            {
                get { return dbName; }
                set
                {
                    if (dbName != value)
                        dbName = value;
                }
            }
			private string dbName = "";

            public string DbServer
            {
                get { return dbServer; }
                set
                {
                    if (dbServer != value)
                        dbServer = value;
                }
            }
			private string dbServer = "";

            public string DbUserID
            {
                get { return dbUserID; }
                set
                {
                    if (dbUserID != value)
                        dbUserID = value;
                }
            }
			private string dbUserID = "";

            public string DbUserPWD
            {
                get { return dbUserPWD; }
                set
                {
                    if (dbUserPWD != value)
                        dbUserPWD = value;
                }
            }
			private string dbUserPWD = "";

            public string Db_FieldTerminator
            {
                get { return db_FieldTerminator; }
                set
                {
                    if (db_FieldTerminator != value)
                        db_FieldTerminator = value;
                }
            }
			private string db_FieldTerminator = "";

            public int Db_FirstRow
            {
                get { return db_FirstRow; }
                set
                {
                    if (db_FirstRow != value)
                        db_FirstRow = value;
                }
            }
			private int db_FirstRow = 0;

            public string Db_FormatFile
            {
                get { return db_FormatFile; }
                set
                {
                    if (db_FormatFile != value)
                        db_FormatFile = value;
                }
            }
			private string db_FormatFile = "";

            public int Db_ImportTypeID
            {
                get { return db_ImportTypeID; }
                set
                {
                    if (db_ImportTypeID != value)
                        db_ImportTypeID = value;
                }
            }
			private int db_ImportTypeID = 0;

            public int Db_NumFields
            {
                get { return db_NumFields; }
                set
                {
                    if (db_NumFields != value)
                        db_NumFields = value;
                }
            }
			private int db_NumFields = 0;

            public string Db_RowTerminator
            {
                get { return db_RowTerminator; }
                set
                {
                    if (db_RowTerminator != value)
                        db_RowTerminator = value;
                }
            }
			private string db_RowTerminator = "";

            public TDocumentProcessType FileDealType
            {
                get { return fileDealType; }
                set
                {
                    if (fileDealType != value)
                        fileDealType = value;
                }
            }
			private TDocumentProcessType fileDealType = TDocumentProcessType.FTP;

            public string FlagFileDataFileFolder
            {
                get { return flagFileDataFileFolder; }
                set
                {
                    if (flagFileDataFileFolder != value)
                        flagFileDataFileFolder = FolderCheck(value);
                }
            }
			private string flagFileDataFileFolder = "";

            public string FlagFileDataFileExt
            {
                get { return flagFileDataFileExt; }
                set
                {
                    if (flagFileDataFileExt != value)
                        flagFileDataFileExt = value;
                }
            }
			private string flagFileDataFileExt = "";

            public int FlagFileGetDataFileType
            {
                get { return flagFileGetDataFileType; }
                set
                {
                    if (flagFileGetDataFileType != value)
                        flagFileGetDataFileType = value;
                }
            }
			private int flagFileGetDataFileType = 0;

            public string FlagFileName
            {
                get { return flagFileName; }
                set
                {
                    if (flagFileName != value)
                    {
                        flagFileName = value;
                        flagFileNames = new List<string>(
                            flagFileName.Split(new string[] { ";" },
                                StringSplitOptions.RemoveEmptyEntries));
                    }
                }
            }
			private string flagFileName = "";

            public List<string> FlagFileNames
            {
                get { return flagFileNames; }
                set
                {
                    if (flagFileNames != value)
                        flagFileNames = value;
                }
            }
			private List<string> flagFileNames = new List<string>();

            public string Ftp_Address
            {
                get { return ftp_Address; }
                set
                {
                    if (ftp_Address != value)
                        ftp_Address = value;
                }
            }
			private string ftp_Address = "";

            public int Ftp_Port
            {
                get { return ftp_Port; }
                set
                {
                    if (ftp_Port != value)
                        ftp_Port = value;
                }
            }
			private int ftp_Port = 21;

            public string Ftp_UserID
            {
                get { return ftp_UserID; }
                set
                {
                    if (ftp_UserID != value)
                        ftp_UserID = value;
                }
            }
			private string ftp_UserID = "";

            public string Ftp_UserPWD
            {
                get { return ftp_UserPWD; }
                set
                {
                    if (ftp_UserPWD != value)
                        ftp_UserPWD = value;
                }
            }
			private string ftp_UserPWD = "";

            public bool NormalKeepUndealFile
            {
                get { return normalKeepUndealFile; }
                set
                {
                    if (normalKeepUndealFile != value)
                        normalKeepUndealFile = value;
                }
            }
			private bool normalKeepUndealFile = false;

            public string NormalKeepUndealFileFolder
            {
                get { return normalKeepUndealFileFolder; }
                set
                {
                    if (normalKeepUndealFileFolder != value)
                        normalKeepUndealFileFolder = value;
                }
            }
			private string normalKeepUndealFileFolder = "";

            public string NormalWatchFileExts
            {
                get { return normalWatchFileExts; }
                set
                {
                    if (normalWatchFileExts != value)
                    {
                        normalWatchFileExts = value;
                        normalWatchFileFilters = new List<string>(
                            normalWatchFileExts.Split(new string[] { ";" },
                                StringSplitOptions.RemoveEmptyEntries));
                    }
                }
            }
			private string normalWatchFileExts = "";

            public List<string> NormalWatchFileFilters
            {
                get { return normalWatchFileFilters; }
                set
                {
                    if (normalWatchFileFilters != value)
                        normalWatchFileFilters = value;
                }
            }
			private List<string> normalWatchFileFilters = new List<string>();

            public string TaskID
            {
                get { return taskID; }
                set
                {
                    if (taskID != value)
                        taskID = value;
                }
            }
			private string taskID = "";

            public string TaskName
            {
                get { return taskName; }
                set
                {
                    if (taskName != value)
                        taskName = value;
                }
            }
			private string taskName = "";

            public string UnrecognizedFloder
            {
                get { return unrecognizedFloder; }
                set
                {
                    if (unrecognizedFloder != value)
                        unrecognizedFloder = FolderCheck(value);
                }
            }
			private string unrecognizedFloder = "";

            public string WatchFolder
            {
                get { return watchFolder; }
                set
                {
                    if (watchFolder != value)
                        watchFolder = FolderCheck(value);
                }
            }
			private string watchFolder = "";

            public TWatchType WatchType
            {
                get { return watchType; }
                set
                {
                    if (watchType != value)
                        watchType = value;
                }
            }
			private TWatchType watchType = TWatchType.SignalFlag;

            public string TbTableName
            {
                get { return tbTableName; }
                set { tbTableName = value; }
            }
            private string tbTableName = "";

            public string TbTxtFileSplitter
            {
                get { return tbTxtFileSplitter; }
                set { tbTxtFileSplitter = value; }
            }
            private string tbTxtFileSplitter = "|";

            public int TbNumOfTxtFields
            {
                get { return tbNumOfTxtFields; }
                set { tbNumOfTxtFields = value; }
            }
            private int tbNumOfTxtFields = 0;

            public int TbDataFirstRow
            {
                get { return tbDataFirstRow; }
                set { tbDataFirstRow = value; }
            }
            private int tbDataFirstRow = 1;

            public bool TbIncludeTxtFileName
            {
                get { return tbIncludeTxtFileName; }
                set { tbIncludeTxtFileName = value; }
            }
            private bool tbIncludeTxtFileName = false;
        }
}

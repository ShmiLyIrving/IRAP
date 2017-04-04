using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace VA_ITCMS2000
{
    /// <summary>
    /// 语音播放线程
    /// </summary>
    public class VAThread
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        #region 申明委托
        private delegate void InvokeAddMessage(string msg);
        private delegate void InvokeClearLogs();
        #endregion

        private static VAThread _instance = null;

        private TextBox edtLog = null;
        /// <summary>
        /// 线程是否运行
        /// </summary>
        private bool isThreadStarted = false;
        private Thread thread = null;
        private object locker = new object();

        private SqlConnection dbConnection = new SqlConnection();


        private IPCast.SetCallBack ipCallback;

        private VAThread() { }

        public static VAThread Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new VAThread();
                return _instance;
            }
        }

        public TextBox Logs
        {
            get { return edtLog; }
            set { edtLog = value; }
        }

        public bool Enabled
        {
            get { return isThreadStarted; }
            set
            {
                if (value)
                {
                    if (!isThreadStarted)
                    {
                        StartWatch();
                    }
                }
                else
                    isThreadStarted = false;
            }
        }

        private void AddLog(string msg)
        {
            if (edtLog.Lines.Length > 100)
            {
                edtLog.Text = "";
            }

            if (msg == "")
                edtLog.Text += "\r\n";
            else
                edtLog.Text +=
                    string.Format(
                        "{0}: {1}\r\n",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        msg);

            edtLog.SelectionStart = edtLog.Text.Length;
            edtLog.ScrollToCaret();

            IRAP.Global.WriteLog.Instance.Write(msg);

            Thread.Sleep(100);
        }

        private void ClearLogs()
        {
            edtLog.Text = "";
        }

        private void WriteLogInThread(string message)
        {
            edtLog.BeginInvoke(
                new InvokeAddMessage(AddLog),
                new object[] { message });
        }

        private void ClearLogInThread()
        {
            edtLog.BeginInvoke(
                new InvokeClearLogs(ClearLogs));
        }

        private void Connect()
        {
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.ConnectionString = SysParams.Instance.DBParams.ConnectionString;

                try
                {
                    dbConnection.Open();
                }
                catch (Exception error)
                {
                    // 可以在这里写数据库连接失败后的处理代码
                    WriteLogInThread(error.Message);
                }
            }
        }

        private void Disconnect()
        {
            if (dbConnection.State != ConnectionState.Closed)
                dbConnection.Close();
        }

        private DataSet ExecuteReturnDataSet(CommandType commandType, string cmdStr)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            //WriteLogInThread(cmdStr);

            DataSet returnDS = new DataSet();
            SqlCommand cmd = new SqlCommand(cmdStr, dbConnection)
            {
                CommandType = commandType
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            sda.Fill(returnDS);

            return returnDS;
        }

        private void StartWatch()
        {
            if (!isThreadStarted)
            {
                thread = new Thread(new ThreadStart(Do));

                ClearLogInThread();
                WriteLogInThread("开始监控广播消息......");

                isThreadStarted = true;

                thread.IsBackground = true;
                thread.Start();
            }
        }

        private void ConnectToITCSM2000Serv()
        {
            try
            {
                bool vaStatus =
                    IPCast.Connect(
                        SysParams.Instance.VAParams.Address,
                        SysParams.Instance.VAParams.UserID,
                        SysParams.Instance.VAParams.UserPWD);
                ipCallback = new IPCast.SetCallBack(SetCallBackHandler);

                if (vaStatus)
                {
                    IPCast.IPCAST_SetCallBack(ipCallback);
                }
            }
            catch (Exception error)
            {
                WriteLogInThread(error.Message);
            }
        }

        private void SetCallBackHandler(int eventNo, string paramStr)
        {

        }

        private void Do()
        {
            try
            {
                #region 打开数据库连接
                Connect();
                if (dbConnection.State != ConnectionState.Open)
                {
                    WriteLogInThread(
                        string.Format(
                            "无法连接[{0}]数据库！",
                            SysParams.Instance.DBParams.DBAddress));
                    isThreadStarted = false;
                    return;
                }
                #endregion

                #region 建立 ITC MS2000 广播服务器连接
                //vaStatus =
                //    IPCast.Connect(
                //        SysParams.Instance.VAParams.Address,
                //        SysParams.Instance.VAParams.UserID,
                //        SysParams.Instance.VAParams.UserPWD);
                #endregion

                while (true)
                {
                    if (!isThreadStarted)
                        break;

                    DeleteExpireMP3Files();

                    try
                    {
                        #region 获取需要广播的消息
                        string rightNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sqlCmd =
                            string.Format(
                                "SELECT TOP 5 * FROM IRAPDWforMES..utb_Log_CRPlaying " +
                                "WHERE Conclusion=0 AND StationID='{0}' " +
                                "AND ScheduledPlayTime <= '{1}' " +
                                // "AND ScheduledExpireTime >= '{1}' " + 暂时忽略过期广播消息的设置
                                "ORDER BY CreatedTime ASC",
                                SysParams.Instance.StationID,
                                rightNow);
                        DataSet ds =
                            ExecuteReturnDataSet(
                                CommandType.Text,
                                sqlCmd);
                        DataTable dt = ds.Tables[0];
                        #endregion

                        foreach (DataRow dr in dt.Rows)
                        {
                            if (!isThreadStarted)
                                break;

                            int logID = (int)dr["LogID"];
                            DateTime timeScheduledPlaying = Convert.ToDateTime(dr["ScheduledPlayTime"].ToString());
                            DateTime timeScheduledExpire = Convert.ToDateTime(dr["ScheduledExpireTime"].ToString());
                            string cmdPlay = dr["PlayCommand"].ToString();
                            int valueCHControl = Convert.ToInt32(dr["CHCtrlValue"].ToString());
                            int numOfPlaying = Convert.ToInt32(dr["TimesPlayed"].ToString());

                            if (numOfPlaying <= 0)
                                numOfPlaying = 1;

                            WriteLogInThread(cmdPlay);

                            #region 生成待广播的声音文件集（mp3格式）
                            IPCast.PlayFile[] files;
                            int fileCount = GenerateVoices(cmdPlay, out files);
                            #endregion

                            #region 生成目标终端集
                            int[] terms = GenerateTermIDs(valueCHControl);
                            #endregion

                            #region 发送消息广播
                            if (!IPCast.IPCAST_ServerStatus())
                            {
                                ConnectToITCSM2000Serv();
                            }
                            if (!IPCast.IPCAST_ServerStatus())
                            {
                                WriteLogInThread(
                                    string.Format(
                                        "无法连接广播服务器[{0}]，不能播放广播",
                                        SysParams.Instance.VAParams.Address));
                                continue;
                            }

                            if (TermsIdle(terms))
                            {
                                try
                                {
                                    IPCast.FilePlayStart(
                                        ref files,
                                        fileCount,
                                        terms,
                                        terms.Length,
                                        500,
                                        3,
                                        0,
                                        0);
                                }
                                catch (Exception error)
                                {
                                    WriteLogInThread(
                                        string.Format(
                                            "播放消息广播时发生错误：[{0}]。\r\n" +
                                            "可能没有找到需要播放的 MP3 文件。",
                                            error.Message));
                                }
                                #endregion

                                #region 将数据库中消息记录状态更新为已广播
                                SqlCommand cmd =
                                    new SqlCommand(
                                        string.Format(
                                            "UPDATE IRAPDWforMES..utb_Log_CRPlaying " +
                                            "SET Conclusion=1 WHERE LogID={0}",
                                            logID),
                                        dbConnection)
                                    {
                                        CommandType = CommandType.Text,
                                    };
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception error)
                                {
                                    WriteLogInThread(error.Message);
                                }
                                #endregion
                            }

                            Thread.Sleep(10);
                        }
                    }
                    catch (Exception error)
                    {
                        WriteLogInThread(error.Message);
                    }

                    Thread.Sleep(SysParams.Instance.RefreshTimeSpan);
                }
            }
            finally
            {
                #region 关闭 ITC MS2000 广播服务器连接
                IPCast.DisConnect();
                #endregion

                if (dbConnection.State != ConnectionState.Closed)
                    Disconnect();
                WriteLogInThread("停止监控......");
            }
        }

        private int GenerateVoices(string playCommand, out IPCast.PlayFile[] playFiles)
        {
            List<IPCast.PlayFile> files = new List<IPCast.PlayFile>();

            string[] cmds = playCommand.Split('[');

            for (int i = 0; i < cmds.Length; i++)
            {
                if (cmds[i].Trim() == "")
                    continue;

                cmds[i] = cmds[i].Replace(";", "");
                if (cmds[i].Substring(0, 2).ToUpper() == "P]")
                {
                    files.Add(
                        new IPCast.PlayFile()
                        {
                            fid = 0,
                            fvol = 50,
                            fname =
                                string.Format(
                                    @"{0}Mp3\{1}",
                                    AppDomain.CurrentDomain.BaseDirectory,
                                    cmds[i].Replace("P]", "")),
                        });
                }
                if (cmds[i].Substring(0, 2).ToUpper() == "T]")
                {
                    string transFile = Text2MP3(cmds[i].Replace("T]", ""));
                    if (transFile != "")
                    {
                        files.Add(
                            new IPCast.PlayFile()
                            {
                                fid = 0,
                                fvol = 100,
                                fname = transFile,
                            });
                    }
                }
            }

            playFiles = files.ToArray();
            return files.Count;
        }

        private string Text2MP3(string voiceText)
        {
            string tmpDirectory = 
                AppDomain.CurrentDomain.BaseDirectory + "Temp";
            if (!Directory.Exists(tmpDirectory))
                try
                {
                    Directory.CreateDirectory(tmpDirectory);
                }
                catch (Exception error)
                {
                    WriteLogInThread(
                        string.Format(
                            "无法创建临时路径[{0}]，原因：{1}",
                            tmpDirectory,
                            error.Message));
                    return "";
                }

            string fileWithoutExtension = Guid.NewGuid().ToString("N");
            string fileWav =
                string.Format(
                    @"{0}\{1}.wav",
                    tmpDirectory,
                    fileWithoutExtension);
            string fileMP3 =
                string.Format(
                    @"{0}\{1}.mp3",
                    tmpDirectory,
                    fileWithoutExtension);

            int cnVoice, enVoice;
            Type type = Type.GetTypeFromProgID("SAPI.SpVoice");
            dynamic spVoice = Activator.CreateInstance(type);
            dynamic colVoice = spVoice.GetVoices();//‘获得语音引擎集合
            spVoice.Volume = 100;// ‘设置音量，0到100，数字越大音量越大
            spVoice.Rate = 0;//
            string langCN = "MSSimplifiedChineseVoice";// ‘简体中文
            string langEN = "MSSam";// ‘如果安装了TTS Engines 5.1，还可以选择MSMike,MSMary
            for (int i = 0; i < colVoice.Count; i++)
            {
                if (colVoice[i].Id == langCN)
                    cnVoice = i;
                if (colVoice[i].Id == langEN)
                    enVoice = i;
            }
            int SSFMCreateForWrite = 3;
            int SAFT22kHz16BitMono = 22;
            int SVSFlagsAsync = 1;
            Type type2 = Type.GetTypeFromProgID("SAPI.SpFileStream");
            dynamic objFileStream = Activator.CreateInstance(type2);
            objFileStream.Format.Type = SAFT22kHz16BitMono;
            objFileStream.Open(fileWav, SSFMCreateForWrite, false);
            spVoice.AudioOutputStream = objFileStream;
            spVoice.Speak(voiceText, SVSFlagsAsync);
            spVoice.WaitUntilDone(-1);
            objFileStream.Close();

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.FileName = Application.StartupPath + @"\lame.exe";
            psi.Arguments = 
                string.Format(
                    "-b128 --resample 24 -m j " +
                    "\"{0}\" \"{1}\"",
                    fileWav,
                    fileMP3);
            Process p = Process.Start(psi);
            p.Close();
            p.Dispose();

            Thread.Sleep(1000);

            string fileMP3L = fileMP3.Replace(".mp3", "L.mp3");
            psi = new ProcessStartInfo();
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.FileName = Application.StartupPath + @"\lame.exe";
            psi.Arguments =
                string.Format(
                    "--scale 4 --mp3input \"{0}\" \"{1}\"",
                    fileMP3,
                    fileMP3L);
            p = Process.Start(psi);
            p.Close();
            p.Dispose();

            Thread.Sleep(500);
            File.Delete(fileMP3);
            File.Copy(fileMP3L, fileMP3);
            File.Delete(fileMP3L);

            while (!File.Exists(fileMP3))
                Thread.Sleep(10);

            while (true)
            {
                try
                {
                    File.Delete(fileWav);
                    break;
                }
                catch { ; }
            }

            return fileMP3;
        }

        private int[] GenerateTermIDs(int chControls)
        {
            List<int> ctrls = new List<int>();
            int[] termsID;

            if (SysParams.Instance.RunMode.ToUpper() == "DEBUG")
            {
                termsID = new int[11]
                {
                   5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5
                };
            }
            else
            {
                termsID = new int[11]
                {
                   2, 9, 1, 10, 7, 8, 3, 4, 11, 5, 6
                };
            }

            for (int i = 0, n = 1; i < 11; i++)
            {
                if ((chControls & n) != 0)
                    ctrls.Add(termsID[i]);
                n = n << 1;
            }

            return ctrls.ToArray();
        }

        private void DeleteExpireMP3Files()
        {
            string tmpDirectory =
               AppDomain.CurrentDomain.BaseDirectory + "Temp";

            if (Directory.Exists(tmpDirectory))
            {
                string[] fileNames = Directory.GetFiles(tmpDirectory, "*.mp3");
                for (int i = 0; i < fileNames.Length - 1; i++)
                {
                    FileInfo fi = new FileInfo(fileNames[i]);
                    if (fi.LastWriteTime <= DateTime.Now.AddMinutes(-15))
                        File.Delete(fileNames[i]);
                }
            }
        }

        private bool TermsIdle(int[] terms)
        {
            bool rlt = false;
            bool cycle = true;

            while (cycle)
            {
                cycle = false;

                for (int i = 0; i < terms.Length; i++)
                {
                    Thread.Sleep(10);

                    long size = Marshal.SizeOf(typeof(IPCast.TermAttrEx));
                    IntPtr pTermStatusEx = Marshal.AllocHGlobal((int)new IntPtr(size));

                    try
                    {
                        if (IPCast.GetTermStatusEx((uint)terms[i], pTermStatusEx))
                        {
                            IPCast.TermAttrEx termAttrEx = 
                                (IPCast.TermAttrEx)Marshal.PtrToStructure(
                                    pTermStatusEx, 
                                    typeof(IPCast.TermAttrEx));
                            if (termAttrEx.status != 0)
                            {
                                rlt = false;
                                cycle = true;

                                break;
                            }
                            else
                            {
                                rlt = true;
                            }
                        }
                        else
                        {
                            rlt = false;
                            break;
                        }
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(pTermStatusEx);
                    }
                }
            }

            return rlt;
        }
    }
}
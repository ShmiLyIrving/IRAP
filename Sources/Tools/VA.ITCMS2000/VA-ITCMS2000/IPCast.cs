using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace VA_ITCMS2000
{
    public static class IPCast
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct PlayFile // 播放文件  
        {
            public int fid; // 文件序号（序号小于 0则取全路径）  
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string fname; // 文件名或全路径名 
            public int fvol;
        }


        /*-------------------------------------------------------------------------------------------------
        1.1[01] IPCAST_Connect: 连接到服务器
        函数:	BOOL IPCAST_Connect(LPCTSTR ipAddr, LPCTSTR user, LPCTSTR pass);
        参数:	ipAddr:		服务器IP地址
                user:		登录用户名(缺省可以用admin)
                pass：		登录密码(缺省可以用admin)
        返回:	成功：返回TRUE
                失败：返回FALSE
        -------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// 连接到服务器
        /// </summary>
        /// <remarks>
        /// BOOL IPCAST_Connect(LPCTSTR ipAddr, LPCTSTR user, LPCTSTR pass);
        /// </remarks>
        /// <param name="ipAddr">服务器IP地址</param>
        /// <param name="user">登录用户名(缺省可以用admin)</param>
        /// <param name="pass">登录密码(缺省可以用admin)</param>
        /// <returns>
        /// 成功：返回 true
        /// 失败：返回 false
        /// </returns>
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_Connect")]
        public static extern bool Connect(string ipAddr, string user, string pass);


        /*-------------------------------------------------------------------------------------------------
        1.2[02] IPCAST_DisConnect：断开连接
        函数:	void IPCAST_DisConnect();
        参数:	无
        返回:	无
        -------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// 断开连接
        /// </summary>
        /// <remarks>
        /// void IPCAST_DisConnect();
        /// </remarks>
        /// <returns>
        /// 成功：返回 true
        /// 失败：返回 false
        /// </returns>
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_DisConnect")]
        public static extern bool DisConnect();

        /*-------------------------------------------------------------------------------------------------
        IPCAST_ServerStatus：服务器状态
        函数:	BOOL IPCAST_ServerStatus(void);
        参数:	无
        返回:	正常：返回TRUE；
		        异常：返回FALSE。
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_ServerStatus")]
        public static extern bool IPCAST_ServerStatus();
        /*-------------------------------------------------------------------------------------------------
        4.10 IPCAST_RMSession：删除指定会话
        函数:	BOOL IPCAST_RMSession(ULONG sid);
        参数:	sid:		需要删除的会话ID
        返回：	TRUE：	成功
		        FALSE： 失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_RMSession")]
        public static extern bool RMSession(uint sid);

        /*-------------------------------------------------------------------------------------------------
        2.1[05] IPCAST_FilePlayStart：创建文件播放
        函数:	int IPCAST_FilePlayStart(PlayFile* pFList[], int fCount, ULONG* pTList, int tCount,
                                         int Grade, int CycMode, int CycCount, int CycTime);
        参数:	pFList:		广播文件列表，指向播放文件结构的数组指针
                            fid：播放的服务器上的文件ID，ID<=0则播放本机文件
                            fname：服务器文件显示名或本机文件全路径名。
                fCount:		广播文件的数目
                pTList:		需要添加到本会话的广播终端列表
                fCount:		需要添加的终端数目
                Grade:		广播等级（0~999，数值越大级别越高）（整数）
                CycMode:	播放模式
                            PLAY_CYC_DAN = 0x0001;			// 单曲播放（即只播放一次）
                            PLAY_CYC_DANCIRCLE = 0x0002;	// 单曲循环播放（循环播放一个曲目）
                            PLAY_CYC_DANORDE = 0x0003;		// 顺序播放（按序播放全部歌曲一次）
                            PLAY_CYC_ALLCIRCLE = 0x0004;	// 循环播放（循环播放所有歌曲）
                CycCount:	循环播放次数。（即要求循环播放多少次，0：表示无限次）
                CycTime:	循环播放时长（只有当CycCount = 0时有效，单位为秒。）
        返回:	大于0: 返回广播会话ID
                -1：会话创建失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_FilePlayStart")]
        public static extern int FilePlayStart(ref PlayFile[] pFList, int fCount, int[] pTList, int tCount,
                                         int Grade, int CycMode, int CycCount, int CycTime);


        public static int FilePlayStart(string file, int fCount, int CycMode, params int[] term)
        {
            PlayFile[] FList = new PlayFile[fCount];
            string[] name = file.Split(new char[] { ';' });
            for (int i = 0; i < fCount; i++)
            {
                FList[i].fid = 0;
                FList[i].fvol = 10;
                FList[i].fname = name[i];
            }


            int cnt = term.Length;

            return FilePlayStart(ref FList, fCount, term, cnt, 500, CycMode, 0, 0);
        }
        /*-------------------------------------------------------------------------------------------------
        IPCAST_FilePlayStartLocal：创建本地文件播放
        函数:	int IPCAST_FilePlayStartLocal(const char* pFileList, const char* pTermList,
									         int Grade, int CycMode, int CycCount, int CycTime);
        参数:	pFileList:	广播文件列表，指向播放文件路径指针，多个文件路径用逗号','分隔

		        pTermList:	需要添加到本会话的广播终端列表, 多个终端ID用逗号','分隔
		        Grade:		广播等级（0~999，数值越大级别越高）（整数）
		        CycMode:	播放模式
					        PLAY_CYC_DAN = 0x0001;			// 单曲播放（即只播放一次）
					        PLAY_CYC_DANCIRCLE = 0x0002;	// 单曲循环播放（循环播放一个曲目）
					        PLAY_CYC_DANORDE = 0x0003;		// 顺序播放（按序播放全部歌曲一次）
					        PLAY_CYC_ALLCIRCLE = 0x0004;	// 循环播放（循环播放所有歌曲）
		        CycCount:	循环播放次数。（即要求循环播放多少次，0：表示无限次）
		        CycTime:	循环播放时长（只有当CycCount = 0时有效，单位为秒。）
        返回:	大于0: 返回广播会话ID
		        -1：会话创建失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_FilePlayStartLocal")]
        public static extern int IPCAST_FilePlayStartLocal(string fileList, string pTermList,
                                              int Grade, int CycMode, int CycCount, int CycTime);

        public static int FilePlayStartLocal(string fileList, string pTermList,
                                              int Grade, int CycMode, int CycCount, int CycTime)
        {
            return IPCAST_FilePlayStartLocal(fileList, pTermList, Grade, CycMode, CycCount, CycTime);
        }
        /*-------------------------------------------------------------------------------------------------
        IPCAST_FilePlayStartServer：创建服务器文件播放
        函数:	int IPCAST_FilePlayStartServer(const char* pProgramList, const char* pTermList,
									         int Grade, int CycMode, int CycCount, int CycTime);
        参数:	pProgramList:	广播文件列表，指向媒体库节目ID列表，多个节目ID间用逗号','分隔

		        pTermList:	需要添加到本会话的广播终端列表， 多个终端间用逗号','分隔
		        Grade:		广播等级（0~999，数值越大级别越高）（整数）
		        CycMode:	播放模式
					        PLAY_CYC_DAN = 0x0001;			// 单曲播放（即只播放一次）
					        PLAY_CYC_DANCIRCLE = 0x0002;	// 单曲循环播放（循环播放一个曲目）
					        PLAY_CYC_DANORDE = 0x0003;		// 顺序播放（按序播放全部歌曲一次）
					        PLAY_CYC_ALLCIRCLE = 0x0004;	// 循环播放（循环播放所有歌曲）
		        CycCount:	循环播放次数。（即要求循环播放多少次，0：表示无限次）
		        CycTime:	循环播放时长（只有当CycCount = 0时有效，单位为秒。）
        返回:	大于0: 返回广播会话ID
		        -1：会话创建失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_FilePlayStartServer")]
        public static extern int IPCAST_FilePlayStartServer(string pProgramList, string pTermList,
                                              int Grade, int CycMode, int CycCount, int CycTime);

        public static int FilePlayStartServer(string pProgramList, string pTermList,
                                              int Grade, int CycMode, int CycCount, int CycTime)
        {
            return IPCAST_FilePlayStartServer(pProgramList, pTermList, Grade, CycMode, CycCount, CycTime);
        }
        /*-------------------------------------------------------------------------------------------------
        IPCAST_GetTermVolume：读取终端音量
        函数:	int IPCAST_GetTermVolume(ULONG tid);
        参数:	tid:		查询音量的终端ID
        返回：	>=0:	返回的终端音量
		        -1：	失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_GetTermVolume")]
        public static extern int GetTermVolume(int tid);
        /*-------------------------------------------------------------------------------------------------
        IPCAST_SetTermVolume：设置终端音量
        函数:	BOOL IPCAST_SetTermVolume(ULONG tid, int vol);
        参数:	tid:		需要设置音量的终端ID
		        vol:		音量值。0~56整数，56最大。
        返回：	TRUE:	成功
		        FALSE:	失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_SetTermVolume")]
        public static extern bool SetTermVolume(int tid, int vol);

        /*-------------------------------------------------------------------------------------------------
        2.2[06] IPCAST_FilePlayCtrl：文件播放控制
        函数:	BOOL IPCAST_FilePlayCtrl(ULONG sid, int cmd, int pos)
        参数:	sid:		广播会话ID
                cmd:		控制命令
                            PLAY_CTRL_STOP = 1;		// 停止广播
                            PLAY_CTRL_JUMPFILE = 2;	// 跳转至第pos曲播放
                            PLAY_CTRL_NEXT = 3;		// 跳至下一曲播放
                            PLAY_CTRL_PREV = 4;		// 跳至上一曲播放
                            PLAY_CTRL_PAUSE = 5;	// 暂停播放
                            PLAY_CTRL_RESTORE = 6;	// 恢复播放
                            PLAY_CTRL_JUMPTIME = 7;	// 跳转到当前曲pos秒处位置
                pos:		cmd = 2:	跳转的歌曲序号
                            cmd = 7:	跳转的曲目时间位置
        返回：	TRUE:	成功
                FALSE:	失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_FilePlayCtrl")]
        public static extern bool FilePlayCtrl(int sid, int cmd, int pos);

        public static bool FilePlayStop(int sid)
        {
            return FilePlayCtrl(sid, 1, 0);
        }
        public static bool FilePlayNext(int sid)
        {
            return FilePlayCtrl(sid, 3, 0);
        }
        public static bool FilePlayPre(int sid)
        {
            return FilePlayCtrl(sid, 4, 0);
        }

        /*-------------------------------------------------------------------------------------------------
        IPCAST_RealPlayStart：开始对某一声卡的实时采播
        函数:	int IPCAST_RealPlayStart(UINT uMxId, UINT iItem, ULONG* pTList, int tCount, int Grade,
								         LPCTSTR bakFile);
        参数:	uMxId:		启动采播的声卡序号
		        iItem:		采播声卡的录音项序号
		        pTList:		需要添加到本会话的广播终端列表
		        fCount:		需要添加的终端数目
		        Grade:		广播等级（0~999，数值越大级别越高）（整数）
		        bakFile:	备份文件全路径名。空则不备份
        返回:	大于0: 返回广播会话ID
		        -1：会话创建失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_RealPlayStart")]
        public static extern int RealPlayStart(uint uMxId, int iItem, uint[] pTList, int tCount, int Grade,
                                         string bakFile);

        /*-------------------------------------------------------------------------------------------------
        IPCAST_RealPlayStop：停止对某一声卡的实时采播
        函数:	void IPCAST_RealPlayStop(UINT uMxId);
        参数:	uMxId:		停止采播的声卡序号
        返回:	TRUE:	成功
                FALSE:	失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_RealPlayStop")]
        public static extern bool RealPlayStop(uint uMxId);
        /*-------------------------------------------------------------------------------------------------
        IPCAST_GetTermList：获取终端列表
        函数:	int IPCAST_GetTermList(ULONG* pTList, int nSize);
        参数:	pTList:		保存返回终端ID列表的缓冲区，pTList==NULL或者nSize<=0只返回终端数目
		        nSize:		允许返回的终端ID数目
        返回：	终端数目。pTList!=NULL 且 nSize>0 时，相应ID填写到pTList中。
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_GetTermList")]
        unsafe public static extern int IPCAST_GetTermList(IntPtr pTList, int nSize);
        /*-------------------------------------------------------------------------------------------------
        IPCAST_GetTermStatusEx：获取终端状态扩展属性，包含工作状态和呼叫状态
        函数:	BOOL IPCAST_GetTermStatusEx(ULONG tid, LPTermAttr pTerm);
        参数:	tid:		需要查询的终端ID
		        pTerm:		返回终端属性的指针
        返回：	TRUE:	成功
		        FALSE:	失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_GetTermStatusEx")]
        unsafe public static extern bool IPCAST_GetTermStatusEx(uint tid, IntPtr pTermEx);

        unsafe public static bool GetTermStatusEx(uint tid, IntPtr pTermEx)
        {
            return IPCAST_GetTermStatusEx(tid, pTermEx);
        }

        unsafe public static int GetTermList(IntPtr pTerm, int size)
        {
            return IPCAST_GetTermList(pTerm, size);
        }
        //// 获取系统中所有终端的ID清单
        unsafe public static string GetAllTerms(string[] terms)
        {
            string termIds = "";
            // int OUT_put = 0;
            IntPtr pArray = Marshal.AllocHGlobal(0);
            int count = IPCast.GetTermList(pArray, 0);
            if (count > 0)
            {
                pArray = Marshal.ReAllocHGlobal(pArray, new IntPtr(count * 4));
                int ret = IPCast.GetTermList(pArray, count);        // 获取终端ID清单

                if (ret > 0)
                {
                    uint* pId = (uint*)pArray.ToPointer();
                    for (int i = 0; i < ret; i++)
                    {
                        uint tid = pId[i];
                        termIds += tid.ToString();
                        termIds += ",";
                        //获取终端状态
                        long size = Marshal.SizeOf(typeof(IPCast.TermAttrEx));
                        IntPtr pTermStatusEx = Marshal.AllocHGlobal((int)new IntPtr(size));

                        if (IPCast.GetTermStatusEx(tid, pTermStatusEx))
                        {
                            IPCast.TermAttrEx termAttrEx = (IPCast.TermAttrEx)Marshal.PtrToStructure(pTermStatusEx, typeof(IPCast.TermAttrEx));
                            Debug.WriteLine("termAttr.tid =" + termAttrEx.tid.ToString());
                            Debug.WriteLine("termAttr.status =" + termAttrEx.status.ToString());
                            Debug.WriteLine("termAttr.work_status =" + termAttrEx.work_status.ToString());
                            Debug.WriteLine("termAttr.call_status =" + termAttrEx.call_status.ToString());
                            Debug.WriteLine("termAttr.a_sid =" + termAttrEx.a_sid.ToString());
                            Debug.WriteLine("termAttr.vol =" + termAttrEx.vol.ToString());
                            Debug.WriteLine("termAttr.ipaddr =" + termAttrEx.ipaddr);
                            Debug.WriteLine("termAttr.fwdaddr =" + termAttrEx.fwdaddr);
                            Debug.WriteLine("termAttr.name =" + termAttrEx.name);
                            string tinfo = "tid:" + termAttrEx.tid.ToString() + " " + "name: " + termAttrEx.name + " " + "termIP: " + termAttrEx.ipaddr + " " + "vol:" + termAttrEx.vol.ToString() + "  " +
                                "work_state:" + termAttrEx.work_status.ToString() + "Call_Status:" + termAttrEx.call_status.ToString() + " " + "a_sid:" + termAttrEx.a_sid.ToString() +
                                "  " + "ServerIp: " + " " + termAttrEx.fwdaddr;
                            //MessageBox.Show(tinfo);

                            terms[i] = tinfo;

                        }

                        Marshal.FreeHGlobal(pTermStatusEx);
                    }
                }
                Marshal.FreeHGlobal(pArray);
            }
            termIds.Trim(',');
            return termIds;
        }
        /*-------------------------------------------------------------------------------------------------
        IPCAST_START_TALK：控制终端发起对讲
        函数:	BOOL IPCAST_Start_Talk(LPCallAddr from, LPCallAddr target);
        参数:	from:			发起对讲终端ID和分控面板号，LPCallAddr 见7.9 CallAddr		
		        target:			对讲目标终端ID和分控面板号
        返回：	TRUE:	成功， 
		        FALSE:	失败
        说明： 
	        1. 目前2.3.12.D06版本只支持终端主机发起对讲，不支持指定分控面板发起对讲；
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_Start_Talk")]
        public static extern bool IPCAST_Start_Talk(ref CallAddr from, ref CallAddr target);
        unsafe public static bool Start_Talk(uint from, uint to, int num)
        {
            CallAddr pFrom = new CallAddr();
            CallAddr pTo = new CallAddr();
            pFrom.tid = from;
            pFrom.box_id = 0;
            pTo.tid = to;
            pTo.box_id = num;

            return IPCAST_Start_Talk(ref pFrom, ref pTo);
        }
        /*-------------------------------------------------------------------------------------------------
        IPCAST_STOP_TALK：控制终端结束对讲
        函数:	BOOL IPCAST_Stop_Talk(ULONG tid);
        参数:	tid:			    对讲终端ID 
        返回：	TRUE:	成功， 
		        FALSE:	失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_Stop_Talk")]
        public static extern bool IPCAST_Stop_Talk(uint tid);

        /*-------------------------------------------------------------------------------------------------
        IPCAST_Accept_Call：控制终端接听对讲
        函数:	BOOL IPCAST_Accept_Call(ULONG tid);
        参数:	tid:				振铃终端ID 
        返回：	TRUE:	成功， 
                FALSE:	失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_Accept_Call")]
        public static extern bool IPCAST_Accept_Call(uint tid);

        /*-------------------------------------------------------------------------------------------------
        IPCAST_START_SPEECH：控制终端发起寻呼
        函数:	BOOL IPCAST_START_SPEECH(LPCallAddr from, LPCallAddr targets, int target_number);
        参数:	from:			发起寻呼终端ID和分控面板号，LPCallAddr 见7.9 CallAddr		
                target:			寻呼目标终端ID和分控面板号
                target_number:	寻呼目标个数
        返回：	TRUE:	成功， 
                FALSE:	失败
        说明： 
                1. 目前2.3.12.D06版本只支持终端主机发起寻呼，不支持指定分控面板发起寻呼；
                2. 目前2.3.12.D06版本只支持对单个目标终端发起寻呼，不支持呼叫多个目标终端
        -------------------------------------------------------------------------------------------------*/

        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_Start_Speech")]
        public static extern bool IPCAST_Start_Speech(ref CallAddr from, IntPtr target, int target_number);

        unsafe public static bool Start_Speech(uint from, ref uint[] to, int target_number)
        {
            CallAddr pFrom = new CallAddr();
            pFrom.tid = from;
            pFrom.box_id = 0;

            int structSize = Marshal.SizeOf(typeof(IPCast.CallAddr));
            IntPtr pArray = Marshal.AllocHGlobal((int)new IntPtr(structSize) * target_number);
            CallAddr* pTo = (CallAddr*)pArray.ToPointer();

            for (int i = 0; i < target_number; i++)
            {
                pTo[i].tid = to[i];
                pTo[i].box_id = 0;
            }

            bool bret = IPCAST_Start_Speech(ref pFrom, pArray, target_number);
            Marshal.FreeHGlobal(pArray);
            return bret;
        }

        /*-------------------------------------------------------------------------------------------------
        IPCAST_STOP_SPEECH：控制终端结束寻呼
        函数:	BOOL IPCAST_STOP_SPEECH(ULONG tid);
        参数:	tid:				发起寻呼终端ID 
        返回：	TRUE:	成功， 
                FALSE:	失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_Stop_Speech")]
        public static extern bool IPCAST_Stop_Speech(uint tid);


        [StructLayout(LayoutKind.Sequential)]
        public struct CallAddr
        {
            public uint tid;        // 终端ID
            public int box_id;      // 终端面板号： 0 -- 终端主机；1 ~ 8 - 终端分控面板
        }
        /*-------------------------------------------------------------------------------------------------
        IPCAST_GetSessionList：获取会话列表
        函数:	int IPCAST_GetSessionList(ULONG* pSList, int nSize);
        参数:	pSList:		保存返回会话ID列表的缓冲区，pSList==NULL或者nSize<=0只返回会话数目
		        nSize:		允许返回的会话ID数目
        返回：	会话数目。pSList!=NULL 且 nSize>0 时，相应ID填写到pSList中。
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_GetSessionList")]
        public static extern int GetSessionList(IntPtr pSList, int nSize);

        /*-------------------------------------------------------------------------------------------------
        IPCAST_GetSessionStatus：获取会话状态属性
        函数:	BOOL IPCAST_GetSessionStatus(ULONG sid, LPSessionAttr pSession);
        参数:	sid:		需要查询的会话ID
		        pSession:	返回会话属性的指针
        返回：	TRUE:	成功
		        FALSE:	失败
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_GetSessionStatus")]
        unsafe public static extern bool GetSessionStatus(uint sid, IntPtr pTermEx);
        unsafe public static string GetAllSessions(string[] sessions)
        {
            string SessionSids = "SessionSids:0";
            IntPtr pArray = Marshal.AllocHGlobal(0);
            int count = IPCast.GetSessionList(pArray, 0);
            if (count > 0)
            {
                pArray = Marshal.ReAllocHGlobal(pArray, new IntPtr(count * 4));
                int ret = IPCast.GetSessionList(pArray, count);  //获取会话列表

                if (ret > 0)
                {
                    uint* pSid = (uint*)pArray.ToPointer();
                    for (int i = 0; i < ret; i++)
                    {
                        uint sid = pSid[i];
                        SessionSids += sid.ToString();
                        SessionSids += ",";
                        long size = Marshal.SizeOf(typeof(IPCast.SessionAttr));
                        IntPtr pSessions = Marshal.AllocHGlobal((int)new IntPtr(size));
                        if (IPCast.GetSessionStatus(sid, pSessions))
                        {
                            IPCast.SessionAttr sessionAttr = (IPCast.SessionAttr)Marshal.PtrToStructure(pSessions, typeof(IPCast.SessionAttr));
                            string sinfo = "sid: " + sessionAttr.sid.ToString() + "   name: " + sessionAttr.name + " status: " + sessionAttr.status.ToString() + " type: " + sessionAttr.type.ToString() +
                                " Grade: " + sessionAttr.grade.ToString() + " t_play: " + sessionAttr.t_play.ToString() + " t_total: " + sessionAttr.t_total.ToString() + " iFile: " + sessionAttr.iFile.ToString();
                            sessions[i] = sinfo;
                        }
                        Marshal.FreeHGlobal(pSessions);
                    }
                    Marshal.FreeHGlobal(pArray);
                }

            }

            SessionSids.Trim(',');
            return SessionSids;
        }
        /*----------------------------------------------------------------------
        IPCAST_GetLastError
        函数:	DWORD IPCAST_GetLastError();
        参数:	无
        返回：	错误码
        ------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_GetLastError")]
        public static extern uint IPCAST_GetLastError();


        /// <summary>
        /// 8.10 IP广播终端扩展属性
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct TermAttrEx
        {
            public uint tid;         // 终端ID
            public int status;       // 终端状态：-1-不连通，0-空闲, >0-使用中
            public int work_status;  // 终端工作状态
            public int call_status;  // 终端呼叫状态
            public int a_sid;       // 活动会话ID
            public int vol;          // 音量：0~56，0最小，56最大
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
            public string ipaddr;    // 终端IP地址
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
            public string fwdaddr;   // 中继服务器IP地址
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string name;      // 中继服务器IP地址
        }

        /// <summary>
        /// IP广播会话属性
        /// </summary>
        public struct SessionAttr		// 会话属性
        {
            public uint sid;					// 任务ID
            public int status;					// 任务状态：0-停止, 1-播放, 2-暂停, 4-关闭
            public int type;					// 会话类型：1-终端点播，2-定时任务，3-文件播放
            //			 4-声卡实时采播，5-双向对讲，6-报警触发任务
            public int grade;					// 任务优先级：0~999，999最大
            public int t_play;					// 播放时间（秒）
            public int t_total;				// 总时间（秒，采播任务为0）
            public int iFile;					// 播放文件序号（采播任务为0）
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string name;			// 会话名称
        }

        /*-------------------------------------------------------------------------------------------------
        回调函数指针定义：
        事件回调函数，参数缓冲区不小于MAX_CB_BUF(1024)字节
        EventNo:
        1：服务器状态变化
            ParamStr: state=%d
                      state: 0-无法连接或未启动, 1-正常连接
        2：终端状态变化
            ParamStr: tid=%d, state=%d
                      tid: 终端id
                      state: -1-不连通，0-空闲, >0-使用中
        3：终端IO端口输入状态变化
            ParamStr：tid=%d, %iport%=%d
                      tid: 终端id
                      %iport%: 1~8, 值：0-断开, 1-连通
        4：文件播放会话状态变化
            ParamStr：sid=%d, state=%d, ifile=%d, tplay=%d, ttotal=%d
                      sid: 文件播放会话ID
                      state: 0-停止, 1-播放, 2-暂停, 3-文件末尾, 4-任务关闭
                      ifile: 当前播放文件序号
                      tplay: 当前文件当前播放时间
                      ttotal: 当前文件总时间

        --------------------------------------------------------------------------------------------------*/

        /*-------------------------------------------------------------------------------------------------
        IPCAST_SetCallBack：设置事件回调函数
        函数:	void IPCAST_SetCallBack(IPCastCallBack* pFunc);
        参数:	pFunc:		回调函数指针
        返回:	无
        -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", EntryPoint = "IPCAST_SetCallBack", CharSet = CharSet.Auto)]
        public static extern void IPCAST_SetCallBack(SetCallBack pFunc);

        public delegate void SetCallBack(int eventNo, string paramStr);

        /*-------------------------------------------------------------------------------------------------
            对讲监听回调函数指针定义：
            Length: 数据头 + PCM数据的长度
            pData: 格式： talk id (4Bytes) + master tid (4Bytes) + slave tid (4Bytes) + frame index(4Bytes) + pcm data
            pUserContext: 用户指针
            音频数据格式：采样率为16K，单声道
            -------------------------------------------------------------------------------------------------*/
        [DllImport("IPCast_I.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "IPCAST_SetTalkMonitorCallBack")]
        public static extern bool IPCAST_SetTalkMonitorCallBack(IPCastTalkMonitorCallBack pFunc, object pUserContext);

        // public delegate void IPCastTalkMonitorCallBack(int Length, byte[] pData, object pUserContext);
        unsafe public delegate void IPCastTalkMonitorCallBack(int Length, ref byte pData, ref int pUserContext);
    }
}

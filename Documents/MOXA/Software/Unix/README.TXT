========================================================================
                  MOXA UNIX Fixed TTY Program (moxattyd)

                              README File

  Date: 08-28-2008
  Copyright (C) 2000-2007, MOXA Technologies Co., Ltd. All rights reserved.
========================================================================
Content

1. Introduction
2. Supported Operating Mode
3. OS Supports
4. Installation and Configuration
5. Device Naming Rule
6. Moxattyd Parameter
7. Add Additional Server
8. Technical Support
------------------------------------------------------------------------
1. Introduction
	The purpose of Moxa Fixed TTY program, moxattyd, is to redirect UNIX
	tty device to MOXA NPort/Async Server RS-232 port.

2. Supported Operating Mode
	1. [Fixed TTY] - [RAW]
	2. [Multi-Host TTY] - [FIXTTY]
	   [Device Control] - [RAW]
	3. [Host Based/Driver Mode]
	   [Real COM Mode]
	   [TCP Server Mode]
	
	You may always find and download the latest driver at
	http://www.moxa.com and http://www.moxa.com.tw

3. OS Supports
	Moxattyd program supports the following OS:
	1. SCO UNIX, SCO OpenServer 5, SCO OpenServer 6
	2. UnixWare 7
	3. Solaris 10 x86/Sparc
	4. QNX4.25, QNX6
	5. FreeBSD 5.x, FreeBSD 6, FreeBSD 7, FreeBSD 8
	6. AIX 5.3
	7. Mac OS X

4. Installation and Configuration
	Step 1  :  Login to UNIX and create a directory for MOXA Fixed TTY.
		   E.g., to create a directory named /usr/etc, execute the 
		   command:
		   # mkdir /usr/etc

	Step 2  :  Copy moxattyd.tar to the /usr/etc directory by executing
		   the commands:
		   # cp moxattyd.tar /usr/etc
		   # cd /usr/etc 
	
	Step 3  :  Extract source files from tar-file by executing the 
		   command:
		   # tar xvf moxattyd.tar
                   # cd /usr/etc/moxattyd

		   The following files will be extracted:
		   README.TXT	
		   moxattyd.c  --> source code
		   moxattyd.cf --> an empty configuration file
		   Makefile	   --> makefile
		   VERSION.TXT --> Fixed TTY driver version
		   SUPPORT.TXT --> Fixed TTY support MOXA product and OP_mode
		   FAQ.TXT     --> FAQ

	Step 4  :  Compile and Link :
		   For QNX4:
		 	 # make qnx4
		   
		   For QNX6:
		 	 # make qnx6
		 	 
		   For SCO OpenServer 6
		   	 # make sco6
		    
		   For SCO UNIX, OpenServer 5:
		 	 # make sco
		 	 
		   For Solaris
		 	 # make sun
		     
		   For FreeBSD
			 # make freebsd

		   For FreeBSD8
			 # make freebsd8
             
		   For UnixWare 7:
			 # make svr5
		   
		   For AIX
		     # make aix

		   For HP-Unix 
		     # make hpunix 

	Step 5	:  Modify the configuration:
		   The configuration used by the moxattyd program is defined
		   in the text file moxattyd.cf, which is in the same 
		   directory that contains the program moxattyd. You may use
		   vi, or any text editor to modify the file. E.g.,
      
			 ttyp11 	192.168.1.1	     950	
      
		   For more configuration information, look at the file 
		   moxattyd.cf, which contains detailed descriptions of the 
		   various configuration parameters. (If you would like to 
		   use self-defined master/slave tty, look at the file 
		   user_defined.cf.)

		   !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		   The "Device Name" depends on the OS. See the
		   "5. Device Naming Rule" section for more information.	
		   !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

	Step 6	:  To start the moxattyd daemon, you configured in 
		    moxattyd.cf. If you would like to set the connection 
		    timeout, you can add a "-t min" parameter to specify 
		    the connection timeout value in minute. E.g.,
		    
		    # /usr/etc/moxattyd/moxattyd -t 1
		    
		    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		    Now, you are able to use tty which is configured 
		    in moxattyd.cf if you complete Step 1 to Step 6.  
		    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

	Step 7	:  To start the moxattyd daemon after system bootup,
		   you configured in moxattyd.cf. E.g.,
		   
		   for SCO Openserver, Unixware, AIX and Solaris
		   add an entry into /etc/inittab
			 ts:234:respawn:/usr/etc/moxattyd/moxattyd -t 1
			 
		   For QNX4 add an entry into /etc/config/sysinit.1
		     /usr/etc/moxattyd/moxattyd -t 1
		     
		   For QNX6 add an entry into /etc/rc.d/rc.local
		     /usr/etc/moxattyd/moxattyd -t 1
		     
		   For FreeBSD add an entry into /etc/rc.local
		     /usr/etc/moxattyd/moxattyd -t 1

	This completes the process of adding an additional server.

5. Device Naming Rule
	For UnixWare, Solaris, SCO OpenServer 6 
		pts/[n]
	
	For HP-UX 
		pty/tty[a-ce-z][0-9a-f]
		or
		tty[p-r][0-9a-f]

	For QNX4, QNX6
		tty[p-s][0-9a-f]

	For FreeBSD, FreeBSD 8
		tty[p-sP-S][0-9a-v]
		
	For AIX
		tty[p-zA-Z][0-9a-f]

	For all other UNIX operating systems, use:
		ttyp[n]

	The value of n should be equal or larger than 11 to prevent from
	conflicting with the device names of functional keys in some UNIX
	systems.
	
6. Moxattyd Parameter
	Usage : moxattyd [-t reset-time] [-f file-name] [-x] [-u user_defined.cf]
		reset-time : reconnection successful time.
 		file-name  : Fixed TTY program configuration file. 
 	
 	t :	If you would like to set the connection timeout, you can add 
 		a "-t min" parameter to specify the connection timeout value 
 		in minute. E.g., 
		# moxattyd -t 1
		
	f :	If you would like to every target machines have configuration 
		file themself, you can add a "-f file-name" to specify 
		configuration file. E.g. If one of configuration file is com.cf,
		you can type
		# moxattyd -f com.cf

	x :	Disable log function.
	
	u :	If you would like to use self-defined tty name, you can add a
		"-u user_defined.cf" to use them. E.g.,
		# moxattyd -u user_defined.cf

7. Add Additional Server
	Step 1	:  Modify the text file moxattyd.cf to add an additional server.
		   User may use vi or any text editor to modify the file. For 
		   more configuration information, look at the file moxattyd.cf, 
		   which contains detailed descriptions of the various 
		   configuration parameters.

	Step 2	:  Find the process id (PID) of program "moxattyd".
		   # ps -ef | grep moxattyd

	Step 3	:  Update configuration of moxattyd program.
		   # kill -USR1 PID
		   (e.g., if "moxattyd" PID = 404, "kill -USR1 404")

	This completes the process of adding an additional server.

8. Technical Support
   If you have any technical questions, please send your question by
   the following ways with detail description of the symptom.

    Email: support@moxa.com.tw
    Tel  : +886 2 89191230 ext.300


-End-

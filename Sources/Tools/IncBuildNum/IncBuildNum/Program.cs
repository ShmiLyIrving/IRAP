using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace IncBuildNum
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                #region local variable definitions
                StreamReader file;
                string sLine;
                string sFile = "";
                List<string> fileContent = new List<string>();
                bool isRelease = false;
                bool isBefore = false;
                #endregion

                #region get args[] and test if file exists
                if (args.Length < 3)
                {
                    // there must be the filename
                    ErrHandler("Usage: IncBuildNo [$Path\\AssemblyInfo.cs] [Release] [Before/After]", null);
                    return -2;
                }

                // only "Release" version increment (not debug)
                if (args.Length >= 2)
                    isRelease = args[1].ToUpper() == "RELEASE";

                if (args.Length >= 3)
                    isBefore = args[2].ToUpper() == "BEFORE";

                if (!File.Exists(args[0]))
                {
                    // exists the file?
                    ErrHandler("File '" + args[0] + "' not found", null);
                    return -3;
                }
                #endregion

                #region open and read cs file
                // try to open the file
                try
                {
                    file = new StreamReader(args[0], Encoding.UTF8);
                }
                catch (Exception Ex)
                {
                    ErrHandler("File '" + args[0] + "' not found\nException thrown: ", Ex);
                    return -4;
                }

                try
                {
                    while ((sLine = file.ReadLine()) != null)
                    {
                        fileContent.Add(sLine);
                    }
                }
                catch (Exception Ex)
                {
                    ErrHandler("(Reading File) Exception thrown: ", Ex);
                    return -5;
                }
                file.Close();
                #endregion

                string version = "";
                int intBuildNo = GetNextBuildNo(fileContent, isRelease, ref version);

                if (isBefore)
                {
                    int idx = -1;
                    for (int i = 0; i < fileContent.Count; i++)
                    {
                        if (fileContent[i].Trim().IndexOf("AssemblyFileVersion") == 11)
                        {
                            idx = i;
                            break;
                        }
                    }
                    if (idx >= 0)
                    {
                        fileContent[idx] =
                            string.Format(
                                "[assembly: AssemblyFileVersion(\"{0}.{1}.{2}.{3}\")]",
                                DateTime.Now.Year,
                                DateTime.Now.Month,
                                DateTime.Now.Day,
                                intBuildNo - 1);
                    }
                    else
                        fileContent.Add(
                            string.Format(
                                "[assembly: AssemblyFileVersion(\"{0}.{1}.{2}.{3}\")]",
                                DateTime.Now.Year,
                                DateTime.Now.Month,
                                DateTime.Now.Day,
                                intBuildNo - 1));
                }
                else
                {
                    // go and read all lines
                    int idx = -1;
                    for (int i = 0; i < fileContent.Count; i++)
                    {
                        if (fileContent[i].Trim().IndexOf("AssemblyVersion") == 11)
                        {
                            idx = i;
                            break;
                        }
                    }
                    if (idx >= 0)
                    {
                        fileContent[idx] =
                            string.Format(
                                "[assembly: AssemblyVersion(\"{0}.{1}\")]",
                                version,
                                intBuildNo);
                    }
                    else
                        fileContent.Add(
                            string.Format(
                                "[assembly: AssemblyVersion(\"{0}.{1}\")]",
                                version,
                                intBuildNo));

                    idx = -1;
                    for (int i = 0; i < fileContent.Count; i++)
                    {
                        if (fileContent[i].Trim().IndexOf("AssemblyInformationalVersion") == 11)
                        {
                            idx = i;
                            break;
                        }
                    }
                    if (idx >= 0)
                    {
                        fileContent[idx] =
                            string.Format(
                                "[assembly: AssemblyInformationalVersion(\"{0}.{1}\")]",
                                version,
                                intBuildNo);
                    }
                    else
                        fileContent.Add(
                            string.Format(
                                "[assembly: AssemblyInformationalVersion(\"{0}.{1}\")]",
                                version,
                                intBuildNo));

                    idx = -1;
                    for (int i = 0; i < fileContent.Count; i++)
                    {
                        if (fileContent[i].Trim().IndexOf("AssemblyFileVersion") == 11)
                        {
                            idx = i;
                            break;
                        }
                    }
                    {
                        string[] spVersion = version.Split('.');
                        string versionString =
                            string.Format(
                                "[assembly: AssemblyFileVersion(\"{0}.{1}.{2}.{3}\")]",
                                spVersion[0],
                                spVersion[1],
                                DateTime.Now.ToString("yyyyMMdd"),
                                intBuildNo);
                        if (idx >= 0)
                        {
                            fileContent[idx] = versionString;
                        }
                        else
                        {
                            fileContent.Add(versionString);
                        }
                    }
                }

                #region write cs file back
                for (int i = 0; i < fileContent.Count; i++)
                    sFile += fileContent[i] + "\n";

                try
                {
                    StreamWriter fileW = new StreamWriter(args[0], false, Encoding.UTF8);       // write the file back
                    fileW.Write(sFile.Substring(0, sFile.Length));
                    fileW.Close();
                    return 0;
                }
                catch (Exception Ex)
                {
                    ErrHandler("(Reading File) Exception thrown: ", Ex);
                    return -6;
                }
                #endregion
            }
            catch       // something else went wrong
            {
                return -10;
            }
        }

        private static int GetNextBuildNo(List<string> content, bool isReleased, ref string version)
        {
            int rlt = 0;
            version = "1.0";

            foreach(string sTemp in content)
            {
                if (sTemp.Length > 2 && sTemp.Trim().Substring(0, 2) != "//")
                {
                    int iPos = sTemp.IndexOf("AssemblyVersion");
                    if (iPos > 0)
                    {
                        string[] strSplitter = sTemp.Split('"');
                        if (strSplitter.Length == 3)
                        {
                            strSplitter = strSplitter[1].Replace('*', '0').Split('.');

                            if (strSplitter.Length >= 1)
                                version = strSplitter[0];
                            else
                                version = "1.0.1";

                            if (strSplitter.Length >= 2)
                                version += "." + strSplitter[1];
                            else
                                version += ".0.1";

                            if (strSplitter.Length >= 3)
                            {
                                if (isReleased)
                                    version += "." + ((int.Parse(strSplitter[2])) + 1).ToString();
                                else
                                    version += "." + strSplitter[2];
                            }
                            else
                                version += ".1";

                            if (strSplitter.Length == 4)
                            {
                                rlt = int.Parse(strSplitter[3]);
                                break;
                            }
                        }
                    }
                }
            }

            return ++rlt;
        }

        static private void ErrHandler(string sError, Exception Ex)
        {
            try
            {
                TextWriter errorWriter = Console.Error;
                EventLog evlog = new EventLog("Application", Environment.MachineName, "BuildNoInc");
                errorWriter.WriteLine("(Reading File) Exception throw: " + Ex);
                evlog.WriteEntry("(Reading File) Exception throw: " + Ex.Message, EventLogEntryType.Error);
            }
            catch { }
        }
    }
}

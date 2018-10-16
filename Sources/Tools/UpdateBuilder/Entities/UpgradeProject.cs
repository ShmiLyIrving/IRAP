using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;

using DevExpress.XtraEditors;

using IRAP.Global;

namespace UpdateBuilder
{
    public class UpgradeProject
    {
        private string projectFileName = "新建项目";
        private List<FileInfo> files = new List<FileInfo>();
        private bool isModified = false;
        /// <summary>
        /// 项目文件格式版本号
        /// </summary>
        private string verion;

        /// <summary>
        /// 项目文件名，如果扩展名不是 .upb，则自动加上
        /// </summary>
        public string ProjectFileName
        {
            get { return projectFileName; }
            set
            {
                projectFileName = value;

                if (projectFileName != "新建项目")
                    if (Path.GetExtension(projectFileName).ToUpper() != ".UPB")
                        projectFileName += ".upb";
            }
        }

        public List<FileInfo> Files
        {
            get { return files; }
        }

        /// <summary>
        /// 自从上次保存以来，是否编辑过
        /// </summary>
        public bool IsModified
        {
            get { return isModified; }
        }

        /// <summary>
        /// 在项目中新增更新文件
        /// </summary>
        public void AddFile(string fileName)
        {
            foreach (FileInfo file in files)
            {
                if (file.FileName.ToLower() == fileName.ToLower())
                    return;
            }

            files.Add(new FileInfo()
            {
                FileName = fileName,
            });

            isModified = true;
        }

        public int FileCount()
        {
            return files.Count;
        }

        /// <summary>
        /// 从项目中删除更新文件
        /// </summary>
        public void DeleteFile(FileInfo file)
        {
            files.Remove(file);

            isModified = true;
        }

        private void Save(string fileName)
        {
            string strXML = "";
            foreach (FileInfo file in files)
            {
                strXML =
                    string.Format(
                        "{0}<UpgradeFile name=\"{1}\" version=\"{2}\" " +
                        "md5=\"{3}\" selected=\"{4}\"/>\n",
                        strXML,
                        file.FileName,
                        file.CurrentVersion.ToString(),
                        file.CurrentMD5,
                        file.Selected.ToString());

                file.OldVersion = file.CurrentVersion;
                file.OldMD5 = file.CurrentMD5;
            }
            strXML =
                string.Format(
                    "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" +
                    "<root>\n{0}</root>",
                    strXML);

            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            UTF8Encoding utf8Encoding = new UTF8Encoding();
            fs.Write(utf8Encoding.GetBytes(strXML), 0, utf8Encoding.GetByteCount(strXML));
            fs.Close();

            isModified = false;
        }

        public void Save()
        {
            if (projectFileName == "新建项目")
            {
                string tempFileName = GetProjectFileName();
                if (tempFileName != "")
                    projectFileName = tempFileName;
                else
                    return;
            }

            Save(projectFileName);
        }

        public void SaveAs()
        {
            string tempFileName = GetProjectFileName();
            if (tempFileName != "")
                projectFileName = tempFileName;
            else
                return;

            Save(projectFileName);
        }

        /// <summary>
        /// 获取项目文件名
        /// </summary>
        private string GetProjectFileName()
        {
            SaveFileDialog sDialog = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = "upb",
                Filter = "自动升级配置项目文件(*.upb)|*.upb",
                Title = "保存为...",
            };

            if (sDialog.ShowDialog() == DialogResult.OK)
            {
                return sDialog.FileName;
            }
            else
                return "";
        }

        /// <summary>
        /// 加载项目
        /// </summary>
        /// <param name="fileName">项目文件名</param>
        public void Load(string fileName)
        {
            projectFileName = fileName;

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                XmlReaderSettings xmlSettings = new XmlReaderSettings()
                {
                    ConformanceLevel = ConformanceLevel.Fragment,
                    IgnoreComments = true,
                    IgnoreWhitespace = true,
                };

                using (XmlReader xr = XmlReader.Create(fs, xmlSettings))
                {
                    while (xr.Read())
                    {
                        if (xr.NodeType == XmlNodeType.Element && xr.HasAttributes)
                        {
                            if (xr.Name.ToLower() == "upgradefile")
                            {
                                FileInfo file = new FileInfo()
                                {
                                    FileName = xr.GetAttribute("name"),
                                    OldVersion = new Version(xr.GetAttribute("version")),
                                    OldMD5 = xr.GetAttribute("md5"),
                                    Selected = Convert.ToBoolean(xr.GetAttribute("selected").ToString()),
                                };
                                files.Add(file);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 生成升级配置文件
        /// </summary>
        public void GenerateUpgradeFile(string fileName)
        {
            string strXML = "";
            foreach (FileInfo file in files)
            {
                if (file.Selected)
                {
                    strXML =
                        string.Format(
                            "{0}<File name=\"{1}\" md5=\"{2}\"/>\n",
                            strXML,
                            Path.GetFileName(file.FileName),
                            file.CurrentMD5);
                }
            }
            if (strXML != "")
                strXML =
                    string.Format(
                        "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" +
                        "<root>\n{0}</root>",
                        strXML);

            if (strXML.Trim() == "")
            {
                XtraMessageBox.Show(
                    "升级文件列表中没有内容，或者没有选择文件！",
                    "生成升级配置文件",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                UTF8Encoding utf8Encoding = new UTF8Encoding();
                fs.Write(
                    utf8Encoding.GetBytes(strXML),
                    0,
                    utf8Encoding.GetByteCount(strXML));
                fs.Close();

                XtraMessageBox.Show(
                    string.Format("升级配置文件[{0}]生成完毕！", fileName),
                    "生成升级配置文件",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 测试能否生成升级配置文件
        /// </summary>
        public bool CanGenerateupgradeFile()
        {
            if (files.Count == 0)
                return false;

            int count = 0;
            foreach (FileInfo file in files)
            {
                if (file.Selected)
                    count++;
            }
            return count > 0;
        }

        /// <summary>
        /// 加载项目文件格式版本号 0 的项目
        /// </summary>
        private bool LoadVersion0(string xmlString)
        {
            bool rlt = false;

            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    string.Format(
                        "加载项目文件时出错：[{0}]",
                        error.Message),
                    "出错啦",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                xml = null;
            }

            return rlt;
        }
    }
}
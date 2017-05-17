using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace IRAP_FVS_Kanban
{
    public class KanbanScreen
    {
        public KanbanScreen()
        {
            Detected = false;
        }

        public int ScreenIndex { get; set; }
        public string DeviceName { get; set; }
        public long SysLogID { get; set; }
        /// <summary>
        ///  看板屏幕是否检测到
        /// </summary>
        public bool Detected { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Show { get; set; }
        public Rectangle Bounds { get; set; }

        public override string ToString()
        {
            return DeviceName;
        }
    }

    public class KanbanScreens
    {
        private static KanbanScreens _instance = null;
        private string cfgFileName;
        private List<KanbanScreen> screens = new List<KanbanScreen>();

        public KanbanScreens()
        {
            cfgFileName = string.Format("{0}.xml", Assembly.GetCallingAssembly().Location);

            if (File.Exists(cfgFileName))
            {
                ReadScreenParams(cfgFileName);
            }

            Screen[] sc = Screen.AllScreens;
            bool finded = false;
            for (int i = 0; i < sc.Length; i++)
            {
                finded = false;
                foreach (KanbanScreen screen in screens)
                {
                    if (screen.ToString() == sc[i].DeviceName)
                    {
                        screen.ScreenIndex = i;
                        screen.Detected = true;
                        screen.Bounds = sc[i].Bounds;
                        finded = true;
                        break;
                    }
                }

                if (!finded)
                {
                    KanbanScreen screen = new KanbanScreen()
                    {
                        ScreenIndex = i,
                        DeviceName = sc[i].DeviceName,
                        Detected = true,
                        Bounds = sc[i].Bounds,
                    };
                    screens.Add(screen);
                }
            }
        }

        public static KanbanScreens Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KanbanScreens();
                return _instance;
            }
        }

        public List<KanbanScreen> Screens
        {
            get { return screens; }
        }

        private void ReadScreenParams(string cfgFileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(cfgFileName);
            }
            catch { return; }

            XmlNode nodeScreen = xmlDoc.SelectSingleNode("configuration/screens/screen");
            while (nodeScreen != null)
            {
                KanbanScreen screen = new KanbanScreen();
                screen.DeviceName = nodeScreen.Attributes["DeviceName"].Value;
                try
                {
                    screen.SysLogID = Int64.Parse(nodeScreen.Attributes["SysLogID"].Value);
                }
                catch { screen.SysLogID = 0; }
                try
                {
                    screen.Show = bool.Parse(nodeScreen.Attributes["Showed"].Value);
                }
                catch { screen.Show = false; }
                screens.Add(screen);

                nodeScreen = nodeScreen.NextSibling;
            }
        }

        public void SaveScreenParams()
        {
            FileStream output = new FileStream(cfgFileName, FileMode.Create);
            XmlWriterSettings ws = new XmlWriterSettings()
            {
                Indent = true,
                Encoding = new UTF8Encoding(false),
                NewLineChars = Environment.NewLine,
            };
            using (XmlWriter writer = XmlWriter.Create(output, ws))
            {
                writer.WriteStartDocument(true);
                try
                {
                    writer.WriteStartElement("configuration");
                    try
                    {
                        writer.WriteStartElement("screens");
                        try
                        {
                            foreach (KanbanScreen screen in screens)
                            {
                                if (screen.Detected || screen.Show)
                                {
                                    writer.WriteStartElement("screen");
                                    writer.WriteAttributeString("DeviceName", screen.DeviceName);
                                    writer.WriteAttributeString("SysLogID", screen.SysLogID.ToString());
                                    writer.WriteAttributeString("Showed", screen.Show.ToString());
                                    writer.WriteEndElement();
                                }
                            }
                        }
                        finally
                        {
                            writer.WriteEndElement();
                        }
                    }
                    finally
                    {
                        writer.WriteEndElement();
                    }
                }
                finally
                {
                    writer.WriteEndDocument();
                }
            }

            output.Flush();
            output.Close();
        }
    }
}

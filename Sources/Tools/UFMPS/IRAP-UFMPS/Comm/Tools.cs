using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRAP_UFMPS.Comm
{
    class Tools
    {
        public static string SelectFolder(string description, string initialFolder)
        {
            FolderBrowserDialog dlgFolder = new FolderBrowserDialog();

            dlgFolder.Description = description;
            dlgFolder.SelectedPath = initialFolder;
            dlgFolder.RootFolder = Environment.SpecialFolder.MyComputer;
            dlgFolder.ShowNewFolderButton = false;

            if (dlgFolder.ShowDialog() == DialogResult.OK)
            {
                return dlgFolder.SelectedPath;
            }
            else
            {
                return initialFolder;
            }
        }
    }
}

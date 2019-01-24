using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using IRAP.Global;

namespace IRAP_MaterialRequestImport
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Utils.AppearanceObject.DefaultFont =
                new System.Drawing.Font("新宋体", 10.5f);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            WriteLog.Instance.WriteBeginSplitter("IRAP");
            WriteLog.Instance.Write("IRAP 物料需求导入工具程序启动", "IRAP");

            try
            {
                #region 用户登录
                TIRAPUser.Instance.UserLogin();
                if (TIRAPUser.Instance.IsLogon)
                {
                    frmMain main = null;
                    try
                    {
                        main = new frmMain();
                        main.ShowDialog();
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, "IRAP");
                        XtraMessageBox.Show(
                            error.Message,
                            "出错啦",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (main != null)
                        {
                            main.Dispose();
                        }
                    }

                    if (TIRAPUser.Instance.IsLogon)
                    {
                        try
                        {
                            TIRAPUser.Instance.Logout();
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(
                                $"用户注销时发生错误：{error.Message}",
                                "IRAP");
                        }
                    }
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.Write("IRAP 物料需求导入工具程序关闭", "IRAP");
                WriteLog.Instance.WriteEndSplitter("IRAP");
                WriteLog.Instance.Write("");
            }
        }
    }
}

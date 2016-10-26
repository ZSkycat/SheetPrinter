using System;
using System.Windows.Forms;

namespace SheetPrintTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //加载配置
            GlobalData.LoadConfig();
            GlobalData.LoadTemplateList();

            //Form初始化
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}

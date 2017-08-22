using System;
using System.Windows.Forms;

namespace SheetPrinter
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Core 初始化
            Core.Program.Initialize();

            // Form 初始化
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
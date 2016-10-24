using SheetPrintTool.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

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
            LoadTemplateList();

            //Form初始化
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        static void LoadTemplateList()
        {
            string[] filePaths = Directory.GetFiles($@"{Application.StartupPath}\Template", "*.json");
            foreach(var p in filePaths)
            {
                var json = File.ReadAllText(p);
                var data = JsonConvert.DeserializeObject<TemplateData>(json);
                GlobalData.TemplateList.Add(data);
            }
            GlobalData.TemplateList.Sort();
        }
    }
}

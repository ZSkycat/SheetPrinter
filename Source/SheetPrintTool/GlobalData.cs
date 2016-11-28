using Newtonsoft.Json;
using SheetPrintTool.DataModel;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SheetPrintTool
{
    public static class GlobalData
    {
        //配置参数
        public static int InputModeIndex { get; set; }
        public static Font Font { get; set; }
        public static string templatePath { get; set; }

        public static List<TemplateData> TemplateList { get; set; } = new List<TemplateData>();

        /// <summary>
        /// 加载配置
        /// </summary>
        public static void LoadConfig()
        {
            //!!!
            InputModeIndex = 0;
            Font = new Font(new FontFamily("黑体"), 12f);
            templatePath = $@"{Application.StartupPath}\Template";
        }

        /// <summary>
        /// 加载模版
        /// </summary>
        public static void LoadTemplateList()
        {
            string[] filePaths = Directory.GetFiles(templatePath, "*.json");
            foreach (var i in filePaths)
            {
                var json = File.ReadAllText(i);
                var data = JsonConvert.DeserializeObject<TemplateData>(json);
                TemplateList.Add(data);
            }
            TemplateList.Sort();
        }
    }

    /// <summary>
    /// 数据输入模式
    /// </summary>
    public enum InputMode
    {
        通用编辑模式,
        淘宝物流格式
    }
}

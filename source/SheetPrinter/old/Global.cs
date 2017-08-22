using Newtonsoft.Json;
using SheetPrinter.DataModel;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SheetPrinter
{
    public static class Global
    {
        private const string ConfigPathName = "config";

        public static ConfigData config = new ConfigData();
        public static ConfigData Config { get { return config; } }
        public static List<TemplateData> TemplateList { get; } = new List<TemplateData>();
        public static List<TemplateData> TaskDataList { get; } = new List<TemplateData>();

        public static string TemplatePath { get; set; }
        public static float DpiX { get; set; }
        public static float DpiY { get; set; }

        /// <summary>
        /// 初始化 Global
        /// </summary>
        public static void InitGlobal()
        {
            TemplatePath = $@"{Application.StartupPath}\Template";
            LoadConfig();
            LoadTemplateList();
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        public static void LoadConfig()
        {
            var json = File.ReadAllText(ConfigPathName, Encoding.UTF8);
            config = JsonConvert.DeserializeObject<ConfigData>(json);
        }

        /// <summary>
        /// 加载模版
        /// </summary>
        public static void LoadTemplateList()
        {
            string[] filePaths = Directory.GetFiles(TemplatePath, "*.json");
            foreach (var i in filePaths)
            {
                var json = File.ReadAllText(i, Encoding.UTF8);
                var data = JsonConvert.DeserializeObject<TemplateData>(json);
                TemplateList.Add(data);
            }
            TemplateList.Sort();
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public static void SaveConfig()
        {
            var json = JsonConvert.SerializeObject(Config);
            File.WriteAllText(ConfigPathName, json, Encoding.UTF8);
        }

        public static void AddTask(TemplateData data)
        {
            if(!TaskDataList.Contains(data))
                TaskDataList.Add(data);
        }
    }

    /// <summary>
    /// 数据录入模式
    /// </summary>
    public enum InputMode
    {
        通用编辑模式,
        淘宝中国物流格式
    }

    /// <summary>
    /// 元素标签，标识类型或特殊字段
    /// </summary>
    public enum ElementTag
    {
        // 通用类型
        Text,
        // 特殊类型
        Year = 100,
        Month,
        Day,
        Hour,
        寄件人姓名 = 200,
        寄件人单位,
        寄件人地址,
        寄件人邮编,
        寄件人电话,
        寄件人签名,
        物品名称,
        收件人姓名 = 300,
        收件人单位,
        收件人地址,
        收件人邮编,
        收件人电话,
        收件人目的地,
        // 统一文字，无实际作用
        寄件时间 = 1000
    }
}
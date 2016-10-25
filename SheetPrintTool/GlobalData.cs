using SheetPrintTool.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace SheetPrintTool
{
    public static class GlobalData
    {
        //配置参数
        public static int InputModeIndxe { get; set; }

        public static List<TemplateData> TemplateList { get; set; } = new List<TemplateData>();

        /// <summary>
        /// 加载模版
        /// </summary>
        public static void LoadTemplateList()
        {
            string[] filePaths = Directory.GetFiles($@"{Application.StartupPath}\Template", "*.json");
            foreach (var i in filePaths)
            {
                var json = File.ReadAllText(i);
                var data = JsonConvert.DeserializeObject<TemplateData>(json);
                TemplateList.Add(data);
            }
            TemplateList.Sort();
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        public static void LoadConfig()
        {
            //!!!
            InputModeIndxe = 0;
        }
    }

    /// <summary>
    /// 元素标签，标识类型或特殊字段
    /// </summary>
    public enum ElementTag
    {
        Text,
        寄件人姓名 = 100,
        寄件人单位,
        寄件人邮编,
        寄件人地址,
        寄件人电话,
        寄件人签名,
        收件人姓名 = 200,
        收件人单位,
        收件人邮编,
        收件人地址,
        收件人电话,
        收件人目的地,
        Year = 500,
        Month,
        Day,
        Hour
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

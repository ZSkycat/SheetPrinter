using System.Collections.Generic;
using System.Drawing;

namespace SheetPrinter.Core.Model
{
    /// <summary>
    /// 配置
    /// </summary>
    public class ConfigModel
    {
        /// <summary>
        /// 字体配置
        /// </summary>
        public Font Font { get; set; } = SystemFonts.DefaultFont;

        /// <summary>
        /// 打印机偏移 X，单位cm
        /// </summary>
        public float PrinterOffsetX { get; set; } = 0;

        /// <summary>
        /// 打印机偏移 Y，单位cm
        /// </summary>
        public float PrinterOffsetY { get; set; } = 0;

        /// <summary>
        /// 插件文件列表
        /// </summary>
        public List<string> PluginFileList = new List<string>();

        /// <summary>
        /// 模板填充列表
        /// </summary>
        public List<TemplateFillModel> TemplateFillList = new List<TemplateFillModel>();
    }
}
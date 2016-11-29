using System.Drawing;

namespace SheetPrintTool.DataModel
{
    public class ConfigData
    {
        /// <summary>
        /// 数据录入模式选中索引
        /// </summary>
        public int InputModeIndex { get; set; } = 0;

        /// <summary>
        /// 字体配置
        /// </summary>
        public Font Font { get; set; } = new Font(new FontFamily("黑体"), 12f);
    }
}

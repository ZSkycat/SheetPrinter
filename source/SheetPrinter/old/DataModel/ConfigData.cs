using System.Collections.Generic;
using System.Drawing;

namespace SheetPrinter.DataModel
{
    /// <summary>
    /// 配置数据模型
    /// </summary>
    public class ConfigData
    {
        /// <summary>
        /// 数据录入模式选中索引
        /// </summary>
        public int InputModeIndex { get; set; } = 0;

        /// <summary>
        /// 字体配置
        /// </summary>
        public Font Font { get; set; } = new Font(new FontFamily("黑体"), 12f, FontStyle.Bold);

        /// <summary>
        /// 信息数据
        /// </summary>
        public List<InfoData> InfoList { get; set; } = new List<InfoData>();
    }
}

namespace SheetPrinter.Core.Model
{
    /// <summary>
    /// 元素
    /// </summary>
    public class ElementModel
    {
        /// <summary>
        /// 元素类型
        /// </summary>
        public ElementType Type { get; set; }

        /// <summary>
        /// 元素名称，默认=""
        /// </summary>
        public string Key { get; set; } = "";

        /// <summary>
        /// 元素内容，默认=""
        /// </summary>
        public string Value { get; set; } = "";

        /// <summary>
        /// X 坐标，单位cm
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Y 坐标，单位cm
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// 内容宽度，0=不限制，默认=0
        /// </summary>
        public float Width { get; set; } = 0;

        /// <summary>
        /// 内容高度，0=不限制，默认=0
        /// </summary>
        public float Height { get; set; } = 0;

        /// <summary>
        /// 字体大小，大于0单位是磅，小于0是相对倍数，0=程序配置值，默认=0
        /// </summary>
        public float FontSize { get; set; } = 0;
    }
}
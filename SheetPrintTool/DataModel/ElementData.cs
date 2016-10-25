using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SheetPrintTool.DataModel
{
    public class ElementData
    {
        /// <summary>
        /// X坐标
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y坐标
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 元素类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ElementTag Tag { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace SheetPrintTool.DataModel
{
    /// <summary>
    /// 元素数据模型
    /// </summary>
    [Serializable]
    public class ElementData
    {
        /// <summary>
        /// X坐标
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// Y坐标
        /// </summary>
        public float Y { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// 元素类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ElementTag Tag { get; set; }
        /// <summary>
        /// 元素名称
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 元素内容
        /// </summary>
        public string Value { get; set; }
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
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SheetPrinter.DataModel
{
    /// <summary>
    /// 模板数据模型
    /// </summary>
    [Serializable]
    public class TemplateData : IComparable<TemplateData>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// 打印机偏移 X
        /// </summary>
        public float OffsetX { get; set; } = 0;
        /// <summary>
        /// 打印机偏移 Y
        /// </summary>
        public float OffsetY { get; set; } = 0;
        /// <summary>
        /// 背景图名称
        /// </summary>
        public string BackgroundFileName { get; set; }
        /// <summary>
        /// 元素列表
        /// </summary>
        public List<ElementData> ElementList { get; set; } = new List<ElementData>();

        /// <summary>
        /// 克隆对象
        /// </summary>
        public TemplateData Clone()
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                var obj = formatter.Deserialize(stream);
                return (TemplateData)obj;
            }
        }

        public int CompareTo(TemplateData other)
        {
            return string.Compare(this.Name, other.Name, false);
        }
    }
}

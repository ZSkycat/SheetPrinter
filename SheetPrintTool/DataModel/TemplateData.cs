using System;
using System.Collections.Generic;

namespace SheetPrintTool.DataModel
{
    public class TemplateData : IComparable<TemplateData>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 背景图路径
        /// </summary>
        public string BackgroundFileName { get; set; }
        public List<ElementData> KeyValueList { get; set; }

        public int CompareTo(TemplateData other)
        {
            return string.Compare(this.Name, other.Name, false);
        }
    }
}

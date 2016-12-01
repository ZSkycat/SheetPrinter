using System;
using System.Collections.Generic;

namespace SheetPrintTool.DataModel
{
    /// <summary>
    /// 信息数据模型
    /// </summary>
    public class InfoData : IComparable<InfoData>
    {
        /// <summary>
        /// 信息名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 元素数据字典
        /// </summary>
        public Dictionary<ElementTag, string> ElementData { get; set; } = new Dictionary<ElementTag, string>();

        public int CompareTo(InfoData other)
        {
            return string.Compare(this.Name, other.Name, false);
        }
    }
}

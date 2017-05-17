using System;
using System.Collections.Generic;

namespace SheetPrinter.Core.Model
{
    /// <summary>
    /// 模板填充
    /// </summary>
    public class TemplateFillModel : IComparable<TemplateFillModel>
    {
        /// <summary>
        /// 填充名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 元素数据
        /// </summary>
        public Dictionary<ElementType, string> ElementData { get; set; } = new Dictionary<ElementType, string>();

        public int CompareTo(TemplateFillModel other)
        {
            return string.Compare(Name, other.Name, true);
        }
    }
}

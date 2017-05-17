using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SheetPrinter.Core.Model
{
    /// <summary>
    /// 模板
    /// </summary>
    public class TemplateModel : IComparable<TemplateModel>
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 宽度，单位cm
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// 高度，单位cm
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// 背景图文件名称，""=不显示，默认=""
        /// </summary>
        public string BackgroundFileName { get; set; } = "";

        /// <summary>
        /// 元素列表
        /// </summary>
        public List<ElementModel> ElementList { get; set; } = new List<ElementModel>();

        /// <summary>
        /// 克隆新实例
        /// </summary>
        public TemplateModel Clone()
        {
            var json = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<TemplateModel>(json);
        }

        public int CompareTo(TemplateModel other)
        {
            return string.Compare(Name, other.Name, true);
        }
    }
}
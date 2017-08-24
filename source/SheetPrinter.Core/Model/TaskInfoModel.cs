using System;

namespace SheetPrinter.Core.Model
{
    /// <summary>
    /// 任务队列
    /// </summary>
    public class TaskInfoModel
    {
        /// <summary>
        /// 任务 ID
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// 模板数据
        /// </summary>
        public TemplateModel Data { get; set; }

        /// <summary>
        /// 插件自定义数据
        /// </summary>
        public object PluginData { get; set; }
    }
}
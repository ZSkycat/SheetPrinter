using System;

namespace SheetPrinter.Core.Model
{
    /// <summary>
    /// 插件模式信息
    /// </summary>
    public class ModeInfoModel
    {
        /// <summary>
        /// 模式名称
        /// </summary>
        public string ModeName { get; set; }

        /// <summary>
        /// 模式类型
        /// </summary>
        public Type ModeType { get; set; }
    }
}
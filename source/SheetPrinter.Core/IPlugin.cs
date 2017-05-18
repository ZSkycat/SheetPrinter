using System;

namespace SheetPrinter.Core
{
    /// <summary>
    /// 定义插件的主入口
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 插件基本信息
        /// </summary>
        string PluginInfo { get; }

        /// <summary>
        /// 模式名称列表
        /// </summary>
        string[] ModeNameList { get; }

        /// <summary>
        /// 类型列表，与模式名称列表按顺序对应
        /// </summary>
        Type[] ModeTypeList { get; }

        /// <summary>
        /// 插件的主入口
        /// </summary>
        void Main();
    }
}
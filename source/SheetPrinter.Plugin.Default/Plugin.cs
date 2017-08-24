using SheetPrinter.Core;
using System;

namespace SheetPrinter.Plugin.Default
{
    public class Plugin : IPlugin
    {
        public string PluginInfo { get; } = "默认插件";

        public string[] ModeNameList { get; } = { "通用编辑", "淘宝地址格式" };

        public Type[] ModeTypeList { get; } = { typeof(ModeCommon), typeof(ModeTaobao) };
    }
}
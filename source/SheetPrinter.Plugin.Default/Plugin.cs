using SheetPrinter.Core;
using System;

namespace SheetPrinter.Plugin.Default
{
    public class Plugin : IPlugin
    {
        public string PluginInfo { get; } = "";

        public string[] ModeNameList { get; } = { "通用编辑", "淘宝物流格式" };

        public Type[] ModeTypeList { get; } = { };

        public void Main()
        {
        }
    }
}
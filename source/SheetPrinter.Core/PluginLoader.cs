using SheetPrinter.Core.Model;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SheetPrinter.Core
{
    /// <summary>
    /// 插件加载器
    /// </summary>
    public static class PluginLoader
    {
        /// <summary>
        /// 插件信息字典
        /// </summary>
        public static Dictionary<string, string> PluginInfoList { get; } = new Dictionary<string, string>();

        /// <summary>
        /// 插件模式信息列表
        /// </summary>
        public static List<ModeInfoModel> ModeList { get; } = new List<ModeInfoModel>();

        /// <summary>
        /// 加载插件
        /// </summary>
        /// <param name="pluginFile">插件文件</param>
        /// <returns>成功=true，失败=false</returns>
        public static bool LoadPlugin(string pluginFile)
        {
            var assembly = Assembly.LoadFrom($@"{Program.PluginPath}\{pluginFile}");
            foreach (var t in assembly.GetTypes())
            {
                if (t.GetInterface(nameof(IPlugin)) != null)
                {
                    IPlugin plugin = (IPlugin)Activator.CreateInstance(t);
                    plugin.Main();
                    PluginInfoList.Add(pluginFile, plugin.PluginInfo);
                    for (var i = 0; i < plugin.ModeNameList.Length; i++)
                    {
                        ModeList.Add(new ModeInfoModel()
                        {
                            ModeName = plugin.ModeNameList[i],
                            ModeType = plugin.ModeTypeList[i],
                        });
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 创建指定模式对象
        /// </summary>
        /// <param name="model">插件模式信息</param>
        /// <returns>成功=IMode，失败=null</returns>
        public static IMode CreateMode(ModeInfoModel model)
        {
            try
            {
                return (IMode)Activator.CreateInstance(model.ModeType);
            }
            catch
            {
                return null;
            }
        }
    }
}
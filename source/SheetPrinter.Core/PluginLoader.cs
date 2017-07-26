using SheetPrinter.Core.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace SheetPrinter.Core
{
    /// <summary>
    /// 插件加载器
    /// </summary>
    public static class PluginLoader
    {
        /// <summary>
        /// 插件列表
        /// </summary>
        public static List<IPlugin> PluginList { get; } = new List<IPlugin>();

        /// <summary>
        /// 模式列表
        /// </summary>
        public static List<ModeInfoModel> ModeList { get; } = new List<ModeInfoModel>();

        /// <summary>
        /// 加载插件
        /// </summary>
        /// <param name="pluginFile">插件文件名</param>
        /// <returns>成功=true，失败=false</returns>
        public static bool LoadPlugin(string pluginFile)
        {
            var assembly = Assembly.LoadFrom($@"{Program.PluginPath}\{pluginFile}");

            foreach (var type in assembly.GetExportedTypes())
            {
                if (type.GetInterfaces().Contains(typeof(IPlugin)))
                {
                    IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                    PluginList.Add(plugin);
                    for (var i = 0; i < plugin.ModeTypeList.Length; i++)
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
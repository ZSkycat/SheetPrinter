﻿using Newtonsoft.Json;
using SheetPrinter.Core.Model;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SheetPrinter.Core
{
    /// <summary>
    /// 程序基础和初始化
    /// </summary>
    public static class Program
    {
        public const string Text_Time = "寄件时间";

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static string ConfigPath { get => _configPath; }
        private static string _configPath;
        /// <summary>
        /// 模板目录路径
        /// </summary>
        public static string TemplatePath { get => _templatePath; }
        private static string _templatePath;
        /// <summary>
        /// 插件目录路径
        /// </summary>
        public static string PluginPath { get => _pluginPath; }
        private static string _pluginPath;
        /// <summary>
        /// 配置数据
        /// </summary>
        public static ConfigModel Config { get => _config; }
        private static ConfigModel _config;

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialize()
        {
            _configPath = $@"{Environment.CurrentDirectory}\core.config";
            _templatePath = $@"{Environment.CurrentDirectory}\template";
            _pluginPath = $@"{Environment.CurrentDirectory}\plugin";
            LoadConfig();
            LoadPluginFromPath();
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        public static void LoadConfig()
        {
            try
            {
                var json = File.ReadAllText(ConfigPath, Encoding.UTF8);
                _config = JsonConvert.DeserializeObject<ConfigModel>(json);
            }
            catch
            {
                _config = new ConfigModel();
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public static void SaveConfig()
        {
            var json = JsonConvert.SerializeObject(Config);
            File.WriteAllText(ConfigPath, json, Encoding.UTF8);
        }

        /// <summary>
        /// 加载插件目录的插件
        /// </summary>
        public static void LoadPluginFromPath()
        {
            DirectoryInfo dire = Directory.CreateDirectory(PluginPath);
            string[] files = dire.GetFiles("*.dll").Select(i => i.Name).ToArray();
            foreach (var i in files)
            {
                PluginLoader.LoadPlugin(i);
            }
        }
    }
}
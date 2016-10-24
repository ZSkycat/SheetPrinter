/**2016.09.22 10:48
 * @author ZSkycat
 * 
 * Refresh(): ConfigurationManager.RefreshSection(string sectionName)
 * 作用：下次获取时从配置文件中读取，而不是使用缓存。主要是影响到 非被修改的对象的获取
 */

using System;
using System.Collections.Specialized;
using System.Configuration;

namespace ZSkycat.AppSettingsHelper
{
    /// <summary>
    /// 控制全局 APP.config 中的 AppSettings 的封装类
    /// </summary>
    public class AppSettingsHelper
    {
        AppSettingsControlMode mode;
        NameValueCollection collectionOnlyRead;
        KeyValueConfigurationCollection collection;
        Configuration config;

        /// <summary>
        /// 实例化 AppSettingsHelper，指定使用模式
        /// </summary>
        /// <param name="mode">默认是 AutoReadWrite 模式</param>
        public AppSettingsHelper(AppSettingsControlMode mode = AppSettingsControlMode.AutoReadWrite)
        {
            switch (mode)
            {
                case AppSettingsControlMode.OnlyRead:
                    collectionOnlyRead = ConfigurationManager.AppSettings;
                    break;

                case AppSettingsControlMode.ReadWrite:
                    goto case AppSettingsControlMode.AutoReadWrite;

                case AppSettingsControlMode.AutoReadWrite:
                    config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    collection = config.AppSettings.Settings;
                    break;

                default:
                    throw ExceptionModeNotExist();
            }
            this.mode = mode;
        }

        #region 属性
        /// <summary>
        /// 获取 key/value 对的数目
        /// </summary>
        public int Count
        {
            get
            {
                switch (mode)
                {
                    case AppSettingsControlMode.OnlyRead:
                        return collectionOnlyRead.Count;

                    case AppSettingsControlMode.ReadWrite:
                        goto case AppSettingsControlMode.AutoReadWrite;

                    case AppSettingsControlMode.AutoReadWrite:
                        return collection.Count;

                    default:
                        throw ExceptionModeNotExist();
                }
            }
        }

        /// <summary>
        /// 获取所有的 key
        /// </summary>
        public string[] AllKeys
        {
            get
            {
                if (mode == AppSettingsControlMode.OnlyRead)
                    return collectionOnlyRead.AllKeys;
                else
                    return collection.AllKeys;
            }
        }

        /// <summary>
        /// 获取原始数据集合 (只读模式)
        /// </summary>
        public NameValueCollection CollectionOnlyRead
        {
            get
            {
                if (mode == AppSettingsControlMode.OnlyRead)
                    return collectionOnlyRead;
                else
                    throw ExceptionReadWrite();
            }
        }

        /// <summary>
        /// 获取原始数据集合 (读写模式)
        /// </summary>
        public KeyValueConfigurationCollection Collection
        {
            get
            {
                if (mode == AppSettingsControlMode.OnlyRead)
                    throw ExceptionOnlyRead();
                else
                    return collection;

            }
        }
        #endregion

        #region 索引器
        /// <summary>
        /// 获取或设置指定 key 的值
        /// </summary>
        public string this[string key]
        {
            get { return GetValue(key); }
            set { SetValue(key, value); }
        }
        #endregion

        #region 操作方法
        /// <summary>
        /// 获取指定 key 的值，如果 key 不存在则返回 null
        /// </summary>
        public string GetValue(string key)
        {
            switch (mode)
            {
                case AppSettingsControlMode.OnlyRead:
                    return collectionOnlyRead[key];

                case AppSettingsControlMode.ReadWrite:
                    goto case AppSettingsControlMode.AutoReadWrite;

                case AppSettingsControlMode.AutoReadWrite:
                    var temp = collection[key];
                    return temp == null ? null : temp.Value;

                default:
                    throw ExceptionModeNotExist();
            }
        }

        /// <summary>
        /// 获取指定 key 的值，并指定如果不存在时返回的默认值 (不会影响到原数据)
        /// </summary>
        public string GetValue(string key, string defaule)
        {
            string temp = GetValue(key);
            return temp == null ? defaule : temp;
        }

        /// <summary>
        /// 设置指定 key 的值, 如果 key 不存在则创建新的项，如果 value 为 null 则删除指定的项
        /// </summary>
        public void SetValue(string key, string value)
        {
            switch (mode)
            {
                case AppSettingsControlMode.OnlyRead:
                    throw ExceptionOnlyRead();
                case AppSettingsControlMode.ReadWrite:
                    HandleSetValue(key, value);
                    break;
                case AppSettingsControlMode.AutoReadWrite:
                    HandleSetValue(key, value);
                    Save();
                    Refresh();
                    break;
            }
        }

        /// <summary>
        /// 删除指定 key 的项
        /// </summary>
        public void RemoveValue(string key)
        {
            switch (mode)
            {
                case AppSettingsControlMode.OnlyRead:
                    throw ExceptionOnlyRead();
                case AppSettingsControlMode.ReadWrite:
                    collection.Remove(key);
                    break;
                case AppSettingsControlMode.AutoReadWrite:
                    collection.Remove(key);
                    Save();
                    Refresh();
                    break;
            }
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            switch (mode)
            {
                case AppSettingsControlMode.OnlyRead:
                    throw ExceptionOnlyRead();
                case AppSettingsControlMode.ReadWrite:
                    collection.Clear();
                    break;
                case AppSettingsControlMode.AutoReadWrite:
                    collection.Clear();
                    Save();
                    Refresh();
                    break;
            }
        }

        /// <summary>
        /// 保存到全局配置文件
        /// </summary>
        public void Save()
        {
            switch (mode)
            {
                case AppSettingsControlMode.OnlyRead:
                    throw ExceptionOnlyRead();

                case AppSettingsControlMode.ReadWrite:
                    goto case AppSettingsControlMode.AutoReadWrite;

                case AppSettingsControlMode.AutoReadWrite:
                    config.Save();
                    break;
            }
        }

        /// <summary>
        /// 刷新 AppSettings 节点
        /// </summary>
        public void Refresh()
        {
            ConfigurationManager.RefreshSection("AppSettings");
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 处理器（设置指定 key 的值），实现当 key 不存在则创建新的项，当 value 为 null 则删除指定的项
        /// </summary>
        private void HandleSetValue(string key, string value)
        {
            var temp = collection[key];
            if (value == null)  //Remove
            {
                RemoveValue(key);
            }
            else  //Set
            {
                if (temp == null)
                    collection.Add(key, value);
                else
                    temp.Value = value;
            }
        }

        /// <summary>
        /// 创建异常
        /// </summary>
        private ArgumentException ExceptionModeNotExist()
        {
            return new ArgumentException("不存在指定的 AppSettingsControlMode", nameof(mode));
        }

        /// <summary>
        /// 创建异常
        /// </summary>
        private NotSupportedException ExceptionOnlyRead()
        {
            return new NotSupportedException("该对象是只读模式");
        }

        /// <summary>
        /// 创建异常
        /// </summary>
        private NotSupportedException ExceptionReadWrite()
        {
            return new NotSupportedException("该对象是读写模式");
        }
        #endregion
    }

    #region 枚举
    /// <summary>
    /// 表示 AppSettingsControl 的使用模式
    /// </summary>
    public enum AppSettingsControlMode
    {
        /// <summary>
        /// 只读模式
        /// </summary>
        OnlyRead,
        /// <summary>
        /// 读写模式：需要手动 Save 和 Refresh
        /// </summary>
        ReadWrite,
        /// <summary>
        /// 自动读写模式：每当修改时会自动调用 Save 和 Refresh
        /// </summary>
        AutoReadWrite,
    }
    #endregion
}
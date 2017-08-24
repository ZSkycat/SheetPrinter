using SheetPrinter.Core.Model;
using System;
using System.Collections.Generic;

namespace SheetPrinter.Core
{
    /// <summary>
    /// 任务控制器
    /// </summary>
    public static class TaskController
    {
        /// <summary>
        /// 任务队列数据列表
        /// </summary>
        public static List<TaskInfoModel> TaskList { get; } = new List<TaskInfoModel>();

        /// <summary>
        /// 添加新任务到队列
        /// </summary>
        /// <param name="data">模板数据</param>
        /// <param name="pluginData">插件自定义数据</param>
        /// <returns>返回创建的任务</returns>
        public static TaskInfoModel Add(TemplateModel data, object pluginData = null)
        {
            TaskInfoModel model = new TaskInfoModel()
            {
                Data = data.Clone(),
                PluginData = pluginData,
            };
            TaskList.Add(model);
            return model;
        }

        /// <summary>
        /// 从任务队列中删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true=删除成功，false=删除失败</returns>
        public static bool Delete(Guid id)
        {
            var temp = TaskList.Find(i => i.Id == id);
            if (temp == null)
                return false;
            else
                return TaskList.Remove(temp);
        }

        /// <summary>
        /// 从任务队列中删除
        /// </summary>
        /// <param name="data"></param>
        /// <returns>true=删除成功，false=删除失败</returns>
        public static bool Delete(TaskInfoModel data)
        {
            if (TaskList.Remove(data))
                return true;
            else
                return Delete(data.Id);
        }

        /// <summary>
        /// 从任务队列中删除
        /// </summary>
        /// <param name="index">任务队列中的索引</param>
        /// <returns>true=删除成功，false=删除失败</returns>
        public static bool Delete(int index)
        {
            if (index >= 0 && index < TaskList.Count)
            {
                TaskList.RemoveAt(index);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 清空任务队列
        /// </summary>
        public static void Clear()
        {
            TaskList.Clear();
        }
    }
}
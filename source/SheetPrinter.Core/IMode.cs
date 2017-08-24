using SheetPrinter.Core.Model;

namespace SheetPrinter.Core
{
    /// <summary>
    /// 定义插件模式的入口
    /// </summary>
    public interface IMode
    {
        /// <summary>
        /// 新建入口
        /// </summary>
        /// <param name="data">模板数据</param>
        void RunNew(TemplateModel model);

        /// <summary>
        /// 编辑入口
        /// </summary>
        /// <param name="data">任务数据</param>
        void RunEdit(TaskInfoModel model);
    }
}
using SheetPrinter.Core.Model;

namespace SheetPrinter.Core
{
    public interface IMode
    {
        /// <summary>
        /// 新建入口
        /// </summary>
        /// <param name="data">模板数据</param>
        void RunNew(TemplateModel data);

        /// <summary>
        /// 编辑入口
        /// </summary>
        /// <param name="data">任务数据</param>
        void RunEdit(TaskInfoModel data);
    }
}
using SheetPrinter.Core.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using static SheetPrinter.Core.UnitConvert;

namespace SheetPrinter.Core
{
    /// <summary>
    /// 打印控制器
    /// </summary>
    public class PrintController
    {
        private TemplateModel[] dataList;
        private int dataListIndex;

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="data">模板数据</param>
        public PrintController(TemplateModel data)
        {
            dataList = new TemplateModel[] { data };
        }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="data">任务队列数据</param>
        public PrintController(List<TaskInfoModel> data)
        {
            dataList = new TemplateModel[data.Count];
            var index = 0;
            data.ForEach(model =>
            {
                dataList[index] = model.Data;
                index++;
            });
        }

        /// <summary>
        /// 开始打印
        /// </summary>
        public void Print()
        {
            var document = new PrintDocument();
            document.PrintPage += Document_PrintPage;
            var dialog = new PrintDialog()
            {
                UseEXDialog = true,
                AllowPrintToFile = false,
                ShowNetwork = false,
                Document = document
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                for (dataListIndex = 0; dataListIndex < dataList.Length; dataListIndex++)
                {
                    var data = dataList[dataListIndex];
                    document.DefaultPageSettings.PaperSize = new PaperSize("Custom", CmToPrint_int(data.Width), CmToPrint_int(data.Height));
                    document.Print();
                }
            }
        }

        /// <summary>
        /// 绘制事件
        /// </summary>
        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            var data = dataList[dataListIndex];
            e.Graphics.PageUnit = GraphicsUnit.Display;
            foreach (var i in data.ElementList)
            {
                var font = CalcFont(ProgramData.Config.Font, i.FontSize);
                e.Graphics.DrawString(i.Value, font, Brushes.Black, new RectangleF(CmToPrint(i.X + ProgramData.Config.PrinterOffsetX), CmToPrint(i.Y + ProgramData.Config.PrinterOffsetY), CmToPrint(i.Width), CmToPrint(i.Height)));
            }
        }

        /// <summary>
        /// 根据 FontSize 计算生成新的字体
        /// </summary>
        /// <param name="font">字体原型</param>
        /// <param name="fontSize">字体大小，大于0单位是磅，小于0是相对倍数，0=程序配置值</param>
        public static Font CalcFont(Font font, float fontSize)
        {
            if (fontSize == 0)
            {
                return font;
            }
            else if (fontSize > 0)
            {
                return new Font(font.FontFamily, fontSize, font.Style, GraphicsUnit.Point);
            }
            else // if (fontSize < 0)
            {
                float size = -1 * fontSize * font.SizeInPoints;
                return new Font(font.FontFamily, size, font.Style, GraphicsUnit.Point);
            }
        }
    }
}
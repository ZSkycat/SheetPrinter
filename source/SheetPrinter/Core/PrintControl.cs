using SheetPrinter.DataModel;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using static SheetPrinter.Core.UnitlHelper;

namespace SheetPrinter.Core
{
    /// <summary>
    /// 打印预览控制器
    /// </summary>
    public class PrintControl
    {
        private List<TemplateData> dataList;
        // 预览功能数据
        private Image image;
        private Panel previewContainer;
        private Panel preview;
        private int previewIndex;
        // 打印功能数据
        private int printIndex;

        /// <summary>
        /// 实例化打印预览控制器
        /// </summary>
        /// <param name="data">模版数据</param>
        public PrintControl(TemplateData data)
        {
            dataList = new List<TemplateData>();
            dataList.Add(data);
        }
        /// <summary>
        /// 实例化打印预览控制器
        /// </summary>
        /// <param name="datalist">模版数据列表</param>
        public PrintControl(List<TemplateData> datalist)
        {
            dataList = datalist;
        }

        #region 预览功能
        /// <summary>
        /// 初始化预览面板
        /// </summary>
        /// <param name="container">Panel 容器</param>
        /// <param name="index">数据索引</param>
        public void InitPreview(Panel container, int index = 0)
        {
            previewContainer = container;
            previewIndex = index;
            var data = dataList[previewIndex];
            try
            {
                image = Image.FromFile($@"{Global.TemplatePath}\{data.BackgroundFileName}");
            }
            catch { }
            preview = new Panel()
            {
                Width = MmToPx(data.Width, Global.DpiX),
                Height = MmToPx(data.Height, Global.DpiY)
            };
            preview.Paint += (sender, e) => { DrawPreview(e.Graphics); };
            previewContainer.AutoScroll = true;
            previewContainer.Controls.Add(preview);
        }

        public void SetPreview(int index)
        {
            previewIndex = index;
            var data = dataList[previewIndex];
            preview.Width = MmToPx(data.Width, Global.DpiX);
            preview.Height = MmToPx(data.Height, Global.DpiY);
        }

        /// <summary>
        /// 刷新预览图
        /// </summary>
        public void RefreshPreview()
        {
            DrawPreview(preview.CreateGraphics());
        }

        /// <summary>
        /// 绘制预览图
        /// </summary>
        /// <param name="g">要绘制的 Graphics 对象</param>
        private void DrawPreview(Graphics g)
        {
            System.Console.WriteLine("DrawPreview");
            var data = dataList[previewIndex];
            try
            {
                g.DrawImage(image, new RectangleF(0f, 0f, MmToPx_f(data.Width, Global.DpiX), MmToPx_f(data.Height, Global.DpiY)), new RectangleF(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            catch { }
            foreach (var i in data.ElementList)
            {
                g.DrawString(i.Value, Global.Config.Font, Brushes.Black, new RectangleF(MmToPx_f(i.X, Global.DpiX), MmToPx_f(i.Y, Global.DpiY), MmToPx_f(i.Width, Global.DpiX), MmToPx_f(i.Height, Global.DpiY)));
            }
        }
        #endregion

        #region 打印功能
        /// <summary>
        /// 打印，指定数据索引，小于0则打印全部
        /// </summary>
        /// <param name="owner">所有者窗体</param>
        /// <param name="index">数据索引，小于0表示全部</param>
        public void Print(int index = 0)
        {
            printIndex = index;
            var document = new PrintDocument();
            document.PrintPage += Document_PrintPage;
            var dialog = new PrintDialog()
            {
                UseEXDialog = true,
                AllowPrintToFile = false,
                ShowNetwork = false,
                Document = document
            };
            // 打印设置和开始打印
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (printIndex < 0)
                {
                    for (var i = 0; i < dataList.Count; i++)
                    {
                        printIndex = i;
                        var data = dataList[printIndex];
                        document.DefaultPageSettings.PaperSize = new PaperSize("Custom", MmToPrinterUnit(data.Width), MmToPrinterUnit(data.Height));
                        document.Print();
                    }
                }
                else
                {
                    var data = dataList[printIndex];
                    document.DefaultPageSettings.PaperSize = new PaperSize("Custom", MmToPrinterUnit(data.Width), MmToPrinterUnit(data.Height));
                    document.Print();
                }
            }
        }

        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            var data = dataList[printIndex];
            e.Graphics.PageUnit = GraphicsUnit.Display;
            foreach (var i in data.ElementList)
            {
                e.Graphics.DrawString(i.Value, Global.Config.Font, Brushes.Black, new RectangleF(MmToPrinterUnit_f(i.X + data.OffsetX), MmToPrinterUnit_f(i.Y + data.OffsetY), MmToPrinterUnit_f(i.Width), MmToPrinterUnit_f(i.Height)));
            }
        }
        #endregion
    }
}

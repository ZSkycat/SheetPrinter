using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SheetPrintTool.DataModel;
using System.Drawing;
using System.Windows.Forms;

namespace SheetPrintTool.Core
{
    public class PrintControl
    {
        TemplateData data;
        Image image;

        Panel previewContainer;
        Panel preview;

        /// <summary>
        /// 实例化打印控制器
        /// </summary>
        /// <param name="data">模版数据</param>
        public PrintControl(TemplateData data)
        {
            this.data = data;
            //!!!
            image = Image.FromFile($@"{GlobalData.templatePath}\{data.BackgroundFileName}");
        }

        /// <summary>
        /// 初始化预览面板
        /// </summary>
        /// <param name="container">Panel 容器</param>
        public void InitPreview(Panel container)
        {
            container.AutoScroll = true;
            previewContainer = container;
            preview = new Panel()
            {
                Width = Convert.ToInt32(UnitlHelper.MmToPxAtDpi(data.Width, 96)),
                Height = Convert.ToInt32(UnitlHelper.MmToPxAtDpi(data.Height, 96))
            };
            previewContainer.Controls.Add(preview);
            preview.Paint += (sender, e) => { Preview(e.Graphics); };
        }

        /// <summary>
        /// 生成预览图
        /// </summary>
        /// <param name="g">要绘制的 Graphics 对象</param>
        public void Preview(Graphics g)
        {
            g.DrawImage(image, new RectangleF(0f, 0f, UnitlHelper.MmToPxAtDpi(data.Width, 96), UnitlHelper.MmToPxAtDpi(data.Height, 96)), new RectangleF(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            foreach (var i in data.ElementList)
            {
                g.DrawString(i.Value, GlobalData.Font, Brushes.Black, new RectangleF(UnitlHelper.MmToPxAtDpi(i.X, 96), UnitlHelper.MmToPxAtDpi(i.Y, 96), UnitlHelper.MmToPxAtDpi(i.Width, 96), UnitlHelper.MmToPxAtDpi(i.Height, 96)));
            }
        }

        /// <summary>
        /// 刷新预览图
        /// </summary>
        public void RefreshPreview()
        {
            Preview(preview.CreateGraphics());
        }
    }
}

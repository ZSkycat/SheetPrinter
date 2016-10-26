using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SheetPrintTool.DataModel;
using System.Drawing;

namespace SheetPrintTool.Core
{
    public class PrintControl
    {
        Image image;
        float imageWidth;
        float imageHeight;

        public PrintControl(TemplateData data)
        {
            //!!!
            image = Image.FromFile($@"{GlobalData.templatePath}\{data.BackgroundFileName}");
            imageWidth = data.Width;
            imageHeight = data.Height;
        }

        /// <summary>
        /// 生成预览图
        /// </summary>
        /// <param name="g">要绘制的 Graphics 对象</param>
        /// <param name="data">模版信息数据</param>
        public void Preview(Graphics g, TemplateData data)
        {
            g.DrawImage(image, new RectangleF(0, 0, imageWidth, imageHeight));
            foreach (var i in data.ElementList)
            {
                g.DrawString(i.Value, GlobalData.Font, Brushes.Black, new RectangleF(i.X, i.Y, i.Width, i.Height));
            }
        }
    }
}

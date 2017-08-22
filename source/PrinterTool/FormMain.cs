using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PrinterHelper
{
    public partial class FormMain : Form
    {
        private static readonly Font PrintFont = new Font(new FontFamily("黑体"), 10f);
        private static readonly Pen PrintPen = Pens.Black;
        private static readonly Brush PrintBrush = Brushes.Black;

        public FormMain()
        {
            InitializeComponent();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (!CheckPrintOption(btn.Name))
            {
                return;
            }
            switch (btn.Name)
            {
                case "bScalePrint":
                    Print(ScaleDocument_PrintPage);
                    break;
                case "bGridPrint":
                    Print(GridDocument_PrintPage);
                    break;
            }
        }

        /// <summary>
        /// 校验打印参数
        /// </summary>
        /// <param name="buttonName">按钮名称</param>
        private bool CheckPrintOption(string buttonName)
        {
            string tipName = "null";
            try
            {
                tipName = "宽度";
                Convert.ToSingle(tbWidth.Text);
                tipName = "高度";
                Convert.ToSingle(tbHeight.Text);
                switch (buttonName)
                {
                    case "bScalePrint":
                        tipName = "刻度间距";
                        Convert.ToSingle(tbScaleSize.Text);
                        tipName = "刻度线长度";
                        Convert.ToSingle(tbScaleLength.Text);
                        break;
                    case "bGridPrint":
                        tipName = "网格间距";
                        Convert.ToSingle(tbGridSize.Text);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{tipName}: {ex.Message}", "参数错误");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="handler">绘制事件</param>
        private void Print(PrintPageEventHandler handler)
        {
            var document = new PrintDocument();
            document.PrintPage += handler;
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
                float printWidth = Convert.ToSingle(tbWidth.Text);
                float printHeight = Convert.ToSingle(tbHeight.Text);
                document.DefaultPageSettings.PaperSize = new PaperSize("Custom", CmToPrint_int(printWidth), CmToPrint_int(printHeight));
                document.Print();
            }
        }

        /// <summary>
        /// 打印绘制 刻度尺
        /// </summary>
        private void ScaleDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Display;
            float printWidth = Convert.ToSingle(tbWidth.Text);
            float printHeight = Convert.ToSingle(tbHeight.Text);
            float scaleSize = Convert.ToSingle(tbScaleSize.Text);
            float scaleLength = Convert.ToSingle(tbScaleLength.Text);
            float scaleSizeHalf = scaleSize / 2;
            float scaleLengthHalf = scaleLength / 2;
            float length = CmToPrint(scaleLength);
            float lengthHalf = CmToPrint(scaleLengthHalf);

            // 绘制水平刻度尺
            if (cbScaleWidth.Checked)
            {
                // 绘制零点
                e.Graphics.DrawLine(Pens.Black, 0, 0, 0, length);
                if (cbScaleNumber.Checked)
                {
                    e.Graphics.DrawString("0", PrintFont, PrintBrush, new RectangleF(0, length, 0, 0));
                }
                // 循环绘制半刻度、刻度、数值
                for (int i = 0; i < printWidth / scaleSize; i++)
                {
                    if (cbScaleHalf.Checked)
                    {
                        var xHalf = CmToPrint(i * scaleSize + scaleSizeHalf);
                        e.Graphics.DrawLine(Pens.Black, xHalf, 0, xHalf, lengthHalf);
                    }

                    var x = CmToPrint((i + 1) * scaleSize);
                    e.Graphics.DrawLine(Pens.Black, x, 0, x, length);

                    if (cbScaleNumber.Checked)
                    {
                        e.Graphics.DrawString($"{i + 1}", PrintFont, PrintBrush, new RectangleF(x, length, 0, 0));
                    }
                }
            }

            // 绘制垂直刻度尺
            if (cbScaleHeight.Checked)
            {
                // 绘制零点
                e.Graphics.DrawLine(Pens.Black, 0, 0, length, 0);
                if (cbScaleNumber.Checked)
                {
                    e.Graphics.DrawString("0", PrintFont, PrintBrush, new RectangleF(length, 0, 0, 0));
                }
                // 循环绘制半刻度、刻度、数值
                for (int i = 0; i < printHeight / scaleSize; i++)
                {
                    if (cbScaleHalf.Checked)
                    {
                        var yHalf = CmToPrint(i * scaleSize + scaleSizeHalf);
                        e.Graphics.DrawLine(Pens.Black, 0, yHalf, lengthHalf, yHalf);
                    }

                    var y = CmToPrint((i + 1) * scaleSize);
                    e.Graphics.DrawLine(Pens.Black, 0, y, length, y);

                    if (cbScaleNumber.Checked)
                    {
                        e.Graphics.DrawString($"{i + 1}", PrintFont, PrintBrush, new RectangleF(length, y, 0, 0));
                    }
                }
            }
        }

        /// <summary>
        /// 打印绘制 简易网格
        /// </summary>
        private void GridDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Display;
            float printWidth = Convert.ToSingle(tbWidth.Text);
            float printHeight = Convert.ToSingle(tbHeight.Text);
            float gridSize = Convert.ToSingle(tbGridSize.Text);
            float size = CmToPrint(gridSize);
            float xMax = CmToPrint(Width);
            float yMax = CmToPrint(Height);

            for (int i = 0; i <= printHeight / gridSize; i++)
            {
                e.Graphics.DrawLine(PrintPen, 0, i * size, xMax, i * size);
            }
            for (int i = 0; i <= printWidth / gridSize; i++)
            {
                e.Graphics.DrawLine(PrintPen, i * size, 0, i * size, yMax);
            }
        }

        #region UnitConvert
        /// <summary>
        /// 将厘米转为打印机单位
        /// </summary>
        public static float CmToPrint(float value)
        {
            return value / 2.54f * 100f;
        }

        /// <summary>
        /// 将厘米转为打印机单位
        /// </summary>
        public static int CmToPrint_int(float value)
        {
            return Convert.ToInt32(Math.Round(CmToPrint(value)));
        }
        #endregion
    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PrinterHelper
{
    public partial class FormMain : Form
    {
        private static Font PrintFont = new Font(new FontFamily("黑体"), 10f);
        private static Pen PrintPen = new Pen(Color.Black) { DashStyle = DashStyle.Dot };

        public FormMain()
        {
            InitializeComponent();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (!TryPrintConfig(btn.Name))
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
        /// 检测打印参数正确性
        /// </summary>
        /// <param name="branchName">类型名称</param>
        private bool TryPrintConfig(string branchName)
        {
            string name = "null";
            try
            {
                name = nameof(tbWidth);
                Convert.ToSingle(tbWidth.Text);
                name = nameof(tbHeight);
                Convert.ToSingle(tbHeight.Text);
                switch (branchName)
                {
                    case "bScalePrint":
                        name = nameof(tbScaleSize);
                        Convert.ToSingle(tbScaleSize.Text);
                        name = nameof(tbScaleLength);
                        Convert.ToSingle(tbScaleLength.Text);
                        break;
                    case "bGridPrint":
                        name = nameof(tbGridSize);
                        Convert.ToSingle(tbGridSize.Text);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{name}: {ex.Message}", "配置错误");
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
                document.DefaultPageSettings.PaperSize = new PaperSize("Custom", MmToPrinterUnit(printWidth), MmToPrinterUnit(printHeight));
                document.Print();
            }
        }

        /// <summary>
        /// 打印绘制 宽高刻度尺
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
            float length = MmToPrinterUnit_f(scaleLength);
            float lengthHalf = MmToPrinterUnit_f(scaleLengthHalf);

            // 绘制水平刻度尺
            if (cbScaleWidth.Checked)
            {
                // 绘制零点
                e.Graphics.DrawLine(Pens.Black, 0, 0, 0, length);
                if (cbScaleNumber.Checked)
                {
                    e.Graphics.DrawString("0", PrintFont, Brushes.Black, new RectangleF(0, length, 0, 0));
                }
                // 循环绘制半刻度、刻度、数值
                for (int i = 0; i < printWidth / scaleSize; i++)
                {
                    if (cbScaleHalf.Checked)
                    {
                        var xHalf = MmToPrinterUnit_f(i * scaleSize + scaleSizeHalf);
                        e.Graphics.DrawLine(Pens.Black, xHalf, 0, xHalf, lengthHalf);
                    }
                    var x = MmToPrinterUnit_f((i + 1) * scaleSize);
                    e.Graphics.DrawLine(Pens.Black, x, 0, x, length);
                    if (cbScaleNumber.Checked)
                    {
                        e.Graphics.DrawString($"{i + 1}", PrintFont, Brushes.Black, new RectangleF(x, length, 0, 0));
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
                    e.Graphics.DrawString("0", PrintFont, Brushes.Black, new RectangleF(length, 0, 0, 0));
                }
                // 循环绘制半刻度、刻度、数值
                for (int i = 0; i < printHeight / scaleSize; i++)
                {
                    if (cbScaleHalf.Checked)
                    {
                        var yHalf = MmToPrinterUnit_f(i * scaleSize + scaleSizeHalf);
                        e.Graphics.DrawLine(Pens.Black, 0, yHalf, lengthHalf, yHalf);
                    }
                    var y = MmToPrinterUnit_f((i + 1) * scaleSize);
                    e.Graphics.DrawLine(Pens.Black, 0, y, length, y);
                    if (cbScaleNumber.Checked)
                    {
                        e.Graphics.DrawString($"{i + 1}", PrintFont, Brushes.Black, new RectangleF(length, y, 0, 0));
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
            float size = MmToPrinterUnit_f(gridSize);
            float xMax = MmToPrinterUnit_f(Width);
            float yMax = MmToPrinterUnit_f(Height);

            for (int i = 0; i <= printHeight / gridSize; i++)
            {
                e.Graphics.DrawLine(PrintPen, 0, i * size, xMax, i * size);
            }
            for (int i = 0; i <= printWidth / gridSize; i++)
            {
                e.Graphics.DrawLine(PrintPen, i * size, 0, i * size, yMax);
            }
        }

        #region UnitlHelper
        /// <summary>
        /// 将毫米转为打印机单位
        /// </summary>
        public static int MmToPrinterUnit(float mm)
        {
            return Convert.ToInt32(Math.Round(mm / 25.4f * 100f));
        }

        /// <summary>
        /// 将毫米转为打印机单位
        /// </summary>
        public static float MmToPrinterUnit_f(float mm)
        {
            return mm / 25.4f * 100f;
        }
        #endregion
    }
}
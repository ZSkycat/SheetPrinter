using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SheetPrintTool
{
    public partial class FormInputCommon : Form
    {
        public FormInputCommon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.DrawImageUnscaled(Image.FromFile(@"E:\SheetPrintTool\SheetPrintTool\Template\test.jpg"), new Point());
            g.DrawString("测试文本测试文本测试文本测试文本测试文本测试文本测试文本测试文本测试文本测试文本", Font, Brushes.Black, new RectangleF(50, 50, 50, 50));
        }
    }
}

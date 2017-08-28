using System;
using System.Windows.Forms;

namespace SheetPrinter
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            tbInfo.Text = @"SheetPrintTool (物流运单打印工具) Build3
Author: ZSkycat (梓天猫)
Github: https://github.com/ZSkycat/SheetPrinter
License: MIT License
";
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

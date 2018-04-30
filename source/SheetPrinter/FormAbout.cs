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
            tbInfo.Text = @"SheetPrinter (物流运单打印工具)
Author: ZSkycat (梓天猫)
Github: https://github.com/ZSkycat/SheetPrinter
License: MIT
";
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

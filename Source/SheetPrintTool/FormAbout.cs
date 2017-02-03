using System;
using System.Windows.Forms;

namespace SheetPrintTool
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            tbInfo.Text = @"SheetPrintTool (物流单据打印工具) V1
Author: ZSkycat (梓天猫)
Github: https://github.com/ZSkycat/SheetPrintTool
License: MIT License
";
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
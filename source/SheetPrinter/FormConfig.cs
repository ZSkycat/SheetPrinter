using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SheetPrinter
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            tbOffsetX.Text = Core.Program.Config.PrinterOffsetX.ToString();
            tbOffsetY.Text = Core.Program.Config.PrinterOffsetY.ToString();
        }

        private void bTool_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start($@"{Environment.CurrentDirectory}\PrinterTool.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                Core.Program.Config.PrinterOffsetX = Convert.ToSingle(tbOffsetX.Text);
                Core.Program.Config.PrinterOffsetY = Convert.ToSingle(tbOffsetY.Text);
                Core.Program.SaveConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "参数错误");
            }
        }
    }
}

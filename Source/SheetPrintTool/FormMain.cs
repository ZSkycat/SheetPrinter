using SheetPrintTool.DataModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SheetPrintTool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // 初始化 dpi
            Graphics g = CreateGraphics();
            Global.DpiX = g.DpiX;
            Global.DpiY = g.DpiY;

            // 初始化数据录入模式
            for (var i = 0; true; i++)
            {
                if (Enum.GetName(typeof(InputMode), i) != null)
                    cbInputMode.Items.Add((InputMode)i);
                else
                    break;
            }
            cbInputMode.SelectedIndex = Global.Config.InputModeIndex;

            // 初始化模版列表
            lbTemplate.DataSource = Global.TemplateList;
            lbTemplate.DisplayMember = "Name";
            lbTemplate.SelectedIndex = -1;
        }

        private void toolStripMenuItem字体配置_Click(object sender, EventArgs e)
        {
            var dialog = new FontDialog()
            {
                AllowVerticalFonts = false,
                ShowEffects = false,
                Font = Global.Config.Font
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Global.Config.Font = dialog.Font;
                Global.SaveConfig();
            }
        }

        private void toolStripMenuItem信息管理_Click(object sender, EventArgs e)
        {
            var form = new FormInfoManage();
            form.ShowDialog(this);
        }

        private void lbTemplate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = lbTemplate.IndexFromPoint(e.Location);
            if (index >= 0)
            {
                var dataCopy = ((TemplateData)lbTemplate.Items[index]).Clone();
                OpenTemplateInputForm(dataCopy);
            }
        }

        /// <summary>
        /// 打开数据输入窗口
        /// </summary>
        private void OpenTemplateInputForm(TemplateData data)
        {
            switch ((InputMode)cbInputMode.SelectedItem)
            {
                case InputMode.通用编辑模式:
                    new FormInputCommon(data).Show();
                    break;
                case InputMode.淘宝物流格式:
                    break;
            }
        }
    }
}

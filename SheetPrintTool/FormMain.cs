using SheetPrintTool.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

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
            //初始化输入模式
            for (var i = 0; true; i++)
            {
                if (Enum.GetName(typeof(InputMode), i) != null)
                    cbInputMode.Items.Add((InputMode)i);
                else
                    break;
            }
            cbInputMode.SelectedIndex = GlobalData.InputModeIndex;
            //初始模版列表
            lbTemplate.DisplayMember = "Name";
            foreach (var i in GlobalData.TemplateList)
            {
                lbTemplate.Items.Add(i);
            }
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
        void OpenTemplateInputForm(TemplateData data)
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

using SheetPrintTool.Core;
using SheetPrintTool.DataModel;
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
    public partial class FormInputTaobao : Form
    {
        TemplateData data;
        PrintControl print;

        public FormInputTaobao(TemplateData data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void FormInputTaobao_Load(object sender, EventArgs e)
        {
            print = new PrintControl(data);
            print.InitPreview(pPreview);
        }
    }
}

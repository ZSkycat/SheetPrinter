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
    public partial class FormInputCommon : Form
    {
        TemplateData data;
        PrintControl print;

        Panel preview;

        public FormInputCommon(TemplateData data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void FormInputCommon_Load(object sender, EventArgs e)
        {
            print = new PrintControl(data);
            InitInput();
            InitPreviewPanel();
        }

        private void toolStripButton清空输入_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton添加任务_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton直接打印_Click(object sender, EventArgs e)
        {

        }

        void InitInput()
        {

        }

        void InitPreviewPanel()
        {
            preview = new Panel()
            {
                Width = Convert.ToInt32(data.Width),
                Height = Convert.ToInt32(data.Height)
            };
            pPreview.Controls.Add(preview);
            preview.Paint += (sender, e) => { print.Preview(e.Graphics, data); };
        }

        void Preview()
        {
            print.Preview(preview.CreateGraphics(), data);
        }
    }
}

using SheetPrinter.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SheetPrinter.Core.Model;

namespace SheetPrinter.Plugin.Default
{
    public partial class ModeCommon : Form, IMode
    {
        private TaskInfoModel task;
        private TemplateModel data;

        public ModeCommon()
        {
            InitializeComponent();
        }

        public void RunNew(TemplateModel data)
        {
            this.data = data;
            Text += " - 新建";
            preview.Initialize(data);
            throw new NotImplementedException();
        }

        public void RunEdit(TaskInfoModel data)
        {
            task = data;
            this.data = data.Data;
            Text += " - 编辑";
            preview.Initialize(this.data);
            throw new NotImplementedException();
        }
    }
}

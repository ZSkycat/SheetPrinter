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
            lbTemplate.DisplayMember = "Name";
            foreach (var i in GlobalData.TemplateList)
            {
                lbTemplate.Items.Add(i);
            }
            
        }

        private void toolStripMenuItem关于_Click(object sender, EventArgs e)
        {
            var v = new FormInputCommon();
            v.Show();
        }
    }
}

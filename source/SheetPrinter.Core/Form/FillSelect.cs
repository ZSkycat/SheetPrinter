using SheetPrinter.Core.Model;
using System;
using System.Windows.Forms;

namespace SheetPrinter.Core.Form
{
    /// <summary>
    /// 填充数据控件，不支持通用和时间类型
    /// </summary>
    public partial class FillSelect : UserControl
    {
        private TemplateModel data;

        public FillSelect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="data">模板数据</param>
        public void Initialize(TemplateModel data)
        {
            this.data = data;
            cbSelect.DataSource = Program.Config.TemplateFillList;
            cbSelect.DisplayMember = "Name";
            cbSelect.SelectedIndex = -1;
        }

        private void cbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelect.SelectedIndex >= 0)
            {
                Fill();
                // 取消选择
                cbSelect.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        public void Fill()
        {
            foreach (var i in Program.Config.TemplateFillList[cbSelect.SelectedIndex].ElementData)
            {
                if (i.Key >= ElementType.寄件人姓名)
                {
                    ElementModel temp = data.ElementList.Find(e => e.Type == i.Key);
                    temp.Value = i.Value;
                }
            }
        }
    }
}
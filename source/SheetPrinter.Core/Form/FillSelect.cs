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
        private bool flagOne;

        /// <summary>
        /// 获取或设置选择的索引
        /// </summary>
        public int SelectedIndex
        {
            get => cbSelect.SelectedIndex;
            set => cbSelect.SelectedIndex = value;
        }

        /// <summary>
        /// 数据填充进模型后发生
        /// </summary>
        public event EventHandler DataModelChanged;

        public FillSelect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="data">模板数据</param>
        /// <param name="flagOne">是否启用一次性填充, 即选择后触发取消选择</param>
        public void Initialize(TemplateModel data, bool flagOne = true)
        {
            this.data = data;
            this.flagOne = flagOne;
            cbSelect.DataSource = Program.Config.TemplateFillList;
            cbSelect.DisplayMember = "Name";
            cbSelect.SelectedIndex = -1;
            cbSelect.SelectedIndexChanged += cbSelect_SelectedIndexChanged;
        }

        /// <summary>
        /// 填充已选中的数据, 一次性填充模式下不可用
        /// </summary>
        public void Fill()
        {
            if (flagOne)
                throw new NotSupportedException("一次性填充模式下不可用.");
            else
                FillDataModel();
        }

        /// <summary>
        /// 清除选择，一次性填充模式下不可用
        /// </summary>
        public void Clear()
        {
            if (flagOne)
                throw new NotSupportedException("一次性填充模式下不可用.");
            else
                cbSelect.SelectedIndex = -1;
        }

        private void FillSelect_EnabledChanged(object sender, EventArgs e)
        {
            cbSelect.Enabled = Enabled;
        }

        private void cbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelect.SelectedIndex >= 0)
            {
                FillDataModel();
                DataModelChanged?.Invoke(this, null);
                if (flagOne)
                    cbSelect.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 填充数据模型
        /// </summary>
        private void FillDataModel()
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

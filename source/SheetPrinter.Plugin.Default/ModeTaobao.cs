using SheetPrinter.Core;
using SheetPrinter.Core.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SheetPrinter.Plugin.Default
{
    public partial class ModeTaobao : Form, IMode
    {
        private TaskInfoModel task;
        private TemplateModel data;

        public ModeTaobao()
        {
            InitializeComponent();
        }

        public void RunNew(TemplateModel model)
        {
            data = model;
            Initialize();
            Text += " - 新建";
            tsbSaveTask.Visible = false;
            tsbDelete.Visible = false;
            Show();
        }

        public void RunEdit(TaskInfoModel model)
        {
            task = model;
            data = model.Data.Clone();
            Initialize();
            Text += " - 编辑";
            LoadPluginData();
            Show();
        }

        private void Initialize()
        {
            preview.Initialize(data);
            InitInput();
        }

        #region 操作
        private void tsbClear_Click(object sender, EventArgs e)
        {
            fillSelect.Clear();
            tbTaobao.Clear();
            tbItemName.Clear();
            dateTimeCheck.Clear();
            data.ElementList.ForEach(o => o.Value = string.Empty);
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            new PrintController(data).Print();
        }

        private void tsbAddTask_Click(object sender, EventArgs e)
        {
            task = TaskController.Add(data, SavePluginData());
            tsbSaveTask.Visible = true;
            tsbDelete.Visible = true;
        }

        private void tsbSaveTask_Click(object sender, EventArgs e)
        {
            task.Data = data.Clone();
            task.PluginData = SavePluginData();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请确认是否删除此任务", "删除此任务", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TaskController.Delete(task);
                Close();
            }
        }

        private object SavePluginData()
        {
            return new PluginData_ModeTaobao()
            {
                SelectedIndex = fillSelect.SelectedIndex,
                TextTaobao = tbTaobao.Text,
                TextItemName = tbItemName.Text,
            };
        }

        private void LoadPluginData()
        {
            if (task.PluginData is PluginData_ModeTaobao pluginData)
            {
                fillSelect.SelectedIndex = pluginData.SelectedIndex;
                tbTaobao.Text = pluginData.TextTaobao;
                tbItemName.Text = pluginData.TextItemName;
            }
        }

        private class PluginData_ModeTaobao
        {
            public int SelectedIndex { get; set; }
            public string TextTaobao { get; set; }
            public string TextItemName { get; set; }
        }
        #endregion

        #region 输入面板
        // 匹配淘宝物流格式的正则表达式，分组 name phone phone2 address addressA code
        private const string PatternTaobao = @"^(?<name>.+)，(?<phone>(\d{0,4}-)?\d{11}) *，((?<phone2>(\d{0,4}-)?\d{3,5}-\d{7,9}(-\d{0,6})?) *，)?((?<address>(?<addressA>\w{2,8}) .+)，(?<code>\d{6})|(?<address>(?<addressA>\w{2,8}) .+))$";

        /// <summary>
        /// 初始化输入面板
        /// </summary>
        private void InitInput()
        {
            // 填充控件
            fillSelect.Initialize(data, false);
            fillSelect.DataModelChanged += (sender, e) =>
            {
                ParseAndInputTaobao();
                if (!string.IsNullOrEmpty(tbItemName.Text))
                {
                    data.ElementList.Find(o => o.Type == ElementType.物品名称).Value = tbItemName.Text;
                }
                preview.RefreshPreview();
            };

            // 检测 物品名称 和 时间戳
            bool dateTimeFlag = false;
            foreach (var e in data.ElementList)
            {
                switch (e.Type)
                {
                    case ElementType.物品名称:
                        tbItemName.Enabled = true;
                        tbItemName.Tag = e;
                        break;
                    case ElementType.Year:
                    case ElementType.Month:
                    case ElementType.Day:
                    case ElementType.Hour:
                    case ElementType.Minute:
                    case ElementType.Second:
                        dateTimeFlag = true;
                        break;
                }
            }

            // 日期时间控件
            if (dateTimeFlag)
            {
                dateTimeCheck.Enabled = true;
                dateTimeCheck.Initialize(data);
                dateTimeCheck.DataModelChanged += (sender, e) => preview.RefreshPreview();
            }
        }

        private void tbTaobao_TextChanged(object sender, EventArgs e)
        {
            if (ParseAndInputTaobao())
            {
                preview.RefreshPreview();
            }
        }

        private void tbItemName_TextChanged(object sender, EventArgs e)
        {
            var model = (ElementModel)tbItemName.Tag;
            model.Value = tbItemName.Text;
            preview.RefreshPreview();
        }

        private void lState_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"
【格式】姓名，手机，电话，地址，邮编
电话、邮编，是可选的，电话要求写区号，邮编要求6位。
对于地址，将从中解析出一级区域（省或直辖市）作为目的地，规则是取地址中第一个空格的左边字符

示例：赵小明，18888888888，000-6666666，北京 北京市 详细地址，000000", "输入提示");
        }

        /// <summary>
        /// 解析淘宝地址并填入模型
        /// </summary>
        private bool ParseAndInputTaobao()
        {
            Match match = Regex.Match(tbTaobao.Text.Trim(), PatternTaobao, RegexOptions.ExplicitCapture);
            if (match.Success)
            {
                var taobaoData = new Dictionary<ElementType, string>();
                Group group;

                // 收件人姓名
                group = match.Groups["name"];
                taobaoData.Add(ElementType.收件人姓名, group.Value.Trim());
                // 收件人地址
                group = match.Groups["address"];
                taobaoData.Add(ElementType.收件人地址, group.Value.Trim());
                // 收件人目的地
                group = match.Groups["addressA"];
                taobaoData.Add(ElementType.收件人目的地, group.Value);
                // 收件人电话
                group = match.Groups["phone"];
                taobaoData.Add(ElementType.收件人电话, group.Value);
                group = match.Groups["phone2"];
                if (group.Success)
                    taobaoData[ElementType.收件人电话] = $"{taobaoData[ElementType.收件人电话]}，{group.Value}";
                // 收件人邮编
                group = match.Groups["code"];
                if (group.Success)
                    taobaoData.Add(ElementType.收件人邮编, group.Value);

                // 数据填入模型
                foreach (var i in taobaoData)
                {
                    ElementModel model = data.ElementList.Find(o => o.Type == i.Key);
                    model.Value = i.Value;
                }

                SetParseTaobaoState(true);
                return true;
            }
            else
            {
                SetParseTaobaoState(false);
                return false;
            }
        }

        /// <summary>
        /// 设置解析淘宝地址状态
        /// </summary>
        private void SetParseTaobaoState(bool flag)
        {
            if (flag)
            {
                lState.Text = "解析成功";
                lState.ForeColor = Color.Blue;
            }
            else
            {
                lState.Text = "格式错误";
                lState.ForeColor = Color.Red;
            }
        }
        #endregion
    }
}

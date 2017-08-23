using SheetPrinter.Core;
using SheetPrinter.Core.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SheetPrinter
{
    public partial class FormFillManage : Form
    {
        public FormFillManage()
        {
            InitializeComponent();
        }

        private void FormInfoManage_Load(object sender, EventArgs e)
        {
            InitInput();
            RefreshList();
        }

        #region 操作
        private void bDelete_Click(object sender, EventArgs e)
        {
            Core.Program.Config.TemplateFillList.RemoveAt(lbList.SelectedIndex);
            Core.Program.Config.TemplateFillList.Sort();
            Core.Program.SaveConfig();
            RefreshList();
            SetState(StateText.新建);
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            SetState(StateText.新建);
        }

        private void bClone_Click(object sender, EventArgs e)
        {
            SetState(StateText.克隆);
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SetState(StateText.编辑_已保存);
        }

        private void lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbList.SelectedIndex >= 0)
            {
                SetState(StateText.编辑);
            }
        }
        #endregion

        #region 输入面板
        private const string FillNameString = "填充名称";

        /// <summary>
        /// 初始化输入面板
        /// </summary>
        private void InitInput()
        {
            const int initY = 5;
            const int nextY = 30;

            // 创建输入项
            var currentY = initY;
            CreateItemInInput(currentY, FillNameString);
            currentY += nextY;
            for (var i = 200; true; i++)
            {
                if (Enum.GetName(typeof(ElementType), i) == null)
                    break;
                CreateItemInInput(currentY, (ElementType)i);
                currentY += nextY;
            }

            // 滚动条出现导致面板宽度减小，在 Anchor 作用下导致TextBox宽度减小，所以延迟修改 Anchor
            foreach (Control control in pInput.Controls)
            {
                if (control is TextBox)
                {
                    control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                }
            }
        }

        /// <summary>
        /// 在输入面板创建 Label + TextBox
        /// </summary>
        /// <param name="y">y 坐标</param>
        /// <param name="tag">标识对象</param>
        private void CreateItemInInput(int y, object tag)
        {
            var label = new Label()
            {
                Location = new Point(5, y),
                Text = tag.ToString(),
            };
            var textBox = new TextBox()
            {
                Location = new Point(150, y),
                Width = 240,
                Name = tag.ToString(),
                Tag = tag,
            };
            pInput.Controls.Add(label);
            pInput.Controls.Add(textBox);
        }

        /// <summary>
        /// 清空输入面板
        /// </summary>
        private void ClearInput()
        {
            foreach (Control control in pInput.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }
        }
        #endregion

        /// <summary>
        /// 刷新填充列表
        /// </summary>
        private void RefreshList()
        {
            lbList.DataSource = null;
            lbList.DataSource = Core.Program.Config.TemplateFillList;
            lbList.DisplayMember = "Name";
        }

        /// <summary>
        /// 获取输入面板数据至模型
        /// </summary>
        private void InputToModel(TemplateFillModel model)
        {
            foreach (Control control in pInput.Controls)
            {
                if (control is TextBox)
                {
                    if (control.Tag is ElementType)
                    {
                        var tag = (ElementType)control.Tag;
                        if (control.Text.Trim() == "")
                        {
                            model.ElementData.Remove(tag);
                        }
                        else
                        {
                            if (model.ElementData.ContainsKey(tag))
                                model.ElementData[tag] = control.Text;
                            else
                                model.ElementData.Add(tag, control.Text);
                        }
                    }
                    else if (control.Tag is string)
                    {
                        model.Name = control.Text;
                    }
                }
            }
        }

        /// <summary>
        /// 获取模型数据至输入面板
        /// </summary>
        private void ModelToInput(TemplateFillModel model)
        {
            pInput.Controls.Find(FillNameString, false)[0].Text = model.Name;
            foreach (var i in model.ElementData)
            {
                Control[] control = pInput.Controls.Find(i.Key.ToString(), false);
                if (control.Length >= 1)
                    control[0].Text = i.Value;
            }

        }

        /// <summary>
        /// 设置状态
        /// </summary>
        private void SetState(string text)
        {
            switch (text)
            {
                case StateText.新建:
                    lbList.SelectedIndex = -1;
                    ClearInput();
                    break;
                case StateText.克隆:
                    lbList.SelectedIndex = -1;
                    break;
                case StateText.编辑:
                    ClearInput();
                    ModelToInput(Core.Program.Config.TemplateFillList[lbList.SelectedIndex]);
                    goto case "编辑_状态文本";
                case StateText.编辑_已保存:
                    TemplateFillModel model = null;
                    if (lbList.SelectedIndex == -1)
                    {
                        model = new TemplateFillModel();
                        Core.Program.Config.TemplateFillList.Add(model);
                    }
                    else
                    {
                        model = Core.Program.Config.TemplateFillList[lbList.SelectedIndex];
                    }
                    InputToModel(model);
                    Core.Program.Config.TemplateFillList.Sort();
                    Core.Program.SaveConfig();
                    RefreshList();
                    goto case "编辑_状态文本";
                case "编辑_状态文本":
                    text = $"{text} [{lbList.SelectedIndex}] {Core.Program.Config.TemplateFillList[lbList.SelectedIndex].Name}";
                    break;
            }
            lState.Text = text;
        }

        /// <summary>
        /// 状态文本
        /// </summary>
        private static class StateText
        {
            public const string 新建 = "新建:";
            public const string 克隆 = "克隆:";
            public const string 编辑 = "编辑:";
            public const string 编辑_已保存 = "编辑: (已保存)";
        }
    }
}
using SheetPrinter.Core;
using SheetPrinter.Core.Form;
using SheetPrinter.Core.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

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
            foreach (Control control in pInput.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
                else if (control is DateTimeCheck date)
                {
                    date.Clear();
                }
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            new PrintController(data).Print();
        }

        private void tsbAddTask_Click(object sender, EventArgs e)
        {
            task = TaskController.Add(data);
            tsbSaveTask.Visible = true;
            tsbDelete.Visible = true;
        }

        private void tsbSaveTask_Click(object sender, EventArgs e)
        {
            task.Data = data.Clone();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请确认是否删除此任务", "删除此任务", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TaskController.Delete(task);
                Close();
            }
        }
        #endregion

        #region 输入面板
        private const int X_Label = 10;
        private const int X_Control = 150;
        private const int Width_Control = 410;

        /// <summary>
        /// 初始化输入面板
        /// </summary>
        private void InitInput()
        {
            const int initY = 35;
            const int nextY = 30;

            // 填充控件
            fillSelect.Initialize(data);
            fillSelect.DataModelChanged += (sender, e) => preview.RefreshPreview();

            // 创建输入项
            int currentY = initY;
            bool dateTimeFlag = false;
            foreach (var e in data.ElementList)
            {
                if ((int)e.Type >= 200)
                {
                    CreateItemInInput(currentY, e);
                    currentY += nextY;
                }
                else
                {
                    switch (e.Type)
                    {
                        case ElementType.Text:
                            CreateItemInInput_Text(currentY, e);
                            currentY += nextY;
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
            }

            // 日期时间控件
            if (dateTimeFlag)
            {
                var label = new Label()
                {
                    Location = new Point(X_Label, currentY),
                    Text = "寄件时间",
                };
                var dateTimeCheck = new DateTimeCheck()
                {
                    Location = new Point(X_Control, currentY),
                };
                dateTimeCheck.Initialize(data);
                dateTimeCheck.DataModelChanged += (sender, e) => preview.RefreshPreview();
                pInput.Controls.Add(label);
                pInput.Controls.Add(dateTimeCheck);
            }

            // 滚动条出现导致面板宽度减小，在 Anchor 作用下导致TextBox宽度减小，所以延迟修改 Anchor
            foreach (Control control in pInput.Controls)
            {
                if (control is TextBox || control is FillSelect)
                {
                    control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                }
            }
        }

        /// <summary>
        /// 在输入面板创建 Label + TextBox
        /// </summary>
        /// <param name="y">Y 坐标</param>
        /// <param name="model">元素类型</param>
        private void CreateItemInInput(int y, ElementModel model)
        {
            var label = new Label()
            {
                Location = new Point(X_Label, y),
                Text = model.Type.ToString(),
            };
            var textBox = new TextBox()
            {
                Location = new Point(X_Control, y),
                Width = Width_Control,
                Name = model.Type.ToString(),
                Tag = model,
                Text = model.Value,
            };
            textBox.TextChanged += Item_TextChanged;
            pInput.Controls.Add(label);
            pInput.Controls.Add(textBox);
        }

        /// <summary>
        /// 在输入面板创建 Label + TextBox，通用文本类型 ElementType.Text
        /// </summary>
        /// <param name="y">Y 坐标</param>
        /// <param name="model">元素模型</param>
        private void CreateItemInInput_Text(int y, ElementModel model)
        {
            var label = new Label()
            {
                Location = new Point(X_Label, y),
                Text = model.Key,
            };
            var textBox = new TextBox()
            {
                Location = new Point(X_Control, y),
                Width = Width_Control,
                Name = model.Key,
                Tag = model,
                Text = model.Value,
            };
            textBox.TextChanged += Item_TextChanged;
            pInput.Controls.Add(label);
            pInput.Controls.Add(textBox);
        }

        private void Item_TextChanged(object sender, EventArgs e)
        {
            var control = (TextBox)sender;
            var model = (ElementModel)control.Tag;
            model.Value = control.Text;
            preview.RefreshPreview();
        }
        #endregion
    }
}

using SheetPrintTool.Core;
using SheetPrintTool.DataModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SheetPrintTool
{
    public partial class FormInputCommon : Form
    {
        const int InitY = 50;
        const int ChangeY = 30;
        const int LabelX = 10;
        const int ControlX = 150;
        const int DateTimeCheckBoxX = 360;
        const int ControlWidth = 420;
        const AnchorStyles TextBoxAnchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        TemplateData data;
        PrintControl print;
        // Tag.Year Month Day Hour 数据
        List<ElementData> dateTimeList;
        DateTimePicker dateTimePicker;
        CheckBox cbDateTime;

        public FormInputCommon(TemplateData data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void FormInputCommon_Load(object sender, EventArgs e)
        {
            print = new PrintControl(data);
            print.InitPreview(pPreview);
            InitInput();
        }

        private void toolStripButton清空输入_Click(object sender, EventArgs e)
        {
            foreach (var i in pInput.Controls)
            {
                if (i is TextBox)
                {
                    var control = (TextBox)i;
                    control.Clear();
                }
                else if (i is DateTimePicker)
                {
                    var control = (DateTimePicker)i;
                    control.Value = DateTime.Now;
                }
            }
        }

        private void toolStripButton添加任务_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton直接打印_Click(object sender, EventArgs e)
        {
            print.Print();
        }

        private void cbSelectSender_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 填充信息
            if (cbSelectSender.SelectedIndex >= 0)
            {
                foreach (var i in Global.Config.InfoList[cbSelectSender.SelectedIndex].ElementData)
                {
                    Control[] controls = pInput.Controls.Find(i.Key.ToString(), false);
                    if (controls.Length >= 1)
                        controls[0].Text = i.Value;
                }
                // 取消选中
                cbSelectSender.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 初始化输入面板
        /// </summary>
        void InitInput()
        {
            // 填充信息功能
            cbSelectSender.DataSource = Global.Config.InfoList;
            cbSelectSender.DisplayMember = "Name";
            cbSelectSender.SelectedIndex = -1;

            // 数据输入功能
            int currentY = InitY;
            foreach (var i in data.ElementList)
            {
                // 根据元素类型处理
                int tagInt = (int)i.Tag;
                if (tagInt >= 200 && tagInt < 400)
                {
                    CreateTag200to400(currentY, i);
                    currentY += ChangeY;
                }
                else
                {
                    switch (i.Tag)
                    {
                        case ElementTag.Text:
                            CreateTagText(currentY, i);
                            currentY += ChangeY;
                            break;
                        case ElementTag.Year:
                            if (dateTimeList == null)
                                dateTimeList = new List<ElementData>();
                            dateTimeList.Add(i);
                            break;
                        case ElementTag.Month:
                            goto case ElementTag.Year;
                        case ElementTag.Day:
                            goto case ElementTag.Year;
                        case ElementTag.Hour:
                            goto case ElementTag.Year;
                    }
                }
            }
            // 创建日期时间控件
            if (dateTimeList != null)
                CreateTagDate(currentY);
            // 防止因为滚动出现，导致宽度减小，同时在Anchor作用下导致TextBox宽度减小
            foreach (Control i in pInput.Controls)
            {
                if (i is TextBox)
                    i.Anchor = TextBoxAnchor;
            }
        }

        /// <summary>
        /// 创建 Label 和 TextBox
        /// </summary>
        private void CreateTextBox(int currentY, ElementData e, object tag, EventHandler textChanged)
        {
            var label = new Label()
            {
                Location = new Point(LabelX, currentY),
                Text = tag.ToString()
            };
            var textBox = new TextBox()
            {
                Location = new Point(ControlX, currentY),
                Width = ControlWidth,
                Tag = tag,
                Text = e.Value
            };
            textBox.TextChanged += textChanged;
            pInput.Controls.Add(label);
            pInput.Controls.Add(textBox);
        }

        /// <summary>
        /// 创建特殊类型控件
        /// </summary>
        /// <param name="y">y 坐标</param>
        /// <param name="d">元素数据</param>
        private void CreateTag200to400(int y, ElementData d)
        {
            var label = new Label()
            {
                Location = new Point(LabelX, y),
                Text = d.Tag.ToString()
            };
            var textBox = new TextBox()
            {
                Location = new Point(ControlX, y),
                Width = ControlWidth,
                Name = d.Tag.ToString(),
                Tag = d.Tag,
                Text = d.Value
            };
            textBox.TextChanged += Tag200to400_TextChanged;
            pInput.Controls.Add(label);
            pInput.Controls.Add(textBox);
        }

        /// <summary>
        /// 特殊类型的 TextChanged 事件
        /// </summary>
        private void Tag200to400_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            var tag = (ElementTag)tb.Tag;
            var element = data.ElementList.Find(obj => obj.Tag == tag);
            element.Value = tb.Text;
            print.RefreshPreview();
        }

        /// <summary>
        /// 创建 Tag.Text 控件
        /// </summary>
        /// <param name="y">y 坐标</param>
        /// <param name="d">元素数据</param>
        private void CreateTagText(int y, ElementData d)
        {
            var label = new Label()
            {
                Location = new Point(LabelX, y),
                Text = d.Key.ToString()
            };
            var textBox = new TextBox()
            {
                Location = new Point(ControlX, y),
                Width = ControlWidth,
                Tag = d.Key,
                Text = d.Value
            };
            textBox.TextChanged += TagText_TextChanged;
            pInput.Controls.Add(label);
            pInput.Controls.Add(textBox);
        }

        /// <summary>
        /// Tag.Text 的 TextChanged 事件
        /// </summary>
        private void TagText_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            var key = (string)tb.Tag;
            var element = data.ElementList.Find(obj => obj.Key == key);
            element.Value = tb.Text;
            print.RefreshPreview();
        }

        /// <summary>
        /// 创建 日期时间 控件
        /// </summary>
        /// <param name="y">y 坐标</param>
        private void CreateTagDate(int y)
        {
            var label = new Label()
            {
                Location = new Point(LabelX, y),
                Text = ElementTag.寄件时间.ToString()
            };
            dateTimePicker = new DateTimePicker()
            {
                Location = new Point(ControlX, y),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy年MM月dd日HH时",
                ShowUpDown = true
            };
            cbDateTime = new CheckBox()
            {
                Location = new Point(DateTimeCheckBoxX, y),
                Checked = true,
                Text = "显示"
            };
            dateTimePicker.ValueChanged += TagDate_TextChanged;
            cbDateTime.CheckedChanged += CbDateTime_CheckedChanged;
            TagDate_TextChanged(dateTimePicker, new EventArgs());
            pInput.Controls.Add(label);
            pInput.Controls.Add(dateTimePicker);
            pInput.Controls.Add(cbDateTime);
        }

        /// <summary>
        /// Tag.Year Month Day Hour 的 TextChanged 事件
        /// </summary>
        private void TagDate_TextChanged(object sender, EventArgs e)
        {
            if (cbDateTime.Checked)
            {
                var dtp = sender as DateTimePicker;
                foreach (var i in dateTimeList)
                {
                    switch (i.Tag)
                    {
                        case ElementTag.Year:
                            i.Value = dtp.Value.Year.ToString();
                            break;
                        case ElementTag.Month:
                            i.Value = dtp.Value.Month.ToString();
                            break;
                        case ElementTag.Day:
                            i.Value = dtp.Value.Day.ToString();
                            break;
                        case ElementTag.Hour:
                            i.Value = dtp.Value.Hour.ToString();
                            break;
                    }
                }
                print.RefreshPreview();
            }
        }

        /// <summary>
        /// Tag.Year Month Day Hour 的 CheckedChanged 事件
        /// </summary>
        private void CbDateTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDateTime.Checked)
                TagDate_TextChanged(dateTimePicker, new EventArgs());
            else
            {
                foreach (var i in dateTimeList)
                {
                    i.Value = "";
                }
            }
            print.RefreshPreview();
        }
    }
}
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
        const int ControlWidth = 420;
        const AnchorStyles TextBoxAnchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        TemplateData data;
        PrintControl print;
        List<ElementData> dataDateTime;

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

        }

        /// <summary>
        /// 初始化输入面板
        /// </summary>
        void InitInput()
        {
            //自动填充
            cbSelectSender.SelectedIndex = 0;
            //数据输入
            int currentY = InitY;
            foreach (var i in data.ElementList)
            {
                int tagInt = (int)i.Tag;
                if (tagInt >= 200 && tagInt < 400)
                {  //处理特殊字段
                    CreateTextBox(currentY, i, i.Tag, Tag200to400_TextChanged);
                    currentY += ChangeY;
                }
                else
                {
                    switch (i.Tag)
                    {
                        case ElementTag.Year:
                            if (dataDateTime == null)
                                dataDateTime = new List<ElementData>();
                            dataDateTime.Add(i);
                            break;
                        case ElementTag.Month:
                            goto case ElementTag.Year;
                        case ElementTag.Day:
                            goto case ElementTag.Year;
                        case ElementTag.Hour:
                            goto case ElementTag.Year;
                        case ElementTag.Text:
                            CreateTextBox(currentY, i, i.Key, TagText_TextChanged);
                            currentY += ChangeY;
                            break;
                    }
                }
            }
            if (dataDateTime != null)
            {  //创建日期时间控件
                var label = new Label()
                {
                    Location = new Point(LabelX, currentY),
                    Text = ElementTag.寄件时间.ToString()
                };
                var date = new DateTimePicker()
                {
                    Location = new Point(ControlX, currentY),
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = "yyyy年MM月dd日HH时",
                    ShowUpDown = true
                };
                date.ValueChanged += TagDate_TextChanged;
                pInput.Controls.Add(label);
                pInput.Controls.Add(date);
            }
            foreach (var i in pInput.Controls)
            {  //防止因为滚动出现，导致宽度减小，同时在Anchor作用下导致TextBox宽度减小
                var tb = i as TextBox;
                if (tb != null)
                    tb.Anchor = TextBoxAnchor;
            }
        }

        /// <summary>
        /// 创建 Label 和 TextBox
        /// </summary>
        private void CreateTextBox(int currentY, ElementData e, object id, EventHandler textChanged)
        {
            var label = new Label()
            {
                Location = new Point(LabelX, currentY),
                Text = id.ToString()
            };
            var textBox = new TextBox()
            {
                Location = new Point(ControlX, currentY),
                Width = ControlWidth,
                Tag = id,
                Text = e.Value
            };
            textBox.TextChanged += textChanged;
            pInput.Controls.Add(label);
            pInput.Controls.Add(textBox);
        }

        /// <summary>
        /// 预制元素字段的 TextChanged 事件
        /// </summary>
        private void Tag200to400_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            var tag = (ElementTag)tb.Tag;
            var element = data.ElementList.Find(obj => obj.Tag == tag);
            element.Value = tb.Text;
            RefreshPreview();
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
            RefreshPreview();
        }

        /// <summary>
        /// Tag.Year Month Day Hour 的 TextChanged 事件
        /// </summary>
        private void TagDate_TextChanged(object sender, EventArgs e)
        {
            var dtp = sender as DateTimePicker;
            foreach (var i in dataDateTime)
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
            RefreshPreview();
        }

        /// <summary>
        /// 初始化预览面板
        /// </summary>
        private void InitPreviewPanel()
        {
            preview = new Panel()
            {
                Width = Convert.ToInt32(UnitlHelper.MillimeterToPixelWithDpi(data.Width, 96)),
                Height = Convert.ToInt32(UnitlHelper.MillimeterToPixelWithDpi(data.Height, 96))
            };
            pPreview.Controls.Add(preview);
            preview.Paint += (sender, e) => { print.Preview(e.Graphics, data); };
        }

        /// <summary>
        /// 刷新预览图
        /// </summary>
        private void RefreshPreview()
        {
            print.Preview(preview.CreateGraphics(), data);
        }
    }
}

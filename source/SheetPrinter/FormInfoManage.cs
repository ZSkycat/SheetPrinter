using SheetPrinter.DataModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SheetPrinter
{
    public partial class FormInfoManage : Form
    {
        private const int InitY = 5;
        private const int ChangeY = 30;
        private const int LabelX = 5;
        private const int ControlX = 150;
        private const int ControlWidth = 240;
        private const AnchorStyles TextBoxAnchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        private const string InfoNameString = "信息名称";

        /// <summary>
        /// 获取或设置当前选中的索引，-1 为新建
        /// </summary>
        private int CurrentInfoIndex
        {
            get { return lbInfo.SelectedIndex; }
            set { lbInfo.SelectedIndex = value; }
        }

        public FormInfoManage()
        {
            InitializeComponent();
        }

        private void FormInfoManage_Load(object sender, EventArgs e)
        {
            InitInput();
            LoadInfoList();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            Global.Config.InfoList.RemoveAt(CurrentInfoIndex);
            Global.Config.InfoList.Sort();
            Global.SaveConfig();
            LoadInfoList();
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            CurrentInfoIndex = -1;
            ClearInput();
        }

        private void bNewCopy_Click(object sender, EventArgs e)
        {
            CurrentInfoIndex = -1;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (CurrentInfoIndex < 0)
            {
                var data = new InfoData();
                SetInfoData(data);
                Global.Config.InfoList.Add(data);
            }
            else
                SetInfoData(Global.Config.InfoList[CurrentInfoIndex]);
            Global.Config.InfoList.Sort();
            Global.SaveConfig();
            LoadInfoList();
        }

        private void lbInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 改变状态文本
            if (CurrentInfoIndex < 0)
                lState.Text = "新建:";
            else
                lState.Text = $"修改: [{CurrentInfoIndex}] {Global.Config.InfoList[CurrentInfoIndex].Name}";
            // 处理信息数据
            if (CurrentInfoIndex >= 0)
            {
                ClearInput();
                pInput.Controls.Find(InfoNameString, false)[0].Text = Global.Config.InfoList[CurrentInfoIndex].Name;
                foreach (var i in Global.Config.InfoList[CurrentInfoIndex].ElementData)
                {
                    Control[] controls = pInput.Controls.Find(i.Key.ToString(), false);
                    if (controls.Length >= 1)
                        controls[0].Text = i.Value;
                }
            }
        }

        /// <summary>
        /// 初始化输入面板
        /// </summary>
        private void InitInput()
        {
            int currentY = InitY;
            // 创建信息名称
            CreateTextInput(currentY, InfoNameString);
            currentY += ChangeY;
            // 创建字段
            int tagIndex = 200;
            while (true)
            {
                if (Enum.GetName(typeof(ElementTag), tagIndex) != null)
                {
                    CreateTextInput(currentY, (ElementTag)tagIndex);
                    currentY += ChangeY;
                    tagIndex++;
                }
                else if (tagIndex < 300)
                    tagIndex = 300;
                else
                    break;
            }
            /*// 创建字段 - 可配置显示的字段
            ElementTag[] elementList = { ElementTag.寄件人姓名, ElementTag.寄件人单位, ElementTag.寄件人地址, ElementTag.寄件人邮编, ElementTag.寄件人电话, ElementTag.寄件人签名, ElementTag.收件人姓名, ElementTag.收件人单位, ElementTag.收件人地址, ElementTag.收件人邮编, ElementTag.收件人电话, ElementTag.收件人目的地 };
            foreach (var i in elementList)
            {
                CreateTextInput(currentY, i);
                currentY += ChangeY;
            }*/
            // 防止因为滚动出现，导致宽度减小，同时在Anchor作用下导致TextBox宽度减小
            foreach (Control i in pInput.Controls)
            {
                if (i is TextBox)
                    i.Anchor = TextBoxAnchor;
            }
        }

        /// <summary>
        /// 加载信息列表
        /// </summary>
        private void LoadInfoList()
        {
            lbInfo.DataSource = null;
            lbInfo.DataSource = Global.Config.InfoList;
            lbInfo.DisplayMember = "Name";
            lbInfo.SelectedIndex = -1;
            ClearInput();
        }

        /// <summary>
        /// 提取信息数据
        /// </summary>
        /// <param name="data">信息数据模型</param>
        private void SetInfoData(InfoData data)
        {
            foreach (Control i in pInput.Controls)
            {
                if (i is TextBox)
                {
                    if (i.Tag is ElementTag)
                    {
                        // 处理数据
                        var tag = (ElementTag)i.Tag;
                        if (i.Text == "")
                        {
                            // 处理数据空值删除
                            if (data.ElementData.ContainsKey(tag))
                                data.ElementData.Remove(tag);
                        }
                        else
                        {
                            // 处理数据修改或添加
                            if (data.ElementData.ContainsKey(tag))
                                data.ElementData[tag] = i.Text;
                            else
                                data.ElementData.Add(tag, i.Text);
                        }
                    }
                    else
                    {
                        // 处理名称
                        data.Name = i.Text;
                    }
                }
            }
        }

        /// <summary>
        /// 清空输入
        /// </summary>
        private void ClearInput()
        {
            foreach (var i in pInput.Controls)
            {
                if (i is TextBox)
                {
                    var control = (TextBox)i;
                    control.Clear();
                }
            }
        }

        /// <summary>
        /// 创建文本输入控件
        /// </summary>
        /// <param name="y">y 坐标</param>
        /// <param name="tag">标签</param>
        private void CreateTextInput(int y, object tag)
        {
            var label = new Label()
            {
                Location = new Point(LabelX, y),
                Text = tag.ToString()
            };
            var textBox = new TextBox()
            {
                Location = new Point(ControlX, y),
                Width = ControlWidth,
                Name = tag.ToString(),
                Tag = tag
            };
            pInput.Controls.Add(label);
            pInput.Controls.Add(textBox);
        }
    }
}
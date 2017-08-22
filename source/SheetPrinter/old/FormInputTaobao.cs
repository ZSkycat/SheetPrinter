using SheetPrinter.Core;
using SheetPrinter.DataModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SheetPrinter
{
    public partial class FormInputTaobao : Form
    {
        // 匹配淘宝物流格式的正则表达式，分组 name phone phone2 address addressA code
        private const string PatternTaobao = @"^(?<name>.+)，(86-)?(?<phone>\d{11})，((86-)?(?<phone2>\d{3,5}-\d{7,9}(-\d{0,6})?)，)?((?<address>(?<addressA>\w{2,8}) .+)，(?<code>\d{6})|(?<address>(?<addressA>\w{2,8}) .+))$";

        private TemplateData data;
        private PrintControl print;
        // Tag.Year Month Day Hour 数据
        private List<ElementData> dateTimeList;


        public FormInputTaobao(TemplateData data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void FormInputTaobao_Load(object sender, EventArgs e)
        {
            print = new PrintControl(data);
            print.InitPreview(pPreview);
            InitInput();
        }

        private void toolStripButton清空输入_Click(object sender, EventArgs e)
        {
            // 清空控件
            cbSelectInfo.SelectedIndex = -1;
            tbTaobao.Clear();
            tbResName.Clear();
            dateTimePicker.Value = DateTime.Now;
            // 清空数据
            foreach (var i in data.ElementList)
            {
                int tagInt = (int)i.Tag;
                if (tagInt >= 200 && tagInt < 400)
                    i.Value = "";
            }
            print.RefreshPreview();
        }

        private void toolStripButton添加任务_Click(object sender, EventArgs e)
        {
            Global.AddTask(data);
            Close();
        }

        private void toolStripButton直接打印_Click(object sender, EventArgs e)
        {
            print.Print();
        }

        private void cbSelectInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            WriteElementData();
            print.RefreshPreview();
        }

        private void tbTaobao_TextChanged(object sender, EventArgs e)
        {
            WriteTaobao();
            print.RefreshPreview();
        }

        private void tbResName_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Tag != null)
            {
                var element = (ElementData)tb.Tag;
                element.Value = tb.Text;
                print.RefreshPreview();
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (cbDateTime.Checked)
            {
                var dtp = (DateTimePicker)sender;
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

        private void cbDateTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDateTime.Checked)
                dateTimePicker_ValueChanged(dateTimePicker, new EventArgs());
            else
            {
                foreach (var i in dateTimeList)
                {
                    i.Value = "";
                }
            }
            print.RefreshPreview();
        }

        private void lState_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"
【格式】姓名，手机，电话，地址，邮编
电话、邮编，是可选的，电话要求写区号，邮编要求6位。
对于地址，将从中解析出一级区域（省或直辖市）作为目的地，规则是取地址中第一个空格的左边字符

示例：赵小明，18888888888，000-6666666，北京 北京市 详细地址，000000
".Trim());
        }

        /// <summary>
        /// 初始化输入面板
        /// </summary>
        private void InitInput()
        {
            // 使用信息功能
            cbSelectInfo.DataSource = Global.Config.InfoList;
            cbSelectInfo.DisplayMember = "Name";
            // 清空数据 (cbSelectInfo 设置 DataSource 时会自动填充数据)
            toolStripButton清空输入_Click(toolStripButton清空输入, null);

            // 数据输入功能
            foreach (var i in data.ElementList)
            {
                switch (i.Tag)
                {
                    case ElementTag.物品名称:
                        tbResName.Enabled = true;
                        tbResName.Tag = i;
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
            // 寄件时间功能
            if (dateTimeList != null)
            {
                dateTimePicker.Enabled = true;
                cbDateTime.Enabled = true;
                cbDateTime.Checked = true;
            }
        }

        /// <summary>
        /// 将所有数据写入数据对象
        /// </summary>
        private void WriteElementData()
        {
            // 填充信息
            if (cbSelectInfo.SelectedIndex >= 0)
            {
                foreach (var i in Global.Config.InfoList[cbSelectInfo.SelectedIndex].ElementData)
                {
                    ElementData temp = data.ElementList.Find(elementData => { return elementData.Tag == i.Key; });
                    temp.Value = i.Value;
                }
            }
            // 输入数据覆盖填充信息
            WriteTaobao();
            tbResName_TextChanged(tbResName, null);
        }

        /// <summary>
        /// 写入淘宝物流格式
        /// </summary>
        private void WriteTaobao()
        {
            Dictionary<ElementTag, string> taobaoData;
            if (ParseTaobao(out taobaoData))
            {
                foreach (var i in taobaoData)
                {
                    ElementData temp = data.ElementList.Find(elementData => { return elementData.Tag == i.Key; });
                    temp.Value = i.Value;
                }
            }
        }

        /// <summary>
        /// 解析淘宝物流格式
        /// <param name="taobaoData">解析结果的数据</param>
        /// <returns>表示解析是否成功</returns>
        /// </summary>
        private bool ParseTaobao(out Dictionary<ElementTag, string> taobaoData)
        {
            Match match = Regex.Match(tbTaobao.Text.Trim(), PatternTaobao, RegexOptions.ExplicitCapture);
            if (match.Success)
            {
                taobaoData = new Dictionary<ElementTag, string>();
                Group group;

                // 收件人姓名
                group = match.Groups["name"];
                taobaoData.Add(ElementTag.收件人姓名, group.Value.Trim());
                // 收件人地址
                group = match.Groups["address"];
                taobaoData.Add(ElementTag.收件人地址, group.Value.Trim());
                // 收件人目的地
                group = match.Groups["addressA"];
                taobaoData.Add(ElementTag.收件人目的地, group.Value);
                // 收件人电话
                group = match.Groups["phone"];
                taobaoData.Add(ElementTag.收件人电话, group.Value);
                group = match.Groups["phone2"];
                if (group.Success)
                    taobaoData[ElementTag.收件人电话] = $"{taobaoData[ElementTag.收件人电话]}，{group.Value}";
                // 收件人邮编
                group = match.Groups["code"];
                if (group.Success)
                    taobaoData.Add(ElementTag.收件人邮编, group.Value);

                ChangeParseState(true);
                return true;
            }
            else
            {
                ChangeParseState(false);
                taobaoData = null;
                return false;
            }
        }

        /// <summary>
        /// 控制解析状态提示
        /// </summary>
        /// <param name="Success">是否成功</param>
        private void ChangeParseState(bool Success)
        {
            if (Success)
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
    }
}
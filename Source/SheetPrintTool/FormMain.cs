using SheetPrintTool.Core;
using SheetPrintTool.DataModel;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SheetPrintTool
{
    public partial class FormMain : Form
    {
        // 任务功能数据
        private ElementTag[] taskColumnTag;
        private PrintControl print;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // 初始化 Dpi
            Graphics g = CreateGraphics();
            Global.DpiX = g.DpiX;
            Global.DpiY = g.DpiY;

            // 初始化数据录入模式
            for (var i = 0; true; i++)
            {
                if (Enum.GetName(typeof(InputMode), i) != null)
                    cbInputMode.Items.Add((InputMode)i);
                else
                    break;
            }
            cbInputMode.SelectedIndex = Global.Config.InputModeIndex;

            // 初始化模版列表
            lbTemplate.DataSource = Global.TemplateList;
            lbTemplate.DisplayMember = "Name";
            lbTemplate.SelectedIndex = -1;

            // 初始化任务功能
            taskColumnTag = new ElementTag[] { ElementTag.收件人姓名, ElementTag.收件人电话, ElementTag.收件人地址, ElementTag.寄件人姓名, ElementTag.寄件人电话, ElementTag.寄件人地址 };
            lvTaskList.Columns.Add("序号", 50, HorizontalAlignment.Center);
            lvTaskList.Columns.Add("单据模版", 100, HorizontalAlignment.Center);
            foreach (var tag in taskColumnTag)
            {
                lvTaskList.Columns.Add(tag.ToString(), 100, HorizontalAlignment.Left);
            }
            print = new PrintControl(Global.TaskDataList);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.Config.InputModeIndex = cbInputMode.SelectedIndex;
            Global.SaveConfig();
        }

        private void toolStripMenuItem字体配置_Click(object sender, EventArgs e)
        {
            var dialog = new FontDialog()
            {
                AllowVerticalFonts = false,
                ShowEffects = false,
                Font = Global.Config.Font
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Global.Config.Font = dialog.Font;
                Global.SaveConfig();
                dialog.Dispose();
            }
        }

        private void toolStripMenuItem信息管理_Click(object sender, EventArgs e)
        {
            var form = new FormInfoManage();
            form.ShowDialog(this);
            form.Dispose();
        }

        private void toolStripMenuItem关于_Click(object sender, EventArgs e)
        {
            var form = new FormAbout();
            form.ShowDialog(this);
            form.Dispose();
        }

        private void lbTemplate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = lbTemplate.IndexFromPoint(e.Location);
            if (index >= 0)
            {
                var dataCopy = ((TemplateData)lbTemplate.Items[index]).Clone();
                OpenTemplateInputForm(dataCopy);
            }
        }

        #region 任务功能事件
        private void FormMain_Activated(object sender, EventArgs e)
        {
            RefreshTaskList();
        }

        private void toolStripMenuItem打印_Click(object sender, EventArgs e)
        {
            if (Global.TaskDataList.Count != 0)
            {
                print.Print(-1);
                toolStripMenuItem清空_Click(null, null);
            }
        }

        private void toolStripMenuItem清空_Click(object sender, EventArgs e)
        {
            Global.TaskDataList.Clear();
            RefreshTaskList();
        }

        private void menuTaskItem_Opening(object sender, CancelEventArgs e)
        {
            if (lvTaskList.SelectedItems.Count != 1)
                e.Cancel = true;
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = lvTaskList.SelectedIndices[0];
            new FormInputCommon(Global.TaskDataList[index]).Show();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = lvTaskList.SelectedIndices[0];
            Global.TaskDataList.RemoveAt(index);
            RefreshTaskList();
        }
        #endregion

        /// <summary>
        /// 打开数据输入窗口
        /// </summary>
        private void OpenTemplateInputForm(TemplateData data)
        {
            switch ((InputMode)cbInputMode.SelectedItem)
            {
                case InputMode.通用编辑模式:
                    new FormInputCommon(data).Show();
                    break;
                case InputMode.淘宝中国物流格式:
                    new FormInputTaobao(data).Show();
                    break;
            }
        }

        /// <summary>
        /// 刷新任务列表
        /// </summary>
        private void RefreshTaskList()
        {
            lvTaskList.BeginUpdate();
            // 清空数据
            lvTaskList.Items.Clear();
            // 加载数据源
            var index = 0;
            foreach (var data in Global.TaskDataList)
            {
                var item = new ListViewItem(index.ToString());
                item.SubItems.Add(data.Name);
                foreach (var tag in taskColumnTag)
                {
                    item.SubItems.Add(data.ElementList.Find(elementData => { return elementData.Tag == tag; }).Value);
                }
                lvTaskList.Items.Add(item);
                index++;
            }
            lvTaskList.EndUpdate();
        }
    }
}
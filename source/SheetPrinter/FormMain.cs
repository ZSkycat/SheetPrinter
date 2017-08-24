using SheetPrinter.Core;
using SheetPrinter.Core.Model;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SheetPrinter
{
    public partial class FormMain : Form
    {
        // 任务列表列源
        private ElementType[] taskColumnType;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // 初始化数据录入模式
            cbInputMode.DisplayMember = "ModeName";
            cbInputMode.DataSource = PluginLoader.ModeList;
            cbInputMode.SelectedIndex = Core.Program.Config.InputModeIndex;

            // 初始化运单模版
            lbTemplate.DisplayMember = "Name";
            lbTemplate.DataSource = Core.Program.Template;

            // 初始化任务列表
            taskColumnType = new ElementType[] { ElementType.收件人姓名, ElementType.收件人电话, ElementType.收件人地址, ElementType.寄件人姓名, ElementType.寄件人电话, ElementType.寄件人地址 };
            lvTaskList.Columns.Add("序号", 50, HorizontalAlignment.Center);
            lvTaskList.Columns.Add("运单模版", 100, HorizontalAlignment.Center);
            foreach (var type in taskColumnType)
            {
                lvTaskList.Columns.Add(type.ToString(), 100, HorizontalAlignment.Left);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Core.Program.Config.InputModeIndex = cbInputMode.SelectedIndex;
            Core.Program.SaveConfig();
        }

        private void lbTemplate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = lbTemplate.IndexFromPoint(e.Location);
            if (index >= 0)
            {
                var data = ((TemplateModel)lbTemplate.Items[index]).Clone();
                OpenInputMode(data);
            }
        }

        #region 菜单功能
        private void toolStripMenuItem打印配置_Click(object sender, EventArgs e)
        {
            new FormConfig().ShowDialog(this);
        }

        private void toolStripMenuItem字体配置_Click(object sender, EventArgs e)
        {
            var dialog = new FontDialog()
            {
                AllowVerticalFonts = false,
                ShowEffects = false,
                Font = Core.Program.Config.Font,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Core.Program.Config.Font = dialog.Font;
                Core.Program.SaveConfig();
            }
        }

        private void toolStripMenuItem填充管理_Click(object sender, EventArgs e)
        {
            new FormFillManage().ShowDialog(this);
        }

        private void toolStripMenuItem关于_Click(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog(this);
        }
        #endregion

        #region 任务功能
        private void FormMain_Activated(object sender, EventArgs e)
        {
            RefreshTaskList();
        }

        private void toolStripMenuItem打印_Click(object sender, EventArgs e)
        {
            if (lvTaskList.Items.Count != 0)
            {
                new PrintController(TaskController.TaskList).Print();
                toolStripMenuItem清空_Click(null, null);
            }
        }

        private void toolStripMenuItem清空_Click(object sender, EventArgs e)
        {
            TaskController.Clear();
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
            OpenInputMode(TaskController.TaskList[index]);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = lvTaskList.SelectedIndices[0];
            TaskController.Delete(index);
            RefreshTaskList();
        }

        private void lvTaskList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            编辑ToolStripMenuItem_Click(null, null);
        }

        /// <summary>
        /// 刷新任务列表
        /// </summary>
        private void RefreshTaskList()
        {
            lvTaskList.BeginUpdate();
            lvTaskList.Items.Clear();
            // 加载任务数据源
            for (var i = 0; i < TaskController.TaskList.Count; i++)
            {
                var data = TaskController.TaskList[i].Data;
                var item = new ListViewItem(i.ToString());
                item.SubItems.Add(data.Name);
                foreach (var type in taskColumnType)
                {
                    item.SubItems.Add(data.ElementList.Find(o => o.Type == type).Value);
                }
                lvTaskList.Items.Add(item);
            }
            lvTaskList.EndUpdate();
        }
        #endregion

        /// <summary>
        /// 打开数据录入模式窗口，新建
        /// </summary>
        private void OpenInputMode(TemplateModel data)
        {
            IMode mode = PluginLoader.CreateMode((ModeInfoModel)cbInputMode.SelectedItem);
            mode.RunNew(data);
        }

        /// <summary>
        /// 打开数据录入模式窗口，编辑
        /// </summary>
        private void OpenInputMode(TaskInfoModel data)
        {
            IMode mode = PluginLoader.CreateMode((ModeInfoModel)cbInputMode.SelectedItem);
            mode.RunEdit(data);
        }
    }
}

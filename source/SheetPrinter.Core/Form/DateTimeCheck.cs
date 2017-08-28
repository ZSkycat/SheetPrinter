using SheetPrinter.Core.Model;
using System;
using System.Text;
using System.Windows.Forms;

namespace SheetPrinter.Core.Form
{
    public partial class DateTimeCheck : UserControl
    {
        private TemplateModel data;

        /// <summary>
        /// 获取或设置是否启用
        /// </summary>
        public bool Checked
        {
            get => cbEnable.Checked;
            set => cbEnable.Checked = value;
        }

        /// <summary>
        /// 获取或设置时间数值
        /// </summary>
        public DateTime DateTimeValue
        {
            get => dtpTime.Value;
            set => dtpTime.Value = value;
        }

        /// <summary>
        /// 数据填充进模型后发生
        /// </summary>
        public event EventHandler DataModelChanged;

        public DateTimeCheck()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="data">模板数据</param>
        public void Initialize(TemplateModel data)
        {
            this.data = data;

            StringBuilder customFormat = new StringBuilder();
            DateTime time = new DateTime(0);
            ElementModel model;

            model = data.ElementList.Find(o => o.Type == ElementType.Year);
            if (model != null)
            {
                customFormat.Append("yyyy年");
                if (!string.IsNullOrEmpty(model.Value))
                    time = time.AddYears(Convert.ToInt32(model.Value) - 1);
            }

            model = data.ElementList.Find(o => o.Type == ElementType.Month);
            if (model != null)
            {
                customFormat.Append("MM月");
                if (!string.IsNullOrEmpty(model.Value))
                    time = time.AddMonths(Convert.ToInt32(model.Value) - 1);
            }

            model = data.ElementList.Find(o => o.Type == ElementType.Day);
            if (model != null)
            {
                customFormat.Append("dd日");
                if (!string.IsNullOrEmpty(model.Value))
                    time = time.AddDays(Convert.ToInt32(model.Value) - 1);
            }

            model = data.ElementList.Find(o => o.Type == ElementType.Hour);
            if (model != null)
            {
                customFormat.Append("HH时");
                if (!string.IsNullOrEmpty(model.Value))
                    time = time.AddHours(Convert.ToInt32(model.Value));
            }

            model = data.ElementList.Find(o => o.Type == ElementType.Minute);
            if (model != null)
            {
                customFormat.Append("mm分");
                if (!string.IsNullOrEmpty(model.Value))
                    time = time.AddMinutes(Convert.ToInt32(model.Value));
            }

            model = data.ElementList.Find(o => o.Type == ElementType.Second);
            if (model != null)
            {
                customFormat.Append("ss秒");
                if (!string.IsNullOrEmpty(model.Value))
                    time = time.AddSeconds(Convert.ToInt32(model.Value));
            }

            dtpTime.CustomFormat = customFormat.ToString();
            if (time.Ticks != 0)
            {
                dtpTime.Value = time;
                cbEnable.Checked = true;
            }
            else
            {
                cbEnable.Checked = false;
            }
        }

        /// <summary>
        /// 清除输入
        /// </summary>
        public void Clear()
        {
            cbEnable.Checked = false;
            dtpTime.Value = DateTime.Now;
        }

        private void DateTimeCheck_EnabledChanged(object sender, EventArgs e)
        {
            cbEnable.Enabled = Enabled;
            dtpTime.Enabled = Enabled;
        }

        private void cbEnable_CheckedChanged(object sender, EventArgs e)
        {
            dtpTime_ValueChanged(dtpTime, null);
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            if (cbEnable.Checked)
            {
                data.ElementList.ForEach(o =>
                {
                    switch (o.Type)
                    {
                        case ElementType.Year:
                            o.Value = dtpTime.Value.Year.ToString();
                            break;
                        case ElementType.Month:
                            o.Value = dtpTime.Value.Month.ToString();
                            break;
                        case ElementType.Day:
                            o.Value = dtpTime.Value.Day.ToString();
                            break;
                        case ElementType.Hour:
                            o.Value = dtpTime.Value.Hour.ToString();
                            break;
                        case ElementType.Minute:
                            o.Value = dtpTime.Value.Minute.ToString();
                            break;
                        case ElementType.Second:
                            o.Value = dtpTime.Value.Second.ToString();
                            break;
                    }
                });
            }
            else
            {
                data.ElementList.ForEach(o =>
                {
                    switch (o.Type)
                    {
                        case ElementType.Year:
                        case ElementType.Month:
                        case ElementType.Day:
                        case ElementType.Hour:
                        case ElementType.Minute:
                        case ElementType.Second:
                            o.Value = "";
                            break;
                    }
                });
            }
            DataModelChanged?.Invoke(this, null);
        }
    }
}

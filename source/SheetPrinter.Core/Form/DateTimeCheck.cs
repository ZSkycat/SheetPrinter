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
            CheckTime();
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
                    switch(o.Type)
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

        private void CheckTime()
        {
            StringBuilder customFormat = new StringBuilder();
            if (data.ElementList.FindIndex(o => o.Type == ElementType.Year) >= 0)
                customFormat.Append("yyyy年");
            if (data.ElementList.FindIndex(o => o.Type == ElementType.Month) >= 0)
                customFormat.Append("MM月");
            if (data.ElementList.FindIndex(o => o.Type == ElementType.Day) >= 0)
                customFormat.Append("dd日");
            if (data.ElementList.FindIndex(o => o.Type == ElementType.Hour) >= 0)
                customFormat.Append("HH时");
            if (data.ElementList.FindIndex(o => o.Type == ElementType.Minute) >= 0)
                customFormat.Append("mm分");
            if (data.ElementList.FindIndex(o => o.Type == ElementType.Second) >= 0)
                customFormat.Append("ss秒");
            dtpTime.CustomFormat = customFormat.ToString();
        }
    }
}

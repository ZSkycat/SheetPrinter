namespace SheetPrinter.Core.Form
{
    partial class FillSelect
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbSelect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbSelect
            // 
            this.cbSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelect.FormattingEnabled = true;
            this.cbSelect.Location = new System.Drawing.Point(0, 0);
            this.cbSelect.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbSelect.Name = "cbSelect";
            this.cbSelect.Size = new System.Drawing.Size(200, 27);
            this.cbSelect.TabIndex = 0;
            // 
            // FillSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbSelect);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FillSelect";
            this.Size = new System.Drawing.Size(200, 27);
            this.EnabledChanged += new System.EventHandler(this.FillSelect_EnabledChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSelect;
    }
}

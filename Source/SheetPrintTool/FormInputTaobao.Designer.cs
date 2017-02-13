namespace SheetPrintTool
{
    partial class FormInputTaobao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInputTaobao));
            this.label2 = new System.Windows.Forms.Label();
            this.pPreview = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton清空输入 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton添加任务 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton直接打印 = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pInput = new System.Windows.Forms.Panel();
            this.lState = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tbResName = new System.Windows.Forms.TextBox();
            this.cbDateTime = new System.Windows.Forms.CheckBox();
            this.tbTaobao = new System.Windows.Forms.TextBox();
            this.cbSelectInfo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.pInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "模版预览";
            // 
            // pPreview
            // 
            this.pPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPreview.Location = new System.Drawing.Point(5, 285);
            this.pPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pPreview.Name = "pPreview";
            this.pPreview.Size = new System.Drawing.Size(600, 300);
            this.pPreview.TabIndex = 5;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton清空输入,
            this.toolStripButton添加任务,
            this.toolStripButton直接打印});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(610, 28);
            this.toolStrip.TabIndex = 7;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton清空输入
            // 
            this.toolStripButton清空输入.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton清空输入.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton清空输入.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton清空输入.Image")));
            this.toolStripButton清空输入.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton清空输入.Name = "toolStripButton清空输入";
            this.toolStripButton清空输入.Size = new System.Drawing.Size(78, 25);
            this.toolStripButton清空输入.Text = "清空输入";
            this.toolStripButton清空输入.Click += new System.EventHandler(this.toolStripButton清空输入_Click);
            // 
            // toolStripButton添加任务
            // 
            this.toolStripButton添加任务.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton添加任务.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton添加任务.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton添加任务.Image")));
            this.toolStripButton添加任务.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton添加任务.Name = "toolStripButton添加任务";
            this.toolStripButton添加任务.Size = new System.Drawing.Size(78, 25);
            this.toolStripButton添加任务.Text = "添加任务";
            this.toolStripButton添加任务.Click += new System.EventHandler(this.toolStripButton添加任务_Click);
            // 
            // toolStripButton直接打印
            // 
            this.toolStripButton直接打印.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton直接打印.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton直接打印.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton直接打印.Image")));
            this.toolStripButton直接打印.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton直接打印.Name = "toolStripButton直接打印";
            this.toolStripButton直接打印.Size = new System.Drawing.Size(78, 25);
            this.toolStripButton直接打印.Text = "直接打印";
            this.toolStripButton直接打印.Click += new System.EventHandler(this.toolStripButton直接打印_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "数据输入";
            // 
            // pInput
            // 
            this.pInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pInput.AutoScroll = true;
            this.pInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInput.Controls.Add(this.lState);
            this.pInput.Controls.Add(this.dateTimePicker);
            this.pInput.Controls.Add(this.tbResName);
            this.pInput.Controls.Add(this.cbDateTime);
            this.pInput.Controls.Add(this.tbTaobao);
            this.pInput.Controls.Add(this.cbSelectInfo);
            this.pInput.Controls.Add(this.label6);
            this.pInput.Controls.Add(this.label5);
            this.pInput.Controls.Add(this.label4);
            this.pInput.Controls.Add(this.label3);
            this.pInput.Location = new System.Drawing.Point(5, 55);
            this.pInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pInput.Name = "pInput";
            this.pInput.Size = new System.Drawing.Size(600, 205);
            this.pInput.TabIndex = 8;
            // 
            // lState
            // 
            this.lState.AutoSize = true;
            this.lState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lState.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lState.ForeColor = System.Drawing.Color.Red;
            this.lState.Location = new System.Drawing.Point(10, 70);
            this.lState.Name = "lState";
            this.lState.Size = new System.Drawing.Size(61, 19);
            this.lState.TabIndex = 7;
            this.lState.Text = "格式错误";
            this.lState.Click += new System.EventHandler(this.lState_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy年MM月dd日HH时";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(120, 170);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker.TabIndex = 6;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // tbResName
            // 
            this.tbResName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResName.Enabled = false;
            this.tbResName.Location = new System.Drawing.Point(120, 135);
            this.tbResName.Name = "tbResName";
            this.tbResName.Size = new System.Drawing.Size(460, 25);
            this.tbResName.TabIndex = 5;
            this.tbResName.TextChanged += new System.EventHandler(this.tbResName_TextChanged);
            // 
            // cbDateTime
            // 
            this.cbDateTime.AutoSize = true;
            this.cbDateTime.Enabled = false;
            this.cbDateTime.Location = new System.Drawing.Point(330, 170);
            this.cbDateTime.Name = "cbDateTime";
            this.cbDateTime.Size = new System.Drawing.Size(54, 23);
            this.cbDateTime.TabIndex = 4;
            this.cbDateTime.Text = "显示";
            this.cbDateTime.UseVisualStyleBackColor = true;
            this.cbDateTime.CheckedChanged += new System.EventHandler(this.cbDateTime_CheckedChanged);
            // 
            // tbTaobao
            // 
            this.tbTaobao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTaobao.Location = new System.Drawing.Point(120, 45);
            this.tbTaobao.Multiline = true;
            this.tbTaobao.Name = "tbTaobao";
            this.tbTaobao.Size = new System.Drawing.Size(460, 80);
            this.tbTaobao.TabIndex = 3;
            this.tbTaobao.TextChanged += new System.EventHandler(this.tbTaobao_TextChanged);
            // 
            // cbSelectInfo
            // 
            this.cbSelectInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectInfo.FormattingEnabled = true;
            this.cbSelectInfo.Location = new System.Drawing.Point(120, 10);
            this.cbSelectInfo.Name = "cbSelectInfo";
            this.cbSelectInfo.Size = new System.Drawing.Size(460, 27);
            this.cbSelectInfo.TabIndex = 2;
            this.cbSelectInfo.SelectedIndexChanged += new System.EventHandler(this.cbSelectInfo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "寄件时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "物品名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "淘宝物流格式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "使用信息模版";
            // 
            // FormInputTaobao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 590);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pInput);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pPreview);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(626, 629);
            this.Name = "FormInputTaobao";
            this.Text = "数据录入 - 淘宝中国物流格式";
            this.Load += new System.EventHandler(this.FormInputTaobao_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.pInput.ResumeLayout(false);
            this.pInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pPreview;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton清空输入;
        private System.Windows.Forms.ToolStripButton toolStripButton添加任务;
        private System.Windows.Forms.ToolStripButton toolStripButton直接打印;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSelectInfo;
        private System.Windows.Forms.TextBox tbTaobao;
        private System.Windows.Forms.CheckBox cbDateTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbResName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label lState;
    }
}
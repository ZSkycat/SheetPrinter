namespace SheetPrinter.Plugin.Default
{
    partial class ModeTaobao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModeTaobao));
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.pInput = new System.Windows.Forms.Panel();
            this.lState = new System.Windows.Forms.Label();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.tbTaobao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbAddTask = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveTask = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.dateTimeCheck = new SheetPrinter.Core.Form.DateTimeCheck();
            this.fillSelect = new SheetPrinter.Core.Form.FillSelect();
            this.preview = new SheetPrinter.Core.Form.SheetPreview();
            this.gbInput.SuspendLayout();
            this.pInput.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInput
            // 
            this.gbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInput.Controls.Add(this.pInput);
            this.gbInput.Location = new System.Drawing.Point(5, 30);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(575, 205);
            this.gbInput.TabIndex = 3;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "数据输入";
            // 
            // pInput
            // 
            this.pInput.AutoScroll = true;
            this.pInput.Controls.Add(this.lState);
            this.pInput.Controls.Add(this.dateTimeCheck);
            this.pInput.Controls.Add(this.tbItemName);
            this.pInput.Controls.Add(this.tbTaobao);
            this.pInput.Controls.Add(this.fillSelect);
            this.pInput.Controls.Add(this.label4);
            this.pInput.Controls.Add(this.label3);
            this.pInput.Controls.Add(this.label2);
            this.pInput.Controls.Add(this.label1);
            this.pInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pInput.Location = new System.Drawing.Point(3, 21);
            this.pInput.Name = "pInput";
            this.pInput.Size = new System.Drawing.Size(569, 181);
            this.pInput.TabIndex = 3;
            // 
            // lState
            // 
            this.lState.AutoSize = true;
            this.lState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lState.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lState.ForeColor = System.Drawing.Color.Red;
            this.lState.Location = new System.Drawing.Point(5, 65);
            this.lState.Name = "lState";
            this.lState.Size = new System.Drawing.Size(61, 19);
            this.lState.TabIndex = 8;
            this.lState.Text = "格式错误";
            this.lState.Click += new System.EventHandler(this.lState_Click);
            // 
            // tbItemName
            // 
            this.tbItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbItemName.Enabled = false;
            this.tbItemName.Location = new System.Drawing.Point(150, 110);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(410, 25);
            this.tbItemName.TabIndex = 4;
            this.tbItemName.TextChanged += new System.EventHandler(this.tbItemName_TextChanged);
            // 
            // tbTaobao
            // 
            this.tbTaobao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTaobao.Location = new System.Drawing.Point(150, 35);
            this.tbTaobao.Multiline = true;
            this.tbTaobao.Name = "tbTaobao";
            this.tbTaobao.Size = new System.Drawing.Size(410, 65);
            this.tbTaobao.TabIndex = 4;
            this.tbTaobao.TextChanged += new System.EventHandler(this.tbTaobao_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "寄件时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "物品名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "淘宝物流格式";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "填充您的数据";
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClear,
            this.tsbPrint,
            this.tsbAddTask,
            this.tsbSaveTask,
            this.tsbDelete});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(584, 28);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsbClear
            // 
            this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(46, 25);
            this.tsbClear.Text = "清空";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(46, 25);
            this.tsbPrint.Text = "打印";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbAddTask
            // 
            this.tsbAddTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddTask.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddTask.Image")));
            this.tsbAddTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddTask.Name = "tsbAddTask";
            this.tsbAddTask.Size = new System.Drawing.Size(94, 25);
            this.tsbAddTask.Text = "添加新任务";
            this.tsbAddTask.Click += new System.EventHandler(this.tsbAddTask_Click);
            // 
            // tsbSaveTask
            // 
            this.tsbSaveTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSaveTask.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveTask.Image")));
            this.tsbSaveTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveTask.Name = "tsbSaveTask";
            this.tsbSaveTask.Size = new System.Drawing.Size(94, 25);
            this.tsbSaveTask.Text = "保存此任务";
            this.tsbSaveTask.Click += new System.EventHandler(this.tsbSaveTask_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(94, 25);
            this.tsbDelete.Text = "删除此任务";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // dateTimeCheck
            // 
            this.dateTimeCheck.Enabled = false;
            this.dateTimeCheck.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.dateTimeCheck.Location = new System.Drawing.Point(150, 145);
            this.dateTimeCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimeCheck.Name = "dateTimeCheck";
            this.dateTimeCheck.Size = new System.Drawing.Size(250, 25);
            this.dateTimeCheck.TabIndex = 5;
            // 
            // fillSelect
            // 
            this.fillSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fillSelect.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.fillSelect.Location = new System.Drawing.Point(150, 0);
            this.fillSelect.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.fillSelect.Name = "fillSelect";
            this.fillSelect.Size = new System.Drawing.Size(410, 27);
            this.fillSelect.TabIndex = 2;
            // 
            // preview
            // 
            this.preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preview.AutoScroll = true;
            this.preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.preview.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.preview.Location = new System.Drawing.Point(0, 240);
            this.preview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(585, 271);
            this.preview.TabIndex = 0;
            // 
            // ModeTaobao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.preview);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ModeTaobao";
            this.Text = "淘宝地址格式";
            this.gbInput.ResumeLayout(false);
            this.pInput.ResumeLayout(false);
            this.pInput.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Core.Form.SheetPreview preview;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.Panel pInput;
        private Core.Form.FillSelect fillSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbAddTask;
        private System.Windows.Forms.ToolStripButton tsbSaveTask;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.TextBox tbTaobao;
        private Core.Form.DateTimeCheck dateTimeCheck;
        private System.Windows.Forms.Label lState;
    }
}
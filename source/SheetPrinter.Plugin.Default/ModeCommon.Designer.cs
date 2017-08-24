namespace SheetPrinter.Plugin.Default
{
    partial class ModeCommon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModeCommon));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbAddTask = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveTask = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.pInput = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.fillSelect = new SheetPrinter.Core.Form.FillSelect();
            this.preview = new SheetPrinter.Core.Form.SheetPreview();
            this.toolStrip.SuspendLayout();
            this.gbInput.SuspendLayout();
            this.pInput.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStrip.TabIndex = 1;
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
            // gbInput
            // 
            this.gbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInput.Controls.Add(this.pInput);
            this.gbInput.Location = new System.Drawing.Point(5, 30);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(573, 250);
            this.gbInput.TabIndex = 2;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "数据输入";
            // 
            // pInput
            // 
            this.pInput.AutoScroll = true;
            this.pInput.Controls.Add(this.fillSelect);
            this.pInput.Controls.Add(this.label1);
            this.pInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pInput.Location = new System.Drawing.Point(3, 21);
            this.pInput.Name = "pInput";
            this.pInput.Size = new System.Drawing.Size(567, 226);
            this.pInput.TabIndex = 3;
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
            // fillSelect
            // 
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
            this.preview.Location = new System.Drawing.Point(0, 285);
            this.preview.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(584, 276);
            this.preview.TabIndex = 0;
            // 
            // ModeCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.preview);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ModeCommon";
            this.Text = "通用编辑";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.gbInput.ResumeLayout(false);
            this.pInput.ResumeLayout(false);
            this.pInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Core.Form.SheetPreview preview;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.ToolStripButton tsbAddTask;
        private System.Windows.Forms.Label label1;
        private Core.Form.FillSelect fillSelect;
        private System.Windows.Forms.Panel pInput;
        private System.Windows.Forms.ToolStripButton tsbSaveTask;
        private System.Windows.Forms.ToolStripButton tsbDelete;
    }
}
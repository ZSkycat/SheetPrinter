﻿namespace SheetPrintTool
{
    partial class FormInputCommon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInputCommon));
            this.pInput = new System.Windows.Forms.Panel();
            this.cbSelectSender = new System.Windows.Forms.ComboBox();
            this.pPreview = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton清空输入 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton添加任务 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton直接打印 = new System.Windows.Forms.ToolStripButton();
            this.pInput.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pInput
            // 
            this.pInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pInput.AutoScroll = true;
            this.pInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInput.Controls.Add(this.cbSelectSender);
            this.pInput.Location = new System.Drawing.Point(5, 55);
            this.pInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pInput.Name = "pInput";
            this.pInput.Size = new System.Drawing.Size(600, 200);
            this.pInput.TabIndex = 3;
            // 
            // cbSelectSender
            // 
            this.cbSelectSender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectSender.FormattingEnabled = true;
            this.cbSelectSender.Items.AddRange(new object[] {
            "点击填充寄件人"});
            this.cbSelectSender.Location = new System.Drawing.Point(10, 10);
            this.cbSelectSender.Name = "cbSelectSender";
            this.cbSelectSender.Size = new System.Drawing.Size(140, 27);
            this.cbSelectSender.TabIndex = 0;
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
            this.pPreview.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "数据输入";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "模版预览";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton清空输入,
            this.toolStripButton添加任务,
            this.toolStripButton直接打印});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(610, 28);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
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
            // FormInputCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 590);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pPreview);
            this.Controls.Add(this.pInput);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(626, 629);
            this.Name = "FormInputCommon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据输入 - 通用编辑模式";
            this.Load += new System.EventHandler(this.FormInputCommon_Load);
            this.pInput.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pInput;
        private System.Windows.Forms.Panel pPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton清空输入;
        private System.Windows.Forms.ToolStripButton toolStripButton添加任务;
        private System.Windows.Forms.ToolStripButton toolStripButton直接打印;
        private System.Windows.Forms.ComboBox cbSelectSender;
    }
}
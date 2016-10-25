namespace SheetPrintTool
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem填写寄件人 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem清空信息 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem添加任务 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem直接打印 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem填写寄件人,
            this.toolStripMenuItem清空信息,
            this.toolStripMenuItem添加任务,
            this.toolStripMenuItem直接打印});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(789, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem填写寄件人
            // 
            this.toolStripMenuItem填写寄件人.Name = "toolStripMenuItem填写寄件人";
            this.toolStripMenuItem填写寄件人.Size = new System.Drawing.Size(80, 21);
            this.toolStripMenuItem填写寄件人.Text = "填写寄件人";
            // 
            // toolStripMenuItem清空信息
            // 
            this.toolStripMenuItem清空信息.Name = "toolStripMenuItem清空信息";
            this.toolStripMenuItem清空信息.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenuItem清空信息.Text = "清空信息";
            // 
            // toolStripMenuItem添加任务
            // 
            this.toolStripMenuItem添加任务.Name = "toolStripMenuItem添加任务";
            this.toolStripMenuItem添加任务.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenuItem添加任务.Text = "添加任务";
            // 
            // toolStripMenuItem直接打印
            // 
            this.toolStripMenuItem直接打印.Name = "toolStripMenuItem直接打印";
            this.toolStripMenuItem直接打印.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenuItem直接打印.Text = "直接打印";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(50, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(200, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 380);
            this.panel1.TabIndex = 3;
            // 
            // FormInputCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 446);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormInputCommon";
            this.Text = "任务控制台 - ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem填写寄件人;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem清空信息;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem添加任务;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem直接打印;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}
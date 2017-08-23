namespace SheetPrinter
{
    partial class FormConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.bTool = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOffsetX = new System.Windows.Forms.TextBox();
            this.tbOffsetY = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "打印机偏移";
            // 
            // bTool
            // 
            this.bTool.Location = new System.Drawing.Point(10, 105);
            this.bTool.Name = "bTool";
            this.bTool.Size = new System.Drawing.Size(110, 30);
            this.bTool.TabIndex = 1;
            this.bTool.Text = "打印机辅助工具";
            this.bTool.UseVisualStyleBackColor = true;
            this.bTool.Click += new System.EventHandler(this.bTool_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "X 偏移";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Y 偏移";
            // 
            // tbOffsetX
            // 
            this.tbOffsetX.Location = new System.Drawing.Point(105, 35);
            this.tbOffsetX.Name = "tbOffsetX";
            this.tbOffsetX.Size = new System.Drawing.Size(100, 25);
            this.tbOffsetX.TabIndex = 2;
            // 
            // tbOffsetY
            // 
            this.tbOffsetY.Location = new System.Drawing.Point(105, 70);
            this.tbOffsetY.Name = "tbOffsetY";
            this.tbOffsetY.Size = new System.Drawing.Size(100, 25);
            this.tbOffsetY.TabIndex = 2;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(135, 105);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(70, 30);
            this.bSave.TabIndex = 3;
            this.bSave.Text = "保存";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 147);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbOffsetY);
            this.Controls.Add(this.tbOffsetX);
            this.Controls.Add(this.bTool);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打印配置";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bTool;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOffsetX;
        private System.Windows.Forms.TextBox tbOffsetY;
        private System.Windows.Forms.Button bSave;
    }
}
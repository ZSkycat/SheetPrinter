namespace PrinterHelper
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bScalePrint = new System.Windows.Forms.Button();
            this.cbScaleHalf = new System.Windows.Forms.CheckBox();
            this.tbScaleLength = new System.Windows.Forms.TextBox();
            this.tbScaleSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.bGridPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.cbScaleWidth = new System.Windows.Forms.CheckBox();
            this.cbScaleHeight = new System.Windows.Forms.CheckBox();
            this.cbScaleNumber = new System.Windows.Forms.CheckBox();
            this.tbGridSize = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(95, 10);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(100, 25);
            this.tbWidth.TabIndex = 0;
            this.tbWidth.Text = "230";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(285, 285);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.bScalePrint);
            this.tabPage1.Controls.Add(this.cbScaleNumber);
            this.tabPage1.Controls.Add(this.cbScaleHeight);
            this.tabPage1.Controls.Add(this.cbScaleWidth);
            this.tabPage1.Controls.Add(this.cbScaleHalf);
            this.tabPage1.Controls.Add(this.tbScaleLength);
            this.tabPage1.Controls.Add(this.tbScaleSize);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(277, 253);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "宽高刻度尺";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bScalePrint
            // 
            this.bScalePrint.Location = new System.Drawing.Point(15, 150);
            this.bScalePrint.Name = "bScalePrint";
            this.bScalePrint.Size = new System.Drawing.Size(75, 30);
            this.bScalePrint.TabIndex = 3;
            this.bScalePrint.Text = "打印";
            this.bScalePrint.UseVisualStyleBackColor = true;
            this.bScalePrint.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // cbScaleHalf
            // 
            this.cbScaleHalf.AutoSize = true;
            this.cbScaleHalf.Checked = true;
            this.cbScaleHalf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbScaleHalf.Location = new System.Drawing.Point(15, 80);
            this.cbScaleHalf.Name = "cbScaleHalf";
            this.cbScaleHalf.Size = new System.Drawing.Size(67, 23);
            this.cbScaleHalf.TabIndex = 2;
            this.cbScaleHalf.Text = "半刻度";
            this.cbScaleHalf.UseVisualStyleBackColor = true;
            // 
            // tbScaleLength
            // 
            this.tbScaleLength.Location = new System.Drawing.Point(150, 45);
            this.tbScaleLength.Name = "tbScaleLength";
            this.tbScaleLength.Size = new System.Drawing.Size(100, 25);
            this.tbScaleLength.TabIndex = 1;
            this.tbScaleLength.Text = "10";
            // 
            // tbScaleSize
            // 
            this.tbScaleSize.Location = new System.Drawing.Point(150, 10);
            this.tbScaleSize.Name = "tbScaleSize";
            this.tbScaleSize.Size = new System.Drawing.Size(100, 25);
            this.tbScaleSize.TabIndex = 1;
            this.tbScaleSize.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "刻度线长度 (mm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "刻度间距 (mm)";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.bGridPrint);
            this.tabPage2.Controls.Add(this.tbGridSize);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(277, 253);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "简易网格";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "网格间距 (mm)";
            // 
            // bGridPrint
            // 
            this.bGridPrint.Location = new System.Drawing.Point(15, 45);
            this.bGridPrint.Name = "bGridPrint";
            this.bGridPrint.Size = new System.Drawing.Size(75, 30);
            this.bGridPrint.TabIndex = 3;
            this.bGridPrint.Text = "打印";
            this.bGridPrint.UseVisualStyleBackColor = true;
            this.bGridPrint.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "宽度 (mm)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "高度 (mm)";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(95, 45);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(100, 25);
            this.tbHeight.TabIndex = 0;
            this.tbHeight.Text = "127";
            // 
            // cbScaleWidth
            // 
            this.cbScaleWidth.AutoSize = true;
            this.cbScaleWidth.Checked = true;
            this.cbScaleWidth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbScaleWidth.Location = new System.Drawing.Point(15, 115);
            this.cbScaleWidth.Name = "cbScaleWidth";
            this.cbScaleWidth.Size = new System.Drawing.Size(93, 23);
            this.cbScaleWidth.TabIndex = 2;
            this.cbScaleWidth.Text = "水平刻度尺";
            this.cbScaleWidth.UseVisualStyleBackColor = true;
            // 
            // cbScaleHeight
            // 
            this.cbScaleHeight.AutoSize = true;
            this.cbScaleHeight.Location = new System.Drawing.Point(150, 115);
            this.cbScaleHeight.Name = "cbScaleHeight";
            this.cbScaleHeight.Size = new System.Drawing.Size(93, 23);
            this.cbScaleHeight.TabIndex = 2;
            this.cbScaleHeight.Text = "垂直刻度尺";
            this.cbScaleHeight.UseVisualStyleBackColor = true;
            // 
            // cbScaleNumber
            // 
            this.cbScaleNumber.AutoSize = true;
            this.cbScaleNumber.Checked = true;
            this.cbScaleNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbScaleNumber.Location = new System.Drawing.Point(150, 80);
            this.cbScaleNumber.Name = "cbScaleNumber";
            this.cbScaleNumber.Size = new System.Drawing.Size(67, 23);
            this.cbScaleNumber.TabIndex = 2;
            this.cbScaleNumber.Text = "刻度值";
            this.cbScaleNumber.UseVisualStyleBackColor = true;
            // 
            // tbGridSize
            // 
            this.tbGridSize.Location = new System.Drawing.Point(150, 10);
            this.tbGridSize.Name = "tbGridSize";
            this.tbGridSize.Size = new System.Drawing.Size(100, 25);
            this.tbGridSize.TabIndex = 1;
            this.tbGridSize.Text = "30";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.tbWidth);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "打印机助手";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbScaleSize;
        private System.Windows.Forms.CheckBox cbScaleHalf;
        private System.Windows.Forms.TextBox tbScaleLength;
        private System.Windows.Forms.Button bScalePrint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bGridPrint;
        private System.Windows.Forms.CheckBox cbScaleHeight;
        private System.Windows.Forms.CheckBox cbScaleWidth;
        private System.Windows.Forms.CheckBox cbScaleNumber;
        private System.Windows.Forms.TextBox tbGridSize;
    }
}


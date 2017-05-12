namespace SheetPrinter
{
    partial class FormInfoManage
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
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pInput = new System.Windows.Forms.Panel();
            this.bDelete = new System.Windows.Forms.Button();
            this.lState = new System.Windows.Forms.Label();
            this.bNewCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.ItemHeight = 19;
            this.lbInfo.Location = new System.Drawing.Point(10, 70);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(200, 384);
            this.lbInfo.TabIndex = 0;
            this.lbInfo.SelectedIndexChanged += new System.EventHandler(this.lbInfo_SelectedIndexChanged);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(265, 10);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 30);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "保存";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bNew
            // 
            this.bNew.Location = new System.Drawing.Point(95, 10);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(75, 30);
            this.bNew.TabIndex = 1;
            this.bNew.Text = "新建";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "填充信息列表（选中修改）";
            // 
            // pInput
            // 
            this.pInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pInput.AutoScroll = true;
            this.pInput.Location = new System.Drawing.Point(215, 70);
            this.pInput.Name = "pInput";
            this.pInput.Size = new System.Drawing.Size(420, 394);
            this.pInput.TabIndex = 3;
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(10, 10);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(75, 30);
            this.bDelete.TabIndex = 1;
            this.bDelete.Text = "删除";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // lState
            // 
            this.lState.AutoSize = true;
            this.lState.ForeColor = System.Drawing.Color.Blue;
            this.lState.Location = new System.Drawing.Point(220, 45);
            this.lState.Name = "lState";
            this.lState.Size = new System.Drawing.Size(38, 19);
            this.lState.TabIndex = 2;
            this.lState.Text = "新建:";
            // 
            // bNewCopy
            // 
            this.bNewCopy.Location = new System.Drawing.Point(180, 10);
            this.bNewCopy.Name = "bNewCopy";
            this.bNewCopy.Size = new System.Drawing.Size(75, 30);
            this.bNewCopy.TabIndex = 1;
            this.bNewCopy.Text = "新建副本";
            this.bNewCopy.UseVisualStyleBackColor = true;
            this.bNewCopy.Click += new System.EventHandler(this.bNewCopy_Click);
            // 
            // FormInfoManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.pInput);
            this.Controls.Add(this.lState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bNew);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bNewCopy);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.lbInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(650, 500);
            this.Name = "FormInfoManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "信息管理";
            this.Load += new System.EventHandler(this.FormInfoManage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbInfo;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pInput;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Label lState;
        private System.Windows.Forms.Button bNewCopy;
    }
}
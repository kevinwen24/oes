namespace OESUI.customer
{
    partial class NoticeDataLineControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRestDateInfo = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLineExamName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLineIndex = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblLineIndex);
            this.panel1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 40);
            this.panel1.TabIndex = 0;
            // 
            // lblRestDateInfo
            // 
            this.lblRestDateInfo.AutoSize = true;
            this.lblRestDateInfo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRestDateInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblRestDateInfo.Location = new System.Drawing.Point(56, 0);
            this.lblRestDateInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRestDateInfo.Name = "lblRestDateInfo";
            this.lblRestDateInfo.Size = new System.Drawing.Size(61, 16);
            this.lblRestDateInfo.TabIndex = 3;
            this.lblRestDateInfo.Text = "exam on";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.lblLineExamName);
            this.flowLayoutPanel1.Controls.Add(this.lblRestDateInfo);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(142, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(121, 22);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // lblLineExamName
            // 
            this.lblLineExamName.AutoSize = true;
            this.lblLineExamName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLineExamName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.lblLineExamName.Location = new System.Drawing.Point(3, 0);
            this.lblLineExamName.Name = "lblLineExamName";
            this.lblLineExamName.Size = new System.Drawing.Size(46, 16);
            this.lblLineExamName.TabIndex = 0;
            this.lblLineExamName.Text = "label2";
            this.lblLineExamName.Click += new System.EventHandler(this.DoLblLineExamNameOnClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.label1.Location = new System.Drawing.Point(26, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please attend the ";
            // 
            // lblLineIndex
            // 
            this.lblLineIndex.AutoSize = true;
            this.lblLineIndex.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLineIndex.Location = new System.Drawing.Point(7, 13);
            this.lblLineIndex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLineIndex.Name = "lblLineIndex";
            this.lblLineIndex.Size = new System.Drawing.Size(20, 16);
            this.lblLineIndex.TabIndex = 0;
            this.lblLineIndex.Text = "1.";
            // 
            // NoticeDataLineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NoticeDataLineControl";
            this.Size = new System.Drawing.Size(634, 40);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLineIndex;
        private System.Windows.Forms.Label lblRestDateInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblLineExamName;
        private System.Windows.Forms.Label label1;
    }
}

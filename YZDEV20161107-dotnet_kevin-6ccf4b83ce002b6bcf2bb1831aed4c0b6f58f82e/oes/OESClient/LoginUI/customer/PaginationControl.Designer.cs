namespace OESUI.customer
{
    partial class PaginationControl
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpPageIdex = new System.Windows.Forms.FlowLayoutPanel();
            this.picNextPage = new System.Windows.Forms.PictureBox();
            this.cbxContent = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtGoContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picPrevPage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNextPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrevPage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.picPrevPage);
            this.panel1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.panel1.Location = new System.Drawing.Point(41, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 57);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.flpPageIdex);
            this.flowLayoutPanel2.Controls.Add(this.picNextPage);
            this.flowLayoutPanel2.Controls.Add(this.cbxContent);
            this.flowLayoutPanel2.Controls.Add(this.label18);
            this.flowLayoutPanel2.Controls.Add(this.txtGoContent);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(232, 8);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(382, 33);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // flpPageIdex
            // 
            this.flpPageIdex.AutoSize = true;
            this.flpPageIdex.BackColor = System.Drawing.Color.White;
            this.flpPageIdex.Location = new System.Drawing.Point(3, 5);
            this.flpPageIdex.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.flpPageIdex.Name = "flpPageIdex";
            this.flpPageIdex.Size = new System.Drawing.Size(0, 0);
            this.flpPageIdex.TabIndex = 4;
            // 
            // picNextPage
            // 
            this.picNextPage.BackgroundImage = global::OESUI.Properties.Resources.BTN_PageRight_20x15_png_;
            this.picNextPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNextPage.Location = new System.Drawing.Point(9, 7);
            this.picNextPage.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.picNextPage.Name = "picNextPage";
            this.picNextPage.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.picNextPage.Size = new System.Drawing.Size(22, 20);
            this.picNextPage.TabIndex = 7;
            this.picNextPage.TabStop = false;
            this.picNextPage.Click += new System.EventHandler(this.DoPicNextPageOnClick);
            // 
            // cbxContent
            // 
            this.cbxContent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxContent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxContent.FormattingEnabled = true;
            this.cbxContent.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "10"});
            this.cbxContent.Location = new System.Drawing.Point(37, 3);
            this.cbxContent.Name = "cbxContent";
            this.cbxContent.Size = new System.Drawing.Size(30, 23);
            this.cbxContent.TabIndex = 8;
            this.cbxContent.SelectedIndexChanged += new System.EventHandler(this.DoCbOnSelectedIndexChange);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label18.Location = new System.Drawing.Point(73, 0);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label18.Size = new System.Drawing.Size(66, 21);
            this.label18.TabIndex = 9;
            this.label18.Text = "Per page";
            // 
            // txtGoContent
            // 
            this.txtGoContent.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtGoContent.Location = new System.Drawing.Point(145, 4);
            this.txtGoContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.txtGoContent.Name = "txtGoContent";
            this.txtGoContent.Size = new System.Drawing.Size(18, 19);
            this.txtGoContent.TabIndex = 10;
            this.txtGoContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoTxtGoContentOnKeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(169, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Go";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.DolblGoOnClick);
            // 
            // picPrevPage
            // 
            this.picPrevPage.BackgroundImage = global::OESUI.Properties.Resources.BTN_PageLeft_20x15_png;
            this.picPrevPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picPrevPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPrevPage.Location = new System.Drawing.Point(210, 16);
            this.picPrevPage.Name = "picPrevPage";
            this.picPrevPage.Size = new System.Drawing.Size(25, 19);
            this.picPrevPage.TabIndex = 6;
            this.picPrevPage.TabStop = false;
            this.picPrevPage.Click += new System.EventHandler(this.DoPicPrevPageOnClick);
            // 
            // PaginationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "PaginationControl";
            this.Size = new System.Drawing.Size(918, 63);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNextPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrevPage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picNextPage;
        private System.Windows.Forms.FlowLayoutPanel flpPageIdex;
        private System.Windows.Forms.PictureBox picPrevPage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ComboBox cbxContent;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtGoContent;
        private System.Windows.Forms.Label label1;
    }
}

namespace OESUI
{
    partial class ExamStudentResult
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamStudentResult));
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlMainData = new System.Windows.Forms.Panel();
            this.lblplaceholder = new System.Windows.Forms.Label();
            this.txtSearchContent = new System.Windows.Forms.TextBox();
            this.pnlPaginationContainer = new System.Windows.Forms.Panel();
            this.pnlDataContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitleId = new System.Windows.Forms.Label();
            this.lblTitleResult = new System.Windows.Forms.Label();
            this.ilstSortImgColl = new System.Windows.Forms.ImageList(this.components);
            this.lblTitleUserName = new System.Windows.Forms.Label();
            this.lblTitleRate = new System.Windows.Forms.Label();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.pnlBodyContainer.SuspendLayout();
            this.pnlNaviation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblNavUserPic)).BeginInit();
            this.pnlMainData.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBodyContainer
            // 
            this.pnlBodyContainer.Controls.Add(this.pnlMainData);
            this.pnlBodyContainer.Controls.SetChildIndex(this.pnlNaviation, 0);
            this.pnlBodyContainer.Controls.SetChildIndex(this.pnlMainData, 0);
            this.pnlBodyContainer.Controls.SetChildIndex(this.pnlAlertWindow, 0);
            // 
            // pnlNaviation
            // 
            this.pnlNaviation.Controls.Add(this.panel3);
            this.pnlNaviation.Controls.SetChildIndex(this.lblNavHome, 0);
            this.pnlNaviation.Controls.SetChildIndex(this.lblNavMyExam, 0);
            this.pnlNaviation.Controls.SetChildIndex(this.lblNameAndPhonebg, 0);
            this.pnlNaviation.Controls.SetChildIndex(this.lblNavUserPic, 0);
            this.pnlNaviation.Controls.SetChildIndex(this.lblNavName, 0);
            this.pnlNaviation.Controls.SetChildIndex(this.panel3, 0);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.panel3.Location = new System.Drawing.Point(0, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1024, 40);
            this.panel3.TabIndex = 2;
            // 
            // pnlMainData
            // 
            this.pnlMainData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainData.BackColor = System.Drawing.Color.White;
            this.pnlMainData.Controls.Add(this.lblplaceholder);
            this.pnlMainData.Controls.Add(this.txtSearchContent);
            this.pnlMainData.Controls.Add(this.pnlPaginationContainer);
            this.pnlMainData.Controls.Add(this.pnlDataContainer);
            this.pnlMainData.Controls.Add(this.tableLayoutPanel2);
            this.pnlMainData.Controls.Add(this.picSearch);
            this.pnlMainData.Controls.Add(this.shapeContainer1);
            this.pnlMainData.Location = new System.Drawing.Point(30, 44);
            this.pnlMainData.Name = "pnlMainData";
            this.pnlMainData.Size = new System.Drawing.Size(957, 675);
            this.pnlMainData.TabIndex = 2;
            this.pnlMainData.Click += new System.EventHandler(this.DoLblplaceholderOnClick);
            // 
            // lblplaceholder
            // 
            this.lblplaceholder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblplaceholder.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblplaceholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))));
            this.lblplaceholder.Location = new System.Drawing.Point(53, 50);
            this.lblplaceholder.Name = "lblplaceholder";
            this.lblplaceholder.Size = new System.Drawing.Size(124, 17);
            this.lblplaceholder.TabIndex = 34;
            this.lblplaceholder.Tag = "";
            this.lblplaceholder.Text = "Please input keyword";
            this.lblplaceholder.Click += new System.EventHandler(this.DoLblplaceholderOnClick);
            // 
            // txtSearchContent
            // 
            this.txtSearchContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchContent.CausesValidation = false;
            this.txtSearchContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.txtSearchContent.Location = new System.Drawing.Point(57, 50);
            this.txtSearchContent.Name = "txtSearchContent";
            this.txtSearchContent.Size = new System.Drawing.Size(125, 14);
            this.txtSearchContent.TabIndex = 4;
            this.txtSearchContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoTxtSearchContentOnKeyDown);
            this.txtSearchContent.Leave += new System.EventHandler(this.DoTxtSearchContentOnLeave);
            // 
            // pnlPaginationContainer
            // 
            this.pnlPaginationContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPaginationContainer.Location = new System.Drawing.Point(20, 532);
            this.pnlPaginationContainer.Name = "pnlPaginationContainer";
            this.pnlPaginationContainer.Size = new System.Drawing.Size(907, 68);
            this.pnlPaginationContainer.TabIndex = 29;
            // 
            // pnlDataContainer
            // 
            this.pnlDataContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDataContainer.BackColor = System.Drawing.Color.White;
            this.pnlDataContainer.Location = new System.Drawing.Point(2, 128);
            this.pnlDataContainer.Name = "pnlDataContainer";
            this.pnlDataContainer.Size = new System.Drawing.Size(955, 352);
            this.pnlDataContainer.TabIndex = 28;
            this.pnlDataContainer.Enter += new System.EventHandler(this.DoTxtSearchContentOnEnter);
            this.pnlDataContainer.Leave += new System.EventHandler(this.DoTxtSearchContentOnLeave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.43187F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.21593F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.402516F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.587F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.93501F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.4088F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.612159F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.13417F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.16772F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lblTitleId, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTitleResult, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTitleUserName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTitleRate, 5, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 85);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(954, 40);
            this.tableLayoutPanel2.TabIndex = 37;
            // 
            // lblTitleId
            // 
            this.lblTitleId.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitleId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitleId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblTitleId.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleId.ImageIndex = 1;
            this.lblTitleId.Location = new System.Drawing.Point(366, 0);
            this.lblTitleId.Name = "lblTitleId";
            this.lblTitleId.Size = new System.Drawing.Size(95, 40);
            this.lblTitleId.TabIndex = 5;
            this.lblTitleId.Text = "Pass criteria";
            this.lblTitleId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleResult
            // 
            this.lblTitleResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitleResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitleResult.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitleResult.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleResult.ImageIndex = 1;
            this.lblTitleResult.ImageList = this.ilstSortImgColl;
            this.lblTitleResult.Location = new System.Drawing.Point(735, 0);
            this.lblTitleResult.Name = "lblTitleResult";
            this.lblTitleResult.Size = new System.Drawing.Size(68, 40);
            this.lblTitleResult.TabIndex = 7;
            this.lblTitleResult.Text = "Result";
            this.lblTitleResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitleResult.Click += new System.EventHandler(this.DoLblTitleResultOnClick);
            // 
            // ilstSortImgColl
            // 
            this.ilstSortImgColl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilstSortImgColl.ImageStream")));
            this.ilstSortImgColl.TransparentColor = System.Drawing.Color.Transparent;
            this.ilstSortImgColl.Images.SetKeyName(0, "ICN_Increase_10x15.png.png");
            this.ilstSortImgColl.Images.SetKeyName(1, "ICN_Decrese_10x15.png.png");
            this.ilstSortImgColl.Images.SetKeyName(2, "mybankImg10_15.png");
            // 
            // lblTitleUserName
            // 
            this.lblTitleUserName.BackColor = System.Drawing.Color.White;
            this.lblTitleUserName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitleUserName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitleUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblTitleUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleUserName.ImageIndex = 1;
            this.lblTitleUserName.ImageList = this.ilstSortImgColl;
            this.lblTitleUserName.Location = new System.Drawing.Point(217, 0);
            this.lblTitleUserName.Name = "lblTitleUserName";
            this.lblTitleUserName.Size = new System.Drawing.Size(88, 40);
            this.lblTitleUserName.TabIndex = 4;
            this.lblTitleUserName.Text = "Attendance";
            this.lblTitleUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitleUserName.Click += new System.EventHandler(this.DoLblTitleUserNameOnClick);
            // 
            // lblTitleRate
            // 
            this.lblTitleRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitleRate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitleRate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleRate.ImageIndex = 1;
            this.lblTitleRate.ImageList = this.ilstSortImgColl;
            this.lblTitleRate.Location = new System.Drawing.Point(495, 0);
            this.lblTitleRate.Name = "lblTitleRate";
            this.lblTitleRate.Size = new System.Drawing.Size(141, 40);
            this.lblTitleRate.TabIndex = 6;
            this.lblTitleRate.Text = "Exam/Total score";
            this.lblTitleRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitleRate.Click += new System.EventHandler(this.DoLblTitleRateOnClick);
            // 
            // picSearch
            // 
            this.picSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSearch.Image = global::OESUI.Properties.Resources.ICN_Search_15x20_png;
            this.picSearch.Location = new System.Drawing.Point(183, 47);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(27, 23);
            this.picSearch.TabIndex = 35;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.DoPicSearchOnClick);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(957, 675);
            this.shapeContainer1.TabIndex = 36;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 2;
            this.lineShape2.X2 = 953;
            this.lineShape2.Y1 = 125;
            this.lineShape2.Y2 = 125;
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 1;
            this.lineShape1.X2 = 955;
            this.lineShape1.Y1 = 84;
            this.lineShape1.Y2 = 84;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.rectangleShape1.CornerRadius = 3;
            this.rectangleShape1.Location = new System.Drawing.Point(50, 41);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(163, 32);
            // 
            // ExamStudentResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Name = "ExamStudentResult";
            this.Text = "ExamStudentDetail";
            this.pnlBodyContainer.ResumeLayout(false);
            this.pnlNaviation.ResumeLayout(false);
            this.pnlNaviation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblNavUserPic)).EndInit();
            this.pnlMainData.ResumeLayout(false);
            this.pnlMainData.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlMainData;
        private System.Windows.Forms.Label lblplaceholder;
        private System.Windows.Forms.PictureBox picSearch;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblTitleId;
        private System.Windows.Forms.Label lblTitleResult;
        private System.Windows.Forms.Label lblTitleUserName;
        private System.Windows.Forms.Label lblTitleRate;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Panel pnlPaginationContainer;
        private System.Windows.Forms.ImageList ilstSortImgColl;
        private System.Windows.Forms.TextBox txtSearchContent;
        private System.Windows.Forms.Panel pnlDataContainer;
    }
}
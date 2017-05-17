using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using OESModel;
using OESUtil;

namespace OESUI.customer
{
    public partial class PaginationControl : UserControl
    {
        private Pagination pagination;
        private List<string> pageIndexs;
        public delegate void FindAllExam(Pagination pagination, int userId);
        private FindAllExam findAllExam;
        private BaseWindowForm baseWindowForm = new BaseWindowForm();
        private static string showTxtGoContent = "";
        private static string showConboxContent = "10";

        public PaginationControl(Pagination pagination, FindAllExam findAllExam)
        {
            InitializeComponent();
            this.pagination = pagination;
            this.findAllExam = findAllExam;
            pageIndexs = PaginationUtil.GetPagingIndexString(pagination);
            InitializePaginationLabel();
        }

        private void InitializePaginationLabel()
        {
            for (int i = 0; i < pageIndexs.Count; i++ )
            {
                Label label = new Label();
                label.Margin = new Padding(1);
                label.AutoSize = true;
                label.Cursor = Cursors.Hand;
                label.ForeColor = Color.FromArgb(50, 50, 50);
                label.Text = pageIndexs[i];
                if(pageIndexs[i] == pagination.CurrentPage + "")
                {
                    label.ForeColor = Color.FromArgb(254, 153, 0);
                }

                if (pageIndexs[i] != "...")
                {
                    label.Click += new System.EventHandler(DoLblPagingIndexOnClick);
                }
                this.flpPageIdex.Controls.Add(label);
              
            }
            this.txtGoContent.Text = showTxtGoContent;
            this.cbxContent.SelectedText = showConboxContent;
        }

        private void DoPicPrevPageOnClick(object sender, EventArgs e)
        {
            if (!pagination.IsFirstPage())
            {
                pagination.CurrentPage = pagination.CurrentPage - 1;
                findAllExam.Invoke(pagination, SessionUtil.User.Id);
            }  
        }

        private void DoPicNextPageOnClick(object sender, EventArgs e)
        {
            if (!pagination.IsLastPage())
            {
                pagination.CurrentPage = pagination.CurrentPage + 1;
                findAllExam.Invoke(pagination, SessionUtil.User.Id);
            }
           
        }

        private void DoLblPagingIndexOnClick(object sender, EventArgs e)
        {
            Label lable = sender as Label;
            pagination.CurrentPage = int.Parse(lable.Text);
            findAllExam.Invoke(pagination, SessionUtil.User.Id);
        }

        private void DoCbOnSelectedIndexChange(object sender, EventArgs e)
        {
            pagination.PageSize = int.Parse(this.cbxContent.Text.Trim());
            showConboxContent = pagination.PageSize + "";
            pagination.CurrentPage = 1;
            findAllExam.Invoke(pagination, SessionUtil.User.Id);
        }

        private void DolblGoOnClick(object sender, EventArgs e)
        {
            string SkipPageString = this.txtGoContent.Text.Trim();
            showTxtGoContent = SkipPageString;
           

            if (string.IsNullOrWhiteSpace(SkipPageString) )
            {
                return;
            }

            bool isNum = Regex.IsMatch(SkipPageString, @"^\d*$");
            if (!isNum)
            {
                 baseWindowForm.showFlashMsg("please input illegal characters");
            }

            if (isNum)
            {
                int skipPageInt = int.Parse(SkipPageString);
                if (skipPageInt > pagination.PageCount)
                {
                    skipPageInt = pagination.PageCount;
                }
                pagination.CurrentPage = skipPageInt;
                findAllExam.Invoke(pagination, SessionUtil.User.Id);
            }
            
        }

        private void DoTxtGoContentOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DolblGoOnClick(sender, new EventArgs());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginUI
{
    public partial class BaseWindowForm : BaseMovingForm
    {
        public BaseWindowForm()
        {
            InitializeComponent(); 
            BindMovForForm(pnlFormTitle);
            BindMovForForm(lblonlineExamTitle);
            BindMovForForm(picLogo); 
        }

        private void DoPicMinOnClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DoPicMaxOnClick(object sender, EventArgs e)
        {
            if ( WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else {
                WindowState = FormWindowState.Normal;
            }
        }

        private void DoPicCloseOnClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
     
}

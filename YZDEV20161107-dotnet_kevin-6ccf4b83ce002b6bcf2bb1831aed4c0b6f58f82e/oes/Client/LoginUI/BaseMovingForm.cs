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
    public partial class BaseMovingForm : Form
    {

        private Point mouseOff;
        private bool leftFlag;

        public BaseMovingForm()
        {
            InitializeComponent();
        }

        public void DoFormTitleMouseDown(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X - control.Location.X, -e.Y- control.Location.Y);

                leftFlag = true;
            }
        }

        public void DoFormTitleMouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                this.Location = mouseSet;
            }
        }

        public void DoFormTitleMouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }

        public List<Control> GetAllControls(Control control)
        {
            List<Control> ConList = new List<Control>();
            foreach (Control con in control.Controls)
            {
                if (con is GroupBox)
                {
                    ConList.AddRange(GetAllControls(con));
                }
                else
                {
                    ConList.Add(con);
                }
            }
            return ConList;
        }

        public void BindMovForForm(Control c)
        {
            c.MouseMove += new MouseEventHandler(DoFormTitleMouseMove);
            c.MouseDown += new MouseEventHandler(DoFormTitleMouseDown);
            c.MouseUp += new MouseEventHandler(DoFormTitleMouseUp);
        }
    }
}

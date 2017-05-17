using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LoginUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm loginForm = new LoginForm();
           
            DialogResult result = loginForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                Application.Run(new ExamListForm());
               // Application.Run(new TakeExam());
            }
            else
            {
                Application.Exit();
            }
            
        }
    }
}

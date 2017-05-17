using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OESUtil;

namespace OESUI
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
                if (SessionUtil.User.RoleId == 4) 
                {
                    Application.Run(new StudentExamListForm());
                }

                if (SessionUtil.User.RoleId == 3)
                {
                    Application.Run(new TeacherExamListForm());
                }

            }
            else
            {
                Application.Exit();
            }
            
        }
    }
}

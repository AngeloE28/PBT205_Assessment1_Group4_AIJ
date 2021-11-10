using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBT205_Assessment1_Group4_AIJ
{
    static class Program
    {
        // Create an instance to control the login form
        public static LoginForm loginForm;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Create the instance to run
            loginForm = new LoginForm();
            Application.Run(loginForm);
            Application.Exit();
        }
    }
}

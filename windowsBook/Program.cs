using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using windowsBook;
namespace windowsBook
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());

            /* Application.Run(new enrollcs());*/
            UserSession.isexit = true;
            Application.Run(new Login());
            if (UserSession.isexit)
            {
                Application.Run(new Formuser());
            }
            if (UserSession.Isadmin)
            {
                Application.Run(new AdminA());
            }

            /*Application.Run(new AdminA());*/



        }
        
    }
}

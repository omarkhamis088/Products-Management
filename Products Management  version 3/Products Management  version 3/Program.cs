using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products_Management__version_3
{
    static class Program
    {
        public static string SalesMan;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
       
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PL.FRM_MAIN());
        }
    }
}

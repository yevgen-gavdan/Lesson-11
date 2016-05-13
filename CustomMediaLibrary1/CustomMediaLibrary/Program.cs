using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CustomMediaLibrary.Controllers;

namespace CustomMediaLibrary
{
    static class Program
    {
        static MediaLibraryController MainController;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainController = new MediaLibraryController();

            Application.Run(MainController.CreateView());
        }
    }
}

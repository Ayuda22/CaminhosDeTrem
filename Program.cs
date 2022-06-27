// André Y. Terada - 20122 Rafael L.Silva - 20734

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CaminhosDeTrem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmCaminhosDeTrem());
        }
    }
}
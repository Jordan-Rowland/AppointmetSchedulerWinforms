﻿using jordan_rowland_c969.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jordan_rowland_c969
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBInit.StartConnection();
            Global Global = new Global() { User = (0, "ERROR") };
            Application.Run(new MainForm(Global));
            DBInit.CloseConnection();
        }
    }
}

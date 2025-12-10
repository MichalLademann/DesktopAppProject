using System;
using System.Windows.Forms;
using TaskManagerDesktop.Data;

namespace TaskManagerDesktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            DatabaseHelper.InitializeDatabase();
            Application.Run(new Forms.MainForm());
        }
    }
}

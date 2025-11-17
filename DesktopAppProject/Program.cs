using System;
using System.Windows.Forms;

namespace DesktopAppProject
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // klasyczna inicjalizacja WinForms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());
        }
    }
}

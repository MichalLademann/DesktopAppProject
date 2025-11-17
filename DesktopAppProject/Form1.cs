using System;
using System.Windows.Forms;

namespace DesktopAppProject
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;

        public Form1()
        {
            InitializeComponent();

            // Inicjalizacja timera (ograniczona funkcjonalność)
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelStatus.Text = "Wykonano prostą akcję (timer).";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer.Start();
            labelStatus.Text = "Timer uruchomiony...";
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            labelStatus.Text = "Timer zatrzymany.";
        }
    }
}

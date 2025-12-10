using System;
using System.Linq;
using System.Windows.Forms;
using TaskManagerDesktop.Data;

namespace TaskManagerDesktop.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void LoadTasks()
        {
            listBoxTasks.Items.Clear();
            var zadania = DatabaseHelper.PobierzZadania();
            foreach (var z in zadania)
            {
                listBoxTasks.Items.Add($"{z.Tytul} [{z.Kategoria}] [{z.Priorytet}] {(z.Ukończone ? "✔" : "")} - {z.Termin:g}");
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var form = new TaskForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                DatabaseHelper.DodajZadanie(form.Task);
                LoadTasks();
            }
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedIndex == -1) return;
            var zadania = DatabaseHelper.PobierzZadania();
            var task = zadania[listBoxTasks.SelectedIndex];
            var form = new TaskForm(task);
            if (form.ShowDialog() == DialogResult.OK)
            {
                DatabaseHelper.AktualizujZadanie(form.Task);
                LoadTasks();
            }
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedIndex == -1) return;
            var zadania = DatabaseHelper.PobierzZadania();
            var task = zadania[listBoxTasks.SelectedIndex];
            DatabaseHelper.UsunZadanie(task.Id);
            LoadTasks();
        }
    }
}

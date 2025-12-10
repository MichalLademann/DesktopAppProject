using System;
using System.Windows.Forms;

namespace TaskManagerDesktop.Forms
{
    public partial class TaskForm : Form
    {
        public TaskManagerDesktop.Models.Task Task { get; private set; }

        public TaskForm(TaskManagerDesktop.Models.Task task = null)
        {
            InitializeComponent();
            comboBoxKategoria.Items.AddRange(new string[] { "praca", "nauka", "dom" });
            comboBoxPriorytet.Items.AddRange(new string[] { "niski", "œredni", "wysoki" });

            if (task != null)
            {
                Task = task;
                txtTytul.Text = task.Tytul;
                comboBoxKategoria.SelectedItem = task.Kategoria;
                comboBoxPriorytet.SelectedItem = task.Priorytet;
                checkBoxUkoñczone.Checked = task.Ukoñczone;
                dateTimePickerTermin.Value = task.Termin;
            }
            else
            {
                Task = new TaskManagerDesktop.Models.Task();
                dateTimePickerTermin.Value = DateTime.Now.AddDays(1);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Task.Tytul = txtTytul.Text;
            Task.Kategoria = comboBoxKategoria.SelectedItem?.ToString() ?? "praca";
            Task.Priorytet = comboBoxPriorytet.SelectedItem?.ToString() ?? "œredni";
            Task.Ukoñczone = checkBoxUkoñczone.Checked;
            Task.Termin = dateTimePickerTermin.Value;
            DialogResult = DialogResult.OK;
        }
    }
}

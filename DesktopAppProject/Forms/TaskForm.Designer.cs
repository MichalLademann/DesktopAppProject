namespace TaskManagerDesktop.Forms
{
    partial class TaskForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTytul;
        private System.Windows.Forms.ComboBox comboBoxKategoria;
        private System.Windows.Forms.ComboBox comboBoxPriorytet;
        private System.Windows.Forms.CheckBox checkBoxUkoñczone;
        private System.Windows.Forms.DateTimePicker dateTimePickerTermin;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTytul = new System.Windows.Forms.TextBox();
            this.comboBoxKategoria = new System.Windows.Forms.ComboBox();
            this.comboBoxPriorytet = new System.Windows.Forms.ComboBox();
            this.checkBoxUkoñczone = new System.Windows.Forms.CheckBox();
            this.dateTimePickerTermin = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTytul
            // 
            this.txtTytul.Location = new System.Drawing.Point(12, 12);
            this.txtTytul.Name = "txtTytul";
            this.txtTytul.Size = new System.Drawing.Size(360, 23);
            this.txtTytul.TabIndex = 0;
            // 
            // comboBoxKategoria
            // 
            this.comboBoxKategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKategoria.Location = new System.Drawing.Point(12, 50);
            this.comboBoxKategoria.Name = "comboBoxKategoria";
            this.comboBoxKategoria.Size = new System.Drawing.Size(120, 23);
            this.comboBoxKategoria.TabIndex = 1;
            // 
            // comboBoxPriorytet
            // 
            this.comboBoxPriorytet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriorytet.Location = new System.Drawing.Point(150, 50);
            this.comboBoxPriorytet.Name = "comboBoxPriorytet";
            this.comboBoxPriorytet.Size = new System.Drawing.Size(120, 23);
            this.comboBoxPriorytet.TabIndex = 2;
            // 
            // checkBoxUkoñczone
            // 
            this.checkBoxUkoñczone.Location = new System.Drawing.Point(12, 90);
            this.checkBoxUkoñczone.Name = "checkBoxUkoñczone";
            this.checkBoxUkoñczone.Size = new System.Drawing.Size(100, 24);
            this.checkBoxUkoñczone.TabIndex = 3;
            this.checkBoxUkoñczone.Text = "Ukoñczone";
            this.checkBoxUkoñczone.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerTermin
            // 
            this.dateTimePickerTermin.Location = new System.Drawing.Point(12, 130);
            this.dateTimePickerTermin.Name = "dateTimePickerTermin";
            this.dateTimePickerTermin.Size = new System.Drawing.Size(260, 23);
            this.dateTimePickerTermin.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 170);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(140, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // TaskForm
            // 
            this.ClientSize = new System.Drawing.Size(384, 221);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dateTimePickerTermin);
            this.Controls.Add(this.checkBoxUkoñczone);
            this.Controls.Add(this.comboBoxPriorytet);
            this.Controls.Add(this.comboBoxKategoria);
            this.Controls.Add(this.txtTytul);
            this.Name = "TaskForm";
            this.Text = "Edytuj zadanie";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

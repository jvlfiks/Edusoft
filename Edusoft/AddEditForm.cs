using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Edusoft.Models;

namespace Edusoft
{
    public partial class AddEditForm : Form
    {

        bool isEdit = false;
        Form1 form1;

        public AddEditForm(Student student = null, Form1 f = null)
        {
            InitializeComponent();
            if (student != null)
            {
                codTxt.Text = student.Code;
                nameTxt.Text = student.Name;
                cpfTxt.Text = student.CPF;
                addrTxt.Text = student.Address;
                phoneTxt.Text = student.Phone;
                genreCombo.Text = student.Genre;
                isEdit = true;
            }
            if (f != null)
            {
                form1 = f;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void okBtn_Click(object sender, EventArgs e)
        {

            if (codTxt.TextLength == 0)
            {
                MessageBox.Show("O campo código deve ser preenchido.", "Edusoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nameTxt.TextLength == 0)
            {
                MessageBox.Show("O campo nome deve ser preenchido.", "Edusoft",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cpfTxt.TextLength == 0)
            {
                MessageBox.Show("O campo CPF deve ser preenchido.", "Edusoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (addrTxt.TextLength == 0)
            {
                MessageBox.Show("O campo endereço deve ser preenchido.", "Edusoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (phoneTxt.TextLength == 0)
            {
                MessageBox.Show("O campo telefone deve ser preenchido.", "Edusoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (genreCombo.Text == "")
            {
                MessageBox.Show("O campo gênero deve ser preenchido.", "Edusoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var thisStudent = new Student() { Code = codTxt.Text, Name = nameTxt.Text, CPF = cpfTxt.Text, Address = addrTxt.Text, Phone = phoneTxt.Text, Genre = genreCombo.Text, Birth = datePicker.Text };

            var db = new DBConnection();

            if (isEdit)
            {
                db.update(thisStudent);
            } 
            else 
            {
                db.insert(thisStudent);
            }

            form1.updateTable();

            this.Close();

        }
    }
}

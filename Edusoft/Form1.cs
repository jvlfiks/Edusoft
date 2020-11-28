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
    public partial class Form1 : Form
    {

        private AddEditForm addEditForm;

        public Form1()
        {
            InitializeComponent();
            var dbConnect = new DBConnection();
            dataGrid.DataSource = dbConnect.get();
            dataGrid.Columns[0].Visible = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            addEditForm = new AddEditForm(null, this);
            addEditForm.Show();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            var dbConnect = new DBConnection();
            var data = dbConnect.get();
            var row = dataGrid.CurrentRow;
            if (row == null)
            {
                MessageBox.Show("Por favor, selecione um aluno!", "Edusoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var id = data[row.Index].Id;
            var thisStudent = new Student() { Code = row.Cells[1].Value.ToString(), Name = row.Cells[3].Value.ToString(), CPF = row.Cells[2].Value.ToString(), Address = row.Cells[4].Value.ToString(), Phone = row.Cells[5].Value.ToString(), Genre = row.Cells[6].Value.ToString(), Birth = row.Cells[7].Value.ToString(), Id = id };
            addEditForm = new AddEditForm(thisStudent, this);
            addEditForm.Show();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            var dbConnect = new DBConnection();
            dataGrid.DataSource = dbConnect.get();
            dataGrid.Columns[0].Visible = false;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja excluir?", "Edusoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var dbConnect = new DBConnection();
                var data = dbConnect.get();
                var row = dataGrid.CurrentRow;
                var id = data[row.Index].Id;
                var thisStudent = new Student() { Code = row.Cells[1].Value.ToString(), Name = row.Cells[3].Value.ToString(), CPF = row.Cells[2].Value.ToString(), Address = row.Cells[4].Value.ToString(), Phone = row.Cells[5].Value.ToString(), Genre = row.Cells[6].Value.ToString(), Birth = row.Cells[7].Value.ToString(), Id = id };
                dbConnect.delete(thisStudent);
                dataGrid.DataSource = dbConnect.get();
                dataGrid.Columns[0].Visible = false;
            }
        }

        public void updateTable()
        {
            var dbConnect = new DBConnection();
            dataGrid.DataSource = dbConnect.get();
            dataGrid.Columns[0].Visible = false;
        }
    }
}

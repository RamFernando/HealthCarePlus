﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Xml;
using System.Net;
using System.Windows.Controls.Primitives;

namespace OOP_Project___Hospital_Management_System
{
    public partial class EmployeeCRUD : UserControl
    {
        public EmployeeCRUD()
        {
            InitializeComponent();
            display();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Employee doctor = new Employee()
            {
                Name = textBoxName.Text,
                Gender = comboBoxGender.Text,
                Designation = rolecbx.SelectedItem.ToString(),
                Department = depcbx.SelectedItem.ToString(),
                Pass = password.Text,
                Email = textBoxEmail.Text,
                Address = textBoxAddress.Text,
                Tel = textBoxTel.Text
            };
            DatabaseOps insertemp = new DatabaseOps();
            insertemp.insert(doctor);
            display();
        }

        public void display()
        {
            DatabaseOps databaseOps = new DatabaseOps();
            DataTable dt = new DataTable();
            dataGridView1.DataSource = databaseOps.display("EMPLOYEE");
            databaseOps.Showincbx(depcbx, "Department", "DepartmentName");
            //databaseOps.Showincbx(rolecbx, "EmployeeRoles", "RoleName");
            rolecbx.Items.Clear();
            rolecbx.Items.Add("User");

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Employee doctor = new Employee()
            {
                ID = textBoxid.Text,
                Name = textBoxName.Text,
                Gender = comboBoxGender.Text,
                Designation = rolecbx.SelectedItem.ToString(),
                Pass = password.Text,
                Department = depcbx.SelectedItem.ToString(),
                Email = textBoxEmail.Text,
                Address = textBoxAddress.Text,
                Tel = textBoxTel.Text
            };
            DatabaseOps updateDoc = new DatabaseOps();
            updateDoc.update(doctor);
            display();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxid.Text.Length != 0)
            {
                DatabaseOps databaseOps = new DatabaseOps();
                databaseOps.delete("EMPLOYEE", textBoxid.Text);
                display();
                textBoxid.Text = "";
                textBoxName.Text = "";
                comboBoxGender.Text = "";
                rolecbx.Text = "";
                password.Text = "";
                depcbx.Text = "";
                textBoxEmail.Text = "";
                textBoxAddress.Text = "";
                textBoxTel.Text = "";
            }
            else
            {
                MessageBox.Show("Unable to delete Data, Select a row which you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            display();
        }

        private void textBoxSearch_TextChanged_1(object sender, EventArgs e)
        {
            DatabaseOps databaseOps = new DatabaseOps();
            dataGridView1.DataSource = databaseOps.search("EMPLOYEE", textBoxSearch.Text, comboBoxSearchBy.Text);
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            if (textBoxid.Text.Length != 0)
            {
                DatabaseOps databaseOps = new DatabaseOps();
                databaseOps.delete("EMPLOYEE", textBoxid.Text);
                display();
                textBoxid.Text = "";
                textBoxName.Text = "";
                comboBoxGender.Text = "";
                rolecbx.Text = "";
                password.Text = "";
                depcbx.Text = "";
                textBoxEmail.Text = "";
                textBoxAddress.Text = "";
                textBoxTel.Text = "";
            }
            else
            {
                MessageBox.Show("Unable to delete Data, Select a row which you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInsert_Click_1(object sender, EventArgs e)
        {
            Employee doctor = new Employee()
            {
                Name = textBoxName.Text,
                Gender = comboBoxGender.Text,
                Designation = rolecbx.SelectedItem.ToString(),
                Department = depcbx.SelectedItem.ToString(),
                Pass = password.Text,
                Email = textBoxEmail.Text,
                Address = textBoxAddress.Text,
                Tel = textBoxTel.Text
            };
            DatabaseOps insertemp = new DatabaseOps();
            insertemp.insert(doctor);
            display();
        }

        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            Employee doctor = new Employee()
            {
                ID = textBoxid.Text,
                Name = textBoxName.Text,
                Gender = comboBoxGender.Text,
                Designation = rolecbx.SelectedItem.ToString(),
                Pass = password.Text,
                Department = depcbx.SelectedItem.ToString(),
                Email = textBoxEmail.Text,
                Address = textBoxAddress.Text,
                Tel = textBoxTel.Text
            };
            DatabaseOps updateDoc = new DatabaseOps();
            updateDoc.update(doctor);
            display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Male")
            {
                comboBoxGender.Text = "Male";
            }
            else
            {
                comboBoxGender.Text = "Female";
            }
            password.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            depcbx.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxTel.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBoxEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

            textBoxAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            rolecbx.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Male")
            {
                comboBoxGender.Text = "Male";
            }
            else
            {
                comboBoxGender.Text = "Female";
            }
            password.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            depcbx.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxTel.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBoxEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

            textBoxAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            rolecbx.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DatabaseOps databaseOps = new DatabaseOps();
            dataGridView1.DataSource = databaseOps.search("EMPLOYEE", textBoxSearch.Text, comboBoxSearchBy.Text);
        }
    }
}

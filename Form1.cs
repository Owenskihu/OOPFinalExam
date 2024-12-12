using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace TabuniarFinalExam
{
    public partial class Form1 : Form
    {
        DBConnect connect = new DBConnect();
        Subject subj = new Subject();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect.OpenDB();
            DisplayRegistration();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                subj.courseno = txtCourseno.Text;
                subj.description = txtDescription.Text;
                subj.schedule = txtSchedule.Text;
                subj.room = txtRoom.Text;
                connect.InsertRegistration(subj);
                MessageBox.Show("You have submitted successfully");
                DisplayRegistration();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        public void DisplayRegistration()
        {
            connect.OpenDB();
            DataTable dt = new DataTable();
            dt = connect.ReadRegistrationRecord();
            dgvRegistration.DataSource = dt;
            connect.CloseDB();
        }

        private void dvgRegistration_DoubleClick(object sender, EventArgs e)
        {
            txtCode.Text = dgvRegistration.CurrentRow.Cells[0].Value.ToString();
            txtCourseno.Text = dgvRegistration.CurrentRow.Cells[1].Value.ToString();
            txtDescription.Text = dgvRegistration.CurrentRow.Cells[3].Value.ToString();
            txtSchedule.Text = dgvRegistration.CurrentRow.Cells[4].Value.ToString();
            txtRoom.Text = dgvRegistration.CurrentRow.Cells[5].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSchedule_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCourseno_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            try
            {
                subj.courseno = txtCourseno.Text;
                subj.description = txtDescription.Text;
                subj.schedule = txtSchedule.Text;
                subj.room = txtRoom.Text;
                connect.InsertRegistration(subj);
                MessageBox.Show("You have submitted successfully");
                DisplayRegistration();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class StudentForm : Form
    {
        private StudentRepository studentRepository;
        string selectedStudentId;
        public StudentForm()
        {
            InitializeComponent();
            MessageBox.Show("Welcome to Student Management System", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            studentRepository = new StudentRepository();
            studentRepository.LoadStudentsFromFile();
        }


        private void StudentForm_Load(object sender, EventArgs e)
        {

            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Student ID";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Total Score Obtained";
            dataGridView1.Columns[3].Name = "Total Maximum Score";
            dataGridView1.Columns[4].Name = "Assignments";
            dataGridView1.Columns[5].Name = "Assignment Count";
            loadStudentsGridBox();

            if (dataGridView1.Rows.Count == 1)
            {
                selectedStudentId = null;
                addnew.Enabled = true;
                update.Enabled = false;
                delete.Enabled = false;
            }else
            {
                selectedStudentId = dataGridView1.Rows[0].Cells[0].Value.ToString();
                addnew.Enabled = true;
                update.Enabled = true;
                delete.Enabled = true;
            }

        }

        public void loadStudentsGridBox()
        {
            dataGridView1.Rows.Clear();
            foreach (Student student in studentRepository.GetAllStudents())
            {
                dataGridView1.Rows.Add(student.StudentId, student.Name, student.TotalScoreObtained, student.TotalMaximumScore, student.Assignments, student.assignmentCount);
            }

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
            }
            else
            {
                clear();
            }

            //if (dataGridView1.Rows.Count == 0)
            //{
            //    addnew.Enabled = true;
            //    update.Enabled = false;
            //    delete.Enabled = false;
            //}
            //else
            //{
            //    addnew.Enabled = true;
            //    update.Enabled = true;
            //    delete.Enabled = true;
            //}
        }

        private void clear()
        {
            score.Text = "";
            scoreCount.Text = "";
            average.Text = "";
        }

        private void performbtn_Click(object sender, EventArgs e)
        {

            if (addnew.Checked)
            {
                AddNew frm = new AddNew(this,studentRepository);
                frm.Show();
                this.Hide();
            }
            else if (update.Checked)
            {
                if (string.IsNullOrEmpty(selectedStudentId))
                {
                    MessageBox.Show("Please select a student to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Student student = studentRepository.FindStudent(selectedStudentId);
                    studentRepository.SetSelectedStudent(student);
                    UpdateStudent update_frm = new UpdateStudent(this, studentRepository);
                    update_frm.Show();
                    this.Hide();
                }
            }
            else if (delete.Checked)
            {
                if (string.IsNullOrEmpty(selectedStudentId))
                {
                    MessageBox.Show("Please select a student to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Student student = studentRepository.FindStudent(selectedStudentId);
                    MessageBox.Show("Are you sure you want to delete this student?"+ selectedStudentId, "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    studentRepository.RemoveStudent(student.StudentId);
                    loadStudentsGridBox();
                }

            }
            else if (exit.Checked)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    if (row.Cells[0].Value != null)
                    {
                        selectedStudentId = row.Cells[0].Value.ToString();
                        MessageBox.Show($"Selected student ID: {selectedStudentId}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Selected cell value is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                studentRepository.SetSelectedStudent(studentRepository.FindStudent(selectedStudentId));
                Student student = studentRepository.FindStudent(selectedStudentId);
                if (student != null)
                {
                    score.Text = student.TotalScoreObtained.ToString();
                    scoreCount.Text = student.TotalMaximumScore.ToString();
                    if (student.TotalMaximumScore != 0)
                    {
                        average.Text = ((student.TotalScoreObtained / student.TotalMaximumScore) * 100).ToString();
                    }
                    else
                    {
                        average.Text = "N/A";
                    }
                }
                else
                {
                    MessageBox.Show("Selected student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}

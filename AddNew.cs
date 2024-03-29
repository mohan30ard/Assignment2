using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class AddNew : Form
    {
        StudentForm studentForm;
        private StudentRepository studentRepository;

        public AddNew(StudentForm studentForm,StudentRepository studentRepository)
        {
            InitializeComponent();
            this.studentForm = studentForm;
            this.studentRepository = studentRepository;
        }

        private void add_Click(object sender, EventArgs e)
        {
            string Name = studentName.Text.Trim();
            string TestName = testName.Text.Trim();
            double ScoreObtained;
            double maximumScore = 100;

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(TestName))
            {
                MessageBox.Show("Please enter a student name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (StudentNameExists(studentName))
            {
                MessageBox.Show($"Student '{studentName}' already exists. Please select the student from the list and choose the update operation to add tests for {studentName}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (double.TryParse(testScore.Text, out ScoreObtained))
            {
                if(ScoreObtained >= 0 && ScoreObtained <=  maximumScore)
                {     
                    Student student = new Student(studentRepository.GenerateStudentId(), Name);
                    student.AddAssignment(new Assignment(studentRepository.GenerateAssignmentId(),TestName, ScoreObtained, maximumScore));
                    studentRepository.AddStudent(student);
                    MessageBox.Show("Student added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.studentForm.Show();
                    this.studentForm.loadStudentsGridBox();
                }
                else
                {
                    MessageBox.Show("Test Score must be between 0 and 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields with valid information." + ScoreObtained, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool StudentNameExists(TextBox studentName)
        {
            return studentRepository.GetAllStudents().Any(s => s.Name == studentName.Text);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            this.studentForm.Show();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.studentForm.Show();
        }

        private void AddNew_Load(object sender, EventArgs e)
        {
            maxScore.Text = "100";
        }
    }
}

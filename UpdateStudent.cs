using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class UpdateStudent : Form
    {
        StudentForm studentForm;
        private StudentRepository studentRepository;
        public Student student;
        static int count = 1;
        public UpdateStudent(StudentForm studentForm , StudentRepository studentRepository)
        {
            InitializeComponent();
            this.studentForm = studentForm;
            this.studentRepository = studentRepository;
            student= studentRepository.GetSelectedStudent();
            MessageBox.Show(studentRepository.GetSelectedStudent().ToString());
            studentName.Text = student.Name;
            StudentData.Columns.Add("TestIDColumn", "Test ID");
            StudentData.Columns.Add("TestNameColumn", "Test Name");
            StudentData.Columns.Add("TestScoreColumn", "Test Score");
            StudentData.Columns.Add("MaximumScoreColumn", "Maximum Score");
            UpdateTestDataGrid();
        }

        private void UpdateTestDataGrid()
        {
            StudentData.Rows.Clear();
            
            Assignment[] assignments = student.ViewAllAssignments();            

            foreach (Assignment assignment in assignments)
            {
                if (assignment != null)
                {
                    StudentData.Rows.Add(assignment.AssignmentId, assignment.AssignmentName, assignment.ScoreObtained, assignment.MaximumScore);
                }
            }
        }

        private void perform_btn_Click(object sender, EventArgs e)
        {
            if(addAssignment.Checked)
            {
                if(count >= 5)
                {
                    MessageBox.Show("Maximum 5 assignments are allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }else
                {
                    double score;
                    if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Please enter a test name and score.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (!double.TryParse(textBox2.Text , out score) || score < 0 || score > 100)
                    {
                        MessageBox.Show("Test Score must be between 0 and 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Assignment assignment = new Assignment(studentRepository.GenerateAssignmentId(), textBox1.Text, score, 100);
                    studentRepository.AddAssignment(student.StudentId, assignment);
                    
                    MessageBox.Show("Assignment added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    count++;
                    UpdateTestDataGrid();
                    ClearVisibilities();
                }
            }
            else if(updateAssignment.Checked)
            {
                double score;
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Please enter a test ID and new score.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!double.TryParse(textBox2.Text, out score) || score < 0 || score > 100)
                {
                    MessageBox.Show("Test Score must be between 0 and 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }else if(studentRepository.FindAssignment(student.StudentId, textBox1.Text) == null)
                {
                    MessageBox.Show("Assignment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                studentRepository.UpdateAssignmentScore(student.StudentId, textBox1.Text, int.Parse(textBox2.Text));
                MessageBox.Show("Assignment updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateTestDataGrid();
                ClearVisibilities();
            }
            else if(ViewAssignment.Checked)
            {
                ClearVisibilities();
            }
            else if(removeAssignment.Checked)
            {
                if (comboBox1.Items.Count == 0)
                {
                    MessageBox.Show("No assignments to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    studentRepository.RemoveAssignment(student.StudentId, comboBox1.SelectedItem.ToString());
                    MessageBox.Show("Assignment removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateTestDataGrid();
                    count--;
                    ClearVisibilities();
                }
            }
        }

        private void loadComboBox()
        {
            comboBox1.Items.Clear();
            Assignment[] assignments = student.ViewAllAssignments();
            foreach (Assignment assignment in assignments)
            {
                if (assignment != null)
                {
                    comboBox1.Items.Add(assignment.AssignmentId.ToString());
                }
            }
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            if(addAssignment.Checked)
            {
                ClearVisibilities();
                label3.Text = "Test Name";
                label4.Text = "Test Score";
                textBox1.Name = "testName";
                textBox2.Name = "testScore";
                label3.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                perform_btn.Visible = true;
            }
            else if(updateAssignment.Checked)
            {
                ClearVisibilities();
                label2.Text = "Select an Assignment ID to update : ";
                label3.Text = "Test ID";
                label4.Text = "New Test Score";
                textBox1.Name = "testID";
                textBox2.Name = "newTestScore";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                perform_btn.Visible = true;
            }
            else if (ViewAssignment.Checked)
            {
                ClearVisibilities();
                label3.Text = "Student Id";
                label3.Visible = true;
                textBox1.Visible = true;
                textBox1.Text = student.StudentId;
                label4.Text = "Total Score";
                label4.Visible = true;
                textBox2.Visible = true;
                textBox2.Text = student.TotalScoreObtained.ToString();
                label5.Text = "Total Maximum Score";
                label5.Visible = true;
                textBox3.Visible = true;
                textBox3.Text = student.TotalMaximumScore.ToString();
                label6.Text = "Average Score";
                label6.Visible = true;
                textBox4.Visible = true;
                textBox4.Text = (student.TotalScoreObtained / student.TotalMaximumScore * 100).ToString();
                perform_btn.Visible = true;
                perform_btn.Text = "Ok";
            }
            else if(removeAssignment.Checked)
            {
                ClearVisibilities();
                label2.Text = "Select an Assignment ID to remove : ";
                label2.Visible = true;
                comboBox1.Visible = true;
                perform_btn.Visible = true;
                loadComboBox();
            }
        }

        private void ClearVisibilities()
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            perform_btn.Visible = false;
            comboBox1.Visible = false;
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Items.Clear();
            label5.Text = "";
            label6.Text = "";
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.studentForm.Show();
        }
    }
}

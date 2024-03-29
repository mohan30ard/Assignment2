using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public class StudentRepository
    {
        private const string studentFilePath = @"Z:\Documents\C# App dev\Assignment2\students.txt";
        private List<Student> students;

        private int nextAssignmentId;

        public StudentRepository()
        {
            nextAssignmentId = 1;
            students = new List<Student>();
        }

        public void LoadStudentsFromFile()
        {
            students.Clear();
            if (File.Exists(studentFilePath))
            {
                string[] lines = File.ReadAllLines(studentFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 9)
                    {
                        string StudentId = parts[0].Trim();
                        string Name = parts[1].Trim();
                        double TotalScoreObtained = double.Parse(parts[2].Trim());
                        double TotalMaximumScore = double.Parse(parts[3].Trim());
                        int assignmentCount = int.Parse(parts[4].Trim());
                        Assignment[] assignments = new Assignment[assignmentCount];
                        for (int i = 5; i < parts.Length; i += 4) {

                            if (i + 3 < parts.Length)
                            {
                                string AssignmentId = parts[i].Trim();
                                string AssignmentName = parts[i + 1].Trim();
                                double ScoreObtained = double.Parse(parts[i + 2].Trim());
                                double MaximumScore = double.Parse(parts[i + 3].Trim());

                                Assignment assignment = new Assignment(AssignmentId, AssignmentName, ScoreObtained, MaximumScore);
                                assignments[(i - 5) / 4] = assignment; 
                            }
                        }
                        Student student = new Student (StudentId, Name, TotalScoreObtained, TotalMaximumScore, assignments, assignmentCount);
                        students.Add(student);
                    }
                }
            }
        }

        public void SaveStudentsToFile()
        {
            List<string> lines = new List<string>();
            foreach (Student student in students)
            {
                string serializedAssignments = SerializeAssignments(student.Assignments);
                string line = $"{student.StudentId},{student.Name},{student.TotalScoreObtained},{student.TotalMaximumScore},{student.assignmentCount},{serializedAssignments}";
                lines.Add(line);
            }
            File.WriteAllLines(studentFilePath, lines);
        }

        private string SerializeAssignments(Assignment[] assignments)
        {
            if (assignments == null || assignments.Length == 0)
            {
                return string.Empty;
            }

            var serializedAssignments = new List<string>();
            foreach (var assignment in assignments)
            {
                if (assignment != null)
                {
                    var serializedAssignment = $"{assignment.AssignmentId ?? ""}," +
                                                $"{assignment.AssignmentName ?? ""}," +
                                                $"{assignment.ScoreObtained}," +
                                                $"{assignment.MaximumScore}";
                    serializedAssignments.Add(serializedAssignment);
                }
            }

            return string.Join(";", serializedAssignments);
        }

        public void AddStudent(Student student)
        {
            MessageBox.Show(student.ToString());
            students.Add(student);
            SaveStudentsToFile();
        }

        public void RemoveStudent(string studentId)
        {
            Student studentToRemove = students.Find(s => s.StudentId == studentId);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
            }
            SaveStudentsToFile();
        }

        public Student FindStudent(string studentId)
        {
            LoadStudentsFromFile();
            return students.Find(s => s.StudentId == studentId);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        internal string GenerateStudentId()
        {
            if (students.Count == 0)
            {
                return "S1";
            }
            else
            {
                string lastStudentId = students[students.Count - 1].StudentId;
                int nextStudentId = int.Parse(lastStudentId.Substring(1)) + 1;
                return "S" + nextStudentId;
            }
            
        }

        public void AddAssignment(string studentId, Assignment assignment)
        {
            Student student = students.Find(s => s.StudentId == studentId);
            if (student != null)
            {
                student.AddAssignment(assignment);
            }
            SaveStudentsToFile();
        }

        public void RemoveAssignment(string studentId, string assignmentId)
        {
            Student student = students.Find(s => s.StudentId == studentId);
            if (student != null)
            {
                student.RemoveAssignment(assignmentId);
            }
        }

        public Assignment FindAssignment(string studentId, string assignmentId)
        {
            Student student = students.Find(s => s.StudentId == studentId);
            if (student != null)
            {
                return student.FindAssignment(assignmentId);
            }
            else
            {
                return null;
            }
        }

        public void UpdateAssignmentScore(string studentId, string assignmentId, double newScore)
        {
            Student student = students.Find(s => s.StudentId == studentId);
            if (student != null)
            {
                student.UpdateAssignmentScore(assignmentId, newScore);
            }
        }

        internal string GenerateAssignmentId()
        {
            string assignmentId = "A" + nextAssignmentId;
            nextAssignmentId++;
            return assignmentId;
        }

        internal void SetSelectedStudent(Student student)
        {
            students.Clear();
            students.Add(student);
        }

        internal Student GetSelectedStudent()
        {
            return students[0];
        }
    }
}

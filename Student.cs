using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public double TotalScoreObtained { get; set; }
        public double TotalMaximumScore { get; set; }
        public Assignment[] Assignments { get; set; }
        public int assignmentCount;

        public Student(string studentId, string name)
        {
            StudentId = studentId;
            Name = name;
            Assignments = new Assignment[5];
            assignmentCount = 0;
        }

        public Student(string studentId, string name, double total , double maxScore, Assignment[] assignments, int count)
        {
            StudentId = studentId;
            Name = name;
            TotalScoreObtained = total;
            TotalMaximumScore = maxScore;
            Assignments = assignments;
            assignmentCount = count;
        }

        public Student()
        {

        }

        public void AddAssignment(Assignment assignment)
        {
            if (assignmentCount < Assignments.Length)
            {
                Assignments[assignmentCount++] = assignment;
                TotalScoreObtained += assignment.ScoreObtained;
                TotalMaximumScore += assignment.MaximumScore;
            }
        }
       
        public void RemoveAssignment(string assignmentId)
        {
            for (int i = 0; i < Assignments.Length; i++)
            {
                if (Assignments[i] != null && Assignments[i].AssignmentId == assignmentId)
                {
                    TotalScoreObtained -= Assignments[i].ScoreObtained;
                    TotalMaximumScore -= Assignments[i].MaximumScore;

                    for (int j = i; j < Assignments.Length - 1; j++)
                    {
                        Assignments[j] = Assignments[j + 1];
                    }

                    Assignments[Assignments.Length - 1] = null;
                    break;
                }
            }
            assignmentCount--;
        }

        public Assignment FindAssignment(string assignmentId)
        {
            for (int i = 0; i < assignmentCount; i++)
            {
                if (Assignments[i].AssignmentId == assignmentId)
                {
                    return Assignments[i];
                }
            }
            return null;
        }

        public void UpdateAssignmentScore(string assignmentId, double newScore)
        {
            for (int i = 0; i < assignmentCount; i++)
            {
                if (Assignments[i].AssignmentId == assignmentId)
                {
                    TotalScoreObtained = TotalScoreObtained - Assignments[i].ScoreObtained + newScore;
                    Assignments[i].ScoreObtained = newScore;
                    break;
                }
            }
        }


        public Assignment[] ViewAllAssignments()
        {
            return Assignments;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Student ID: {StudentId}");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Total Score Obtained: {TotalScoreObtained}");
            sb.AppendLine($"Total Maximum Score: {TotalMaximumScore}");
            if (TotalMaximumScore != 0)
            {
                sb.AppendLine($"Average Score: {(TotalScoreObtained / TotalMaximumScore) * 100}%");
            }
            else
            {
                sb.AppendLine("Average Score: N/A");
            }
            sb.AppendLine("Assignments:");
            foreach (Assignment assignment in Assignments)
            {
                if (assignment != null)
                {
                    sb.AppendLine(assignment.ToString());
                }
            }

            return sb.ToString();
        }

    }

}


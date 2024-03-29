using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Assignment
    {
        public Assignment() { }
        public Assignment(string assignmentId ,string assignmentName, double scoreObtained, double maximumScore)
        {
            AssignmentId = assignmentId;
            AssignmentName = assignmentName;
            ScoreObtained = scoreObtained;
            MaximumScore = maximumScore;
        }
        public string AssignmentName { get; set; }

        public string AssignmentId { get; set; }
        public double ScoreObtained { get; set; }
        public double MaximumScore { get; set; }

        public override string ToString()
        {
            return $"Assignment ID: {AssignmentId}, Assignment Name: {AssignmentName}, Score Obtained: {ScoreObtained}, Maximum Score: {MaximumScore}";
        }
    }
}

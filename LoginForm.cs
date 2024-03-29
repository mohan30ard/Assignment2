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
    public partial class LoginForm : Form
    {
        private static readonly string userFilePath = "user.txt";
        private static readonly string studentFilePath = "students.txt";
        private Dictionary<string, string> users = new Dictionary<string, string>();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadUsersFromFile();
        }

        private void LoadUsersFromFile()
        {
            if (File.Exists(userFilePath))
            {
                string[] lines = File.ReadAllLines(userFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string username = parts[0].Trim();
                        string password = parts[1].Trim();
                        users[username] = password;
                    }
                }
            }
            else
            {
                // Create default user
                users["ADMIN"] = "Password";
                SaveUsersToFile();
            }
        }

        private void SaveUsersToFile()
        {
            List<string> lines = new List<string>();
            foreach (KeyValuePair<string, string> user in users)
            {
                lines.Add($"{user.Key}: {user.Value}");
            }
            File.WriteAllLines(userFilePath, lines);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            if (users.ContainsKey(username) && users[username] == password)
            {
                StudentForm studentForm = new StudentForm();
                studentForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

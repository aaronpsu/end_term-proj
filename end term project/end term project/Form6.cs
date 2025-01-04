using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace end_term_project
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Database connection string for MySQL
                string connectionString = "user id=root;server=localhost;database=police_blotter_db";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to validate user credentials
                    string query = "SELECT COUNT(*) FROM users WHERE username = @Username AND password = @Password";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", textBox1.Text);
                        command.Parameters.AddWithValue("@Password", HashPassword(textBox2.Text)); // Hash the password before comparison

                        int userCount = Convert.ToInt32(command.ExecuteScalar());

                        if (userCount > 0)
                        {
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Navigate to Form1 (Main application page)
                            Form1 mainForm = new Form1();
                            this.Hide();
                            mainForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashPassword(string password)
        {
            // Hash the password using SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate to registration form if needed
            Form7 registrationForm = new Form7();
            this.Hide();
            registrationForm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Username input
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Password input
        }
    }
}

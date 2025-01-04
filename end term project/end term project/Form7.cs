using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace end_term_project
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Registering

            // Validate inputs
            if (string.IsNullOrWhiteSpace(textBox4.Text) || // Name
                string.IsNullOrWhiteSpace(textBox5.Text) || // Email
                string.IsNullOrWhiteSpace(textBox1.Text) || // Username
                string.IsNullOrWhiteSpace(textBox2.Text) || // Password
                string.IsNullOrWhiteSpace(textBox3.Text) || // Confirm Password
                string.IsNullOrWhiteSpace(comboBox1.Text))  // Changed from listBox1.Text to comboBox1.Text
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate email format
            if (!IsValidEmail(textBox5.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate password match
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Hash the password before storing it
                string hashedPassword = HashPassword(textBox2.Text);

                // Database connection string for MySQL
                string connectionString = "user id=root;server=localhost;database=police_blotter_db";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to insert the user
                    string query = "INSERT INTO users (name, email, username, password, role) " +
                                   "VALUES (@Name, @Email, @Username, @Password, @Role)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", textBox4.Text);
                        command.Parameters.AddWithValue("@Email", textBox5.Text);
                        command.Parameters.AddWithValue("@Username", textBox1.Text);
                        command.Parameters.AddWithValue("@Password", hashedPassword); // Use hashed password
                        command.Parameters.AddWithValue("@Role", comboBox1.Text);  // Use comboBox1 instead of listBox1

                        command.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("You have been successfully registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirect to login page (Form6)
                Form6 loginForm = new Form6();
                this.Hide();
                loginForm.Show();
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

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cancel and go back to login page (Form6)
            Form6 loginForm = new Form6();
            this.Hide();
            loginForm.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Full name
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // Email
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Username
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Password
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Confirm password validation to match with textBox2
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Must be checked to register
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Role selection: Administrator or Officer
        }
    }
}

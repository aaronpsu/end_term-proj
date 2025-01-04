using System;
using System.Drawing;
using System.Windows.Forms;

namespace end_term_project
{
    public partial class Form3 : Form
    {
        private Button activeButton;

        public Form3()
        {
            InitializeComponent();

            // Ensure buttons are connected to the event handler
            button3.BackColor = Color.White;  // Button1 stays white (not selected)
            activeButton = null;  // No button selected initially

            // Connecting button click events
            button1.Click += button_Click;
            button2.Click += button_Click;
            button3.Click += button_Click;
        
            button5.Click += button_Click;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // Exclude Button1 from being highlighted
                if (clickedButton != button3)
                {
                    if (activeButton != null)
                    {
                        activeButton.BackColor = SystemColors.Control;
                    }

                    clickedButton.BackColor = Color.LightBlue;
                    activeButton = clickedButton;  // Update active button reference
                }

                OpenForm(clickedButton);  // Open the corresponding form
            }
        }

        private void OpenForm(Button clickedButton)
        {
            Form newForm = null;

            if (clickedButton == button1)
            {
                newForm = new Form1();  // Open Form1
            }
            else if (clickedButton == button2)
            {
                newForm = new Form2();  // Open Form2
            }
            else if (clickedButton == button3)
            {
                newForm = new Form3();  // Open Form3
            }
       
            else if (clickedButton == button5)
            {
                newForm = new Form4();  // Open Form5
            }

            if (newForm != null)
            {
                newForm.Show();
                this.Hide();  // Optionally hide the current form
            }
        }

        // Empty methods for button clicks (if needed for other purposes)
        private void button3_Click(object sender, EventArgs e)
        {
            // Handle button3 click if necessary
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Handle button5 click if necessary
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Handle button4 click if necessary
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Handle button1 click if necessary
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Handle button2 click if necessary
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //fullname textbox
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //username
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //email
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //password
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //conmfirm password
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //administrator or officer
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //create the user 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //update the user stuff
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //total users
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //delete button
        }
    }
}

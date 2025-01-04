using System;
using System.Drawing;
using System.Windows.Forms;

namespace end_term_project
{
    public partial class Form2 : Form
    {
        private Button activeButton;

        public Form2()
        {
            InitializeComponent();
            // Ensure the buttons are connected to the event handler
            button2.BackColor = Color.White;  // Button1 stays white (not selected)
            activeButton = null;  // No button selected initially

            // Connect button click events
            button1.Click += button_Click;
            button2.Click += button_Click;
            button3.Click += button_Click;
            button4.Click += button_Click;
           
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // Exclude Button1 from being highlighted
                if (clickedButton != button2)
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
            else if (clickedButton == button4)
            {
                newForm = new Form4();  // Open Form4
            }
          

            if (newForm != null)
            {
                newForm.Show();
                this.Hide();  // Optionally hide the current form
            }
        }

        // Empty methods for button2 (if needed for other purposes)
        private void button2_Click(object sender, EventArgs e)
        {
            // Handle button2 click if necessary
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           //this is panel 13
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //title 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //crime description
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //start date
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //date updated? 
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //created by who user 
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //status
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //record button
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //cancel
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //update or edit
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //data gridview showign stuff
        }
    }
}

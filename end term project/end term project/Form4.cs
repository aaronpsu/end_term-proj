using System;
using System.Drawing;
using System.Windows.Forms;

namespace end_term_project
{
    public partial class Form4 : Form
    {
        private Button activeButton;

        public Form4()
        {
            InitializeComponent();
            button4.BackColor = Color.White;  // Button1 stays white (not selected)
            activeButton = null;  // No button selected initially

            // Connect the buttons to the same event handler
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
                if (clickedButton != button4)
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

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            //charts
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            //pie chart
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //data grid viewinfg
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //report type
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //start date
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //end date
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //crime type
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //case outcome
        }



        private void button6_Click(object sender, EventArgs e)
        {
            //button to generetae
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //assigned judge
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

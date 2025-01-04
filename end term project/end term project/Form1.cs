using System;
using System.Drawing;
using System.Windows.Forms;

namespace end_term_project
{
    public partial class Form1 : Form
    {
        private Button activeButton;
        private Form currentForm;

        public Form1()
        {
            InitializeComponent();
            button1.BackColor = Color.LightBlue;  // Button1 is highlighted by default
            activeButton = button1;  // Set button1 as the active button initially

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
                if (clickedButton != button1)
                {
                    if (activeButton != null)
                    {
                        activeButton.BackColor = SystemColors.Control;
                    }

                    clickedButton.BackColor = Color.LightBlue;  // Highlight the clicked button
                    activeButton = clickedButton;  // Update active button reference
                }

                // Open the corresponding form based on the button clicked
                OpenForm(clickedButton);
            }
        }

        private void OpenForm(Button clickedButton)
        {
            Form newForm = null;

            if (clickedButton == button1)
            {
                newForm = new Form1();  // Open Form1
                this.Show(); // Keep Form1 open when button1 is clicked
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
         

            // Check if the form to be opened is already visible
            if (newForm != null && currentForm != newForm)
            {
                // Hide the current form and open the new one
                currentForm?.Hide();  // Hide the current form if it's already open
                newForm.Show();  // Show the new form
                currentForm = newForm;  // Set the new form as the current form
                this.Hide();  // Hide Form1 when buttons 2-5 are clicked
            }
        }

        // Button click handlers
        private void button1_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        // Placeholder for additional events (if needed)
        private void label3_Click(object sender, EventArgs e)
        {
            // Add code if label3 needs to do something
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // This panel is used to show the dashboard or the current form
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            //pnale yeah
        }

        private void label8_Click(object sender, EventArgs e)
        {
            //placeolder for solved cases
        }

        private void label10_Click(object sender, EventArgs e)
        {
            //placeholder for open cases
        }

        private void label12_Click(object sender, EventArgs e)
        {
            //total cases
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //officers how many
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            //chart idk what of to put please put
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

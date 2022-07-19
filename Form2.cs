using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button2.Text = Form3.buttonTwoText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.igofirst = true;
            Form1.selectIndex = 0;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.igofirst = false;
            Form1.selectIndex = 1;
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If we haven't clicked either button but the form is still closing
            //aka if we have clicked exit on this form, then close entire program
            if (Form1.selectIndex == 2)
            {
                //Would use Application.Exit() however it won't kill all our forms
                //including the ones hidden while this form is shown and runs
                Environment.Exit(0);
            }
        }
    }
}

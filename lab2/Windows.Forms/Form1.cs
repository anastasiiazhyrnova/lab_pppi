using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string s;
        double num1;
        double num2;
        double sum;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s = textBox1.Text;
            num1 = Convert.ToDouble(s);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            s = textBox2.Text;
            num2 = Convert.ToDouble(s);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            sum = num1 + num2;
            textBox3.Text = Convert.ToString(sum);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using PolinomSR;
using static PolinomSR.Polinom;
namespace ForforPolinom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PolinomSR.Polinom polinom1;
        PolinomSR.Polinom polinom2;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                int min = Convert.ToInt32(textBox2.Text);
                int max = Convert.ToInt32(textBox3.Text);
                polinom1 = new PolinomSR.Polinom(n, min, max);
                richTextBox1.Text = polinom1.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBox4.Text);
                int min = Convert.ToInt32(textBox5.Text);
                int max = Convert.ToInt32(textBox6.Text);
                polinom2 = new PolinomSR.Polinom(n, min, max);
                richTextBox2.Text = polinom2.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("ошибка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "" || richTextBox2.Text == "")
            {
                MessageBox.Show("Пустые поля");
            }
            try
            {
                richTextBox3.Text = (polinom1 + polinom2).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("ошибка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "" || richTextBox2.Text == "")
            {
                MessageBox.Show("Пустые поля");
            }
            try
            {
                richTextBox3.Text = (polinom1 - polinom2).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("ошибка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "" || richTextBox2.Text == "")
            {
                MessageBox.Show("Пустые поля");
            }
            try
            {
                richTextBox3.Text = (polinom1 * polinom2).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("ошибка");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "" || richTextBox2.Text == "")
            {
                MessageBox.Show("Пустые поля");
            }
            if (richTextBox2.Text == "0")
            {
                throw new ArgumentException("На ноль делить нельзя");
            }
            try
            {
                richTextBox3.Text = (polinom1 / polinom2).ToString();
                if (richTextBox3.Text == "")
                    richTextBox3.Text = "0";
            }
            catch (Exception)
            {
                MessageBox.Show("ошибка");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(textBox7.Text);
                textBox9.Text = polinom1.P(x).ToString();
            }
            catch (Exception) { MessageBox.Show("ошибка"); }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "" || richTextBox2.Text == "")
            {
                MessageBox.Show("Пустые поля");
            }
            if (richTextBox2.Text == "0")
            {
                throw new ArgumentException("На ноль делить нельзя");
            }
            try
            {
                richTextBox3.Text = (polinom1 % polinom2).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("ошибка");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(textBox8.Text);
                textBox10.Text = polinom2.P(x).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("ошибка");
            }
        }
    }
}
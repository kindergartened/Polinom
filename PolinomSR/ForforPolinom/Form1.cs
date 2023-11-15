using PolinomSR;
namespace ForforPolinom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PolinomRoots polinom1;
        PolinomRoots polinom2;
        const int MAX_X = 10000;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                int min = Convert.ToInt32(textBox2.Text);
                int max = Convert.ToInt32(textBox3.Text);
                if (isFirst.Checked)
                {
                    polinom1 = new PolinomRoots(n, min, max);
                    polinomText1.Text = polinom1.ToString();
                }
                else
                {
                    polinom2 = new PolinomRoots(n, min, max);
                    polinomText2.Text = polinom2.ToString();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка: " + err.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (polinomText1.Text == "" || polinomText2.Text == "")
            {
                MessageBox.Show("Пустые поля");
            }
            try
            {
                output.Text = (polinom1 + polinom2).ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка: " + err.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (polinomText1.Text == "" || polinomText2.Text == "")
            {
                MessageBox.Show("Пустые поля");
            }
            try
            {
                output.Text = (polinom1 - polinom2).ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка: " + err.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (polinomText1.Text == "" || polinomText2.Text == "")
            {
                MessageBox.Show("Пустые поля");
            }
            try
            {
                output.Text = (polinom1 * polinom2).ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка: " + err.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (polinomText1.Text == "" || polinomText2.Text == "")
            {
                MessageBox.Show("Пустые поля");
            }
            if (polinomText2.Text == "0")
            {
                throw new ArgumentException("На ноль делить нельзя");
            }
            try
            {
                output.Text = (polinom1 / polinom2).ToString();
                if (output.Text == "")
                    output.Text = "0";
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка: " + err.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (isFirst.Checked)
                {
                    double x = Convert.ToDouble(textBox7.Text);
                    textBox9.Text = polinom1.P(x).ToString();
                }
                else
                {
                    double x = Convert.ToDouble(textBox7.Text);
                    textBox9.Text = polinom2.P(x).ToString();
                }
            }
            catch (Exception err) { MessageBox.Show("Ошибка: " + err.Message); }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (polinomText1.Text == "" || polinomText2.Text == "")
            {
                MessageBox.Show("Пустые поля");
            }
            if (polinomText2.Text == "0")
            {
                throw new ArgumentException("На ноль делить нельзя");
            }
            try
            {
                output.Text = (polinom1 % polinom2).ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка: " + err.Message);
            }
        }

        private void pow_Click(object sender, EventArgs e)
        {
            try
            {
                int pow = int.Parse(powVal.Text);
                if (isFirst.Checked)
                    output.Text = polinom1.Pow(pow).ToString();
                else
                    output.Text = polinom2.Pow(pow).ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка: " + err.Message);
            }
        }

        private void integral1_Click(object sender, EventArgs e)
        {
            try
            {
                if (isFirst.Checked)
                    output.Text = polinom1.Integral().ToString();
                else
                    output.Text = polinom2.Integral().ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка: " + err.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (isFirst.Checked)
                    output.Text = polinom1.Derivative().ToString();
                else
                    output.Text = polinom2.Derivative().ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка: " + err.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                PolinomRoots pol;
                if (isFirst.Checked)
                {
                    pol = polinom1;
                }
                else
                {
                    pol = polinom2;
                }

                List<(double x, double y, ExtremumPointType stPointType)> extremumPoints = pol.FindAllExtremumPoints(-MAX_X, MAX_X);
                extremumPoints.RemoveAll(item => double.IsNaN(item.x));
                extremumPoints = extremumPoints.OrderBy(item => item.x).ToList();
                string s = "";
                foreach (var item in extremumPoints)
                    s += $"({item.x}; {item.y}) - точка " + (item.stPointType == ExtremumPointType.Min ? "минимума" : "максимума") + "\n";
                output.Text = s;
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка: " + err.Message);
            }
        }

        private void parse_Click(object sender, EventArgs e)
        {
            try
            {
                string[] coefsStr = parsing.Text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                double[] coefs = new double[coefsStr.Length];
                for (int i = 0; i < coefsStr.Length; i++)
                {
                    coefs[i] = double.Parse(coefsStr[i]);
                }
                if (isFirst.Checked)
                {
                    polinom1 = new PolinomRoots(coefs);
                    polinomText1.Text = polinom1.ToString();
                }
                else
                {
                    polinom2 = new PolinomRoots(coefs);
                    polinomText2.Text = polinom2.ToString();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка: " + err.Message);
            }
        }

        private void findRoots_Click(object sender, EventArgs e)
        {
            try
            {
                int fotx = int.Parse(FOTX.Text);
                if (isFirst.Checked)
                {
                    output.Text = string.Join("\n", polinom1.FindAllRootsNewton(-MAX_X, MAX_X, fotx));
                }
                else
                {
                    output.Text = string.Join("\n", polinom2.FindAllRootsNewton(-MAX_X, MAX_X, fotx));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка: " + err.Message);
            }
        }
    }
}
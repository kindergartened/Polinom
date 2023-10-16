using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PolinomSR.Polinom;

namespace PolinomForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            int min= Convert.ToInt32(textBox3.Text);
            int max= Convert.ToInt32(textBox4.Text);
            Polinom polinom1=new Polinom(n,min,max)
            richTextBox1.Text=polinom1.ToString();
        }
    }
}

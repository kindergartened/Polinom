namespace ForforPolinom
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            polinomText1 = new RichTextBox();
            polinomText2 = new RichTextBox();
            output = new RichTextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            textBox7 = new TextBox();
            label10 = new Label();
            button8 = new Button();
            textBox9 = new TextBox();
            label12 = new Label();
            powVal = new TextBox();
            pow = new Button();
            integral1 = new Button();
            button12 = new Button();
            button13 = new Button();
            parsing = new RichTextBox();
            groupBox1 = new GroupBox();
            label5 = new Label();
            parse = new Button();
            label4 = new Label();
            isFirst = new RadioButton();
            isSecond = new RadioButton();
            findRoots = new Button();
            FOTX = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // polinomText1
            // 
            polinomText1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            polinomText1.Location = new Point(31, 76);
            polinomText1.Margin = new Padding(3, 2, 3, 2);
            polinomText1.Name = "polinomText1";
            polinomText1.Size = new Size(603, 120);
            polinomText1.TabIndex = 0;
            polinomText1.Text = "";
            // 
            // polinomText2
            // 
            polinomText2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            polinomText2.Location = new Point(31, 258);
            polinomText2.Margin = new Padding(3, 2, 3, 2);
            polinomText2.Name = "polinomText2";
            polinomText2.Size = new Size(603, 113);
            polinomText2.TabIndex = 1;
            polinomText2.Text = "";
            // 
            // output
            // 
            output.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            output.Location = new Point(31, 423);
            output.Margin = new Padding(3, 2, 3, 2);
            output.Name = "output";
            output.Size = new Size(603, 117);
            output.TabIndex = 2;
            output.Text = "";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(1122, 187);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(50, 42);
            button1.TabIndex = 3;
            button1.Text = "✔";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(722, 170);
            label1.Name = "label1";
            label1.Size = new Size(23, 25);
            label1.TabIndex = 4;
            label1.Text = "n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(854, 170);
            label2.Name = "label2";
            label2.Size = new Size(44, 25);
            label2.TabIndex = 5;
            label2.Text = "min";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(984, 170);
            label3.Name = "label3";
            label3.Size = new Size(47, 25);
            label3.TabIndex = 6;
            label3.Text = "max";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(722, 197);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(110, 32);
            textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(854, 197);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(110, 32);
            textBox2.TabIndex = 12;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(984, 197);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(110, 32);
            textBox3.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(270, 36);
            label7.Name = "label7";
            label7.Size = new Size(108, 25);
            label7.TabIndex = 17;
            label7.Text = "Полином 1";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(282, 220);
            label8.Name = "label8";
            label8.Size = new Size(108, 25);
            label8.TabIndex = 18;
            label8.Text = "Полином 2";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(282, 386);
            label9.Name = "label9";
            label9.Size = new Size(96, 25);
            label9.TabIndex = 19;
            label9.Text = "Результат";
            // 
            // button3
            // 
            button3.BackColor = SystemColors.Highlight;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.Control;
            button3.Location = new Point(74, 593);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(80, 74);
            button3.TabIndex = 20;
            button3.Text = "+";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.Highlight;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Segoe UI", 28F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.Control;
            button4.Location = new Point(184, 593);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(80, 74);
            button4.TabIndex = 21;
            button4.Text = "-";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.Highlight;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            button5.ForeColor = SystemColors.Control;
            button5.Location = new Point(304, 593);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(80, 74);
            button5.TabIndex = 22;
            button5.Text = "*";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.Highlight;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            button6.ForeColor = SystemColors.Control;
            button6.Location = new Point(418, 593);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(80, 74);
            button6.TabIndex = 23;
            button6.Text = "/";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = SystemColors.Highlight;
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            button7.ForeColor = SystemColors.Control;
            button7.Location = new Point(525, 593);
            button7.Margin = new Padding(3, 2, 3, 2);
            button7.Name = "button7";
            button7.Size = new Size(80, 74);
            button7.TabIndex = 24;
            button7.Text = "%";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // textBox7
            // 
            textBox7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox7.Location = new Point(722, 273);
            textBox7.Margin = new Padding(3, 2, 3, 2);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(110, 32);
            textBox7.TabIndex = 25;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(722, 245);
            label10.Name = "label10";
            label10.Size = new Size(21, 25);
            label10.TabIndex = 27;
            label10.Text = "x";
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button8.Location = new Point(862, 267);
            button8.Margin = new Padding(3, 2, 3, 2);
            button8.Name = "button8";
            button8.Size = new Size(186, 42);
            button8.TabIndex = 29;
            button8.Text = "Точка вхождения";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // textBox9
            // 
            textBox9.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox9.Location = new Point(1070, 273);
            textBox9.Margin = new Padding(3, 2, 3, 2);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(102, 32);
            textBox9.TabIndex = 31;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(1070, 245);
            label12.Name = "label12";
            label12.Size = new Size(42, 25);
            label12.TabIndex = 33;
            label12.Text = "F(x)";
            // 
            // powVal
            // 
            powVal.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            powVal.Location = new Point(779, 85);
            powVal.Margin = new Padding(3, 2, 3, 2);
            powVal.Name = "powVal";
            powVal.Size = new Size(95, 36);
            powVal.TabIndex = 38;
            // 
            // pow
            // 
            pow.BackColor = SystemColors.Control;
            pow.FlatStyle = FlatStyle.Popup;
            pow.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            pow.ForeColor = SystemColors.ActiveCaptionText;
            pow.Location = new Point(724, 103);
            pow.Margin = new Padding(3, 2, 3, 2);
            pow.Name = "pow";
            pow.Size = new Size(49, 46);
            pow.TabIndex = 37;
            pow.Text = "^";
            pow.UseVisualStyleBackColor = false;
            pow.Click += pow_Click;
            // 
            // integral1
            // 
            integral1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            integral1.Location = new Point(742, 329);
            integral1.Margin = new Padding(3, 2, 3, 2);
            integral1.Name = "integral1";
            integral1.Size = new Size(110, 42);
            integral1.TabIndex = 41;
            integral1.Text = "Интеграл";
            integral1.UseVisualStyleBackColor = true;
            integral1.Click += integral1_Click;
            // 
            // button12
            // 
            button12.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button12.Location = new Point(858, 329);
            button12.Margin = new Padding(3, 2, 3, 2);
            button12.Name = "button12";
            button12.Size = new Size(148, 42);
            button12.TabIndex = 42;
            button12.Text = "Производная";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button13.Location = new Point(1012, 329);
            button13.Margin = new Padding(3, 2, 3, 2);
            button13.Name = "button13";
            button13.Size = new Size(148, 42);
            button13.TabIndex = 43;
            button13.Text = "Экстремумы";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // parsing
            // 
            parsing.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            parsing.Location = new Point(24, 89);
            parsing.Margin = new Padding(3, 2, 3, 2);
            parsing.Name = "parsing";
            parsing.Size = new Size(458, 101);
            parsing.TabIndex = 44;
            parsing.Text = "";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(parse);
            groupBox1.Controls.Add(parsing);
            groupBox1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(669, 456);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(581, 212);
            groupBox1.TabIndex = 45;
            groupBox1.TabStop = false;
            groupBox1.Text = "Парсинг полиномов";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.GrayText;
            label5.Location = new Point(24, 47);
            label5.Name = "label5";
            label5.Size = new Size(521, 25);
            label5.TabIndex = 51;
            label5.Text = "Введите коэффициенты полинома через пробел (1 2 3 4 5)";
            // 
            // parse
            // 
            parse.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            parse.Location = new Point(504, 124);
            parse.Margin = new Padding(3, 2, 3, 2);
            parse.Name = "parse";
            parse.Size = new Size(50, 42);
            parse.TabIndex = 46;
            parse.Text = "✔";
            parse.UseVisualStyleBackColor = true;
            parse.Click += parse_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(786, 29);
            label4.Name = "label4";
            label4.Size = new Size(330, 32);
            label4.TabIndex = 48;
            label4.Text = "Операции над полиномами";
            // 
            // isFirst
            // 
            isFirst.AutoSize = true;
            isFirst.Checked = true;
            isFirst.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            isFirst.Location = new Point(908, 98);
            isFirst.Name = "isFirst";
            isFirst.Size = new Size(126, 29);
            isFirst.TabIndex = 49;
            isFirst.TabStop = true;
            isFirst.Text = "Полином 1";
            isFirst.UseVisualStyleBackColor = true;
            // 
            // isSecond
            // 
            isSecond.AutoSize = true;
            isSecond.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            isSecond.Location = new Point(1046, 99);
            isSecond.Name = "isSecond";
            isSecond.Size = new Size(126, 29);
            isSecond.TabIndex = 50;
            isSecond.TabStop = true;
            isSecond.Text = "Полином 2";
            isSecond.UseVisualStyleBackColor = true;
            // 
            // findRoots
            // 
            findRoots.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            findRoots.Location = new Point(786, 398);
            findRoots.Margin = new Padding(3, 2, 3, 2);
            findRoots.Name = "findRoots";
            findRoots.Size = new Size(179, 42);
            findRoots.TabIndex = 51;
            findRoots.Text = "Корни, при F(x) =";
            findRoots.UseVisualStyleBackColor = true;
            findRoots.Click += findRoots_Click;
            // 
            // FOTX
            // 
            FOTX.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            FOTX.Location = new Point(992, 404);
            FOTX.Margin = new Padding(3, 2, 3, 2);
            FOTX.Name = "FOTX";
            FOTX.Size = new Size(102, 32);
            FOTX.TabIndex = 52;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1267, 686);
            Controls.Add(FOTX);
            Controls.Add(findRoots);
            Controls.Add(isSecond);
            Controls.Add(isFirst);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(integral1);
            Controls.Add(powVal);
            Controls.Add(pow);
            Controls.Add(label12);
            Controls.Add(textBox9);
            Controls.Add(button8);
            Controls.Add(label10);
            Controls.Add(textBox7);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(output);
            Controls.Add(polinomText2);
            Controls.Add(polinomText1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox polinomText1;
        private RichTextBox polinomText2;
        private RichTextBox output;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private TextBox textBox7;
        private Label label10;
        private Button button8;
        private TextBox textBox9;
        private Label label12;
        private TextBox powVal;
        private Button pow;
        private Button integral1;
        private Button button12;
        private Button button13;
        private RichTextBox parsing;
        private GroupBox groupBox1;
        private Button parse;
        private Label label4;
        private RadioButton isFirst;
        private RadioButton isSecond;
        private Label label5;
        private Button findRoots;
        private TextBox FOTX;
    }
}
using System;

namespace PolinomSR
{
    public class Polinom
    {
        /// <summary>
        /// Свойтсва класса
        /// </summary>
        /// <param name="n">Степень полинома</param>
        /// <param name="koef">Коэффициенты полинома</param>
        private int n;
        double[] koef;
        static Random r = new Random();
        public double[] Coefs { get { return koef; } }
        /// <summary>
        /// Конструктор по умолчанию создающий полином 3-й степени
        /// </summary>
        public Polinom()
        {
            n = 3;
            koef = new double[n + 1];
            koef[0] = 6; koef[1] = 5; koef[2] = 2; koef[3] = 1;
        }

        /// <summary>
        /// Конструктор создающий полином n-й степени
        /// </summary>
        /// <param name="n">степень полинома</param>
        public Polinom(int n)
        {
            this.n = n;
            koef = new double[n + 1];
        }

        /// <summary>
        /// Конструктор создающий полином n-й степени со случайными коэффициентами в диапазоне min - max
        /// </summary>
        /// <param name="n">степень полинома</param>
        /// <param name="min">минимальный параметр</param>
        /// <param name="max">максимальный параментр</param>
        public Polinom(int n, int min, int max)
        {
            this.n = n;
            koef = new double[n + 1];
            for (int i = 0; i <= n; i++)
            {
                koef[i] = r.Next(min, max);
            }
        }

        /// <summary>
        /// Конструктор создающий полином из переданных данных
        /// </summary>
        /// <param name="koefUser">массив переданных коэффициентов</param>
        public Polinom(double[] koefUser)
        {
            n = koefUser.Length - 1;
            koef = new double[n + 1];
            for (int i = 0; i <= n; i++)
            {
                koef[i] = koefUser[i];
            }
        }

        /// <summary>
        /// Переропределение метода ToString()
        /// </summary>
        /// <returns>Возвращает строку представляющую полином</returns>
        public override string ToString()
        {
            string s = "", s1 = "";
            for (int i = n; i > 0; i--)
            {
                if (koef[i] == 0)
                {
                    s1 = "";
                }
                else
                {                   
                    s1 = Math.Abs(koef[i]) == 1 ? "x^" + i : koef[i] + "x^" + i;
                    if (koef[i] > 0)
                        s1 = "+" + s1;
                    s += s1;
                }
            }
            if (koef[0] > 0)
            {
                s += "+" + koef[0];
            }
            else if (koef[0] == 0)
                s += "";
            else
            {
                s += koef[0].ToString();
            }
            return s.TrimStart('+');
        }

        /// <summary>
        /// Вычисление значения полинома в точке Х (Алгоритм Горнера)
        /// </summary>
        /// <param name="x">точка</param>
        /// <returns>Р(х)</returns>
        public double P(double x)
        {
            double res = 0;
            for (int i = n; i >= 0; i--)
            {
                res = res * x + koef[i];
            }
            return res;
        }

        /// <summary>
        /// Поиск производной полинома
        /// </summary>
        /// <returns>возвращает полином представляющий производную</returns>
        public Polinom DerivativePolinom()
        {
            double[] b = new double[n];
            for (int i = n; i >= 0; i--)
            {
                b[i - 1] = i * koef[i];
            }
            return new Polinom(b);
        }

        /// <summary>
        /// Сложение полиномов заданных коэффициентами
        /// </summary>
        /// <param name="a">1-й полином</param>
        /// <param name="b">2-й полином</param>
        /// <returns>сумма 2-х полиномов</returns>
        public static Polinom operator +(Polinom a, Polinom b)
        {
            Polinom p;
            int n, m;
            n = Math.Max(a.n, b.n);
            m = Math.Min(a.n, b.n);
            p = new Polinom(n);

            for (int i = 0; i <= m; i++) //сложение коэффициентов
            {
                p.koef[i] = a.koef[i] + b.koef[i];
            }
            if (n!=m)
                for (int i = m + 1; i <= n; i++) //дописывание старших коэффициентов
                {
                    p.koef[i] = (a.n >= b.n) ? a.koef[i] : b.koef[i];
                }
            return p;
        }

        /// <summary>
        /// Вычитание полиномов заданных коэффициентами
        /// </summary>
        /// <param name="a">первый полином</param>
        /// <param name="b">второй полином</param>
        /// <returns>разность 2-х полиномов</returns>
        public static Polinom operator -(Polinom a, Polinom b)
        {
            Polinom p;
            int n, m;
            n = Math.Max(a.n, b.n);
            m = Math.Min(a.n, b.n);
            p = new Polinom(n);

            for (int i = 0; i <= m; i++) //вычитание коэффициентов
            {
                p.koef[i] = a.koef[i] - b.koef[i];
            }
            if (n != m)
                for (int i = m + 1; i <= n; i++) //дописывание старших коэффициентов
                 {
                    p.koef[i] = (a.n >= b.n) ? a.koef[i] : -b.koef[i];
                 }
            return p;
        }

        /// <summary>
        /// Выполняет операцию умножения полинома на полином
        /// </summary>
        /// <param name="a">первый полином</param>
        /// <param name="b">второй полином</param>
        /// <returns>возвращает полином который является результатом деления</returns>
        public static Polinom operator *(Polinom a, Polinom b)
        {
            Polinom p;
            int n = a.n;
            int m = b.n;
            int k = 0;
            p = new Polinom(n + m);

            for (int i = 0; i <= n + m; i++)
            {
                for (int j = 0; j <= Math.Min(i, n); j++)
                {
                    k = i - j;
                    if (k <= m)
                    {
                        p.koef[i] += a.koef[j] * b.koef[k];
                    }
                }
            }
            return p;
        }

        /// <summary>
        /// Выполняет операцию деления полинома на полином
        /// </summary>
        /// <param name="a">первый полином</param>
        /// <param name="b">второй полином</param>
        /// <returns>возвращает полином который является результатом деления</returns>
        public static Polinom operator /(Polinom a, Polinom b)
        {
            int n = a.n;
            int m = b.n;
            if (n < m)
            {
                Polinom zero=new Polinom(n,0,0);
                return zero;
            }
            double d = 0;
            Polinom p = new Polinom(n - m);
            Polinom t = new Polinom(a.koef);
            for (int i = 0; i <= n - m; i++)
            {
                d = t.koef[n - i] / b.koef[m];
                p.koef[n - m - i] = d;
                t.koef[n - i] = 0;
                for (int j = 0; j <= m; j++)
                {
                    t.koef[n - i - j] = t.koef[n - i - j] - d * b.koef[m - j];
                }
            }
            return p;
        }

        /// <summary>
        /// Выполняет поиск отстатка от деления полинома на полином
        /// </summary>
        /// <param name="a">первый полином</param>
        /// <param name="b">второй полином</param>
        /// <returns>возвращает полином содержащий остаток от деления</returns>
        public static Polinom operator %(Polinom a, Polinom b)
        {
            return a - b * (a/b);
        }
    }
}


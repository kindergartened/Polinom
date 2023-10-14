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
        static new Random r = new Random();

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
            //ПОСЛШУАТЬ В ЛЕКЦИИ ЧТО ДА КАК ТУТ
            string s = "", s1 = "";
            for (int i = n; i > 0; i--)
            {
                if (koef[i] == 0)
                {
                    s1 = "";
                }
                else
                {
                    if (Math.Abs(koef[i]) == 1)
                    {
                        s1 = "x^" + i;
                    }
                    else
                    {
                        s1 = koef[i] + "x^" + i;
                    }
                    if (koef[i] > 0)
                    {
                        s1 = "+" + s1;
                    }
                    s += s1;
                }
                if (koef[0] >= 0)
                {
                    s += "+" + koef[0];
                }
                else
                {
                    s += koef[0].ToString();
                }
            }
            return s;
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
        /// <returns>сумма 2-ух полиномов</returns>
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
            for (int i = m + 1; i <= n; i++) //дописывание старших коэффициентов
            {
                p.koef[i] = (a.n >= b.n) ? a.koef[i] : b.koef[i];
            }

            return p;
        }

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
            for (int i = m + 1; i <= n; i++) //дописывание старших коэффициентов
            {
                p.koef[i] = (a.n >= b.n) ? a.koef[i] : -b.koef[i];
            }

            return p;
        }

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

        public static Polinom operator /(Polinom a, Polinom b)
        {
            Polinom p, t;
            int n = a.n;
            int m = b.n;
            if (n < m)
            {
                return new Polinom(0);
            }
            double d = 0;
            p = new Polinom(n - m);
            t = new Polinom(a.koef);
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

        public static Polinom operator %(Polinom a, Polinom b)
        {
            Polinom p, t;
            int n = a.n;
            int m = b.n;
            if (n < m)
            {
                return new Polinom(0);
            }
            double d = 0;
            p = new Polinom(n - m);
            t = new Polinom(a.koef);
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
            int k = 0;
            double[] af;
            while (k <= n && t.koef[n - k] == 0)
            {
                k++;
            }
            if (k <= n)
            {
                af = new double[n - k + 1];
                for (int i = 0; i <= n; i++)
                {
                    af[i] = t.koef[i];
                }
            }
            else
            {
                af = new double[1];
            }

            return new Polinom(af);
        }
    }
}


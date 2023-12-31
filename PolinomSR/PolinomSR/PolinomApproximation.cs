﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolinomSR
{
    public class Point
    {
        public double X { get; set; }  // координата x
        public double Y { get; set; }  // координата y

        /// <summary>
        /// Конструктор по умолчанию.
        /// Создает точку (0; 0).
        /// </summary>
        public Point()
        {
            X = 0;
            Y = 0;
        }
        /// <summary>
        /// Конструктор.
        /// Создает точку (x; y).
        /// </summary>
        /// <param name="x"> координата x </param>
        /// <param name="y"> координата y </param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    /// <summary>
    /// Класс матрица.
    /// </summary>
    public class Matrix
    {
        public double[,] Args { get; set; }  // матрица
        public int RowCount { get; set; }  // количество строк
        public int ColCount { get; set; }  // количество столбцов

        /// <summary>
        /// Конструктор.
        /// Создает матрицу из одной строки (вектор).
        /// </summary>
        /// <param name="x"> вектор </param>
        public Matrix(double[] x)
        {
            RowCount = x.Length;
            ColCount = 1;
            Args = new double[RowCount, ColCount];
            for (int i = 0; i < Args.GetLength(0); i++)
                for (int j = 0; j < Args.GetLength(1); j++)
                    Args[i, j] = x[i];
        }

        /// <summary>
        /// Конструктор.
        /// Копирует переданные данные в матрицу.
        /// </summary>
        /// <param name="x"> двумерный массив </param>
        public Matrix(double[,] x)
        {
            RowCount = x.GetLength(0);
            ColCount = x.GetLength(1);
            Args = new double[RowCount, ColCount];
            for (int i = 0; i < Args.GetLength(0); i++)
                for (int j = 0; j < Args.GetLength(1); j++)
                    Args[i, j] = x[i, j];
        }


        /// <summary>
        /// Получение транспонированной матрицы.
        /// </summary>
        /// <returns> транспонированная матрица </returns>
        public Matrix Transposition()
        {
            double[,] t = new double[ColCount, RowCount];
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColCount; j++)
                    t[j, i] = Args[i, j];
            return new Matrix(t);
        }

        /// <summary>
        /// Умножение матрицы на матрицу
        /// </summary>
        /// <param name="m1"> первая матрица </param>
        /// <param name="m2"> вторая матрица </param>
        /// <returns> матрица - результат умножения </returns>
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            double[,] ans = new double[m1.RowCount, m2.ColCount];
            for (int i = 0; i < m1.RowCount; i++)
            {
                for (int j = 0; j < m2.ColCount; j++)
                {
                    for (int k = 0; k < m2.RowCount; k++)
                    {
                        ans[i, j] += m1.Args[i, k] * m2.Args[k, j];
                    }
                }
            }
            return new Matrix(ans);
        }
    }
    internal class PolinomApproximation : PolinomRoots
    {

        private Point[] points = new Point[0];  // точки, по которым строится полином
        // Свойство для доступа к точкам
        public Point[] Points
        {
            get { return points; }
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// Создает полином второй степени и задаёт корни.
        /// </summary>
        public PolinomApproximation() : base()
        { }

        /// <summary>
        /// Конструктор.
        /// Создает полином n-й степени с нулевыми коэффициентами.
        /// Список корней пока пуст.
        /// </summary>
        /// <param name="n"> степень полинома </param>
        public PolinomApproximation(int n) : base(n)
        { }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином n-й степени со случайными коэффициентами
        /// целого типа из диапазона [min, max). 
        /// </summary>
        /// <param name="n"> степень полинома </param>
        /// <param name="min"> нижняя граница </param>
        /// <param name="max"> верхняя граница </param>
        public PolinomApproximation(int n, int min, int max) : base(n, min, max)
        { }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином, копируя переданные коэффициенты.
        /// </summary>
        /// <param name="coefs"> набор коэффициентов </param>
        public PolinomApproximation(double[] coefs) : base(coefs)
        { }

        /// <summary>
        /// Конструктор.
        /// Создает полином, используя переданные корни.
        /// </summary>
        /// <param name="roots"> корни полинома </param>
        public PolinomApproximation(List<double> roots) : base(roots)
        { }

        /// <summary>
        /// Конструктор.
        /// Создаёт интерполяционный полином Лагранжа по заданным точкам.
        /// </summary>
        /// <param name="points"> массив точек </param>
        public PolinomApproximation(Point[] points)
        {
            PolinomRoots p = new PolinomRoots(new double[] { 0 });
            for (int i = 0; i < points.Length; i++)
            {
                p += L(i, points) * points[i].Y;
            }
            koef = p.Coefs;
            n = p.N;
            roots = p.Roots;
            stationaryPoints = p.StationaryPoints;
            this.points = points;
        }

        /// <summary>
        /// Поиск множителя Лагранжа.
        /// Вычисляется как произведение при k = 0 до k = n-1, где n - количество точек
        /// дробей (x - xₖ) / (xᵢ - xₖ), при условием, что k != i.
        /// </summary>
        /// <param name="i"> индекс, который необходимо исключить из множителя Лагранжа </param>
        /// <param name="points"> массив точек </param>
        /// <returns></returns>
        private PolinomRoots L(int i, Point[] points)
        {
            PolinomRoots L = new PolinomRoots(new double[] { 1 });
            for (int k = 0; k < points.Length; k++)
                if (k != i)
                {
                    PolinomRoots r = new PolinomRoots(new double[] { -points[k].X, 1 });  // (x - xₖ)
                    L *= r * (1 / (points[i].X - points[k].X));
                }
            return L;
        }

        /// <summary>
        /// Конструктор.
        /// Создаёт экстраполяционный полином методом наименьших квадратов.
        /// </summary>
        /// <param name="m"> порядок полинома </param>
        /// <param name="points"> массив точек </param>
        public PolinomApproximation(int m, Point[] points)
        {
            PolinomRoots p = LeastSquaresMethod(m, points);
            koef = p.Coefs;
            n = p.N;
            roots = p.Roots;
            stationaryPoints = p.StationaryPoints;
            this.points = points;
        }

        /// <summary>
        /// Построение экстраполяционного полинома методом наименьших квадратов.
        /// </summary>
        /// <param name="m"> порядок полинома </param>
        /// <param name="points"> массив точек </param>
        /// <returns> экстраполяционный полином </returns>
        public PolinomRoots LeastSquaresMethod(int m, Point[] points)
        {
            // Массив для хранения значений базисных функций
            double[,] basic = new double[points.Length, m + 1];
            // Заполнение массива для базисных функций
            for (int i = 0; i < points.Length; i++)
                basic[i, 0] = 1;
            for (int i = 0; i < basic.GetLength(0); i++)
                for (int j = 1; j < basic.GetLength(1); j++)
                    basic[i, j] = basic[i, j - 1] * points[i].X;
            // Создание матрицы из массива значений базисных функций (МЗБФ)
            Matrix basicFuncMatr = new Matrix(basic);
            // Транспонирование МЗБФ
            Matrix transBasicFuncMatr = basicFuncMatr.Transposition();
            // Произведение транспонированного  МЗБФ на МЗБФ
            Matrix lambda = transBasicFuncMatr * basicFuncMatr;
            // Произведение транспонированого МЗБФ на матрицу значений
            double[] Y = new double[points.Length];
            for (int i = 0; i < Y.Length; i++)
                Y[i] = points[i].Y;
            Matrix beta = transBasicFuncMatr * new Matrix(Y);
            // Решение СЛАУ lambda * X = beta
            double[] beta2 = new double[m + 1];
            for (int i = 0; i < beta2.Length; i++)
                beta2[i] = beta.Args[i, 0];
            (double[,] lower, double[,] upper) LU = GetLUMatrices(lambda.Args);
            double[] coeff = ComputeX(LU.lower, LU.upper, beta2);
            // Получение результирующего полинома
            return new PolinomRoots(coeff);
        }

        /// <summary>
        /// Разложение матрицы на нижнюю (L) и верхнюю (U) треугольные матрицы
        /// таким образом, что A = L * U.
        /// </summary>
        /// <param name="A"> матрица коэффициентов </param>
        /// <returns> кортеж - нижняя и верхняя треугольные матрицы </returns>
        private (double[,] lower, double[,] upper) GetLUMatrices(double[,] A)
        {
            int n = A.GetLength(0);
            double[,] lower = new double[n, n];
            double[,] upper = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int k = i; k < n; k++)
                {
                    double sum = 0;
                    for (int j = 0; j < i; j++)
                        sum += lower[i, j] * upper[j, k];
                    upper[i, k] = A[i, k] - sum;
                }
                for (int k = i; k < n; k++)
                {
                    if (i == k)
                        lower[i, i] = 1;
                    else
                    {
                        double sum = 0;
                        for (int j = 0; j < i; j++)
                            sum += lower[k, j] * upper[j, i];
                        lower[k, i] = (A[k, i] - sum) / upper[i, i];
                    }
                }
            }
            return (lower, upper);
        }

        /// <summary>
        /// Вычисление вектора X по нижней и верхней треугольной матрице.
        /// Сначала находим вектор Z из соотношения L * Z = B, 
        /// затем находим вектор X из соотношения U * X = Z
        /// </summary>
        /// <param name="lower"> нижняя треугольная матрица </param>
        /// <param name="upper"> верхняя треугольная матрица </param>
        /// <param name="B"> массив коэффициентов </param>
        /// <returns> вектор X - решение СЛАУ </returns>
        private double[] ComputeX(double[,] lower, double[,] upper, double[] B)
        {
            double[] Z = new double[B.Length];
            Z[0] = B[0] / lower[0, 0];
            for (int i = 1; i < B.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Z[i] += -lower[i, j] * Z[j];
                }
                Z[i] = (Z[i] + B[i]) / lower[i, i];
            }

            double[] X = new double[Z.Length];
            X[X.Length - 1] = Z[X.Length - 1] / upper[X.Length - 1, X.Length - 1];
            for (int i = X.Length - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < X.Length; j++)
                {
                    X[i] += -upper[i, j] * X[j];
                }
                X[i] = (X[i] + Z[i]) / upper[i, i];
            }
            return X;
        }

        /// <summary>
        /// Метод нахождения среднеквадратичного отклонения.
        /// </summary>
        /// <param name="p"> полином </param>
        /// <param name="points"> точки </param>
        /// <returns> среднеквадратичное отклонение </returns>
        public double GetDelta(Point[] points)
        {
            double[] dif = new double[points.Length];
            double[] f = new double[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                f[i] = P(points[i].X);
                dif[i] = Math.Pow(f[i] - points[i].Y, 2);
            }
            return Math.Sqrt(dif.Sum() / points.Length);
        }
    }
}
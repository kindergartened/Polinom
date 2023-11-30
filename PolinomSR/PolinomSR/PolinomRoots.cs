using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolinomSR
{
    /// <summary>
    /// Перечисление точка экстремума.
    /// </summary>
    public enum ExtremumPointType
    {
        Min,  // точка минимума
        Max   // точка максимума
    }

    /// <summary>
    /// Класс полином с возможностью вычисления корней и точек экстремума.
    /// </summary>
    public class PolinomRoots : Polinom
    {
        private protected List<double> roots = new List<double>(); 
        private protected List<(double x, double y, ExtremumPointType stPoint)> extremumPoints = new();  

        /// <summary>
        /// Свойство для доступа к корням.
        /// </summary>
        public List<double> Roots { get { return roots; } }

        /// <summary>
        /// Свойство для доступа к точкам экстремума.
        /// </summary>
        public List<(double x, double y, ExtremumPointType stPoint)> ExtremumPoints { get { return extremumPoints; } }

        /// <summary>
        /// Конструктор по умолчанию.
        /// Создает полином второй степени и задаёт корни.
        /// </summary>
        public PolinomRoots() : base()
        {
            roots = new List<double>();
            extremumPoints = new List<(double x, double y, ExtremumPointType stPoint)>();
            roots.Add(1);
            roots.Add(2);
        }

        /// <summary>
        /// Конструктор.
        /// Создает полином n-й степени с нулевыми коэффициентами.
        /// Список корней пока пуст.
        /// </summary>
        /// <param name="n"> степень полинома</param>
        public PolinomRoots(int n) : base(n)
        {
            roots = new List<double>();
            extremumPoints = new List<(double x, double y, ExtremumPointType stPoint)>();
        }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином n-й степени со случайными коэффициентами
        /// целого типа из диапазона [min, max). 
        /// </summary>
        /// <param name="n"> степень полинома </param>
        /// <param name="min"> нижняя граница </param>
        /// <param name="max"> верхняя граница </param>
        public PolinomRoots(int n, int min, int max) : base(n, min, max)
        {
            roots = new List<double>();
            extremumPoints = new List<(double x, double y, ExtremumPointType stPoint)>();
        }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином, копируя переданные коэффициенты.
        /// </summary>
        /// <param name="koef"> набор коэффициентов </param>
        public PolinomRoots(double[] koef) : base(koef)
        {
            roots = new List<double>();
            extremumPoints = new List<(double x, double y, ExtremumPointType stPoint)>();
        }

        /// <summary>
        /// Умножение полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> произведение полиномов </returns>
        public static PolinomRoots operator *(PolinomRoots p1, PolinomRoots p2)
        {
            int n = p1.n;
            int m = p2.n;
            double[] resCoef = new double[n + m + 1];
            for (int i = 0; i <= n + m; i++)  // i указывает на индекс в итоговом массиве
                for (int k = 0; k <= Math.Min(i, n); k++)  // k указывает на индекс элемента в полиноме с меньшей степенью
                {
                    int j = i - k;  // j указывает на индекс элемента в полиноме с большей степенью
                    if (j <= m)  // если j не вышло за границы массива коэффициентов
                        resCoef[i] += p1.koef[k] * p2.koef[j];
                }
            PolinomRoots res = new PolinomRoots(resCoef);
            // Получение корней произведения полиномов
            foreach (double root in p1.Roots)
                res.roots.Add(root);
            foreach (double root in p2.Roots)
                res.roots.Add(root);
            return res;
        }

        /// <summary>
        /// Деление полиномов нацело.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> полином - результат деления нацело </returns>
        public static PolinomRoots operator /(PolinomRoots p1, PolinomRoots p2)
        {
            int n = p1.n, m = p2.n;
            if (n < m)  // если степень первого полинома меньше степени второго, то результат деления нацело - 0
                return new PolinomRoots(0);
            double[] pCoef = new double[n - m + 1];  // коэффициенты итогового полинома 
            double[] tCoef = new double[n + 1];  // коэффициенты делимого
            for (int i = 0; i <= n; i++)
                tCoef[i] = p1.koef[i];
            for (int i = 0; i <= n - m; i++)
            {
                double d = tCoef[n - i] / p2.koef[m];  // коэффициент итогового полинома
                pCoef[n - m - i] = d;
                tCoef[n - i] = 0;  // старший коэффициент делимого уничтожается
                for (int k = 1; k <= m; k++)
                    tCoef[n - i - k] -= d * p2.koef[m - k];  // вычитание из делимого результата умножения d на p2
            }
            return new PolinomRoots(pCoef);
        }

        /// <summary>
        /// Существует ли корень полинома на заданном интервале.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <param name="y"> корень (по умолчанию 0) </param>
        /// <returns> true - если существует, иначе - false </returns>
        public bool ExistRoot(ref double a, ref double b, double y = 0)
        {
            PolinomRoots pol = new PolinomRoots(koef);
            pol.koef[0] -= y;  // если мы хотим найти значения x, при которых функция равна y,
            // то от полинома можно отнять этот y и искать значения x, при которых функция равна 0
            double eps = 1e-1;
            if (pol.P(a) * pol.P(b) <= 0)
                return true;
            else if (b - a < eps)
                return false;
            else
            {
                double mid = (a + b) / 2;
                if (pol.ExistRoot(ref a, ref mid))
                {
                    b = mid;
                    return true;
                }
                else if (pol.ExistRoot(ref mid, ref b))
                {
                    a = mid;
                    return true;
                }
                else
                    return false;
            }
        }

        /// <summary>
        /// Поиск корня на заданном интервале
        /// при условии, что корень существует.
        /// Использует метод Ньютона.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <param name="y"> корень (по умолчанию 0) </param>
        /// <returns> корень </returns>
        public double FindRootNewton(double a, double b, double y = 0)
        {
            PolinomRoots pol = new PolinomRoots(koef);
            pol.koef[0] -= y;
            double eps = 1e-7;
            double x0 = 0;  // начальное приближение
            if (pol.P(a) * pol.Derivative().Derivative().P(a) > 0)
                x0 = a;
            else if (pol.P(b) * pol.Derivative().Derivative().P(b) > 0)
                x0 = b;
            double xn = x0 - pol.P(x0) / pol.Derivative().P(x0);  // первое приближение
            double xn2 = xn - pol.P(xn) / pol.Derivative().P(xn);  // второе приближение
            while (Math.Abs(xn - xn2) >= eps)
            {
                xn = xn2;
                xn2 = xn - pol.P(xn) / pol.Derivative().P(xn);  // вычисляем следующее приближение
            }
            return xn2;
        }

        /// <summary>
        /// Поиск всех корней полинома на заданном интервале.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <param name="y"> корень (по умолчанию 0) </param>
        /// <returns> список всех корней </returns>
        public List<double> FindAllRootsNewton(double a, double b, double y = 0)
        {
            double ta = a, tb = b;
            List<double> res = new List<double>();
            PolinomRoots q = new PolinomRoots(koef);  // копия исходного полинома
            q.koef[0] -= y;
            double r;
            PolinomRoots one = new PolinomRoots(1);  // полином, у которого старший коэффициент 1, а свободный -r
            one.koef[1] = 1;
            while (q.ExistRoot(ref a, ref b))
            {
                r = q.FindRootNewton(a, b);
                res.Add(r);
                one.koef[0] = -r;
                q /= one;  // делим полином на (x - r), тем самым удаляем корень r из полинома
                a = ta;
                b = tb;
            }
            roots = res;
            return res;
        }
        
        /// <summary>
        /// Поиск всех точек экстремума на заданном интервале.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <returns> список всех точек экстремума </returns>
        public List<(double x, double y, ExtremumPointType stPoint)> FindAllExtremumPoints(double a, double b)
        {
            double eps = 1e-5;
            PolinomRoots derivative = new PolinomRoots(Derivative().Coefs);   
            List<double> roots = derivative.FindAllRootsNewton(a, b);  // точки экстремума - точки, в которых производная равна 0
            List<(double, double, ExtremumPointType)> res = new List<(double, double, ExtremumPointType)>();
            for (int i = 0; i < roots.Count; i++)
            {
                double p = P(roots[i]);
                if (p < P(roots[i] + eps))  // если значение в точке i меньше соседнего значения
                    res.Add((roots[i], p, ExtremumPointType.Min));
                else  // если значение в точке i больше соседних значений
                    res.Add((roots[i], p, ExtremumPointType.Max));
            }
            extremumPoints = res;
            return res;
        }
    }
}

using PolinomSR;
using static PolinomSR.Polinom;
namespace Tests
{
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod]
        public void UmnoweniePolynomials_ReturnsCorrectResult()
        {
            Polinom p1 = new Polinom(new double[] { -2, 0, 3 }); // 3x^2 - 2
            Polinom p2 = new Polinom(new double[] { 1, 2 }); // 2x + 1

            Polinom result = p1 * p2; // (3x^2 - 2) * (2x + 1) = 6x^3 + 3x^2 - 4x - 2
            CollectionAssert.AreEqual(new Polinom(new double[] { -2, -4, 3, 6 }).Coefs, result.Coefs);
        }

        [TestMethod]
        public void RazdeleniePolynomials_ReturnsCorrectResult()
        {
            Polinom p1 = new Polinom(new double[] { 1, 3, -2, 4 }); // 4x^3 - 2x^2 + 3x + 1
            Polinom p2 = new Polinom(new double[] { 1, 1 }); // x + 1

            Polinom result = p1 / p2; // (4x^3 - 2x^2 + 3x + 1) / (x + 1) = 4x^2 - 6x + 9
            CollectionAssert.AreEqual(new Polinom(new double[] { 9, -6, 4 }).Coefs, result.Coefs);
        }

        [TestMethod]
        public void SloweniePolynomials_ReturnsCorrectResult()
        {
            Polinom p1 = new Polinom(new double[] { 2, 4, 3 }); // 3x^2 + 4x + 2
            Polinom p2 = new Polinom(new double[] { 1, 5, 2 }); // 2x^2 + 5x + 1

            Polinom result = p1 + p2; // (3x^2 + 4x + 2) + (2x^2 + 5x + 1) = 5x^2 + 9x + 3
            CollectionAssert.AreEqual(new Polinom(new double[] { 3, 9, 5 }).Coefs, result.Coefs);
        }

        [TestMethod]
        public void VichitaniePolynomials_ReturnsCorrectResult()
        {
            Polinom p1 = new Polinom(new double[] { -1, 2, 5 }); // 5x^2 + 2x^1 - 1
            Polinom p2 = new Polinom(new double[] { 1, -1, 2 }); // 2x^2 - x^1 + 1

            Polinom result = p1 - p2; // (5x^2 + 2x^1 - 1) - (2x^2 - x^1 + 1) = 3x^2 + 3x^1 - 2

            CollectionAssert.AreEqual(new Polinom(new double[] { -2, 3, 3 }).Coefs, result.Coefs);
        }
    }
}
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
            Polinom p1 = new Polinom(new double[] { 3, 0, -2 }); // 3x^2 - 2
            Polinom p2 = new Polinom(new double[] { 2, 1 }); // 2x + 1

            Polinom result = p1 * p2; // (3x^2 - 2) * (2x + 1) = 6x^3 + x^2 - 4x - 2
            CollectionAssert.AreEqual((dynamic)new Polinom(new double[] { 6, 1, -4, -2 }).Coefs, (dynamic)result.Coefs);
        }

        [TestMethod]
        public void RazdeleniePolynomials_ReturnsCorrectResult()
        {
            Polinom p1 = new Polinom(new double[] { 4, -2, 3, 1 }); // 4x^3 - 2x^2 + 3x + 1
            Polinom p2 = new Polinom(new double[] { 1, 1 }); // x + 1

            Polinom result = p1 / p2; // (4x^3 - 2x^2 + 3x + 1) / (x + 1) = 4x^2 - 6x + 9

            Assert.AreEqual(new Polinom(new double[] { 4, -6, 9 }), result);
        }

        [TestMethod]
        public void SloweniePolynomials_ReturnsCorrectResult()
        {
            Polinom p1 = new Polinom(new double[] { 3, 4, 2 }); // 3x^2 + 4x + 2
            Polinom p2 = new Polinom(new double[] { 2, 5, 1 }); // 2x^2 + 5x + 1

            Polinom result = p1 + p2; // (3x^2 + 4x + 2) + (2x^2 + 5x + 1) = 5x^2 + 9x + 3

            Assert.AreEqual(new Polinom(new double[] { 5, 9, 3 }), result);
        }

        [TestMethod]
        public void VichitaniePolynomials_ReturnsCorrectResult()
        {
            Polinom p1 = new Polinom(new double[] { 5, 2, -1 }); // 5x^3 + 2x^2 - x
            Polinom p2 = new Polinom(new double[] { 2, -1, 1 }); // 2x^3 - x^2 + x

            Polinom result = p1 - p2; // (5x^3 + 2x^2 - x) - (2x^3 - x^2 + x) = 3x^3 + 3x^2 - 2x

            Assert.AreEqual(new Polinom(new double[] { 3, 3, -2 }), result);
        }
    }
}
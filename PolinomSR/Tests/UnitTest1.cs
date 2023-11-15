using PolinomSR;
namespace Tests
{
    [TestClass]
    public class PolynomialTests
    {
        PolinomSR.Polinom p1;
        PolinomSR.Polinom p2;
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
        [TestMethod]
        public void TestIntegrate()
        {
            Polinom p1 = new Polinom(new double[] { -1, 2, 6 });
            Polinom result = p1.Integral(); 
            CollectionAssert.AreEqual(new Polinom(new double[] { 0, -1, 1, 2 }).Coefs, result.Coefs);
        }
        [TestMethod]
        public void TestDerative()
        {
            Polinom p1 = new Polinom(new double[] { -1, 2, 5 }); // 5x^2 + 2x^1 - 1
            Polinom result = p1.Derivative(); // 10x+2
            
            CollectionAssert.AreEqual(new Polinom(new double[] { 2,10 }).Coefs, result.Coefs);
        }
        [TestMethod]
        public void TestX()
        {
            Polinom p1 = new Polinom(new double[] { -1, 2, 5 }); // 5x^2 + 2x^1 - 1
            double x = 2;
            double result=p1.P(x);
            double res2 = 23;
            Console.WriteLine(result);
            Console.WriteLine(res2);
            Assert.AreEqual(result,res2);
        }
        [TestMethod]
        public void RazdeleniePolynomials_ReturnsCorrectResult1()
        {
            Polinom p1 = new Polinom(new double[] { 1,1 }); 
            Polinom p2 = new Polinom(new double[] { 1, 3, -2, 4 }); 

            Polinom result = p1 / p2; 
            CollectionAssert.AreEqual(new Polinom(new double[] { 0, 0 }).Coefs, result.Coefs);
        }
        [TestMethod]
        public void TestPow()
        {
            Polinom p1 = new Polinom(new double[] { 1, 1 });
            int n = 2;
            Polinom result = p1.Pow(n); //1,2,1
            CollectionAssert.AreEqual(new Polinom(new double[] { 1,2,1 }).Coefs, result.Coefs);
        }
        [TestMethod]
        public void TestRoots()
        {
            PolinomRoots p1 = new PolinomRoots(new double[] { 3, 1, 3 });
            List<double> result = p1.FindAllRootsNewton(-10000, 10000, 10);  // 3x^2 + x + 3 = 10
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = Math.Round(result[i], 5);
            }
            CollectionAssert.AreEquivalent(new Polinom(new double[] { -1.70326, 1.36992 }).Coefs, result);
        }
        [TestMethod]
        public void TestMod()
        {
            Polinom p1 = new Polinom(new double[] { 1, 1 });
            Polinom p2 = new Polinom(new double[] { 1, 3, -2, 4 });

            Polinom result = p1 % p2;
            Assert.AreEqual(new Polinom(new double[] { 1, 1 }).ToString(), result.ToString());
        }
    }
}
using TesterProyect;
using TesterProyect.Interfaces;

namespace TestPro
{
    [TestClass]
    public sealed class Test1
    {
        private IInyectionTester? _inyectionTester;

        [TestInitialize]
        public void Setup()
        {
            _inyectionTester = new InyectionTester();
        }

        [TestMethod]
        public void DevuelveStringTrim_ShouldTrimString()
        {
            // Arrange
            string input = "  test  ";
            string expected = "Result string: test";

            // Act
            string result = _inyectionTester.DevuelveStringTrim(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DevuelveSuma_ShouldReturnCorrectSum()
        {
            // Arrange
            int sumA = 5;
            int sumB = 3;
            int expected = 8;

            // Act
            int result = _inyectionTester.DevuelveSuma(sumA, sumB);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DevuelveSuma_ShouldHandleNegativeNumbers()
        {
            // Arrange
            int sumA = -5;
            int sumB = 3;
            int expected = -2;

            // Act
            int result = _inyectionTester.DevuelveSuma(sumA, sumB);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DevuelveSuma_ShouldHandleZero()
        {
            // Arrange
            int sumA = 0;
            int sumB = 0;
            int expected = 0;

            // Act
            int result = _inyectionTester.DevuelveSuma(sumA, sumB);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}